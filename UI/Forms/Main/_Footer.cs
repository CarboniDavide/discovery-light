using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Slider;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Footer : UserControl
    {
        public _Footer()
        {
            InitializeComponent();
        }

        public String FooterTittleName;

        /// <summary>
        /// Change title values in footer bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeTitle(object sender, EventArgs e)
        {
            this.ChartBar.CustomText = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;  // get panel name
            this.ChartBar.BarFillSize = 0;                                                          // reset charging bar    
            this.FooterTittleName = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;     // get a backup to the current title
        }
    }
}
