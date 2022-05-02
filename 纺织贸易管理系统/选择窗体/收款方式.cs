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

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 收款方式 : Form
    {
        public SKFS   skfs { get; set; }
        public 收款方式()
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
            this.Close();
        }

        private void 客户选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                skfs = SKFSService.GetOneSKFS(x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString());
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
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
            new 新增收款方式() { useful = FormUseful.新增 }.ShowDialog();
            CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                new 新增收款方式() { useful = FormUseful.修改, shoukuanfangshi = SKFSService.GetOneSKFS(x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString()) }.ShowDialog();
                CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                SKFSService.DeleteSKFS (x=>x.BH==gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString()) ;
                CreateGrid.Query<SKFS>(gridControl1, SKFSService.GetSKFSlst(x => x.ZJC.Contains(txtzhujici.Text)));
            }
        }

        private void 查看流水ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
