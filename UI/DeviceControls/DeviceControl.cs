using DiscoveryLight.Core.Device;
using DiscoveryLight.UI.BaseUserControl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoveryLight.UI.DeviceControls
{
    public class DeviceControlEventArgs : EventArgs                       // Task Event Args
    {
        public EventStatus Status { get; private set; }
        public enum EventStatus
        {
            start,
            next,
            pause,
            finish,
            init,
            empty
        }

        public DeviceControlEventArgs(EventStatus status)
        {
            this.Status = status;
        }
    }

    /// <summary>
    /// Extended user control. Define the main class for each custom device control.
    /// Class define four base core methods: update, start, show e abort. Each af them provide a rendering engine in background mode.
    /// </summary>
    public abstract class AbstractDeviceControl : _BaseUserControl
    {
        protected abstract void update();       // define action to run periodically
        protected abstract void validate();     // check all updates values and create a empty collection for empty collection
        protected abstract void abort();        // abort to update
        protected abstract void show();         // define action to show results in update
        protected abstract void start();        // load task in background then update and show until abort is requested

        // event handler associated to each methods. Each of them is raised when a method is called
        public event EventHandler OnStart;
        public event EventHandler OnAbort;
        public event EventHandler<DeviceControlEventArgs> OnUpdate;
        public event EventHandler<DeviceControlEventArgs> OnValidate;
        public event EventHandler<DeviceControlEventArgs> OnShow;

        protected virtual void onUpdate(DeviceControlEventArgs e)
        {
            EventHandler<DeviceControlEventArgs> handler = OnUpdate;
            handler?.Invoke(this, e);
        }

        protected virtual void onValidate(DeviceControlEventArgs e)
        {
            EventHandler<DeviceControlEventArgs> handler = OnValidate;
            handler?.Invoke(this, e);
        }

        protected virtual void onShow(DeviceControlEventArgs e)
        {
            EventHandler<DeviceControlEventArgs> handler = OnShow;
            handler?.Invoke(this, e);
        }

        protected virtual void onStart(EventArgs e)
        {
            EventHandler handler = OnStart;
            handler?.Invoke(this, e);
        }

        protected virtual void onAbort(EventArgs e)
        {
            EventHandler handler = OnAbort;
            handler?.Invoke(this, e);
        }
    }

    public class DeviceControl : AbstractDeviceControl
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;
        private string className;
        private Type classType;

        public string ClassName { get => className; set => className = value; }
        public Type ClassType { get => classType; set => classType = value; }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }

        private void setToken()
        {
            // create a new token for the next task
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            // get interval from user settings
            period = TimeSpan.FromMilliseconds(Convert.ToInt32(Settings.Settings.Default.Frequency));
        }
        private async Task run()
        {
            while (!this.token.IsCancellationRequested)
            {
                await Task.Delay(period, token);

                if (!token.IsCancellationRequested)
                {
                    await Task.Run(() => update(), token);
                    onUpdate(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.finish));
                    await Task.Run(() => validate(), token);
                    onValidate(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.finish));
                    await Task.Run(() => this.Invoke((System.Action)(() => show())), token); 
                    onShow(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.finish));
                }
            }
        }

        protected override void start()
        {
            onStart(EventArgs.Empty);       // raise the associated event
            abort();                        // abort all before                                                              
            setToken();                     // create a new token for the new task
            run();                          // run task until a abort request is raised
        }
        protected override void abort()
        {
            onAbort(EventArgs.Empty);                               // raise the associated event
            if (token != null && tokenSource != null)               // stop the task
                tokenSource.Cancel();
        }

        protected override void update()
        {
            onUpdate(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.start));             // raise the associated event
        }

        protected override void validate()
        {
            onValidate(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.start));           // raise the associated event
        }

        protected override void show()
        {
            onShow(new DeviceControlEventArgs(DeviceControlEventArgs.EventStatus.start));               // raise the associated event
        }

        public override void onLoad(object sender, EventArgs e)
        {
            start();             // load automatically when control is ready
        }
        public override void onDispose(object sender, EventArgs e)
        {
            abort();                    // abort loaded task when a dispose method is raised    
            this.Dispose(true);         // dispose all
            GC.SuppressFinalize(this);  // finalize and close
        }

        public DeviceControl()
        {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
        }
    }

    public interface IInitializable
    {
        void Init(_Device Device);

        _Device CurrentDevice { get; set; }
        _SubDevice CurrentSubDevice { get; set; }
    }
}
