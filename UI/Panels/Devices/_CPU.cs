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
using WinformComponents;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _CPU : UserControl
    {
        public _CPU() : base()
        {
            InitializeComponent();
            
        }
        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (CPU)this.CpuDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (CPU.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID + " - " + block.Name);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            this.CpuDeviceDataControl.CurrentSubDevice = this.CpuDeviceDataControl.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedIndex.ToString())).FirstOrDefault();
            this.CpuDevicePerformanceControl.CurrentSubDevice = Convert.ToInt32(this.CpuDeviceDataControl.CurrentSubDevice.DeviceID);

            var CurrentPerformanceCPU = (PERFORM_CPU)this.CpuDevicePerformanceControl.CurrentPerformance;
            CurrentPerformanceCPU.SelectedCpu = CpuDeviceDataControl.CurrentSubDevice.DeviceID;
            var CurrentDevice = this.CpuDeviceDataControl.CurrentSubDevice;
            this.CpuDevicePerformanceControl.GraphComponents_Add(CurrentDevice);
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }

        private void _CPU_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
