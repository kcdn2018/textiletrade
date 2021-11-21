using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RemainMoneyTableService
    {
        public static List<RemainMoneyTable> GetRemainMoneyTablelst(Expression<Func<RemainMoneyTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RemainMoneyTable>(func);
         }
        public static RemainMoneyTable GetOneRemainMoneyTable(Expression<Func<RemainMoneyTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RemainMoneyTable>(func);
         }
        public static void InsertRemainMoneyTablelst(List<RemainMoneyTable> RemainMoneyTableObjs)
         {
            foreach(RemainMoneyTable OBJ in RemainMoneyTableObjs)
             {
              Connect.CreatConnect().Insert<RemainMoneyTable>(OBJ);
             }
         }
        public static void InsertRemainMoneyTable(RemainMoneyTable RemainMoneyTableObj)
         {
              Connect.CreatConnect().Insert<RemainMoneyTable>(RemainMoneyTableObj);
         }
        public static void UpdateRemainMoneyTable(RemainMoneyTable RemainMoneyTableObj,Expression<Func<RemainMoneyTable, bool>> func)
         {
              Connect.CreatConnect().Update<RemainMoneyTable>(RemainMoneyTableObj, func);
         }
        public static void UpdateRemainMoneyTable(string UpdateString, Expression<Func<RemainMoneyTable, bool>> func)
        {
            Connect.CreatConnect().Update<RemainMoneyTable>(UpdateString , func);
        }
        public static void DeleteRemainMoneyTable(Expression<Func<RemainMoneyTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RemainMoneyTable>(func);
         }
    }
}
