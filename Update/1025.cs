using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1025
    {
        public static void UpdateToV1026()
        {
            Connect.Environmen = "公司";
            var verinfo = infoService.Getinfolst()[0];
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.5"))
            {
                Connect.CreatConnect().Insert<ColumnTable>(new ColumnTable()
                {
                    GridName = "gridview1",
                    ColumnText = "用途",
                    ColumnName = "YongTu",
                    DataProperty = "YongTu",
                    Edit = false,
                    FormName = "品种资料",
                    Summary = false,
                    UserID = "10001",
                    Visible = true,
                    VisibleID = -1,
                    Width = 50
                });
                Console.WriteLine("创建用途成功");
                Connect.CreatConnect().Insert<ColumnTable>(new ColumnTable()
                {
                    GridName = "gridview1",
                    ColumnText = "风格",
                    ColumnName = "Fengge",
                    DataProperty = "Fengge",
                    Edit = false,
                    FormName = "品种资料",
                    Summary = false,
                    UserID = "10001",
                    Visible = true,
                    VisibleID = -1,
                    Width = 50
                });
                Console.WriteLine("创建风格成功");
                verinfo.Version = "1.0.2.6";
                更新数据库版本.UpdateInfo (verinfo); 
                
            }
        }
    }
}
