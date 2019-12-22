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
        ///  Get a property value when property base is a array of items
        /// </summary>
        /// <param name="ArrayAt"></param>
        /// <returns></returns>
        public String AsArray(int ArrayAt)
        {
            if (obj == null) return null;                                      // return "N/A" for null object
            return (obj.GetType().IsArray) ? obj[ArrayAt] : null;                // check for array type: return array items for array data string elesewhere    
        }

        /// <summary>
        /// Get a substring from ManagementObject Property
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="Lenght"></param>
        /// <returns></returns>
        public String AsSubString(int StartIndex, int Lenght)
        {
            if (obj == null) return null;
            // check for array structure: nothing to do for unknow index
            return obj.GetType().IsArray ? null : obj.ToString().Substring(StartIndex, Lenght);
        }

        /// <summary>
        /// Return property value as String if exists, null elsewhere
        /// </summary>
        /// <returns></returns>
        public String AsString()
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
        private readonly String PATH = "root\\CIMV2";      // base wmi namespace for each drive data

        /// <summary>
        /// Get a collection of WprManagementObjectSearcher, elsewhere a empty list
        /// </summary>
        /// <returns></returns>
        public List<WprManagementObject> All()
        {
            return Get($"Select * from {driveName}");
        }


        /// <summary>
        /// Get the fisrt items in collection of WprManagementObject
        /// </summary>
        /// <returns></returns>
        public WprManagementObject First()
        {
            var res = Get($"Select * from {driveName}");
            return res == null ? null : res.FirstOrDefault();
        }

        /// <summary>
        /// Get the fisrt item in collection of WprManagementObject that match the condition
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject First(string Property, string Value, string Condition)
        {
            var res = Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'");
            return res == null ? null : res.FirstOrDefault();
        }

        /// <summary>
        /// Get the fisrt item in collection of WprManagementObject that match the lambda condition
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject First(Func<WprManagementObject, Boolean> Condition)
        {
            List<WprManagementObject> res = Get($"Select * from {driveName}");

            return res == null ? null : res.Where(Condition).FirstOrDefault();
        }
         
        /// <summary>
        /// Get the last item in collection of WprManagementObject that match the condition
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject Last(string Property, string Value, string Condition)
        {
            var res = Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'");
            return res == null ? null : res.LastOrDefault();
        }

        /// <summary>
        /// Get the last item in collection of WprManagementObject that match the condition
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Value"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public WprManagementObject Last(Func<WprManagementObject, Boolean> Condition)
        {
            List<WprManagementObject> res = Get($"Select * from {driveName}");

            return res == null ? null : res.Where(Condition).LastOrDefault();
        }

        /// <summary>
        /// Get a collection of WprManagementObject that match the lambda condition
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<WprManagementObject> Find(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'");
        }

        /// <summary>
        /// Get a collection of WprManagementObject that match the lambda condition
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<WprManagementObject> Find(Func<WprManagementObject, Boolean> Condition)
        {
            List<WprManagementObject> res = new List<WprManagementObject>();

            res = Get($"Select * from {driveName}").Where(Condition).ToList();

            return res.Count == 0 ? null : res;
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
            return wprCollection.Count == 0 ? null: wprCollection;
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
