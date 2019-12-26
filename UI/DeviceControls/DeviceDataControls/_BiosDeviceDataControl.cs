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
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _BiosDeviceDataControl : DeviceDataControl
    {
        public _BiosDeviceDataControl(DeviceData Device) : base(Device)
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
            var CurrentDevice = (BIOS.SubDevice)this.CurrentSubDevice;
            lbl_BiosManufacturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A"); ;
            lbl_BiosSerialNumber_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.SerialNumber, "N/A");
            lbl_BiosVersion_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Caption, "N/A");
            lbl_BiosReleaseDate_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsSubString(0,4), CurrentDevice.ReleaseDate, null) 
                + "-" + MobPropertyDataConvert.AsDefaultValue(x => x.AsSubString(4,2), CurrentDevice.ReleaseDate, null) 
                + "-" + MobPropertyDataConvert.AsDefaultValue(x => x.AsSubString(6, 2), CurrentDevice.ReleaseDate, null);
            abort();
        }
    }
}