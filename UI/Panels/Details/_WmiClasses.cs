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
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _WmiClasses : BaseSubPanel
    {
        public String NameSpace;
        public _WmiClasses()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            this.ListValues = this.lst_WmiClassName;
            this.Load();
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + this.NameSpace), new WqlObjectQuery("select * from meta_class"), null);
                collection = nsClass.Get();
                if (collection.Count == 0) nsClass = null;
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null)
                yield return ("Not Found");
            else
            {
                foreach (ManagementClass wmiClass in collection)
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                        // Si la classe est dynamique, ajoute les valeurs dans la liste.
                        if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                            yield return (wmiClass["__CLASS"].ToString());
                nsClass.Dispose();
            }
        }

        private void lst_Classe_Click(object sender, EventArgs e)
        {
            // get subpanel container
            var subPanelContainer = this.Parent as _Details;
            // load first subpanel in container
            subPanelContainer.WmiDetails.NameSpace = this.NameSpace;
            subPanelContainer.WmiDetails.WmiClassName = this.lst_WmiClassName.SelectedItem.ToString();
            subPanelContainer.WmiDetails.Init();
        }
    }
}
