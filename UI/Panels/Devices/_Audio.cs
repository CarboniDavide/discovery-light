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
    public partial class _Audio : UserControl
    {
        public _Audio()
        {
            InitializeComponent();
            InitSubDevicesID();
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (AUDIO)this.AudioDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (AUDIO.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.Name);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            this.AudioDeviceDataControl.CurrentSubDevice = this.AudioDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(this.cmb_Blocks.SelectedItem)).FirstOrDefault();
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }
    }
}
