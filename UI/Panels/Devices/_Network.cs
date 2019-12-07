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
            this.NetworkDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(NetworkAdapter)).First());
        }

        private void ChargeListOfSubDevicesInit()
        {
            // load all names for each installed network
            List<String> devices = new List<string>();
            var CurrentDevice = (NetworkAdapter)this.NetworkDeviceDataControl.CurrentDevice;
            if (CurrentDevice == null || CurrentDevice.IsNull) return;
            foreach (NetworkAdapter.Block block in CurrentDevice.Blocks)
                devices.Add(block.DeviceID + " - " + block.Name);  // add device name to each networ's name

            // don't change comboBox list if no changes are availables
            if (devices.SequenceEqual(cmb_Blocks.Items.Cast<String>().ToList())) return;

            // if a network device are removed or added then manages changes
            if (cmb_Blocks.Items.Count != 0) {
                string currentSelected = cmb_Blocks.SelectedItem.ToString();       // get current selection
                cmb_Blocks.Items.Clear();                                          // remove all loaded disk's name in the comboBox 
                cmb_Blocks.Items.AddRange(devices.ToArray());                      // update comboBox with the last updated list of networks
                // use old selected network in comboBox if exists in the new list // differently select the first in the list as default
                cmb_Blocks.SelectedIndex = cmb_Blocks.Items.Contains(currentSelected) ? cmb_Blocks.Items.IndexOf(currentSelected) : 0;
                return;
            }

            // for a empty list
            cmb_Blocks.Items.AddRange(devices.ToArray());
            cmb_Blocks.SelectedIndex = 0;
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // change network device
            // use only network name
            int indexFrom = this.cmb_Blocks.SelectedItem.ToString().IndexOf("-"); 
            string selected = this.cmb_Blocks.SelectedItem.ToString();
            string name = selected.Substring(indexFrom + 2, selected.Length - indexFrom - 2);
            this.NetworkDeviceDataControl.CurrentSubDevice = (NetworkAdapter.Block)this.NetworkDeviceDataControl.CurrentDevice.Blocks.Where(d => d.Name.Equals(name)).FirstOrDefault();

            var CurrentPerformance = (PERFORM_NETWORK)this.NetworkDevicePerformanceControl.CurrentPerformance;
            var CurrentDevice = (NetworkAdapter.Block)this.NetworkDeviceDataControl.CurrentSubDevice;

            CurrentPerformance.SelectedNetwork = CurrentDevice.UsedNameinPerformance;
        }

        private void InitSubDevicesID()
        {
            // load all name for each installed network's adapter and fill the comboBox
            this.ChargeListOfSubDevicesInit();
            // update comboBox list each update
            this.NetworkDeviceDataControl.OnUpdateFinish += new EventHandler(OnDeviceUpdate);
        }

        private void OnDeviceUpdate(object sender, EventArgs e)
        {
            // check if a network adapter is removed or added then update the comboBox list
            this.Invoke((System.Action)(() => { ChargeListOfSubDevicesInit(); }));
        }

        private void _Network_Load(object sender, EventArgs e)
        {
            InitSubDevicesID();
        }
    }
}
