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
    public abstract class AbstractBasePanel : DevicePanel
    {
        protected ListBox ListBoxValues;

        public abstract void InitAndRun(ListBox ListBoxValues);
        public abstract void FillInListBox();
        public abstract IEnumerable<String> Get();
        public override void StopLoadedTask()
        {
            base.StopLoadedTask();
        }
    }

    public class BasePanel: AbstractBasePanel
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;

        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }

        public async override void FillInListBox() {
            await Task.Run(() => {
                foreach (String ns in this.Get())
                    this.Invoke((System.Action)(() =>
                    {
                        ListBoxValues.Items.Add(ns);
                    }));
            }, token);
        }

        public override IEnumerable<String> Get() {
            return null;
        }

        public override void StopLoadedTask()
        {
            base.StopLoadedTask();
            if (token != null && tokenSource != null)
                tokenSource.Cancel();
        }

        private void SetToken()
        {
            tokenSource = new CancellationTokenSource();
            token = TokenSource.Token;
            period = TimeSpan.FromMilliseconds(0);
        }

        public override void InitAndRun(ListBox ListBoxValues)
        {
            this.ListBoxValues = ListBoxValues;
            StopLoadedTask();
            SetToken();
            FillInListBox();
        }

        public BasePanel()
        {
            SetToken();
        }
    }
}
