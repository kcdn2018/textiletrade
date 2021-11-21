using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchandanSeLaoduService
    {
        public static List<ShengchandanSeLaodu> GetShengchandanSeLaodulst(Expression<Func<ShengchandanSeLaodu, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchandanSeLaodu>(func);
         }
        public static ShengchandanSeLaodu GetOneShengchandanSeLaodu(Expression<Func<ShengchandanSeLaodu, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchandanSeLaodu>(func);
         }
        public static void InsertShengchandanSeLaodulst(List<ShengchandanSeLaodu> ShengchandanSeLaoduObjs)
         {
            foreach(ShengchandanSeLaodu OBJ in ShengchandanSeLaoduObjs)
             {
              Connect.CreatConnect().Insert<ShengchandanSeLaodu>(OBJ);
             }
         }
        public static void InsertShengchandanSeLaodu(ShengchandanSeLaodu ShengchandanSeLaoduObj)
         {
              Connect.CreatConnect().Insert<ShengchandanSeLaodu>(ShengchandanSeLaoduObj);
         }
        public static void UpdateShengchandanSeLaodu(ShengchandanSeLaodu ShengchandanSeLaoduObj,Expression<Func<ShengchandanSeLaodu, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchandanSeLaodu>(ShengchandanSeLaoduObj, func);
         }
        public static void DeleteShengchandanSeLaodu(Expression<Func<ShengchandanSeLaodu, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchandanSeLaodu>(func);
         }
    }
}
