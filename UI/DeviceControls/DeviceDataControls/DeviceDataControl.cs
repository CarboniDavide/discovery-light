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
                if (currentDevice.Devices.Count == 0) currentDevice.UpdateCollection();
                CurrentSubDevice = currentDevice.Devices.First();
            }
        }
        public DeviceData._Device CurrentSubDevice
        {
            get {
                if (currentSubDevice == null ) return currentSubDevice;
                //  get the current value form field or the oldest subdevice for null value
                string currentKey = (currentSubDevice.GetType().GetField(currentDevice.PrimaryKey).GetValue(currentSubDevice) as MobProperty).AsString();
                // get the device using primary key else use the currentSubDevice for null value
                currentSubDevice = CurrentDevice.GetDevice(currentKey) ?? currentSubDevice;
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
