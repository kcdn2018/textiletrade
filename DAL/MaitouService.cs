using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class MaitouService
    {
        public static List<Maitou> GetMaitoulst(Expression<Func<Maitou, bool>> func)
        {
            return  Connect.CreatConnect().Query<Maitou>(func);
         }
        public static List<Maitou> GetMaitoulst()
        {
            return Connect.CreatConnect().Query<Maitou>();
        }
        public static Maitou GetOneMaitou(Expression<Func<Maitou,bool >> func )
         {
            return  Connect.CreatConnect().QueryOneResult<Maitou>(func);
         }
        public static void InsertMaitoulst(List<Maitou> MaitouObjs)
         {
            foreach(Maitou OBJ in MaitouObjs)
             {
              Connect.CreatConnect().Insert<Maitou>(OBJ);
             }
         }
        public static void InsertMaitou(Maitou MaitouObj)
         {
              Connect.CreatConnect().Insert<Maitou>(MaitouObj);
         }
        public static void UpdateMaitou(Maitou MaitouObj, Expression<Func<Maitou, bool>> func)
        {
              Connect.CreatConnect().Update<Maitou>(MaitouObj,func);
         }
        public static void DeleteMaitou(Expression<Func<Maitou, bool>> func)
        {
              Connect.CreatConnect().Delete<Maitou>(func);
         }
    }
}
