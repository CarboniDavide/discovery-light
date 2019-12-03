using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformComponents;

namespace DiscoveryLight.UI.Charts
{
    public static class ChartPerform
    {
        /// <summary>
        /// Return passed "Value", null elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static int? FillOrDefault(String Value)
        {
            if (Value == null) return null;
            return Convert.ToInt32(Value);
        }

        /// <summary>
        /// Return passed "Value", null elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static int? FillOrDefault(int? Value)
        {
            if (Value == null) return null;
            return Value;
        }

        /// <summary>
        /// Return lambda value for param "Value",null elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static int? FillOrDefault(Func<String, int?> Lambda, String Value)
        {
            if (Value == null) return null;
            return Convert.ToInt32(Lambda.Invoke(Value));
        }

        /// <summary>
        /// Return lambda value for param "Value", null elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static int? FillOrDefault(Func<int?, int?> Lambda, int? Value)
        {
            if (Value == null) return null;
            return Lambda.Invoke(Value);
        }

    }
}
