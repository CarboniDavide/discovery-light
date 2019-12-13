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
        private Boolean isNull;                                     // Check for null WprManagementObjec
        private String primaryKey;                                  // define entry key in _Device for search items

        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }
        public List<_Device> Devices { get { return devices; } set { devices = value; DeviceNumber = value.Count; } }
        public bool IsNull { get => isNull; set => isNull = value; }
        public string PrimaryKey { get => primaryKey; set => primaryKey = value; }

        /// <summary>
        /// Base device class. All device have a name and a DeviceId
        /// </summary>
        public class _Device
        {
            public MobProperty DeviceID;
            public MobProperty Name;
            public MobProperty Caption;
            public MobProperty Description;

            /// <summary>
            /// Serialize all field with ManagementObject
            /// </summary>
            /// <param name="mj"></param>
            /// <returns></returns>
            public _Device Serialize(WprManagementObject mj)
            {
                foreach (FieldInfo field in this.GetType().GetFields())
                    field.SetValue(this, mj.GetProperty(field.Name));

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
                        field.SetValue(this, mj.GetProperty(field.Name));

                return this;
            }

        }

        /// <summary>
        /// Get collection from wmi class 
        /// </summary>
        public abstract List<_Device> GetCollection();

        /// <summary>
        /// Get a selected Device from collection
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public abstract _Device GetCollection(String Device);

        /// <summary>
        /// Update collection from wmi class 
        /// </summary>
        public abstract void UpdateCollection();

        /// <summary>
        /// Update a single device in collection
        /// </summary>
        /// <param name="Device"></param>
        public abstract void UpdateCollection(String Device);

        /// <summary>
        /// Get a selected device form device list that primarykex field contien value
        /// </summary>
        /// <param name="Device"></param>
        public virtual _Device GetDevice(String Value)
        {

            foreach (_Device device in Devices)
            {
                string Key = (device.GetType().GetField(PrimaryKey).GetValue(device) as MobProperty).AsString();
                if (Key != null && Key.Equals(Value))
                    return device;
            }

            return null;
        }

        /// <summary>
        /// Update a single device from wmi class 
        /// </summary>
        public virtual void UpdateDevice(String DeviceName) { }

        public AbstractDevice()
        {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
        }
    }
}
