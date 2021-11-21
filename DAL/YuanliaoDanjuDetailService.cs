using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YuanliaoDanjuDetailService
    {
        public static List<YuanliaoDanjuDetail> GetYuanliaoDanjuDetaillst(Expression<Func<YuanliaoDanjuDetail, bool>> func)
         {
            return  Connect.CreatConnect().Query<YuanliaoDanjuDetail>(func);
         }
        public static YuanliaoDanjuDetail GetOneYuanliaoDanjuDetail(Expression<Func<YuanliaoDanjuDetail, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YuanliaoDanjuDetail>(func);
         }
        public static void InsertYuanliaoDanjuDetaillst(List<YuanliaoDanjuDetail> YuanliaoDanjuDetailObjs)
         {
            foreach(YuanliaoDanjuDetail OBJ in YuanliaoDanjuDetailObjs)
             {
              Connect.CreatConnect().Insert<YuanliaoDanjuDetail>(OBJ);
             }
         }
        public static void InsertYuanliaoDanjuDetail(YuanliaoDanjuDetail YuanliaoDanjuDetailObj)
         {
              Connect.CreatConnect().Insert<YuanliaoDanjuDetail>(YuanliaoDanjuDetailObj);
         }
        public static void UpdateYuanliaoDanjuDetail(YuanliaoDanjuDetail YuanliaoDanjuDetailObj,Expression<Func<YuanliaoDanjuDetail, bool>> func)
         {
              Connect.CreatConnect().Update<YuanliaoDanjuDetail>(YuanliaoDanjuDetailObj, func);
         }
        public static void DeleteYuanliaoDanjuDetail(Expression<Func<YuanliaoDanjuDetail, bool>> func)
         {
              Connect.CreatConnect().Delete<YuanliaoDanjuDetail>(func);
         }
    }
}
