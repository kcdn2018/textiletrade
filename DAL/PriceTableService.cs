using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class PriceTableService
    {
        public static List<PriceTable> GetPriceTablelst(Expression<Func<PriceTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<PriceTable>(func);
         }
        public static PriceTable GetOnePriceTable(Expression<Func<PriceTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<PriceTable>(func);
         }
        public static void InsertPriceTablelst(List<PriceTable> PriceTableObjs)
         {
            foreach(PriceTable OBJ in PriceTableObjs)
             {
              Connect.CreatConnect().Insert<PriceTable>(OBJ);
             }
         }
        public static void InsertPriceTable(PriceTable PriceTableObj)
         {
              Connect.CreatConnect().Insert<PriceTable>(PriceTableObj);
         }
        public static void UpdatePriceTable(PriceTable PriceTableObj,Expression<Func<PriceTable, bool>> func)
         {
              Connect.CreatConnect().Update<PriceTable>(PriceTableObj, func);
         }
        public static void DeletePriceTable(Expression<Func<PriceTable, bool>> func)
         {
              Connect.CreatConnect().Delete<PriceTable>(func);
         }
    }
}
