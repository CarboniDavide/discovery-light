using DiscoveryLight.Core.Device;
using DiscoveryLight.Core.Device.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public class DevicePerformanceControl: DeviceControl, IInitializable
    {
        private _Device currentDevice;               // main device type
        private _SubDevice currentSubDevice;     // a child for the current device 

        public _Device CurrentDevice { get => currentDevice; set => currentDevice = value; }
        public _SubDevice CurrentSubDevice { get => CurrentDevice.SubDevices.FirstOrDefault(); set => currentSubDevice = value; }
        
        protected override void validate()
        {
            base.validate();
            if (CurrentDevice.IsEmpty)
            {
                _SubDevice obj = Activator.CreateInstance(Type.GetType(CurrentDevice.ClassType.FullName + "+SubDevice")) as _SubDevice;
                CurrentDevice.SubDevices.Add(obj.Initialize());
            }
        }

        public void Init(_Device Device)
        {
            CurrentDevice = Device;
        }

        public DevicePerformanceControl(_Device Device)
        {
            Init(Device);
        }

        public DevicePerformanceControl() { }
    }
}
