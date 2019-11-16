using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using DiscoveryLight.Logging;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _WmiClasses : BaseSubPanel
    {
        private String nameSpace;
        public _WmiClasses(String nameSpace)
        {
            InitializeComponent();
            this.nameSpace = nameSpace;
            InitAndRun(this.lst_Classe);
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + this.nameSpace), new WqlObjectQuery("select * from meta_class"), null);
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null) yield return null;

            foreach (ManagementClass wmiClass in nsClass.Get())
                foreach (QualifierData qd in wmiClass.Qualifiers)
                    // Si la classe est dynamique, ajoute les valeurs dans la liste.
                    if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        yield return wmiClass["__CLASS"].ToString();

            nsClass.Dispose();
        }

        private void lst_Classe_Click(object sender, EventArgs e)
        {
            // get subpanel container
            var subPanelContainer = this.Parent.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_SubPanelContainer).FullName)).FirstOrDefault() as _SubPanelContainer;
            // load first subpanel in container
            subPanelContainer.LoadSubPanel(new _WmiDetails(this.nameSpace, this.lst_Classe.SelectedItem.ToString()));
        }
    }
}
