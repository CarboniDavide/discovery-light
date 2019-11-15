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
            this.RemovePanel();
            this.CurrentPanel = PanelCollection.PanelFactory(name);
            this.Controls.Add(CurrentPanel);
        }

        public void RemovePanel()
        {
            if (this.Controls.Count == 0) return;
            this.CurrentPanel.StopLoadedTask();
            this.Controls.Clear();
        }
    }
}
