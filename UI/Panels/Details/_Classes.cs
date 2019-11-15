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
    public partial class _Classes : BaseSubPanel
    {
        public _Classes()
        {
            InitializeComponent();
            InitAndRun(this.lst_Classe);
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\CIMV2"), new WqlObjectQuery("select * from meta_class"), null);
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
        }
    }
}
