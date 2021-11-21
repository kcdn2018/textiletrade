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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 发货清单 : Form
    {
        public string CustomerName { get; set; }
        public 发货清单()
        {            
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView2);

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl2, "销售发货单清单");
        }
        private void Query()
        {
            //gridControl2.DataSource=danjumingxitableService.Getdanjumingxitablelst (x=>x.CustomName .Contains (txtksmc.Text)&&x.rq >=dateEdit1.DateTime &&x.rq<=dateEdit2.DateTime );
            gridControl2.DataSource = danjumingxitableService.Getdanjumingxitablelst($"select danjumingxitable.* from danjumingxitable,danjutable where  danjutable.ksmc like '%{txtksmc.Text}%' and danjutable.rq between '{dateEdit1.DateTime}' and '{ dateEdit2.DateTime}' and danjutable.djlx='{DanjuLeiXing.销售出库单}' and danjutable.dh=danjumingxitable.danhao");
        }

        private void 发货清单_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = txtksmc.Text } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
          
        }
    }
}
