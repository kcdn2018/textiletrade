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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 销售计划单查询 : Form
    {
        public 销售计划单查询()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Create(this.Name , gridView2);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderTable () };
            fm.ShowDialog();
        }
        private void Query()
        {
            string querystring = $"select distinct orderTable.* from orderTable,orderdetailTable where OrderTable.orderdate between '{ Convert.ToDateTime(dateEdit1.Text)}' and '{Convert.ToDateTime(dateEdit2.Text)}' and orderTable.CustomerName like '%{txtksmc.Text}%' " +
               $"and OrderTable.OrderNum like '%{txtOrdernum.Text }%'" +
               $"and OrderDetailTable.sampleNum like '%{txtbianhao.Text }%' " +
               $"and OrderDetailTable.sampleName like '%{txtpingming.Text }%' " +
               $"and OrderDetailTable.Specifications like '%{txtGuige.Text }%' " +
               $"and OrderDetailTable.ColorNum like '%{txtyanse.Text }%' " +
               $"and OrderTable.ContractNum like '%{txthetonghao.Text }%' "+
            $"and OrderTable.OrderNum=Orderdetailtable.Ordernum ";
            if (rdweiwancheng.Checked == true)
            {
                querystring += " and ordertable.state!='已完成'";
            }
            if (rbyiwancheng.Checked == true)
            {
                querystring += " and OrderTable.state='已完成'";
            }
            querystring += " order by orderTable.orderdate desc";
            CreateGrid.Query(gridControl1, querystring);
        }
        private void 采购查询_Load(object sender, EventArgs e)
        {

            Query();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new OrderDetailTable () };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CreateGrid.Query<OrderDetailTable >(gridControl2, OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum  == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString ()));
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess (this.Name)==true)
            {
                MainForm.mainform.AddMidForm (new 销售计划单 () { useful=FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改销售计划单") == true)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.修改,order  =OrderTableService .GetOneOrderTable  (x=>x.OrderNum ==gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"OrderNum").ToString ())});
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除销售计划单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改销售计划单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == 6)
                {
                    if (订单BLL.删除(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) == false)
                    {
                        MessageBox.Show("删除计划单失败,有过采购记录的不能退删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                    CreateGrid.Query<OrderTable>(gridControl1, OrderTableService.GetOrderTablelst(x => x.Orderdate >= Convert.ToDateTime(dateEdit1.Text) && x.Orderdate <= Convert.ToDateTime(dateEdit2.Text) && x.CustomerName.Contains(txtksmc.Text)));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"销售计划单清单");
        }

        private void 查看进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 订单进度() { OrderNum= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString() });
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.查看, order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) });
            }
        }
        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                订单BLL.审核订单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                AlterDlg.Show("审核成功！");
                CreateGrid.Query<OrderTable>(gridControl1, OrderTableService.GetOrderTablelst(x => x.Orderdate >= Convert.ToDateTime(dateEdit1.Text) && x.Orderdate <= Convert.ToDateTime(dateEdit2.Text) && x.CustomerName.Contains(txtksmc.Text)));
            }
            catch
            {
                MessageBox.Show("审核订单的时候发生了错误！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                订单BLL.反审核订单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                AlterDlg.Show("反审核成功！");
                CreateGrid.Query<OrderTable>(gridControl1, OrderTableService.GetOrderTablelst(x => x.Orderdate >= Convert.ToDateTime(dateEdit1.Text) && x.Orderdate <= Convert.ToDateTime(dateEdit2.Text) && x.CustomerName.Contains(txtksmc.Text)));
            }
            catch
            {
                MessageBox.Show("反审核订单的时候发生了错误！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = txtksmc.Text,ZJC="" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            CreateGrid.Query<OrderTable>(gridControl1, OrderTableService.GetOrderTablelst(x => x.Orderdate >= Convert.ToDateTime(dateEdit1.Text) && x.Orderdate <= Convert.ToDateTime(dateEdit2.Text) && x.CustomerName.Contains(txtksmc.Text)));
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void rdweiwancheng_CheckedChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }
    }
}
