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
    public partial class _Details : BasePanel
    {
        public _Details()
        {
            InitializeComponent();
            InitAndRun(this.lst_Details);
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass;

            try
            {
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\CIMV2"), new WqlObjectQuery("select * from CIM_ProcessExecutable"), null);
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null) yield return null;

            int count = 0;
            foreach (ManagementObject wmiObject in nsClass.Get())
            {
                count++;
                yield return " [" + count.ToString() + "]";

                foreach (PropertyData property in wmiObject.Properties)
                {
                    if (property.Value != null)
                    {
                        if (property.IsArray)
                        {
                            yield return (" " + property.Name + ":");
                            if (property.Type.ToString().Equals("String"))
                            {
                                String[] arrConfigOptions = (String[])(wmiObject[property.Name]);
                                foreach (String arrValue in arrConfigOptions)
                                    yield return ("    - " + arrValue);
                            }
                        }
                        else
                            yield return (" " + property.Name + " = " + property.Value);
                    }
                }
                yield return " ";
            }
        }
    }
}
