﻿using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _SystemDevicePerformanceControl : DevicePerformanceControl
    {
        public _SystemDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _SystemDevicePerformanceControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection();
        }
        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_SYSTEM.SubDevice)this.CurrentSubDevice;
            lbl_Threads_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.Threads, "N/A", "{0:N0}");
            lbl_Process_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.Processes, "N/A", "{0:N0}");
        }
    }
}
