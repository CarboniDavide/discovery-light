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
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public dynamic ListValues { get => listValues; set => listValues = value; }

        public async void FillInListBox() {

            await Task.Run(() => {
                foreach (String ns in Get())
                {
                    Console.WriteLine(Token.IsCancellationRequested);

                    if (Token.IsCancellationRequested) 
                        break;

                    this.Invoke((System.Action)(() =>
                        {
                            this.ListValues.Items.Add(ns);
                        }));
                }
            });
        }

        public override IEnumerable<String> Get() { return null; }

        public override void Init() {
            this.StopLoadedSubTask();
            if (ListValues != null) ListValues.Items.Clear();
        }

        public override void StopLoadedSubTask()
        {
            if (this.token != null && this.tokenSource != null)
                this.tokenSource.Cancel();
        }

        private void SetToken()
        {
            this.tokenSource = new CancellationTokenSource();
            this.token = TokenSource.Token;
        }

        public override void Load()
        {
            FillInListBox();
        }

        public BaseSubPanel() {
            this.SetToken();
        }
    }
}
