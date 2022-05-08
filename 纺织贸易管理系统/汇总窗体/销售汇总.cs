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
              $" from DanjuTable where DanjuTable.djlx = '销售出库单' and DanjuTable.rq between '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}' group by SaleMan");
            var totaljine = dt.Compute("sum(合计销售额)", "true").TryToDecmial();
            var totallilun = dt.Compute("sum(合计利润)", "true").TryToDecmial();
            foreach (DataRow row in dt.Rows)
            {
                var name = YhbService.GetOneYhb(x => x.YHBH == row["业务员"].ToString()).YHMC;
                row["业务员"] = string.IsNullOrEmpty(name) ? row["业务员"] : name;
                dataGridViewX1.AddRow(row["业务员"], row["合计销售数量"], row["合计销售额"], row["合计利润"], (row["合计销售额"].TryToDecmial() / totaljine).ToString("0%"));
            }
            txtstock.Text = Connect.CreatConnect().Query("select sum(t.AvgPrice *t.MS ) 库存金额 from StockTable t").Rows[0][0].ToString();
            txtxiaoshoue.Text = totaljine.ToString();
            txtlilun.Text = totallilun.ToString();
            txtfeiyong.Text = Connect.CreatConnect().Query($"select sum(t.yunfei+t.ChaCheFei+t.ZhuangXieFei ) from DanjuTable t where t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtyouhui.Text = Connect.CreatConnect().Query($"select sum(t.totalmoney ) from DanjuTable t where t.djlx ='收款单' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtcaigou.Text = Connect.CreatConnect().Query($"select sum(t.je ) from DanjuTable t where t.djlx ='{DanjuLeiXing.采购入库单 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtjiagong.Text = Connect.CreatConnect().Query($"select sum(t.je ) from DanjuTable t where t.djlx ='{DanjuLeiXing.委外取货单 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtshouru.Text = Connect.CreatConnect().Query($"select sum(t.totalmoney  ) from DanjuTable t where t.djlx ='{DanjuLeiXing.费用单  }' and  t.yaoqiu='{ShouzhiStyle.收入 }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
            txtshouru.Text = Connect.CreatConnect().Query($"select sum(t.je  ) from DanjuTable t where t.djlx ='{DanjuLeiXing.费用单  }' and  t.yaoqiu='{ShouzhiStyle.支出  }' and t.rq between  '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'").Rows[0][0].ToString();
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
    }
}
