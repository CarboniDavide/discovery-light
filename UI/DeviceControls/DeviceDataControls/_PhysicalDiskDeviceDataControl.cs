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

        public override void ShowData()
        {
            base.ShowData();
            var CurrentSubDevice = (DISK.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Tipology_Value.Text = CurrentSubDevice.MediaType;
            lbl_ConnectionType_Value.Text = CurrentSubDevice.Intreface;
            lbl_Size_Value.Text = (Convert.ToUInt64(CurrentSubDevice.Size) / 1048576).ToString() + " MB";
            lbl_SerialNumber_Value.Text = CurrentSubDevice.SerialNumber;
            lbl_Cylinders_Value.Text = CurrentSubDevice.Cylinders;
            lbl_Heads_Value.Text = CurrentSubDevice.Heads;
            lbl_Sectors_Value.Text = CurrentSubDevice.Sectors;
            lbl_Tracks_Value.Text = CurrentSubDevice.Tracks;
            lbl_TracksPerCylinder_Value.Text = CurrentSubDevice.TracksPerCylinder;
            lbl_BytesPerSector_Value.Text = CurrentSubDevice.BytesPerSector;
            lbl_Firmware_Value.Text = CurrentSubDevice.FirmwareVersion;
        }
    }
}
