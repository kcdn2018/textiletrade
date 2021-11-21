using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class LaiYangTableService
    {
        public static List<LaiYangTable> GetLaiYangTablelst(Expression<Func<LaiYangTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<LaiYangTable>(func);
         }
        public static LaiYangTable GetOneLaiYangTable(Expression<Func<LaiYangTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LaiYangTable>(func);
         }
        public static void InsertLaiYangTablelst(List<LaiYangTable> LaiYangTableObjs)
         {
            foreach(LaiYangTable OBJ in LaiYangTableObjs)
             {
              Connect.CreatConnect().Insert<LaiYangTable>(OBJ);
             }
         }
        public static void InsertLaiYangTable(LaiYangTable LaiYangTableObj)
         {
              Connect.CreatConnect().Insert<LaiYangTable>(LaiYangTableObj);
         }
        public static void UpdateLaiYangTable(LaiYangTable LaiYangTableObj,Expression<Func<LaiYangTable, bool>> func)
         {
              Connect.CreatConnect().Update<LaiYangTable>(LaiYangTableObj, func);
         }
        public static void DeleteLaiYangTable(Expression<Func<LaiYangTable, bool>> func)
         {
              Connect.CreatConnect().Delete<LaiYangTable>(func);
         }
    }
}
