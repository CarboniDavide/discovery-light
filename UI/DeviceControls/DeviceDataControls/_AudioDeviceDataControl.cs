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
    public partial class _AudioDeviceDataControl : DeviceDataControl
    {
        public _AudioDeviceDataControl()
        {
            InitializeComponent();
            if (Program.Devices != null)
                InitData(Program.Devices.Where(d => d.Properties.GetType() == typeof(AUDIO)).First().Properties);
        }

        public override void ShowData()
        {
            base.ShowData();
            var CurrentSubDevice = (AUDIO.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Manufacturer_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_PowerManagment_Value.Text = CurrentSubDevice.PowerManagmentSupport;
        }
    }
}
