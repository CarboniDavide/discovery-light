using DiscoveryLight.Core.Device;
using DiscoveryLight.Core.Device.Utils;
using DiscoveryLight.UI.BaseUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoveryLight.UI.DeviceControls
{
    /// <summary>
    /// Extended user control. Define the main class for each custom device control.
    /// Class define four base core methods: update, start, show e abort. Each af them provide a rendering engine in background mode.
    /// </summary>
    public abstract class AbstractDeviceControl : _BaseUserControl
    {
        protected abstract void update();       // define action to run periodically
        protected abstract void validate();     // check all updates values
        protected abstract void abort();        // abort to update
        protected abstract void show();         // define action to show results in update
        protected abstract void start();        // load task in background then update and show until abort is requested

        // event handler associated to each methods. Each of them is raised when a method is called
        public event EventHandler OnStart;
        public event EventHandler OnAbort;
        public event EventHandler OnUpdateStart;
        public event EventHandler OnUpdateFinish;
        public event EventHandler OnValidateStart;
        public event EventHandler OnValidateFinish;
        public event EventHandler OnShow;

        protected virtual void onUpdateStart(EventArgs e)
        {
            EventHandler handler = OnUpdateStart;
            handler?.Invoke(this, e);
        }

        protected virtual void onUpdateFinish(EventArgs e)
        {
            EventHandler handler = OnValidateStart;
            handler?.Invoke(this, e);
        }

        protected virtual void onValidateStart(EventArgs e)
        {
            EventHandler handler = OnUpdateStart;
            handler?.Invoke(this, e);
        }
        protected virtual void onValidateFinish(EventArgs e)
        {
            EventHandler handler = OnValidateFinish;
            handler?.Invoke(this, e);
        }

        protected virtual void onStart(EventArgs e)
        {
            EventHandler handler = OnStart;
            handler?.Invoke(this, e);
        }

        protected virtual void onShow(EventArgs e)
        {
            EventHandler handler = OnShow;
            handler?.Invoke(this, e);
        }

        protected virtual void onAbort(EventArgs e)
        {
            EventHandler handler = OnAbort;
            handler?.Invoke(this, e);
        }
    }

    public class DeviceControl: AbstractDeviceControl
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
                    await Task.Run(() => update());
                    onUpdateFinish(EventArgs.Empty);
                    await Task.Run(() => validate());
                    onValidateFinish(EventArgs.Empty);
                    show();
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

        protected override void update() {
            onUpdateStart(EventArgs.Empty);             // raise the associated event
        }

        protected override void validate() {
            onValidateStart(EventArgs.Empty);           // raise the associated event
        }

        protected override void show() {
            onShow(EventArgs.Empty);                    // raise the associated event
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

        public DeviceControl() {
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
