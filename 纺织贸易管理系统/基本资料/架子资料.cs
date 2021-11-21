using DAL;
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
    public partial class 架子资料 : Form
    {
        private List<JiaziTable   > dblist = new List<JiaziTable  >();
        public 架子资料()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name ,gridView1 );           
            dblist = JiaziTableService .GetJiaziTablelst ();
            uiDatePicker2.Value = DateTime.Now;
            uiDatePicker1.Value = DateTime.Now.AddDays(-30);
            CreateGrid.Query<JiaziTable  >(gridControl1,dblist );
            uiDataGridView1.AutoGenerateColumns = false;
        }
        private void Query()
        {
            dblist = JiaziTableService .GetJiaziTablelst();
            gridControl1.DataSource =dblist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj =new JiaziTable () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增支架信息"))
            {
                var fm = new 新增架子() { Useful = FormUseful.新增, zhijiaTable = new JiaziTable () };
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
                var fm = new 新增架子() { Useful = FormUseful.修改, zhijiaTable = dblist.First(x => x.JiaziID == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "JiaziID").ToString()) };
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
                    JiaziTableService .DeleteJiaziTable(x => x.JiaziID  ==gridView1.GetRowCellValue (gridView1.FocusedRowHandle,"JiaziID").ToString ());
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
     

        private void 支架信息_Load(object sender, EventArgs e)
        {

        }

        private void 打印标签ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 架子出库();
            fm.ShowDialog();
            Query();
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 架子入库();
            fm.ShowDialog();
            Query();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle >=0)
            {
                uiDataGridView1.DataSource = ZhijiaMingxiTableService.GetZhijiaMingxiTablelst(x => x.Bianhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString() && x._date >= uiDatePicker1.Value
               && x._date <= uiDatePicker2.Value);
            }
        }
    }
}
