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

        static public string Capture_Value(string property_name, ManagementObject obj)
        {
            // Find Value

            try
            {
                if (obj.Properties[property_name].Value != null)
                {
                    return obj.Properties[property_name].Value.ToString();
                }
                else
                {
                    return "N/A"; // return  null if the value is null
                }
            }
            catch { return "Not Found"; } // return not found in case of error
        }

        static public ManagementObjectSearcher Classe_Find(string name)
        {
            ManagementObjectSearcher obj = null;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(PATH, "select * from meta_class");

            foreach (ManagementClass wmiClass in searcher.Get())
                foreach (QualifierData qd in wmiClass.Qualifiers)
                    if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        if (wmiClass["__CLASS"].ToString() == name)
                            return obj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + name); // Object init with query values for the search               

            return null;
            /*
            try
            {
                obj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + name); // Object init with query values for the search       
                return obj;
            }
            catch
            {
                return null;
            }*/
        }

    }
}
