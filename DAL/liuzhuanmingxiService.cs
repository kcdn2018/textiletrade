using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public  class liuzhuanmingxiService
    {
        public static List<liuzhuanmingxi> Getliuzhuanmingxilst(string WhereString)
         {
            return  Connect.CreatConnect().Query<liuzhuanmingxi>(WhereString);
         }
        public static liuzhuanmingxi GetOneliuzhuanmingxi(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<liuzhuanmingxi>(WhereString);
         }
        public static void Insertliuzhuanmingxilst(List<liuzhuanmingxi> liuzhuanmingxiObjs)
         {
            foreach(liuzhuanmingxi OBJ in liuzhuanmingxiObjs)
             {
              Connect.CreatConnect().Insert<liuzhuanmingxi>(OBJ);
             }
         }
        public static void Insertliuzhuanmingxi(liuzhuanmingxi liuzhuanmingxiObj)
         {
              Connect.CreatConnect().Insert<liuzhuanmingxi>(liuzhuanmingxiObj);
         }
        public static void Updateliuzhuanmingxi(liuzhuanmingxi liuzhuanmingxiObj,string WhereString)
         {
              Connect.CreatConnect().Update<liuzhuanmingxi>(liuzhuanmingxiObj,WhereString);
         }
        public static void Deleteliuzhuanmingxi(string WhereString)
         {
              Connect.CreatConnect().Delete<liuzhuanmingxi>(WhereString);
         }
        public static List<liuzhuanmingxi> Getliuzhuanmingxilst(Expression<Func<liuzhuanmingxi ,bool>> func)
         {
            return  Connect.CreatConnect().Query<liuzhuanmingxi>(func);
         }
        public static liuzhuanmingxi GetOneliuzhuanmingxi(Expression<Func<liuzhuanmingxi ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<liuzhuanmingxi>(func);
         }
        public static void Updateliuzhuanmingxi(liuzhuanmingxi liuzhuanmingxiObj,Expression<Func<liuzhuanmingxi ,bool>> func)
         {
              Connect.CreatConnect().Update<liuzhuanmingxi>(liuzhuanmingxiObj,func);
         }
        public static void Deleteliuzhuanmingxi(Expression<Func<liuzhuanmingxi ,bool>> func)
         {
              Connect.CreatConnect().Delete<liuzhuanmingxi>(func);
         }
    }
}
