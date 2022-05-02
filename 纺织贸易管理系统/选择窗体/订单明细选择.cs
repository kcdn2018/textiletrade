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
    public partial class 订单明细选择 : Sunny.UI.UIForm
    {
        public string OrderNum { get; set; }
        public List <OrderDetailTable > pingzhong { get; set; }
        private List<OrderDetailTable > dblist = new List<OrderDetailTable >();
        public 订单明细选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
        }

        private void 品种选择_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            if (!checkBox1.Checked)
            {
                dblist = OrderDetailTableService.GetOrderDetailTablelst($"select orderDetailTable.* from orderTable,orderDetailTable where ordertable.orderNum like " +
              $"'%{OrderNum}%' and OrderDetailTable.sampleName like '%{txtpingming.Text }%' and OrderDetailTable.color like '%{txtyanse.Text }%' and OrderDetailTable.sampleNum like '%{txtBianhao.Text }%' and OrderTable.OrderNum=OrderDetailTable.OrderNum  order by orderTable.ID desc");
            }
            else
            { 
            dblist = OrderDetailTableService.GetOrderDetailTablelst($"select orderDetailTable.* from orderTable,orderDetailTable where ordertable.orderNum like " +
                $"'%{OrderNum}%' and  OrderDetailTable.sampleName like '%{txtpingming.Text }%' and OrderDetailTable.color like '%{txtyanse.Text }%'  and OrderDetailTable.sampleNum like '%{txtBianhao.Text }%'  and OrderTable.state!='已完成' and OrderTable.OrderNum=OrderDetailTable.OrderNum  order by orderTable.ID desc");
        }
                gridControl1.DataSource = dblist;
           
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderDetailTable () };
            fm.ShowDialog();
        }

        private void 品种选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            pingzhong = new List<OrderDetailTable >();
            foreach (int i in gridView1.GetSelectedRows())
            {
                var ID = gridView1.GetRowCellValue(i, "ID");
                pingzhong.Add(dblist.Where (x=>x.ID==(int )ID).ToList ()[0]);
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

        private void txtOrderNum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                OrderNum = txtOrderNum.Text;
                Query(); 
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            Query();
        }
    }
}
