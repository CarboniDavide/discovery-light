using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _PanelContainer : UserControl
    {

        private DevicePanel currentPanel;
        public DevicePanel CurrentPanel { get => currentPanel; set => currentPanel = value; }

        public _PanelContainer()
        {
            InitializeComponent();
        }
        
        public void LoadPanel(string name)
        {
            this.CurrentPanel = PanelCollection.PanelFactory(name);
            this.Slider.AddSlide(CurrentPanel);
        }
    }
}
