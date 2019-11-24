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
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Network : DevicePanel
    {
        public _Network()
        {
            InitializeComponent();
            this.NetworkDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_NETWORK)).First());
            this.NetworkDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(NETWORK)).First());
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (NETWORK)this.NetworkDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null) return;
            foreach (NETWORK.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID + " - " + block.Name);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            int indexFrom = this.cmb_Blocks.SelectedItem.ToString().IndexOf("-");
            string selected = this.cmb_Blocks.SelectedItem.ToString();
            string name = selected.Substring(indexFrom + 2, selected.Length - indexFrom - 2);
            this.NetworkDeviceDataControl.CurrentSubDevice = (NETWORK.Block)this.NetworkDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(name)).FirstOrDefault();

            var CurrentPerformance = (PERFORM_NETWORK)this.NetworkDevicePerformanceControl.CurrentPerformance;
            CurrentPerformance.SelectedNetwork = name;
        }

        private void InitSubDevicesID()
        {
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }

        private void _Network_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
