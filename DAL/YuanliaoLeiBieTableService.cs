using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YuanliaoLeiBieTableService
    {
        public static List<YuanliaoLeiBieTable> GetYuanliaoLeiBieTablelst(Expression<Func<YuanliaoLeiBieTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<YuanliaoLeiBieTable>(func);
         }
        public static YuanliaoLeiBieTable GetOneYuanliaoLeiBieTable(Expression<Func<YuanliaoLeiBieTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YuanliaoLeiBieTable>(func);
         }
        public static void InsertYuanliaoLeiBieTablelst(List<YuanliaoLeiBieTable> YuanliaoLeiBieTableObjs)
         {
            foreach(YuanliaoLeiBieTable OBJ in YuanliaoLeiBieTableObjs)
             {
              Connect.CreatConnect().Insert<YuanliaoLeiBieTable>(OBJ);
             }
         }
        public static void InsertYuanliaoLeiBieTable(YuanliaoLeiBieTable YuanliaoLeiBieTableObj)
         {
              Connect.CreatConnect().Insert<YuanliaoLeiBieTable>(YuanliaoLeiBieTableObj);
         }
        public static void UpdateYuanliaoLeiBieTable(YuanliaoLeiBieTable YuanliaoLeiBieTableObj,Expression<Func<YuanliaoLeiBieTable, bool>> func)
         {
              Connect.CreatConnect().Update<YuanliaoLeiBieTable>(YuanliaoLeiBieTableObj, func);
         }
        public static void DeleteYuanliaoLeiBieTable(Expression<Func<YuanliaoLeiBieTable, bool>> func)
         {
              Connect.CreatConnect().Delete<YuanliaoLeiBieTable>(func);
         }
    }
}
