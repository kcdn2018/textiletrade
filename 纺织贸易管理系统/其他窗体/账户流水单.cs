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

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 账户流水单 : Form
    {
        public string Shoukuanfangshi { get; set; }
        public 账户流水单()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
        }

        private void 账户流水单_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            var danjulist = Connect.CreatConnect().Query <DanjuTable >( $"select * from danjutable where shoukuanfangshi='{Shoukuanfangshi}' and rq between '{dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date }' order by rq asc, id asc");
            foreach (var danju in danjulist)
            {
                if(danju.djlx==DanjuLeiXing.收款单  )
                {
                    danju.totalmoney = danju.je;
                    danju.je = 0;
                    danju.yaoqiu = ShouzhiStyle.收入 ;
                    danju.bz = danju.ksmc + "打款收入";
                    danju.jiagongleixing = "销售收入";
                }
                else
                {
                    if(danju.djlx ==DanjuLeiXing.付款单 )
                    {
                        danju.yaoqiu = ShouzhiStyle.支出 ;
                        danju.bz = danju.ksmc + "打款支出";
                        danju.jiagongleixing = "经营支出";
                    }
                    else
                    {
                        if(danju.djlx==DanjuLeiXing.费用单 )
                        {

                        }
                    }
                }
            }
            gridControl1.DataSource = danjulist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable () };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "银行流水单");
        }
    }
}
