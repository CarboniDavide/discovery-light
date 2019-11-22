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
        
        public _WmiClasses()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init(lst_WmiClassName);
            SubPanelContainer.WmiDetails.Init();
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + Sender["NameSpace"]), new WqlObjectQuery("select * from meta_class"), null);
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

        public override void OnChangeIndex(object sender, EventArgs e)
        {
            base.OnChangeIndex(sender, e);
            if (ListValues.SelectedItem == "-- Select --") return;
            Sender["WmiClassName"] = this.ListValues.SelectedItem.ToString();
            SubPanelContainer.WmiDetails.Load();
        }
    }
}
