using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.BaseUserControl;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.Panels.Devices
{

    public abstract class AbstractDevicePanel: _BaseUserControl
    {
    }
    public class DevicePanel: AbstractDevicePanel
    {
        private int panelIndex;

        public int PanelIndex { get => panelIndex; set => panelIndex = value; }
        public DevicePanel() { }
    }
}
