using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public class AddColumn
    {
        /// <summary>
        /// 新增字段
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="ColumnName">字段名</param>
        /// <param name="columntype">字段类型</param>
        /// <param name="value">默认值</param>
        public static void AddNewColumn(string tablename,string ColumnName,string columntype,string value)
        {
            Connect.CreatConnect().DoSQL($"alter table {tablename} add  {ColumnName } {columntype }" );
            Connect.CreatConnect().DoSQL($"update {tablename } set  {ColumnName } ={value}");
        }
    }
}
