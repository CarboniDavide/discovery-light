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
    public partial class _BiosDeviceDataControl : DeviceDataControl
    {
        public _BiosDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _BiosDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _BiosDeviceDataControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.GetDriveInfo();
        }
        protected override void show()
        {
            base.show();
            var CurrentDevice = (BIOS)this.CurrentDevice;
            lbl_BiosManufacturer_Value.Text = CurrentDevice.Manufacturer;
            lbl_BiosSerialNumber_Value.Text = CurrentDevice.SerialNumber;
            lbl_BiosVersion_Value.Text = CurrentDevice.Version;
            lbl_BiosReleaseDate_Value.Text = CurrentDevice.ReleaseData.Substring(0, 4) + " - " + CurrentDevice.ReleaseData.Substring(4, 2) + " - " + CurrentDevice.ReleaseData.Substring(6, 2);
            abort();
        }
    }
}