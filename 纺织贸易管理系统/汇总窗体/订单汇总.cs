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
using 纺织贸易管理系统.报表窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.汇总窗体
{
    public partial class 订单汇总 : Form
    {
        public 订单汇总()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            Query();
        }
        private void Query()
        {
            string querystring = $"select distinct orderTable.* from orderTable,orderdetailTable where OrderTable.orderdate between '{ dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date }' and orderTable.CustomerName like '%{txtksmc.Text}%' " +            
            $"and OrderTable.OrderNum=Orderdetailtable.Ordernum ";
            querystring += " order by orderTable.orderdate desc";
            CreateGrid.Query(gridControl1, querystring);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderTable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var fm=new 订单进度() { OrderNum = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString() };
            fm.ShowDialog();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "销售订单汇总");
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = txtksmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }
    }
}
