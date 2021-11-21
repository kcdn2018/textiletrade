using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public  class LiuzhuancardService
    {
        public static List<Liuzhuancard> GetLiuzhuancardlst(string WhereString)
         {
            return  Connect.CreatConnect().Query<Liuzhuancard>(WhereString);
         }
        public static Liuzhuancard GetOneLiuzhuancard(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<Liuzhuancard>(WhereString);
         }
        public static void InsertLiuzhuancardlst(List<Liuzhuancard> LiuzhuancardObjs)
         {
            foreach(Liuzhuancard OBJ in LiuzhuancardObjs)
             {
              Connect.CreatConnect().Insert<Liuzhuancard>(OBJ);
             }
         }
        public static void InsertLiuzhuancard(Liuzhuancard LiuzhuancardObj)
         {
              Connect.CreatConnect().Insert<Liuzhuancard>(LiuzhuancardObj);
         }
        public static void UpdateLiuzhuancard(Liuzhuancard LiuzhuancardObj,string WhereString)
         {
              Connect.CreatConnect().Update<Liuzhuancard>(LiuzhuancardObj,WhereString);
         }
        public static void DeleteLiuzhuancard(string WhereString)
         {
              Connect.CreatConnect().Delete<Liuzhuancard>(WhereString);
         }
        public static List<Liuzhuancard> GetLiuzhuancardlst(Expression<Func<Liuzhuancard ,bool>> func)
         {
            return  Connect.CreatConnect().Query<Liuzhuancard>(func);
         }
        public static Liuzhuancard GetOneLiuzhuancard(Expression<Func<Liuzhuancard ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<Liuzhuancard>(func);
         }
        public static void UpdateLiuzhuancard(Liuzhuancard LiuzhuancardObj,Expression<Func<Liuzhuancard ,bool>> func)
         {
              Connect.CreatConnect().Update<Liuzhuancard>(LiuzhuancardObj,func);
         }
        public static void DeleteLiuzhuancard(Expression<Func<Liuzhuancard ,bool>> func)
         {
              Connect.CreatConnect().Delete<Liuzhuancard>(func);
         }
    }
}
