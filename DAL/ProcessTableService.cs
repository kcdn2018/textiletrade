using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ProcessTableService
    {
        public static List<ProcessTable> GetProcessTablelst(Expression<Func<ProcessTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<ProcessTable>(func).OrderByDescending(x => x.rq).ToList();
         }
        public static ProcessTable GetOneProcessTable(Expression<Func<ProcessTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ProcessTable>(func);
         }
        public static void InsertProcessTablelst(List<ProcessTable> ProcessTableObjs)
         {        
              Connect.CreatConnect().Insert<ProcessTable>(ProcessTableObjs);
         }
        public static void InsertProcessTable(ProcessTable ProcessTableObj)
         {
              Connect.CreatConnect().Insert<ProcessTable>(ProcessTableObj);
         }
        public static void UpdateProcessTable(ProcessTable ProcessTableObj,Expression<Func<ProcessTable, bool>> func)
         {
              Connect.CreatConnect().Update<ProcessTable>(ProcessTableObj, func);
         }
        public static void DeleteProcessTable(Expression<Func<ProcessTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ProcessTable>(func);
         }
    }
}
