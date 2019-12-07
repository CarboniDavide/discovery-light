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
    public partial class _Video: DevicePanel
    {
        public _Video()
        {
            InitializeComponent();
            this.VideoDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(VideoController)).First());
            InitSubDevicesID();
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (VideoController)this.VideoDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null || CurrentDevice.IsNull) return;
            int index = 0;
            foreach (VideoController.Block block in CurrentDevice.Blocks)
            {
                this.cmb_Blocks.Items.Add(index + " - " + block.Name);      // add a index to each subdevice name
                index++;
            }
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // get name from selection
            int indexSize = this.cmb_Blocks.SelectedIndex.ToString().Length;
            string selected = this.cmb_Blocks.SelectedItem.ToString();
            // remove index to get subdevice name
            string name = selected.Substring(indexSize + 1, selected.Length - indexSize - 1);
            // load the selected subdevice values from source
            this.VideoDeviceDataControl.CurrentSubDevice = this.VideoDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(name)).FirstOrDefault();
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();      // fill the list of subdevices
            this.cmb_Blocks.SelectedIndex = cmb_Blocks.Items.Count == 0 ? -1 : 0;
            this.cmb_Blocks.Enabled = !(cmb_Blocks.Items.Count == 0);
        }
    }
}
