using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Components
{
    /// <summary>
    /// Extend base button control with new custom fields
    /// </summary>
    class PanelLinkButton : Button
    {
        private String buttonFor;           // identify the purpose for this button
        private String device;              // set the device name linked at this button
        private ToolTip toolDescription;    // use a common tooltip using the device name as description
        /// <summary>
        /// Select de panel to link a this button
        /// </summary>
        public String ButtonFor { get => buttonFor; set => buttonFor = value; }
        public String Device { get => device; set => device = value; }
        public ToolTip ToolDescription
        {
            get { return toolDescription; }
            set { 
                toolDescription = value;
                toolDescription.SetToolTip(this, Device);
            }
        }
    }
}
