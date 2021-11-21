using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class CheckTableService
    {
        public static List<CheckTable> GetCheckTablelst(Expression<Func<CheckTable  ,bool>> func)
         {
            return  Connect.CreatConnect().Query<CheckTable>(func);
         }
        public static CheckTable GetOneCheckTable(Expression<Func<CheckTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<CheckTable>(func);
         }
        public static void InsertCheckTablelst(List<CheckTable> CheckTableObjs)
         {
            foreach(CheckTable OBJ in CheckTableObjs)
             {
              Connect.CreatConnect().Insert<CheckTable>(OBJ);
             }
         }
        public static void InsertCheckTable(CheckTable CheckTableObj)
         {
              Connect.CreatConnect().Insert<CheckTable>(CheckTableObj);
         }
        public static void UpdateCheckTable(CheckTable CheckTableObj,Expression<Func<CheckTable, bool>> func)
         {
              Connect.CreatConnect().Update<CheckTable>(CheckTableObj,func);
         }
        public static void DeleteCheckTable(Expression<Func<CheckTable, bool>> func)
         {
              Connect.CreatConnect().Delete<CheckTable>(func);
         }
    }
}
