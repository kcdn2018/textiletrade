using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public  class 打印白坯码单
    {
        public DanjuTable Danju { get; set; }
        public List<FabricMadan>juanhaolist { get; set; }
        public FormInfo FormInfo { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string gsmc { get; set; }
        /// <summary>
        /// 单据明细
        /// </summary>
        public List<danjumingxitable> Danjumingxitables { get; set; } = new List<danjumingxitable>();
        /// <summary>
		/// 创建单据DataTable
		/// </summary>
		/// <returns></returns>
      private DataTable CreatDanjuDT()
        {
            var dt = CreateDanjuDatatable.CreateTable(Danju, FormInfo, "单据信息", gsmc);
            return dt;
        }
        private DataTable CreateMadan()
        {
            DataTable dt = new DataTable("码单明细");
            var madan = new FabricMadan();
            var pros = madan.GetType().GetProperties();
            foreach (var p in pros)
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }
            foreach (var j in juanhaolist )
            {
                var row = dt.Rows.Add();
                pros = j.GetType().GetProperties();
                foreach (var p in pros )
                {
                    row[p.Name] = p.GetValue(j, null);
                }
            }
            return dt;
        }
        public void Print(int model, string path)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(CreatDanjuDT());
            ds.Tables.Add(CreateMadan());
            ds.Tables.Add(CreateDanjuDatatable.CreateTable(Danjumingxitables.Where(x =>!string.IsNullOrEmpty ( x.pingming) ).ToList(), new FormInfo() { FormName = "白坯销售单", GridviewName = "gridView1" }));
            var fs = new FastReport.Report();
            fs.RegisterData(ds);
            try
            {
                fs.Load(path);
                switch (model)
                {
                    case PrintModel.Design:
                        fs.Design();
                        var arr = path.Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.报表);
                        ReportService.LoadReport(path, new ReportTable { reportStyle = ReportService.报表, reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                    case PrintModel.Print:
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
