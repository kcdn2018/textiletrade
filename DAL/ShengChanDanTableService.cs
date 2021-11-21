using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class ShengChanDanTableService
    {
        public static List<ShengChanDanTable> GetShengChanDanTablelst(Expression<Func<ShengChanDanTable,bool>>func)
         {
            return  Connect.CreatConnect().Query<ShengChanDanTable>(func);
         }
        public static ShengChanDanTable GetOneShengChanDanTable(Expression<Func<ShengChanDanTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengChanDanTable>(func);
         }
        public static void InsertShengChanDanTablelst(List<ShengChanDanTable> ShengChanDanTableObjs)
         {
            foreach(ShengChanDanTable OBJ in ShengChanDanTableObjs)
             {
              Connect.CreatConnect().Insert<ShengChanDanTable>(OBJ);
             }
         }
        public static void InsertShengChanDanTable(ShengChanDanTable ShengChanDanTableObj)
         {
              Connect.CreatConnect().Insert<ShengChanDanTable>(ShengChanDanTableObj);
         }
        public static void UpdateShengChanDanTable(ShengChanDanTable ShengChanDanTableObj, Expression<Func<ShengChanDanTable, bool>> func)
         {
              Connect.CreatConnect().Update<ShengChanDanTable>(ShengChanDanTableObj,func);
         }
        public static void UpdateShengChanDanTable(string UpdateString, Expression<Func<ShengChanDanTable, bool>> func)
        {
            Connect.CreatConnect().Update<ShengChanDanTable>(UpdateString, func);
        }
        public static void DeleteShengChanDanTable(Expression<Func<ShengChanDanTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengChanDanTable>(func);
         }
    }
}
