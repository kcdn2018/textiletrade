using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public  class liuzhuanlogService
    {
        public static List<liuzhuanlog> Getliuzhuanloglst(string WhereString)
         {
            return  Connect.CreatConnect().Query<liuzhuanlog>(WhereString);
         }
        public static liuzhuanlog GetOneliuzhuanlog(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<liuzhuanlog>(WhereString);
         }
        public static void Insertliuzhuanloglst(List<liuzhuanlog> liuzhuanlogObjs)
         {
            foreach(liuzhuanlog OBJ in liuzhuanlogObjs)
             {
              Connect.CreatConnect().Insert<liuzhuanlog>(OBJ);
             }
         }
        public static void Insertliuzhuanlog(liuzhuanlog liuzhuanlogObj)
         {
              Connect.CreatConnect().Insert<liuzhuanlog>(liuzhuanlogObj);
         }
        public static void Updateliuzhuanlog(liuzhuanlog liuzhuanlogObj,string WhereString)
         {
              Connect.CreatConnect().Update<liuzhuanlog>(liuzhuanlogObj,WhereString);
         }
        public static void Deleteliuzhuanlog(string WhereString)
         {
              Connect.CreatConnect().Delete<liuzhuanlog>(WhereString);
         }
        public static List<liuzhuanlog> Getliuzhuanloglst(Expression<Func<liuzhuanlog ,bool>> func)
         {
            return  Connect.CreatConnect().Query<liuzhuanlog>(func);
         }
        public static liuzhuanlog GetOneliuzhuanlog(Expression<Func<liuzhuanlog ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<liuzhuanlog>(func);
         }
        public static void Updateliuzhuanlog(liuzhuanlog liuzhuanlogObj,Expression<Func<liuzhuanlog ,bool>> func)
         {
              Connect.CreatConnect().Update<liuzhuanlog>(liuzhuanlogObj,func);
         }
        public static void Deleteliuzhuanlog(Expression<Func<liuzhuanlog ,bool>> func)
         {
              Connect.CreatConnect().Delete<liuzhuanlog>(func);
         }
    }
}
