using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public abstract class AbstractDevicePerformanceControl : System.Windows.Forms.UserControl
    {
        public abstract void InitPerformace(DevicePerformance Device);
        public abstract void ShowPerformance();
        public abstract void RunPerformance();
        public abstract void StopPerformance();
    }

    public class DevicePerformanceControl: AbstractDevicePerformanceControl
    {
        private DevicePerformance currentPerformance;
        private int currentSubDevice;
        private Type deviceType;
        private String deviceName;

        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private TimeSpan period;

        public DevicePerformance CurrentPerformance
        {
            get { return currentPerformance; }
            set
            {
                if (value == null) return;
                currentPerformance = value;
                deviceType = currentPerformance.GetType();
                deviceName = deviceType.ToString();
                currentSubDevice = 0;
            }
        }
        public int CurrentSubDevice { get => currentSubDevice; set => currentSubDevice = value; }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }
        public CancellationToken Token { get => token; set => token = value; }
        public TimeSpan Period { get => period; set => period = value; }

        public override void InitPerformace(DevicePerformance Performance)
        {
            CurrentPerformance = Performance;
        }
        private void SetToken()
        {
            tokenSource = new CancellationTokenSource();
            token = TokenSource.Token;
            period = TimeSpan.FromMilliseconds(500);
        }
        public override void ShowPerformance() { }

        public override async void RunPerformance()
        {
            StopPerformance();
            SetToken();
            Run();
        }

        public async Task Run()
        {
            while (!this.token.IsCancellationRequested)
            {
                await Task.Delay(period, token);

                if (!token.IsCancellationRequested)
                {
                    await Task.Run(() => currentPerformance.GetPerformance());
                    ShowPerformance();
                }
            }
        }

        public override void StopPerformance()
        {
            if (token != null && tokenSource != null)
                tokenSource.Cancel();
        }

        public DevicePerformanceControl(DevicePerformance Performance) {
            if (Performance == null) return;
            InitPerformace(Performance);
        }

        public DevicePerformanceControl()
        {
        }
    }
}
