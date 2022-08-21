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
   public  class 打印打样单
    {
        public List<ShengchandanSeLaodu> colorTables { get; set; } = new List<ShengchandanSeLaodu>();
        public DanjuTable DanjuTable { get; set; } = new DanjuTable();
        public List<ShengchandanHouzhengli> houzhenglis { get; set; } = new List<ShengchandanHouzhengli>();
        public List<ShengChanDanHouZhengLiYaoQiu> yaoqius { get; set; } = new List<ShengChanDanHouZhengLiYaoQiu>();
        public FormInfo formInfo { get; set; } = new FormInfo();
        /// <summary>
        /// 单据明细
        /// </summary>
        public danjumingxitable DocDetail { get; set; }
        public  void 打印(string path,int useful)
        {
            var fs = new FastReport.Report();
            DataSet ds = new DataSet();
            var danjudt = CreateDanjuDatatable.CreateTable(DanjuTable, formInfo, "单据信息", "");
            danjudt.Columns.Add("客户助记词");
            danjudt.Columns.Add("款号");
            danjudt.Rows[0]["款号"] = DocDetail.kuanhao;
            danjudt.Rows[0]["客户助记词"] =DanjuTable.SaleMan !=null ? LXRService.GetOneLXR(x => x.MC == DanjuTable.SaleMan).ZJC:string.Empty ;
            ds.Tables.Add(danjudt );
            ds.Tables.Add(getColorTable());
            ds.Tables.Add(GetYaoqiu());
            ds.Tables.Add(CreateDanjuDatatable.CreateTable<db>(dbService.GetOnedb(x => x.bh == DanjuTable.StockName), new FormInfo() { FormName = "品种资料", GridviewName = "gridview1" }, "布料信息",string.Empty) );
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
      private DataTable getColorTable()
        {
            DataTable dt = new DataTable("颜色信息");
            dt.Columns.Add("颜色");
            dt.Columns.Add("颜色要求");
            foreach (var y in colorTables )
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["颜色"] = y.Yaoqiu ;
                dt.Rows[dt.Rows.Count - 1]["颜色要求"] = y.Selaodu ;
            }
            return dt;
        }
        private DataTable GetYaoqiu()
        {
            DataTable dt = new DataTable("要求");
            dt.Columns.Add("色卡");
            dt.Columns.Add("光学");
            dt.Columns.Add("尺寸");
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
            dt.Rows[0]["光学"] =yaoqius.Where(x=>x.HouZhengLiYaoQiu =="光学要求").ToList()[0].YaoQiu ;
            dt.Rows[0]["尺寸"] = yaoqius.Where(x => x.HouZhengLiYaoQiu == "尺寸要求").ToList()[0].YaoQiu;
            return dt;
        }
    }
}
