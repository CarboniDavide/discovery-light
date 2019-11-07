using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Logging;

namespace DiscoveryLight.Core
{
    static class ComponentsUtils
    {
        static readonly String PATH = "root\\CIMV2";
        static public UInt64 Capture_Number(string property_name, ManagementObject obj)
        {
            // Find Value

            try
            {
                if (obj.Properties[property_name].Value != null)
                {
                    return Convert.ToUInt64(obj.Properties[property_name].Value);
                }
                else
                {
                    return 0; // return  0 if the value is null
                }
            }
            catch { return 0; } // return 0 found in case of error
        }

        static public string GetProperty(string property_name, ManagementObject obj)
        {
            try{
                return obj[property_name].ToString(); // return value or null if not exists
            }
            catch (System.Management.ManagementException exception){
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            catch (Exception exception){
                LogHelper.Log(LogTarget.File, exception.ToString());
            }
            return null; // not found 
        }

        static public List<ManagementObject> GetDriveInfo(string drive)
        {
            try{
                ManagementObjectSearcher collection;
                List<ManagementObject> res;
                // get all drive informaton from a selected one
                collection = new ManagementObjectSearcher(PATH, "select * from " + drive);
                res = collection.Get().Cast<ManagementObject>().ToList();
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

        static public List<ManagementObject> GetDriveInfo(string drive, string property, string value)
        {
            try
            {
                ManagementObjectSearcher collection;
                List<ManagementObject> res = new List<ManagementObject>();
                // get all drive informaton from a selected one
                collection = new ManagementObjectSearcher(PATH, "Select * From " + drive);
                foreach(ManagementObject mj in collection.Get().Cast<ManagementObject>().ToList()){
                    if (mj[property].ToString().Equals(value))
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
