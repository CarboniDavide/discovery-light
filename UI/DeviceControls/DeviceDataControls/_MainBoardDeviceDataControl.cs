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
    public partial class _MainBoardDeviceDataControl : DeviceDataControl
    {
        public _MainBoardDeviceDataControl()
        {
            InitializeComponent();
            if (Program.Devices != null)
                InitData(Program.Devices.Where(d => d.Properties.GetType() == typeof(MAINBOARD)).First().Properties);
        }

        public override void ShowData()
        {
            base.ShowData();
            var CurrentDevice = (MAINBOARD)this.CurrentDevice;
            lbl_Manufacturer_Value.Text = CurrentDevice.Manufacturer;
            lbl_Model_Value.Text = CurrentDevice.Model;
            lbl_Version_Value.Text = CurrentDevice.Version;
            lbl_PrimaryBus_Value.Text = CurrentDevice.PrimaryBus_Value;
            lbl_SecondaryBus_Value.Text = CurrentDevice.SecondaryBus_Value;
            lbl_SlotNumber_Value.Text = CurrentDevice.NumberSlot;
        }
    }
}
