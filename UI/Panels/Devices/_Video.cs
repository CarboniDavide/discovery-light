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
            int index = 0;
            foreach (VIDEO.Block block in CurrentDevice.Blocks)
            {
                this.cmb_Blocks.Items.Add(index + "-" + block.Name);
                index++;
            }
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // get name from selected
            int indexSize = this.cmb_Blocks.SelectedIndex.ToString().Length;
            string selected = this.cmb_Blocks.SelectedItem.ToString();
            string name = selected.Substring(indexSize + 1, selected.Length - indexSize - 1);
            this.VideoDeviceDataControl.CurrentSubDevice = this.VideoDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(name)).FirstOrDefault();
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }
    }
}
