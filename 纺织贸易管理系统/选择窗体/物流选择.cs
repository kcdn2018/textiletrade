using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 物流选择 : Form
    {
        public WuliuTable  linkman = new WuliuTable ();
        public 物流选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Query<WuliuTable >(gridControl1, WuliuTableService.GetWuliuTablelst (x => x.name .Contains(txtzhujici.Text)));
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<WuliuTable>(gridControl1, WuliuTableService.GetWuliuTablelst(x => x.name.Contains(txtzhujici.Text)));
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateGrid.Query<WuliuTable>(gridControl1, WuliuTableService.GetWuliuTablelst(x => x.name.Contains(txtzhujici.Text)));
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 客户选择_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            linkman = WuliuTableService.GetOneWuliuTable   (x => x.Bianhao  == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bianhao").ToString());
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
