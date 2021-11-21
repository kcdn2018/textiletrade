using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class FahuoDanService
    {
        public static List<FahuoDan> GetFahuoDanlst(Expression<Func<FahuoDan,bool>> func)
         {
            return  Connect.CreatConnect().Query<FahuoDan>(func);
         }
        public static FahuoDan GetOneFahuoDan(Expression<Func<FahuoDan, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<FahuoDan>(func);
         }
        public static void InsertFahuoDanlst(List<FahuoDan> FahuoDanObjs)
         {
              Connect.CreatConnect().Insert<FahuoDan>(FahuoDanObjs);
         }
        public static void InsertFahuoDan(FahuoDan FahuoDanObj)
         {
              Connect.CreatConnect().Insert<FahuoDan>(FahuoDanObj);
         }
        public static void UpdateFahuoDan(FahuoDan FahuoDanObj, Expression<Func<FahuoDan, bool>> func)
         {
              Connect.CreatConnect().Update<FahuoDan>(FahuoDanObj,func);
         }
        public static void DeleteFahuoDan(Expression<Func<FahuoDan, bool>> func)
         {
              Connect.CreatConnect().Delete<FahuoDan>(func);
         }
    }
}
