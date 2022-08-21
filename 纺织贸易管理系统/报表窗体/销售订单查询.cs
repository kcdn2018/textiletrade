using BLL;
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
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.汇总窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 销售订单查询 : Form
    {
        public 销售订单查询()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            Query();
            
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改销售计划单") == true)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.修改, order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) });
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (AccessBLL.CheckAccess("删除销售计划单"))
                {
                    if ((int)(MessageBox.Show("您确定要删除改销售计划单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == 6)
                    {
                        if (订单BLL.删除(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) == false)
                        {
                            MessageBox.Show("删除计划单失败,有过采购记录的不能退删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                        CreateGrid.Query<OrderTable>(gridControl1, OrderTableService.GetOrderTablelst(x => x.Orderdate >= dateEdit1.DateTime && x.Orderdate <=dateEdit2.DateTime.Date.AddDays(1) && x.CustomerName.Contains(txtksmc.Text)));
                    }
                }
                else
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "销售计划单清单");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }
        private  void Query()
        {
            string querystring = $"select * from orderTable,orderdetailTable where OrderTable.orderdate between '{ dateEdit1.DateTime}' and '{dateEdit2.DateTime.Date.AddDays(1)}' and orderTable.CustomerName like '%{txtksmc.Text}%' " +
                $"and OrderTable.OrderNum like '%{txtOrdernum.Text }%'" +
                $"and OrderDetailTable.sampleNum like '%{txtbianhao.Text }%' " +
                $"and OrderDetailTable.sampleName like '%{txtpingming.Text }%' " +
                $"and OrderDetailTable.Specifications like '%{txtGuige.Text }%' " +
                $"and OrderDetailTable.ColorNum like '%{txtsehao.Text }%' " +
                 $"and OrderDetailTable.color like '%{txtyanse .Text }%' " +
                $"and OrderTable.ContractNum like '%{txthetonghao.Text }%' " +
                $"and OrderDetailTable.CustomerPingMing like '%{txtCustomerPingming .Text }%' " +
                $"and OrderDetailTable.CustomerColorNum like '%{txtCustomerColorNum .Text }%' " +
                 $"and OrderDetailTable.Huahao like '%{txthuahao.Text }%' " +
                $"and OrderTable.OrderNum=Orderdetailtable.Ordernum";
            if(rdweiwancheng .Checked==true  )
            {
                querystring += " and OrderTable.state!='已完成'";
            }
            if(rbyiwancheng .Checked==true )
            {
                querystring += " and OrderTable.state='已完成'";
            }
            if(User.user.access =="自己")
            {
                querystring += $" and OrderTable.own='{User.user.YHBH   }'";
            }
            querystring += " order by orderTable.orderdate desc";
            var dt = SQLHelper.SQLHelper.Chaxun(querystring );
            if (checkBox1.Checked)
            {
                for(int row=0;row<dt.Rows.Count;row++)
                {
                    if(row>0)
                    {
                        if(dt.Rows[row]["price"].TryToDecmial ()==dt.Rows[row-1]["price"].TryToDecmial ()&&dt.Rows[row]["OrderNum"].ToString ()== dt.Rows[row-1]["OrderNum"].ToString ())
                        {
                            decimal a = dt.Rows[row]["Num"].TryToDecmial();
                            decimal b = dt.Rows[row-1]["Num"].TryToDecmial();
                            dt.Rows[row - 1]["Num"] = a + b;
                            a = dt.Rows[row]["Total"].TryToDecmial();
                            b = dt.Rows[row-1]["Total"].TryToDecmial();
                            dt.Rows[row - 1]["Total"] = a + b;
                            dt.Rows.RemoveAt(row);
                            row -= 1;
                        }
                    }
                }
             
                gridControl1.DataSource = dt;
                gridView1.Columns["color"].Visible = false;
                gridControl1.RefreshDataSource();
            }
            else
            {
                gridControl1.DataSource = dt;
                gridView1.Columns["color"].Visible = true;
                gridControl1.RefreshDataSource();
            }
           uiLabel1 .Text = "共计订单数："+ dt.DefaultView.ToTable(true,"OrderNum").Rows.Count .ToString ();
        }

        private void 查看进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("查看进度") == true)
            {
                MainForm.mainform.AddMidForm(new 订单进度() { OrderNum = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString() });
            }
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = txtksmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,  dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                订单BLL.审核订单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                AlterDlg.Show("审核成功！");
                Query();
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
                Query();
            }
            catch
            {
                MessageBox.Show("反审核订单的时候发生了错误！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.查看, order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) });
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 结束订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle >=0)
            {
                OrderTable order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                订单BLL.结束订单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());             
                Query();
            }            
        }

        private void 重启订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                订单BLL.重启订单 (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString());
                Query();
            }
        }

        private void rbyiwancheng_CheckedChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void 汇总报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("订单汇总") == true)
            {
                MainForm.mainform.AddMidForm(new 订单汇总());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked )
            {
                gridView1.OptionsView.AllowCellMerge = true;
            }
            else
            {
                gridView1.OptionsView.AllowCellMerge = false;
            }
        }

        private void 复制新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 销售计划单() { useful = FormUseful.复制, order = OrderTableService.GetOneOrderTable(x => x.OrderNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNum").ToString()) });
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
