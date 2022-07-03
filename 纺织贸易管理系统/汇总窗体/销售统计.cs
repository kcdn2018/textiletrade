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

namespace 纺织贸易管理系统.汇总窗体
{
    public partial class 销售统计 : Form
    {
        public 销售统计()
        {
            InitializeComponent();
         
        }
        private void Query()
        {
            var querystring = $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ dateEdit1.Value.Date }' and '{dateEdit2.Value.Date.AddDays(1) }'  " +
                   $"and danjutable.djlx='{DanjuLeiXing.白坯直销单}' or danjutable.djlx='{DanjuLeiXing.白坯销售单 }' or danjutable.djlx='{DanjuLeiXing.销售出库单 }' " +
                   $"and danjutable.dh=danjumingxitable.danhao ";
            gridControl1.DataSource = Connect.CreatConnect().Query(querystring);
        }

        private void 销售统计_Load(object sender, EventArgs e)
        {

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }
    }
}
