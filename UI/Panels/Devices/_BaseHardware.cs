﻿using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System.Data;
using System.Linq;

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
        }
    }
}
