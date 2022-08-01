using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统;

namespace Tools
{
    public class 打印报关单
    {
        public BaoGuanTable baoguandan { get; set; }
        public List<danjumingxitable> mingxis { get; set; }
        public List<JuanHaoTable> juanHaos { get; set; }
        public virtual void Print(int model)
        {
            foreach (var mx in mingxis.Select(x => x.Bianhao).Distinct().ToList())
            {
                FastReport.Report fs = new FastReport.Report();
                var madan = new 打印成品码单() { danjumingxitables = mingxis, juanHaoTables = juanHaos };
                DataSet ds = new DataSet();
                var path = Application.StartupPath + "\\Report\\报关单.frx";
                try
                {
                    ds.Tables.Add(CreateDanjuDatatable.CreateTable(mingxis.Where(x => x.Bianhao == mx).ToList(), new FormInfo() { FormName = "销售发货单", GridviewName = "gridView1" }));
                    ds.Tables.Add(madan.CreatMadanDetail(mingxis.Where(x => x.Bianhao == mx).ToList()[0]));
                    ds.Tables.Add(CreatBaoGuanDan());
                   if( File.Exists(path))
                    {
                        fs.RegisterData(ds);
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
                   else
                    {
                        fs.RegisterData(ds);
                        fs.Design();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("检测到打印的是否发生了错误！" + ex.Message);
                    fs.Design();
                }
            }
        }
        /// <summary>
        /// 生成报关单数据
        /// </summary>
        /// <returns></returns>
        private DataTable CreatBaoGuanDan()
        {
            return CreateDanjuDatatable.CreateTable<BaoGuanTable>(baoguandan, new FormInfo() { FormName = "报关单列表", GridviewName = "gridView1" }, "报关单信息", this.baoguandan.CompanyName);
        }
    }
}
