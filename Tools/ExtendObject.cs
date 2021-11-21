using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class ExtendObject
    {
        /// <summary>
        /// 将object强制转化为int
        /// </summary>
        /// <param name="o">要强制转换的object</param>
        /// <param name="defaultValue">o为null或者转换失败的默认值</param>
        /// <returns></returns>
        public static int TryToInt(this object o, int defaultValue = 0)
        {
            int retValue;
            //o为null 或者转换失败返回默认值
            retValue = o == null || !int.TryParse(o.ToString(), out retValue) ? defaultValue : retValue;
            return retValue;
        }
        /// <summary>
        /// 将object强制转化为int
        /// </summary>
        /// <param name="o">要强制转换的object</param>
        /// <param name="defaultValue">o为null或者转换失败的默认值</param>
        /// <returns></returns>
        public static decimal TryToDecmial(this object o, decimal defaultValue = 0)
        {
            decimal retValue;
            //o为null 或者转换失败返回默认值
            retValue = o == null || !decimal.TryParse(o.ToString(), out retValue) ? defaultValue : retValue;
            return retValue;
        }
        /// <summary>
        /// 将object强制转化为int
        /// </summary>
        /// <param name="o">要强制转换的object</param>
        /// <param name="defaultValue">o为null或者转换失败的默认值</param>
        /// <returns></returns>
        public static Boolean TryToBoolean(this object o, Boolean defaultValue = true)
        {
            Boolean retValue;
            //o为null 或者转换失败返回默认值
            retValue = o == null || !Boolean.TryParse(o.ToString(), out retValue) ? defaultValue : retValue;
            return retValue;
        }
    }
}
