using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _OperatingSystemDataControl : DeviceDataControl
    {
        public _OperatingSystemDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _OperatingSystemDataControl() : base()
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
            var CurrentDevice = (DiscoveryLight.Core.Device.Data.OperatingSystem.SubDevice)this.CurrentSubDevice;
            lbl_Version_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.BuildNumber, "N/A");
            lbl_SystemOS_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Caption, "N/A");
            lbl_Producer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Architectur_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.OSArchitecture, "N/A");
            abort();
        }
    }
}
