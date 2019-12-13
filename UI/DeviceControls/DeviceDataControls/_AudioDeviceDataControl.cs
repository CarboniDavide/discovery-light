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
    public partial class _AudioDeviceDataControl : DeviceDataControl
    {
        public _AudioDeviceDataControl(DeviceData Device) :base(Device)
        {
            InitializeComponent();
        }

        public _AudioDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _AudioDeviceDataControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection();
        }

        protected override void show ()
        {
            base.show();
            var CurrentSubDevice = (SoundDevice.Device)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name.AsString(), "N/A");
            lbl_Manufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer.AsString(), "N/A");
            lbl_PowerManagment_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.PowerManagementSupported.AsString(), "N/A");
        }
    }
}
