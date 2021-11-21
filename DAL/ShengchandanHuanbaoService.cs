using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchandanHuanbaoService
    {
        public static List<ShengchandanHuanbao> GetShengchandanHuanbaolst(Expression<Func<ShengchandanHuanbao, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchandanHuanbao>(func);
         }
        public static ShengchandanHuanbao GetOneShengchandanHuanbao(Expression<Func<ShengchandanHuanbao, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchandanHuanbao>(func);
         }
        public static void InsertShengchandanHuanbaolst(List<ShengchandanHuanbao> ShengchandanHuanbaoObjs)
         {
            foreach(ShengchandanHuanbao OBJ in ShengchandanHuanbaoObjs)
             {
              Connect.CreatConnect().Insert<ShengchandanHuanbao>(OBJ);
             }
         }
        public static void InsertShengchandanHuanbao(ShengchandanHuanbao ShengchandanHuanbaoObj)
         {
              Connect.CreatConnect().Insert<ShengchandanHuanbao>(ShengchandanHuanbaoObj);
         }
        public static void UpdateShengchandanHuanbao(ShengchandanHuanbao ShengchandanHuanbaoObj,Expression<Func<ShengchandanHuanbao, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchandanHuanbao>(ShengchandanHuanbaoObj, func);
         }
        public static void DeleteShengchandanHuanbao(Expression<Func<ShengchandanHuanbao, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchandanHuanbao>(func);
         }
    }
}
