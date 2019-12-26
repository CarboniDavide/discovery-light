﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.Charts;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BaseFreeStorageDevicePerformance : DevicePerformanceControl
    {
        public _BaseFreeStorageDevicePerformance(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BaseFreeStorageDevicePerformance() : base() {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection("Name", "_Total");
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_DISK.SubDevice)this.CurrentSubDevice;
            chartHD.FillSize = ChartPerform.FillOrDefault(x => 100 - x.AsInt32(), CurrentPerformance.PercentFreeSpace);
        }
    }
}
