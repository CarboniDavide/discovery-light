using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;
using System.Reflection;
using DiscoveryLight.UI.Buttons;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Navigation : UserControl
    {
        Panel PanelContainer;
        DevicePanel CurrentPanel;

        public _Navigation()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            String requestedPanelName = (sender as PanelLinkButton).ButtonFor.ToString();
            Point currentPointToMOve = (sender as Button).Location;
            if (CurrentPanel != null) CurrentPanel.Dispose();
            CurrentPanel = PanelCollection.PanelFactory(requestedPanelName);
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(CurrentPanel);
            AnimationLine_Navigation.MoveLine(currentPointToMOve);
        }

        private void _Navigation_Load(object sender, EventArgs e)
        {
            PanelContainer = FormsCollection.Main.DevicePanelContainer;
            PanelContainer.Controls.Add(PanelCollection.PanelFactory(""));
        }
    }
}
