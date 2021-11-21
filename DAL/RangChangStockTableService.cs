using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RangChangStockTableService
    {
        public static List<RangChangStockTable> GetRangChangStockTablelst(Expression<Func<RangChangStockTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RangChangStockTable>(func);
         }
        public static RangChangStockTable GetOneRangChangStockTable(Expression<Func<RangChangStockTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RangChangStockTable>(func);
         }
        public static void InsertRangChangStockTablelst(List<RangChangStockTable> RangChangStockTableObjs)
         {
            foreach(RangChangStockTable OBJ in RangChangStockTableObjs)
             {
              Connect.CreatConnect().Insert<RangChangStockTable>(OBJ);
             }
         }
        public static void InsertRangChangStockTable(RangChangStockTable RangChangStockTableObj)
         {
              Connect.CreatConnect().Insert<RangChangStockTable>(RangChangStockTableObj);
         }
        public static void UpdateRangChangStockTable(RangChangStockTable RangChangStockTableObj,Expression<Func<RangChangStockTable, bool>> func)
         {
              Connect.CreatConnect().Update<RangChangStockTable>(RangChangStockTableObj, func);
         }
        public static void DeleteRangChangStockTable(Expression<Func<RangChangStockTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RangChangStockTable>(func);
         }
    }
}
