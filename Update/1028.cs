using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1028

    {
        public static void UpdateToV1029()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.8"))
            {
                AddSettingTable();
                Console.WriteLine("创建设置表成功");
                verinfo.Version = "1.0.2.9";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }    
        private static void AddSettingTable()
        {
            Connect.CreatConnect().DoSQL("Create table Setting (SettingName nvarchar(200),SettingValue nvarchar(200),[ID] [int] IDENTITY(1,1) NOT NULL)");          
        }
    }
}
