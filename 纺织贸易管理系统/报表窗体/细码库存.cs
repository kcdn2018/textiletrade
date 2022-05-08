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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 细码库存 : Form
    {
        private List<JuanHaoTable> juanlist = new List<JuanHaoTable>();
        public 细码库存()
        {
            InitializeComponent();
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
            cmbmaitou.Items.AddRange(Tools.获取模板.获取所有模板(PrintPath.唛头模板).ToArray());
            if (cmbmaitou.Items.Count > 0)
            {
                cmbmaitou.SelectedIndex = 0;
            }

            Query();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new JuanHaoTable () };
            fm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
        private void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            juanlist = JuanHaoTableService.GetJuanHaoTablelst(x =>  x.SampleName.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text) && x.GangHao.Contains(txtganghao.Text) && x.kuanhao.Contains(txthuohao.Text)
             && x.yanse.Contains(txtsehao.Text) && x.CustomerName.Contains(txtkehu.Text) && x.SampleNum.Contains(txtBianhao.Text) && x.OrderNum.Contains(txtOrderNum.Text)&&x.state ==0);
            gridControl1.DataSource = juanlist;         
            UIWaitFormService.HideWaitForm();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "细码库存表");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 删除卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            foreach (var i in gridView1.GetSelectedRows())
            {
                s += "\r\n  " + gridView1.GetRowCellValue(i, "JuanHao").ToString();
            }
            var res = MessageBox.Show($"您确定要删除卷号是{s}\r\n这些卷吗？", this.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                foreach (var i in gridView1.GetSelectedRows())
                {
                    可发卷BLL.卷删除(gridView1.GetRowCellValue(i, "JuanHao").ToString());
                }
                Query();
            }
        }

        private void 打印唛头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var fm = new 打印设置窗体();
            fm.ShowDialog();
            foreach (var s in gridView1.GetSelectedRows())
            {
                gridView1.FocusedRowHandle = s;
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Print, moban = PrintPath.唛头模板 + cmbmaitou.Text, juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == gridView1.GetRowCellValue(s, "JuanHao").ToString()) }.打印();
            }
            AlterDlg.Show("所有唛头都打印完毕！");
        }

        private void txtpingming_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            { Query(); }
        }
    }
}
