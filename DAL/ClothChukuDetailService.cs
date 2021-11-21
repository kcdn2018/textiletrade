using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class ClothChukuDetailService
    {
        public static List<ClothChukuDetail> GetClothChukuDetaillst(string WhereString)
         {
            return  Connect.CreatConnect().Query<ClothChukuDetail>(WhereString);
         }
        public static ClothChukuDetail GetOneClothChukuDetail(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<ClothChukuDetail>(WhereString);
         }
        public static void InsertClothChukuDetaillst(List<ClothChukuDetail> ClothChukuDetailObjs)
         {
            foreach(ClothChukuDetail OBJ in ClothChukuDetailObjs)
             {
              Connect.CreatConnect().Insert<ClothChukuDetail>(OBJ);
             }
         }
        public static void InsertClothChukuDetail(ClothChukuDetail ClothChukuDetailObj)
         {
              Connect.CreatConnect().Insert<ClothChukuDetail>(ClothChukuDetailObj);
         }
        public static void UpdateClothChukuDetail(ClothChukuDetail ClothChukuDetailObj,string WhereString)
         {
              Connect.CreatConnect().Update<ClothChukuDetail>(ClothChukuDetailObj,WhereString);
         }
        public static void DeleteClothChukuDetail(string WhereString)
         {
              Connect.CreatConnect().Delete<ClothChukuDetail>(WhereString);
         }
    }
}
