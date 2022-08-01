using FastReport;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
    public class 打印成品码单
    {
        public List<JuanHaoTable> juanHaoTables { get; set; }
        public DanjuTable danjuTable { get; set; }
        public List<danjumingxitable> danjumingxitables { get; set; }
        public FormInfo danjuinfo { get; set; } = new FormInfo();
        public FormInfo mingxiinfo { get; set; } = new FormInfo();
        public string gsmc { get; set; }
        public void Print(string path, int model)
        {
            foreach (var mx in danjumingxitables.Select(x => x.Bianhao).Distinct().ToList())
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjuTable, danjuinfo, "单据信息",gsmc));
                ds.Tables.Add(CreateDanjuDatatable.CreateTable(danjumingxitables.Where(x => x.Bianhao == mx).ToList(), mingxiinfo));
                ds.Tables.Add(CreatMadanDetail(danjumingxitables.Where(x => x.Bianhao == mx).ToList()[0]));
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
        //表格增加17行
        private void AddRow(DataTable dt)
        {
            for (int i = 0; i < 15; i++)
            {
                dt.Rows.Add();
            }
        }
        private DataTable CreateMadanTable()
        {
            DataTable dt = new DataTable("码单明细");
            dt.Columns.Add("卷号0");
            dt.Columns.Add("缸号0");
            dt.Columns.Add("缸卷号0");
            dt.Columns.Add("颜色0");
            dt.Columns.Add("款号0");
            dt.Columns.Add("后整理0");
            dt.Columns.Add("长度0", typeof(decimal));
            dt.Columns.Add("卷号1");
            dt.Columns.Add("缸号1");
            dt.Columns.Add("缸卷号1");
            dt.Columns.Add("颜色1");
            dt.Columns.Add("款号1");
            dt.Columns.Add("后整理1");
            dt.Columns.Add("长度1", typeof(decimal));
            dt.Columns.Add("卷号2");
            dt.Columns.Add("缸号2");
            dt.Columns.Add("缸卷号2");
            dt.Columns.Add("颜色2");
            dt.Columns.Add("款号2");
            dt.Columns.Add("后整理2");
            dt.Columns.Add("长度2", typeof(decimal));
            dt.Columns.Add("卷号3");
            dt.Columns.Add("缸号3");
            dt.Columns.Add("缸卷号3");
            dt.Columns.Add("颜色3");
            dt.Columns.Add("款号3");
            dt.Columns.Add("后整理3");
            dt.Columns.Add("长度3", typeof(decimal));
            dt.Columns.Add("卷号4");
            dt.Columns.Add("缸号4");
            dt.Columns.Add("缸卷号4");
            dt.Columns.Add("颜色4");
            dt.Columns.Add("款号4");
            dt.Columns.Add("后整理4");
            dt.Columns.Add("长度4", typeof(decimal));
            dt.Columns.Add("卷号5");
            dt.Columns.Add("缸号5");
            dt.Columns.Add("缸卷号5");
            dt.Columns.Add("颜色5");
            dt.Columns.Add("款号5");
            dt.Columns.Add("后整理5");
            dt.Columns.Add("长度5", typeof(decimal));
            dt.Columns.Add("卷号6");
            dt.Columns.Add("缸号6");
            dt.Columns.Add("缸卷号6");
            dt.Columns.Add("颜色6");
            dt.Columns.Add("款号6");
            dt.Columns.Add("后整理6");
            dt.Columns.Add("长度6", typeof(decimal));
            dt.Columns.Add("卷号7");
            dt.Columns.Add("缸号7");
            dt.Columns.Add("缸卷号7");
            dt.Columns.Add("颜色7");
            dt.Columns.Add("款号7");
            dt.Columns.Add("后整理7");
            dt.Columns.Add("长度7", typeof(decimal));
            dt.Columns.Add("合计长度", typeof(decimal));
            dt.Columns.Add("合计卷数", typeof(decimal));
            return dt;
        }
        public  DataTable CreatMadanDetail(danjumingxitable mx)
        {

            DataTable totaldt = new DataTable("合计信息");
            totaldt.Columns.Add("合计米数");
            totaldt.Columns.Add("合计卷数");
            var dt = CreateMadanTable();
            try
            {
                //定义当前列
                int curCol = 0;
                //定义当前行
                int currow = 0;
                //定义当前页
                int curpage = 1;
                AddRow(dt);
                //&& x.OrderNum == mx.OrderNum && x.yanse == mx.yanse && x.GangHao == mx.ganghao && x.kuanhao == mx.kuanhao && x.Houzhengli == mx.houzhengli)
                var jlist = juanHaoTables.Where(x => x.SampleNum == mx.Bianhao).ToList();
                string ganghao = string.Empty;
                string houzhengli = string.Empty;
                string yanse = string.Empty;
                if (jlist.Count > 0)
                {
                    ganghao = jlist[0].GangHao;
                    houzhengli = jlist[0].Houzhengli;
                    yanse = jlist[0].yanse;
                }
                foreach (var j in jlist)
                {
                    if (ganghao != j.GangHao||houzhengli!=j.Houzhengli ||yanse!=j.yanse )
                    {
                        if (currow > 0)
                        {
                            curCol++;
                        }
                        if (curCol > 7)
                        {
                            curpage++;
                            curCol =0;
                            AddRow(dt);
                        }
                        ganghao = j.GangHao;
                        houzhengli = j.Houzhengli;
                        yanse = j.yanse;
                        currow = 15 * (curpage - 1);
                    }
                    if (currow % 15 ==0)
                    {
                        dt.Rows[currow][$"卷号{curCol }"] = j.JuanHao;
                        dt.Rows[currow][$"缸号{curCol }"] = j.GangHao;                        
                        dt.Rows[currow][$"颜色{curCol }"] = j.yanse;
                        dt.Rows[currow][$"后整理{curCol }"] = j.Houzhengli;
                        dt.Rows[currow][$"款号{curCol }"] = j.kuanhao;
                    }
                    dt.Rows[currow][$"缸卷号{curCol }"] = j.PiHao;
                    dt.Rows[currow][$"长度{curCol }"] = j.biaoqianmishu;
                    currow++;
                    if (currow >= 15 * curpage)
                    {
                        curCol++;
                        //已经是第4列了 就新建一页
                        if (curCol > 7)
                        {
                            curCol = 0;
                            currow = 15 * curpage;
                            decimal heji = 0;
                            for (int i = 15 * (curpage - 1); i < 15 * curpage; i++)
                            {
                                for (int c = 0; c < 8; c++)
                                {
                                    if (!string.IsNullOrEmpty(dt.Rows[i][$"长度{c }"].ToString()))
                                    {
                                        heji += (decimal)dt.Rows[i][$"长度{c }"];
                                    }
                                }
                                dt.Rows[i]["合计长度"] = heji;
                            }
                            AddRow(dt);
                            curpage++;
                        }
                        else
                        {
                            currow = 15 * (curpage - 1);
                        }
                    }
                    //    else
                    //    {
                    //    decimal sum = 0;
                    //    for (int i = 16 * (curpage - 1); i < 16 * curpage; i++)
                    //    {
                    //        if (dt.Rows[i][$"长度{curCol }"].GetType().ToString() != "System.DBNull")
                    //        {
                    //            sum += Convert.ToDecimal(dt.Rows[i][$"长度{curCol}"]);
                    //        }
                    //    }
                    //    dt.Rows[16 * curpage][$"缸号{0 }"] = "列合计";
                    //    dt.Rows[16 * curpage][$"长度{curCol }"] = sum;
                    //}
                }

                //totaldt .Rows[0][]
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Sum(dt);
        }
        private DataTable Sum(DataTable dt)
        {
            for(int i=0;i<dt.Rows.Count;i++)
            {
                decimal heji = 0;
                decimal juan=0;
                for(var c=0;c<8;c++)
                { 
                    if( dt.Rows[i][$"长度{c}"].GetType().ToString ()!="System.DBNull") 
                    {
                        heji += (decimal)dt.Rows[i][$"长度{c}"]; 
                       juan ++;
                    }
                }
                dt.Rows[i]["合计长度"] = heji;
                dt.Rows[i]["合计卷数"] = juan;
            }
            return dt;
        }        
        }
    }
