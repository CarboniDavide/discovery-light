using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device
{
    public interface IPreUpdate
    {
        /// <summary>
        /// Use Pre load method before update
        /// </summary>
        void PreUpdate();

        /// <summary>
        /// Check if a update has been performed
        /// </summary>
        Boolean IsUpdated { get; set; }
    }

    public interface IRelatable
    {
        /// <summary>
        /// Convert property before update
        /// </summary>
        String GetRelatedDevice();

        /// <summary>
        /// Check if a conversion has been performed
        /// </summary>
        Boolean IsRelated { get; set; }

        /// <summary>
        /// Store the value to convert
        /// </summary>
        String DevicetoToRelate { get; set; }

        /// <summary>
        /// Store the value to convert
        /// </summary>
        String DeviceRelated { get; set; }
    }

    public abstract class AbstractDevice
    {
        protected readonly string deviceName;
        protected readonly string className;
        protected readonly Type classType;
        private int deviceNumber = 0;                               // number of device for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_SubDevice> devices = new List<_SubDevice>();        // List of properties for each device           
        private Boolean isNull;                                     // Check for null WprManagementObjec
        private String primaryKey;                                  // define entry key in _Device for search items

        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public string DeviceName { get => deviceName; }
        public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }
        public List<_SubDevice> Devices { get { return devices; } set { devices = value; DeviceNumber = value.Count; } }
        public bool IsNull { get => isNull; set => isNull = value; }
        public string PrimaryKey { get => primaryKey; set => primaryKey = value; }

        /// <summary>
        /// Get collection from wmi class 
        /// </summary>
        public abstract List<_SubDevice> GetCollection();

        /// <summary>
        /// Get a selected Device from collection
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public abstract List<_SubDevice> GetCollection(String FieldName, String Value);

        /// <summary>
        /// Get a single sub device using primary key as default
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public abstract List<_SubDevice> GetCollection(String Value);

        /// <summary>
        /// Update collection from wmi class 
        /// </summary>
        public abstract void UpdateCollection();

        /// <summary>
        /// Update a single sub device using field name and it value
        /// </summary>
        /// <param name="Device"></param>
        public abstract void UpdateCollection(String FieldName, String Value);

        /// <summary>
        /// Update a single sub device using primary key as default field
        /// </summary>
        /// <param name="Value"></param>
        public abstract void UpdateCollection(String Value);

        /// <summary>
        /// Get a selected device form device list that primarykey field contien value
        /// </summary>
        /// <param name="Device"></param>
        public virtual _SubDevice GetDevice(String Value)
        {

            foreach (_SubDevice device in Devices)
            {
                try
                {
                    string Key = (device.GetType().GetField(PrimaryKey).GetValue(device) as MobProperty).AsString();
                    if (Key != null && Key.Equals(Value))
                        return device;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Get a selected device form device list where key field contien value
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public virtual _SubDevice GetDevice(String Field, String Value)
        {
            foreach (_SubDevice device in Devices)
            {
                try
                {
                    string Key = (device.GetType().GetField(Field).GetValue(device) as MobProperty).AsString();
                    if (Key != null && Key.Equals(Value))
                        return device;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Get a selected device form device list that primarykey field contien value / convert device name if implemented
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="GetRelated"></param>
        /// <returns></returns>
        public virtual _SubDevice GetDevice(String Field, Boolean GetRelated) { return null; }

        /// <summary>
        /// Get a selected device form device list where key field contien value / convert device name if implemented
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        /// <param name="GetRelated"></param>
        /// <returns></returns>
        public virtual _SubDevice GetDevice(String Field, String Value, Boolean GetRelated) { return null; }

        /// <summary>
        /// Update a single device from wmi class 
        /// </summary>
        public virtual void UpdateDevice(String DeviceName) { }

        /// <summary>
        /// Get Collection from WprManagementObject
        /// </summary>
        public List<WprManagementObject> WmiCollection
        {
            get
            {
                var res = new WprManagementObjectSearcher(deviceName).All();
                IsNull = (res == null);
                return res ?? new List<WprManagementObject>() { new WprManagementObject() };
            }
        }

        public AbstractDevice()
        {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
        }

        public AbstractDevice(String DeviceName)
        {
            this.className = this.GetType().Name;
            this.classType = this.GetType();
            this.deviceName = DeviceName;
        }
    }

    public class _Device: AbstractDevice
    {
        public override List<_SubDevice> GetCollection() { return new List<_SubDevice>(); }

        public override List<_SubDevice> GetCollection(String FieldName, String Value) { return new List<_SubDevice>(); }

        public override List<_SubDevice> GetCollection(String Value) { return GetCollection(PrimaryKey, Value); }

        public override void UpdateCollection() { Devices = GetCollection(); }

        public override void UpdateCollection(String FieldName, String Value) { Devices = GetCollection(FieldName, Value); }

        public override void UpdateCollection(String Value) { Devices = GetCollection(PrimaryKey, Value); }

        public _Device(String DeviceName): base(DeviceName) { }
    }

    public class _SubDevice
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
        public _SubDevice Serialize(WprManagementObject mj)
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
        public _SubDevice Serialize(WprManagementObject mj, List<String> Fields)
        {
            foreach (FieldInfo field in this.GetType().GetFields())
                if (Fields.Contains(field.Name))
                    field.SetValue(this, mj.GetProperty(field.Name));
            return this;
        }

        /// <summary>
        /// Serialize all field with ManagementObject only for the specified fields using a custom field destination
        /// </summary>
        /// <param name="mj"></param>
        /// <param name="ConvertAs"></param>
        /// <returns></returns>
        public _SubDevice Serialize(WprManagementObject mj, Dictionary<string, string> ConvertAs)
        {
            foreach (FieldInfo field in this.GetType().GetFields())
                if (ConvertAs.ContainsKey(field.Name))
                    field.SetValue(this, mj.GetProperty(ConvertAs[field.Name]));
            return this;
        }

        /// <summary>
        /// Extend sub device field that are not available in WprManagementObject
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public virtual _SubDevice Extend(dynamic Obj) { return this; }

        /// <summary>
        /// Extend sub device field that are not available in WprManagementObject
        /// </summary>
        /// <returns></returns>
        public virtual _SubDevice Extend() { return this; }
    }
}
