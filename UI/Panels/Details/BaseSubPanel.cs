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
    public abstract class AbstractBaseSubPanel : UserControl
    {
        public abstract void Init();
        public abstract void Load();
        public abstract IEnumerable<String> Get();
        public abstract void StopLoadedSubTask();
        public abstract void OnChangeIndex(object sender, EventArgs e);
    }
    public class BaseSubPanel: AbstractBaseSubPanel
    {
        private _Footer _footer;
        private dynamic listValues;
        private Thread t;
        private _Details subPanelContainer;
        public dynamic ListValues { get => listValues; set => listValues = value; }
        public Thread T { get => t; set => t = value; }
        public _Details SubPanelContainer { get => subPanelContainer; set => subPanelContainer = value; }
        public _Footer Footer { get => _footer; set => _footer = value; }

        public void FillInListBox()
        {
            this.Invoke((System.Action)(() => {listPrepare();}));
            foreach (String ns in Get())
                this.Invoke((System.Action)(() => { this.ListValues.Items.Add(ns); }));
        }

        public override void OnChangeIndex(object sender, EventArgs e)
        {
            subPanelContainer = this.Parent as _Details;
            
        }

        public override IEnumerable<String> Get() { return null; }

        public void listPrepare()
        {
            if (ListValues != null) ListValues.Items.Clear();
            if (ListValues.GetType().FullName == typeof(ComboBox).FullName.ToString())
            {
                this.ListValues.Items.Add("-- Select --");
                this.ListValues.SelectedItem = "-- Select --";
            }
        }

        public override void Init() 
        {
            StopLoadedSubTask();
            Footer = this.Parent.Parent.Parent.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_Footer).FullName)).FirstOrDefault() as _Footer;
            if (Footer != null) Footer.ChartBar.BarFillSize = 0;
            t = new Thread(FillInListBox);
        }

        public override void StopLoadedSubTask()
        {
            if (t != null) t.Abort();
        }

        public override void Load()
        {
            t.Start();
        }

        public BaseSubPanel() { }
    }
}
