using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YuanliaoStockService
    {
        public static List<YuanliaoStock> GetYuanliaoStocklst(Expression<Func<YuanliaoStock, bool>> func)
         {
            return  Connect.CreatConnect().Query<YuanliaoStock>(func);
         }
        public static YuanliaoStock GetOneYuanliaoStock(Expression<Func<YuanliaoStock, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YuanliaoStock>(func);
         }
        public static void InsertYuanliaoStocklst(List<YuanliaoStock> YuanliaoStockObjs)
         {
            foreach(YuanliaoStock OBJ in YuanliaoStockObjs)
             {
              Connect.CreatConnect().Insert<YuanliaoStock>(OBJ);
             }
         }
        public static void InsertYuanliaoStock(YuanliaoStock YuanliaoStockObj)
         {
              Connect.CreatConnect().Insert<YuanliaoStock>(YuanliaoStockObj);
         }
        public static void UpdateYuanliaoStock(YuanliaoStock YuanliaoStockObj,Expression<Func<YuanliaoStock, bool>> func)
         {
              Connect.CreatConnect().Update<YuanliaoStock>(YuanliaoStockObj, func);
         }
        public static void DeleteYuanliaoStock(Expression<Func<YuanliaoStock, bool>> func)
         {
              Connect.CreatConnect().Delete<YuanliaoStock>(func);
         }
    }
}
