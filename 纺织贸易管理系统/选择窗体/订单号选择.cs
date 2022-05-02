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
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 订单号选择 : Sunny.UI.UIForm
    {
        /// <summary>
        /// 查询返回模式，1表示返回明细返回，0表示只返回一个订单号
        /// </summary>
        public int UseFul { get; set; }
        public OrderTable Order { get; set; }
        public List<ReturnData > returnDatas { get; set; }
        public 订单号选择()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            gridView1.OptionsView.AllowCellMerge = false;
            gridView1.OptionsCustomization.AllowSort = true;
            
            Query();
        }
        public class ReturnData
        {
            public OrderTable order { get; set; }
            public OrderDetailTable orderDetail { get; set; }
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 订单号选择_FormClosed(object sender, FormClosedEventArgs e)
        {         
            try
            {
                if (UseFul == 0)
                {
                    Order = new OrderTable();
                    if (gridView1.FocusedRowHandle >= 0)
                    {
                        Order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                    }
                }
                else
                {
                    returnDatas = new List<ReturnData>();
                    foreach(int row in gridView1.GetSelectedRows ())
                    {
                        returnDatas.Add(new ReturnData() { order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(row, "OrderNum").ToString()),
                            orderDetail = OrderDetailTableService .GetOneOrderDetailTable(x => x.ID ==(int) gridView1.GetRowCellValue(row, "ID1"))
                    });
                    }
                }
            }
            catch(Exception ex)
            {
                Sunny.UI.UIMessageBox.Show(ex.Message);
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
           string q = $"select orderTable.*,orderDetailTable.* from orderTable,orderdetailTable where OrderTable.orderdate between '{ dateEdit1.DateTime}' and '{dateEdit2.DateTime.Date.AddDays(1)}' and orderTable.CustomerName like '%{txtksmc.Text}%' " +
               $"and OrderDetailTable.sampleNum like '%{txtbianhao.Text }%' " +
               $"and OrderDetailTable.sampleName like '%{txtpingming.Text }%' " +
               $"and OrderDetailTable.Specifications like '%{txtGuige.Text }%' " +
               $"and OrderDetailTable.ColorNum like '%{txtyanse.Text }%' " +
               $"and OrderTable.OrderNum like '%{txtOrderNum.Text }%' " +
               $"and OrderTable.ContractNum like '%{txthetonghao.Text }%' " +
               $"and OrderTable.OrderNum=Orderdetailtable.Ordernum";
            if(checkBox1 .Checked!=true )
            {
                q += $" and OrderTable.state='已审核'";
            }
            if (User.user.access == "自己")
            {
                q += $" and  OrderTable.own='{User.user.YHBH }'";
            }
            q += " order by orderTable.orderDate desc";
            CreateGrid.Query(gridControl1,q);
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.OptionsView.AllowCellMerge = checkBox2.Checked ;
        }

        private void 订单号选择_Load(object sender, EventArgs e)
        {          
                gridView1.OptionsSelection.MultiSelect = UseFul == 0 ? false : true;
        }
    }
}
