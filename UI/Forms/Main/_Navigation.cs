using DiscoveryLight.UI.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Navigation : UserControl
    {
        public _Navigation()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            String requestedPanelName = (sender as PanelLinkButton).ButtonFor.ToString();  // get request panel name from the "ButtomFor" field
            Point currentPointToMOve = (sender as Button).Location;                        // get current button position
            if (requestedPanelName == "Settings")                                          // settings panel use not panel container 
                FormsCollection.Main.UserSettings.anm_PanelSet.OpenPanel();
            else
            {
                FormsCollection.Main.PanelContainer.LoadPanel(requestedPanelName);         // load panel directly in PanelContainer
                FormsCollection.Main.UserSettings.anm_PanelSet.ClosePanel();               // close panel  
            }
            AnimationLine_Navigation.MoveLine(currentPointToMOve);                         // change buttom line indicator
        }
    }
}