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
using DiscoveryLight.UI.Forms.Main;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _WmiDetails : BaseSubPanel
    {
        public _WmiDetails()
        {
            InitializeComponent();
        }

        protected override void Set(dynamic list)
        {
            base.Set(lst_Details);
        }

        /// <summary>
        /// Get all details for a selected wmi class.
        /// Use Yeld to return each values in real time.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.pause, null));
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + Sender["NameSpace"]), new WqlObjectQuery("select * from " + Sender["WmiClassName"]), null);
                collection = nsClass.Get();
                if (collection.Count == 0) nsClass = null;
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }


            if (nsClass == null)
            {
                yield return ("Not Found");
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
            }
            else
            {
                int count = 0;
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.init, collection.Count));
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.start, null));
                
                foreach (ManagementObject wmiObject in collection)                          // read all subdrive info
                {

                    count++;
                    yield return (" [" + count.ToString() + "]");

                    foreach (PropertyData property in wmiObject.Properties)                // read all sub property for each sub drive 
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
                    yield return (" ");
                    onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.next, null));
                }
                if (count == 0) yield return ("Not Found");
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
                nsClass.Dispose();
            }
        }
    }
}
