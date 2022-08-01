using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
  public  class AddNewMenu
    {
        /// <summary>
        /// 增加新菜单
        /// </summary>
        /// <param name="MenuName"></param>
        public static void Add(MenuTable menu )
        {
            var dbhelper = Connect.SoftkcDBHelper();
            var dt = Connect.DbHelper().Queryable<MenuTable>().Where(x => x.FormName == menu.MenuName ).ToList();
            if (dt.Count == 0)
            {
                Console.WriteLine("正在创建" + menu.MenuName + "菜单功能，请等待。。。。。。");
                var yhs = Connect.CreatConnect().Query<Yhb>();
                foreach (var yh in yhs)
                {
                    menu.UserID = yh.YHBH;
                    Connect.CreatConnect().Insert<MenuTable>(menu );
                    AddNewForm(menu.FormName);
                }
            }
        }
        public static void AddNewForm(string Formname)
        {
            var dbhelper = Connect.SoftkcDBHelper();
            var yhs = Connect.CreatConnect().Query<Yhb>();
            foreach (var yh in yhs)
            {
                var columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == Formname ).ToList();
                columns.ForEach(x => x.UserID = yh.YHBH);
                if (Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == Formname).Count == 0)
                {
                    Connect.CreatConnect().Insert<ColumnTable>(columns);
                }
            }
        }
    }
}
