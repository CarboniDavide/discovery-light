using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _NetworkDeviceDataControl : DeviceDataControl
    {
        public _NetworkDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _NetworkDeviceDataControl() : base()
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
            var CurrentSubDevice = (NetworkAdapter.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Tipology_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.NetConnectionID, "N/A");
            lbl_Manufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_AdapterType_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.AdapterType, "N/A");
            lbl_DeviceID_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.DeviceID, "N/A");
            lbl_Speed_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsDouble() / 1000000, CurrentSubDevice.Speed, "N/A") + " Mbps";
            lbl_MACAddress_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MACAddress, "N/A");
            lbl_IPAddress_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsArray(0), CurrentSubDevice.IpAddress, "N/A");
            lbl_PrimaryDNS_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsArray(0), CurrentSubDevice.DNSServerSearchOrder, "N/A");
            lbl_SecondaryDNS_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsArray(1), CurrentSubDevice.DNSServerSearchOrder, "N/A");
            lbl_SubnetMask_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsArray(0), CurrentSubDevice.IpSubnet, "N/A");
            lbl_Getway_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsArray(0), CurrentSubDevice.DefaultIPGateway, "N/A");
        }
    }
}
