using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _PhysicalDisk : DevicePanel
    {
        public _PhysicalDisk()
        {
            InitializeComponent();
            this.PhysicalDiskDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_DISK)).First());
            this.PhysicalDiskDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(DiskDrive)).First());
        }

        private void ChargeListOfSubDevicesInit()
        {
            // fill list with all physical disk
            List<String> devices = new List<string>();
            var CurrentDevice = (DiskDrive)this.PhysicalDiskDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (DiskDrive.Block block in CurrentDevice.Blocks)
                devices.Add(block.DeviceID + " - " + block.DriveName + " " + block.Name);

            // don't update loaded values in comboBox if not new physical disk are founded
            if (devices.SequenceEqual(cmb_Blocks.Items.Cast<String>().ToList())) return;

            // if a physical disk are removed or added then manage changes
            if (cmb_Blocks.Items.Count != 0) {
                string currentSelected = cmb_Blocks.SelectedItem.ToString();                   // get current selection
                cmb_Blocks.Items.Clear();                                                      // remove all loaded disk's name in the comboBox
                cmb_Blocks.Items.AddRange(devices.ToArray());                                  // update comboBox with the last updated list of disks                      
                // use old selected disk in comboBox if exists in the new list // differently select the first in the list as default
                cmb_Blocks.SelectedIndex = cmb_Blocks.Items.Contains(currentSelected) ? cmb_Blocks.Items.IndexOf(currentSelected): 0;
                return;
            }
            
            // for a empty list
            cmb_Blocks.Items.AddRange(devices.ToArray());
            cmb_Blocks.SelectedIndex = 0;
            
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // change physical disk
            if (cmb_Blocks.SelectedItem.ToString() == " -  ") return;
            this.PhysicalDiskDeviceDataControl.CurrentSubDevice = (DiskDrive.Block)this.PhysicalDiskDeviceDataControl.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedItem.ToString().Substring(0,1))).FirstOrDefault();
            var CurrentPerformance = (PERFORM_DISK)this.PhysicalDiskDevicePerformanceControl.CurrentPerformance;
            CurrentPerformance.DriveIndex = Convert.ToInt32(this.PhysicalDiskDeviceDataControl.CurrentSubDevice.DeviceID);
        }

        private void InitSubDevicesID()
        {
            // fill the list with all founded physical disk
            this.ChargeListOfSubDevicesInit();  
            // run when update occured. Check if a physical disk drive are added or removed
            this.PhysicalDiskDeviceDataControl.OnUpdateFinish += new EventHandler(OnDeviceUpdateFinish);
        }

        private void OnDeviceUpdateFinish(object sender, EventArgs e)
        {
            // check if a physical disk as removed or added then update list of selection
            this.Invoke((System.Action)(() => { ChargeListOfSubDevicesInit(); }));
        }

        private void _PhysicalDisk_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
