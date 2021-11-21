using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class JingZhouInfoTableService
    {
        public static List<JingZhouInfoTable> GetJingZhouInfoTablelst(Expression <Func<JingZhouInfoTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<JingZhouInfoTable>(func);
         }
        public static JingZhouInfoTable GetOneJingZhouInfoTable(Expression<Func<JingZhouInfoTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<JingZhouInfoTable>(func);
         }
        public static void InsertJingZhouInfoTablelst(List<JingZhouInfoTable> JingZhouInfoTableObjs)
         {
            foreach(JingZhouInfoTable OBJ in JingZhouInfoTableObjs)
             {
              Connect.CreatConnect().Insert<JingZhouInfoTable>(OBJ);
             }
         }
        public static void InsertJingZhouInfoTable(JingZhouInfoTable JingZhouInfoTableObj)
         {
              Connect.CreatConnect().Insert<JingZhouInfoTable>(JingZhouInfoTableObj);
         }
        public static void UpdateJingZhouInfoTable(JingZhouInfoTable JingZhouInfoTableObj,Expression<Func<JingZhouInfoTable, bool>> func)
         {
              Connect.CreatConnect().Update<JingZhouInfoTable>(JingZhouInfoTableObj, func);
         }
        public static void DeleteJingZhouInfoTable(Expression<Func<JingZhouInfoTable, bool>> func)
         {
              Connect.CreatConnect().Delete<JingZhouInfoTable>(func);
         }
    }
}
