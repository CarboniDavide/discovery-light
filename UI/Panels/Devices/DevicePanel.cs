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
    public class DevicePanel: UserControl
    {
        public List<DevicePerformance> LoadedPerformance;
        

        public void StopLoadedPerformance()
        {
            foreach (Control c in this.Controls)
            {
                var res = c.GetType().BaseType.FullName;
                var res2 = typeof(DevicePerformanceControl).ToString();
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
