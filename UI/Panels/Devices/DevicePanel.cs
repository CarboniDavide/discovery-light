using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;


namespace DiscoveryLight.UI.Panels.Devices
{
    public abstract class AbstractDevicePanel : System.Windows.Forms.UserControl
    {
        public abstract void InitProperties(Type type);
        public abstract void InitPerformance(Type type);
        public abstract void LoadProperties();
        public abstract void LoadPerformance();
    }

    public class DevicePanel : AbstractDevicePanel
    {
        private DeviceData currentDevice;
        private DevicePerformance currentPerformance;
        private Task taskPerformance;
        public DeviceData CurrentDevice { get => currentDevice; set => currentDevice = value; }
        public DevicePerformance CurrentPerformance { get => currentPerformance; set => currentPerformance = value; }
        public Task TaskPerformance { get => taskPerformance; set => taskPerformance = value; }

        public DevicePanel(){}

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

        public override void LoadProperties() { }

        public override void LoadPerformance() { }

    }
}
