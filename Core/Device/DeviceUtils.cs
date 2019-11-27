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
        public enum ReturnType
        {
            String, UInt64
        }

        public enum Operator
        {
            Egual,
            NotEgual
        }

        /// <summary>
        /// Get a property value from a selected wmi class
        /// </summary>
        /// <param name="property_name"></param>
        /// <param name="obj"></param>
        /// <param name="returnAs"></param>
        /// <returns></returns>
        static public dynamic GetProperty(string property_name, ManagementObject obj, ReturnType returnAs)
        {
            try{
                if (returnAs == ReturnType.String)
                    return obj[property_name].ToString();                    // return value as string
                else
                    return Convert.ToUInt64(obj[property_name]);             // return value as integer
            }
            catch (System.Management.ManagementException exception){
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception){
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
                    if ( (comp == Operator.NotEgual) && (GetProperty(property, mj, ReturnType.String) != value) )
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
