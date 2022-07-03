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
  public   class 打印检验报告
    {
        public static void PrintReport(int useful, List<JuanHaoTable> juans)
        {
            try
            {
                juans = juans.OrderBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
                var juandt = CreateDT();
                InitDT(ref juandt, juans);
                DataSet ds = new DataSet();
                ds.Tables.Add(juandt);
                ///生成疵点对照字符串
                var cidiandt = new DataTable("疵点名称");
                cidiandt.Columns.Add("疵点名称", typeof(string));
                cidiandt.Rows.Add();
                var cidianlist = string.Empty;
                foreach (var cidian in Connect .DbHelper() .Queryable<CiDianNameTable>().ToList())
                {
                    cidianlist += cidian.Daihao + cidian.CiDianName + ",";
                }
                cidianlist.Remove(cidianlist.Length - 1, 1);
                cidiandt.Rows[0][0] = cidianlist;
                ///
                ds.Tables.Add(cidiandt);
                FastReport.Report fs = new FastReport.Report();
                fs.RegisterData(ds);
                var path = Application.StartupPath + "\\Report\\CheckDoc.frx";
                if (File.Exists(path))
                {
                    fs.Load(path);
                    switch (useful)
                    {
                        case PrintModel.Design:
                            fs.Design();
                            var arr = path.Split('\\');
                            ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.报表);
                            ReportService.LoadReport(path, new ReportTable { reportStyle = ReportService.报表, reportName = arr[arr.Length - 1] });
                            break;
                        case PrintModel.Privew :
                            fs.Show();
                            break;
                        case PrintModel.Print:
                            fs.Print();
                            break;
                    }
                }
                else
                {
                    fs.Design();
                    var arr = path.Split('\\');
                    ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.报表);
                    ReportService.LoadReport(path, new ReportTable { reportStyle = ReportService.报表, reportName = arr[arr.Length - 1] });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 生成表结构
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateDT()
        {
            DataTable dt = new DataTable("检验报告");
            dt.Columns.Add("缸号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("物料编号", typeof(string));
            dt.Columns.Add("卷号", typeof(string));
            dt.Columns.Add("颜色", typeof(string));
            dt.Columns.Add("实长", typeof(int));
            dt.Columns.Add("拼接位置", typeof(decimal));
            dt.Columns.Add("幅宽", typeof(string));
            dt.Columns.Add("等级", typeof(string));
            dt.Columns.Add("赠送", typeof(decimal));
            dt.Columns.Add("检验日期", typeof(DateTime));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("订单号", typeof(string));
            dt.Columns.Add("合同号", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("客户名称", typeof(string));
            dt.Columns.Add("款号", typeof(string));
            for (int col = 0; col < 18; col++)
            {
                dt.Columns.Add("代码" + col.ToString(), typeof(string));
                dt.Columns.Add("位置" + col.ToString(), typeof(decimal));
                dt.Columns.Add("扣分" + col.ToString(), typeof(int));
            }
            dt.Columns.Add("备注", typeof(string));
            dt.Columns.Add("总分", typeof(int));
            return dt;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="juandt"></param>
        /// <param name="juans"></param>
        private static void InitDT(ref DataTable juandt, List<JuanHaoTable> juans)
        {
            var chidiannames =Connect. DbHelper().Queryable<CiDianNameTable>().ToList();
            int index = 0;
            DateTime jianyanriqi = juans.OrderBy(x => x.rq).ToList()[0].rq;
            foreach (var juan in juans)
            {
                AddNewRow(juandt, juan,jianyanriqi );
                index = juandt.Rows.Count - 1;
                var cidians = Connect.DbHelper().Queryable<ChiDianTable>().Where(x => x.JuanHao == juan.JuanHao).ToList();
                int col = 0;
                foreach (var cidian in cidians)
                {
                    if (!cidian.ChiDianName.Contains("通坯"))
                    {
                        juandt.Rows[index]["代码" + col.ToString()] = chidiannames.FirstOrDefault(x => x.CiDianName == cidian.ChiDianName).Daihao;
                        juandt.Rows[index]["位置" + col.ToString()] = cidian.WeiZhi;
                        juandt.Rows[index]["扣分" + col.ToString()] = cidian.KouFeng;
                    }
                    else
                    {
                        juandt.Rows[index]["备注"] += cidian.ChiDianName;
                    }
                    col++;
                    if (col > 18)
                    {
                        AddNewRow(juandt, juan,jianyanriqi );
                        col = 0;
                    }
                }
            }
        }
        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="juandt"></param>
        /// <param name="juan"></param>
        private static void AddNewRow(DataTable juandt, JuanHaoTable juan, DateTime jianyanriqi)
        {
            juandt.Rows.Add();
            var index = juandt.Rows.Count - 1;
            juandt.Rows[index]["缸号"] = juan.GangHao;
            juandt.Rows[index]["卷号"] = juan.PiHao;
            juandt.Rows[index]["品名"] = juan.SampleName;
            juandt.Rows[index]["物料编号"] = juan.SampleNum;
            juandt.Rows[index]["颜色"] = juan.yanse;
            juandt.Rows[index]["实长"] = juan.biaoqianmishu;
            juandt.Rows[index]["拼接位置"] = 0;
            juandt.Rows[index]["幅宽"] = juan.Menfu;
            juandt.Rows[index]["总分"] = juan.SumKouFeng;
            juandt.Rows[index]["等级"] = juan.DengJI;
            juandt.Rows[index]["赠送"] = juan.JiaJian;
            juandt.Rows[index]["检验日期"] = jianyanriqi;
            juandt.Rows[index]["批号"] = juan.Houzhengli;
            juandt.Rows[index]["单位"] = juan.Danwei;
            juandt.Rows[index]["订单号"] = juan.OrderNum ;
            juandt.Rows[index]["合同号"] = juan.Hetonghao ;
            juandt.Rows[index]["客户名称"] = juan.CustomerName;
            juandt.Rows[index]["款号"] = juan.kuanhao ;
        }
    }
}
