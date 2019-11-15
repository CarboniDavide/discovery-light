using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Buttons
{
    class PanelLinkButton: Button
    {
        private String buttonFor;
        private String device;
        private ToolTip toolDescription;
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
