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
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 委外取货单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();       
        public DanjuTable danju = new DanjuTable();
        private List<RangShequpiTable > ToupiList = new List<RangShequpiTable>();
        private int rowindex;

        public 委外取货单()
        {
            InitializeComponent();           
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Create(this.Name , gridView2);
            gridView1.Columns["SampleNum"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit1;
            //gridView1.Columns["Remarkers"].ColumnEdit = cmddanwei;
            gridView2.Columns["Bianhao"].ColumnEdit = ChengpingButtonEdit1 ;
            gridView2.Columns["OrderNum"].ColumnEdit = ChengpingButtonEdit2 ;
            gridView2.Columns["danwei"].ColumnEdit = cmddanwei;
            gridView2.Columns["yanse"].ColumnEdit = colorbtn ;
            gridControl1.DataSource = ToupiList;
            gridControl2.DataSource = danjumingxitables;
            cmbgongyi.DataSource = 委外取货单BLL.获取加工类型();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new RangShequpiTable  () };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 供货商选择() { linkman=new LXR() { ZJC="",MC="" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
        }

        private void txtwuliu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择();
            fm.ShowDialog();
            danju.wuliuBianhao  = fm.linkman.Bianhao  ;
            txtwuliu.Text = fm.linkman.name ;
            var wuliu = fm.linkman;
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;            
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(cmbcunfang.Text=="仓库")
            {
                var fm = new 仓库选择() { stock = new StockInfoTable() { mingcheng = cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
                CreateGrid.CreateKuweiCmb(gridView2, txtckmc.Text);
            }
            else
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC ="",ZJC="" } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                CreateGrid.ClearKuwei(gridView2);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(txtkehu.Text =="")
            {
                MessageBox.Show("请先选择加工厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var fm = new 库存选择() { StockName=txtkehu .Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
           foreach (var pingzhong in fm.pingzhong )
            {
                ToupiList[i].OrderNum = pingzhong.orderNum;
                ToupiList[i].CustomName  = pingzhong.CustomName ;
                ToupiList[i].ContractNum  = pingzhong.ContractNum ;
                ToupiList[i].SampleNum = pingzhong.BH ;
                ToupiList[i].sampleName = pingzhong.PM ;
                ToupiList[i].Specifications  = pingzhong.GG;
                ToupiList[i].chengfeng = pingzhong.CF;
                ToupiList[i].kezhong  = pingzhong.KZ ;
                ToupiList[i].menfu  = pingzhong.MF ;
                ToupiList[i].color  = pingzhong.YS ;
                ToupiList[i].kuanhao  = pingzhong.kuanhao ;
                ToupiList[i].ganghao = pingzhong.GH;
                ToupiList[i].ToupiMishu  = pingzhong.MS ;
                ToupiList[i].ToupiJuanshu = pingzhong.JS;
                ToupiList[i].houzhengli = pingzhong.houzhengli;
                ToupiList[i].Remarkers = pingzhong.Kuwei ;
                ToupiList[i].SampleRemarks = "";
                ToupiList[i].Danjia  = pingzhong.AvgPrice ;
                ToupiList[i].Heji  = pingzhong.AvgPrice*pingzhong.MS ;
                ToupiList[i].ColorNum = pingzhong.ColorNum;
                ToupiList[i].CustomerColorNum = pingzhong.CustomerColorNum;
                ToupiList[i].CustomerPingMing = pingzhong.CustomerPingMing;
                ToupiList[i].Huahao = pingzhong.Huahao;
                ToupiList[i].AveragePrice = pingzhong.AvgPrice;
                ToupiList[i].FactoryName = pingzhong.Rangchang;
                ToupiList[i].Pihao = pingzhong.Pihao;
                ToupiList[i].PibuChang = pingzhong.PibuChang;
                ToupiList[i].FrabicWidth = pingzhong.FrabicWidth ;
                i++;
            }
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OrderDetailSelect.SelectDetail(gridView1, danjumingxitables, true);
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }
        private void 删除行ToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView2.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable >(danjumingxitables  , rowindex, gridView2, gridView2.FocusedRowHandle,this);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ToupiList[gridView1.FocusedRowHandle].Heji = ToupiList[gridView1.FocusedRowHandle].Danjia  * ToupiList[gridView1.FocusedRowHandle].ToupiMishu ;
                //ToupiList [gridView1.FocusedRowHandle].Heji  = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                gridControl1.RefreshDataSource();
                计算缩率();
            }
            catch 
            {
                MessageBox.Show("请输入数字。计算错误","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private   void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            gridView2.CloseEditor();
            if (danjumingxitables.Sum(x => x.chengpingmishu) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return;
            }
            if (txtsuolv.Text.TryToInt (0) > QueryTime.Suolv )
            {
                if (Sunny.UI.UIMessageBox.ShowAsk($"该订单的缩率超过了预警缩率{QueryTime.Suolv }值,\r\n是否继续保存该单据？") == false)
                { return; }
            }
            if (txtckmc.Text=="")
            {
                MessageBox.Show("收货地址没有选择！请填写地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace ( x.Bianhao)).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text ;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = txtckmc .Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.委外取货单;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;            
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = txtyunfei.Text.TryToDecmial ();
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.jiagongleixing = cmbgongyi.Text;
            danju.yaoqiu = txtyaoqiu.Text;
            danju.own = User.user.YHBH;
            danju.LiuzhuanCard = txtLiuzhuanka.Text;
            danju.suolv = txtsuolv.Text.TryToInt();
            danju.ChaCheFei = txtChachefei.Text.TryToDecmial(0);
            danju.ZhuangXieFei = txtzhuangxiefei.Text.TryToDecmial(0);
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji)+danjumingxitables.Sum(x=>x.weishuiheji  );
            var juan = new List<RangShequpiTable>();
            juan = ToupiList.Where(x => x.SampleNum != null).ToList();
            ////检查库存。没有不能发货
            if (useful == FormUseful.新增)
            {
                var d = 库存BLL.检查库存(juan, danju);
                if (d.SampleNum != null)
                {
                    var mes = $"该发货单中\n 布料编号:{d.SampleNum }\n 订单号:{d.OrderNum } \n 色号:{d.ColorNum } \n 缸号:{d.ganghao } \n 颜色:{d.color  }在该仓库中没有！保存失败";
                    MessageBox.Show(mes, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (var m in danjumingxitables.Where (x=>!string.IsNullOrWhiteSpace (x.Bianhao)).ToList ())
            {
                var t = ToupiList.Where (x => x.SampleNum == m.Bianhao).ToList ();
                if(t.Count >0)
                {
                    var t1 = ToupiList.Where(x => x.SampleNum == m.Bianhao && x.ganghao == m.ganghao).ToList ();
                    if (t1.Count>0)
                    {
                        var h = m.houzhengli.Split('+');
                        string houzheng = string.Empty;
                        if (h.Length > 0)
                        {
                            for (int i = 0; i < h.Length - 1; i++)
                            {
                                houzheng += h[i] + "+";
                            }
                            if (houzheng.Length > 0)
                            {
                                houzheng = houzheng.Substring(0, houzheng.Length - 1);
                            }
                        }
                        var t2 = ToupiList.Where(x => x.SampleNum == m.Bianhao && x.ganghao == m.ganghao && x.houzhengli == houzheng).ToList ();
                        if (t2 .Count >0)
                        {
                            var pibu = ToupiList.FirstOrDefault(x => x.SampleNum == m.Bianhao && x.ganghao == m.ganghao && x.houzhengli == houzheng);
                            m.AveragePrice =pibu .Danjia+m.hanshuidanjia +(pibu.ToupiMishu -m.chengpingmishu)*pibu.Danjia /m.chengpingmishu  ;
                        }
                        else
                        {
                            var pibu = ToupiList.FirstOrDefault(x => x.SampleNum == m.Bianhao && x.ganghao == m.ganghao);
                            m.AveragePrice = pibu.Danjia + m.hanshuidanjia + (pibu.ToupiMishu - m.chengpingmishu) * pibu.Danjia / m.chengpingmishu;
                        }
                    }
                    else
                    {
                        var pibu = ToupiList.FirstOrDefault(x => x.SampleNum == m.Bianhao);
                        m.AveragePrice =pibu.Danjia +m.hanshuidanjia  +(ToupiList.Sum (x=>x.ToupiMishu )-danjumingxitables.Sum (x=>x.chengpingmishu ))*pibu.Danjia/ danjumingxitables.Sum(x => x.chengpingmishu);
                    }
                }
                else
                {
                    var pibu = ToupiList[0];
                    m.AveragePrice = pibu.Danjia + m.chengpingmishu + (ToupiList.Sum(x => x.ToupiMishu) - danjumingxitables.Sum(x => x.chengpingmishu)) * pibu.Danjia / danjumingxitables.Sum(x => x.chengpingmishu);
                }
                
            }
            ///////
            if (useful == FormUseful.新增)
            {
                委外取货单BLL.保存单据(danju, danjumingxitables,juan );
            }
            else
            {
                委外取货单BLL.修改单据(danju, danjumingxitables, juan);
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        委外取货单BLL .单据审核(danju.dh);
                    }
                }
            }           
            AlterDlg.Show("保存成功！");
            //清空所有控件
            Init();
        }
        private void Init()
        { 
            foreach (Control  c in this.groupControl1.Controls  )
            {
                if(c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    c.Text = "";
                }
                if(c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }

            dateEdit1.DateTime = DateTime.Now ;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.委外取货单 , dateEdit1.DateTime, DanjuLeiXing.委外取货单);
            danju.dh = txtdanhao.Text;
            txtChachefei.Text = "0";
            txtyunfei.Text = "0";
            txtzhuangxiefei.Text = "0";
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            ToupiList.Clear();
            for(int i=0;i<30-length;i++)
            {
                ToupiList.Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
            }
            gridControl1.RefreshDataSource();
            gridControl2.DataSource = danjumingxitables;
            useful = FormUseful.新增;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void 委外取货单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
               
                Init();
            }
            else
            {
                Edit();
                if(useful==FormUseful.查看 )
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
            
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;        
            cmbcunfang.Text = danju.StockName ;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
            cmbgongyi.Text = danju.jiagongleixing;
            txtyaoqiu.Text = danju.yaoqiu;
            txtzhuangxiefei.Text = danju.ZhuangXieFei.ToString();
            txtChachefei.Text = danju.ChaCheFei.ToString();
            dateEdit1.DateTime =danju.rq;
            txtckmc.Text = danju.ckmc;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            ToupiList = RangShequpiTableService.GetRangShequpiTablelst(x => x.DocumentNum == txtdanhao.Text);
            for (int i = 0; i < 30 - length; i++)
            {
                ToupiList.Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
            }
            gridControl1.DataSource = ToupiList;

            gridControl2.DataSource = danjumingxitables;
        }

        private void ChengpingButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(cmbgongyi.Text=="")
            {
                MessageBox.Show("请先填写工艺名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var row = gridView2.FocusedRowHandle;
            if (danjumingxitables[row].OrderNum ==null)
            {
                var fm = new 品种选择();
                fm.ShowDialog();
                var i = gridView2.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.bh;
                    danjumingxitables[i].guige = pingzhong.gg;
                    danjumingxitables[i].chengfeng = pingzhong.cf;
                    danjumingxitables[i].pingming = pingzhong.pm;
                    danjumingxitables[i].kezhong = pingzhong.kz;
                    danjumingxitables[i].menfu = pingzhong.mf;
                    danjumingxitables[i].FrabicWidth = pingzhong.mf;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].PibuName = pingzhong.PibuName;
                    danjumingxitables[i].EnglishName = pingzhong.EnglishName;
                    var mx = ToupiList.Where(x => x.SampleNum == pingzhong.bh  && x.OrderNum == x.OrderNum && x.color == x.color).ToList();
                    if (mx.Count > 0)
                    {
                        danjumingxitables[i].FrabicWidth = mx[0].FrabicWidth;
                        if (mx[0].houzhengli != "")
                        {
                            danjumingxitables[i].houzhengli = mx[0].houzhengli + "+" + cmbgongyi.Text;
                        }
                        else
                        {
                            danjumingxitables[i].houzhengli = cmbgongyi.Text;
                        }
                        danjumingxitables[i].ganghao = mx[0].ganghao;
                    }
                    else
                    {
                        danjumingxitables[i].houzhengli =  cmbgongyi.Text;
                    }
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                        }
                }
                fm.Dispose();
                gridControl2.RefreshDataSource();
                gridView2.CloseEditor();
            }
            else
            {
                var fm = new 订单明细选择() { OrderNum=danjumingxitables[row].OrderNum };
                fm.ShowDialog();
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == danjumingxitables[row].OrderNum);
                var i = gridView2.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.sampleNum ;
                    danjumingxitables[i].guige = pingzhong.Specifications;
                    danjumingxitables[i].chengfeng = pingzhong.Component;
                    danjumingxitables[i].pingming = pingzhong.sampleName ;
                    danjumingxitables[i].kezhong = pingzhong.weight;
                    danjumingxitables[i].menfu = pingzhong.width;
                    danjumingxitables[i].FrabicWidth = pingzhong.width;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].OrderNum  =pingzhong.OrderNum ;
                    danjumingxitables[i].kuanhao  =pingzhong.Kuanhao ;
                    danjumingxitables[i].yanse  = pingzhong.color ;
                    danjumingxitables[i].chengpingmishu  = pingzhong.Num -pingzhong.consignmentNum ;
                    danjumingxitables[i].ContractNum = order.ContractNum;
                    danjumingxitables[i].CustomName=order.CustomerName ;
                    danjumingxitables[i].Huahao = pingzhong.Huahao;
                    danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                    danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    var mx= ToupiList.Where (x=>x.SampleNum==pingzhong.sampleNum &&x.OrderNum==pingzhong.OrderNum &&x.color==pingzhong.color ).ToList ();
                    if(mx.Count >0)
                    {
                        danjumingxitables[i].FrabicWidth = mx[0].FrabicWidth;
                        danjumingxitables[i].houzhengli = mx[0].houzhengli + "+" + cmbgongyi.Text;
                        danjumingxitables[i].ganghao = mx[0].ganghao;
                    }
                    else
                    {
                        danjumingxitables[i].houzhengli = cmbgongyi.Text;
                    }
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                        }
                }
                foreach (var d in danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)))
                {
                    var t = ToupiList.Where(x => x.ganghao == d.ganghao).ToList();
                    if(t.Count >0)
                    {
                        d.Rangchang = t[0].FactoryName;
                        d.houzhengli = t[0].houzhengli ;
                    }
                }
                gridControl2.RefreshDataSource();
                gridView2.CloseEditor();
            }
        }

        private void ChengpingButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace ( cmbgongyi.Text))
            {
                MessageBox.Show("请先填写工艺名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var fm = new 订单号选择() { UseFul=1};
            fm.ShowDialog();
            var row = gridView2.FocusedRowHandle;
            foreach (var d in fm.returnDatas)
            {
                danjumingxitables[row].OrderNum = d.order.OrderNum;
                danjumingxitables[row].ContractNum =d.order.ContractNum;
                danjumingxitables[row].CustomName = d.order.CustomerName;
                danjumingxitables[row].bizhong = "人民币￥";
                danjumingxitables[row].Bianhao = d.orderDetail .sampleNum;
                danjumingxitables[row].guige = d.orderDetail.Specifications;
                danjumingxitables[row].chengfeng = d.orderDetail.Component;
                danjumingxitables[row].pingming = d.orderDetail.sampleName;
                danjumingxitables[row].kezhong = d.orderDetail.weight;
                danjumingxitables[row].menfu = d.orderDetail.width;
                danjumingxitables[row].FrabicWidth = d.orderDetail.width ;
                danjumingxitables[row].danwei = "米";
                danjumingxitables[row].OrderNum = d.orderDetail.OrderNum;
                danjumingxitables[row].kuanhao = d.orderDetail.Kuanhao;
                danjumingxitables[row].yanse = d.orderDetail.color;
                danjumingxitables[row].chengpingmishu = d.orderDetail.Num - d.orderDetail.consignmentNum;
                danjumingxitables[row].Huahao = d.orderDetail.Huahao;
                danjumingxitables[row].ColorNum = d.orderDetail.ColorNum;
                danjumingxitables[row].CustomerColorNum = d.orderDetail.CustomerColorNum;
                danjumingxitables[row].CustomerPingMing = d.orderDetail.CustomerPingMing;
                var mx = ToupiList.Where(x => x.SampleNum == d.orderDetail.sampleNum && x.OrderNum == d.orderDetail.OrderNum && x.color == d.orderDetail.color).ToList();
                if (mx.Count > 0)
                {
                    danjumingxitables[row].houzhengli = mx[0].houzhengli + "+" + cmbgongyi.Text;
                    danjumingxitables[row].ganghao = mx[0].ganghao;
                }
                else
                {
                    danjumingxitables[row].houzhengli = cmbgongyi.Text;
                }
               row++;
                if (row == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                    }
            }
            gridControl2.RefreshDataSource();
            gridView2.CloseEditor();
        }
        private void 计算缩率()
        {
            var toupishu = ToupiList.Sum(x => x.ToupiMishu);
            if (toupishu != 0)
            {
                var chengpingshu = danjumingxitables.Sum(x => x.chengpingmishu);
                txtsuolv.Text = Convert.ToInt32((toupishu - chengpingshu) / toupishu * 100).ToString();
            }
            else
            {
                txtsuolv.Text = "0";
            }
        }
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //ToupiList[gridView2.FocusedRowHandle].Heji = ToupiList[gridView2.FocusedRowHandle].Danjia * ToupiList[gridView2.FocusedRowHandle].ToupiMishu;
                danjumingxitables [gridView2.FocusedRowHandle].hanshuiheji  = danjumingxitables[gridView2.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView2.FocusedRowHandle].chengpingmishu;
                var gang = ToupiList.Where(x => x.ganghao == danjumingxitables[gridView2.FocusedRowHandle].ganghao).ToList();
                if(gang.Count >0)
                {
                    danjumingxitables[gridView2.FocusedRowHandle].houzhengli = gang[0].houzhengli + "+"+cmbgongyi.Text;
                    danjumingxitables[gridView2.FocusedRowHandle].Rangchang = gang[0].FactoryName;
                }
                gridControl2.RefreshDataSource();
                计算缩率();
            }
            catch
            {
                MessageBox.Show("请输入数字。计算错误","错误",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }
        }

        private void 相同信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace ( cmbgongyi.Text) )
            {
                MessageBox.Show("请先填写工艺名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = 0;
            foreach (var pingzhong in ToupiList.Where(x=>x.SampleNum!=null).ToList ())
            {
                var mingxi= (new danjumingxitable()
                {
                    CustomName = pingzhong.CustomName,
                    chengfeng = pingzhong.chengfeng,
                    ganghao = pingzhong.ganghao,
                    Bianhao = pingzhong.SampleNum,
                    pingming = pingzhong.sampleName,
                    guige = pingzhong.Specifications,
                    ContractNum = pingzhong.ContractNum,
                    chengpingmishu = pingzhong.ToupiMishu,
                    chengpingjuanshu = pingzhong.ToupiJuanshu,
                    bizhong = "人民币￥",
                    beizhu = pingzhong.SampleRemarks,
                    Chengpingyanse = pingzhong.color,
                    yanse = pingzhong.color,
                    danhao = txtdanhao.Text, 
                    menfu = pingzhong.menfu,
                    Kuwei = pingzhong.Remarkers,
                    kezhong = pingzhong.kezhong,
                    kuanhao = pingzhong.kuanhao,
                    OrderNum = pingzhong.OrderNum,
                    Huahao=pingzhong.Huahao ,
                    rq = dateEdit1.DateTime,
                    danwei = "米",
                    rkdh = pingzhong.rkdh,
                    CustomerColorNum=pingzhong.CustomerColorNum ,
                    CustomerPingMing=pingzhong.CustomerPingMing ,
                    ColorNum =pingzhong.ColorNum ,
                    Rangchang =pingzhong.FactoryName ,
                    Pihao =pingzhong.Pihao ,
                    PiBuChang=pingzhong.PibuChang ,
                    FrabicWidth=pingzhong.FrabicWidth ,
                });
                if (pingzhong.houzhengli != "")
                {
                  mingxi.  houzhengli = pingzhong.houzhengli + "+" + cmbgongyi.Text;
                }
                else
                {
                    mingxi.houzhengli = cmbgongyi.Text;
                }
                danjumingxitables[i]=(mingxi);
                i++;
            } 
            gridControl2.RefreshDataSource();
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fm = new 供货商选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }

        private void cmbcunfang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtckmc.Text = "";
            }
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            danjumingxitables[gridView2.FocusedRowHandle].yanse = fm.colorInfo.ColorName ;
            danjumingxitables[gridView2.FocusedRowHandle].ColorNum  = fm.colorInfo.ColorNum ;
            gridControl2.RefreshDataSource();
            gridView2.CloseEditor();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.委外取货单 , dateEdit1.DateTime, DanjuLeiXing.委外取货单 );
            }
        }

        private void colorbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.CloseEditor();
                var colorlist = ColorTableService.GetColorTablelst(x => x.ColorNum.Contains(danjumingxitables[gridView1.FocusedRowHandle].yanse));
                ColorTable color = new ColorTable();
                if (colorlist.Count > 1)
                {
                    var fm = new 色号选择() { colorInfo = new ColorTable() { ColorNum = danjumingxitables[gridView1.FocusedRowHandle].yanse } };
                    fm.ShowDialog();
                    color = fm.colorInfo;
                }
                else
                {
                    if (colorlist.Count == 1)
                    {
                        color = colorlist[0];
                    }
                }
                if (!string.IsNullOrEmpty(color.ColorNum))
                {
                    danjumingxitables[gridView1.FocusedRowHandle].ColorNum = color.ColorNum;
                    danjumingxitables[gridView1.FocusedRowHandle].yanse = color.ColorName;
                }
                gridControl1.RefreshDataSource();
            }
        }

        private void 添加行ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToupiList.Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
        }

        private void 删除行ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
    }
}
