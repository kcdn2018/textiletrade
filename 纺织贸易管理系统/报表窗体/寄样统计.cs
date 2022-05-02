using BLL;
using DevExpress.XtraNavBar.ViewInfo;
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
    public partial class 寄样统计 : Form
    {
        public 寄样统计()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name , gridView1);
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            gridView1.Columns["HejiJinE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["HejiJinE"].SummaryItem.FieldName = "HejiJinE";
            gridView1.Columns["HejiJinE"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["sl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["sl"].SummaryItem.FieldName = "sl";
            gridView1.Columns["sl"].SummaryItem.DisplayFormat = "{0:0.##}";
           //for(int i=1;i<gridView1.Columns .Count;i++)
           // {
           //     gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
           // }
            gridView1.IndicatorWidth = 30;
          
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new JiYangBaoJia () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改寄样单") == true)
            {
                MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.修改, jiYangBaoJia = JiYangBaoJiaService.GetOneJiYangBaoJia(x => x.DH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除寄样单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改寄样单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    寄样单BLL.删除寄样单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString());
                    Chaxun();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "寄样单清单");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chaxun();
        }
        private void Chaxun()
        {
            Sunny.UI.UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            if (User.user.access == "所有")
            {
                gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ <= dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text) && x.Kuanhao.Contains(txtKuanhao.Text)
            && x.ys.Contains(txtyanse.Text) && x.SPMC.Contains(txtpingming.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.Hetonghao.Contains(txthetonghao.Text) && x.SPBH.Contains(txtbianhao.Text) && x.gg.Contains(txtGuige.Text) && x.Lianxiren.Contains(txtlianxiren.Text) && x.DH.Contains(FirstLetter.寄样单)).OrderByDescending(x => x.RQ).ToList();
            }
            else
            {
                gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ <= dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text) && x.Kuanhao.Contains(txtKuanhao.Text)
           && x.ys.Contains(txtyanse.Text) && x.SPMC.Contains(txtpingming.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.Hetonghao.Contains(txthetonghao.Text) && x.SPBH.Contains(txtbianhao.Text) && x.gg.Contains(txtGuige.Text) && x.Lianxiren.Contains(txtlianxiren.Text) && x.DH.Contains(FirstLetter.寄样单)&&x.own==User.user.YHBH ).OrderByDescending(x => x.RQ).ToList();
            }
            Sunny.UI.UIWaitFormService.HideWaitForm ();
        }
        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { ZJC=txtksmc.Text } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Chaxun();
            //gridControl1.DataSource = JiYangBaoJiaService.GetJiYangBaoJialst(x => x.RQ >= dateEdit1.DateTime && x.RQ <= dateEdit2.DateTime && x.KHMC.Contains(txtksmc.Text));
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Chaxun();
            }
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                if (gridView1.FocusedRowHandle>=0)
                {
                    var danhao = (gridControl1.DataSource as List<JiYangBaoJia>)[gridView1.FocusedRowHandle];
                    MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.复制, jiYangBaoJia = JiYangBaoJiaService.GetOneJiYangBaoJia(x => x.DH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
                }
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Chaxun();
        }
    }
}
