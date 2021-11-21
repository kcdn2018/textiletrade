using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothPlaneFuliaoService
    {
        public static List<ClothPlaneFuliao> GetClothPlaneFuliaolst(Expression<Func<ClothPlaneFuliao, bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothPlaneFuliao>(func);
         }
        public static ClothPlaneFuliao GetOneClothPlaneFuliao(Expression<Func<ClothPlaneFuliao, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothPlaneFuliao>(func);
         }
        public static void InsertClothPlaneFuliaolst(List<ClothPlaneFuliao> ClothPlaneFuliaoObjs)
         {
            foreach(ClothPlaneFuliao OBJ in ClothPlaneFuliaoObjs)
             {
              Connect.CreatConnect().Insert<ClothPlaneFuliao>(OBJ);
             }
         }
        public static void InsertClothPlaneFuliao(ClothPlaneFuliao ClothPlaneFuliaoObj)
         {
              Connect.CreatConnect().Insert<ClothPlaneFuliao>(ClothPlaneFuliaoObj);
         }
        public static void UpdateClothPlaneFuliao(ClothPlaneFuliao ClothPlaneFuliaoObj,Expression<Func<ClothPlaneFuliao, bool>> func)
         {
              Connect.CreatConnect().Update<ClothPlaneFuliao>(ClothPlaneFuliaoObj, func);
         }
        public static void DeleteClothPlaneFuliao(Expression<Func<ClothPlaneFuliao, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothPlaneFuliao>(func);
         }
    }
}
