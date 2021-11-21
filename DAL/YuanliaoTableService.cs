using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YuanliaoTableService
    {
        public static List<YuanliaoTable> GetYuanliaoTablelst(Expression<Func<YuanliaoTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<YuanliaoTable>(func);
         }
        public static YuanliaoTable GetOneYuanliaoTable(Expression<Func<YuanliaoTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YuanliaoTable>(func);
         }
        public static void InsertYuanliaoTablelst(List<YuanliaoTable> YuanliaoTableObjs)
         {
            foreach(YuanliaoTable OBJ in YuanliaoTableObjs)
             {
              Connect.CreatConnect().Insert<YuanliaoTable>(OBJ);
             }
         }
        public static void InsertYuanliaoTable(YuanliaoTable YuanliaoTableObj)
         {
              Connect.CreatConnect().Insert<YuanliaoTable>(YuanliaoTableObj);
         }
        public static void UpdateYuanliaoTable(YuanliaoTable YuanliaoTableObj,Expression<Func<YuanliaoTable, bool>> func)
         {
              Connect.CreatConnect().Update<YuanliaoTable>(YuanliaoTableObj, func);
         }
        public static void DeleteYuanliaoTable(Expression<Func<YuanliaoTable, bool>> func)
         {
              Connect.CreatConnect().Delete<YuanliaoTable>(func);
         }
    }
}
