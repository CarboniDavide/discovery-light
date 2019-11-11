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
        private String currentSubDeviceName;
        private Int32 currentSubDeviceID;

        public DeviceData CurrentDevice { get => currentDevice; set => currentDevice = value; }
        public List<DevicePerformance> CurrentPerformances { get => currentPerformances; set => currentPerformances = value; }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }
        public String CurrentSubDeviceName { get => currentSubDeviceName; set => currentSubDeviceName = value; }
        public Int32 CurrentSubDeviceID { get => currentSubDeviceID; set => currentSubDeviceID = value; }

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
        public override void InitProperties(Type type) {
            this.CurrentDevice = this.GetDevice(type);
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
