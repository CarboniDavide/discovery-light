using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Logging;

namespace DiscoveryLight.Core.Device.Utils
{
    static class DeviceUtils
    {
        static public readonly String PATH = "root\\CIMV2";      // base wmi namespace for each drive data

        public enum Operator
        {
            Egual,
            NotEgual
        }

        public static class GetProperty
        {
            /// <summary>
            /// Get a property value when property base is a array of values
            /// </summary>
            /// <param name="property_name"></param>
            /// <param name="obj"></param>
            /// <param name="ArrayAt"></param>
            /// <returns></returns>
            public static dynamic AsArray(string property_name, ManagementObject obj, int ArrayAt)
            {
                dynamic res = Get(property_name, obj);
                if (res == null) return null;                                      // return "N/A" for null object
                return (res.GetType().IsArray) ? res[ArrayAt] : null;                // check for array type: return array items for array data string elesewhere    
            }

            /// <summary>
            /// Get a substring for a selected property
            /// </summary>
            /// <param name="property_name"></param>
            /// <param name="obj"></param>
            /// <param name="StartIndex"></param>
            /// <param name="Lenght"></param>
            /// <returns></returns>
            public static dynamic AsSubString(string property_name, ManagementObject obj, int StartIndex, int Lenght)
            {
                String res = Get(property_name, obj);
                if (res == null) return null;
                // check for array structure: nothing to do for unknow index
                return  res.GetType().IsArray ? null : res.Substring(StartIndex, Lenght);
            }

            /// <summary>
            /// Return property value or array of values if exists N/A elsewhere
            /// </summary>
            /// <param name="property_name"></param>
            /// <param name="obj"></param>
            /// <returns></returns>
            static public dynamic AsString(string property_name, ManagementObject obj)
            {
                var res = Get(property_name, obj);
                if (res == null) return res;
                return (res.GetType().IsArray) ? null : res;        // check for array structure: nothing to do for unknow index
            }
        }
       

        /// <summary>
        /// Get Property values from a selected Wmi class object
        /// </summary>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static dynamic Get(string property, ManagementObject obj)
        {
            try
            {
                if (obj[property].GetType().IsArray)
                    return obj[property];
                else
                    return obj[property].ToString();                    // return value as string
            }
            catch (System.Management.ManagementException exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception)
            {
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            return null; // not found 
        }

        /// <summary>
        /// Get all informations for a selected drive
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        static public List<ManagementObject> GetDriveInfo(string drive)
        {
            try{
                // get all drive informaton from a selected one
                var collection = new ManagementObjectSearcher(PATH, "select * from " + drive);
                var res = collection.Get().Cast<ManagementObject>().ToList();
                collection.Dispose();
                return res;
            }
            catch (System.Management.ManagementException exception){
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception){
                LogHelper.Log(LogTarget.File, exception.ToString());
            }

            // return empty list for any problems
            return new List<ManagementObject>(); 
        }

        /// <summary>
        /// Get a single information from the drive informations(collection)
        /// </summary>
        /// <param name="drive"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        static public List<ManagementObject> GetDriveInfo(string drive, string property, string value, Operator comp)
        {
            try
            {
                var res = new List<ManagementObject>();
                // get all collection from drive
                var collection = new ManagementObjectSearcher(PATH, "Select * From " + drive);

                // get a sub information from the collection
                foreach(ManagementObject mj in collection.Get().Cast<ManagementObject>().ToList()){
                    if ( ( comp == Operator.Egual) && (mj[property].ToString().Equals(value)) )
                        res.Add(mj);
                    if ( (comp == Operator.NotEgual) && (GetProperty.AsString(property, mj) != value) )
                        res.Add(mj);
                }
                collection.Dispose();
                return res;
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
            return new List<ManagementObject>();
        }

    }
}
