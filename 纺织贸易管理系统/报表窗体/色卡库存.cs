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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 色卡库存 : Form
    {
        public string StockName { get; set; } = "";
        public List <StockTable > pingzhong { get; set; }
        private List<JuanHaoTable> juanlist = new List<JuanHaoTable>();

        public 色卡库存()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name , gridView1);
            Query();
        }
   
        private void 品种选择_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            pingzhong  = StockTableService.GetStockTablelst (x => x.ContractNum .Contains(txthetonghao.Text) && x.PM .Contains(txtpingming.Text) && x.GG .Contains(txtguige.Text) && x.GH.Contains(txtganghao.Text) && x.kuanhao.Contains(txthuohao.Text)&& x.CKMC=="色卡仓库"
            &&x.ColorNum.Contains (txtsehao.Text )&&x.CustomName.Contains(txtkehu.Text )&&x.BH.Contains (txtBianhao.Text )&&x.orderNum.Contains (txtOrderNum .Text ));
            gridControl1.DataSource = pingzhong ;
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new StockTable () };
            fm.ShowDialog();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }



   
 
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 录入明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var fm = new 录入可发卷() { stock = pingzhong[gridView1.FocusedRowHandle] };
                fm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                fm.ShowDialog();
            }
            else
            {
                AlterDlg.Show("没有任何库存可录入");
            }
        }

    

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

    

  

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "发货通知单清单");
        }
    }
}
