using BLL;
using Microsoft.VisualBasic;
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
    public partial class 寄件列表 : Form
    {
        public 寄件列表()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "物流记录");
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            if (User.user.access == "所有")
            {
                gridControl1.DataSource = DanjuTableService.GetDanjuTablelst(x => x.djlx == DanjuLeiXing.物流登记 && x.rq >= dateEdit1.DateTime.Date && x.rq <= dateEdit2.DateTime.Date
                && x.ksmc.Contains(txtksmc.Text) && x.shouhuodizhi.Contains(txtshdz.Text) && x.own.Contains(txtjsr.Text) && x.dh.Contains(txtdanhao.Text) && x.wuliugongsi.Contains(cmbwuliugongshi.Text)
                && x.StockName.Contains(cmbquyu.Text)).OrderByDescending(x => x.rq).ToList();
            }else
            {
                gridControl1.DataSource = DanjuTableService.GetDanjuTablelst(x => x.djlx == DanjuLeiXing.物流登记 && x.rq >= dateEdit1.DateTime.Date && x.rq <= dateEdit2.DateTime.Date
               && x.ksmc.Contains(txtksmc.Text) && x.shouhuodizhi.Contains(txtshdz.Text) && x.own.Contains(txtjsr.Text) && x.dh.Contains(txtdanhao.Text) && x.wuliugongsi.Contains(cmbwuliugongshi.Text)
               && x.StockName.Contains(cmbquyu.Text)&&x.own==User.user.YHBH  ).OrderByDescending(x => x.rq).ToList();
            }
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 寄件登记() { useful=FormUseful.新增 };
            fm.ShowDialog();
            Query();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改寄件登记"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    var fm = new 寄件登记() { useful = FormUseful.修改, danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString() };
                    fm.ShowDialog();
                    Query();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除寄件登记"))
            {
                if (MessageBox.Show("您确定要删除改物流登记信息吗？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gridView1.FocusedRowHandle >= 0)
                    {
                        DanjuTableService.DeleteDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                        Query();
                    }
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void txtdanhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void cmbquyu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = "", MC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }
    }
}
