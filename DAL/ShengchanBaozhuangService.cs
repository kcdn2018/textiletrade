using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchanBaozhuangService
    {
        public static List<ShengchanBaozhuang> GetShengchanBaozhuanglst(Expression<Func<ShengchanBaozhuang, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchanBaozhuang>(func);
         }
        public static ShengchanBaozhuang GetOneShengchanBaozhuang(Expression<Func<ShengchanBaozhuang, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchanBaozhuang>(func);
         }
        public static void InsertShengchanBaozhuanglst(List<ShengchanBaozhuang> ShengchanBaozhuangObjs)
         {
            foreach(ShengchanBaozhuang OBJ in ShengchanBaozhuangObjs)
             {
              Connect.CreatConnect().Insert<ShengchanBaozhuang>(OBJ);
             }
         }
        public static void InsertShengchanBaozhuang(ShengchanBaozhuang ShengchanBaozhuangObj)
         {
              Connect.CreatConnect().Insert<ShengchanBaozhuang>(ShengchanBaozhuangObj);
         }
        public static void UpdateShengchanBaozhuang(ShengchanBaozhuang ShengchanBaozhuangObj,Expression<Func<ShengchanBaozhuang, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchanBaozhuang>(ShengchanBaozhuangObj, func);
         }
        public static void DeleteShengchanBaozhuang(Expression<Func<ShengchanBaozhuang, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchanBaozhuang>(func);
         }
    }
}
