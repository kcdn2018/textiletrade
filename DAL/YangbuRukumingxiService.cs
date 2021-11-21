using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class YangbuRukumingxiService
    {
        public static List<YangbuRukumingxi> GetYangbuRukumingxilst(Expression<Func<YangbuRukumingxi, bool>> func)
         {
            return  Connect.CreatConnect().Query<YangbuRukumingxi>(func);
         }
        public static YangbuRukumingxi GetOneYangbuRukumingxi(Expression<Func<YangbuRukumingxi, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YangbuRukumingxi>(func);
         }
        public static void InsertYangbuRukumingxilst(List<YangbuRukumingxi> YangbuRukumingxiObjs)
         {
            foreach(YangbuRukumingxi OBJ in YangbuRukumingxiObjs)
             {
              Connect.CreatConnect().Insert<YangbuRukumingxi>(OBJ);
             }
         }
        public static void InsertYangbuRukumingxi(YangbuRukumingxi YangbuRukumingxiObj)
         {
              Connect.CreatConnect().Insert<YangbuRukumingxi>(YangbuRukumingxiObj);
         }
        public static void UpdateYangbuRukumingxi(YangbuRukumingxi YangbuRukumingxiObj,Expression<Func<YangbuRukumingxi, bool>> func)
         {
              Connect.CreatConnect().Update<YangbuRukumingxi>(YangbuRukumingxiObj, func);
         }
        public static void DeleteYangbuRukumingxi(Expression<Func<YangbuRukumingxi, bool>> func)
         {
              Connect.CreatConnect().Delete<YangbuRukumingxi>(func);
         }
    }
}
