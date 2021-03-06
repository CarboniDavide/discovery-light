﻿using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Memory : DevicePanel
    {
        public _Memory()
        {
            InitializeComponent();
            this.MemoryDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_RAM)).First());
            this.PhysicalMemoryDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemory)).First());
            this.PhysicalMemoryArrayDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemoryArray)).First());
        }

        private void _Memory_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(PhysicalMemoryDataControl, null, null);
        }
    }
}
