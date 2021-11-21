using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class SKFSService
    {
        public static List<SKFS> GetSKFSlst(Expression<Func <SKFS,bool>> func)
         {
            return  Connect.CreatConnect().Query<SKFS>(func);
         }
        public static SKFS GetOneSKFS(Expression<Func<SKFS, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<SKFS>(func);
         }
        public static void InsertSKFSlst(List<SKFS> SKFSObjs)
         {
            foreach(SKFS OBJ in SKFSObjs)
             {
              Connect.CreatConnect().Insert<SKFS>(OBJ);
             }
         }
        public static void InsertSKFS(SKFS SKFSObj)
         {
              Connect.CreatConnect().Insert<SKFS>(SKFSObj);
         }
        public static void UpdateSKFS(SKFS SKFSObj, Expression<Func<SKFS, bool>> func)
         {
              Connect.CreatConnect().Update<SKFS>(SKFSObj,func);
         }
        public static void UpdateSKFS(string UpdateString, Expression<Func<SKFS, bool>> func)
        {
            Connect.CreatConnect().Update<SKFS>(UpdateString , func);
        }
        public static void DeleteSKFS(Expression<Func<SKFS, bool>> func)
         {
              Connect.CreatConnect().Delete<SKFS>(func);
         }
    }
}
