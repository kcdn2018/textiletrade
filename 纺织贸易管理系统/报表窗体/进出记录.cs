using Model;
using SqlSugar;
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
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 进出记录 : Form
    {
        public 进出记录()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            Query();
        }

        private void 进出记录_Load(object sender, EventArgs e)
        {

        }
        private void Query()
        {
            UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            var querystring = $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ dateEdit1.DateTime}' and '{dateEdit2.DateTime.Date.AddDays(1)}' and danjutable.ckmc like '%{txtckmc.Text}%' " 
                    +$"and danjutable.dh=danjumingxitable.danhao";
            if (User.user.access == "自己")
            {
                querystring += $" and danjutable.own='{User.user.YHBH }'";
            }
            querystring += " order by danjutable.id desc";
            var dt = Connect.CreatConnect().Query(querystring);
            for(int row=0;row<dt.Rows.Count;row++)
            {
                if(dt.Rows [row]["djlx"].ToString ()==DanjuLeiXing.销售出库单)
                {
                    dt.Rows[row]["CustomName"] = dt.Rows[row]["ksmc"];
                    dt.Rows[row]["ksmc"] = string.Empty ;
                }
                if (dt.Rows[row]["djlx"].ToString() == DanjuLeiXing.销售退货单 )
                {
                    dt.Rows[row]["CustomName"] = dt.Rows[row]["ksmc"];
                    dt.Rows[row]["ksmc"] = string.Empty;
                }
            }
            gridControl1.DataSource = dt;
            UIWaitFormService.HideWaitForm();
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cmbcunfang.Text == "仓库")
            {
                var fm = new 仓库选择() { stock = new StockInfoTable() { mingcheng = cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
            }
            else
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC = txtckmc.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "进出记录");
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.Focus();
            SendKeys.Send("^c");
        }
    }
}
