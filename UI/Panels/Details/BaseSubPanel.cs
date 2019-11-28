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
    public abstract class _AbstractUIRendering : _BaseUserControl
    {
        public class TaskEventArgs : EventArgs                       // Task Event Args
        {
            public EventStatus Status { get; private set; }
            public Decimal? FillSize { get; private set; }
            public enum EventStatus                                 
            {
                start,
                next,
                pause,
                finish,
                init,
                empty
            }

            public TaskEventArgs(EventStatus status, Decimal? fillSize )
            {
                this.Status = status;
                this.FillSize = fillSize;
            }
        }

        public abstract void Start();                                // start Get method in baground              
        protected abstract IEnumerable<String> Get();                // get all values to fill the list of values in real time
        protected abstract void Set(dynamic list);                   // fill the list (comboBox or ListBox) using values form Get
        public abstract void Abort();                                // abort loaded thread

        // event handler associated to each methods. Each of them is raised when a method is called
        public event EventHandler OnStartThread;
        public event EventHandler OnAbortThread;
        public event EventHandler<TaskEventArgs> OnSetValues;
        public event EventHandler<TaskEventArgs> OnGetValues;

        protected virtual void onSetThread(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> handler = OnSetValues;
            this.Invoke((System.Action)(() => { handler?.Invoke(this, e); }));
        }
        protected virtual void onGetValues(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> handler = OnGetValues;
            this.Invoke((System.Action)(() => { handler?.Invoke(this, e); }));
        }
        protected virtual void onStartThread(EventArgs e)
        {
            EventHandler handler = OnStartThread;
            handler?.Invoke(this, e);
        }
        protected virtual void onAbortThread(EventArgs e)
        {
            EventHandler handler = OnAbortThread;
            handler?.Invoke(this, e);
        }

        // Manage  footer message box
        public void ChangeTitle(object sender, TaskEventArgs e)
        {
            switch (e.Status)
            {
                case TaskEventArgs.EventStatus.pause:
                    Forms.FormsCollection.Main.Footer.SetWaitTitle();
                    break;
                case TaskEventArgs.EventStatus.start:
                    Forms.FormsCollection.Main.Footer.SetLoadTitle();
                    break;
                case TaskEventArgs.EventStatus.finish:
                    Forms.FormsCollection.Main.Footer.SetMainTitle();
                    break;
            }
        }

        // Update Chart Bar Size in Footer
        public void UpdateChartBar(object sender, TaskEventArgs e)
        {
            switch (e.Status)
            {
                case TaskEventArgs.EventStatus.next:
                    Forms.FormsCollection.Main.Footer.UpdateChartBar();
                    break;
                case TaskEventArgs.EventStatus.init:
                    Forms.FormsCollection.Main.Footer.InitChartBar(e.FillSize);
                    break;
                case TaskEventArgs.EventStatus.finish:
                    Forms.FormsCollection.Main.Footer.InitChartBar(0); Abort();
                    break;
            }
        }

        // Reset Chart Bar in Footert
        public void Reset(object sender, EventArgs e)
        {
            Forms.FormsCollection.Main.Footer.InitChartBar(0);
        }

        public _AbstractUIRendering()
        {
            // add new event handler to manage footer
            OnGetValues += new EventHandler<TaskEventArgs>(ChangeTitle);
            OnGetValues += new EventHandler<TaskEventArgs>(UpdateChartBar);
            OnAbortThread += new EventHandler(Reset);
        }
    }

    public class BaseSubPanel: _AbstractUIRendering
    {
        static private Dictionary<string, string> sender = new Dictionary<string, string>()
        {
            {"NameSpace","" },
            {"WmiClassName",""}
        };
        
        private _Footer _footer;
        private Thread t;
        private _Details subPanelContainer;
        
        public _Details SubPanelContainer { get => subPanelContainer; set => subPanelContainer = value; }
        public _Footer Footer { get => _footer; set => _footer = value; }
        public static Dictionary<string, string> Sender { get => sender; set => sender = value; }

        private void listPrepare(dynamic list)
        {
            if (list != null) list.Items.Clear();
            if (list.GetType().FullName == typeof(ComboBox).FullName.ToString())   // use only comboBox control
            {
                list.Items.Add("-- Select --");                                    // initialize list with the first item "-- Select --"
                list.SelectedItem = "-- Select --";
            }
        }

        protected override void Set(dynamic list)
        {
            onSetThread(new TaskEventArgs(TaskEventArgs.EventStatus.start, null));
            this.Invoke((System.Action)(() => {listPrepare(list); }));
            foreach (String s in Get())
            {
                // get each values in collection to add in list
                this.Invoke((System.Action)(() => { list.Items.Add(s); }));
                onSetThread(new TaskEventArgs(TaskEventArgs.EventStatus.next, null));
            }
               
            onSetThread(new TaskEventArgs(TaskEventArgs.EventStatus.finish, null)); 
        }

        protected override IEnumerable<String> Get() {
            return null; 
        }

        public override void Abort()
        {
            if (t != null) t.Abort();
            onAbortThread(EventArgs.Empty);
        }

        public override void Start()
        {
            Abort();                                         // stop all loaded thread
            t = new Thread(Set);                             // create a new one
            t.Start();                                       // start to get values 
            onStartThread(EventArgs.Empty);                  // raise the associate Event
        }

        public override void onDispose(object sender, EventArgs e)
        {
            this.Abort();                           // Abort loaded thread
            this.Dispose(true);                     // Dispose all
            GC.SuppressFinalize(this);              // remove all resources
        }

        public override void onLoad(object sender, EventArgs e)
        {
            base.onLoad(sender, e);
            subPanelContainer = this.Parent as _Details;
            if (SubPanelContainer == null) return;
            Footer = subPanelContainer.Parent.Parent.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_Footer).FullName)).FirstOrDefault() as _Footer;
        }

        public BaseSubPanel() { }
    }
}
