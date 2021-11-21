using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class FuliaoRukuDetailService
    {
        public static List<FuliaoRukuDetail> GetFuliaoRukuDetaillst(Expression<Func<FuliaoRukuDetail, bool>> func)
         {
            return  Connect.CreatConnect().Query<FuliaoRukuDetail>(func);
         }
        public static FuliaoRukuDetail GetOneFuliaoRukuDetail(Expression<Func<FuliaoRukuDetail, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<FuliaoRukuDetail>(func);
         }
        public static void InsertFuliaoRukuDetaillst(List<FuliaoRukuDetail> FuliaoRukuDetailObjs)
         {
            foreach(FuliaoRukuDetail OBJ in FuliaoRukuDetailObjs)
             {
              Connect.CreatConnect().Insert<FuliaoRukuDetail>(OBJ);
             }
         }
        public static void InsertFuliaoRukuDetail(FuliaoRukuDetail FuliaoRukuDetailObj)
         {
              Connect.CreatConnect().Insert<FuliaoRukuDetail>(FuliaoRukuDetailObj);
         }
        public static void UpdateFuliaoRukuDetail(FuliaoRukuDetail FuliaoRukuDetailObj,Expression<Func<FuliaoRukuDetail, bool>> func)
         {
              Connect.CreatConnect().Update<FuliaoRukuDetail>(FuliaoRukuDetailObj, func);
         }
        public static void DeleteFuliaoRukuDetail(Expression<Func<FuliaoRukuDetail, bool>> func)
         {
              Connect.CreatConnect().Delete<FuliaoRukuDetail>(func);
         }
    }
}
