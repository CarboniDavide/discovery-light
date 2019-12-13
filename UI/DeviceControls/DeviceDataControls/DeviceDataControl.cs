using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Utils;
using DiscoveryLight.UI.BaseUserControl;


namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    /// <summary>
    /// Extend Device Control.
    /// </summary>
    public abstract class AbstractDeviceDataControl : DeviceControl
    {
        public abstract void InitData(DeviceData Device);
    }
    public class DeviceDataControl : AbstractDeviceDataControl
    {
        private DeviceData currentDevice;               // main device type
        private DeviceData._Device currentSubDevice;     // a child for the current device    

        public DeviceData CurrentDevice
        {
            get { return currentDevice; }
            set
            {
                if (value == null) return;
                currentDevice = value;
                CurrentSubDevice = (CurrentDevice.Devices.Count != 0) ? CurrentDevice.Devices.First() : new DeviceData._Device();
            }
        }
        public DeviceData._Device CurrentSubDevice
        {
            get {
                if (currentSubDevice == null) return currentSubDevice;
                // change device
                foreach (DeviceData._Device device in currentDevice.Devices)
                {
                    string Key = (device.GetType().GetField(currentDevice.PrimaryKey).GetValue(device) as MobProperty).AsString();
                    string currentKey = (currentSubDevice.GetType().GetField(currentDevice.PrimaryKey).GetValue(currentSubDevice) as MobProperty).AsString();
                    if (Key != null && currentKey != null && Key.Equals(currentKey))
                        return device;
                }

                return currentSubDevice;
            }
            set {
                currentSubDevice = value;
                if (value != null) show();  // upadate UI when a new subdevice is selected
            }
        }

        public override void InitData(DeviceData Device)
        {
            CurrentDevice = Device;
            CurrentSubDevice = (CurrentDevice.Devices.Count != 0) ? CurrentDevice.Devices.First() : new DeviceData._Device();
        }

        public DeviceDataControl(DeviceData Device) 
        {
            InitData(Device);
        }

        public DeviceDataControl(DeviceData Device, Boolean GetDriveInfo)
        {
            if (GetDriveInfo)
                Device.UpdateCollection();
            InitData(Device);
        }

        public DeviceDataControl() { }
    }
}
