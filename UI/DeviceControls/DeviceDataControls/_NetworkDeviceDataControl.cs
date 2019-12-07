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
    public partial class _NetworkDeviceDataControl : DeviceDataControl
    {
        public _NetworkDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _NetworkDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _NetworkDeviceDataControl() : base()
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
            var CurrentSubDevice = (NetworkAdapter.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Tipology_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Type, "N/A");
            lbl_Manufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_AdapterType_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AdapterType, "N/A");
            lbl_DeviceID_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.DeviceID, "N/A");
            lbl_Speed_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToDouble(x) / 1000000).ToString(), CurrentSubDevice.Speed, "N/A") +" Mbps";
            lbl_MACAddress_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MACAddresse, "N/A");
            lbl_IPAddress_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Ip_Address, "N/A");
            lbl_PrimaryDNS_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.PrimaryDNS, "N/A");
            lbl_SecondaryDNS_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SencondaryDNS, "N/A");
            lbl_SubnetMask_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SubNetMask, "N/A");
            lbl_Getway_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.DefualtGetway, "N/A");
        }
    }
}
