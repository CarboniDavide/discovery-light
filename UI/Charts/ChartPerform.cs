using DiscoveryLight.Core.Device.Utils;
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
        public static int? FillOrDefault(MobProperty Value)
        {
            return (Value == null || Value.IsNull) ? null : Value.AsInt32();
        }

        /// <summary>
        /// Return lambda value for param "Value",null elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static Int32? FillOrDefault(Func<MobProperty, dynamic> Lambda, MobProperty Value)
        {
            if (Value == null || Value.IsNull) return null;
            return Convert.ToInt32(Lambda.Invoke(Value));
        }
    }
}
