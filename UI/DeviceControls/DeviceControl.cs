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

    }

    public class DeviceControl: AbstractDeviceControl
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;

        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }

        private void setToken()
        {
            tokenSource = new CancellationTokenSource();
            token = TokenSource.Token;
            period = TimeSpan.FromMilliseconds(500);
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
            abort();
            setToken();
            run();
        }
        protected override void abort()
        {
            if (token != null && tokenSource != null)
                tokenSource.Cancel();
        }
        protected override void update() { }
        protected override void show() { }

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

        public DeviceControl() { }
    }
}
