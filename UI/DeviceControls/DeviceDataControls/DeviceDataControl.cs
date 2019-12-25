using DiscoveryLight.Core.Device;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public class DeviceDataControl: DeviceControl, IInitializable
    {
        private _Device currentDevice;               // main device type
        private _SubDevice currentSubDevice;     // a child for the current device 

        public _Device CurrentDevice
        {
            get { return currentDevice; }
            set
            {
                if (value == null) return;
                currentDevice = value;
                CurrentSubDevice = currentDevice.SubDevices.FirstOrDefault();
            }
        }
        public _SubDevice CurrentSubDevice
        {
            get
            {
                // return current sub device if nothing is specified as key or for null value (for VS rendering)
                if (currentSubDevice == null) return currentSubDevice;
                // no primary key -> use first as default
                if (currentDevice.PrimaryKey == null) return currentDevice.SubDevices.First();
                //  get the current value form field or the oldest subdevice for null value
                string currentKey = (currentSubDevice.GetType().GetField(currentDevice.PrimaryKey).GetValue(currentSubDevice) as MobProperty).AsString();
                // get the device using primary key else use the currentSubDevice for null value
                currentSubDevice = CurrentDevice.GetDevice(currentKey) ?? currentSubDevice;
                return currentSubDevice;
            }
            set
            {
                currentSubDevice = value;
                if (value != null) show();  // upadate UI when a new subdevice is selected
            }
        }

        protected override void validate()
        {
            base.validate();
            if (CurrentDevice.IsEmpty)
            {
                _SubDevice obj = Activator.CreateInstance(Type.GetType(CurrentDevice.ClassType.FullName + "+SubDevice")) as _SubDevice;
                currentSubDevice = obj.Serialize();
            }
        }

        public void Init(_Device Device)
        {
            CurrentDevice = Device;
        }

        public DeviceDataControl() { }

        public DeviceDataControl(_Device Device)
        {
            Init(Device);
        }
    }
}
