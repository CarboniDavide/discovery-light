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
    }

    public class BaseSubPanel: AbstractBaseSubPanel
    {
        private dynamic listValues;
        private Thread t;
        public dynamic ListValues { get => listValues; set => listValues = value; }
        public Thread T { get => t; set => t = value; }

        public void FillInListBox() {
            
            if (ListValues != null) this.Invoke((System.Action)(() => { ListValues.Items.Clear(); }));
            foreach (String ns in Get())
                this.Invoke((System.Action)(() => { this.ListValues.Items.Add(ns); }));
        }

        public override IEnumerable<String> Get() { return null; }

        public override void Init() {
            
            SetThread();
        }

        public override void StopLoadedSubTask()
        {
            if (t != null) t.Abort();
        }

        private void SetThread()
        {
            StopLoadedSubTask();
            t = new Thread(FillInListBox);
        }

        public override void Load()
        {
            t.Start();
        }

        public BaseSubPanel() { }
    }
}
