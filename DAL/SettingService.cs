using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using 纺织贸易管理系统;

namespace DAL
{
  public   class SettingService
    {
        public static Setting GetSetting(Setting setting )
        {
            var sql = $"select * from setting where formname='{setting.formname }' and settingname='{setting.settingname }' limit 1";
            SQLiteDataAdapter dp = new SQLiteDataAdapter(sql, Connect.CreatSqlite());
            DataTable dt = new DataTable();
            dp.Fill(dt);
            //var dt = Connect.GetSqlsugarSqlite().Ado.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return  SQLHelper.SqlSugor.ChangToModel<Setting>(dt)[0];
            }
            else
            {
                return new Setting() { settingValue=setting.settingValue };
            }
        }
        public static void InsertSetting(Setting setting )
        {
            string sql = $"insert into Setting values('{setting.formname }','{setting.settingname }','{setting.settingValue }')";
            SQLiteCommand command = new SQLiteCommand(sql, Connect.CreatSqlite());
            command.ExecuteNonQuery();
        }
        public static void Update(Setting setting )
        {
            string sql = $"delete from Setting where formname='{setting.formname }' and settingname='{setting.settingname }'";
            //string sql = $"update Setting set formname= {setting.formname },settingname= {setting.settingname },settingValue= {setting.settingValue } where formname={setting.formname } and settingname={setting.settingname }";
            SQLiteCommand command = new SQLiteCommand(sql, Connect.CreatSqlite());
            command.ExecuteNonQuery();
            InsertSetting(setting);
        }
        public static Setting GetSetting(Expression<Func<Setting , bool>> func)
        {
            return Connect.CreatConnect().QueryOneResult<Setting>(func);
        }
        public static void UpdateSQLSERVER(Setting setting)
        {
            string sql = $"delete from Setting where  settingname='{setting.settingname }'";
            //string sql = $"update Setting set formname= {setting.formname },settingname= {setting.settingname },settingValue= {setting.settingValue } where formname={setting.formname } and settingname={setting.settingname }";
            Connect.CreatConnect().Delete(sql);
            Connect.CreatConnect ().Insert <Setting>(setting);
        }
    }
}
