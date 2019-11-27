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
    /// <summary>
    /// Abstract BaseSub Panel.
    /// Manage all wmi details using a dynamic list performed in background mode
    /// </summary>
    public abstract class AbstractBaseSubPanel : _BaseUserControl
    {
        private dynamic listValues;
        public dynamic ListValues { get => listValues; set => listValues = value; }
        public abstract void Init(dynamic ListOfValues);                      // init list of values 
        public abstract void Init();
        public abstract void Load();                                          // prepare thread and start Get method in baground              
        public abstract IEnumerable<String> Get();                            // get all values to fill the list of values                  
        public abstract void StopLoadedSubTask();                             // abort loaded thread
        public abstract void OnChangeIndex(object sender, EventArgs e);       // action to execute when a value in list is selected
    }

    public class BaseSubPanel: AbstractBaseSubPanel
    {
        static private Dictionary<string, string> sender = new Dictionary<string, string>()
        {
            {"NameSpace","" },
            {"WmiClassName",""}
        };
        private _Footer _footer;
        
        private Thread t;
        private _Details subPanelContainer;
        public Thread T { get => t; set => t = value; }
        public _Details SubPanelContainer { get => subPanelContainer; set => subPanelContainer = value; }
        public _Footer Footer { get => _footer; set => _footer = value; }
        public static Dictionary<string, string> Sender { get => sender; set => sender = value; }

        public void FillInListBox()
        {
            this.Invoke((System.Action)(() => {ListPrepare();}));                               // initialize list before
            foreach (String ns in Get())                                                        // get each values and fill list in the same time
                this.Invoke((System.Action)(() => { this.ListValues.Items.Add(ns); }));
        }

        public override void OnChangeIndex(object sender, EventArgs e) {
            if (Footer != null) Footer.ChartBar.BarFillSize = 0;             // reset chargin bar
        }

        public override IEnumerable<String> Get() { return null; }

        
        public void ListPrepare()
        {
            if (ListValues != null) ListValues.Items.Clear();
            if (ListValues.GetType().FullName == typeof(ComboBox).FullName.ToString()) // use only comboBox control
            {
                this.ListValues.Items.Add("-- Select --");             // initialize list with the first item "-- Select --"
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
            if (Footer != null) Footer.ChartBar.BarFillSize = 0;
        }

        public override void Load()
        {
            StopLoadedSubTask();             // stop all loaded thread
            t = new Thread(FillInListBox);   // create a new one
            t.Start();                       // start to get values       
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
