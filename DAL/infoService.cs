using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class infoService
    {
        public static List<info> Getinfolst()
         {
            return  Connect.CreatConnect().Query<info>();
         }
        public static info GetOneinfo(Expression<Func<info ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<info>(func);
         }
        public static void Insertinfolst(List<info> infoObjs)
         {
            foreach(info OBJ in infoObjs)
             {
              Connect.CreatConnect().Insert<info>(OBJ);
             }
         }
        public static void Insertinfo(info infoObj)
         {
              Connect.CreatConnect().Insert<info>(infoObj);
         }
        public static void Updateinfo(info infoObj,Expression<Func<info ,bool>> func)
         {
              Connect.CreatConnect().Update<info>(infoObj,func);
         }
        public static void Updateinfo(string Updatestring)
        {
            Connect.CreatConnect().DoSQL (Updatestring );
        }
        public static void Updateinfo(Expression<Func<info, bool>> Updatefunc, Expression<Func<info, bool>> func)
        {
            Connect.CreatConnect().Update<info>(Updatefunc  , func);
        }
        public static void Deleteinfo(Expression<Func<info,bool>>func)
         {
              Connect.CreatConnect().Delete<info>(func);
         }
    }
}
