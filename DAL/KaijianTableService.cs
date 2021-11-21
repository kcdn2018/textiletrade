using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class KaijianTableService
    {
        public static List<KaijianTable> GetKaijianTablelst(Expression<Func<KaijianTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<KaijianTable>(func);
         }
        public static KaijianTable GetOneKaijianTable(Expression<Func<KaijianTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<KaijianTable>(func);
         }
        public static void InsertKaijianTablelst(List<KaijianTable> KaijianTableObjs)
         {
            foreach(KaijianTable OBJ in KaijianTableObjs)
             {
              Connect.CreatConnect().Insert<KaijianTable>(OBJ);
             }
         }
        public static void InsertKaijianTable(KaijianTable KaijianTableObj)
         {
              Connect.CreatConnect().Insert<KaijianTable>(KaijianTableObj);
         }
        public static void UpdateKaijianTable(KaijianTable KaijianTableObj,Expression<Func<KaijianTable, bool>> func)
         {
              Connect.CreatConnect().Update<KaijianTable>(KaijianTableObj, func);
         }
        public static void DeleteKaijianTable(Expression<Func<KaijianTable, bool>> func)
         {
              Connect.CreatConnect().Delete<KaijianTable>(func);
         }
    }
}
