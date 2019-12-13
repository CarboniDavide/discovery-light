using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device
{
    public abstract class AbstractDevice
    {
        protected readonly string className;
        protected readonly Type classType;
        private int deviceNumber = 0;                               // number of device for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_Device> devices = new List<_Device>();        // List of properties for each device           
        private Boolean isNull;                                     // Check for null collection    

        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }
        public List<_Device> Devices { get { return devices; } set { devices = value; DeviceNumber = value.Count; } }
        public bool IsNull { get => isNull; set => isNull = value; }

        /// <summary>
        /// Base device class. All device have a name and a DeviceId
        /// </summary>
        public class _Device
        {
            public String DeviceID;
            public String Name;
            public String Caption;
            public String Description;

            /// <summary>
            /// Serialize all field with ManagementObject
            /// </summary>
            /// <param name="mj"></param>
            /// <returns></returns>
            public _Device Serialize(WprManagementObject mj)
            {
                foreach (FieldInfo field in this.GetType().GetFields())
                    field.SetValue(this, mj.GetProperty(field.Name).AsString());

                return this;
            }

            /// <summary>
            /// Serialize all field with ManagementObject only for the specified fields
            /// </summary>
            /// <param name="mj"></param>
            /// <param name="Fields"></param>
            /// <returns></returns>
            public _Device Serialize(WprManagementObject mj, List<String> Fields)
            {
                foreach (FieldInfo field in this.GetType().GetFields())
                    if (Fields.Contains(field.Name))
                        field.SetValue(this, mj.GetProperty(field.Name).AsString());

                return this;
            }

        }

        /// <summary>
        /// Get collection from wmi class 
        /// </summary>
        public abstract List<_Device> GetCollection();

        /// <summary>
        /// Update collection from wmi class 
        /// </summary>
        public abstract void UpdateCollection();

        /// <summary>
        /// Get ad device using name or device id
        /// </summary>
        /// <param name="GetBy"></param>
        public abstract _Device GetDevice(String GetBy);

        /// <summary>
        /// Update a single device from wmi class 
        /// </summary>
        public abstract void UpdateDevice(String DeviceName);

        public AbstractDevice()
        {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
        }
    }
}
