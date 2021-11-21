using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class StockInfoTableService
    {
        public static List<StockInfoTable> GetStockInfoTablelst(Expression<Func<StockInfoTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<StockInfoTable>(func);
         }
        public static List<StockInfoTable> GetStockInfoTablelst()
        {
            return Connect.CreatConnect().Query<StockInfoTable>();
        }
        public static StockInfoTable GetOneStockInfoTable(Expression<Func<StockInfoTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<StockInfoTable>(func);
         }
        public static void InsertStockInfoTablelst(List<StockInfoTable> StockInfoTableObjs)
         {
            foreach(StockInfoTable OBJ in StockInfoTableObjs)
             {
              Connect.CreatConnect().Insert<StockInfoTable>(OBJ);
             }
         }
        public static void InsertStockInfoTable(StockInfoTable StockInfoTableObj)
         {
              Connect.CreatConnect().Insert<StockInfoTable>(StockInfoTableObj);
         }
        public static void UpdateStockInfoTable(StockInfoTable StockInfoTableObj, Expression<Func<StockInfoTable, bool>> func)
         {
              Connect.CreatConnect().Update<StockInfoTable>(StockInfoTableObj,func);
         }
        public static void DeleteStockInfoTable(Expression<Func<StockInfoTable, bool>> func)
         {
              Connect.CreatConnect().Delete<StockInfoTable>(func);
         }
    }
}
