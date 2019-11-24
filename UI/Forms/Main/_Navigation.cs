using System;
using System.Drawing;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;
using DiscoveryLight.UI.Buttons;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Navigation : UserControl
    {
        _PanelContainer PanelContainer;

        public _Navigation()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            String requestedPanelName = (sender as PanelLinkButton).ButtonFor.ToString();
            Point currentPointToMOve = (sender as Button).Location;
            PanelContainer.LoadPanel(requestedPanelName);
            AnimationLine_Navigation.MoveLine(currentPointToMOve);
        }

        private void _Navigation_Load(object sender, EventArgs e)
        {
            PanelContainer = FormsCollection.Main.PanelContainer;
            PanelContainer.LoadPanel("");
        }
    }
}