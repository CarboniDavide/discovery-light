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
        protected ListBox ListBoxValues;

        public abstract void InitAndRun(ListBox ListBoxValues);
        public abstract void FillInListBox();
        public abstract IEnumerable<String> Get();
        public abstract void StopLoadedSubTask();
    }

    public class BaseSubPanel: AbstractBaseSubPanel
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
                {
                    if (token.IsCancellationRequested) break;

                    this.Invoke((System.Action)(() =>
                        {
                            ListBoxValues.Items.Add(ns);
                        }));
                }
            });
        }

        public override IEnumerable<String> Get() {
            return null;
        }

        public override void StopLoadedSubTask()
        {
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
            this.ListBoxValues.Items.Clear();
            StopLoadedSubTask();
            SetToken();
            FillInListBox();
        }

        public BaseSubPanel()
        {
            SetToken();
        }
    }
}
