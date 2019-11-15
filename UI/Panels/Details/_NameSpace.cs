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
    public partial class _NameSpace : BasePanel
    {
        public _NameSpace()
        {
            InitializeComponent();
            InitAndRun(this.lst_NameSpace);
        }

        public override IEnumerable<String> Get()
        {
            base.Get();
            ManagementClass nsClass;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementClass(new ManagementScope("root"), new ManagementPath("__namespace"), null);
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null) yield return null;

            foreach (ManagementObject ns in nsClass.GetInstances())
                    yield return ns["Name"].ToString().ToUpper();
            
        }
    }
}
