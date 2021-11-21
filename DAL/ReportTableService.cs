using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class ReportTableService
    {
        public static List<ReportTable> GetReportTablelst(Expression<Func<ReportTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<ReportTable>(func);
         }
        public static List<ReportTable> GetReportTablelst()
        {
            return Connect.CreatConnect().Query<ReportTable>();
        }
        public static ReportTable GetOneReportTable(Expression<Func<ReportTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ReportTable>(func);
         }
        public static void InsertReportTablelst(List<ReportTable> ReportTableObjs)
         {
            foreach(ReportTable OBJ in ReportTableObjs)
             {
              Connect.CreatConnect().Insert<ReportTable>(OBJ);
             }
         }
        public static void InsertReportTable(ReportTable ReportTableObj)
         {
              Connect.CreatConnect().Insert<ReportTable>(ReportTableObj);
         }
        public static void UpdateReportTable(ReportTable ReportTableObj,Expression<Func<ReportTable, bool>> func)
         {
              Connect.CreatConnect().Update<ReportTable>(ReportTableObj, func);
         }
        public static void DeleteReportTable(Expression<Func<ReportTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ReportTable>(func);
         }
    }
}
