using BLL;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 收款单 : Form
    {
        public int Useful { get; set; } = 1;
        private LXR LinkMan = new LXR ();
        public DanjuTable danju { get; set; } = new DanjuTable() { djlx=DanjuLeiXing.收款单 };
        public 收款单()
        {
            InitializeComponent();         
        }

        private void 收款单_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX2.AutoGenerateColumns = false;
            dataGridViewX3.AutoGenerateColumns = false;
            if (Useful==FormUseful.新增 )
            {
                Init();
            }
            else
            {
                Edit();
            }
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtjine.Text = danju.je.ToString ();
            txtkehu.Text = danju.ksmc;
            txtyuanying.Text = danju.yaoqiu;
            txtzhanghu.Text = danju.ShoukuanFangshi;
            LinkMan.BH = danju.ksbh;
            dateEdit1.DateTime = danju.rq.Date ;
            txtyouhui.Text = danju.totalmoney.ToString();
            //txtyingshoujine.Text = danju.RemainMoney.ToString();
            dataGridViewX1.DataSource = ProcessTableService.GetProcessTablelst(x => x.receiptnum == danju.dh);
            var skmxlist = skmxService.Getskmxlst(x => x.dh == danju.dh);
            var dt= SQLHelper.SQLHelper.Chaxun($"select * from skmx,RemainMoneyTable where skmx.dh='{danju.dh }' and RemainMoneyTable.ReceiptNum=skmx.skyy and skmx.skfs='发货单'");
           for(int r=0;r<dt.Rows.Count;r++)
            {
                dt.Rows[r]["Shengyumoney"] = dt.Rows[r]["Danjujine"].TryToDecmial(0) - dt.Rows[r]["Shengyumoney"].TryToDecmial(0);
            }
            dataGridViewX2.DataSource = dt;
            var dt1= SQLHelper.SQLHelper.Chaxun($"select * from skmx,RemainMoneyTable where skmx.dh='{danju.dh }' and RemainMoneyTable.ReceiptNum=skmx.skyy and skmx.skfs='发票'");
            for (int r = 0; r < dt1.Rows.Count; r++)
            {
                dt1.Rows[r]["Shengyumoney"] = dt1.Rows[r]["Danjujine"].TryToDecmial(0) - dt1.Rows[r]["Shengyumoney"].TryToDecmial(0);
            }
            dataGridViewX3.DataSource = dt1;
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = "" ,ZJC="" } };
            fm.ShowDialog();
            LinkMan = fm.linkman;
            txtkehu.Text = LinkMan.MC;
            txtyingshoujine.Text = LinkMan.JE.ToString();
            dataGridViewX1.DataSource = OrderTableService.GetOrderTablelst(x => x.CustomerNum == fm.linkman.BH && x.ShengYuMoney > 0);
            dataGridViewX2.DataSource = RemainMoneyTableService.GetRemainMoneyTablelst(x => x.MachineType == DanjuLeiXing.打样工艺单 || x.MachineType == DanjuLeiXing.销售出库单 || x.MachineType == DanjuLeiXing.色卡销售单).Where(x => x.ShengYuMoney > 0&&x.SupplierName ==fm.linkman.MC ).ToList();
            dataGridViewX3.DataSource = RemainMoneyTableService.GetRemainMoneyTablelst(x => x.SupplierNum == fm.linkman.BH && x.MachineType == DanjuLeiXing.发票开具  && x.ShengYuMoney > 0);
        }

        private void txtzhanghu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 收款方式();
            fm.ShowDialog();
            txtzhanghu.Text = fm.skfs.Skfs ;
        }
        private List<ProcessTable  > CreateOrderList()
        {
            List<ProcessTable > processTables  = new List<ProcessTable >();
            for(int i=0;i<dataGridViewX1.Rows.Count;i++)
            {
                processTables.Add(new ProcessTable () { OrderNum = dataGridViewX1.Rows[i].Cells[COrderNum.Name ].Value .ToString (), TotalMoney = dataGridViewX1.Rows[i].Cells[CShoukuan .Name ].Value .TryToDecmial(2),receiptnum=txtdanhao.Text ,
               MachineType=DanjuLeiXing.收款单 , Currency="人民币", rq= dateEdit1.DateTime ,Documenttype=txtyuanying.Text });
            }
            return processTables;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danju.dh = txtdanhao.Text;
            danju.rq = dateEdit1.DateTime.Date ;
            danju.ksbh = LinkMan.BH;
            danju.ksmc = LinkMan.MC;
            danju.remarker = txtbeizhu.Text;
            danju.totalmoney = txtyouhui.Text.ToDecimal(0);
            danju.je =Convert.ToDecimal ( txtjine.Text);
            danju.yaoqiu = txtyuanying.Text;
            danju.ShoukuanFangshi = txtzhanghu.Text;
            danju.djlx = DanjuLeiXing.收款单;
            danju.Qiankuan = "欠款";
            danju.own = User.user.YHBH;
            if (Useful==FormUseful.新增 )
            {
                收款单BLL.保存(danju,CreateOrderList (),CreatSkmxList ());
            }
            else
            {
                收款单BLL.修改 (danju,CreateOrderList (), CreatSkmxList());
         
            }
            Thread.Sleep(1000);
            Init();
            Useful = FormUseful.新增;
        }
     
        private List<skmx> CreatSkmxList()
        {
            var mxlist = new List<skmx>();
            for (int r = 0; r < dataGridViewX2.Rows.Count; r++)
            {
                var row = dataGridViewX2.Rows[r];
                mxlist.Add(new skmx
                {
                    dh = txtdanhao.Text,
                    skyy = row.Cells[cfahuodanhao.Name].Value.ToString(),
                    je = row.Cells[cfahuoshoukuan.Name].Value.TryToDecmial(0),
                    skfs = "发货单"
                });
            }
            for (int r = 0; r < dataGridViewX3.Rows.Count; r++)
            {
                var row = dataGridViewX3.Rows[r];
                mxlist.Add(new skmx
                {
                    dh = txtdanhao.Text,
                    skyy = row.Cells[cfapiaodanhao.Name].Value.ToString(),
                    je = row.Cells[cfapiaoshoukuanjine.Name].Value.TryToDecmial(0),
                    skfs = "发票"
                });
            }
            return mxlist;
        }
 
        private void Init()
        {
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.收款单 ,dateEdit1.DateTime, DanjuLeiXing.收款单 );
            txtjine.Text = "0";
            txtyuanying.Text = "";
            txtkehu.Text = "";
            txtbeizhu.Text = "";          
            txtzhanghu.Text = "";
            txtyouhui.Text = "0.00";
            txtyingshoujine.Text = "0.00";
            dataGridViewX1.DataSource = new List<ProcessTable>();
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                LinkMan = fm.linkman;
                txtkehu.Text = LinkMan.MC;
                txtyingshoujine.Text = LinkMan.JE.ToString ();
                dataGridViewX1.DataSource = OrderTableService.GetOrderTablelst(x => x.CustomerNum == fm.linkman.BH && x.ShengYuMoney > 0);
                dataGridViewX2.DataSource = RemainMoneyTableService.GetRemainMoneyTablelst(x => x.SupplierNum == fm.linkman.BH  && x.MachineType == DanjuLeiXing.打样工艺单 || x.MachineType == DanjuLeiXing.销售出库单 || x.MachineType == DanjuLeiXing.色卡销售单 ).Where (x=>x.ShengYuMoney >0).ToList ();
                dataGridViewX3.DataSource = RemainMoneyTableService.GetRemainMoneyTablelst(x => x.SupplierNum == fm.linkman.BH && x.MachineType == DanjuLeiXing.发票开具 && x.ShengYuMoney > 0);
            }
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.收款单 , dateEdit1.DateTime, DanjuLeiXing.收款单);
            }
        }

        private void txtjine_ValueChanged(object sender, EventArgs e)
        {
            var jine = txtjine.Text.ToDecimal (2)+txtyouhui.Text.ToDecimal(0);
            for(int r=0;r<dataGridViewX1.Rows.Count;r++)
            {
                if (dataGridViewX1.Rows[r].Cells[Cshengyujine.Name].Value != null)
                {
                    dataGridViewX1.Rows[r].Cells[CShoukuan.Name].Value = jine >= dataGridViewX1.Rows[r].Cells[Cshengyujine.Name].Value.TryToDecmial(0) ?dataGridViewX1.Rows[r].Cells[Cshengyujine.Name].Value.TryToDecmial(0) : jine;
                    jine -= dataGridViewX1.Rows[r].Cells[Cshengyujine.Name].Value.TryToDecmial(0);
                    if (jine <= 0)
                    {
                        break ;
                    }
                }
            }
            dataGridViewX1.RefreshEdit();
            jine = txtjine.Text.ToDecimal(0) + txtyouhui.Text.ToDecimal(0);
            for (int r = 0; r < dataGridViewX2.Rows.Count; r++)
            {
                if (dataGridViewX2.Rows[r].Cells[Cfahuoshengyu.Name].Value != null)
                {
                    dataGridViewX2.Rows[r].Cells[cfahuoshoukuan.Name].Value = jine >= dataGridViewX2.Rows[r].Cells[Cfahuoshengyu.Name].Value.TryToDecmial(0) ? dataGridViewX2.Rows[r].Cells[Cfahuoshengyu.Name].Value.TryToDecmial(0) : jine;
                    jine -= dataGridViewX2.Rows[r].Cells[Cfahuoshengyu.Name].Value.TryToDecmial(0);
                    if (jine <= 0)
                    {
                        break ;
                    }
                }
            }
            dataGridViewX2.RefreshEdit();
             jine = txtjine.Text.ToDecimal(0) + txtyouhui.Text.ToDecimal(0);
            for (int r = 0; r < dataGridViewX3.Rows.Count; r++)
            {
                if (dataGridViewX3.Rows[r].Cells[cfapiaoshengyujine .Name].Value != null)
                {
                    dataGridViewX3.Rows[r].Cells[cfapiaoshoukuanjine.Name].Value = jine >= dataGridViewX3.Rows[r].Cells[cfapiaoshengyujine.Name].Value.TryToDecmial(0) ? dataGridViewX3.Rows[r].Cells[cfapiaoshengyujine.Name].Value.TryToDecmial(0) : jine;
                    jine -= dataGridViewX3.Rows[r].Cells[cfapiaoshengyujine.Name].Value.TryToDecmial(0);
                    if (jine <= 0)
                    {
                        break ;
                    }
                }
            }
            dataGridViewX3.RefreshEdit();
        }
    }
}
