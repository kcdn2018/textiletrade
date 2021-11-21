using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ChiDianTableService
    {
        public static List<ChiDianTable> GetChiDianTablelst(Expression<Func<ChiDianTable  ,bool>> func)
         {
            return  Connect.CreatConnect().Query<ChiDianTable>(func);
         }
        public static ChiDianTable GetOneChiDianTable(Expression<Func<ChiDianTable  ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ChiDianTable>(func);
         }
        public static void InsertChiDianTablelst(List<ChiDianTable> ChiDianTableObjs)
         {
            foreach(ChiDianTable OBJ in ChiDianTableObjs)
             {
              Connect.CreatConnect().Insert<ChiDianTable>(OBJ);
             }
         }
        public static void InsertChiDianTable(ChiDianTable ChiDianTableObj)
         {
              Connect.CreatConnect().Insert<ChiDianTable>(ChiDianTableObj);
         }
        public static void UpdateChiDianTable(ChiDianTable ChiDianTableObj,Expression<Func<ChiDianTable  ,bool>> func)
         {
              Connect.CreatConnect().Update<ChiDianTable>(ChiDianTableObj,func);
         }
        public static void DeleteChiDianTable(Expression<Func<ChiDianTable  ,bool>> func)
         {
              Connect.CreatConnect().Delete<ChiDianTable>(func);
         }
    }
}
