using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class DengJiNameTableService
    {
        public static List<DengJiNameTable> GetDengJiNameTablelst(Expression<Func<DengJiNameTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<DengJiNameTable>(func);
         }
        public static DengJiNameTable GetOneDengJiNameTable(Expression<Func<DengJiNameTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<DengJiNameTable>(func);
         }
        public static void InsertDengJiNameTablelst(List<DengJiNameTable> DengJiNameTableObjs)
         {
            foreach(DengJiNameTable OBJ in DengJiNameTableObjs)
             {
              Connect.CreatConnect().Insert<DengJiNameTable>(OBJ);
             }
         }
        public static void InsertDengJiNameTable(DengJiNameTable DengJiNameTableObj)
         {
              Connect.CreatConnect().Insert<DengJiNameTable>(DengJiNameTableObj);
         }
        public static void UpdateDengJiNameTable(DengJiNameTable DengJiNameTableObj,Expression<Func<DengJiNameTable, bool>> func)
         {
              Connect.CreatConnect().Update<DengJiNameTable>(DengJiNameTableObj, func);
         }
        public static void DeleteDengJiNameTable(Expression<Func<DengJiNameTable, bool>> func)
         {
              Connect.CreatConnect().Delete<DengJiNameTable>(func);
         }
    }
}
