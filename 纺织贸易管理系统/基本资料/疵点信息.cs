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

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 疵点信息 : Form
    {
        private List<CiDianNameTable > dblist = new List<CiDianNameTable >();
        public 疵点信息()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            dblist = CiDianNameTableService .GetCiDianNameTablelst ();
            CreateGrid.Query<CiDianNameTable >(gridControl1, dblist);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增疵点信息"))
            {
                var fm = new 新增疵点() { Useful = FormUseful.新增 };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }
        private void Query()
        {
            dblist = CiDianNameTableService .GetCiDianNameTablelst();
            gridControl1.DataSource = dblist;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("修改疵点信息"))
            {
                var fm = new 新增疵点() { Useful = FormUseful.修改, infoTable = CiDianNameTableService.GetOneCiDianNameTable(x => x.CiDianName == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CiDianName").ToString()) };
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
            if (BLL.AccessBLL.CheckAccess("删除疵点信息"))
            {
                var res = MessageBox.Show($"您确定要删除该编号{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bianhao")}的疵点信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if ((int)res == 6)
                {
                    CiDianNameTableService.DeleteCiDianNameTable(x => x.CiDianName == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CiDianName").ToString());
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
            ExportFile.导出到文件(gridControl1, "疵点信息");
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "疵点信息");
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 修改品种ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 新增疵点() { Useful = FormUseful.修改, infoTable = CiDianNameTableService .GetOneCiDianNameTable(x => x.CiDianName == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CiDianName").ToString()) };
            fm.ShowDialog();
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
