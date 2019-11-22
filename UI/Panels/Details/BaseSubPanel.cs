using DiscoveryLight.UI.BaseUserControl;
using DiscoveryLight.UI.Forms.Main;
using DiscoveryLight.UI.Panels.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Details
{
    public abstract class AbstractBaseSubPanel : _BaseUserControl
    {
        public abstract void Init(dynamic ListOfValues);
        public abstract void Init();
        public abstract void Load();
        public abstract IEnumerable<String> Get();
        public abstract void StopLoadedSubTask();
        public abstract void OnChangeIndex(object sender, EventArgs e);
    }
    public class BaseSubPanel: AbstractBaseSubPanel
    {
        static private Dictionary<string, string> sender = new Dictionary<string, string>()
        {
            {"NameSpace","" },
            {"WmiClassName",""}
        };
        private _Footer _footer;
        private dynamic listValues;
        private Thread t;
        private _Details subPanelContainer;
        public dynamic ListValues { get => listValues; set => listValues = value; }
        public Thread T { get => t; set => t = value; }
        public _Details SubPanelContainer { get => subPanelContainer; set => subPanelContainer = value; }
        public _Footer Footer { get => _footer; set => _footer = value; }
        public static Dictionary<string, string> Sender { get => sender; set => sender = value; }

        public void FillInListBox()
        {
            this.Invoke((System.Action)(() => {ListPrepare();}));
            foreach (String ns in Get())
                this.Invoke((System.Action)(() => { this.ListValues.Items.Add(ns); }));
        }

        public override void OnChangeIndex(object sender, EventArgs e) {
            if (Footer != null) Footer.ChartBar.BarFillSize = 0;
        }

        public override IEnumerable<String> Get() { return null; }

        public void ListPrepare()
        {
            if (ListValues != null) ListValues.Items.Clear();
            if (ListValues.GetType().FullName == typeof(ComboBox).FullName.ToString())
            {
                this.ListValues.Items.Add("-- Select --");
                this.ListValues.SelectedItem = "-- Select --";
            }
        }

        public override void Init(dynamic ListOfValues) 
        {
            subPanelContainer = this.Parent as _Details;
            ListValues = ListOfValues;
            Footer = this.Parent.Parent.Parent.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_Footer).FullName)).FirstOrDefault() as _Footer;
        }

        public override void Init() { }

        public override void StopLoadedSubTask()
        {
            if (t != null) t.Abort();
        }

        public override void Load()
        {
            StopLoadedSubTask();
            t = new Thread(FillInListBox);
            t.Start();
        }

        public override void onDispose(object sender, EventArgs e)
        {
            StopLoadedSubTask();
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BaseSubPanel() { }
    }
}
