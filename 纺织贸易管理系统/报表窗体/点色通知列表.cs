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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 点色通知列表 : Form
    {
        public 点色通知列表()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            Query();
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
            gridView1.OptionsCustomization.AllowSort = true;
        }
        public virtual void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            var querystring = $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ dateEdit1.DateTime}' and '{dateEdit2.DateTime.Date.AddDays(1)}' and danjutable.ksmc like '%{txtksmc.Text}%' " +
                    $"and danjumingxitable.bianhao like '%{txtbianhao.Text }%' " +
                    $"and danjumingxitable.pingming like '%{txtpingming.Text }%' " +
                    $"and danjumingxitable.guige like '%{txtGuige.Text }%' " +
                    $"and danjumingxitable.ColorNum like '%{txtyanse.Text }%' " +
                    $"and danjumingxitable.ContractNum like '%{txthetonghao.Text }%' " +
                    $"and danjumingxitable.OrderNum like '%{txtordernum.Text }%' " +
                    $"and danjutable.djlx='{DanjuLeiXing.点色通知单   }' " +
                    $"and danjutable.dh=danjumingxitable.danhao";
            if (User.user.access == "自己")
            {
                querystring += $" and danjutable.own='{User.user.YHBH }'";
            }
            querystring += " order by danjutable.id desc";
            CreateGrid.Query(gridControl1, querystring);
            UIWaitFormService.HideWaitForm();
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 点色通知单() { UseFul = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改点色通知单") == true)
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    MainForm.mainform.AddMidForm(new 点色通知单() { UseFul = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (AccessBLL.CheckAccess("删除点色通知单"))
                {
                    if ((int)(MessageBox.Show("您确定要删除改点色通知单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                    {
                        string danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString();
                        var oldmingxi = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                        DanjuTable danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                        //库存BLL.减少库存(oldmingxi, danju);
                        //oldmingxi.ForEach(m => m.houzhengli = m.houzhengli.Substring(0, m.houzhengli.Length - 4));
                        //库存BLL.增加库存(oldmingxi, danju);
                        单据BLL.删除单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                        Query();
                    }
                }
                else
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
                }
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "点色通知单清单");
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL.审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL.未审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                MainForm.mainform.AddMidForm(new 点色通知单 () { UseFul  = FormUseful.查看, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
            }
        }
    }
}
