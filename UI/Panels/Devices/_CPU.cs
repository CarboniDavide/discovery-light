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
using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _CPU : DevicePanel
    {
        public _CPU()
        {
            InitializeComponent();
            this.CpuDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_CPU)).First());
            this.SystemDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_SYSTEM)).First());
            this.CpuDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(Processor)).First());

            // init subdevice
            this.SystemDevicePerformanceControl.CurrentSubDevice = this.SystemDevicePerformanceControl.CurrentDevice.Devices.First();
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
