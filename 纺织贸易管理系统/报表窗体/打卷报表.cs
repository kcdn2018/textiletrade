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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 打卷报表 : Form
    {
        private List<JuanHaoTable> juanlist = new List<JuanHaoTable>();
        public 打卷报表()
        {
            InitializeComponent();
            try
            {
                CreateGrid.Create(this.Name, gridView2);
                gridView2.Columns["rq"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                gridView2.OptionsCustomization.AllowSort = true;
            }
            catch
            {
                var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
                fm.ShowDialog();
            }
            try
            {
                CreateGrid.Create(this.Name, gridView1);
                gridView1.Columns["rq"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            }
            catch
            {
                var fm = new 配置列(gridView1) { formname = this.Name, Obj = new KaijianTable() };
                fm.ShowDialog();
            }
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.Date.AddDays(-1);
            cmbmaitou.Items.AddRange(Tools.获取模板.获取所有模板(PrintPath.唛头模板).ToArray());
            if (cmbmaitou.Items.Count > 0)
            {
                cmbmaitou.SelectedIndex = 0;
            }

            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl2, "打卷报表");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }
        private void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            juanlist = JuanHaoTableService.GetJuanHaoTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <= dateEdit2.DateTime.Date.AddDays(1) && x.SampleName.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text) && x.GangHao.Contains(txtganghao.Text) && x.kuanhao.Contains(txthuohao.Text)
             && x.yanse.Contains(txtsehao.Text) && x.CustomerName.Contains(txtkehu.Text) && x.SampleNum.Contains(txtBianhao.Text) && x.OrderNum.Contains(txtOrderNum.Text)&&x.Huahao.Contains (txthuahao.Text )&&x.Hetonghao.Contains (txtHetonghao.Text ));
            gridControl2.DataSource = juanlist;
            gridControl1.DataSource = KaijianTableService.GetKaijianTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <= dateEdit2.DateTime.Date.AddDays(1) && x.SampleName.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text) && x.GangHao.Contains(txtganghao.Text)
            && x.yanse .Contains(txtsehao.Text) && x.CustomerName.Contains(txtkehu.Text) && x.SampleNum.Contains(txtBianhao.Text) && x.OrderNum.Contains(txtOrderNum.Text));
            gridControl3.DataSource = DeleteLogService.GetDeleteLoglst(x => x.date >= dateEdit1.DateTime && x.date <= dateEdit2.DateTime.Date.AddDays(1) && x.Log.Contains(txtganghao.Text));
            UIWaitFormService.HideWaitForm();
        }
        private void 删除卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            foreach (var i in gridView2.GetSelectedRows())
            {
                s += "\r\n  " + gridView2.GetRowCellValue(i, "JuanHao").ToString();
            }
            var res = MessageBox.Show($"您确定要删除卷号是{s}\r\n这些卷吗？", this.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                foreach (var i in gridView2.GetSelectedRows())
                {
                    可发卷BLL.卷删除(gridView2.GetRowCellValue(i, "JuanHao").ToString());
                }
                Query();
            }
        }

        private void txtpingming_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void 打印唛头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView2.CloseEditor();
            var fm = new 打印设置窗体();
            fm.ShowDialog();
            foreach (var s in gridView2.GetSelectedRows())
            {
                gridView2.FocusedRowHandle = s;
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Print, moban = PrintPath.唛头模板 + cmbmaitou.Text, juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == gridView2.GetRowCellValue(s, "JuanHao").ToString()) }.打印();
            }
            AlterDlg.Show("所有唛头都打印完毕！");
        }

        private void 生成质检单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var juan in juanlist)
            {
                foreach (var chidian in ChiDianTableService.GetChiDianTablelst(x => x.JuanHao == juan.JuanHao))
                {
                    juan.Cidian += "{" + chidian.WeiZhi + "," + chidian.ChiDianName + "}";
                }
            }
            gridControl2.DataSource = juanlist;
            gridControl2.RefreshDataSource();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new CiDianNameTable() };
            fm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 删除开剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sunny.UI.UIMessageBox.ShowAsk("您确定要删除改开剪信息吗？"))
            {
                try
                {
                    int stockid = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "state").TryToInt();
                    int id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").TryToInt();
                    decimal kaijianmishu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BiaoqianMishu").TryToDecmial();
                    StockTableService.UpdateStockTable($"kaijianmishu=kaijianmishu-{kaijianmishu }", x => x.ID == stockid);
                    KaijianTableService.DeleteKaijianTable(x => x.ID == id);
                    gridControl1.DataSource = KaijianTableService.GetKaijianTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <= dateEdit2.DateTime && x.SampleName.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text) && x.GangHao.Contains(txtganghao.Text)
               && x.yanse .Contains(txtsehao.Text) && x.CustomerName.Contains(txtkehu.Text) && x.SampleNum.Contains(txtBianhao.Text) && x.OrderNum.Contains(txtOrderNum.Text));
                    Sunny.UI.UIMessageBox.ShowSuccess("删除开剪完毕！");
                }
                catch (Exception ex)
                {
                    Sunny.UI.UIMessageBox.ShowError("删除开剪信息时发生了错误！" + ex.Message);
                }
            }
        }
        private List<JuanHaoTable> CreatJuanhao()
        {
            var juan = new List<JuanHaoTable>();
            foreach (var j in gridView2.GetSelectedRows())
            {
                juan.Add(juanlist[j]);
            }
            return juan;
        }
        private void 编辑报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.打印检验报告.PrintReport(PrintModel.Design, CreatJuanhao());
        }

        private void 预览报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.打印检验报告.PrintReport(PrintModel.Privew , CreatJuanhao());
        }

        private void 打印报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.打印检验报告.PrintReport(PrintModel.Print , CreatJuanhao());
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            if(gridView2.FocusedRowHandle>=0)
            {
                gridControl4.DataSource = ChiDianTableService.GetChiDianTablelst(x => x.JuanHao == juanlist[gridView2.FocusedRowHandle].JuanHao);
            }
        }
    }
}
