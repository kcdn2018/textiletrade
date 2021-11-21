using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ZhanhuiDetailService
    {
        public static List<ZhanhuiDetail> GetZhanhuiDetaillst(Expression<Func<ZhanhuiDetail, bool>> func)
         {
            return  Connect.CreatConnect().Query<ZhanhuiDetail>(func);
         }
        public static ZhanhuiDetail GetOneZhanhuiDetail(Expression<Func<ZhanhuiDetail, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ZhanhuiDetail>(func);
         }
        public static void InsertZhanhuiDetaillst(List<ZhanhuiDetail> ZhanhuiDetailObjs)
         {
            foreach(ZhanhuiDetail OBJ in ZhanhuiDetailObjs)
             {
              Connect.CreatConnect().Insert<ZhanhuiDetail>(OBJ);
             }
         }
        public static void InsertZhanhuiDetail(ZhanhuiDetail ZhanhuiDetailObj)
         {
              Connect.CreatConnect().Insert<ZhanhuiDetail>(ZhanhuiDetailObj);
         }
        public static void UpdateZhanhuiDetail(ZhanhuiDetail ZhanhuiDetailObj,Expression<Func<ZhanhuiDetail, bool>> func)
         {
              Connect.CreatConnect().Update<ZhanhuiDetail>(ZhanhuiDetailObj, func);
         }
        public static void DeleteZhanhuiDetail(Expression<Func<ZhanhuiDetail, bool>> func)
         {
              Connect.CreatConnect().Delete<ZhanhuiDetail>(func);
         }
    }
}
