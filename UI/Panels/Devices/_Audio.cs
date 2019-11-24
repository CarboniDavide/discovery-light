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
    public partial class _Audio : DevicePanel
    {
        public _Audio()
        {
            InitializeComponent();
            this.AudioDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(AUDIO)).First());
            InitSubDevicesID();
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (AUDIO)this.AudioDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            int index = 0; // use number in list
            foreach (AUDIO.Block block in CurrentDevice.Blocks)
            {
                this.cmb_Blocks.Items.Add(index.ToString() + "-" + block.Name);
                index++;
            }
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // get name from selected
            int indexSize = this.cmb_Blocks.SelectedIndex.ToString().Length;
            string selected = this.cmb_Blocks.SelectedItem.ToString();
            string name = selected.Substring( indexSize + 1, selected.Length-indexSize-1);
            this.AudioDeviceDataControl.CurrentSubDevice = this.AudioDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(name)).FirstOrDefault();
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }
    }
}
