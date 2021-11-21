using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchandanGongyiService
    {
        public static List<ShengchandanGongyi> GetShengchandanGongyilst()
        {
            return Connect.CreatConnect().Query<ShengchandanGongyi>();
        }
        public static List<ShengchandanGongyi> GetShengchandanGongyilst(Expression<Func<ShengchandanGongyi, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchandanGongyi>(func);
         }
        public static ShengchandanGongyi GetOneShengchandanGongyi(Expression<Func<ShengchandanGongyi, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchandanGongyi>(func);
         }
        public static void InsertShengchandanGongyilst(List<ShengchandanGongyi> ShengchandanGongyiObjs)
         {
            foreach(ShengchandanGongyi OBJ in ShengchandanGongyiObjs)
             {
              Connect.CreatConnect().Insert<ShengchandanGongyi>(OBJ);
             }
         }
        public static void InsertShengchandanGongyi(ShengchandanGongyi ShengchandanGongyiObj)
         {
              Connect.CreatConnect().Insert<ShengchandanGongyi>(ShengchandanGongyiObj);
         }
        public static void UpdateShengchandanGongyi(ShengchandanGongyi ShengchandanGongyiObj,Expression<Func<ShengchandanGongyi, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchandanGongyi>(ShengchandanGongyiObj, func);
         }
        public static void DeleteShengchandanGongyi(Expression<Func<ShengchandanGongyi, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchandanGongyi>(func);
         }
    }
}
