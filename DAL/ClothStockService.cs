using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothStockService
    {
        public static List<ClothStock> GetClothStocklst(Expression<Func<ClothStock, bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothStock>(func);
         }
        public static ClothStock GetOneClothStock(Expression<Func<ClothStock, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothStock>(func);
         }
        public static void InsertClothStocklst(List<ClothStock> ClothStockObjs)
         {
            foreach(ClothStock OBJ in ClothStockObjs)
             {
              Connect.CreatConnect().Insert<ClothStock>(OBJ);
             }
         }
        public static void InsertClothStock(ClothStock ClothStockObj)
         {
              Connect.CreatConnect().Insert<ClothStock>(ClothStockObj);
         }
        public static void UpdateClothStock(ClothStock ClothStockObj,Expression<Func<ClothStock, bool>> func)
         {
              Connect.CreatConnect().Update<ClothStock>(ClothStockObj, func);
         }
        public static void DeleteClothStock(Expression<Func<ClothStock, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothStock>(func);
         }
    }
}
