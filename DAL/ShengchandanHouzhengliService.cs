using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchandanHouzhengliService
    {
        public static List<ShengchandanHouzhengli> GetShengchandanHouzhenglilst(Expression<Func<ShengchandanHouzhengli ,bool >>func)
         {
            return  Connect.CreatConnect().Query<ShengchandanHouzhengli>(func);
         }
        public static ShengchandanHouzhengli GetOneShengchandanHouzhengli(Expression<Func<ShengchandanHouzhengli, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchandanHouzhengli>(func);
         }
        public static void InsertShengchandanHouzhenglilst(List<ShengchandanHouzhengli> ShengchandanHouzhengliObjs)
         {
            foreach(ShengchandanHouzhengli OBJ in ShengchandanHouzhengliObjs)
             {
              Connect.CreatConnect().Insert<ShengchandanHouzhengli>(OBJ);
             }
         }
        public static void InsertShengchandanHouzhengli(ShengchandanHouzhengli ShengchandanHouzhengliObj)
         {
              Connect.CreatConnect().Insert<ShengchandanHouzhengli>(ShengchandanHouzhengliObj);
         }
        public static void UpdateShengchandanHouzhengli(ShengchandanHouzhengli ShengchandanHouzhengliObj,Expression<Func<ShengchandanHouzhengli, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchandanHouzhengli>(ShengchandanHouzhengliObj, func);
         }
        public static void DeleteShengchandanHouzhengli(Expression<Func<ShengchandanHouzhengli, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchandanHouzhengli>(func);
         }
    }
}
