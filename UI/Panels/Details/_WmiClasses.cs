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

        /// <summary>
        /// Get all classes for a selected namespace.
        /// Use Yeld to return each values in real time.
        /// </summary>
        /// <returns></returns>
        /// 
        protected override void Set(dynamic list)
        {
            base.Set(lst_WmiClassName);
        }

        protected override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.pause, null));
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + Sender["NameSpace"]), new WqlObjectQuery("select * from meta_class"), null);
                collection = nsClass.Get();
                if (collection.Count == 0) nsClass = null;
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null) {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
            }
            else
            {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.init, collection.Count));
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.start, null));
                foreach (ManagementClass wmiClass in collection)
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                        //use only static and dynamic
                        if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        {
                            yield return (wmiClass["__CLASS"].ToString());
                            onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.next, null));
                        }
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
                nsClass.Dispose();
            }
        }
       
        public void OnChangeIndex(object sender, EventArgs e)
        {
            if (lst_WmiClassName.SelectedItem.Equals("-- Select --")) return;
            Sender["WmiClassName"] = this.lst_WmiClassName.SelectedItem.ToString();
            SubPanelContainer.WmiDetails.Start();
            onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
        }
    }
}
