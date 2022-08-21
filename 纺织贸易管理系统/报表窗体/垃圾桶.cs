using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 垃圾桶 : Form
    {
        private List<RukuTable> rukuTables = new List<RukuTable>();
        public 垃圾桶()
        {
            InitializeComponent();
            var conMenu = new ContexMenuEX() { formName = this.Name, dataGridView  = uiDataGridView1 , menuStrip = contextMenuStrip1,obj=new RukuTable () };
            conMenu.Init();
            CreateGrid.CreateDatagridview(this.Name, uiDataGridView1);
            this.CXuanzhe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            uiDataGridView1.Columns.Add(CXuanzhe);
            刷新数据();
        }

        private void 清空垃圾桶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RukuTableService.DeleteRukuTable("delete from RukuTable");
            刷新数据();
        }

        private void 删除垃圾ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RukuTableService.DeleteRukuTable(x=>x.ID==(int)uiDataGridView1.CurrentRow.Cells["ID"].Value );
            刷新数据();
        }
        private void 刷新数据()
        {            
            rukuTables = RukuTableService.GetRukuTablelst(x=>x.GH.Contains (txtganghao.Text )&&x.BH .Contains (txtCustomer.Text )&&x.PM.Contains (txtpingming.Text )).OrderByDescending(x=>x.ID).ToList ();
            uiDataGridView1.DataSource = rukuTables;
          
            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["BH"] = "合计";
            uiDataGridViewFooter1["MS"] = rukuTables.Sum(x => x.MS).ToString();
            uiDataGridViewFooter1["JS"] = rukuTables.Sum(x => x.JS).ToString();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            刷新数据();
        }

        private void txtganghao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                刷新数据();
            }    
        }

        private void 还原库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiDataGridView1.EndEdit();
            var selectstock = new List<RukuTable>();
            for(int row=0;row<uiDataGridView1.Rows.Count;row++)
            {
                if(uiDataGridView1.Rows[row].Cells [CXuanzhe.Name ].Value!=null )
                {
                    if(Convert.ToBoolean (uiDataGridView1.Rows[row].Cells[CXuanzhe.Name].Value))
                    {
                        selectstock.Add(rukuTables[row]);
                    }
                }
            }
            try
            {
                BackToStock(selectstock);
                MessageBox.Show("还原成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("还原失败" + ex.Message);
            }
            刷新数据();
        }
        private void BackToStock(List<RukuTable > rukus )
        {
            foreach(var r in rukus )
            {
                var stock = new StockTable()
                {
                    AvgPrice = 0,
                    BH = r.BH,
                    biaoqianmishu = 0,
                    CF = r.CF,
                    CKMC = r.CKMC,
                    ColorNum = string.Empty,
                    ContractNum = string.Empty,
                    CustomerColorNum = string.Empty,
                    CustomerPingMing = string.Empty,
                    CustomName = string.Empty,
                    FrabicWidth = string.Empty,
                    GG = r.GG,
                    GH = r.GH,
                    houzhengli = r.Houzhengli,
                    Huahao = string.Empty,
                    IsCheckDone = string.Empty,
                    JS = r.JS,
                    kaijianmishu = 0,
                    kuanhao = r.Kuanhao,
                    Kuwei = string.Empty,
                    LiuzhuanCard = string.Empty,
                    KZ = r.KZ,
                    MF = r.MF,
                    MS = r.MS,
                    orderNum = r.orderNum,
                    own = r.own,
                    PibuChang = string.Empty,
                    Pihao = string.Empty,
                    PM = r.PM,
                    Rangchang = string.Empty,
                    Remarkers = string.Empty,
                    RKDH = r.RKDH,
                    RQ = r.RQ,
                    RukuNum = 0,
                    TotalMoney = 0,
                    YiFaNum = 0,
                    yijianjuanshu = 0,
                    yijianmishu = 0,
                    YS = r.YS
                };
                stock = SQLHelper.MapperHelper.Mapper(r, stock);
                StockTableService.InsertStockTable(stock);
                RukuTableService.DeleteRukuTable(x => x.ID == r.ID);
            }
        }
    }
}
