using BLL;
using DevExpress.LookAndFeel;
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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 付款记录 : Form
    {
        private LXR Linkman = new LXR() { BH=""};
        public 付款记录()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
        }
        private void Query()
        {
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.djlx == DanjuLeiXing.付款单   && x.rq >= dateEdit1.DateTime && x.rq <= dateEdit2.DateTime && x.ksmc.Contains (txtksmc.Text )).OrderBy  (x=>x.rq ).ToList ());
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 供货商选择() { linkman=new LXR() { ZJC=txtksmc.Text } };
            fm.ShowDialog();
            Linkman = fm.linkman;
            txtksmc.Text = Linkman.MC;
            Query();
        }

        private void 收款记录_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "打款记录");
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "打款记录");
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除付款单"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    if (MessageBox.Show("您确定要删除改付款单吗？", this.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        付款单BLL.删除(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                        Query();
                    }
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改付款单"))
            {
                var fm = new 付款单() { Useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) };
                fm.ShowDialog();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }
    }
}
