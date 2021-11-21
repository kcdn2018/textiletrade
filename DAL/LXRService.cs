using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class LXRService
    {
        public static List<LXR> GetLXRlst(Expression<Func<LXR, bool>> func)
         {
            return  Connect.CreatConnect().Query<LXR>(func);
         }
        public static LXR GetOneLXR(Expression<Func<LXR, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LXR>(func);
         }
        public static void InsertLXRlst(List<LXR> LXRObjs)
         {
            foreach(LXR OBJ in LXRObjs)
             {
              Connect.CreatConnect().Insert<LXR>(OBJ);
             }
         }
        public static void InsertLXR(LXR LXRObj)
         {
              Connect.CreatConnect().Insert<LXR>(LXRObj);
         }
        public static void UpdateLXR(LXR LXRObj, Expression<Func<LXR, bool>> func)
         {
              Connect.CreatConnect().Update<LXR>(LXRObj,func);
         }
        public static void UpdateLXR(Expression <Func<LXR,bool >> LXRObj, Expression<Func<LXR, bool>> func)
        {
            Connect.CreatConnect().Update<LXR>(LXRObj, func);
        }
        public static void UpdateLXR(string Updatestring, Expression<Func<LXR, bool>> func)
        {
            Connect.CreatConnect().Update<LXR>(Updatestring , func);
        }
        public static void DeleteLXR(Expression<Func<LXR, bool>> func)
         {
              Connect.CreatConnect().Delete<LXR>(func);
         }
        //public static void DeleteLXR(Expression<Func<LXR, bool>> func)
        //{
        //    Connect.CreatConnect().Delete<LXR>(func);
        //}
    }
}
