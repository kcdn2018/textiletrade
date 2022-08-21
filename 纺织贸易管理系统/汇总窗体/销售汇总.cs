using Model;
using Sunny.UI;
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
using 纺织贸易管理系统.新增窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 销售汇总 : Form
    {
        public 销售汇总()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
        }
        private void Query()
        {
            dataGridViewX1.Rows.Clear();
            DataTable dt = Connect.CreatConnect().Query($" select saleman as 业务员,sum(TotalMishu) as 合计销售数量,sum(je) as 合计销售额,SUM(Profit) as 合计利润 " +
              $" from DanjuTable where DanjuTable.djlx = '销售出库单' and DanjuTable.rq between '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'  group by SaleMan");
            var totaljine = dt.Compute("sum(合计销售额)", "true").TryToDecmial();
            var totallilun = dt.Compute("sum(合计利润)", "true").TryToDecmial();           
            txtstock.Text =Connect.CreatConnect().Query("select sum(t.AvgPrice *t.MS ) 库存金额 from StockTable t").Rows[0][0].ToString();
            txtxiaoshoue.Text = totaljine.ToString("F2");            
            txtfeiyong.Text = Connect.CreatConnect().Query($"select sum(t.yunfei+t.ChaCheFei+t.ZhuangXieFei ) from DanjuTable t where t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtyouhui.Text = Connect.CreatConnect().Query($"select sum(t.totalmoney ) from DanjuTable t where t.djlx ='收款单' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtcaigou.Text = Connect.CreatConnect().Query($"select sum(t.je ) from DanjuTable t where t.djlx ='{DanjuLeiXing.采购入库单 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtjiagong.Text = Connect.CreatConnect().Query($"select sum(t.je ) from DanjuTable t where t.djlx ='{DanjuLeiXing.委外取货单 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtshouru.Text = Connect.CreatConnect().Query($"select sum(t.totalmoney  ) from DanjuTable t where t.djlx ='{DanjuLeiXing.费用单  }' and  t.yaoqiu='{ShouzhiStyle.收入 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtzhichu .Text = Connect.CreatConnect().Query($"select sum(t.je  ) from DanjuTable t where t.djlx ='{DanjuLeiXing.费用单  }' and  t.yaoqiu='{ShouzhiStyle.支出  }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtlilun.Text =(txtxiaoshoue.Text .TryToDecmial ()+txtstock.Text.TryToDecmial ()-txtcaigou.Text .TryToDecmial ()-txtjiagong.Text.TryToDecmial ()+txtshouru.Text .TryToDecmial ()-txtzhichu.Text .TryToDecmial ()+txtyouhui.Text.TryToDecmial ()).ToString ("F2");
            dt.Columns.Add("提成");
            foreach (DataRow row in dt.Rows)
            {
                var Employer = YuanGongTableService .GetOneYuanGongTable(x => x.Xingming  == row["业务员"].ToString());
                row["业务员"] = string.IsNullOrEmpty(Employer.Xingming ) ? row["业务员"] : Employer.Xingming ;
                string zhanbi = (row["合计销售额"].TryToDecmial() / totaljine).ToString ("0.00%");
                row["提成"] = (txtlilun.Text .TryToDecmial () * Employer.TiCheng * (zhanbi.Split("%")[0]).TryToDecmial () /10000).ToString("F0");
                dataGridViewX1.AddRow(row["业务员"], row["合计销售数量"], row["合计销售额"], row["合计利润"], (row["合计销售额"].TryToDecmial() / totaljine).ToString("0.00%"), Employer.TiCheng , row["提成"]);
            }
        }
        private void 销售汇总_Load(object sender, EventArgs e)
        {
            //Connect.DbHelper().Queryable();
            Query();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as UIDataGridView; 
                if (dgv.Columns[e.ColumnIndex].HeaderText == "提成比例")
                {
                    var row = dgv.Rows[e.RowIndex];
                    row.Cells[Cticheng.Name ].Value = (txtlilun .Text .TryToDecmial() * row.Cells[CZanbi.Name].Value.ToString().Split("%")[0].TryToDecmial() * row.Cells[CTichengbili.Name ].Value.TryToDecmial() / 10000).ToString("F0");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 提成领用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 提成领用();
            fm.ShowDialog();
        }
    }
}
