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
            this.PhysicalDiskDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(DISK)).First());
        }

        private void ChargeListOfSubDevicesInit()
        {
            List<String> devices = new List<string>();
            var CurrentDevice = (DISK)this.PhysicalDiskDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (DISK.Block block in CurrentDevice.Blocks)
                devices.Add(block.DeviceID + " - " + block.DriveName + " " + block.Name);

            if (devices.SequenceEqual(cmb_Blocks.Items.Cast<String>().ToList())) return;

            if (cmb_Blocks.Items.Count != 0) {
                string currentSelected = cmb_Blocks.SelectedItem.ToString();
                cmb_Blocks.Items.Clear();
                cmb_Blocks.Items.AddRange(devices.ToArray());
                if (cmb_Blocks.Items.Contains(currentSelected))
                    cmb_Blocks.SelectedIndex = cmb_Blocks.Items.IndexOf(currentSelected);
                else
                    cmb_Blocks.SelectedIndex = 0;
            }
            else
            {
                cmb_Blocks.Items.AddRange(devices.ToArray());
                cmb_Blocks.SelectedIndex = 0;
            }
            
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            this.PhysicalDiskDeviceDataControl.CurrentSubDevice = (DISK.Block)this.PhysicalDiskDeviceDataControl.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedItem.ToString().Substring(0,1))).FirstOrDefault();
            this.PhysicalDiskDevicePerformanceControl.CurrentSubDevice = Convert.ToInt32(this.PhysicalDiskDeviceDataControl.CurrentSubDevice.DeviceID);

            var CurrentPerformance = (PERFORM_DISK)this.PhysicalDiskDevicePerformanceControl.CurrentPerformance;
            CurrentPerformance.DriveIndex = Convert.ToInt32(this.PhysicalDiskDeviceDataControl.CurrentSubDevice.DeviceID);
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.PhysicalDiskDeviceDataControl.OnUpdateFinish += new EventHandler(OnDeviceUpdate);
        }

        private void OnDeviceUpdate(object sender, EventArgs e)
        {
            this.Invoke((System.Action)(() => { ChargeListOfSubDevicesInit(); }));
        }

        private void _PhysicalDisk_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
