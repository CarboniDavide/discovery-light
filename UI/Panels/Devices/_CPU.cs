using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _CPU : DevicePanel
    {
        public _CPU()
        {
            InitializeComponent();
            this.CpuDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_CPU)).First());
            this.SystemDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_SYSTEM)).First());
            this.CpuDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(Processor)).First());
        }
        private void ExtendedACtionToRun()
        {
            CpuDevicePerformanceControl.GraphComponents_Add(CpuDeviceDataControl.CurrentSubDevice);
        }

        private void _CPU_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(CpuDeviceDataControl, CpuDevicePerformanceControl, ExtendedACtionToRun);
        }
    }
}
