using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 垃圾桶 : Form
    {
        private List<RukuTable> rukuTables = new List<RukuTable>();
        public 垃圾桶()
        {
            InitializeComponent();
            var conMenu = new ContexMenuEX() { formName = this.Name, dataGridView  = uiDataGridView1 , menuStrip = contextMenuStrip1,obj=new RukuTable () };
            conMenu.Init();
            CreateGrid.CreateDatagridview(this.Name, uiDataGridView1);
            刷新数据();
        }

        private void 清空垃圾桶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RukuTableService.DeleteRukuTable("delete from RukuTable");
            刷新数据();
        }

        private void 删除垃圾ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RukuTableService.DeleteRukuTable(x=>x.ID==(int)uiDataGridView1.CurrentRow.Cells["ID"].Value );
            刷新数据();
        }
        private void 刷新数据()
        {            
            rukuTables = RukuTableService.GetRukuTablelst(x=>x.GH.Contains (txtganghao.Text )&&x.BH .Contains (txtCustomer.Text )&&x.PM.Contains (txtpingming.Text ));
            uiDataGridView1.DataSource = rukuTables;
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["BH"] = "合计";
            uiDataGridViewFooter1["MS"] = rukuTables.Sum(x => x.MS).ToString();
            uiDataGridViewFooter1["JS"] = rukuTables.Sum(x => x.JS).ToString();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            刷新数据();
        }

        private void txtganghao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                刷新数据();
            }    
        }
    }
}
