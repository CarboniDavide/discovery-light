using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.Core.Commun
{
    public static class DataConvert
    {
        /// <summary>
        /// Return passed "Value", "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(String Value, String Default)
        {
            return Value == null ? Default : Value.ToString();
        }

        /// <summary>
        /// Return passed "Value" with the specified format, "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(String Value, String Default, String Format)
        {
            return Value == null ? Default : string.Format(Format, Convert.ToDouble(Value));
        }

        /// <summary>
        /// Return lambda value for param "Value", "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(Func<String, String> Lambda, String Value, String Default)
        {
            return Value == null ? Default : Lambda.Invoke(Value);
        }

       

        /// <summary>
        /// Return a lambda value for param "Value" with the specified string format, "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(Func<String, String> Function, String Value, String Default, String Format)
        {
            return Value == null ? Default : string.Format(Format, Convert.ToDouble(Function.Invoke(Value)));
        }


    }
}
