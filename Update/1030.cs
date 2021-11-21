using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1030

    {
        public static void UpdateToV10211()
        {
            var verinfo = infoService.Getinfolst()[0];
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.10"))
            {
                AddSekakucun();
                色卡采购();
                色卡盘亏();
                色卡盘盈();
                色卡销售();
                寄件列表();
                Console.WriteLine("创建菜单成功");
                verinfo.Version = "1.0.2.11";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }    
        private static void AddSekakucun()
        {
            var menu = new MenuTable { FatherMenu = "库存管理", FormName = "色卡库存", MenuName = "色卡库存", UserID = "10001", Visitable = true };
            Connect.CreatConnect().Insert<MenuTable>(menu);
        }
        private static void 色卡采购()
        {
            var menu = new MenuTable { FatherMenu = "采购管理", FormName = "色卡采购", MenuName = "色卡采购单", UserID = "10001", Visitable = true };
            Connect.CreatConnect().Insert<MenuTable>(menu);
        }
        private static void 色卡销售()
        {
            var menu = new MenuTable { FatherMenu = "销售管理", FormName = "色卡销售", MenuName = "色卡销售单", UserID = "10001", Visitable = true };
            Connect.CreatConnect().Insert<MenuTable>(menu);
        }
        private static void 色卡盘盈()
        {
            var menu = new MenuTable { FatherMenu = "库存管理", FormName = "色卡盘盈", MenuName = "色卡盘盈单", UserID = "10001", Visitable = true };
            Connect.CreatConnect().Insert<MenuTable>(menu);
        }
        private static void 色卡盘亏()
        {
            var menu = new MenuTable { FatherMenu = "库存管理", FormName = "色卡盘亏", MenuName = "色卡盘亏单", UserID = "10001", Visitable = true };
            Connect.CreatConnect().Insert<MenuTable>(menu);
        }
        private static void 寄件列表()
        {
            var l = Connect.CreatConnect().Query<MenuTable>(x => x.FormName == "寄件列表");
            if (l.Count == 0)
            {
                var menu = new MenuTable { FatherMenu = "财务管理", FormName = "寄件列表", MenuName = "寄件列表", UserID = "10001", Visitable = true };
                Connect.CreatConnect().Insert<MenuTable>(menu);
            }
        }
    }
}
