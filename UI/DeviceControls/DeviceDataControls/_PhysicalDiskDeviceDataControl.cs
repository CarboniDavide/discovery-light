using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _PhysicalDiskDeviceDataControl : DeviceDataControl
    {
        public _PhysicalDiskDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _PhysicalDiskDeviceDataControl() : base()
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
            var CurrentSubDevice = (DiskDrive.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.Caption, "N/A");
            lbl_Tipology_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.MediaType, "N/A");
            lbl_ConnectionType_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.InterfaceType, "N/A");
            lbl_Size_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsUInt64() / 1048576, CurrentSubDevice.Size, "N/A", "{0:N0}") + " MB";
            lbl_SerialNumber_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.SerialNumber, "N/A");
            lbl_Cylinders_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.TotalCylinders, "N/A", "{0:N0}");
            lbl_Heads_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.TotalHeads, "N/A", "{0:N0}");
            lbl_Sectors_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.TotalSectors, "N/A", "{0:N0}");
            lbl_Tracks_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.TotalTracks, "N/A", "{0:N0}");
            lbl_TracksPerCylinder_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.TracksPerCylinder, "N/A", "{0:N0}");
            lbl_BytesPerSector_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.BytesPerSector, "N/A", "{0:N0}");
            lbl_Firmware_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentSubDevice.FirmwareRevision, "N/A");
        }
    }
}
