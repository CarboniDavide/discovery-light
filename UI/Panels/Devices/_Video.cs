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

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Video: UserControl
    {
        public _Video()
        {
            InitializeComponent();
            InitSubDevicesID();
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (VIDEO)this.VideoDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (VIDEO.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID + " - " + block.Name);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            this.VideoDeviceDataControl.CurrentSubDevice = this.VideoDeviceDataControl.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedIndex.ToString() + 1)).FirstOrDefault();
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }
    }
}
