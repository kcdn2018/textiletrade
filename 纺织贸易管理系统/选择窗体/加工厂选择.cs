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
    public partial class 加工厂选择 : Sunny.UI.UIForm 
    {
        public string StockName { get; set; }
        public 加工厂选择()
        {
            InitializeComponent();
            gridControl1.DataSource = Connect.DbHelper().Ado.SqlQuery<string>("select distinct CKMC from stocktable where StockTable.CKMC not in (select mingcheng  from StockInfoTable )");  
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 仓库选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            if (gridView1.FocusedRowHandle >= 0)
            {
                StockName =  gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKMC").ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
