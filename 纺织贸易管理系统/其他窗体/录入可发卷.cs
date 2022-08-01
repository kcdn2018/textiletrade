using BLL;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 录入可发卷 : Form
    {
        public StockTable stock { get; set; }
        private BindingList <JuanHaoTable> juanHaoTables = new BindingList  <JuanHaoTable>();
        
        public 录入可发卷()
        {
            InitializeComponent();
            gridView1.IndicatorWidth = 30;
            cmbmaitou .Items.AddRange  ( Tools.获取模板.获取所有模板(PrintPath.唛头模板 ).ToArray ());
            CreateGrid.Create("打卷报表", gridView2);
            //this.juanHaoTables.AddingNew += (s, ev) => {
            //  ev.NewObject =(new JuanHaoTable() { PiHao = juanHaoTables.Count + 1 });
            //    gridControl1.RefreshDataSource();
            //};
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "PiHao", juanHaoTables.Count );
            gridControl1.RefreshDataSource();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var jlist = juanHaoTables.Where(x => x.PiHao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PiHao").TryToInt()).ToList();
            if (jlist .Count >1)
            {
                MessageBox.Show("该缸卷号一卷存在。缸卷号不能重复。请重新输入", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtheji.Text = juanHaoTables.Sum(x => x.biaoqianmishu ).ToString ();
            txthejijuanshu.Text =( juanHaoTables.Count ).ToString ();
        }

        private void 录入可发卷_Load(object sender, EventArgs e)
        {
            txtkehu.Text = stock.CustomName ;
            txtganghao.Text = stock.GH;
            txthetonghao.Text = stock.ContractNum;
            txtordernum.Text = stock.orderNum ;
            txtmenfu.Text = stock.MF;
            txtpingming.Text = stock.PM;
            txtyanse.Text = stock.YS;
            txtkucunjuanshu.Text = stock.MS.ToString ();
            txtkucunmingshu.Text = stock.JS.ToString ();
            txtkezhong.Text = stock.KZ;
            txtkuanhao.Text = stock.kuanhao;
            txtchengfeng.Text = stock.CF;
            txtcangku.Text = stock.CKMC;
            txtbianhao.Text = stock.BH;
            txtguige.Text = stock.GG;
            txthuahao.Text = stock.Huahao;
            txtkehupingming.Text = stock.CustomerPingMing;
            txtkehusehao.Text = stock.CustomerColorNum;
            txtYingwenming.Text= dbService.GetOnedb(x => x.bh == stock.BH).EnglishName;
            var d = stock;
            juanHaoTables = new BindingList<JuanHaoTable>(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
               && x.GangHao == d.GH && x.SampleNum == d.BH && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.state == 0 && x.Ckmc == d.CKMC));
        gridControl1.DataSource = juanHaoTables;
            var lxr = LXRService.GetOneLXR(x => x.MC == stock.CustomName);
            var maitou = MaitouService.GetOneMaitou(x => x.khbh == lxr.BH).path;
            if (string.IsNullOrWhiteSpace (maitou ))
            {
                cmbmaitou.Text = cmbmaitou.Items[0].ToString();
            }
            else
            {
                cmbmaitou.Text = maitou;
            }
            //= !=string.Empty ? : MaitouService.GetOneMaitou(x => x.khbh == stock.CustomName).path;
            txtheji.Text = juanHaoTables.Sum(x => x.biaoqianmishu).ToString();
            txthejijuanshu.Text=(juanHaoTables.Count).ToString ();
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            bool IsHave=false ;
            try
            {
                foreach (var j in juanHaoTables)
                {
                    j.Danwei = comdanwei.Text;
                  
                    if (j.JuanHao == null)
                    {
                        IsHave = true;
                        j.JuanHao = BianhaoBLL.CreatJuanhao(stock.GH, j.PiHao.ToString()) ;
                    }
                    j.MiShu = j.biaoqianmishu ;
                    j.SampleNum = stock.BH;
                    j.SampleName = stock.PM;
                    j.CustomerName = stock.CustomName;
                    j.GangHao = stock.GH;
                    j.guige = stock.GG;
                    j.Houzhengli = stock.houzhengli;
                    j.kuanhao = stock.kuanhao;
                    j.OrderNum = stock.orderNum;
                    j.MaShu = txtMalv.Text.TryToDecmial (0);
                    j.rq = DateTime.Now;
                    j.SumKouFeng = 0;
                    j.yanse = stock.YS;
                    j.Huahao = stock.Huahao;
                    j.Menfu = stock.MF;
                    j.Kezhong = stock.KZ;
                    j.CustomerColorNum = stock.CustomerColorNum;
                    j.CustomerName = stock.CustomName;
                    j.CustomerPingMing = stock.CustomerPingMing;
                    j.ColorNum = stock.ColorNum;
                    j.Ckmc = stock.CKMC ;
                    j.Hetonghao = stock.ContractNum;
                    if(IsHave)
                    {
                        JuanHaoTableService.InsertJuanHaoTable(j);                                                                   
                    }
                    else
                    {
                        Connect.DbHelper().Updateable<JuanHaoTable>(j).ExecuteCommandAsync();      
                    }
                }
                if (comdanwei.Text == "米")
                {
                    stock.yijianmishu = txtheji.Text.ToDecimal(0) * txtMalv.Text.TryToDecmial(0) / 100;
                    stock.biaoqianmishu = txtheji.Text.ToDecimal(0);
                    stock.yijianjuanshu = txthejijuanshu.Text.ToDecimal(0);
                }
                else
                {
                    stock.yijianmishu =(decimal )0.9144* txtheji.Text.ToDecimal(0) * txtMalv.Text.TryToDecmial(0) / 100;
                    stock.biaoqianmishu =(decimal )0.9144* txtheji.Text.ToDecimal(0);
                    stock.yijianjuanshu = txthejijuanshu.Text.ToDecimal(0);
                }              
                StockTableService.UpdateStockTable($"yijianmishu='{stock.yijianmishu }',biaoqianmishu='{stock.biaoqianmishu }',yijianjuanshu='{stock.yijianjuanshu }'", x=>x.ID==stock.ID);
                string message = "布料名为" + txtpingming.Text + "  颜色为 " + txtyanse.Text + " 订单号为" + txtordernum.Text + " 缸号为" + txtganghao.Text + "是否已经全部检验打卷完毕";
                if (Sunny.UI.UIMessageDialog.ShowAskDialog(this, message))
                {
                    库存BLL.检验完毕(stock.ID);
                }
                else
                {
                    库存BLL.检验未完毕(stock.ID);
                }
                MessageBox.Show("保存完毕！界面将关闭！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存的时候发送错误！有可能是一个数据都没有"+ex.Message ,this.Name,MessageBoxButtons.OK ,MessageBoxIcon.Information );
            }

        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            txtheji.Text = juanHaoTables.Sum(x => x.biaoqianmishu).ToString();
            txthejijuanshu.Text = (juanHaoTables.Count).ToString();
        }
        private JuanHaoTable  CreatJuan()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var j = new JuanHaoTable();
                if (string.IsNullOrEmpty(juanHaoTables[gridView1.FocusedRowHandle].JuanHao))
                {
                    j.Danwei = comdanwei.Text;
                    j.JuanHao = BianhaoBLL.CreatJuanhao(stock.GH, j.PiHao.ToString());
                    j.MiShu = juanHaoTables[gridView1.FocusedRowHandle].biaoqianmishu;
                    j.SampleNum = stock.BH;
                    j.SampleName = stock.PM;
                    j.CustomerName = stock.CustomName;
                    j.GangHao = stock.GH;
                    j.guige = stock.GG;
                    j.Houzhengli = stock.houzhengli;
                    j.kuanhao = stock.kuanhao;
                    j.OrderNum = stock.orderNum;
                    j.MaShu = txtMalv.Text.TryToDecmial(0);
                    j.rq = DateTime.Now;
                    j.SumKouFeng = 0;
                    j.yanse = stock.YS;
                    j.Huahao = stock.Huahao;
                    j.biaoqianmishu = juanHaoTables[gridView1.FocusedRowHandle].biaoqianmishu;
                    j.PiHao = juanHaoTables[gridView1.FocusedRowHandle].PiHao;
                    j.Huahao = txthuahao.Text;
                    j.CustomerColorNum = txtkehusehao.Text;
                    j.CustomerPingMing = txtkehupingming.Text;
                    j.ColorNum = txtsehao.Text;
                    j.Menfu = txtmenfu.Text;
                    j.Kezhong = txtkezhong.Text;
                    j.Hetonghao = txthetonghao.Text;
                }
                else
                {
                    j = juanHaoTables[gridView1.FocusedRowHandle];
                }
                return j;
            }
            else
            {
                return new JuanHaoTable();
            }
        }
        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var fm = new 打印设置窗体();
            fm.ShowDialog();
            foreach (var s in gridView1.GetSelectedRows())
            {
                gridView1.FocusedRowHandle = s;
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Print, moban = PrintPath.唛头模板 + cmbmaitou.Text, juan = CreatJuan() }.打印();
            }
        }

        private void 码单编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                gridView1.CloseEditor();
                var fm = new 打印设置窗体();
                //fm.ShowDialog();
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Design, moban = PrintPath.唛头模板 + cmbmaitou.Text, juan = CreatJuan() }.打印();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 码单预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var fm = new 打印设置窗体();
            //fm.ShowDialog();
            new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Privew , moban = PrintPath.唛头模板 + cmbmaitou.Text, juan = CreatJuan() }.打印();
        }

        private void 转98码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var j in juanHaoTables)
            {
                j.biaoqianmishu =Math.Round ( ( j.biaoqianmishu / (txtMalv.Text .TryToDecmial(0)/100)).TryToDecmial (0),0);
            }
            gridControl1.RefreshDataSource();
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                PrintStock(PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }
        private void PrintStock(int printstyle)
        {
            var mingxis = new List<danjumingxitable>();
            mingxis.Add(new danjumingxitable()
            {
                Bianhao = stock.BH,
                CustomName = stock.CustomName,
                CustomerPingMing = stock.CustomerPingMing,
                CustomerColorNum = stock.CustomerColorNum,
                chengfeng = stock.CF,
                ColorNum = stock.ColorNum,
                ContractNum = stock.ContractNum,
                Chengpingyanse = stock.YS,
                yanse = stock.YS,
                FrabicWidth = stock.FrabicWidth,
                ganghao = stock.GH,
                guige = stock.GG,
                houzhengli = stock.houzhengli,
                Huahao = stock.Huahao,
                kezhong = stock.KZ,
                kuanhao = stock.kuanhao,
                Kuwei = stock.Kuwei,
                menfu = stock.MF,
                OrderNum = stock.orderNum,
                chengpingjuanshu = juanHaoTables.Count,
                chengpingmishu = juanHaoTables.Sum(x => x.biaoqianmishu),
                beizhu = stock.Remarkers,
                PiBuChang = stock.PibuChang,
                Pihao = stock.Pihao,
                pingming = stock.PM,
                Rangchang = stock.Rangchang,
                rq = stock.RQ
            });
            var madan = new Tools.打印成品码单()
            {
                danjuTable = new DanjuTable(),
                danjumingxitables =mingxis ,
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                juanHaoTables = juanHaoTables.ToList (),
                mingxiinfo = new Tools.FormInfo() { FormName = "销售发货单", GridviewName = gridView1.Name },
                gsmc = stock.CustomName 
            };
            madan.Print(PrintPath.报表模板 + "\\库存单.frx", printstyle );
         
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStock(PrintModel.Privew );
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStock(PrintModel.Print );
        }

        private void 生成质检报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            juanHaoTables.ForEach(x => x.MiShu = x.biaoqianmishu + x.SumKouFeng);
            var selectJuanhaos = new List<JuanHaoTable>();
           foreach(var row in gridView1.GetSelectedRows())
            {
                selectJuanhaos .Add (juanHaoTables [row]);
            }
            gridControl2.DataSource = selectJuanhaos;
            Tools.打印检验报告.PrintReport(PrintModel.Privew, selectJuanhaos);
        }
    }
}
