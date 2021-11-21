using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ClothInfoService
    {
        public static List<ClothInfo> GetClothInfolst(Expression<Func<ClothInfo, bool>> func)
         {
            return  Connect.CreatConnect().Query<ClothInfo>(func);
         }
        public static ClothInfo GetOneClothInfo(Expression<Func<ClothInfo, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothInfo>(func);
         }
        public static void InsertClothInfolst(List<ClothInfo> ClothInfoObjs)
         {
            foreach(ClothInfo OBJ in ClothInfoObjs)
             {
              Connect.CreatConnect().Insert<ClothInfo>(OBJ);
             }
         }
        public static void InsertClothInfo(ClothInfo ClothInfoObj)
         {
              Connect.CreatConnect().Insert<ClothInfo>(ClothInfoObj);
         }
        public static void UpdateClothInfo(ClothInfo ClothInfoObj,Expression<Func<ClothInfo, bool>> func)
         {
              Connect.CreatConnect().Update<ClothInfo>(ClothInfoObj,func);
         }
        public static void DeleteClothInfo(Expression<Func<ClothInfo, bool>> func)
         {
              Connect.CreatConnect().Delete<ClothInfo>(func);
         }
    }
}
