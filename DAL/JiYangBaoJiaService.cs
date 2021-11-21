using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class JiYangBaoJiaService
    {
        public static List<JiYangBaoJia> GetJiYangBaoJialst(Expression<Func<JiYangBaoJia , bool>> func)
         {
            return  Connect.CreatConnect().Query<JiYangBaoJia>(func).OrderByDescending(x => x.RQ).ToList();
         }
        public static JiYangBaoJia GetOneJiYangBaoJia(Expression<Func<JiYangBaoJia, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<JiYangBaoJia>(func);
         }
        public static void InsertJiYangBaoJialst(List<JiYangBaoJia> JiYangBaoJiaObjs)
         {
              Connect.CreatConnect().Insert<JiYangBaoJia>(JiYangBaoJiaObjs);
         }
        public static void InsertJiYangBaoJia(JiYangBaoJia JiYangBaoJiaObj)
         {
              Connect.CreatConnect().Insert<JiYangBaoJia>(JiYangBaoJiaObj);
         }
        public static void UpdateJiYangBaoJia(JiYangBaoJia JiYangBaoJiaObj,Expression<Func<JiYangBaoJia, bool>> func)
         {
              Connect.CreatConnect().Update<JiYangBaoJia>(JiYangBaoJiaObj, func);
         }
        public static void DeleteJiYangBaoJia(Expression<Func<JiYangBaoJia, bool>> func)
         {
              Connect.CreatConnect().Delete<JiYangBaoJia>(func);
         }
    }
}
