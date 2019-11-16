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
    public partial class _SubNavigation : UserControl
    {
        private  _SubPanelContainer subPanelContainer;
        public _SubNavigation()
        {
            InitializeComponent();
        }

        private void cmd_NameSpace_Click(object sender, EventArgs e)
        {
            subPanelContainer.RemoveSubPanel();
            if (subPanelContainer.Controls.Count > 1)
                subPanelContainer.RemoveSubPanel();
        }

        private void cmd_Classe_Click(object sender, EventArgs e)
        {
            subPanelContainer.RemoveSubPanel();
        }

        private void ButtonsManage(object sender, ControlEventArgs e)
        {
            cmd_Classe.Visible = (subPanelContainer.Controls.Count >= 2);
            cmd_Details.Visible = (subPanelContainer.Controls.Count == 3);
        }

        private void _Navigation_Load(object sender, EventArgs e)
        {
            // get subpanel container
            subPanelContainer = this.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_SubPanelContainer).FullName)).FirstOrDefault() as _SubPanelContainer;
            // load first subpanel in container
            subPanelContainer.LoadSubPanel(new _WmiNameSpace());
            subPanelContainer.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ButtonsManage);
            subPanelContainer.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ButtonsManage);
        }
    }
}