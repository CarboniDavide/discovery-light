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
using System.Threading;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _WmiDetails : DevicePanel
    {
        private String nameSpace;
        private String wmiClassName;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;

        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }
        public string NameSpace { get => nameSpace; set => nameSpace = value; }
        public string WmiClassName { get => wmiClassName; set => wmiClassName = value; }
        public _WmiDetails()
        {
            InitializeComponent();
        }

        public override void StopLoadedTask()
        {
            if (token != null && tokenSource != null)
                tokenSource.Cancel();
        }
        private async void _WmiDetails_Load(object sender, EventArgs e)
        {
            SetToken();
            await Task.Run(()=>  GetNamespace());
        }

        private void SetToken()
        {
            tokenSource = new CancellationTokenSource();
            token = TokenSource.Token;
            period = TimeSpan.FromMilliseconds(0);
        }

        public async Task GetDetails()
        {
            this.Invoke((System.Action)(() => { lst_Details.Items.Clear(); })); 
            try
            {
                ManagementObjectSearcher nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + this.nameSpace), new WqlObjectQuery("select * from " + this.wmiClassName), null);
                int count = 0;
                foreach (ManagementObject wmiObject in nsClass.Get())
                {
                    if (token.IsCancellationRequested) break;
                    count++;
                    this.Invoke((System.Action)(() => { lst_Details.Items.Add(" [" + count.ToString() + "]"); }));

                    foreach (PropertyData property in wmiObject.Properties)
                    {
                        if (token.IsCancellationRequested) break;
                        if (property.Value != null)
                        {
                            if (property.IsArray)
                            {
                                this.Invoke((System.Action)(() => { lst_Details.Items.Add(" " + property.Name + ":"); }));
                                if (property.Type.ToString().Equals("String"))
                                {
                                    String[] arrConfigOptions = (String[])(wmiObject[property.Name]);
                                    foreach (String arrValue in arrConfigOptions)
                                        this.Invoke((System.Action)(() => { lst_Details.Items.Add("    - " + arrValue); }));
                                }
                            }
                            else
                                this.Invoke((System.Action)(() => { lst_Details.Items.Add(" " + property.Name + " = " + property.Value); }));
                        }
                    }
                    this.Invoke((System.Action)(() => { lst_Details.Items.Add(" "); }));
                }
                nsClass.Dispose();
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
            }
        }

        public async Task GetWmiClass()
        {
            this.Invoke((System.Action)(() => { cmb_WmiClassName.Items.Clear(); })); 
            
            try
            {
                // __namespace WMI class.
                ManagementObjectSearcher nsClass = new ManagementObjectSearcher(new ManagementScope("root\\" + this.nameSpace), new WqlObjectQuery("select * from meta_class"), null);
                this.Invoke((System.Action)(() => {
                    cmb_WmiClassName.Items.Add("--Select --");
                    cmb_WmiClassName.SelectedIndex = 0;
                }));
                foreach (ManagementClass wmiClass in nsClass.Get())
                {
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                    {
                        if (token.IsCancellationRequested) break;
                        if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                            this.Invoke((System.Action)(() => { cmb_WmiClassName.Items.Add(wmiClass["__CLASS"].ToString()); }));
                    }
                    if (token.IsCancellationRequested) break;
                }
                nsClass.Dispose();
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
            }
        }

        public async Task GetNamespace()
        {
            this.Invoke((System.Action)(() => {
                cmb_Namespace.Items.Clear();
                cmb_Namespace.Items.Add("--Select --");
                cmb_Namespace.SelectedIndex = 0;
            }));
            
            try
            {
                // __namespace WMI class.
                ManagementClass nsClass = new ManagementClass(new ManagementScope("root"), new ManagementPath("__namespace"), null);
                foreach (ManagementObject ns in nsClass.GetInstances())
                {
                    if (token.IsCancellationRequested) break;
                    this.Invoke((System.Action)(() => { cmb_Namespace.Items.Add(ns["Name"].ToString().ToUpper()); }));
                }
                nsClass.Dispose();
                if (lst_Details.Items.Count == 0)
                    this.Invoke((System.Action)(() => { lst_Details.Items.Add("Nothing ----"); })); 
            }
            catch (ManagementException e)
            {
                LogHelper.Log(LogTarget.File, e.ToString());
            }
        }

        private async void cmb_Namespace_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nameSpace = cmb_Namespace.SelectedItem.ToString();
            await Task.Run(()=> GetWmiClass());
        }

        private async void cmb_WmiClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.wmiClassName = cmb_WmiClassName.SelectedItem.ToString();
            await Task.Run(()=> GetDetails());
        }
    }
}
