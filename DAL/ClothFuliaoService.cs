using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothFuliaoService
    {
        public static List<ClothFuliao> GetClothFuliaolst(Expression<Func<ClothFuliao  ,bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothFuliao>(func);
         }
        public static ClothFuliao GetOneClothFuliao(Expression<Func<ClothFuliao, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothFuliao>(func);
         }
        public static void InsertClothFuliaolst(List<ClothFuliao> ClothFuliaoObjs)
         {
            foreach(ClothFuliao OBJ in ClothFuliaoObjs)
             {
              Connect.CreatConnect().Insert<ClothFuliao>(OBJ);
             }
         }
        public static void InsertClothFuliao(ClothFuliao ClothFuliaoObj)
         {
              Connect.CreatConnect().Insert<ClothFuliao>(ClothFuliaoObj);
         }
        public static void UpdateClothFuliao(ClothFuliao ClothFuliaoObj,Expression<Func<ClothFuliao, bool>> func)
         {
              Connect.CreatConnect().Update<ClothFuliao>(ClothFuliaoObj,func);
         }
        public static void DeleteClothFuliao(Expression<Func<ClothFuliao, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothFuliao>(func);
         }
    }
}
