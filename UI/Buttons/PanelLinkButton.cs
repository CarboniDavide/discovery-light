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
        String buttonFor;
        /// <summary>
        /// Select de panel to link a this button
        /// </summary>
        public String ButtonFor { get => buttonFor; set => buttonFor = value; }
    }
}
