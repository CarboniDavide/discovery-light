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
    public partial class _BasePcDeviceDataControl : DeviceDataControl
    {
        public _BasePcDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _BasePcDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _BasePcDeviceDataControl() : base()
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
            var CurrentDevice = (PC)this.CurrentDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Name, "N/A");
            lbl_Type_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Type, "N/A");
            lbl_Manufaturer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Model_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Model, "N/A");
            lbl_NumberID_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.IDNumber, "N/A");
            lbl_User_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.User, "N/A");
            lbl_Domain_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Domaine, "N/A");
            lbl_Version_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Version, "N/A");
            lbl_SystemOS_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS, "N/A");
            lbl_Producer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Brand, "N/A");
            lbl_Architectur_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SystemOS_Architecture, "N/A");
            abort();
        }
    }
}
