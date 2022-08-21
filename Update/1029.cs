using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1029

    {
        public static void UpdateToV10210()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.9"))
            {
                AddSaleTable();
                AddCaigoutuihuoTable();
                AddSaleTuihuoTable();
                AddweiwaiTable();
                AddweiwaijiagongTable();
                Console.WriteLine("创建列成功");
                verinfo.Version = "1.0.2.10";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }    
        private static void AddSaleTable()
        {
            var cols = Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == "采购单列表");
            foreach (var c in cols )
            {
                c.FormName = "销售发货列表";
                Connect.CreatConnect().Insert<ColumnTable>(c);
            }
        }
        private static void AddCaigoutuihuoTable()
        {
            var cols = Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == "采购单列表");
            foreach (var c in cols)
            {
                c.FormName = "采购退货列表";
                Connect.CreatConnect().Insert<ColumnTable>(c);
            }
        }
        private static void AddSaleTuihuoTable()
        {
            var cols = Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == "采购单列表");
            foreach (var c in cols)
            {
                c.FormName = "销售退货列表";
                Connect.CreatConnect().Insert<ColumnTable>(c);
            }
        }
        private static void AddweiwaiTable()
        {
            var cols = Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == "采购单列表");
            foreach (var c in cols)
            {
                c.FormName = "委外取货列表";
                Connect.CreatConnect().Insert<ColumnTable>(c);
            }
        }
        private static void AddweiwaijiagongTable()
        {
            var cols = Connect.CreatConnect().Query<ColumnTable>(x => x.FormName == "采购单列表");
            foreach (var c in cols)
            {
                c.FormName = "委外加工单列表";
                Connect.CreatConnect().Insert<ColumnTable>(c);
            }
        }
    }
}
