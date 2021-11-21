using BLL;
using Model;
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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 门市采样统计 : Form
    {
        public 门市采样统计()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name  , gridView1);
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            gridView1.Columns["HejiJinE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["HejiJinE"].SummaryItem.FieldName = "HejiJinE";
            gridView1.Columns["HejiJinE"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["sl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["sl"].SummaryItem.FieldName = "sl";
            gridView1.Columns["sl"].SummaryItem.DisplayFormat = "{0:0.##}";
           for(int i=2;i<gridView1.Columns .Count;i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            }
            gridView1.IndicatorWidth = 30;
            gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ < dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable() };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 门市采样单 () { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改门市采样单") == true)
            {
                MainForm.mainform.AddMidForm(new 门市采样单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("门市采样单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改门市采样单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    报价单BLL.删除(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ < dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "门市采样单清单");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ < dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { ZJC=txtksmc.Text } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ < dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ < dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
            }
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == false)
            {
                MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.复制, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
