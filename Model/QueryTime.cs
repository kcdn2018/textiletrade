using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public   class QueryTime
    {
        public static int 间隔;
        public static int Digit;
        public static string IsTax=string.Empty ;
        public static string IsFabricStyle = string.Empty;
        public static string IsBuyStyle = string.Empty;
        public static int  Suolv = 100;
        public static string DanjubianhaoRule = "类型+年份+月份+日+累计编号";
        //业务员是否必填
        public static string IsNeedSaleMan = "否";
    }
}
