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
        public static void  GetUserAccess(string userid)
        {
            AccessList=Connect.CreatConnect().Query<AccessTable>(x=>x.UserID==userid );
        }
    }
}
