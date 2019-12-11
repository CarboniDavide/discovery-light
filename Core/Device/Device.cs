using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.Core.Device
{
    public abstract class AbstractDevice
    {
        private int deviceNumber = 0;                               // number of device for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_Device> devices = new List<_Device>();        // List of properties for each device           
        private Boolean isNull;                                     // Check for null collection    

        public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }
        public List<_Device> Devices { get => devices; set => devices = value; }
        public bool IsNull { get => isNull; set => isNull = value; }

        /// <summary>
        /// Use Name or DeviceID to manage each device
        /// </summary>
        public enum GetBy
        {
            Name,
            DeviceID
        }

        /// <summary>
        /// Base device class. All device have a name and a DeviceId
        /// </summary>
        public class _Device
        {
            public String DeviceID;
            public String Name;
        }

        /// <summary>
        /// Get collection from wmi class 
        /// </summary>
        public abstract void GetCollection();

        /// <summary>
        /// Get ad device using name or device id
        /// </summary>
        /// <param name="GetBy"></param>
        public abstract void GetDevice(GetBy GetBy);
    }
}
