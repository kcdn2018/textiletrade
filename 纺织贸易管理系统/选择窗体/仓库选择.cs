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
    public partial class 仓库选择 : Form
    {
        public StockInfoTable stock = new StockInfoTable();
        public 仓库选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Query<StockInfoTable >(gridControl1, StockInfoTableService.GetStockInfoTablelst (x =>x.mingcheng .Contains (stock.mingcheng )));      
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateGrid.Query<StockInfoTable>(gridControl1, StockInfoTableService.GetStockInfoTablelst(x => x.mingcheng.Contains(txtzhujici.Text) ));
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<StockInfoTable>(gridControl1, StockInfoTableService.GetStockInfoTablelst(x => x.mingcheng.Contains(txtzhujici.Text) ));
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 仓库选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            stock =StockInfoTableService.GetOneStockInfoTable  (x => x.bianhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"bianhao").ToString ());
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 仓库选择_Load(object sender, EventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
