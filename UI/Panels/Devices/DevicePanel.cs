using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.Panels.Devices
{

    public abstract class AbstractDevicePanel: UserControl
    {
        public abstract void StopLoadedTask();

    }
    public class DevicePanel: AbstractDevicePanel
    {
        public List<DevicePerformance> LoadedPerformance;

        public override void StopLoadedTask()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().BaseType.FullName == typeof(DevicePerformanceControl).ToString())
                {
                    var t = (DevicePerformanceControl)c;
                    t.StopPerformance();
                }
            }
        }

        public DevicePanel()
        {
            LoadedPerformance = new List<DevicePerformance>();
            
        }
    }
}
