using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengChengGongYiService
    {
        public static List<ShengChengGongYi> GetShengChengGongYilst(Expression<Func<ShengChengGongYi, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengChengGongYi>(func);
         }
        public static ShengChengGongYi GetOneShengChengGongYi(Expression<Func<ShengChengGongYi, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengChengGongYi>(func);
         }
        public static void InsertShengChengGongYilst(List<ShengChengGongYi> ShengChengGongYiObjs)
         {          
              Connect.CreatConnect().Insert<ShengChengGongYi>(ShengChengGongYiObjs);
         }
        public static void InsertShengChengGongYi(ShengChengGongYi ShengChengGongYiObj)
         {
              Connect.CreatConnect().Insert<ShengChengGongYi>(ShengChengGongYiObj);
         }
        public static void UpdateShengChengGongYi(ShengChengGongYi ShengChengGongYiObj,Expression<Func<ShengChengGongYi, bool>> func)
         {
              Connect.CreatConnect().Update<ShengChengGongYi>(ShengChengGongYiObj, func);
         }
        public static void DeleteShengChengGongYi(Expression<Func<ShengChengGongYi, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengChengGongYi>(func);
         }
    }
}
