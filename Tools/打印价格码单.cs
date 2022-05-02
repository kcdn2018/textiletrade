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
  public   class 打印价格码单
    {
        public List<JuanHaoTable> Juanhaolist { get; set; }
		public DanjuTable DanjuTable { get; set; }
		public List<danjumingxitable> Danjumingxitables { get; set; }
		public FormInfo Danjuinfo { get; set; } = new FormInfo();
		public FormInfo Mingxiinfo { get; set; } = new FormInfo();
		/// <summary>
		/// 公司名称
		/// </summary>
		public string Gsmc { get; set; }
		public void Print(string path, int model,bool IsPrintPrice)
		{
			DataSet ds = new DataSet();			
			DataTable MingxiDT = CreateDanjuDatatable.CreateTable(Danjumingxitables, Mingxiinfo);
			MingxiDT.Columns.Add("细码",typeof (string));
			MingxiDT.Columns.Add("价格1");
			MingxiDT.Columns.Add("合计金额1");
			for (var row=0;row< MingxiDT.Rows.Count ;row++ )
            {
                var mingxi = Danjumingxitables[row];
                MingxiDT.Rows[row]["价格1"] = IsPrintPrice ? mingxi.hanshuidanjia.ToString("C1") : string.Empty;
				MingxiDT.Rows[row]["合计金额1"] = IsPrintPrice ? mingxi.hanshuiheji .ToString("C1") : string.Empty;
				foreach (var j in Juanhaolist.Where(x => x.SampleNum == mingxi.Bianhao && x.yanse == mingxi.yanse && x.Houzhengli == mingxi.houzhengli && x.GangHao == mingxi.ganghao &&
               x.ColorNum == mingxi.ColorNum && x.kuanhao == mingxi.kuanhao && x.OrderNum == mingxi.OrderNum && x.Huahao == mingxi.Huahao).ToList())
                {
                    MingxiDT.Rows[row]["细码"] += j.biaoqianmishu.ToString("N1") + "，";
                }
                MingxiDT.Rows[row]["细码"] = MingxiDT.Rows[row]["细码"].ToString().Substring(0, MingxiDT.Rows[row]["细码"].ToString().Length - 1);
            }
			ds.Tables.Add(CreateDanjuDatatable.CreateTable(DanjuTable, Danjuinfo, "单据信息", ""));
			ds.Tables.Add(MingxiDT );
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
