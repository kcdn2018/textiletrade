using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class AccessTableService
    {
        public static List<AccessTable> GetAccessTablelst(Expression<Func<AccessTable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<AccessTable>(func);
         }
        public static List<AccessTable> GetAccessTablelst()
        {
            return Connect.CreatConnect().Query<AccessTable>();
        }
        public static AccessTable GetOneAccessTable(Expression<Func<AccessTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<AccessTable>(func);
         }
        public static void InsertAccessTablelst(List<AccessTable> AccessTableObjs)
         {
              Connect.CreatConnect().Insert<AccessTable>(AccessTableObjs);
         }
        public static void InsertAccessTable(AccessTable AccessTableObj)
         {
              Connect.CreatConnect().Insert<AccessTable>(AccessTableObj);
         }
        public static void UpdateAccessTable(AccessTable AccessTableObj, Expression<Func<AccessTable, bool>> func)
         {
              Connect.CreatConnect().Update<AccessTable>(AccessTableObj,func);
         }
        public static void DeleteAccessTable(Expression<Func<AccessTable, bool>> func)
         {
              Connect.CreatConnect().Delete<AccessTable>(func);
         }
    }
}
