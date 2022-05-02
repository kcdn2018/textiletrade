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

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 账户资料 : Form
    {
        public SKFS   skfs { get; set; }
        public 账户资料()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst  (x => x.ZJC.Contains(txtzhujici.Text)));
        }
       
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj =new SKFS () };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode ==Keys.Enter )
            {
                CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var shoukuanfangshi = gridView1.GetRowCellValue (gridView1.FocusedRowHandle , "Skfs").ToString();
                MainForm.mainform.AddMidForm(new 账户流水单() { Shoukuanfangshi=shoukuanfangshi });
            }
        }

        private void 客户选择_FormClosed(object sender, FormClosedEventArgs e)
        {         
            skfs =SKFSService.GetOneSKFS (x=>x.BH ==gridView1 .GetRowCellValue ( gridView1.FocusedRowHandle, "BH").ToString ());
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void 客户选择_Load(object sender, EventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增账户资料"))
            {
                new 新增收款方式() { useful = FormUseful.新增 }.ShowDialog();
            CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
        } 
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
        }

    }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("修改账户资料"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    new 新增收款方式() { useful = FormUseful.修改, shoukuanfangshi = SKFSService.GetOneSKFS(x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString()) }.ShowDialog();
                    CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("删除账户资料"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    SKFSService.DeleteSKFS(x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString());
                    CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 美金结转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 账户转账();
            fm.ShowDialog();
        }
    }
}
