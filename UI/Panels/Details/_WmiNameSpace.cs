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
    public partial class _WmiNameSpace : BaseSubPanel
    {
        public _WmiNameSpace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Read all namespace available in the wmi managment class.
        /// Use Yeld to return each values in real time.
        /// </summary>
        /// <returns></returns>
        /// 
        protected override void Set(dynamic list)
        {
            base.Set(lst_NameSpaces);
        }

        protected override IEnumerable<String> Get()
        {
            base.Get();
            ManagementClass nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.pause, null));
                // __namespace WMI class.
                nsClass = new ManagementClass(new ManagementScope("root"), new ManagementPath("__namespace"), null);
                collection = nsClass.GetInstances();
                if (collection.Count == 0) nsClass = null;
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
                nsClass = null;
            }

            if (nsClass == null)
            {
                yield return "Not Found";
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
            }
            else
            {
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.init, collection.Count));
                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.start, null));
                foreach (ManagementObject ns in collection)
                {
                    yield return (ns["Name"].ToString().ToUpper());
                    onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.next, null));
                }

                onGetValues(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null));
                nsClass.Dispose();
            }
        }
        public void OnChangeIndex(object sender, EventArgs e)
        {
            if (lst_NameSpaces.SelectedItem.Equals("-- Select --")) return;              // don't perform  default value
            Sender["NameSpace"] = this.lst_NameSpaces.SelectedItem.ToString();           // update the current select namespace
            SubPanelContainer.WmiClasses.Start();                                        // load all wmi classes for a selected namespace
            SubPanelContainer.WmiDetails.Abort();                                        // Abort eventually thread loaded in details               
        }
    }
}
