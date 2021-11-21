using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothPlaneService
    {
        public static List<ClothPlane> GetClothPlanelst(Expression<Func<ClothPlane, bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothPlane>(func);
         }
        public static ClothPlane GetOneClothPlane(Expression<Func<ClothPlane, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothPlane>(func);
         }
        public static void InsertClothPlanelst(List<ClothPlane> ClothPlaneObjs)
         {
            foreach(ClothPlane OBJ in ClothPlaneObjs)
             {
              Connect.CreatConnect().Insert<ClothPlane>(OBJ);
             }
         }
        public static void InsertClothPlane(ClothPlane ClothPlaneObj)
         {
              Connect.CreatConnect().Insert<ClothPlane>(ClothPlaneObj);
         }
        public static void UpdateClothPlane(ClothPlane ClothPlaneObj,Expression<Func<ClothPlane, bool>> func)
         {
              Connect.CreatConnect().Update<ClothPlane>(ClothPlaneObj, func);
         }
        public static void DeleteClothPlane(Expression<Func<ClothPlane, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothPlane>(func);
         }
    }
}
