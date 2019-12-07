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
    public partial class _Memory : DevicePanel
    {
        public _Memory()
        {
            InitializeComponent();
            this.MemoryDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_RAM)).First());
            this.PhysicalMemoryDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemory)).First());
            this.PhysicalMemoryArrayDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemoryArray)).First());
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (PhysicalMemory)this.PhysicalMemoryDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (PhysicalMemory.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            if (cmb_Blocks.SelectedItem.ToString() == null) return;
            this.PhysicalMemoryDataControl.CurrentSubDevice = this.PhysicalMemoryDataControl.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedIndex.ToString())).FirstOrDefault();
            this.MemoryDevicePerformanceControl.CurrentSubDevice = Convert.ToInt32(this.PhysicalMemoryDataControl.CurrentSubDevice.DeviceID);
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }

        private void _Memory_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
