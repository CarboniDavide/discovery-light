using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _PhysicalMemoryDataControl : DeviceDataControl
    {
        public _PhysicalMemoryDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _PhysicalMemoryDataControl() : base()
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
            var CurrentSubDevice = (PhysicalMemory.SubDevice)this.CurrentSubDevice;
            lbl_BlockSize_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Capacity, "N/A", "{0:N0}") + " Kbytes";
            lbl_BlockSlotPosition_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.DeviceLocator, "N/A");
            lbl_BlockLocation_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.BankLabel, "N/A");
            lbl_BlockManufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_BlockNumberParty_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.PartNumber, "N/A");
            lbl_BlockSerial_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.SerialNumber, "N/A");
            lbl_BlockSpeed_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.ConfiguredClockSpeed, "N/A", "{0:N0}") + " Mhz";
            lbl_BlockBusSize_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.DataWidth, "N/A") + " Bytes";
            lbl_BlockVoltage_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MinVoltage, "N/A", "{0:N0}") + " mV";
            abort();
        }
    }
}
