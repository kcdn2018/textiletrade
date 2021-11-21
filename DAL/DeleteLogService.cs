using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class DeleteLogService
    {
        public static List<DeleteLog> GetDeleteLoglst(Expression<Func<DeleteLog, bool>> func)
         {
            return  Connect.CreatConnect().Query<DeleteLog>(func);
         }
        public static DeleteLog GetOneDeleteLog(Expression<Func<DeleteLog, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<DeleteLog>(func);
         }
        public static void InsertDeleteLoglst(List<DeleteLog> DeleteLogObjs)
         {
            foreach(DeleteLog OBJ in DeleteLogObjs)
             {
              Connect.CreatConnect().Insert<DeleteLog>(OBJ);
             }
         }
        public static void InsertDeleteLog(DeleteLog DeleteLogObj)
         {
              Connect.CreatConnect().Insert<DeleteLog>(DeleteLogObj);
         }
        public static void UpdateDeleteLog(DeleteLog DeleteLogObj,Expression<Func<DeleteLog, bool>> func)
         {
              Connect.CreatConnect().Update<DeleteLog>(DeleteLogObj, func);
         }
        public static void DeleteDeleteLog(Expression<Func<DeleteLog, bool>> func)
         {
              Connect.CreatConnect().Delete<DeleteLog>(func);
         }
    }
}
