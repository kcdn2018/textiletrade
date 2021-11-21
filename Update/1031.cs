﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1031

    {
        public static void UpdateToV10212()
        {
            var verinfo = infoService.Getinfolst()[0];
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.11"))
            {
                创建对账();
                Console.WriteLine("创建时候已对账成功");
                verinfo.Version = "1.0.2.12";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }
        public static void 创建对账()
        {
            var columns = new ColumnTable { ColumnName = "IsCheck", ColumnText = "已对账", DataProperty = "IsCheck", Edit = true, FormName = "对账单", GridName = "gridView1", Summary = false, UserID = "10001", Visible = true , VisibleID=30, Width=30 };
            Connect.CreatConnect().Insert<ColumnTable >(columns );
             columns = new ColumnTable { ColumnName = "IsCheck", ColumnText = "已对账", DataProperty = "IsCheck", Edit = true, FormName = "供货商对账单", GridName = "gridView1", Summary = false, UserID = "10001", Visible = true, VisibleID = 30, Width = 30 };
            Connect.CreatConnect().Insert<ColumnTable>(columns);
            Connect.CreatConnect().DoSQL("alter table lwdetail add IsCheck bit");
        }
    }
}
