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
    public partial class 发货通知单查询 : Form
    {
        public 发货通知单查询()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now ;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView2);
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
          
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x=>x.rq >=Convert.ToDateTime ( dateEdit1.Text)&&x.rq<= Convert.ToDateTime(dateEdit2.Text)&&x.ksmc .Contains (txtksmc.Text )&&x.zhuangtai !="已删除"&&x.djlx==DanjuLeiXing.发货通知单  ));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new danjumingxitable () };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CreateGrid.Query<danjumingxitable>(gridControl2, danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString ()));
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess (this.Name)==true)
            {
                MainForm.mainform.AddMidForm (new 发货通知单() { useful=FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改发货通知单") == true)
            {
                MainForm.mainform.AddMidForm(new 发货通知单() { useful = FormUseful.修改,danju =DanjuTableService.GetOneDanjuTable (x=>x.dh==gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"dh").ToString ())});
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.发货通知单));
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除发货通知单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改发货通知单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    单据BLL.删除单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.发货通知单));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"发货通知单清单");
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL.审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL .未审核 (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 发货通知单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
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
