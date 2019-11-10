using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;


namespace DiscoveryLight.UI.Panels.Devices
{
    public abstract class AbstractDevicePanel : System.Windows.Forms.UserControl
    {
        public abstract void InitProperties(Type type);
        public abstract void InitPerformance(Type type);
        public abstract void ShowProperties();
        public abstract void ShowPerformance();
    }

    public class DevicePanel : AbstractDevicePanel
    {
        private DeviceData currentDevice;
        private DevicePerformance currentPerformance;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;
        
        public DeviceData CurrentDevice { get => currentDevice; set => currentDevice = value; }
        public DevicePerformance CurrentPerformance { get => currentPerformance; set => currentPerformance = value; }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }

        private DeviceData GetDevice(Type type){
            return Program.Devices.Where(d => d.Properties.GetType() == type).First().Properties;
        }
        private DevicePerformance GetPerformance(Type type)
        {
            return Program.Performances.Where(d => d.Properties.GetType() == type).First().Properties;
        }
        public override void InitProperties(Type type) {
            this.CurrentDevice = this.GetDevice(type);
        }
        public override void InitPerformance(Type type) {
            this.CurrentPerformance = this.GetPerformance(type);
        }
        public override void ShowProperties() { }
        public override void ShowPerformance() { }

        protected void Start()
        {
            this.ShowProperties();
            this.Run();
        }

        public async Task Run()
        {
            while (!this.token.IsCancellationRequested)
            {
                await Task.Delay(period, token);

                if (!token.IsCancellationRequested)
                {
                    await Task.Run(() => this.CurrentPerformance.GetPerformance());
                    ShowPerformance();
                }
            }
        }

        public void Stop()
        {
            this.tokenSource.Cancel();
        }

        public DevicePanel()
        {
            this.tokenSource = new CancellationTokenSource();
            this.token = TokenSource.Token;
            this.period = TimeSpan.FromMilliseconds(500);
        }

    }
}
