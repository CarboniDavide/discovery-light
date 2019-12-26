using DiscoveryLight.UI.BaseUserControl;
using System.ComponentModel;

namespace DiscoveryLight.UI.Panels.Devices
{
    /// <summary>
    /// Device Panel. Extend BaseUserControl with new fields to get more information about all device's panel.
    /// </summary>
    public class DevicePanel : _BaseUserControl
    {
        private int panelIndex;            // define order between each panel
        private string panelName;          // panel name to be used in footer bar 

        public int PanelIndex { get => panelIndex; set => panelIndex = value; }

        [Localizable(true)]
        public string PanelName { get => panelName; set => panelName = value; }

        public DevicePanel() { }
    }
}
