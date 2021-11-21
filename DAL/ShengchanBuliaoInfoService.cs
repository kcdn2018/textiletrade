using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class ShengchanBuliaoInfoService
    {
        public static List<ShengchanBuliaoInfo> GetShengchanBuliaoInfolst(Expression<Func<ShengchanBuliaoInfo ,bool >> func)
         {
            return Connect.CreatConnect().Query<ShengchanBuliaoInfo>(func);
         }
        public static ShengchanBuliaoInfo GetOneShengchanBuliaoInfo(Expression<Func<ShengchanBuliaoInfo, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchanBuliaoInfo>(func);
         }
        public static void InsertShengchanBuliaoInfolst(List<ShengchanBuliaoInfo> ShengchanBuliaoInfoObjs)
         {
              Connect.CreatConnect().Insert<ShengchanBuliaoInfo>(ShengchanBuliaoInfoObjs);
         }
        public static void InsertShengchanBuliaoInfo(ShengchanBuliaoInfo ShengchanBuliaoInfoObj)
         {
              Connect.CreatConnect().Insert<ShengchanBuliaoInfo>(ShengchanBuliaoInfoObj);
         }
        public static void UpdateShengchanBuliaoInfo(ShengchanBuliaoInfo ShengchanBuliaoInfoObj,Expression<Func<ShengchanBuliaoInfo, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchanBuliaoInfo>(ShengchanBuliaoInfoObj, func);
         }
        public static void DeleteShengchanBuliaoInfo(Expression<Func<ShengchanBuliaoInfo, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchanBuliaoInfo>(func);
         }
    }
}
