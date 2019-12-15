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
    public partial class _BiosDeviceDataControl : DeviceControl
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
            CurrentDevice.UpdateCollection();
        }
        protected override void show()
        {
            base.show();
            var CurrentDevice = (BIOS.Device)this.CurrentSubDevice;
            lbl_BiosManufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Manufacturer.AsString(), "N/A"); ;
            lbl_BiosSerialNumber_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SerialNumber.AsString(), "N/A");
            lbl_BiosVersion_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Caption.AsString(), "N/A");
            lbl_BiosReleaseDate_Value.Text = DataConvert.AsDefaultValue(x => x.Substring(0,4), CurrentDevice.ReleaseDate.AsString(), null) 
                + "-" + DataConvert.AsDefaultValue(x => x.Substring(4,2), CurrentDevice.ReleaseDate.AsString(), null) 
                + "-" + DataConvert.AsDefaultValue(x => x.Substring(6, 2), CurrentDevice.ReleaseDate.AsString(), null);
            abort();
        }
    }
}