using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class LeibieTableService
    {
        public static List<LeibieTable> GetLeibieTablelst(Expression<Func<LeibieTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<LeibieTable>(func);
         }
        public static LeibieTable GetOneLeibieTable(Expression<Func<LeibieTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LeibieTable>(func);
         }
        public static void InsertLeibieTablelst(List<LeibieTable> LeibieTableObjs)
         {
            foreach(LeibieTable OBJ in LeibieTableObjs)
             {
              Connect.CreatConnect().Insert<LeibieTable>(OBJ);
             }
         }
        public static void InsertLeibieTable(LeibieTable LeibieTableObj)
         {
              Connect.CreatConnect().Insert<LeibieTable>(LeibieTableObj);
         }
        public static void UpdateLeibieTable(LeibieTable LeibieTableObj,Expression<Func<LeibieTable, bool>> func)
         {
              Connect.CreatConnect().Update<LeibieTable>(LeibieTableObj, func);
         }
        public static void DeleteLeibieTable(Expression<Func<LeibieTable, bool>> func)
         {
              Connect.CreatConnect().Delete<LeibieTable>(func);
         }
    }
}
