using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;


namespace DiscoveryLight.UI.Panels.Devices
{
    public abstract class AbstractDevice: System.Windows.Forms.UserControl
    {
        public abstract void LoadProperties();
    }

    public class Device: AbstractDevice
    {
        private DeviceData currentDevice;
        public DeviceData CurrentDevice { get => currentDevice; set => currentDevice = value; }

        // Get the loaded device and store it into Device
        public Device(Type type){
            this.currentDevice = this.GetDevice(type);
        }

        public Device(){}

        private DeviceData GetDevice(Type type){
            return Program.Devices.Where(d => d.Properties.GetType() == type).First().Properties;
        }
        public override void LoadProperties(){}
    }
}
