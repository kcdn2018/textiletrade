using DevComponents.AdvTree;
using DevExpress.XtraEditors;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 仓库信息 : Form
    {
        private List<StockInfoTable> dblist = new List<StockInfoTable>();
        public 仓库信息()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name ,gridView1 );
            dblist = StockInfoTableService.GetStockInfoTablelst(x=>x.Leixing.Contains (""));
            CreateGrid.Query<StockInfoTable>(gridControl1,dblist );
        }
        private void Query()
        {
            dblist = StockInfoTableService.GetStockInfoTablelst(x => x.Leixing.Contains(""));
            gridControl1.DataSource =dblist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增仓库"))
            {
                var fm = new 新增仓库() { Useful = FormUseful.新增 };
                fm.ShowDialog();
                Query();
            }
          else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("修改仓库"))
            {
                var fm = new 新增仓库() { Useful = FormUseful.修改, infoTable = StockInfoTableService.GetOneStockInfoTable(x => x.bianhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bianhao").ToString()) };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("删除仓库"))
            {
                var res = MessageBox.Show($"您确定要删除该编号{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bianhao")}的仓库信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if ((int)res == 6)
                {
                    StockInfoTableService.DeleteStockInfoTable(x => x.bianhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bianhao").ToString());
                    Query();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"仓库信息");
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
