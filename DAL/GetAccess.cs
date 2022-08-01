using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace DAL
{
  public static   class GetAccess
    {
        public static List<AccessTable> AccessList = new List<AccessTable>();
        /// <summary>
        /// 是否可以打印编辑
        /// </summary>
        public static Boolean IsCanPrintDesign = true;
        public static void  GetUserAccess(string userid)
        {
            AccessList=Connect.CreatConnect().Query<AccessTable>(x=>x.UserID==userid );
        }
    }
}
