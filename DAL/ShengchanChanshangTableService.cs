using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengchanChanshangTableService
    {
        public static List<ShengchanChanshangTable> GetShengchanChanshangTablelst(Expression<Func<ShengchanChanshangTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengchanChanshangTable>(func);
         }
        /// <summary>
        /// 根据语句查询
        /// </summary>
        /// <param name="QueryString">查询语句</param>
        /// <returns></returns>
        public static List<ShengchanChanshangTable> GetShengchanChanshangTablelst(string QueryString)
        {
            return Connect.CreatConnect().Query<ShengchanChanshangTable>(QueryString);
        }
        public static ShengchanChanshangTable GetOneShengchanChanshangTable(Expression<Func<ShengchanChanshangTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengchanChanshangTable>(func);
         }
        public static void InsertShengchanChanshangTablelst(List<ShengchanChanshangTable> ShengchanChanshangTableObjs)
         {
              Connect.CreatConnect().Insert<ShengchanChanshangTable>(ShengchanChanshangTableObjs);
         }
        public static void InsertShengchanChanshangTable(ShengchanChanshangTable ShengchanChanshangTableObj)
         {
              Connect.CreatConnect().Insert<ShengchanChanshangTable>(ShengchanChanshangTableObj);
         }
        public static void UpdateShengchanChanshangTable(ShengchanChanshangTable ShengchanChanshangTableObj,Expression<Func<ShengchanChanshangTable, bool>> func)
         {
              Connect.CreatConnect().Update<ShengchanChanshangTable>(ShengchanChanshangTableObj, func);
         }
        public static void UpdateShengchanChanshangTable(string UpdateString, Expression<Func<ShengchanChanshangTable, bool>> func)
        {
            Connect.CreatConnect().Update<ShengchanChanshangTable>(UpdateString , func);
        }
        public static void DeleteShengchanChanshangTable(Expression<Func<ShengchanChanshangTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengchanChanshangTable>(func);
         }
    }
}
