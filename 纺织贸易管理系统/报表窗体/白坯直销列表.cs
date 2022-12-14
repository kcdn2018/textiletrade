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
using 纺织贸易管理系统.汇总窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 白坯直销列表 : Form
    {
        public 白坯直销列表()
        {
            InitializeComponent();
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
            dateEdit2.Value = DateTime.Now;
            dateEdit1.Value = dateEdit2.Value.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            Query();
        }
        public virtual void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            var querystring = $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ dateEdit1.Value.Date }' and '{dateEdit2.Value.Date.AddDays(1) }' and danjutable.ksmc like '%{txtksmc.Text}%' " +
                      $"and danjumingxitable.bianhao like '%{txtbianhao.Text }%' " +
                      $"and danjumingxitable.pingming like '%{txtpingming.Text }%' " +
                      $"and danjumingxitable.guige like '%{txtguige.Text }%' " +
                      $"and danjumingxitable.ContractNum like '%{txthetonghao.Text }%' " +
                      $"and danjumingxitable.OrderNum like '%{txtordermun.Text }%' " +
                      $"and danjutable.djlx='{DanjuLeiXing.白坯直销单}' " +
                      $"and danjutable.dh=danjumingxitable.danhao ";
            if (User.user.access == "自己")
            {
                querystring += $" and  danjutable.own='{User.user.YHBH }'";
            }
            querystring += " order by danjutable.id desc";
            DataTable dt = SQLHelper.SQLHelper.Chaxun(querystring);
            gridControl1.DataSource = dt;
            UIWaitFormService.HideWaitForm();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 白坯直销单() { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改白坯直销单") == true)
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                {
                    MainForm.mainform.AddMidForm(new 白坯直销单 () { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                }
                else
                {
                    if (SysInfo.GetInfo.own != "审核制")
                    {
                        MainForm.mainform.AddMidForm(new 白坯直销单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
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
            if (AccessBLL.CheckAccess("删除白坯直销单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改白坯直销单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                    {
                        白坯直销单BLL.删除单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
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
            ExportFile.导出到文件(gridControl1, "白坯直销清单");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = txtksmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void txtguige_KeyDown(object sender, KeyEventArgs e)
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
                MainForm.mainform.AddMidForm(new 白坯直销单() { useful = FormUseful.查看, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 审核单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("审核白坯直销单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                {
                    白坯直销单BLL.单据审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    AlterDlg.Show("审核成功！");
                    检测状态.检测(danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()));
                    Query();
                }
                else
                {
                    MessageBox.Show("该单据已经审核过了！无需再次审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("您没有权限审核改单据！请让管理员为你开通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 反审核单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("反审核白坯直销单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()))
                {
                    白坯直销单BLL.单据反审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    AlterDlg.Show("反审核成功！");
                    if (订单BLL.检查是否发完(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                    {
                        订单BLL.重启订单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    }
                    Query();
                }
                else
                {
                    MessageBox.Show("该单据还未审核通过！不能反审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
