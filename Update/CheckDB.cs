using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
  public   class CheckDB
     
    {

        public static void dbcompar()
        {

            var remortdb = new SqlSugar.SqlSugarClient(new SqlSugar.ConnectionConfig() {ConnectionString= "Server=softkc.cn,1433;uid=sa;pwd=Kc123456;database=Fricedb",DbType=SqlSugar.DbType.SqlServer  });
            var localdb = Connect.DbHelper();
            var dBNames = remortdb.Ado.SqlQuery<DBName>("SELECT Name FROM  SysObjects Where XType='U' ORDER BY Name");
            foreach (var dbname in dBNames)
            {
                var dbnamedt = localdb.Ado.GetDataTable($"select count(*) from { Connect.DBName }.dbo.sysobjects where id = object_id('{ Connect.DBName  }.dbo.{ dbname.Name }')");
                SqlConnection sconn = new SqlConnection(remortdb.CurrentConnectionConfig.ConnectionString);
                sconn.Open();
                if ((int)dbnamedt.Rows[0][0] == 0)
                {
                    localdb.Ado.ExecuteCommand($"Create table { dbname.Name } ([ID] [int] IDENTITY(1,1) NOT NULL)");
                }
                string[] restrictionValues = new string[4];
                restrictionValues[0] = null; // Catalog
                restrictionValues[1] = null; // Owner
                restrictionValues[2] = dbname.Name;  // Table
                restrictionValues[3] = null; // Column
                var dt = sconn.GetSchema(SqlClientMetaDataCollectionNames.Columns, restrictionValues).AsEnumerable().Select(X => new TableStructure()
                {
                    COLUMN_NAME = X["COLUMN_NAME"].ToString(),
                    DATA_TYPE = X["DATA_TYPE"].ToString(),
                    IS_NULLABLE = X["IS_NULLABLE"].ToString(),
                    CHARACTER_MAXIMUM_LENGTH = X["CHARACTER_MAXIMUM_LENGTH"].ToString(),
                    NUMERIC_PRECISION = X["NUMERIC_PRECISION"].ToString(),
                    NUMERIC_SCALE = X["NUMERIC_SCALE"].ToString()
                }).ToList();
                SqlConnection lconn = new SqlConnection(localdb.CurrentConnectionConfig.ConnectionString);
                lconn.Open();
                var local = lconn.GetSchema(SqlClientMetaDataCollectionNames.Columns, restrictionValues).AsEnumerable().Select(X => new TableStructure()
                {
                    COLUMN_NAME = X["COLUMN_NAME"].ToString(),
                    DATA_TYPE = X["DATA_TYPE"].ToString(),
                    IS_NULLABLE = X["IS_NULLABLE"].ToString(),
                    CHARACTER_MAXIMUM_LENGTH = X["CHARACTER_MAXIMUM_LENGTH"].ToString()
                }).ToList();
               
                foreach (var col in dt)
                { 
                    if (local.Where(x => x.COLUMN_NAME.ToLower() == col.COLUMN_NAME.Replace("/","").ToLower()).ToList().Count == 0)
                    {
                        if (col.DATA_TYPE == "nvarchar")
                        {
                            localdb.Ado.ExecuteCommand($"alter table {dbname.Name  } add {col.COLUMN_NAME } {col.DATA_TYPE }({col.CHARACTER_MAXIMUM_LENGTH })");
                            localdb.Ado.ExecuteCommand($"update  {dbname.Name  } set {col.COLUMN_NAME }=''");
                        }
                        else
                        {
                            if (col.DATA_TYPE == "decimal")
                            {
                                localdb.Ado.ExecuteCommand($"alter table {dbname.Name  } add {col.COLUMN_NAME } {col.DATA_TYPE }({col.NUMERIC_PRECISION },{col.NUMERIC_SCALE })");
                                localdb.Ado.ExecuteCommand($"update {dbname.Name  } set {col.COLUMN_NAME } =0");
                            }
                            else
                               if (col.DATA_TYPE == "datetime")
                            {
                                localdb.Ado.ExecuteCommand($"alter table {dbname.Name  } add {col.COLUMN_NAME } {col.DATA_TYPE }");
                                localdb.Ado.ExecuteCommand($"update  {dbname.Name  } set {col.COLUMN_NAME }='{DateTime.Now }'");
                            }
                            else
                             if (col.DATA_TYPE == "bit")
                            {
                                localdb.Ado.ExecuteCommand($"alter table {dbname.Name  } add {col.COLUMN_NAME } {col.DATA_TYPE }");
                                localdb.Ado.ExecuteCommand($"update  {dbname.Name  } set {col.COLUMN_NAME }='{1 }'");
                            }
                        }
                    }

                }
                lconn.Close();
                lconn.Dispose();
                sconn.Close();
                sconn.Dispose();
            }
        }
    }
}
