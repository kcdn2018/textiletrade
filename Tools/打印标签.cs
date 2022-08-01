using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public static  class 打印标签
    {
        public static void 打印(decimal Num,db pingzhong,PrintSetting printSetting,List <ShengChengGongYi > shengChengGongYis,JiYangBaoJia jiYangBaoJia   )
        {
            var dt = new DataTable() { TableName ="品种信息"};
            dt.Columns.Add("数量", typeof(decimal));
            dt.Columns.Add("合同号");
            dt.Columns.Add("款号");
            dt.Columns.Add("单位");
            dt.Columns.Add("特点说明");
            var collist = Connect.GetColumntable("品种资料", "gridView1","10001");
            foreach (ColumnTable column in collist )
            {
                dt.Columns.Add(column.ColumnText);
            }
            dt.Rows.Add();
            var pro = pingzhong.GetType().GetProperties();
            foreach (PropertyInfo p in pro )
            {
                if (collist.Where<ColumnTable>(x => x.DataProperty == p.Name).ToList().Count > 0)
                {
                    dt.Rows[0][collist.Where<ColumnTable>(x => x.DataProperty == p.Name).ToList()[0].ColumnText] = p.GetValue(pingzhong, null);
                }
            }
            dt.Rows[0]["数量"] = Num;
            dt.Rows[0]["合同号"] = jiYangBaoJia.Hetonghao;
            dt.Rows[0]["款号"] = jiYangBaoJia.Kuanhao;
            dt.Rows[0]["单位"] = jiYangBaoJia.Danwei;
            dt.Rows[0]["特点说明"] = pingzhong.Characteristic;
            try
            {
                dt.Rows[0]["日期"] = pingzhong.rq.ToString("d");
            }
            catch 
            {
               
            }
            var gongyidt = new DataTable("后整理信息");
            gongyidt.Columns.Add("加工单位");
            gongyidt.Columns.Add("加工工艺");
            gongyidt.Columns.Add("加工要求");
            gongyidt.Columns.Add("单价");
            foreach (var g in shengChengGongYis )
            {
                var row = gongyidt.NewRow();
                row["加工单位"] = g.JGDW;
                row["加工工艺"] = g.JGGY;
                row["加工要求"] = g.JGBH;
                row["单价"] = g.JG; 
                gongyidt.Rows.Add(row);
            }
            var fs = new FastReport.Report ();
            var ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(gongyidt);
            fs.RegisterData(ds);
          try
            {  
                fs.Load(printSetting.Path );        
                switch (printSetting.Printmodel)
                {
                    case PrintModel.Design:
                        fs.Design();
                        var arr = printSetting .Path .Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.标签);
                        ReportService.LoadReport(printSetting.Path, new ReportTable { reportStyle = ReportService.标签 , reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Print:
                        fs.PrintSettings.ShowDialog = false;
                        fs.PrintSettings.Printer = printSetting.PrintName;
                        fs.PrintSettings.Copies = printSetting.PrintNum;
                        fs.Print();
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                }
            }
            catch
            {
                fs.Design();
            }
        }
    }
}
