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

        public void ChangeTitle(object sender, EventArgs e)
        {
            this.ChartBar.CustomText = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;
            this.ChartBar.BarFillSize = 0;
            this.FooterTittleName = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;
        }
    }
}
