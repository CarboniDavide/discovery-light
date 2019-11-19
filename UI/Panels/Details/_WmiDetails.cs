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
        public String NameSpace;
        public String WmiClassName;
        public _WmiDetails()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            this.ListValues = this.lst_Details;
            this.Load();
        }

        public override IEnumerable<String> Get()
        {
            base.Get();

            ManagementObjectSearcher nsClass = null;
            ManagementObjectCollection collection = null;

            try
            {
                this.Invoke((System.Action)(() => { Footer.ChartBar.CustomText = "Wait one moment ..."; }));
                nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + this.NameSpace), new WqlObjectQuery("select * from " + this.WmiClassName), null);
                collection = nsClass.Get();
                if (collection.Count == 0) nsClass = null;
                this.Invoke((System.Action)(() => { Footer.ChartBar.CustomText = Footer.FooterTittleName; }));
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
                int count = 0;
                double step = (double)Decimal.Divide(100, collection.Count);
                double barSize = 0;

                foreach (ManagementObject wmiObject in collection)
                {
                   
                    count++;
                    yield return (" [" + count.ToString() + "]");

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
                    yield return (" ");
                    barSize += step;
                    this.Invoke((System.Action)(() => { Footer.ChartBar.BarFillSize = (int)barSize; }));
                }
                if (count == 0) yield return ("Not Found");
                nsClass.Dispose();
                this.Invoke((System.Action)(() => { Footer.ChartBar.BarFillSize = 0; }));
            }
        }
    }
}
