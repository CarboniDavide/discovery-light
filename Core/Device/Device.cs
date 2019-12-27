using DiscoveryLight.Core.Device.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        private int deviceNumber = 0;                                       // number of device for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_SubDevice> subDevices = new List<_SubDevice>();       // List of properties for each device           
        private Boolean isEmpty;                                             // Check for null WprManagementObjec
        private String primaryKey;                                          // define entry key in _Device for search items

        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public string DeviceName { get => deviceName; }
        public int DeviceNumber { get => deviceNumber; set => deviceNumber = value; }
        public List<_SubDevice> SubDevices { get { return subDevices; } set { subDevices = value; DeviceNumber = value.Count; } }
        public bool IsEmpty { get { return subDevices.Count == 0; } set { isEmpty = value; } }
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
        /// Get wpr collection that match the condition (lambda expression)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract List<_SubDevice> GetCollection(Func<_SubDevice, Boolean> condition);

        /// <summary>
        /// get a wpr collection that match the condition
        /// </summary>
        /// <param name="condtion"></param>
        /// <returns></returns>
        public abstract List<_SubDevice> GetCollection(Func<WprManagementObject, Boolean> condtion);

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
        /// Update a collection that mach the lambda condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract void UpdateCollection(Func<_SubDevice, Boolean> condition);

        /// <summary>
        /// Update a collection that mach the lambda condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract void UpdateCollection(Func<WprManagementObject, Boolean> condition);

        /// <summary>
        /// Get a selected device form device list that primarykey field contien value
        /// </summary>
        /// <param name="Device"></param>
        public virtual _SubDevice GetDevice(String Value)
        {

            foreach (_SubDevice device in SubDevices)
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
            foreach (_SubDevice device in SubDevices)
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
        /// Get a sub device using lambda expression
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual _SubDevice GetDevice(Func<_SubDevice, Boolean> condition)
        {
            return SubDevices.Where(condition).FirstOrDefault();
        }

        /// <summary>
        /// Get Collection from WprManagementObject
        /// </summary>
        public WprManagementObjectSearcher WmiCollection
        {
            get
            {
                return new WprManagementObjectSearcher(deviceName);
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

    public class _Device : AbstractDevice
    {
        public override List<_SubDevice> GetCollection() {
            return WmiCollection.All()
                .Select(x => (Activator.CreateInstance(Type.GetType(ClassType.FullName + "+SubDevice")) as _SubDevice).Serialize(x))
                .ToList();
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value) {
            return WmiCollection.Find(FieldName, Value, "=")
                .Select(x => (Activator.CreateInstance(Type.GetType(ClassType.FullName + "+SubDevice")) as _SubDevice).Serialize(x))
                .ToList();
        }

        public override List<_SubDevice> GetCollection(String Value) {
            return GetCollection(PrimaryKey, Value);
        }

        public override List<_SubDevice> GetCollection(Func<_SubDevice, Boolean> condition) {
            return WmiCollection.All()
                .Select(x => (Activator.CreateInstance(Type.GetType(ClassType.FullName + "+SubDevice")) as _SubDevice).Serialize(x))
                .Where(condition)
                .ToList();
        }

        public override List<_SubDevice> GetCollection(Func<WprManagementObject, Boolean> condition)
        {
            return WmiCollection.All()
                .Where(condition)
                .Select(x => (Activator.CreateInstance(Type.GetType(ClassType.FullName + "+SubDevice")) as _SubDevice).Serialize(x))
                .ToList();
        }

        public override void UpdateCollection() { SubDevices = GetCollection(); }

        public override void UpdateCollection(String FieldName, String Value) { SubDevices = GetCollection(FieldName, Value); }

        public override void UpdateCollection(String Value) { SubDevices = GetCollection(PrimaryKey, Value); }

        public override void UpdateCollection(Func<_SubDevice, Boolean> condition) { SubDevices = GetCollection(condition); }

        public override void UpdateCollection(Func<WprManagementObject, Boolean> condition) { SubDevices = GetCollection(condition); }

        public _Device(String DeviceName) : base(DeviceName) { }
    }

    public class _SubDevice
    {
        public MobProperty DeviceID;
        public MobProperty Name;
        public MobProperty Caption;
        public MobProperty Description;

        /// <summary>
        /// Initialize all field with a empty MobProperty
        /// </summary>
        /// <param name="mj"></param>
        /// <returns></returns>
        public _SubDevice Initialize()
        {
            foreach (FieldInfo field in this.GetType().GetFields())
                field.SetValue(this, new MobProperty(null));
            return this;
        }

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
