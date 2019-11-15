using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _SubPanelContainer : UserControl
    {
        public _SubPanelContainer()
        {
            InitializeComponent();
        }

        public void LoadSubPanel(BaseSubPanel subPanel)
        {
            this.Controls.Add(subPanel);
        }

        public void RemoveSubPanel(BaseSubPanel subPanel)
        {
            this.Controls.RemoveAt(this.Controls.Count);
        }
    }
}
