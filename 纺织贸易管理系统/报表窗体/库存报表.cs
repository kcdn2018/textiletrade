using BLL;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.报表窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 库存报表 : Form
    {
        public string StockName { get; set; } = "";
        public List<StockTable> pingzhong { get; set; }
        private List<JuanHaoTable> juanlist = new List<JuanHaoTable>();

        public 库存报表()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView2);
            CreateGrid.Query<JuanHaoTable>(gridControl2, juanlist);
            CreateGrid.Query<StockTable>(gridControl1, pingzhong);
            gridView1.OptionsCustomization.AllowSort = true;
            CreatLeibie();
            try
            {
                cmbmaitou.Items.AddRange(Tools.获取模板.获取所有模板(PrintPath.唛头模板).ToArray());
                if (cmbmaitou.Items.Count > 0)
                {
                    cmbmaitou.SelectedIndex = 0;
                }
            }
            catch
            {
                Sunny.UI.UIMessageBox.ShowError("没有找到任何唛头模板信息");
            }
        }
        private void CreatLeibie()
        {
            treeView1.Nodes.Clear();
            var lblist = Connect.CreatConnect().Query("select distinct ckmc from stocktable");
            var node = new TreeNode() { Text = "所有仓库", Name = "所有仓库" };
            for (int i = 0; i < lblist.Rows.Count; i++)
            {
                node.Nodes.Add(new TreeNode() { Text = lblist.Rows[i][0].ToString(), Name = lblist.Rows[i][0].ToString() });
            }
            treeView1.Nodes.Add(node);
            treeView1.ExpandAll();
        }
        private void 品种选择_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            pingzhong = Connect.DbHelper().Queryable <StockTable >().Where (x => x.ContractNum.Contains(txthetonghao.Text) && x.PM.Contains(txtpingming.Text) && x.GG.Contains(txtguige.Text) && x.GH.Contains(txtganghao.Text) && x.kuanhao.Contains(txthuohao.Text) && x.CKMC.Contains(StockName)
          && x.YS .Contains(txtsehao.Text) && x.CustomName.Contains(txtkehu.Text) && x.BH.Contains(txtBianhao.Text) && x.orderNum.Contains(txtOrderNum.Text) && x.CKMC != "色卡仓库"  ).OrderBy(x => x.RQ).ToList();
            gridControl1.DataSource = pingzhong;
            UIWaitFormService.HideWaitForm();
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new StockTable() };
            fm.ShowDialog();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            StockName = treeView1.SelectedNode.Text == "所有仓库" ? "" : treeView1.SelectedNode.Text;
            gridControl2.DataSource = null;
            Query();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            加载卷();
        }
        private void 加载卷()
        {
            var id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").TryToInt();
            var d = StockTableService.GetOneStockTable (x=>x.ID ==id);        
             gridControl2.DataSource = JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.GH && x.SampleNum == d.BH && x.Danhao =="" && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum&&x.Ckmc==d.CKMC ).OrderBy (x=>x.PiHao);          
        }

        private void 清零选择库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要把这些选中的库存清零吗？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<StockTable> stocks = new List<StockTable>();
                //List<StockTable> stockTables = gridControl1.DataSource as List<StockTable>;
                foreach (var index in gridView1.GetSelectedRows())
                {
                    var s = pingzhong.Where(x => x.ID == (int)gridView1.GetRowCellValue(index, "ID")).ToList()[0];
                    stocks.Add(s);
                    RukuTableService.InsertRukuTable(new RukuTable()
                    {
                        BH = s.BH,
                        CF = s.CF,
                        CKMC = s.CKMC,
                        GG = s.GG,
                        GH = s.GH,
                        Houzhengli = s.houzhengli,
                        JS = s.JS,
                        Kuanhao = s.kuanhao,
                        KZ = s.KZ,
                        MF = s.MF,
                        MS = s.MS,
                        orderNum = s.orderNum,
                        PM = s.PM,
                        own = s.own,
                        RKDH = s.RKDH,
                        RQ = DateTime.Now,
                        YS = s.YS,
                        offerid = s.RKDH,
                        LX = "删除库存",
                        bz = string.Empty
                    });
                }
                库存BLL.清零库存(stocks);
            }
            Query();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatLeibie();
        }

        private void 录入明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var fm = new 录入可发卷() { stock = pingzhong.Where(x => x.ID == (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")).ToList()[0] };
                fm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                fm.ShowDialog();
            }
            else
            {
                AlterDlg.Show("没有任何库存可录入");
            }
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 打印设置窗体();
            //fm.ShowDialog();
            var juanlist = gridControl2.DataSource as DataTable;
            var moban = MaitouService.GetOneMaitou(x => x.khbh == (String)juanlist.Rows[gridView2.FocusedRowHandle]["CustomerName"]).path;
            if (!string.IsNullOrWhiteSpace(moban))
            {
                moban = cmbmaitou.Text;
            }
            new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Design, moban = PrintPath.唛头模板 + moban, juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == (string)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "JuanHao")) }.打印();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void 删除卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("您确定要删除选中的卷吗？", this.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                foreach (var i in gridView2.GetSelectedRows())
                {
                    可发卷BLL.卷删除(gridView2.GetRowCellValue(i, "JuanHao").ToString());
                }
                加载卷();
            }
        }
        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "发货通知单清单");
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 打印设置窗体();
            //fm.ShowDialog();
            string moban = string.Empty;
            if (string.IsNullOrWhiteSpace(moban))
            {
                moban = cmbmaitou.Text;
            }
            new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Privew, moban = PrintPath.唛头模板 + moban, juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == (string)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "JuanHao")) }.打印();
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 打印设置窗体();
            fm.ShowDialog();
            var juanlist = gridControl2.DataSource as DataTable;
            string moban = string.Empty;
            //var moban = MaitouService.GetOneMaitou(x => x.khbh == (String)juanlist.Rows[gridView2.FocusedRowHandle]["CustomerName"]).path;
            //if (!string.IsNullOrWhiteSpace(moban))
            //{
                moban = cmbmaitou.Text;
            //}
            foreach (var index in gridView2.GetSelectedRows())
            {
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Print, moban = PrintPath.唛头模板 + moban, juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == (string)gridView2.GetRowCellValue(index, "JuanHao")) }.打印();
            }
        }

        private void 订单转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("订单转换"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                   var fm=new 订单转换() { OldOrder =StockTableService.GetOneStockTable (x=>x.ID ==(int )gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"ID"))};
                    fm.ShowDialog();
                    if (treeView1.SelectedNode != null)
                    {
                        StockName = treeView1.SelectedNode.Text == "所有仓库" ? "" : treeView1.SelectedNode.Text;
                    }
                    else
                    {
                        StockName = "";
                    }
                    gridControl2.DataSource = null;
                    Query();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 查看开剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").TryToInt();
            var fm = new 查看开剪() { stockid = id };
            fm.ShowDialog();
        }

        private void 查看垃圾桶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 垃圾桶());
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                StockName = treeView1.SelectedNode.Text == "所有仓库" ? "" : treeView1.SelectedNode.Text;
                gridControl2.DataSource = null;
                Query();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var remarkers = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remarkers").ToString();
                Sunny.UI.UIInputDialog.InputStringDialog(this, ref remarkers,true ,"请输入该库存的完成备注");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Remarkers", remarkers);
                int id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").TryToInt ();
                StockTable stock = StockTableService.GetOneStockTable (x => x.ID ==id);
                stock.Remarkers = remarkers;
                Connect.DbHelper().Updateable<StockTable >(stock).ExecuteCommandAsync();
            }
        }

        private void 登记库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                //var remarkers = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Kuwei").ToString();
                var fm = new 库位登记() { StockName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKMC").ToString() };
                fm.ShowDialog();
                int id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").TryToInt();
                StockTable stock = StockTableService.GetOneStockTable(x => x.ID == id);
                stock.Kuwei = fm.Kuwei;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Kuwei", fm.Kuwei);
                Connect.DbHelper().Updateable<StockTable>(stock).ExecuteCommandAsync();
            }
        }

        private void 唛头模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.DefaultExt = "xls";
                    openFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Title = "Excel文件路径";
                    openFileDialog.ShowDialog();
                    var ds = ExcelService.ExcelToDataSet(openFileDialog.FileName, true);
                    List<StockTable> stocks = new List<StockTable>();
                    foreach (var i in gridView1.GetSelectedRows())
                    {
                        stocks.Add(pingzhong.FirstOrDefault(x => x.ID == (int)gridView1.GetRowCellValue(i, "ID")));
                    }
                    var fm = new 码单导入() { GetDataSet = ds,stockTables =stocks  };
                    fm.ShowDialog();
                }
                else
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择你要导入的缸号");
                }
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageBox.ShowError("导入码单发送错误  "+ex.Message);
            }
        }

        private void 复检ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sunny.UI.UIMessageBox.ShowAsk ("您确定要把这些选中的库存复检吗？\r\n复检会删除全部这些库存的在库的打卷信息"))
            {
                var stocks = new List<StockTable>();
                foreach (var s in gridView1.GetSelectedRows() )
                {
                    var d = pingzhong.FirstOrDefault(x => x.ID == (int)gridView1.GetRowCellValue(s, "ID"));                   
                    d.biaoqianmishu -=Connect.DbHelper().Queryable <JuanHaoTable >().Where(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
            && x.GangHao == d.GH && x.SampleNum == d.BH && x.Danhao == "" && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == d.CKMC).Sum (x=>x.biaoqianmishu );
                    d.yijianmishu  -= Connect.DbHelper().Queryable<JuanHaoTable>().Where(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
           && x.GangHao == d.GH && x.SampleNum == d.BH && x.Danhao == "" && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == d.CKMC).Sum(x => x.MiShu );
                    d.yijianjuanshu  -= Connect.DbHelper().Queryable<JuanHaoTable>().Where(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
             && x.GangHao == d.GH && x.SampleNum == d.BH && x.Danhao == "" && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == d.CKMC).Count();
                    JuanHaoTableService.DeleteJuanHaoTable(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
                   && x.GangHao == d.GH && x.SampleNum == d.BH && x.Danhao == "" && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == d.CKMC);
                    stocks.Add(d);
                }
                Connect.DbHelper().Updateable<StockTable>(stocks).ExecuteCommand();
                Sunny.UI.UIMessageDialog.ShowSuccessDialog(this, "复检完成");
            }
        }
    }
}
