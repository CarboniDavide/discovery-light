using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.BaseUserControl;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public abstract class AbstractDevicePerformanceControl :DeviceControl
    {
        public abstract void InitPerformace(DevicePerformance Device);
    }

    public class DevicePerformanceControl: AbstractDevicePerformanceControl
    {
        private DevicePerformance currentPerformance;
        private int currentSubDevice;
        private Type deviceType;
        private String deviceName;

        public DevicePerformance CurrentPerformance
        {
            get { return currentPerformance; }
            set
            {
                if (value == null) return;
                currentPerformance = value;
                deviceType = currentPerformance.GetType();
                deviceName = deviceType.ToString();
                currentSubDevice = 0;
            }
        }
        public int CurrentSubDevice { get => currentSubDevice; set => currentSubDevice = value; }

        public override void InitPerformace(DevicePerformance Performance)
        {
            CurrentPerformance = Performance;
        }

        public DevicePerformanceControl(DevicePerformance Performance) {
            if (Performance == null) return;
            InitPerformace(Performance);
        }

        public DevicePerformanceControl() { }
    }
}
