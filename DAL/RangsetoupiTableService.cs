using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RangsetoupiTableService
    {
        public static List<RangsetoupiTable> GetRangsetoupiTablelst(Expression<Func<RangsetoupiTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RangsetoupiTable>(func);
         }
        public static RangsetoupiTable GetOneRangsetoupiTable(Expression<Func<RangsetoupiTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RangsetoupiTable>(func);
         }
        public static void InsertRangsetoupiTablelst(List<RangsetoupiTable> RangsetoupiTableObjs)
         {
            foreach(RangsetoupiTable OBJ in RangsetoupiTableObjs)
             {
              Connect.CreatConnect().Insert<RangsetoupiTable>(OBJ);
             }
         }
        public static void InsertRangsetoupiTable(RangsetoupiTable RangsetoupiTableObj)
         {
              Connect.CreatConnect().Insert<RangsetoupiTable>(RangsetoupiTableObj);
         }
        public static void UpdateRangsetoupiTable(RangsetoupiTable RangsetoupiTableObj,Expression<Func<RangsetoupiTable, bool>> func)
         {
              Connect.CreatConnect().Update<RangsetoupiTable>(RangsetoupiTableObj, func);
         }
        public static void DeleteRangsetoupiTable(Expression<Func<RangsetoupiTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RangsetoupiTable>(func);
         }
    }
}
