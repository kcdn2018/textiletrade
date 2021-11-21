using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class FatherMenuTableService
    {
        public static List<FatherMenuTable> GetFatherMenuTablelst()
         {
            return  Connect.CreatConnect().Query<FatherMenuTable>();
         }
        public static List<FatherMenuTable> GetFatherMenuTablelst(Expression<Func<FatherMenuTable ,bool>>func)
        {
            return Connect.CreatConnect().Query<FatherMenuTable>(func);
        }
        public static FatherMenuTable GetOneFatherMenuTable(Expression<Func<FatherMenuTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<FatherMenuTable>(func);
         }
        public static void InsertFatherMenuTablelst(List<FatherMenuTable> FatherMenuTableObjs)
         {
              Connect.CreatConnect().Insert<FatherMenuTable>(FatherMenuTableObjs);
         }
        public static void InsertFatherMenuTable(FatherMenuTable FatherMenuTableObj)
         {
              Connect.CreatConnect().Insert<FatherMenuTable>(FatherMenuTableObj);
         }
        public static void UpdateFatherMenuTable(FatherMenuTable FatherMenuTableObj, Expression<Func<FatherMenuTable, bool>> func)
         {
              Connect.CreatConnect().Update<FatherMenuTable>(FatherMenuTableObj,func);
         }
        public static void DeleteFatherMenuTable(Expression<Func<FatherMenuTable, bool>> func)
         {
              Connect.CreatConnect().Delete<FatherMenuTable>(func);
         }
    }
}
