using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YangBuStockService
    {
        public static List<YangBuStock> GetYangBuStocklst(Expression<Func<YangBuStock, bool>> func)
         {
            return  Connect.CreatConnect().Query<YangBuStock>(func);
         }
        public static YangBuStock GetOneYangBuStock(Expression<Func<YangBuStock, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YangBuStock>(func);
         }
        public static void InsertYangBuStocklst(List<YangBuStock> YangBuStockObjs)
         {
            foreach(YangBuStock OBJ in YangBuStockObjs)
             {
              Connect.CreatConnect().Insert<YangBuStock>(OBJ);
             }
         }
        public static void InsertYangBuStock(YangBuStock YangBuStockObj)
         {
              Connect.CreatConnect().Insert<YangBuStock>(YangBuStockObj);
         }
        public static void UpdateYangBuStock(YangBuStock YangBuStockObj,Expression<Func<YangBuStock, bool>> func)
         {
              Connect.CreatConnect().Update<YangBuStock>(YangBuStockObj, func);
         }
        public static void DeleteYangBuStock(Expression<Func<YangBuStock, bool>> func)
         {
              Connect.CreatConnect().Delete<YangBuStock>(func);
         }
    }
}
