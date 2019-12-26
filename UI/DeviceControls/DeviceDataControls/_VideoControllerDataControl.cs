using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _VideoControllerDataControl : DeviceDataControl
    {
        public _VideoControllerDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _VideoControllerDataControl() : base()
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
            var CurrentSubDevice = (VideoController.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A"); ;
            lbl_Manufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.AdapterCompatibility, "N/A");
            lbl_Adapter_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.AdapterDACType, "N/A");
            lbl_Memory_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsUInt64() / 1024, CurrentSubDevice.AdapterRAM, "N/A", "{0:N0}") + " MB";
            lbl_BitsPixel_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.CurrentBitsPerPixel, "N/A");
            lbl_HorizontalResolution_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.CurrentHorizontalResolution, "N/A", "{0:N0}") + " Pixel";
            lbl_VerticalResolution_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.CurrentVerticalResolution, "N/A", "{0:N0}") + " Pixel";
            lbl_FreqNow_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.CurrentRefreshRate, "N/A") + " Hz";
            lbl_FreqMax_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MaxRefreshRate, "N/A") + " Hz";
            lbl_FreqMin_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MinRefreshRate, "N/A") + " Hz";
            lbl_ColorsNumber_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.CurrentNumberOfColors, "N/A", "{0:N0}"); ;
            lbl_ModalitySupported_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.VideoModeDescription, "N/A"); ;
        }
    }
}
