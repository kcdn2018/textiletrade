using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothPlaneDetailService
    {
        public static List<ClothPlaneDetail> GetClothPlaneDetaillst(Expression<Func<ClothPlaneDetail, bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothPlaneDetail>(func);
         }
        public static ClothPlaneDetail GetOneClothPlaneDetail(Expression<Func<ClothPlaneDetail, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothPlaneDetail>(func);
         }
        public static void InsertClothPlaneDetaillst(List<ClothPlaneDetail> ClothPlaneDetailObjs)
         {
            foreach(ClothPlaneDetail OBJ in ClothPlaneDetailObjs)
             {
              Connect.CreatConnect().Insert<ClothPlaneDetail>(OBJ);
             }
         }
        public static void InsertClothPlaneDetail(ClothPlaneDetail ClothPlaneDetailObj)
         {
              Connect.CreatConnect().Insert<ClothPlaneDetail>(ClothPlaneDetailObj);
         }
        public static void UpdateClothPlaneDetail(ClothPlaneDetail ClothPlaneDetailObj,Expression<Func<ClothPlaneDetail, bool>> func)
         {
              Connect.CreatConnect().Update<ClothPlaneDetail>(ClothPlaneDetailObj, func);
         }
        public static void DeleteClothPlaneDetail(Expression<Func<ClothPlaneDetail, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothPlaneDetail>(func);
         }
    }
}
