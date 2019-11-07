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
        static public readonly String PATH = "root\\CIMV2";
        public enum ReturnType
        {
            String, UInt64
        }

        public enum Operator
        {
            Egual,
            NotEgual
        }

        static public dynamic GetProperty(string property_name, ManagementObject obj, ReturnType returnAs)
        {
            try{
                if (returnAs == ReturnType.String)
                    return obj[property_name].ToString();
                else
                    return Convert.ToUInt64(obj[property_name]);
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

        static public List<ManagementObject> GetDriveInfo(string drive, string property, string value, Operator comp)
        {
            try
            {
                ManagementObjectSearcher collection;
                List<ManagementObject> res = new List<ManagementObject>();
                // get all drive informaton from a selected one
                collection = new ManagementObjectSearcher(PATH, "Select * From " + drive);
                foreach(ManagementObject mj in collection.Get().Cast<ManagementObject>().ToList()){
                    if ( ( comp == Operator.Egual) && (mj[property].ToString().Equals(value)) )
                        res.Add(mj);
                    if ( (comp == Operator.NotEgual) && !(mj[property].ToString().Equals(value)) )
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
