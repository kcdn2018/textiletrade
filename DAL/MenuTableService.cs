using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class MenuTableService
    {
        public static List<MenuTable> GetMenuTablelst(Expression<Func<MenuTable,bool >> func)
         {
            return  Connect.CreatConnect().Query<MenuTable>(func);
         }
        public static List<MenuTable> GetMenuTablelst()
        {
            return Connect.CreatConnect().Query<MenuTable>();
        }
        public static MenuTable GetOneMenuTable(Expression<Func<MenuTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<MenuTable>(func);
         }
        public static void InsertMenuTablelst(List<MenuTable> MenuTableObjs)
         {
              Connect.CreatConnect().Insert<MenuTable>(MenuTableObjs);
         }
        public static void InsertMenuTable(MenuTable MenuTableObj)
         {
              Connect.CreatConnect().Insert<MenuTable>(MenuTableObj);
         }
        public static void UpdateMenuTable(MenuTable MenuTableObj, Expression<Func<MenuTable, bool>> func)
         {
              Connect.CreatConnect().Update<MenuTable>(MenuTableObj,func);
         }
        public static void DeleteMenuTable(Expression<Func<MenuTable, bool>> func)
         {
              Connect.CreatConnect().Delete<MenuTable>(func);
         }
    }
}
