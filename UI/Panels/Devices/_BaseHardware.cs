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
using System.Threading;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _BaseHardware : DevicePanel
    {
        public _BaseHardware()
        {
            InitializeComponent();
            this.ComputerSystem.Init(Program.Devices.Where(d => d.ClassType == typeof(ComputerSystem)).First());
            this.ComputerSystemProduct.Init(Program.Devices.Where(d => d.ClassType == typeof(ComputerSystemProduct)).First());
            this.OperatingSystem.Init(Program.Devices.Where(d => d.ClassType == typeof(Core.Device.Data.OperatingSystem)).First());
            
            this._BaseFreeRamDevicePerformance.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_RAM)).First());
            this._BaseFreeStorageDevicePerformance.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_DISK)).First());
            this._BaseProcessorUsageDevicePerformance.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_CPU)).First());

            // Init SubDevice
            this._BaseFreeRamDevicePerformance.CurrentSubDevice = this._BaseFreeRamDevicePerformance.CurrentDevice.Devices.First();
            this._BaseFreeStorageDevicePerformance.CurrentSubDevice = this._BaseFreeStorageDevicePerformance.CurrentDevice.GetDevice("Name", "_Total");
            this._BaseProcessorUsageDevicePerformance.CurrentSubDevice = this._BaseProcessorUsageDevicePerformance.CurrentDevice.GetDevice("Name", "_Total");
        }
    }
}
