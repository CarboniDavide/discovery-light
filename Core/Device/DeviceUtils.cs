using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Logging;

namespace DiscoveryLight.Core.Device.Utils
{
    /// <summary>
    /// Manage ManagementObject's property
    /// </summary>
    public class MobProperty
    {
        private dynamic obj;
        public Boolean IsNull { get => (obj == null); }


        /// <summary>
        /// Get property value
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            return obj;
        }

        /// <summary>
        ///  Get a property value when property base is a array of items
        /// </summary>
        /// <param name="ArrayAt"></param>
        /// <returns></returns>
        public string AsArray(int ArrayAt)
        {
            if (obj == null) return null;                                     
            return (obj.GetType().IsArray) ? obj[ArrayAt] : null;                 
        }

        /// <summary>
        /// Get ManagementObject property as Int16
        /// </summary>
        /// <returns></returns>
        public int? AsInt()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : (int?)obj;
        }

        /// <summary>
        /// Get ManagementObject property as Int16
        /// </summary>
        /// <returns></returns>
        public Int16? AsInt16()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToInt16(obj);
        }

        /// <summary>
        /// Get ManagementObject property as Int32
        /// </summary>
        /// <returns></returns>
        public Int32? AsInt32()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToInt32(obj);
        }

        /// <summary>
        /// Get ManagementObject property as Int16
        /// </summary>
        /// <returns></returns>
        public Int64? AsInt64()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToInt64(obj);
        }

        /// <summary>
        /// Get ManagementObject property as UInt16
        /// </summary>
        /// <returns></returns>
        public UInt16? AsUInt16()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToUInt16(obj);
        }

        /// <summary>
        /// Get ManagementObject property as UInt32
        /// </summary>
        /// <returns></returns>
        public UInt32? AsUInt32()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToUInt32(obj);
        }

        /// <summary>
        /// Get ManagementObject property as UInt64
        /// </summary>
        /// <returns></returns>
        public UInt64? AsUInt64()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToUInt64(obj);
        }

        /// <summary>
        /// Get ManagementObject property as Double
        /// </summary>
        /// <returns></returns>
        public int? AsDouble()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToDouble(obj);
        }

        /// <summary>
        /// Get ManagementObject property as Decimal
        /// </summary>
        /// <returns></returns>
        public int? AsDecimal()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : Convert.ToDecimal(obj);
        }

        /// <summary>
        /// Get a substring from ManagementObject Property
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="Lenght"></param>
        /// <returns></returns>
        public string AsSubString(int StartIndex, int Lenght)
        {
            if (obj == null) return null;
            // check for array structure: nothing to do for unknow index
            return obj.GetType().IsArray ? null : obj.ToString().Substring(StartIndex, Lenght);
        }

        /// <summary>
        /// Return property value as String if exists, null elsewhere
        /// </summary>
        /// <returns></returns>
        public string AsString()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : obj.ToString();         // check for array structure: nothing to do for unknow index
        }

        public MobProperty(dynamic Obj)
        {
            obj = Obj;
        }
    }

    /// <summary>
    /// ManagementObject Wrapper
    /// </summary>
    public class WprManagementObject
    {
        private ManagementObject managementObject;

        /// <summary>
        /// Determines if ManagmentObject is null
        /// </summary>
        public Boolean IsNullObject { get => (managementObject == null);}

        public MobProperty GetProperty(string Name)
        {
            try
            {
                return new MobProperty(managementObject.GetPropertyValue(Name));
            }
            catch (System.Management.ManagementException exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            return new MobProperty(null); // not found 
        }

        /// <summary>
        /// Create a new Wrapper class for the selected ManagementObject
        /// </summary>
        /// <param name="ManagementObj"></param>
        public WprManagementObject(ManagementObject ManagementObj)
        {
            managementObject = ManagementObj;
        }

        /// <summary>
        /// Create a new Wrapper class for a null ManagementObject
        /// </summary>
        public WprManagementObject()
        {
            managementObject = null;
        }
    }

    /// <summary>
    /// ManagementObjectSearcher Wrapper
    /// </summary>
    public class WprManagementObjectSearcher
    {
        private string driveName;
        private readonly string PATH = "root\\CIMV2";      // base wmi namespace for each drive data

        /// <summary>
        /// Get a WprManagementObjectSearcher collection, elsewhere a empty list
        /// </summary>
        /// <returns></returns>
        public List<WprManagementObject> All()
        {
            return Get($"Select * from {driveName}");
        }


        /// <summary>
        /// Get the fisrt WprManagementObject item
        /// </summary>
        /// <returns></returns>
        public WprManagementObject First()
        {
            return Get($"Select * from {driveName}").FirstOrDefault();
        }

        /// <summary>
        /// Get the fisrt WprManagementObject item using a satandard WMI Query eg: select * from Win32_DiskDrive where Property = 'Value' 
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject First(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'").FirstOrDefault();
        }

        /// <summary>
        /// Get the fisrt WprManagementObject item that match the lambda condition
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject First(Func<WprManagementObject, Boolean> Condition)
        {
            return Get($"Select * from {driveName}").Where(Condition).FirstOrDefault();
        }

        /// <summary>
        /// Get the last WprManagementObject item using a satandard WMI Query eg: select * from Win32_DiskDrive where Property = 'Value'
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject Last(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'").LastOrDefault();
        }

        /// <summary>
        /// Get the last WprManagementObject item that match the lambda condition
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject Last(Func<WprManagementObject, bool> Condition)
        {
            return Get($"Select * from {driveName}").Where(Condition).LastOrDefault(); ;
        }

        /// <summary>
        /// Get a WprManagementObject collection using a satandard WMI Query eg: select * from Win32_DiskDrive where Property = 'Value'
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<WprManagementObject> Find(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'");
        }

        /// <summary>
        /// Get a WprManagementObject collection that match the lambda condition
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<WprManagementObject> Find(Func<WprManagementObject, bool> Condition)
        {
            return Get($"Select * from {driveName}").Where(Condition).ToList();
        }

        /// <summary>
        /// Get a WprManagementObject unique that match the condition
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject Unique(string Property, string Value, string Condition)
        {
            return new WprManagementObject(new ManagementObject($"{driveName}.{Property}{Condition}'{Value}'"));
        }

        private List<WprManagementObject> Get(string Query)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(PATH, Query);
            List<WprManagementObject> wprCollection = new List<WprManagementObject>();

            try
            {
                var collection = searcher.Get().Cast<ManagementObject>().ToList();
                wprCollection = collection.Select(x => new WprManagementObject(x)).ToList();
            }
            catch (System.Management.ManagementException exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }

            //release unmanaged resources
            searcher.Dispose();

            // return collection or null value for empty list
            return wprCollection;
        }

        /// <summary>
        /// Create a new Wrapper for thr ManagemetObjectSearcher for the seleced wmi class name
        /// </summary>
        /// <param name="Name"></param>
        public WprManagementObjectSearcher(string Name)
        {
            driveName = Name;
        }
    }
}
