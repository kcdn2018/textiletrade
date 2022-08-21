using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1027
    {
        public static void UpdateToV1028()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.7"))
            {
                //增加色号菜单
                AddSehaoMenu();
                Console.WriteLine("增加色号菜单成功");
                AddHuahao();
                Console.WriteLine("增加花号成功");
                verinfo.Version = "1.0.2.7";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }
        /// <summary>
        /// 增加花号
        /// </summary>
        private static void AddSehaoMenu()
        {
            Connect.CreatConnect().Insert<MenuTable>(new MenuTable()
            {
                FatherMenu = "基本资料",
                FormName = "色号资料",
                MenuName = "色号资料",
                Visitable = true,
                UserID = "10001",
            }) ;
        }
        private static void AddHuahao()
        {
            Connect.CreatConnect().DoSQL("alter table juanhaotable add Huahao nvarchar(200)");
            Connect.CreatConnect().DoSQL("update juanhaotable set Huahao=''");
            Connect.CreatConnect().Delete<ColumnTable>(x => x.ColumnText == string.Empty);
        }
    }
}
