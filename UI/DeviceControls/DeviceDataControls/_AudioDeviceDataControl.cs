using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _AudioDeviceDataControl : DeviceDataControl
    {
        public _AudioDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _AudioDeviceDataControl() : base()
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
            var CurrentSubDevice = (SoundDevice.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Manufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_PowerManagment_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.PowerManagementSupported, "N/A");
        }
    }
}
