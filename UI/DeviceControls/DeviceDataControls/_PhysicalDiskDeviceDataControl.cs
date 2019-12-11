using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Commun;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _PhysicalDiskDeviceDataControl : DeviceDataControl
    {
        public _PhysicalDiskDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _PhysicalDiskDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
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
            var CurrentSubDevice = (DiskDrive.Device)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Tipology_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MediaType, "N/A");
            lbl_ConnectionType_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Intreface, "N/A");
            lbl_Size_Value.Text = DataConvert.AsDefaultValue( x => (Convert.ToUInt64(x) / 1048576).ToString(), CurrentSubDevice.Size, "N/A", "{0:N0}") + " MB";
            lbl_SerialNumber_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SerialNumber, "N/A");
            lbl_Cylinders_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Cylinders, "N/A", "{0:N0}");
            lbl_Heads_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Heads, "N/A", "{0:N0}");
            lbl_Sectors_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Sectors, "N/A", "{0:N0}");
            lbl_Tracks_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Tracks, "N/A", "{0:N0}");
            lbl_TracksPerCylinder_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.TracksPerCylinder, "N/A", "{0:N0}");
            lbl_BytesPerSector_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.BytesPerSector, "N/A", "{0:N0}");
            lbl_Firmware_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.FirmwareVersion, "N/A");
        }
    }
}
