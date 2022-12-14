using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
  public   class 打印合同
    {
        public OrderTable orderTable { get; set; }
        public List<OrderDetailTable> orderDetailTables { get; set; }
        public void Print(string path,int model,string CompanyName)
        {
			DataSet ds = new DataSet();
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(orderTable , new FormInfo() { FormName ="销售计划单查询", GridviewName="gridView1"}, "单据信息", CompanyName));
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(orderDetailTables, new FormInfo() { FormName = "销售计划单", GridviewName = "gridView1" }, "单据明细"));
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
