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
            this.PhysicalDiskDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_DISK)).First().Properties);
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (DISK)this.PhysicalDiskDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (DISK.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID + " - " + block.DriveName + " " + block.Name);
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
            this.cmb_Blocks.SelectedIndex = 0;
        }

        private void _PhysicalDisk_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
