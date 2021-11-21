using DAL;
using Model;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
namespace 纺织贸易管理系统
{
    public static class Connect
    {
        public static string Environmen ;
        public static void SetDefault(string LabelName)
        {
            var sqliteconn = CreatSqlite();
            SQLiteCommand sQLiteCommand = new SQLiteCommand() { CommandText = $"update DefaultLabel set LabelName='{LabelName }'", Connection = sqliteconn };
            sQLiteCommand.ExecuteNonQuery();
        }
        public static List<DefaultLabel> GetDefault()
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            var sqliteconn = CreatSqlite();
            DataTable dt = new DataTable();
            SQLiteDataAdapter dp = new SQLiteDataAdapter("select * from DefaultLabel", sqliteconn);
            dp.Fill(dt);
            return SQLHelper.SqlSugor .ChangToModel<DefaultLabel>(dt);
        }
        public static SQLiteConnection CreatSqlite()
        {
            SQLiteConnection sqlconn = new SQLiteConnection();
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder
            {
                DataSource = System.Environment.CurrentDirectory + "\\Config.db"
            };
            sqlconn.ConnectionString = connstr.ToString();
            sqlconn.Open();
            return sqlconn;
        }
        public static DataTable  GetFormName()
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            return db.Query("select distinct FormName from ColumnTable where UserID='10001'");
           
        }
        public static DataTable  GetGridName(string FormName)
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            return db.Query($"select distinct GridName from ColumnTable where UserID='10001' and FormName='{FormName}'");
            
        }
        public static List<ColumnTable> GetColumntable(string formname, string gridname, string userid)
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            return db.Query<ColumnTable>(x => x.FormName == formname && x.GridName == gridname && x.UserID == userid);
            //var sqliteconn = CreatSqlite();
            //SQLiteDataAdapter dp = new SQLiteDataAdapter($"select * from ColumnTable", sqliteconn);
            //DataTable dt = new DataTable();
            //dp.Fill(dt);         
            //return  db.ChangToModel<ColumnTable>(dt).Where<ColumnTable >(x=>x.FormName ==formname &&x.GridName ==gridname ).ToList ();
        }
        public static ColumnSetting GetColumnSetting()
        {
            var sqliteconn = CreatSqlite();
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            SQLiteDataAdapter dp = new SQLiteDataAdapter($"select * from ColumnSetting", sqliteconn);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            return SQLHelper.SqlSugor.ChangToModel<ColumnSetting >(dt).ToList()[0];
        }
        //设定奇数行颜色
        public static void SetOddColor(string color)
        {
            var sqliteconn = CreatSqlite();
            SQLiteCommand sQLiteCommand = new SQLiteCommand() { CommandText = $"Update ColumnSetting set OddColor='{color }'", Connection = sqliteconn };
            sQLiteCommand.ExecuteNonQuery();
        }
        //设定偶数行颜色
        public static void SetEvenColor(string color)
        {
            var sqliteconn = CreatSqlite();
            SQLiteCommand sQLiteCommand = new SQLiteCommand() { CommandText = $"Update ColumnSetting set EvenColor='{color }'", Connection = sqliteconn };
            sQLiteCommand.ExecuteNonQuery();
        }
        //
        public static void SaveColumnTable(List<ColumnTable > collist)
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            var sqliteconn = CreatSqlite();                   
             db.Insert<ColumnTable>(collist );
        }
        public static void DeleteColumnTable(string formname,string gridname,string userid)
        {
            var db = new SQLHelper.SQLHelper(CreatConnectstring());
            db.Delete<ColumnTable>(x => x.FormName == formname &&x.GridName == gridname&&x.UserID==userid);
            //var sqliteconn = CreatSqlite();
            //SQLiteCommand sQLiteCommand = new SQLiteCommand() { CommandText =$"delete from ColumnTable where formname='{formname}' and GridName='{gridname }'", Connection = sqliteconn };
            //sQLiteCommand.ExecuteNonQuery();
        }
        private static DataTable GetSqlite()
        {
            var sqliteconn = CreatSqlite();
            SQLiteDataAdapter dp = new SQLiteDataAdapter($"select * from linkinfo where Environment='{Environmen}'", sqliteconn);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            return dt;
        }
        private  static string CreatConnectstring()
        {
            var sqliteconn = CreatSqlite();
            SQLiteDataAdapter dp = new SQLiteDataAdapter($"select * from linkinfo where Environment='{Environmen}'", sqliteconn);
            DataTable dt = new DataTable();
            dp.Fill(dt);
           
            if (dt.Rows.Count >0)
            {
               return $"server={dt.Rows[0]["server"]},{dt.Rows[0]["port"]};uid={dt.Rows[0]["username"]};pwd={dt.Rows[0]["PWD"]};database={dt.Rows[0]["database"]}";
            }
            else
            {
                return "";
            }
        }
        public static SqlSugar.SqlSugarClient  DbHelper()
        {
            return new SqlSugar.SqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                ConnectionString = CreatConnectstring(),
                DbType = SqlSugar.DbType.SqlServer,
                IsAutoCloseConnection = true,
            }) ;
        }
        public static SQLHelper.SQLHelper CreatConnect()
        {
           return  new SQLHelper.SQLHelper(CreatConnectstring());
        }
        public static SQLHelper.SQLHelper CreatRemortConnect()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("LinkInfo.xml");
            var conn = new SQLHelper.ConnectInfo
            {
                Database = xml.SelectSingleNode("/Serverdatabase").InnerText,
                Port = xml.SelectSingleNode("/Serverport").InnerText,
                PWD = xml.SelectSingleNode("/Serverpwd").InnerText,
                UID = xml.SelectSingleNode("/Serveruid").InnerText,
                Server = xml.SelectSingleNode("/Serverserver").InnerText
            };
            var db = new SQLHelper.SQLHelper(conn);
            return db;
        }
    }
}
