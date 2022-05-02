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

        private void 销售汇总_Load(object sender, EventArgs e)
        {
            //Connect.DbHelper().Queryable();
          DataTable dt=  Connect.CreatConnect().Query($" select saleman as 业务员,sum(TotalMishu) as 合计销售数量,sum(je) as 合计销售额,SUM(Profit) as 合计利润" +
                $" from DanjuTable where DanjuTable.djlx = '销售出库单' and DanjuTable.rq between '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime .Date.AddDays(1)}' group by SaleMan");
            dataGridViewX1.DataSource = dt;
            //txtfeiyong.Text = Connect.DbHelper().Queryable<DanjuTable>().Where(x => x.djlx == DanjuLeiXing.委外加工单 || x.djlx == DanjuLeiXing.委外取货单 || x.djlx == DanjuLeiXing.采购入库单).Sum (x=>x.yunfei );
        }
 
    }
}
