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

        public override void ShowData()
        {
            base.ShowData();
            var CurrentSubDevice = (NETWORK.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Tipology_Value.Text = CurrentSubDevice.Type;
            lbl_Manufacturer_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_AdapterType_Value.Text = CurrentSubDevice.AdapterType;
            lbl_DeviceID_Value.Text = CurrentSubDevice.DeviceID;
            lbl_InterfaceID_Value.Text = CurrentSubDevice.InterfaceIndex;
            lbl_Speed_Value.Text = CurrentSubDevice.Speed + " Bps";
            lbl_MACAddress_Value.Text = CurrentSubDevice.MACAddresse;
        }
    }
}
