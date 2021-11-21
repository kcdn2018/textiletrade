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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 色号资料 : Form
    {
        private List<ColorTable  > dblist = new List<ColorTable >();
        public 色号资料()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name ,gridView1 );
            gridView1.Columns["Color"].ColumnEdit = ColorEdit1; 
            Query();
        }
        private void Query()
        {
            dblist = ColorTableService .GetColorTablelst (x => x.ColorNum.Contains (txtzhujici.Text )&&x.ColorName.Contains (txtmingcheng.Text ));
            gridControl1.DataSource =dblist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new ColorTable () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 新增色号() { useFul=FormUseful.新增 };
            fm.ShowDialog();
            Query();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("修改色号"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    var fm = new 新增色号() { useFul = FormUseful.修改, ColorNum = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum").ToString() };
                    fm.ShowDialog();
                    Query();
                }
                else
                {
                    AlterDlg.Show("没有任何颜色被选中");
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增色号"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    var res = MessageBox.Show($"您确定要删除该编号{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum")}的色号信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if ((int)res == 6)
                    {
                        ColorTableService.DeleteColorTable(x => x.ColorNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum").ToString());
                        Query();
                    }
                }
                else
                {
                    AlterDlg.Show("没有任何颜色被选中");
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"色号信息");
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 打印标签ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
