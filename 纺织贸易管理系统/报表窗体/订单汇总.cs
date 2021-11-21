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

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 订单汇总 : Form
    {
        public 订单汇总()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsView.AllowCellMerge = true;
            gridView1.OptionsCustomization.AllowSort = true;
            Query();
        }
        private void Query()
        {
            string querystring = $"select orderTable.*,orderDetailTable.* from orderTable,orderdetailTable where OrderTable.orderdate between '{ Convert.ToDateTime(dateEdit1.Text)}' and '{Convert.ToDateTime(dateEdit2.Text)}' and orderTable.CustomerName like '%{txtksmc.Text}%' " +
                $"and OrderTable.OrderNum like '%{txtOrdernum.Text }%'" +
                $"and OrderDetailTable.sampleNum like '%{txtbianhao.Text }%' " +
                $"and OrderDetailTable.sampleName like '%{txtpingming.Text }%' " +
                $"and OrderDetailTable.Specifications like '%{txtGuige.Text }%' " +
                $"and OrderDetailTable.ColorNum like '%{txtyanse.Text }%' " +
                $"and OrderTable.ContractNum like '%{txthetonghao.Text }%' " +
                $"and OrderTable.OrderNum=Orderdetailtable.Ordernum";
            if (rdweiwancheng.Checked == true)
            {
                querystring += " and OrderTable.state!='已完成'";
            }
            if (rbyiwancheng.Checked == true)
            {
                querystring += " and OrderTable.state='已完成'";
            }
            querystring += " order by orderTable.orderdate desc";
            var dt = SQLHelper.SQLHelper.Chaxun(querystring);
            var listdanju = SQLHelper.SqlSugor.ChangToModel<OrderTable >(dt);
            var mingxi = SQLHelper.SqlSugor.ChangToModel<OrderDetailTable >(dt);
            CreateGrid.Query(gridControl1, querystring);
        }
    }
}
