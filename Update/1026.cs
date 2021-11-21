using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V1026
    {
        public static void UpdateToV1027()
        {
            var verinfo = infoService.Getinfolst()[0];
            if (Version.Parse(verinfo.Version ) == Version.Parse("1.0.2.6"))
            {
                var sqliteconn = Connect.CreatSqlite();
                SQLiteCommand sQLiteCommand = new SQLiteCommand() { CommandText = "Create table Setting ('fornname' text,'settingname' text,'settingValue' text)", Connection = sqliteconn };
                sQLiteCommand.ExecuteNonQuery();
                Console.WriteLine("创建设置表成功");
                verinfo.Version = "1.0.2.7";
               更新数据库版本.UpdateInfo(verinfo);
            }
        }
    }
}
