using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Logging;

namespace DiscoveryLight.Core.Device.Utils
{
    public class MobProperty
    {
        private dynamic obj;

        /// <summary>
        /// Get a property value when property base is a array of values
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="obj"></param>
        /// <param name="ArrayAt"></param>
        /// <returns></returns>
        public dynamic AsArray(int ArrayAt)
        {
            if (obj == null) return null;                                      // return "N/A" for null object
            return (obj.GetType().IsArray) ? obj[ArrayAt] : null;                // check for array type: return array items for array data string elesewhere    
        }

        /// <summary>
        /// Get a substring for a selected property
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="obj"></param>
        /// <param name="StartIndex"></param>
        /// <param name="Lenght"></param>
        /// <returns></returns>
        public dynamic AsSubString(int StartIndex, int Lenght)
        {
            if (obj == null) return null;
            // check for array structure: nothing to do for unknow index
            return obj.GetType().IsArray ? null : obj.ToString().Substring(StartIndex, Lenght);
        }

        /// <summary>
        /// Return property value or array of values if exists N/A elsewhere
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public dynamic AsString()
        {
            if (obj == null) return obj;
            return (obj.GetType().IsArray) ? null : obj.ToString();         // check for array structure: nothing to do for unknow index
        }

        public MobProperty(dynamic Obj)
        {
            obj = Obj;
        }
    }

    public class WprManagementObject: IDisposable
    {
        public void Dispose() {
            this.Dispose();
        }

        private ManagementObject managementObject;

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


        public WprManagementObject(ManagementObject ManagementObj)
        {
            managementObject = ManagementObj;
        }
    }

    public class WprManagementObjectSearcher
    {
        private string driveName;
        private readonly String PATH = "root\\CIMV2";      // base wmi namespace for each drive data

        public List<WprManagementObject> All()
        {
            return Get($"Select * from {driveName}");
        }

        public List<WprManagementObject> Find(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'");
        }

        public WprManagementObject First(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'").FirstOrDefault();
        }

        public WprManagementObject First()
        {
            return Get($"Select * from {driveName}").FirstOrDefault();
        }

        public WprManagementObject Last(string Property, string Value, string Condition)
        {
            return Get($"Select * from {driveName} Where {Property} {Condition} '{Value}'").LastOrDefault();
        }

        public WprManagementObject Unique(string Property, string Value, string Condition)
        {
            return new WprManagementObject(new ManagementObject($"{driveName}.{Property}{Condition}'{Value}'"));
        }

        private List<WprManagementObject> Get(string Query)
        {
            try
            {
                // get all drive informaton from a selected one
                var collection = new ManagementObjectSearcher(PATH, Query);
                var res = collection.Get().Cast<ManagementObject>().ToList();
                collection.Dispose();
                return res.Select(x => new WprManagementObject(x)).Cast<WprManagementObject>().ToList();
            }
            catch (System.Management.ManagementException exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }

            // return empty list for any problems
            return new List<WprManagementObject>();
        }

        public WprManagementObjectSearcher(string Name)
        {
            driveName = Name;
        }
    }
}
