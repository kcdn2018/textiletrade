using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class StockTableService
    {
        public static List<StockTable> GetStockTablelst(Expression<Func<StockTable,bool>> func)
         {
            return  Connect.CreatConnect().Query<StockTable>(func);
         }
        public static List<StockTable> GetStockTablelst()
        {
            return Connect.CreatConnect().Query<StockTable>();
        }
        public static StockTable GetOneStockTable(Expression<Func<StockTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<StockTable>(func);
         }
        public static void InsertStockTablelst(List<StockTable> StockTableObjs)
         {
            foreach(StockTable OBJ in StockTableObjs)
             {
              Connect.CreatConnect().Insert<StockTable>(OBJ);
             }
         }
        public static void InsertStockTable(StockTable StockTableObj)
         {
            Connect.CreatConnect().Insert<StockTable>(StockTableObj);
        
         }
        public static void UpdateStockTable(StockTable StockTableObj, Expression<Func<StockTable, bool>> func)
         {
              Connect.CreatConnect().Update<StockTable>(StockTableObj,func);
         }
        public static void UpdateStockTable(string UpdateString , Expression<Func<StockTable, bool>> func)
        {
            Connect.CreatConnect().Update<StockTable>(UpdateString , func);
        }
        public static void DeleteStockTable(Expression<Func<StockTable, bool>> func)
         {
              Connect.CreatConnect().Delete<StockTable>(func);
         }
    }
}
