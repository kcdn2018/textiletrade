using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class WuliuTableService
    {
        public static List<WuliuTable> GetWuliuTablelst(Expression<Func<WuliuTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<WuliuTable>(func);
         }
        public static WuliuTable GetOneWuliuTable(Expression<Func<WuliuTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<WuliuTable>(func);
         }
        public static void InsertWuliuTablelst(List<WuliuTable> WuliuTableObjs)
         {
            foreach(WuliuTable OBJ in WuliuTableObjs)
             {
              Connect.CreatConnect().Insert<WuliuTable>(OBJ);
             }
         }
        public static void InsertWuliuTable(WuliuTable WuliuTableObj)
         {
              Connect.CreatConnect().Insert<WuliuTable>(WuliuTableObj);
         }
        public static void UpdateWuliuTable(WuliuTable WuliuTableObj, Expression<Func<WuliuTable, bool>> func)
         {
              Connect.CreatConnect().Update<WuliuTable>(WuliuTableObj,func);
         }
        public static void DeleteWuliuTable(Expression<Func<WuliuTable, bool>> func)
         {
              Connect.CreatConnect().Delete<WuliuTable>(func);
         }
    }
}
