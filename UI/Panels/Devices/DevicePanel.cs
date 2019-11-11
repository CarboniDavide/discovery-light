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
        public abstract void InitPerformance(List<Type> PerformancesTypes);
        public abstract void ShowProperties();
        public abstract void ShowPerformance();
    }

    public class DevicePanel : AbstractDevicePanel
    {
        private DeviceData currentDevice;
        private List<DevicePerformance> currentPerformances;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;
        private DeviceData. _Block currentSubDevice;

        public DeviceData CurrentDevice { get => currentDevice; set => currentDevice = value; }
        public List<DevicePerformance> CurrentPerformances { get => currentPerformances; set => currentPerformances = value; }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }
        public DeviceData._Block CurrentSubDevice { get => currentSubDevice; set => currentSubDevice = value; }

        public DeviceData GetDevice(Type type){
            return Program.Devices.Where(d => d.Properties.GetType() == type).First().Properties;
        }
        public List<DevicePerformance> GetPerformance(List<Type> PerformancesTypes)
        {
            List<DevicePerformance> mm = new List<DevicePerformance>();
            foreach (Type deviceType in PerformancesTypes)
                mm.Add(Program.Performances.Where(d => d.Properties.GetType() == deviceType).First().Properties);
            return mm;
        }
        public override void InitProperties(Type DeviceType) {
            this.CurrentDevice = this.GetDevice(DeviceType);
            if (this.CurrentDevice.Blocks.Count == 0) return;
            this.CurrentSubDevice = this.CurrentDevice.Blocks.First();
        }
        public override void InitPerformance(List<Type> PerformancesTypes) {
            this.CurrentPerformances = this.GetPerformance(PerformancesTypes);
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
                    foreach (DevicePerformance currentPerformance in currentPerformances)
                        await Task.Run(() => currentPerformance.GetPerformance());
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
