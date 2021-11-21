using FastReport;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public  class 打印打样单后整理
    {
        public List<danjumingxitable > colorTables { get; set; } = new List<danjumingxitable >();
        public DanjuTable DanjuTable { get; set; } = new DanjuTable();
        public List<ShengchandanHouzhengli> houzhenglis { get; set; } = new List<ShengchandanHouzhengli>();
        public List<ShengChanDanHouZhengLiYaoQiu> yaoqius { get; set; } = new List<ShengChanDanHouZhengLiYaoQiu>();
        public FormInfo formInfo { get; set; } = new FormInfo();
        public FormInfo mingxiinfo { get; set; } = new FormInfo() {  FormName ="打样单", GridviewName ="gridView1"};
        public  void 打印(string path,int useful)
        {
            var fs = new FastReport.Report();
            DataSet ds = new DataSet();
            ds.Tables.Add(CreateDanjuDatatable.CreateTable(DanjuTable, formInfo,"单据信息",""));
            ds.Tables.Add(CreateDanjuDatatable.CreateTable(colorTables, mingxiinfo));
            ds.Tables.Add(GetYaoqiu());
            try
            {
                fs.RegisterData(ds);
                fs.Load(path);
                switch (useful )
                {
                    case PrintModel.Design:
                        fs.Design();
                        var arr = path.Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.报表);
                        ReportService.LoadReport(path, new ReportTable { reportStyle = ReportService.报表, reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Print :
                        fs.Print ();
                        break;
                    case PrintModel.Privew :
                        fs.Show ();
                        break;
                }
            }
            catch
            {
                fs.Design();
            }
        }
        private DataTable GetYaoqiu()
        {
            DataTable dt = new DataTable("要求");
            dt.Columns.Add("色卡");
            dt.Rows.Add();
            dt.Rows[0]["色卡"] = "请安排色卡";
            int s = 0;
            foreach(var h in houzhenglis )
            {
                if(h.Value ==true )
                {
                    dt.Rows[0]["色卡"] += h.HouzhengliGongyi;
                    s++;
                }
            }
            dt.Rows[0]["色卡"] += " " + s.ToString() + "块色卡";         
            return dt;
        }
    }
}
