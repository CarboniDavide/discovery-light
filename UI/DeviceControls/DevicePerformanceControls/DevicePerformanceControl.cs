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
    /// <summary>
    /// Extend Class Device Control
    /// </summary>
    public abstract class AbstractDevicePerformanceControl :DeviceControl
    {
        public abstract void InitPerformace(DevicePerformance Device);
    }

    public class DevicePerformanceControl: AbstractDevicePerformanceControl
    {
        private DevicePerformance currentPerformance;  // current main device performance type
        private int currentSubDevice;                  // a child for the current performance             

        public int CurrentSubDevice { get => currentSubDevice; set => currentSubDevice = value; }
        public DevicePerformance CurrentPerformance { get => currentPerformance; set => currentPerformance = value; }

        public override void InitPerformace(DevicePerformance Performance)
        {
            CurrentPerformance = Performance;
            currentSubDevice = 0;
        }

        public DevicePerformanceControl(DevicePerformance Performance) {
            if (Performance == null) return;
            InitPerformace(Performance);
        }

        public DevicePerformanceControl() { }
    }
}
