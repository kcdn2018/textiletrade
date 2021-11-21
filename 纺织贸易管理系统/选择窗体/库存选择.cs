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
    public partial class 库存选择 : Form
    {
        public string StockName { get; set; } = "";
        public List <StockTable > pingzhong { get; set; }
        private List<StockTable > dblist = new List<StockTable >();
        public 库存选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Query<StockTable>(gridControl1, dblist.OrderByDescending(x=>x.ID ).ToList ());
            gridView1.OptionsCustomization.AllowSort = true;
        }

        private void 品种选择_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            dblist = Connect.DbHelper().Queryable <StockTable >().Where  (x => x.ContractNum .Contains(txthetonghao.Text) && x.PM .Contains(txtpingming.Text) && x.GG .Contains(txtguige.Text) && x.GH.Contains(txtganghao.Text) && x.kuanhao.Contains(txthuohao.Text)&& x.CKMC.Contains(StockName )
            &&x.CustomName.Contains (txtkehu.Text )&&x.orderNum.Contains (txtOrderNum.Text ) ).ToList () .OrderByDescending(x=>x.ID ).ToList ();
            gridControl1.DataSource = dblist;
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new StockTable() };
            fm.ShowDialog();
        }

        private void 品种选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            pingzhong = new List<StockTable >();
            foreach (int i in gridView1.GetSelectedRows())
            {
                pingzhong.Add(dblist.Where(x => x.ID==(int) gridView1.GetRowCellValue(i, "ID")).ToList()[0]);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            this.Close();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
