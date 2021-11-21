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
    public partial class 支架信息 : Form
    {
        private List<ZhijiaTable  > dblist = new List<ZhijiaTable >();
        public 支架信息()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name ,gridView1 );           
            cmbCangkumingcheng.DataSource = StockInfoTableService.GetStockInfoTablelst(x => x.Leixing.Contains("")).Select(x => x.mingcheng).ToList(); 
            dblist = ZhijiaTableService .GetZhijiaTablelst (x =>x.StockName==cmbCangkumingcheng.Text );
            CreateGrid.Query<ZhijiaTable >(gridControl1,dblist );
        }
        private void Query()
        {
            dblist = ZhijiaTableService.GetZhijiaTablelst(x => x.StockName == cmbCangkumingcheng.Text);
            gridControl1.DataSource =dblist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增支架信息"))
            {
                var fm = new 新增支架() { Useful = FormUseful.新增, zhijiaTable = new ZhijiaTable() { StockName = cmbCangkumingcheng.Text, StockIndex = StockInfoTableService.GetOneStockInfoTable(x => x.mingcheng == cmbCangkumingcheng.Text).bianhao } };
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
            if (BLL.AccessBLL.CheckAccess("修改支架信息"))
            {
                var fm = new 新增支架() { Useful = FormUseful.修改, zhijiaTable = dblist[gridView1.FocusedRowHandle] };
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
            if (BLL.AccessBLL.CheckAccess("删除支架信息"))
            {
                var res = MessageBox.Show($"您确定要删除该编号{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh")}的客户信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if ((int)res == 6)
                {
                    var index = gridView1.FocusedRowHandle;
                    ZhijiaTableService.DeleteZhijiaTable(x => x.StockName == dblist[index].StockName && x.StockIndex == dblist[index].StockIndex && x.Zhijiahao == dblist[index].Zhijiahao);
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
            ExportFile.导出到文件(gridControl1,"支架信息");
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 支架信息_Load(object sender, EventArgs e)
        {

        }

        private void cmbCangkumingcheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void 打印标签ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
