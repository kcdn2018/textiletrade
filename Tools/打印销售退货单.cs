using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Tools
{
  public   class 打印销售退货单
    {
		public DanjuTable danjuTable { get; set; }
		public List<danjumingxitable> danjumingxitables { get; set; }
		public FormInfo danjuinfo { get; set; } = new FormInfo();
		public FormInfo mingxiinfo { get; set; } = new FormInfo();
		public void Print(string path, int model)
		{
			DataSet ds = new DataSet();
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjuTable, danjuinfo, "单据信息", ""));
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjumingxitables, mingxiinfo));
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
