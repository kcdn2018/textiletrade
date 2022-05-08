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
  public class 打印横版码单
    {
        public DanjuTable danju { get; set; }
        public List<JuanHaoTable> juanhaolist { get; set; }
        public FormInfo formInfo { get; set; }
        public string gsmc { get; set; }
        /// <summary>
		/// 创建单据DataTable
		/// </summary>
		/// <returns></returns>
        private DataTable CreatDanjuDT()
        {
            var dt = CreateDanjuDatatable.CreateTable(danju, formInfo, "单据信息",gsmc );
            dt.Columns.Add("包数", typeof(int));
            dt.Rows[0]["包数"] = juanhaolist.Select(x => x.state).Distinct().ToList().Count;
            return dt;
        }
        /// <summary>
        /// 创建明细DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable CreatMingxi()
        {
            DataTable dt = new DataTable("明细");
            var clist = Connect.GetColumntable("打包发货", "gridView1", "10001");
            foreach (var c in clist)
            {
                try
                {
                    dt.Columns.Add(c.ColumnText);
                }
                catch
                { }
            }
            dt.Columns.Add("1", typeof(string));
            dt.Columns.Add("2", typeof(string));
            dt.Columns.Add("3", typeof(string));
            dt.Columns.Add("4", typeof(string));
            dt.Columns.Add("5", typeof(string));
            dt.Columns.Add("6", typeof(string));
            dt.Columns.Add("7", typeof(string));
            dt.Columns.Add("8", typeof(string));
            dt.Columns.Add("9", typeof(string));
            dt.Columns.Add("10", typeof(string));
            dt.Columns.Add("匹数", typeof(decimal));
            dt.Columns.Add("合计数量", typeof(decimal));
            dt.Columns.Add("缸合计");
            return dt;
        }
        private void 赋值一行(DataTable dt, int row, JuanHaoTable juanHao)
        {
            dt.Rows.Add();
            var clist = Connect.GetColumntable("打包发货", "gridView1", "10001");
            var pros = juanHao.GetType().GetProperties();
            foreach (var p in pros)
            {
                try
                {
                    var n = clist.Where(x => x.DataProperty == p.Name).ToList();
                    if (n.Count > 0)
                    {
                        if (p.PropertyType.FullName != "System.Decimal")
                        {
                            dt.Rows[row][n[0].ColumnText] = p.GetValue(juanHao);
                        }
                        else
                        {
                            var ms = (decimal)p.GetValue(juanHao);
                            var s = ms.ToString("0.##");
                            dt.Rows[row][n[0].ColumnText] = s;
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
            dt.Rows[row]["1"] = juanHao.biaoqianmishu.ToString("0.##");
        }
        private DataTable 初始化明细()
        {
            DataTable mingxiti = CreatMingxi();
            //列出所有包号
            var baohaolist = juanhaolist.OrderBy(x=>x.GangHao).ThenBy (x=>x.yanse ).ThenBy(x=>x.PiHao );
            int row = 0;
            JuanHaoTable prejuan = new JuanHaoTable();
            int n = 1;
            try
            {
                foreach (var juan in baohaolist)
                {
                    if (row == 0)
                    {
                        赋值一行(mingxiti, row, juan);
                        prejuan = juan;
                        row++;
                        n = 1;
                    }
                    else
                    {
                        if (juan.state != prejuan.state)
                        {
                            赋值一行(mingxiti, row, juan);
                            prejuan = juan;
                            row++;
                            n = 1;
                        }
                        else
                        {
                            if (juan.OrderNum != prejuan.OrderNum)
                            {
                                赋值一行(mingxiti, row, juan);
                                prejuan = juan;
                                row++;
                                n = 1;
                            }
                            else
                            {
                                if (juan.SampleNum != prejuan.SampleNum)
                                {
                                    赋值一行(mingxiti, row, juan);
                                    prejuan = juan;
                                    row++;
                                    n = 1;
                                }
                                else
                                {
                                    if (juan.yanse  != prejuan.yanse )
                                    {
                                        赋值一行(mingxiti, row, juan);
                                        prejuan = juan;
                                        row++;
                                        n = 1;
                                    }
                                    else
                                    {
                                        if (juan.GangHao != prejuan.GangHao)
                                        {
                                            赋值一行(mingxiti, row, juan);
                                            prejuan = juan;
                                            row++;
                                            n = 1;
                                        }
                                        else
                                        {
                                            if (juan.Huahao != prejuan.Huahao)
                                            {
                                                赋值一行(mingxiti, row, juan);
                                                prejuan = juan;
                                                row++;
                                                n = 1;
                                            }
                                            else
                                            {
                                                n++;
                                                if (n == 11)
                                                {
                                                    赋值一行(mingxiti, row, juan);
                                                    prejuan = juan;
                                                    row++;
                                                    n = 1;
                                                }
                                                else
                                                {
                                                    mingxiti.Rows[row - 1][n.ToString()] = juan.biaoqianmishu.ToString("0.##");
                                                    prejuan = juan;

                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            for (int r = 0; r < mingxiti.Rows.Count; r++)
            {
                //mingxiti.Rows[r]["合计数量"] =(int)(mingxiti.Rows[r]["1"]) +(int)(mingxiti.Rows[r]["2"]) + (int)(mingxiti.Rows[r]["3"]) + (int)(mingxiti.Rows[r]["4"]) +( int)(mingxiti.Rows[r]["5"]);
                decimal pishu = 0;
                decimal num = 0;
                for (int p = 1; p < 11; p++)
                {
                    if ((mingxiti.Rows[r][p.ToString()]) != DBNull.Value)
                    {
                        pishu++;
                        try
                        {
                            num += Convert.ToDecimal(mingxiti.Rows[r][p.ToString()]);
                        }
                        catch
                        {

                        }
                    }
                }
                mingxiti.Rows[r]["缸合计"] = juanhaolist.Where(x => x.GangHao == (string)mingxiti.Rows[r]["缸号"]).ToList().Sum(x => x.biaoqianmishu);
                mingxiti.Rows[r]["合计数量"] = num;
                mingxiti.Rows[r]["匹数"] = pishu;
            }
            return mingxiti;
        }
        public void 打印(int model, string path)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(CreatDanjuDT());
            ds.Tables.Add(初始化明细());
            FastReport.Report  fs = new FastReport.Report();
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
