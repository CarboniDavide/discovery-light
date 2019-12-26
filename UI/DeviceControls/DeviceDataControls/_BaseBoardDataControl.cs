using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _BaseBoardDataControl : DeviceDataControl
    {
        public _BaseBoardDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _BaseBoardDataControl() : base()
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
            var CurrentDevice = (BaseBoard.SubDevice)this.CurrentSubDevice;
            lbl_Manufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Model_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Product, "N/A");
            lbl_Version_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Version, "N/A");
            abort();
        }
    }
}
