using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _CpuDeviceDataControl : DeviceDataControl
    {
        public _CpuDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _CpuDeviceDataControl() : base()
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
            var CurrentSubDevice = (Processor.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Size_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.AddressWidth, "N/A") + " bit";
            lbl_Description_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Description, "N/A");
            lbl_Producteur_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_Revision_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Revision, "N/A");
            lbl_Socket_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.SocketDesignation, "N/A");
            lbl_Core_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.NumberOfCores, "N/A");
            lbl_Thread_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.NumberOfLogicalProcessors, "N/A");
            lbl_MaxSpeed_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MaxClockSpeed, "N/A", "{0:N0}") + " Mhz";
            lbl_L1CacheSize_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsInt16() / 4, CurrentSubDevice.L2CacheSize, "N/A") + " Kb";
            lbl_L2CacheSize_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.L2CacheSize, "N/A") + " Kb";
            lbl_L3CacheSize_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.L3CacheSize, "N/A") + " Kb";
            abort();
        }
    }
}
