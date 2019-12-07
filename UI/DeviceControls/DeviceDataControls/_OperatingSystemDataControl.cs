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
    public partial class _OperatingSystemDataControl : DeviceDataControl
    {
        public _OperatingSystemDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _OperatingSystemDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _OperatingSystemDataControl() : base()
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
            var CurrentDevice = (DiscoveryLight.Core.Device.Data.OperatingSystem)this.CurrentDevice;
            lbl_Version_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Version, "N/A");
            lbl_SystemOS_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS, "N/A");
            lbl_Producer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Brand, "N/A");
            lbl_Architectur_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Architecture, "N/A");
            abort();
        }
    }
}
