using DiscoveryLight.UI.BaseUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoveryLight.UI.DeviceControls
{
    public abstract class AbstractDeviceControl : _BaseUserControl
    {
        protected abstract void update();
        protected abstract void abort();
        protected abstract void show();
        protected abstract void start();

        public event EventHandler OnStart;
        public event EventHandler OnAbort;
        public event EventHandler OnUpdate;
        public event EventHandler OnShow;

        protected virtual void onUpdate(EventArgs e)
        {
            EventHandler handler = OnUpdate;
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
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
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
                    show();
                }
            }
        }

        protected override void start()
        {
            onStart(EventArgs.Empty);
            abort();
            setToken();
            run();
        }
        protected override void abort()
        {
            onAbort(EventArgs.Empty);
            if (token != null && tokenSource != null)
                tokenSource.Cancel();
        }
        protected override void update() {
            onUpdate(EventArgs.Empty);
        }
        protected override void show() {
            onShow(EventArgs.Empty);
        }

        public override void onLoad(object sender, EventArgs e)
        {
            start();
        }
        public override void onDispose(object sender, EventArgs e)
        {
            abort();
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DeviceControl() {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
        }
    }
}
