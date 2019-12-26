using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Devices
{
    /// <summary>
    /// Panel Container Class. Base container for each device panel.
    /// </summary>
    public partial class _PanelContainer : UserControl
    {

        private DevicePanel currentPanel;              // current panel in UI
        public DevicePanel CurrentPanel { get => currentPanel; set => currentPanel = value; }

        public _PanelContainer()
        {
            InitializeComponent();
        }

        public void LoadPanel(string name)
        {
            // get a new instance for a requested panel and use slider to perform ui
            this.CurrentPanel = PanelCollection.PanelFactory(name);
            this.Slider.AddSlide(CurrentPanel);
        }
    }
}
