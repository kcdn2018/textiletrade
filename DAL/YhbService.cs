using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YhbService
    {
        public static List<Yhb> GetYhblst(Expression<Func<Yhb,bool>>func)
         {
            return  Connect.CreatConnect().Query<Yhb>(func);
         }
        public static List<Yhb> GetYhblst()
        {
            return Connect.CreatConnect().Query<Yhb>();
        }
        public static Yhb GetOneYhb(Expression<Func<Yhb, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<Yhb>(func);
         }
        public static void InsertYhblst(List<Yhb> YhbObjs)
         {
            foreach(Yhb OBJ in YhbObjs)
             {
              Connect.CreatConnect().Insert<Yhb>(OBJ);
             }
         }
        public static void InsertYhb(Yhb YhbObj)
         {
              Connect.CreatConnect().Insert<Yhb>(YhbObj);
         }
        public static void UpdateYhb(Yhb YhbObj, Expression<Func<Yhb, bool>> func)
         {
              Connect.CreatConnect().Update<Yhb>(YhbObj,func);
         }
        public static void DeleteYhb(Expression<Func<Yhb, bool>> func)
         {
              Connect.CreatConnect().Delete<Yhb>(func);
         }
    }
}
