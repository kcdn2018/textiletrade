using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RangShequpiTableService
    {
        public static List<RangShequpiTable> GetRangShequpiTablelst(Expression<Func<RangShequpiTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RangShequpiTable>(func);
         }
        public static RangShequpiTable GetOneRangShequpiTable(Expression<Func<RangShequpiTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RangShequpiTable>(func);
         }
        public static void InsertRangShequpiTablelst(List<RangShequpiTable> RangShequpiTableObjs)
         {       
              Connect.CreatConnect().Insert<RangShequpiTable>(RangShequpiTableObjs);
         }
        public static void InsertRangShequpiTable(RangShequpiTable RangShequpiTableObj)
         {
              Connect.CreatConnect().Insert<RangShequpiTable>(RangShequpiTableObj);
         }
        public static void UpdateRangShequpiTable(RangShequpiTable RangShequpiTableObj,Expression<Func<RangShequpiTable, bool>> func)
         {
              Connect.CreatConnect().Update<RangShequpiTable>(RangShequpiTableObj, func);
         }
        public static void DeleteRangShequpiTable(Expression<Func<RangShequpiTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RangShequpiTable>(func);
         }
    }
}
