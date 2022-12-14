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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 库存调拨单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();     
        public DanjuTable danju = new DanjuTable();
        private List<JuanHaoTable> juanList = new List<JuanHaoTable>();
        private int rowindex;

        public 库存调拨单()
        {
            InitializeComponent();         
            CreateGrid.Create(this.Name  ,gridView1);
            CreateGrid.Create("委外加工单", gridView2);
            gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["danwei"].ColumnEdit = cmddanwei ;
            gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
            gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
            gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
            gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";          
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 仓库选择 () ;
            fm.ShowDialog();
            danju.ksbh = fm.stock.bianhao ;
            danju.ksmc = fm.stock.mingcheng ;
            txtkehu.Text = danju.ksmc;
        }

        private void txtwuliu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择();
            fm.ShowDialog();
            danju.wuliuBianhao  = fm.linkman.Bianhao  ;
            txtwuliu.Text = fm.linkman.name;
            var wuliu= WuliuTableService.GetOneWuliuTable(x => x.Bianhao == fm.linkman.Bianhao );
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;          
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cmbcunfang.Text == "仓库")
            {
                var fm = new 仓库选择() { stock = new StockInfoTable() { mingcheng = cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
                CreateGrid.CreateKuweiCmb(gridView1, txtckmc.Text);
            }
            else
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC = txtckmc.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                CreateGrid.ClearKuwei(gridView1);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(txtkehu .Text =="")
            {
                MessageBox.Show("请先选择仓库名称","错误",MessageBoxButtons.OK );
                return;
            }
            var fm = new 库存选择() { StockName=txtkehu.Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao  = pingzhong.BH ;
                danjumingxitables[i].guige = pingzhong.GG;
                danjumingxitables[i].chengfeng = pingzhong.CF;
                danjumingxitables[i].pingming  = pingzhong.PM;
                danjumingxitables[i].kezhong  = pingzhong.KZ;          
                danjumingxitables[i].menfu  = pingzhong.MF;
                danjumingxitables[i].danwei  = "米";
                danjumingxitables[i].ContractNum  = pingzhong.ContractNum ;
                danjumingxitables[i].CustomName = pingzhong.CustomName ;
                danjumingxitables[i].OrderNum  = pingzhong.orderNum ;
                danjumingxitables[i].kuanhao  = pingzhong.kuanhao ;
                danjumingxitables[i].houzhengli  = pingzhong.houzhengli ;
                danjumingxitables[i].yanse  = pingzhong.YS ;
                danjumingxitables[i].ganghao  = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS ;
                danjumingxitables[i].chengpingmishu  = pingzhong.MS ;
                danjumingxitables[i].Kuwei  = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                danjumingxitables[i].Rangchang = pingzhong.Rangchang;
                danjumingxitables[i].PiBuChang = pingzhong.PibuChang;
                danjumingxitables[i].Pihao = pingzhong.Pihao;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable () { danhao  = txtdanhao.Text, rq = dateEdit1.DateTime});
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
            加载卷();
        }
        private void 加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)))
            {
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.state == 0 && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum&&x.Ckmc ==txtkehu.Text ));
            }
            juanList = juanList.OrderBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
            gridControl2.DataSource = juanList;
        }
        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择 ();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].OrderNum = fm.Order.OrderNum;
            danjumingxitables[gridView1.FocusedRowHandle].CustomName  = fm.Order.CustomerName ;
            danjumingxitables[gridView1.FocusedRowHandle].ContractNum  = fm.Order.ContractNum ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle,this );
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                gridControl1.RefreshDataSource();
            }
            catch 
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }
        private void InitDanju()
        {
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text;
            danju.CarNum = txtchepai.Text;
            danju.StockName = cmbcunfang.Text;
            danju.ckmc = txtckmc.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.移库单 ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;
            danju.lianxiren = txtlianxiren.Text;
            //danju.Qiankuan = cmbqiankuan.Text;
            //danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = (decimal)txtyunfei.Value;
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.zhuangtai = "未审核";
            danju.own = User.user.YHBH;
        }
        private List<JuanHaoTable> CreatJuanhao()
        {
            var juan = new List<JuanHaoTable>();
            foreach (var j in gridView2.GetSelectedRows())
            {
                juan.Add(juanList[j]);
            }
            return juan.OrderBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (txtckmc.Text == "" || txtkehu.Text == "")
            {
                MessageBox.Show("请选择收货地址或者发货仓库！保存失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            InitDanju();
            if (useful == FormUseful.新增)
            {
                库存调拨单BLL  .保存单据(danju, danjumingxitables, CreatJuanhao());
            }
            else
            {
                库存调拨单BLL.修改单据(danju, danjumingxitables, CreatJuanhao());
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        库存调拨单BLL.单据审核(danju.dh);
                    }
                }
            }
            else
            {
                库存调拨单BLL  .单据审核(danju.dh);
            }
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
            txtdanhao.Text = BianhaoBLL.CreatDanhao("DBD", dateEdit1.DateTime, DanjuLeiXing.移库单);          
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl1.RefreshDataSource();
            juanList.Clear();
            gridControl2.RefreshDataSource();
            useful = FormUseful.新增;
        }
        private void 委外加工单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.库存调拨单 , dateEdit1.DateTime, DanjuLeiXing.移库单);
               dateEdit1.DateTime= DateTime.Now;
                danju.dh = txtdanhao.Text;
            }
            else
            {
                Edit();
                if(useful==FormUseful.查看 )
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.shouhuodizhi;
            cmbcunfang.Text = danju.ckmc;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString(); 
            dateEdit1.DateTime =danju.rq;
        }

        private void 码单预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            var madan = new Tools.打印成品码单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
            
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            };
            madan.Print(PrintPath.报表模板 + "\\madan.frx", PrintModel.Privew);
        }

        private void 码单编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                InitDanju();
                var madan = new Tools.打印成品码单()
                {
                    danjuTable = danju,
                    danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                    danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                    mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
                };
                madan.Print(PrintPath.报表模板 + "\\madan.frx", PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitDanju();
            var madan = new Tools.打印成品码单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },

                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            };
            madan.Print(PrintPath.报表模板 + "\\madan.frx", PrintModel.Print );
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 仓库选择 () ;
                fm.ShowDialog();
                danju.ksbh = fm.stock.bianhao ;
                danju.ksmc = fm.stock.mingcheng ;
                txtkehu.Text = danju.ksmc;
            }
        }

        private void cmbcunfang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtckmc.Text = "";
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 库存调拨单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.库存调拨单, dateEdit1.DateTime, DanjuLeiXing.移库单);
            }
        }

        private void 重新加载卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重新加载卷();
        }
        private void 重新加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null))
            {
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == txtckmc.Text&&x.state==0));
            }
            gridControl2.DataSource = juanList.OrderBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
            gridControl2.RefreshDataSource();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = "委外加工单" , Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            foreach (var d in danjumingxitables)
            {
                d.chengpingmishu = 0;
                d.chengpingjuanshu = 0;
            }
            foreach (var i in gridView2.GetSelectedRows())
            {
                var juan = new JuanHaoTable();
                juan = juanList.First(x => x.JuanHao == gridView2.GetRowCellValue(i, "JuanHao").ToString());

                var d = danjumingxitables.Where(x => x.OrderNum == juan.OrderNum && x.Bianhao == juan.SampleNum && x.ganghao == juan.GangHao && x.kuanhao == juan.kuanhao
                 && x.houzhengli == juan.Houzhengli && x.yanse == juan.yanse && x.Huahao == juan.Huahao && x.ColorNum == juan.ColorNum).ToList();
                if (d.Count > 0)
                {
                    if (d[0].danwei == "米" && juan.Danwei == "米")
                    {
                        d[0].chengpingmishu += juan.biaoqianmishu;
                        d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                    }
                    else
                    {
                        if (d[0].danwei == "米" && juan.Danwei == "码")
                        {
                            d[0].chengpingmishu += juan.biaoqianmishu * (decimal)0.9144;
                            d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                        }
                        else
                        {
                            if (d[0].danwei == "码" && juan.Danwei == "码")
                            {
                                d[0].chengpingmishu += juan.biaoqianmishu;
                                d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                            }
                            else
                            {
                                d[0].chengpingmishu += juan.biaoqianmishu / (decimal)0.9144;
                                d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                            }
                        }
                    }
                    d[0].chengpingjuanshu++;
                }
            }
            foreach (var d in danjumingxitables)
            {
                d.hanshuiheji = d.hanshuidanjia * d.chengpingmishu;
            }
            gridControl1.RefreshDataSource();
        }
    }
}
