using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.DeviceControls.DeviceDataControls;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.Components
{
    class DataControlComboBox: ComboBox
    {
        private List<DeviceData._Block> blocks;
        private DeviceDataControl currentDeviceControl;
        private DevicePerformanceControl relatedPerformance;
        private Action action;
        private StringValue valueToUse;

        public enum StringValue
        {
            Name,
            DeviceID
        }

        public List<DeviceData._Block> Blocks { get => blocks; set => blocks = value; }
        public DeviceDataControl CurrentDeviceControl { get => currentDeviceControl; set => currentDeviceControl = value; }
        public DevicePerformanceControl RelatedPerformance { get => relatedPerformance; set => relatedPerformance = value; }
        public Action Action { get => action; set => action = value; }
        private StringValue ValueToUse { get => valueToUse; set => valueToUse = value; }

        private void ChargeListOfSubDevicesInit()
        {
            // fill list with all physical disk
            List<String> devices = new List<string>();
            if (CurrentDeviceControl.CurrentDevice == null || CurrentDeviceControl.CurrentDevice.IsNull)
            {
                this.Enabled = false;
                return;
            }
            else
            {
                this.Enabled = true;
            }
            foreach (DeviceData._Block block in CurrentDeviceControl.CurrentDevice.Blocks)
                 devices.Add(ValueToUse == StringValue.Name ? block.Name : block.DeviceID);

            // don't update loaded values in comboBox if not new devices are founded
            if (devices.SequenceEqual(this.Items.Cast<String>().ToList())) return;

            // if a device are removed or added then manage changes
            if (this.Items.Count != 0)
            {
                string currentSelected = this.SelectedItem.ToString();                   // get current selection
                this.Items.Clear();                                                      // remove all loaded device's name in the comboBox
                this.Items.AddRange(devices.ToArray());                                  // update comboBox with the last updated list of devices                      
                // use old selected device in comboBox if exists in the new list // differently select the first in the list as default
                this.SelectedIndex = this.Items.Contains(currentSelected) ? this.Items.IndexOf(currentSelected) : 0;
                return;
            }

            // for a empty list
            this.Items.AddRange(devices.ToArray());
            this.SelectedIndex = 0;

        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            // change device
            CurrentDeviceControl.CurrentSubDevice = CurrentDeviceControl.CurrentDevice.Blocks.Where(d => ValueToUse == StringValue.Name ? d.Name.Equals(this.SelectedItem.ToString()) : d.DeviceID.Equals(this.SelectedItem.ToString())).FirstOrDefault();
            if (RelatedPerformance != null) RelatedPerformance.CurrentPerformance.CurrentSelected = CurrentDeviceControl.CurrentSubDevice.Name;
            if (Action != null) Action.Invoke(); 
        }

        private void InitSubDevicesID()
        {
            // fill the list with all founded physical disk
            this.ChargeListOfSubDevicesInit();
            // run when update occured. Check if a physical disk drive are added or removed
            CurrentDeviceControl.OnUpdateFinish += new EventHandler(OnDeviceUpdateFinish);
        }

        private void OnDeviceUpdateFinish(object sender, EventArgs e)
        {
            // check if a physical disk as removed or added then update list of selection
            this.Invoke((System.Action)(() => { ChargeListOfSubDevicesInit(); }));
            
        }

        public void Init(DeviceDataControl DeviceControl, DevicePerformanceControl RelatedPerformance, StringValue ValueToUse, Action ExtendedAction)
        {
            this.CurrentDeviceControl = DeviceControl;
            this.RelatedPerformance = RelatedPerformance;
            this.ValueToUse = ValueToUse;
            this.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            this.Action = ExtendedAction;
            this.InitSubDevicesID();
        }
    }
}
