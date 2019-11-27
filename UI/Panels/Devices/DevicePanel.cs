using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Device Panel. Extend BaseUserControl with new fields to get more information about all device's panel.
    /// </summary>
    public class DevicePanel: _BaseUserControl
    {
        private int panelIndex;            // define order between each panel
        private string panelName;          // panel name to be used in footer bar 

        public int PanelIndex { get => panelIndex; set => panelIndex = value; }

        [Localizable(true)]
        public string PanelName { get => panelName; set => panelName = value; }

        public DevicePanel() { }
    }
}
