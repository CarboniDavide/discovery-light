using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _ComputerSystemProductDataControl : DeviceDataControl
    {
        public _ComputerSystemProductDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _ComputerSystemProductDataControl() : base()
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
            var CurrentDevice = (ComputerSystemProduct.SubDevice)this.CurrentSubDevice;
            lbl_NumberID_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.IdentifyingNumber, "N/A");
            abort();
        }
    }
}
