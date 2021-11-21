using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ChangliangTableService
    {
        public static List<ChangliangTable> GetChangliangTablelst(Expression<Func<ChangliangTable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<ChangliangTable>(func).OrderByDescending (x=>x.Riqi ).ToList ();
         }
        public static ChangliangTable GetOneChangliangTable(Expression<Func<ChangliangTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ChangliangTable>(func);
         }
        public static void InsertChangliangTablelst(List<ChangliangTable> ChangliangTableObjs)
         {
            foreach(ChangliangTable OBJ in ChangliangTableObjs)
             {
              Connect.CreatConnect().Insert<ChangliangTable>(OBJ);
             }
         }
        public static void InsertChangliangTable(ChangliangTable ChangliangTableObj)
         {
              Connect.CreatConnect().Insert<ChangliangTable>(ChangliangTableObj);
         }
        public static void UpdateChangliangTable(ChangliangTable ChangliangTableObj, Expression<Func<ChangliangTable, bool>> func)
         {
              Connect.CreatConnect().Update<ChangliangTable>(ChangliangTableObj,func);
         }
        public static void DeleteChangliangTable(Expression<Func<ChangliangTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ChangliangTable>(func);
         }
    }
}
