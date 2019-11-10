using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.Core.Device.Performance
{
    class Performance
    {
        private String name;
        private DevicePerformance properties;

        public string Name { get => name; set => name = value; }
        public DevicePerformance Properties
    {
            get { return properties; }
            set
            {
                properties = value;
                this.Name = this.properties.GetType().Name;
            }
        }

        public Performance(DevicePerformance Performance)
        {
            this.Properties = Performance;
        }
    }
}
