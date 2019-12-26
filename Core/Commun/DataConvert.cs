using DiscoveryLight.Core.Device.Utils;
using System;

namespace DiscoveryLight.Core.Commun
{
    public static class MobPropertyDataConvert
    {
        /// <summary>
        /// Return passed "Value", "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(MobProperty Value, String Default)
        {
            return (Value == null || Value.IsNull) ? Default : Value.AsString();
        }

        /// <summary>
        /// Return passed "Value" with the specified format, "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(MobProperty Value, String Default, String Format)
        {
            return (Value == null || Value.IsNull) ? Default : string.Format(Format, Convert.ToDouble(Value.Get()));
        }

        /// <summary>
        /// Return lambda value for param "Value", "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(Func<MobProperty, dynamic> Lambda, MobProperty Value, String Default)
        {
            return (Value == null || Value.IsNull) ? Default : Lambda.Invoke(Value).ToString();
        }



        /// <summary>
        /// Return a lambda value for param "Value" with the specified string format, "Default" string elsewhere
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        public static String AsDefaultValue(Func<MobProperty, dynamic> Function, MobProperty Value, String Default, String Format)
        {
            return (Value == null || Value.IsNull) ? Default : string.Format(Format, Convert.ToDouble(Function.Invoke(Value)));
        }


    }

    public static class MobPropertyChartConvert
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
