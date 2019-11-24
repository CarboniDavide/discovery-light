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

        private _Slider Slider;
        private _PanelContainer PanelContainer;
        public String FooterTittleName;

        public void ChangeTitle(object sender, EventArgs e)
        {
            this.ChartBar.CustomText = PanelContainer.CurrentPanel.PanelName;
            this.ChartBar.BarFillSize = 0;
            this.FooterTittleName = PanelContainer.CurrentPanel.PanelName;         }

        private void ChartBar_Load(object sender, EventArgs e)
        {
            Slider = FormsCollection.Main.PanelContainer.Slider;
            PanelContainer = FormsCollection.Main.PanelContainer;
            Slider.ControlAdded += new ControlEventHandler(ChangeTitle);
        }
    }
}
