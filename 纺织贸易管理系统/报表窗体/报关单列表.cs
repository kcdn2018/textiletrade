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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 报关单列表 : Form
    {
        public 报关单列表()
        {
            InitializeComponent();  
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            Query();        
        }
        public virtual void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            var querystring = $"select BaoGuanTable.*,danjumingxitable.* from BaoGuanTable,danjumingxitable where BaoGuanTable.InvoiceDate between '{ dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1) }' and BaoGuanTable.Customer like '%{txtksmc.Text}%' " +
                      $"and danjumingxitable.bianhao like '%{txtbianhao.Text }%' " +
                      $"and danjumingxitable.pingming like '%{txtpingming.Text }%' " +
                      $"and danjumingxitable.guige like '%{txtGuige.Text }%' " +
                      $"and danjumingxitable.ColorNum like '%{txtyanse.Text }%' " +
                      $"and danjumingxitable.ContractNum like '%{txthetonghao.Text }%' " +
                      $"and danjumingxitable.OrderNum like '%{txtordernum.Text }%' " +
                      $"and danjumingxitable.ganghao like '%{txtganghao.Text }%' " +
                      $"and BaoGuanTable.FromSaleNo=danjumingxitable.danhao ";
            querystring += " order by BaoGuanTable.id desc";
            DataTable dt = SQLHelper.SQLHelper.Chaxun(querystring);
            gridControl1.DataSource = dt;
            UIWaitFormService.HideWaitForm();
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 新增报关单() { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改报关单") == true)
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString()) == false)
                {
                    MainForm.mainform.AddMidForm(new 新增报关单() { useful = FormUseful.修改, InnvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString()});
                }
                else
                {
                    if (SysInfo.GetInfo.own != "审核制")
                    {
                        MainForm.mainform.AddMidForm(new 新增报关单() { useful = FormUseful.修改, InnvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString() });
                    }
                    else
                    {
                        MessageBox.Show("对不起!改单据已经审核，如需修改请先取消审核状态！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("对不起!您没有权限修改该单据", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除报关单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改报关单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString()) == false)
                    {
                        销售发货单BLL.删除单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString());
                        Query();
                    }
                    else
                    {
                        MessageBox.Show("该单据已经审核过，不能删除！要删除需先取消审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "报关单清单");
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null ,dt=gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择 () { linkman = new LXR() { MC = txtksmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }



        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                MainForm.mainform.AddMidForm(new 新增报关单() { useful = FormUseful.查看, InnvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceNo").ToString() });
            }
        }
        private void 报关单列表_Load(object sender, EventArgs e)
        {

        }
    }
}

