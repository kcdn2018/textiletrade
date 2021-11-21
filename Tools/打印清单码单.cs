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
  public class 打印清单码单
    {
		public DanjuTable danjuTable { get; set; }
		public List<danjumingxitable> danjumingxitables { get; set; }
		public FormInfo danjuinfo { get; set; } = new FormInfo();
		public FormInfo mingxiinfo { get; set; } = new FormInfo();
		public FormInfo JuanInfo { get; set; } = new FormInfo();
		public List<JuanHaoTable > juanHaoTables { get; set; }
		public string gsmc { get; set; }
		public void Print(string path, int model)
		{
			DataSet ds = new DataSet();
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjuTable, danjuinfo, "单据信息",gsmc));
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjumingxitables, mingxiinfo));
			foreach (var j in juanHaoTables )
            {
				j.MiShu = j.biaoqianmishu + j.SumKouFeng;
            }
			var dt = CreateDanjuDatatable.CreateTable(juanHaoTables, JuanInfo, "卷号明细");
			dt.Columns.Add("疵点信息");
			dt.Columns.Add("卷净重");
			dt.Columns.Add("卷毛重");
			for (int row=0;row<dt.Rows.Count;row++)
            {
				var cidianlist = ChiDianTableService.GetChiDianTablelst(x => x.JuanHao == juanHaoTables[row].JuanHao);
				foreach (var cidian in cidianlist)
				{
					dt.Rows[row]["疵点信息"] = cidian.ChiDianName + "(" + cidian.WeiZhi+","+cidian.ShuLiang+")" ;
			    }
				try
				{
					dt.Rows[row]["卷净重"] =decimal.Parse ( juanHaoTables[row].Menfu) *decimal .Parse ( juanHaoTables[row].Kezhong) * juanHaoTables[row].biaoqianmishu / 100000;
				}
				catch
                {
					dt.Rows[row]["卷净重"] = 0;
                }
				try
				{
					dt.Rows[row]["卷毛重"] = decimal.Parse(juanHaoTables[row].Menfu) * decimal.Parse(juanHaoTables[row].Kezhong) * juanHaoTables[row].MiShu/ 100000;
				}
				catch
				{
					dt.Rows[row]["卷毛重"] = 0;
				}
			}
			ds.Tables.Add(dt);
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
