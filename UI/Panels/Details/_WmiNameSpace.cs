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

        public override void Init()
        {
            base.Init(lst_NameSpaces);
            SubPanelContainer.WmiClasses.Init();
        }

        /// <summary>
        /// Read all namespace available in the wmi managment class.
        /// Use Yeld to return each values in real time.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<String> Get()
        {
            base.Get();
            ManagementClass nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                // __namespace WMI class.
                nsClass = new ManagementClass(new ManagementScope("root"), new ManagementPath("__namespace"), null);
                collection = nsClass.GetInstances();
                if (collection.Count == 0) nsClass = null;
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
            }

            if (nsClass == null)
                yield return "Not Found";
            else
            {
                foreach (ManagementObject ns in collection)
                    yield return (ns["Name"].ToString().ToUpper());
                nsClass.Dispose();
            }
        }
        public override void OnChangeIndex(object sender, EventArgs e)
        {
            base.OnChangeIndex(sender, e);
            if (ListValues.SelectedItem == "-- Select --") return;              // don't perform  default value
            Sender["NameSpace"] = this.ListValues.SelectedItem.ToString();      // update the current select namespace
            SubPanelContainer.WmiClasses.Load();                                // load all wmi classes for a selected namespace
            
        }
    }
}
