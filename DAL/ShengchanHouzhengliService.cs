using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchanHouzhengliService
    {
        public static List<ShengchanHouzhengli> GetShengchanHouzhenglilst(Expression<Func<ShengchanHouzhengli, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchanHouzhengli>(func);
         }
        public static ShengchanHouzhengli GetOneShengchanHouzhengli(Expression<Func<ShengchanHouzhengli, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchanHouzhengli>(func);
         }
        public static void InsertShengchanHouzhenglilst(List<ShengchanHouzhengli> ShengchanHouzhengliObjs)
         {
              Connect.CreatConnect().Insert<ShengchanHouzhengli>(ShengchanHouzhengliObjs);
         }
        public static void InsertShengchanHouzhengli(ShengchanHouzhengli ShengchanHouzhengliObj)
         {
              Connect.CreatConnect().Insert<ShengchanHouzhengli>(ShengchanHouzhengliObj);
         }
        public static void UpdateShengchanHouzhengli(ShengchanHouzhengli ShengchanHouzhengliObj,Expression<Func<ShengchanHouzhengli, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchanHouzhengli>(ShengchanHouzhengliObj, func);
         }
        public static void DeleteShengchanHouzhengli(Expression<Func<ShengchanHouzhengli, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchanHouzhengli>(func);
         }
    }
}
