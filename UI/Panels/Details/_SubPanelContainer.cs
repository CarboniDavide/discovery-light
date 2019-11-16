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
            for (int i = 0; i < this.Controls.Count - 1; i++)
                this.Controls[i].Hide();
        }

        public void RemoveSubPanel()
        {
            var control = this.Controls[this.Controls.Count - 1] as BaseSubPanel;
            control.StopLoadedSubTask();
            this.Controls.RemoveAt(this.Controls.Count - 1);
            this.Controls[this.Controls.Count - 1].Show();
        }
    }
}
