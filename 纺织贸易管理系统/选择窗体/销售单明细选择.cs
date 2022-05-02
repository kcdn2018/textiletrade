using BLL;
using Model;
using SqlSugar;
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

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 销售单明细选择 : Sunny.UI.UIForm 
    {
        public decimal Rate { get; set; }
        private List<danjumingxitable> Mingxis = new List<danjumingxitable>();
        public 销售单明细选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            Query();
        }

        private void Query()
        {
            //gridControl1.DataSource = Connect.DbHelper().Ado.SqlQuery <danjumingxitable >("select * from danjumingxitable left join danjutable on danjutable.dh=danjumingxitable.danhao")
           Mingxis   = Connect.DbHelper().Queryable<danjumingxitable, DanjuTable>((mingxi, danju) => (new object[] { JoinType.Left, mingxi.danhao == danju.dh })).Where((mingxi, danju) => danju.djlx==DanjuLeiXing.销售出库单&&danju.Bizhong  =="美金"&&mingxi.Rate==0 ).Select <danjumingxitable >().ToList ();
            gridControl1.DataSource = Mingxis;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIWaitFormService.ShowWaitForm();
             List<danjumingxitable> SelectMingxi = new List<danjumingxitable>();
            foreach(var s in gridView1.GetSelectedRows ())
            {
                SelectMingxi.Add(Mingxis.FirstOrDefault(x => x.ID == (int)gridView1.GetRowCellValue(s, "ID")));
            }
            SelectMingxi.ForEach(x => x.Rate = Rate);
            Connect.DbHelper().Updateable<danjumingxitable>(SelectMingxi).ExecuteCommand ();
            foreach (var m in SelectMingxi )
            {
                var order = Connect.DbHelper().Queryable<OrderTable>().First(x => x.OrderNum == m.OrderNum);
                if(order!=null)
                {
                    order.FaHuoMoney += (m.hanshuiheji * Rate - m.hanshuiheji);
                    if(order.state =="已完成")
                    {
                        order.HejiLilun = order.FaHuoMoney - order.Deposit - order.Cost;
                    }
                    Connect.DbHelper().Updateable<OrderTable>(order).ExecuteCommand();
                }
            }
            Sunny.UI.UIWaitFormService.HideWaitForm ();
            this.Close();
            this.Dispose();
        }
    }
}
