using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RukuTableService
    {
        public static List<RukuTable> GetRukuTablelst(Expression<Func<RukuTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RukuTable>(func);
         }
        public static List<RukuTable> GetRukuTablelst()
        {
            return Connect.CreatConnect().Query<RukuTable>();
        }
        public static RukuTable GetOneRukuTable(Expression<Func<RukuTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RukuTable>(func);
         }
        public static void InsertRukuTablelst(List<RukuTable> RukuTableObjs)
         {
            foreach(RukuTable OBJ in RukuTableObjs)
             {
              Connect.CreatConnect().Insert<RukuTable>(OBJ);
             }
         }
        public static void InsertRukuTable(RukuTable RukuTableObj)
         {
              Connect.CreatConnect().Insert<RukuTable>(RukuTableObj);
         }
        public static void UpdateRukuTable(RukuTable RukuTableObj,Expression<Func<RukuTable, bool>> func)
         {
              Connect.CreatConnect().Update<RukuTable>(RukuTableObj, func);
         }
        public static void DeleteRukuTable(Expression<Func<RukuTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RukuTable>(func);
         }
        public static void DeleteRukuTable(string sql)
        {
            Connect.CreatConnect().Delete(sql);
        }
    }
}
