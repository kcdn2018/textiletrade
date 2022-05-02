using BLL;
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
using Tools;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 订单转换 :Sunny.UI.UIForm  
    {
        public StockTable  OldOrder { get; set; }
        private List<JuanHaoTable> juanHao{ get; set; }
        public 订单转换()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView2);
        }

        private void textBoxX1_ButtonCustom2Click(object sender, EventArgs e)
        {
            var fm = new 订单明细选择() { OrderNum=string.Empty };
            fm.ShowDialog();
            if (fm.pingzhong.Count > 0)
            {
                var orderdetail = fm.pingzhong[0] ;
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == orderdetail.OrderNum);
                txtNewCustomName.Text = order.CustomerName  ;
                txtNewHetonghao.Text = order.ContractNum;
                txtnewOrder.Text = order.OrderNum;
                txtnewbianhao .Text = orderdetail.sampleNum ;
                txtnewpingming.Text = orderdetail.sampleName;
                txtnewsehao.Text = orderdetail.ColorNum;
                txtnewyanse.Text = orderdetail.color;
                txtnewyingwenming.Text = orderdetail.EnglishName;
                txtnewmenfu.Text = orderdetail.width;
                txtnewkuanhao.Text = orderdetail.Kuanhao;
                txtnewkezhong.Text = orderdetail.weight;
                txtnewkehusehao.Text = orderdetail.CustomerColorNum;
                txtnewkehupingming.Text = orderdetail.CustomerPingMing;
                txtnewhuahao.Text = orderdetail.Huahao;
                txtnewguige.Text = orderdetail.Specifications;
                txtnewchengfen.Text = orderdetail.Component;
                
            }
        }

        private void 订单转换_Load(object sender, EventArgs e)
        {
            txtkehu .Text = OldOrder.CustomName ;
            txthetonghao.Text = OldOrder.ContractNum;
            txtordernum .Text = OldOrder.orderNum ;
            txtkucunmingshu .Text = OldOrder.MS.ToString();
            txtkucunjuanshu .Text = OldOrder.JS.ToString();
            txtkehusehao.Text = OldOrder.CustomerColorNum;
            txthuahao.Text = OldOrder.Huahao;
            txtganghao.Text = OldOrder.GH;
            txtbianhao.Text = OldOrder.BH;
            txtcangku.Text = OldOrder.CKMC;
            txtchengfeng.Text = OldOrder.CF;
            txtguige.Text = OldOrder.GG;
            txthetonghao.Text = OldOrder.ContractNum;
            txthuahao.Text = OldOrder.Huahao;
            txtkehupingming.Text = OldOrder.CustomerPingMing;
            txtkehusehao.Text = OldOrder.CustomerColorNum;
            txtkezhong.Text = OldOrder.KZ;
            txtkuanhao.Text = OldOrder.kuanhao;
            txtmenfu.Text = OldOrder.MF;
            txtsehao.Text = OldOrder.ColorNum;
            txtyanse.Text = OldOrder.YS;
            txtpingming.Text = OldOrder.PM;
            txtYingwenming.Text = dbService.GetOnedb(x => x.bh == OldOrder .BH).EnglishName;
            ////赋值新的信息       
            txtnewganghao.Text = OldOrder.GH;
            txtnewpingming .Text = OldOrder.PM;
            txtnewbianhao.Text = OldOrder.BH;
            txtnewchangkumingcheng .Text = OldOrder.CKMC;
            txtnewchengfen .Text = OldOrder.CF;
            txtnewguige .Text = OldOrder.GG;
            txtnewkezhong .Text = OldOrder.KZ;
            txtkuanhao.Text = OldOrder.kuanhao;
            txtnewmenfu .Text = OldOrder.MF;
            txtnewsehao .Text = OldOrder.ColorNum;
            txtnewyanse .Text = OldOrder.YS;
            txthouzhengli.Text = OldOrder.houzhengli;
            txtnewyingwenming .Text =txtYingwenming.Text ;
            txtdanjia.Text = OldOrder.AvgPrice.ToString();
            加载卷();
        }

        private void 全部转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtnewMishu.Text =OldOrder.MS .ToString ();
            txtnewjuanshu.Text = OldOrder.JS.ToString ();
        }

        private void txtnewMishu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtkucunmingshu .Text = (OldOrder.MS - txtnewMishu.Text.TryToDecmial (0)).ToString();
                txthejijine.Text =( txtnewMishu.Text.TryToDecmial(0) * txtdanjia.Text.TryToDecmial(0)).ToString ();
            }
            catch { }
        }

        private void txtnewjuanshu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtkucunjuanshu.Text = (OldOrder.JS - Convert.ToDecimal(txtnewjuanshu .Text)).ToString();
            }
            catch { }
        }
        private void 加载卷()
        {
            try
            {
                var d = OldOrder;
                juanHao = (JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.orderNum && x.yanse == d.YS && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
                   && x.GangHao == d.GH && x.SampleNum == d.BH && x.state == 0 && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum&&x.Ckmc==d.CKMC ));
                gridControl2.DataSource = juanHao;
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "加载卷的时候发生错误" + ex.Message);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void 确定保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.CloseEditor();
                OldOrder.MS-= txtkucunmingshu.Text.TryToDecmial (0);
                OldOrder.JS-=txtkucunjuanshu.Text.TryToDecmial (0);
                var newstock = new StockTable()
                {
                    MS = txtnewMishu.Text.TryToDecmial(0),
                    orderNum = txtnewOrder.Text,
                    CustomName = txtNewCustomName.Text,
                    ContractNum = txtNewHetonghao.Text,
                    CustomerColorNum = txtnewkehusehao.Text,
                    CustomerPingMing = txtnewkehupingming.Text,
                    kuanhao = txtnewkuanhao.Text,
                    Huahao = txtnewhuahao.Text,
                    BH = txtnewbianhao.Text,
                    PM = txtnewpingming.Text,
                    GG = txtnewguige.Text,
                    KZ = txtnewkezhong.Text,
                    MF = txtnewmenfu.Text,
                    CF = txtnewchengfen.Text,
                    ColorNum = txtnewsehao.Text,
                    JS = Convert.ToDecimal(txtnewjuanshu.Text),
                    GH = txtnewganghao.Text,
                    YS = txtnewyanse.Text,
                    AvgPrice =txtdanjia.Text.TryToDecmial (),
                    biaoqianmishu = txtnewMishu.Text.TryToDecmial(0),
                    CKMC = OldOrder.CKMC,
                    houzhengli = txthouzhengli.Text,
                    IsCheckDone = "已完成",
                    kaijianmishu = 0,
                    Rangchang = OldOrder.Rangchang,
                    yijianmishu = txtnewMishu.Text.TryToDecmial(0),
                    RKDH = OldOrder.RKDH,
                    RQ = OldOrder.RQ,
                    Kuwei = OldOrder.Kuwei,
                    RukuNum = txtnewMishu.Text.TryToDecmial(0),
                    own = OldOrder.own,
                    TotalMoney = txtnewMishu.Text.TryToDecmial(0) * txtdanjia.Text.ToDecimal(0),
                    LiuzhuanCard = OldOrder.LiuzhuanCard,
                    YiFaNum = OldOrder.YiFaNum,
                    yijianjuanshu = txtnewjuanshu.Text.ToDecimal(0)
                };
                decimal yijianmishu = 0, yijianjuanshu = 0, biaoqianmishu = 0;
                foreach (var i in gridView2.GetSelectedRows())
                {
                    var j = juanHao.Where(x => x.JuanHao == gridView2.GetRowCellValue(i, "JuanHao").ToString()).ToList();
                    if (j.Count > 0)
                    {
                        j[0].OrderNum = txtnewOrder.Text;
                        j[0].CustomerName = txtNewCustomName.Text;
                        j[0].CustomerPingMing = txtnewkehupingming .Text;
                        j[0].CustomerColorNum = txtnewkehusehao .Text;
                        j[0].kuanhao = txtnewkuanhao .Text;
                        j[0].Huahao = txtnewhuahao .Text;
                        j[0].GangHao = txtnewganghao.Text;
                        j[0].yanse = txtnewyanse.Text;
                        j[0].Houzhengli  = txthouzhengli .Text;
                        j[0].SampleNum  = txtnewbianhao .Text;
                        j[0].SampleName  = txtnewpingming .Text;
                        j[0].guige  = txtnewguige .Text;
                        j[0].Kezhong  = txtnewkezhong .Text;
                        j[0].Menfu  = txtnewmenfu .Text;
                        j[0].ColorNum = txtnewsehao.Text;
                        biaoqianmishu = j[0].biaoqianmishu;
                        yijianmishu = j[0].MiShu;
                        yijianjuanshu += 1;
                        JuanHaoTableService.UpdateJuanHaoTable(j[0], x => x.JuanHao == j[0].JuanHao);
                    }
                }
                newstock.yijianjuanshu = yijianjuanshu;
                newstock.yijianmishu = yijianmishu;
                newstock.biaoqianmishu = biaoqianmishu;
                BLL.库存BLL.增加库存(newstock);
                OldOrder.yijianmishu -= yijianmishu;
                OldOrder.yijianjuanshu -= yijianjuanshu;
                OldOrder.biaoqianmishu -= biaoqianmishu;
                BLL.库存BLL.减少库存(OldOrder );
                var danjumingxis = new List<danjumingxitable>();
                danjumingxis.Add(new danjumingxitable()
                {
                    pingming = txtpingming.Text,
                    guige = txtguige.Text,
                    chengfeng = txtchengfeng.Text,
                    kezhong = txtkezhong.Text,
                    Bianhao = txtbianhao.Text,
                    menfu = txtmenfu.Text,
                    ColorNum = txtsehao.Text,
                    ContractNum = txtNewHetonghao.Text,
                    CustomName = txtNewCustomName.Text,
                    CustomerPingMing = txtnewkehupingming.Text,
                    chengpingjuanshu = txtnewjuanshu.Text.ToDecimal(),
                    chengpingmishu = txtnewMishu.Text.ToDecimal(),
                    CustomerColorNum = txtnewkehusehao.Text,
                    Chengpingyanse = txtnewyanse.Text,
                    ganghao = txtganghao.Text,
                    hanshuidanjia = txtdanjia.Text.ToDecimal(),
                    hanshuiheji = txthejijine.Text.ToDecimal(),
                    houzhengli = OldOrder.houzhengli,
                    kuanhao = txtnewkuanhao.Text,
                    Huahao = txtnewhuahao.Text,
                    OrderNum = txtnewOrder.Text,
                    rq = DateTime.Now,
                     yanse =txtyanse.Text ,
                     bizhong="人民币",              
                     danwei ="米" ,
                }) ;
                var danju = new DanjuTable() {
                    je = txthejijine.Text.ToDecimal(),
                    djlx = "订单转入",
                    rq=DateTime.Now ,
                    ksmc =OldOrder.own,
                };
                订单BLL.增加费用(danjumingxis, danju);
                订单进度BLL.新增进度(danjumingxis, danju);
                danjumingxis[0].OrderNum = OldOrder.orderNum;
                订单BLL.增加发货金额(danjumingxis);
                订单BLL.计算利润(OldOrder.orderNum);
                danjumingxis[0].OrderNum = txtordernum.Text;
                danjumingxis[0].ContractNum = txthetonghao .Text;
                danjumingxis[0].CustomName = txtkehu .Text;
                danjumingxis[0].CustomerPingMing = txtkehupingming .Text;
                danjumingxis[0].CustomerColorNum  = txtkehusehao .Text;
                danju.djlx = "订单转出";
                订单进度BLL.新增进度(danjumingxis, danju);
                this.Close();
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog (this, "保存的时候发生错误"+ex.Message );
            }
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                decimal yijianmishu = 0, yijianjuanshu = 0, biaoqianmishu = 0;
                foreach (var i in gridView2.GetSelectedRows())
                {
                    var j = juanHao.Where(x => x.JuanHao == gridView2.GetRowCellValue(i, "JuanHao").ToString()).ToList();
                    if (j.Count > 0)
                    {
                        biaoqianmishu += j[0].biaoqianmishu;
                        yijianmishu += j[0].MiShu;
                        yijianjuanshu += 1;
                    }
                }
                txtnewMishu.Text = biaoqianmishu.ToString();
                txtnewjuanshu.Text = yijianjuanshu.ToString();
                ///计算合计金额
                if (txtdanjia.Text.IsDecimal() && txtnewMishu.Text.IsDecimal())
                {
                    txthejijine.Text = (txtdanjia.Text.TryToDecmial() * (txtnewMishu.Text.TryToDecmial())).ToString();
                }
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "计算的时候发生错误！错误原因" + ex.Message);
            }
        }

        private void txtdanjia_TextChanged(object sender, EventArgs e)
        {
            if(txtdanjia.Text.IsDecimal()&&txtnewMishu.Text .IsDecimal())
            {
                txthejijine.Text =( txtdanjia.Text.TryToDecmial()*(txtnewMishu.Text.TryToDecmial())).ToString ();
            }
        }
    }
}
