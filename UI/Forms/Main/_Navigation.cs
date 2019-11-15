using System;
using System.Drawing;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;
using DiscoveryLight.UI.Buttons;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Navigation : UserControl
    {
        Panel PanelContainer;
        _Footer Footer;
        DevicePanel CurrentPanel;

        public _Navigation()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            String requestedPanelName = (sender as PanelLinkButton).ButtonFor.ToString();
            Point currentPointToMOve = (sender as Button).Location;
            if (CurrentPanel != null) CurrentPanel.StopLoadedPerformance();
            CurrentPanel = PanelCollection.PanelFactory(requestedPanelName);
            Footer.lbl_DeviceName.Text = (sender as PanelLinkButton).Device.ToString();
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(CurrentPanel);
            AnimationLine_Navigation.MoveLine(currentPointToMOve);
        }

        private void _Navigation_Load(object sender, EventArgs e)
        {
            PanelContainer = FormsCollection.Main.DevicePanelContainer;
            Footer = FormsCollection.Main.FooterBar;
            Footer.lbl_DeviceName.Text = "Base Pc Informations";
            CurrentPanel = PanelCollection.PanelFactory("");
            PanelContainer.Controls.Add(CurrentPanel);
        }
    }
}