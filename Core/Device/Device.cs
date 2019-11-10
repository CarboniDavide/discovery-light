using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.Core.Device.Data
{

    public class Device
    {
        private String name;
        private DeviceData properties;

        public string Name { get => name; set => name = value; }
        public DeviceData Properties {
            get { return properties; }
            set { 
                properties = value; 
                this.Name = this.Properties.GetType().Name;
            }
        }

        public Device(DeviceData Device)
        {
            this.Properties = Device;
        }
    }
}
