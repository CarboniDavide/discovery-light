using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

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
                return obj[property_name] != null ? obj[property_name].ToString() : "N/A";
            }
            catch { 
                return "Not Found"; 
            } 
        }

        static public List<ManagementObject> GetDriveInfo(string drive)
        {
            try
            {
                // get all drive informaton from a selected one
                ManagementObjectSearcher collection;
                List<ManagementObject> res;
                collection = new ManagementObjectSearcher(PATH, "select * from " + drive);
                res = collection.Get().Cast<ManagementObject>().ToList();
                collection.Dispose();
                return res;
            }
            catch
            {
                return new List<ManagementObject>();
            }
        }

    }
}
