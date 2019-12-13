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
    public partial class _ComputerSystemDataControl : DeviceDataControl
    {
        public _ComputerSystemDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _ComputerSystemDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _ComputerSystemDataControl() : base()
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
            var CurrentDevice = (ComputerSystem.Device)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Name, "N/A");
            lbl_Type_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemType, "N/A");
            lbl_Manufaturer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Model_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Model, "N/A");
            lbl_User_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.UserName, "N/A");
            lbl_Domain_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Domain, "N/A");
            abort();
        }
    }
}
