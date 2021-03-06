﻿using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Utils;
using System.Linq;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _SystemSlotDataControl : DeviceDataControl
    {
        public _SystemSlotDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _SystemSlotDataControl() : base()
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
            var CurrentDevice = (SystemSlot.SubDevice)this.CurrentSubDevice;
            lbl_SlotNumber_Value.Text = MobPropertyDataConvert.AsDefaultValue(new MobProperty(this.CurrentDevice.SubDevices.Count().ToString()), "N/A"); ;
            abort();
        }
    }
}
