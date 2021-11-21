using BLL;
using DevExpress.Xpo.DB.Helpers;
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

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 委外加工查询 : Form
    {
        public 委外加工查询()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Create(this.Name , gridView2);
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable() };
            fm.ShowDialog();
        }

        private void 采购查询_Load(object sender, EventArgs e)
        {
          
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x=>x.rq >=Convert.ToDateTime ( dateEdit1.Text)&&x.rq<= Convert.ToDateTime(dateEdit2.Text)&&x.ksmc .Contains (txtksmc.Text )&&x.zhuangtai !="已删除"&&x.djlx==DanjuLeiXing.委外加工单 ));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CreateGrid.Query<danjumingxitable>(gridControl2, danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString ()));
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess ("委外加工单") ==true )
            {
                MainForm.mainform.AddMidForm (new 委外加工单 () { useful=FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改委外加工单") == true)
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                {
                    MainForm.mainform.AddMidForm(new 委外加工单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                }
                else
                {
                    if (SysInfo.GetInfo.own != "审核制")
                    {
                        MainForm.mainform.AddMidForm(new 委外加工单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                    }
                    else
                    {
                        MessageBox.Show("对不起!改单据已经审核，如需修改请先取消审核状态！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("您没有权限修改此单据", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.委外加工单));
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess ("删除采购入库单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改采购单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                    {
                        委外发货单BLL.删除单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                        CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.委外加工单));
                    }
                    else
                    {
                        MessageBox.Show("该单据已经审核过，不能删除！要删除需先取消审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
                }
            }
        }


        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "委外加工单清单");
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("反审核委外加工单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()))
                {
                    委外发货单BLL .反审核 (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    MessageBox.Show("反审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.委外加工单 ));
                }
                else
                {
                    MessageBox.Show("该单据还未审核通过！不能反审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("审核采购单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                {
                    委外发货单BLL .审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    AlterDlg.Show("审核成功！");
                    CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.委外加工单));
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 委外加工单() { useful = FormUseful.查看, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }
    }
}
