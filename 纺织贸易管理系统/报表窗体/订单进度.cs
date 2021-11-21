using BLL;
using DevExpress.Xpo.DB.Helpers;
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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 订单进度 : Form
    {
        public  string OrderNum { get; set; }
        public 订单进度()
        {
            InitializeComponent();  
            CreateGrid.Create("销售计划单" , gridView1);
            CreateGrid.Create(this.Name , gridView2);
            foreach (Control  c in groupPanel1.Controls)
            {
                c.Enabled = false;
            }       
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderDetailTable  () };
            fm.ShowDialog();
        }

        private void 采购查询_Load(object sender, EventArgs e)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
            txtbeizhu.Text = order.Remakers;
            txtdanhao.Text = order.OrderNum;
            dateEdit1.Text = order.Orderdate.ToShortDateString();
            txtdayangfei.Text = order.DayangFei;
            txtdingjing.Text = order.Deposit.ToString();
            txthetonghao.Text = order.ContractNum;
            txtkehu.Text = order.CustomerName;
            txtxiaogangfei.Text = order.XiaogangFei;
            txtyaoqiu.Text = order.Yaoqiu;
            txtyewuyuan.Text = order.SaleMan;
            txtzhibanfei.Text = order.ZhibanFei.ToString();
            dateEdit2.DateTime = order.delivery;
            if (order.Rax == true)
            {
                comhanshui.Text = "含税";
            }
            else
            {
                comhanshui.Text = "不含税";
            }
            gridControl1.DataSource = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == txtdanhao.Text);
            gridControl2.DataSource = ProcessTableService.GetProcessTablelst(x => x.OrderNum == txtdanhao.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new ProcessTable () };
            fm.ShowDialog();
        }
        
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = ProcessTableService.GetProcessTablelst(x => x.OrderNum == txtdanhao.Text);
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl2,"进度清单");
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }
    }
}
