using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public   class 打印唛头
    { 
        public  string PrinterName { get; set; }
        public  decimal copyies { get; set; }
        public string moban { get; set; }
        public JuanHaoTable juan { get; set; }
        public int userful { get; set; }
        private DataTable CreatMaitouDt()
        {
            DataTable dt = new DataTable("唛头信息");
            dt.Columns.Add("订单号");
            dt.Columns.Add("缸号");
            dt.Columns.Add("卷号");
            dt.Columns.Add("合同号");
            dt.Columns.Add("毛米数", typeof(decimal));
            dt.Columns.Add("品名");
            dt.Columns.Add("规格");
            dt.Columns.Add("门幅");
            dt.Columns.Add("克重");
            dt.Columns.Add("颜色");
            dt.Columns.Add("日期",typeof(DateTime ));
            dt.Columns.Add("成分");
            dt.Columns.Add("单位");
            dt.Columns.Add("缸卷");
            dt.Columns.Add("等级");
            dt.Columns.Add("备注");
            dt.Columns.Add("码数", typeof(decimal));
            dt.Columns.Add("净米数",typeof(decimal ));
            dt.Columns.Add("净码数",typeof(decimal));
            dt.Columns.Add("合计扣米数", typeof(decimal));
            dt.Columns.Add("款号");
            dt.Columns.Add("后整理");
            dt.Columns.Add("英文名");
            dt.Columns.Add("客户品名");
            dt.Columns.Add("客户色号");
            dt.Columns.Add("色号");
            dt.Columns.Add("条码信息");
            dt.Columns.Add("疵点"); 
            dt.Columns.Add("客户名称");
            dt.Columns.Add("花号");
            dt.Columns.Add("布料编号");
            dt.Columns.Add("检验员");
            return dt;
        }
        private DataTable 赋值(DataTable dt)
        {
            dt.Rows.Add();
            db buliao = new db { EnglishName=string.Empty ,cf=string.Empty } ;
            if (!string.IsNullOrEmpty(juan.SampleNum))
            {
                 buliao = dbService.GetOnedb(x => x.bh == juan.SampleNum);
            }
            dt.Rows[0]["订单号"]=juan.OrderNum ;
            dt.Rows[0]["缸号"]=juan.GangHao ;
            dt.Rows[0]["卷号"]=juan.JuanHao  ;
            dt.Rows[0]["合同号"]=juan.Hetonghao ;
            dt.Rows[0]["毛米数"]=juan.MiShu.ToString("N1") ;
            dt.Rows[0]["品名"]=juan.SampleName ;
            dt.Rows[0]["规格"]=juan.guige ;
            dt.Rows[0]["门幅"]=juan.Menfu ;
            dt.Rows[0]["克重"]=juan.Kezhong ;
            dt.Rows[0]["颜色"]=juan.yanse ;
            dt.Rows[0]["日期"]=juan.rq ;
            dt.Rows[0]["成分"]=buliao .cf ;
            dt.Rows[0]["单位"]=juan.Danwei ;
            dt.Rows[0]["缸卷"]=juan.PiHao ;
            dt.Rows[0]["等级"]=juan.DengJI ;
            dt.Rows[0]["备注"]=string.Empty;
            dt.Rows[0]["码数"]=(juan.biaoqianmishu /(decimal )0.9144).ToString("N1");
            dt.Rows[0]["净米数"]=juan.biaoqianmishu.ToString("N1");
            dt.Rows[0]["净码数"]=(juan.biaoqianmishu /(decimal)0.9144).ToString("N1");
            dt.Rows[0]["合计扣米数"]=juan.SumKouFeng.ToString("N1");
            dt.Rows[0]["款号"]=juan.kuanhao ;
            dt.Rows[0]["后整理"]=juan.Houzhengli ;
            dt.Rows[0]["英文名"]=buliao .EnglishName ;
            dt.Rows[0]["客户品名"]=juan.CustomerPingMing ;
            dt.Rows[0]["客户色号"]=juan.CustomerColorNum ;
            dt.Rows[0]["色号"]=juan.ColorNum ;
            dt.Rows[0]["条码信息"]= juan.CustomerPingMing+juan.yanse +juan.OrderNum  +string.Format ("{0:000.00}", juan.biaoqianmishu).Replace(".", "") + juan.GangHao + string.Format("{0:000}", juan.PiHao) ;
            dt.Rows[0]["疵点"]=juan.Cidian;
            dt.Rows[0]["花号"] = juan.Huahao ;
            dt.Rows[0]["布料编号"] = juan.SampleNum ;
            dt.Rows[0]["客户名称"] = juan.CustomerName ;
            dt.Rows[0]["检验员"] = juan.CheckID ;
            return dt;
        }
        public  void 打印( )
        {
            var dt = CreatMaitouDt();
            dt = 赋值(dt);
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);
            var fs = new FastReport.Report();
           
            fs.RegisterData(dataSet);     
            try
            {
                fs.Load(moban); 
                switch (userful )
                {
                    case PrintModel.Design:
                        fs.Design();
                        var arr = moban .Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.唛头);
                        ReportService.LoadReport(moban , new ReportTable { reportStyle = ReportService.唛头, reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                    case PrintModel.Print:
                        fs.PrintSettings.Printer = PrinterName;
                        fs.PrintSettings.Copies  =(int) copyies;
                        fs.PrintSettings.ShowDialog = false;
                        fs.Print();
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
