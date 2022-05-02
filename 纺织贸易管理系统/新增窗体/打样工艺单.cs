using BLL;
using DevComponents.DotNetBar.Controls;
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
    public partial class 打样工艺单 : Form
    {
        private LXR jiagongchang = new LXR();
        private LXR Kehu = new LXR();
        private BindingList <ShengchandanSeLaodu > ColorTables = new BindingList<ShengchandanSeLaodu> ();
        private int rowindex;
        public DanjuTable danju { get; set; }

        public int Useful { get; set; }
        public 打样工艺单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            gridView1.Columns["Yaoqiu"].ColumnEdit = colorbtn;
        }

        private void txtjiagongc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {        
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            jiagongchang = fm.linkman;
            txtjiagongc.Text = jiagongchang.MC;
            txtlianxidianhua.Text = jiagongchang.DH;
            txtlianxiren.Text = jiagongchang.Lxr;
            if(jiagongchang.Leixing =="染厂")
            {
                comleixing.Text = "色卡";
            }
        }
        private void txtjiagongc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter )
            {
                var linkman = new LXR() { ZJC = txtjiagongc.Text };
                var fm = new 供货商选择() { linkman = linkman };
                fm.ShowDialog();
                jiagongchang = fm.linkman;
                txtjiagongc.Text = jiagongchang.MC;
                txtlianxidianhua.Text = jiagongchang.DH;
                txtlianxiren.Text = jiagongchang.Lxr;
            }
        }

        private void 打样工艺单_Load(object sender, EventArgs e)
        {
            cmbgongyimingcheng.DataSource = DanjuTableService.GetDanjuTablelst(x => x.djlx == DanjuLeiXing.打样工艺单).Select(x => x.yaoqiu ).Distinct ().ToList ();
            if(Useful==FormUseful.新增 )
            {
                Init();
            }
            else
            {
                if (Useful == FormUseful.修改)
                {
                    Edit();
                }
                else
                {
                    if (Useful == FormUseful.复制)
                    {
                        Edit();
                        dateEdit1.DateTime = DateTime.Now;
                        txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样指示单, dateEdit1.DateTime, DanjuLeiXing.打样工艺单);
                        foreach (var y in ColorTables)
                        {
                            y.shengchandanhao = txtdanhao.Text;
                        }
                        Useful = FormUseful.新增;
                    }
                    else
                    {
                        Edit();
                        保存ToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }
        private void Init()
        {                 
            foreach (Control c in this.groupControl1.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样指示单 , dateEdit1.DateTime, DanjuLeiXing.打样工艺单);
            checkBoxX1.Checked = true;
            checkBoxX2.Checked = true;
            checkBoxX3.Checked = true;
            checkBoxX4.Checked = true;
            txtguangyue.Text = "";
            txtcicun.Text = "";
            ColorTables.Clear();
           for(int i=0;i<20;i++)
            {
                ColorTables.Add(new ShengchandanSeLaodu() { shengchandanhao=txtdanhao.Text });
            }
            gridControl1.DataSource = ColorTables;
            gridControl1.RefreshDataSource();
            Useful = FormUseful.新增;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            dateEdit1.DateTime = danju.rq;
            jiagongchang.BH = danju.ksbh;
             jiagongchang.MC = danju.ksmc;
            txtjiagongc.Text = jiagongchang.MC;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtorder.Text = danju.ordernum;
            //客户名称
            Kehu.MC = danju.SaleMan;
            txtkehu.Text = Kehu.MC;
            //客户编号
            Kehu.BH = danju.wuliuBianhao;
            //合同号
            txthetonghao.Text = danju.HetongHao ;
            //布料编号
            txtbianhao.Text = danju.StockName;
            //品名
            txtpingming.Text = danju.CarLeixing;
            //规格
            txtguige.Text = danju.CarNum;
            //成分
            txtchengfeng.Text = danju.ckmc;
            //备注
            txtbeizhu.Text = danju.bz;
            txtBuliaoSource.Text = danju.fromDanhao;
            txtkezhong.Text = danju.Weight;
            txtheji.Value = danju.je;
            comhanshui.Text = danju.Hanshui;
            cmbqiankuan.Text = danju.Qiankuan;
            comleixing.Text = danju.jiagongleixing;
            ColorTables =new BindingList<ShengchandanSeLaodu>(ShengchandanSeLaoduService.GetShengchandanSeLaodulst(x => x.shengchandanhao == danju.dh));   
            for(int i=ColorTables.Count;i<20;i++)
            {
                ColorTables.Add(new ShengchandanSeLaodu() { shengchandanhao = danju.dh });
            }
            gridControl1.DataSource = ColorTables;
            gridControl1.RefreshDataSource();
            var listhouzhengli = ShengchandanHouzhengliService.GetShengchandanHouzhenglilst(x=>x.shengchandanhao==danju.dh );
            if(listhouzhengli.Where (x=>x.HouzhengliGongyi =="A").ToList ()[0].Value ==true )
            {
                checkBoxX1.Checked = true;
            }
            else
            {
                checkBoxX1.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "B").ToList()[0].Value == true)
            {
                checkBoxX2.Checked = true;
            }
            else
            {
                checkBoxX2.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "C").ToList()[0].Value == true)
            {
                checkBoxX3.Checked = true;
            }
            else
            {
                checkBoxX3.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "D").ToList()[0].Value == true)
            {
                checkBoxX4.Checked = true;
            }
            else
            {
                checkBoxX4.Checked = false;
            }
            var yaoqius = ShengChanDanHouZhengLiYaoQiuService.GetShengChanDanHouZhengLiYaoQiulst(x => x.ShengChanDanHao == danju.dh);
            txtguangyue.Text = yaoqius.Where(x => x.HouZhengLiYaoQiu == "光学要求").ToList()[0].YaoQiu;
            txtcicun.Text = yaoqius.Where(x => x.HouZhengLiYaoQiu == "尺寸要求").ToList()[0].YaoQiu;
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linkman = new LXR() { ZJC ="",MC="" };
            var fm = new 客户选择 () { linkman = linkman };
            fm.ShowDialog();
            Kehu  = fm.linkman;
            txtkehu .Text = Kehu .MC;
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var linkman = new LXR() { ZJC = txtjiagongc.Text,MC="" };
                var fm = new 客户选择() { linkman = linkman };
                fm.ShowDialog();
                Kehu = fm.linkman;
                txtkehu.Text = Kehu .MC;
            }
        }

        private void txtbuliaobianhao_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(txtorder.Text =="")
            {
                var fm = new 品种选择() { zjc=txtpingming .Text };
                fm.ShowDialog();
                if (fm.pingzhong.Count > 0)
                {
                    var pingzhong = fm.pingzhong[0];
                    txtbianhao.Text = pingzhong.bh;
                    txtpingming.Text = pingzhong.pm;
                    txtguige.Text = pingzhong.gg;
                    txtchengfeng.Text = pingzhong.cf;
                    txtkezhong.Text = pingzhong.kz;
                }
            }
            else
            {
                var fm = new 订单明细选择 () { OrderNum  = txtorder .Text };
                fm.ShowDialog();
                if (fm.pingzhong.Count > 0)
                {
                    var pingzhong = fm.pingzhong[0];
                    txtbianhao.Text = pingzhong.sampleNum;
                    txtpingming.Text = pingzhong.sampleName;
                    txtguige.Text = pingzhong.Specifications;
                    txtchengfeng.Text = pingzhong.Component;
                }
            }
        }

        private void txtpingming_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                if (txtorder.Text == "")
                {
                    var fm = new 品种选择() { zjc = txtpingming.Text };
                    fm.ShowDialog();
                    if (fm.pingzhong.Count > 0)
                    {
                        var pingzhong = fm.pingzhong[0];
                        txtbianhao.Text = pingzhong.bh;
                        txtpingming.Text = pingzhong.pm;
                        txtguige.Text = pingzhong.gg;
                        txtchengfeng.Text = pingzhong.cf;
                    }
                }
                else
                {
                    var fm = new 订单明细选择() { OrderNum = txtorder.Text };
                    fm.ShowDialog();
                    if (fm.pingzhong.Count > 0)
                    {
                        var pingzhong = fm.pingzhong[0];
                        txtbianhao.Text = pingzhong.sampleNum;
                        txtpingming.Text = pingzhong.sampleName;
                        txtguige.Text = pingzhong.Specifications;
                        txtchengfeng.Text = pingzhong.Component;
                    }
                }
            }
        }

        private void txtorder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择();
            fm.ShowDialog();
            txtorder.Text = fm.Order.OrderNum;
            txthetonghao.Text = fm.Order.ContractNum;
            txtkehu.Text = fm.Order.CustomerName ;
            if (fm.Order.CustomerNum !=null )
            {
                Kehu = LXRService.GetOneLXR(x => x.BH == fm.Order.CustomerNum);
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj =new ShengchandanSeLaodu () };
            fm.ShowDialog();
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorTables .Add(new ShengchandanSeLaodu() { shengchandanhao  = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<ShengchandanSeLaodu>(ColorTables , rowindex, gridView1, gridView1.FocusedRowHandle);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (comleixing.Text =="")
            {
                MessageBox.Show("请填写工艺类型！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var danju = new DanjuTable() {
                dh = txtdanhao.Text,
                rq = dateEdit1.DateTime,
                ksbh = jiagongchang.BH,
                ksmc = jiagongchang.MC,
                lianxidianhua = txtlianxidianhua.Text,
                lianxiren = txtlianxiren.Text,
                djlx = DanjuLeiXing.打样工艺单,
                own = User.user.YHBH,
                ordernum = txtorder.Text,
                //客户名称
                SaleMan = Kehu.MC,
                //客户编号
                wuliuBianhao = Kehu.BH,
                //合同号
                HetongHao = txthetonghao.Text,
                //布料编号
                StockName = txtbianhao.Text,
                //品名
                CarLeixing = txtpingming.Text,
                //规格
                CarNum = txtguige.Text,
                //成分
                ckmc = txtchengfeng.Text,
                //类型
                jiagongleixing = comleixing.Text,
                //合计费用
                je = txtheji.Value,
                Hanshui = comhanshui.Text,
                Qiankuan = cmbqiankuan.Text,
                zhuangtai = "已审核",
                bz = txtbeizhu.Text,
                yaoqiu = cmbgongyimingcheng.Text,
                Weight = txtkezhong.Text,
                //布料来源
                fromDanhao = txtBuliaoSource.Text
            };
            var listhouzhenli = new List<ShengchandanHouzhengli>();
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "A", Value = checkBoxX1.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "B", Value = checkBoxX2.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "C", Value = checkBoxX3.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "D", Value = checkBoxX4.Checked });
            var yaoqius = new List<ShengChanDanHouZhengLiYaoQiu>();
            yaoqius.Add(new ShengChanDanHouZhengLiYaoQiu() { ShengChanDanHao = txtdanhao.Text, HouZhengLiYaoQiu ="光学要求", YaoQiu=txtguangyue.Text });
            yaoqius.Add(new ShengChanDanHouZhengLiYaoQiu() { ShengChanDanHao = txtdanhao.Text, HouZhengLiYaoQiu = "尺寸要求", YaoQiu = txtcicun.Text });
            danju.TotalMishu = ColorTables.Where(x => x.Yaoqiu  != null).ToList().Count();
            if (Useful==FormUseful.新增 )
            {
                打样单BLL.保存(ColorTables.Where(x=>x.Yaoqiu !=null).ToList  (), danju,listhouzhenli,yaoqius  );
            }
            else
            {
                打样单BLL.修改(ColorTables.Where(x => x.Yaoqiu  != null).ToList(), danju, listhouzhenli, yaoqius);
            }
            AlterDlg.Show("保存成功！");
            Init();
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Design );
        }
        private void Print(int c)
        {
            var danju = new DanjuTable()
            {
                dh = txtdanhao.Text,
                rq = dateEdit1.DateTime,
                ksbh = jiagongchang.BH,
                ksmc = jiagongchang.MC,
                lianxidianhua = txtlianxidianhua.Text,
                lianxiren = txtlianxiren.Text,
                djlx = DanjuLeiXing.打样工艺单,
                own = User.user.YHBH,
                ordernum = txtorder.Text,
                //客户名称
                SaleMan = Kehu.MC,
                //客户编号
                wuliuBianhao = Kehu.BH,
                //合同号
                HetongHao  = txthetonghao.Text,
                //布料编号
                StockName = txtbianhao.Text,
                //品名
                CarLeixing = txtpingming.Text,
                //规格
                CarNum = txtguige.Text,
                //成分
                ckmc = txtchengfeng.Text,
                yaoqiu  =cmbgongyimingcheng.Text ,
                bz=txtbeizhu.Text ,
                zhuangtai = "未审核",
                Weight = txtkezhong.Text,
                  //布料来源
                fromDanhao = txtBuliaoSource.Text
            };
            var listhouzhenli = new List<ShengchandanHouzhengli>();
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "A", Value = checkBoxX1.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "B", Value = checkBoxX2.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "C", Value = checkBoxX3.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "D", Value = checkBoxX4.Checked });
            var yaoqius = new List<ShengChanDanHouZhengLiYaoQiu>();
            yaoqius.Add(new ShengChanDanHouZhengLiYaoQiu() { ShengChanDanHao = txtdanhao.Text, HouZhengLiYaoQiu = "光学要求", YaoQiu = txtguangyue.Text });
            yaoqius.Add(new ShengChanDanHouZhengLiYaoQiu() { ShengChanDanHao = txtdanhao.Text, HouZhengLiYaoQiu = "尺寸要求", YaoQiu = txtcicun.Text });
            danju.TotalMishu = ColorTables.Where(x => x.Yaoqiu  != null).ToList().Count();
            var result = new Tools.打印打样单() {  colorTables = ColorTables.Where(x => x.Yaoqiu  != null).ToList() ,formInfo= new FormInfo() {  FormName ="打样工艺单查询" , GridviewName="gridView1" }, DanjuTable=danju ,  houzhenglis=listhouzhenli ,yaoqius=yaoqius};
            result.打印(PrintPath.报表模板+"打样工艺单.frx",c );
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print (PrintModel.Privew );
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Print );
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            ColorTables [gridView1.FocusedRowHandle].Yaoqiu  = fm.colorInfo.ColorName ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 打样工艺单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (Useful != FormUseful.修改&&Useful!=FormUseful.查看  )
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样指示单 , dateEdit1.DateTime, DanjuLeiXing.打样工艺单);
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linkman = new LXR() { ZJC = txtBuliaoSource .Text };
            var fm = new 供货商选择() { linkman = linkman };
            fm.ShowDialog();
            txtBuliaoSource.Text = fm.linkman.MC;
        }

        private void txtBuliaoSource_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var linkman = new LXR() { ZJC = txtBuliaoSource.Text };
                var fm = new 供货商选择() { linkman = linkman };
                fm.ShowDialog();
                txtBuliaoSource.Text = fm.linkman.MC;
            }
        }
    }
}
