using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class LetterTableService
    {
        public static List<LetterTable> GetLetterTablelst()
         {
            return  Connect.CreatConnect().Query<LetterTable>();
         }
        public static LetterTable GetOneLetterTable(Expression<Func<LetterTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LetterTable>(func);
         }
        public static void InsertLetterTablelst(List<LetterTable> LetterTableObjs)
         {
            foreach(LetterTable OBJ in LetterTableObjs)
             {
              Connect.CreatConnect().Insert<LetterTable>(OBJ);
             }
         }
        public static void InsertLetterTable(LetterTable LetterTableObj)
         {
              Connect.CreatConnect().Insert<LetterTable>(LetterTableObj);
         }
        public static void UpdateLetterTable(LetterTable LetterTableObj,Expression<Func<LetterTable, bool>> func)
         {
              Connect.CreatConnect().Update<LetterTable>(LetterTableObj, func);
         }
        public static void DeleteLetterTable(Expression<Func<LetterTable, bool>> func)
         {
              Connect.CreatConnect().Delete<LetterTable>(func);
         }
    }
}
