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

        public override void ShowData()
        {
            base.ShowData();
            var CurrentDevice = (PC)this.CurrentDevice;
            lbl_Name_Value.Text = CurrentDevice.Name;
            lbl_Type_Value.Text = CurrentDevice.Type;
            lbl_Manufaturer_Value.Text = CurrentDevice.Manufacturer;
            lbl_Model_Value.Text = CurrentDevice.Model;
            lbl_NumberID_Value.Text = CurrentDevice.IDNumber;
            lbl_User_Value.Text = CurrentDevice.User;
            lbl_Domain_Value.Text = CurrentDevice.Domaine;
            lbl_Version_Value.Text = CurrentDevice.SystemOS_Version;
            lbl_SystemOS_Value.Text = CurrentDevice.SystemOS;
            lbl_Producer_Value.Text = CurrentDevice.SystemOS_Brand;
            lbl_Architectur_Value.Text = CurrentDevice.SystemOS_Architecture;
        }
    }
}
