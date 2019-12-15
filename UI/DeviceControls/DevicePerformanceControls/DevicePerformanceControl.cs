using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.Core.Device.Utils;
using DiscoveryLight.UI.BaseUserControl;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    /// <summary>
    /// Extend Class Device Control
    /// </summary>
    public abstract class AbstractDevicePerformanceControl :DeviceControl
    {
        public abstract void InitPerformace(DevicePerformance Device);
    }

    public class DevicePerformanceControl: AbstractDevicePerformanceControl
    {
        private DevicePerformance currentDevice;               // main device type
        private DevicePerformance._Device currentSubDevice;     // a child for the current device    

        public DevicePerformance CurrentDevice
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
        public DevicePerformance._Device CurrentSubDevice
        {
            get
            {
                // return current sub device if nothing is specified as key or for null value (for VS rendering)
                if (currentSubDevice == null) return currentSubDevice;
                // no primary key -> use first as default
                if (currentDevice.PrimaryKey == null) return currentDevice.Devices.First();
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

        public override void InitPerformace(DevicePerformance Performance)
        {
            CurrentDevice = Performance;
        }

        public DevicePerformanceControl(DevicePerformance Performance) {
            InitPerformace(Performance);
        }

        public DevicePerformanceControl() { }
    }
}
