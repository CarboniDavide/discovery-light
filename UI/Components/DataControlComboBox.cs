using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.Core.Device.Utils;
using DiscoveryLight.UI.DeviceControls.DeviceDataControls;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.Components
{
    class DataControlComboBox: ComboBox
    {
        private List<DeviceData._Device> devices;
        private DeviceDataControl currentDeviceControl;
        private DevicePerformanceControl relatedPerformance;
        private Action action;
        private String valueToUse;

        public List<DeviceData._Device> Devices { get => devices; set => devices = value; }
        public DeviceDataControl CurrentDeviceControl { get => currentDeviceControl; set => currentDeviceControl = value; }
        public DevicePerformanceControl RelatedPerformance { get => relatedPerformance; set => relatedPerformance = value; }
        public Action Action { get => action; set => action = value; }
        private String ValueToUse { get => valueToUse; set => valueToUse = value; }

        private void ChargeListOfSubDevicesInit()
        {
            // fill list with all available devices
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
            foreach (DeviceData._Device device in CurrentDeviceControl.CurrentDevice.Devices)
                devices.Add( (device.GetType().GetField(ValueToUse).GetValue(device) as MobProperty).AsString());

            // don't update loaded values in comboBox if not new devices are founded
            if (devices.SequenceEqual(this.Items.Cast<String>().ToList())) return;

            // manage changes when a device are removed or added
            if (this.Items.Count != 0)
            {
                string currentSelected = this.SelectedItem.ToString();                   // get current selection
                this.Items.Clear();                                                      // remove all loaded device's name in the comboBox
                this.Items.AddRange(devices.ToArray());                                  // update comboBox with the last updated list of devices                      
                // use old selected device in comboBox if exists in the new list // differently select the first in the list as default
                this.SelectedIndex = this.Items.Contains(currentSelected) ? this.Items.IndexOf(currentSelected) : 0;
                return;
            }

            // default: for a empty list
            this.Items.AddRange(devices.ToArray());
            this.SelectedIndex = 0;

        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            CurrentDeviceControl.CurrentSubDevice = CurrentDeviceControl.CurrentDevice.GetDevice(this.SelectedItem.ToString());
            if (RelatedPerformance != null) RelatedPerformance.CurrentPerformance.CurrentSelected = this.SelectedItem.ToString();
            if (Action != null) Action.Invoke(); 
        }

        private void InitSubDevicesID()
        {
            // fill the list with all founded devices
            this.ChargeListOfSubDevicesInit();
            // run when update occured. Check if a physical disk drive are added or removed
            CurrentDeviceControl.OnUpdateFinish += new EventHandler(OnDeviceUpdateFinish);
        }

        private void OnDeviceUpdateFinish(object sender, EventArgs e)
        {
            // check if a device has been removed or added then update list for selection
            this.Invoke((System.Action)(() => { ChargeListOfSubDevicesInit(); }));
            
        }

        public void Init(DeviceDataControl DeviceControl, DevicePerformanceControl RelatedPerformance, Action ExtendedAction)
        {
            this.CurrentDeviceControl = DeviceControl;
            this.RelatedPerformance = RelatedPerformance;
            this.ValueToUse = CurrentDeviceControl.CurrentDevice.PrimaryKey;
            this.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            this.Action = ExtendedAction;
            this.InitSubDevicesID();
        }
    }
}
