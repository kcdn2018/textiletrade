using BLL;
using Microsoft.VisualBasic;
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
    public partial class 采购入库单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public int rowindex;
        public DanjuTable danju = new DanjuTable();
        public 采购入库单()
        {
            InitializeComponent();         
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.Columns["ColorNum"].ColumnEdit = colorbtn;
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 供货商选择() { linkman=new LXR() { MC="",ZJC="" } };
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
            var wuliu= WuliuTableService.GetOneWuliuTable(x => x.Bianhao == fm.linkman.Bianhao );
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;
            
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(cmbcunfang.Text=="仓库")
            {
                var fm = new 仓库选择() {  stock =new StockInfoTable() {  mingcheng=cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
                CreateGrid.CreateKuweiCmb(gridView1 ,txtckmc.Text );
            }
            else
            {
                var fm = new 供货商选择() {  linkman =new LXR() { MC=txtckmc.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                CreateGrid.ClearKuwei (gridView1);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (系统设定.GetSet(new Setting() { formname = "", settingname = "采购显示订单明细", settingValue = "不显示" }).settingValue == "不显示"||danjumingxitables[gridView1.FocusedRowHandle].OrderNum==null)
                {
                    var fm = new 品种选择();
                    fm.ShowDialog();
                    var i = gridView1.FocusedRowHandle;
                    foreach (var pingzhong in fm.pingzhong)
                    {
                        danjumingxitables[i].bizhong = "人民币￥";
                        danjumingxitables[i].Bianhao = pingzhong.bh;
                        danjumingxitables[i].guige = pingzhong.gg;
                        danjumingxitables[i].chengfeng = pingzhong.cf;
                        danjumingxitables[i].pingming = pingzhong.pm;
                        danjumingxitables[i].kezhong = pingzhong.kz;
                        danjumingxitables[i].menfu = pingzhong.mf;
                        danjumingxitables[i].danwei = "米";
                        i++;
                        if (i == danjumingxitables.Count - 1)
                            for (int j = 0; j < 30; j++)
                            {
                                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                            }
                    }
                }
                else
                {
                    OrderDetailSelect.Select(gridView1.FocusedRowHandle, danjumingxitables, new List<RangShequpiTable>(), "",txtdanhao.Text, dateEdit1.DateTime);
                }
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择() { UseFul = 1 };
            fm.ShowDialog();
            var row = gridView1.FocusedRowHandle;
            foreach (var d in fm.returnDatas)
            {
                danjumingxitables[row].OrderNum = d.order.OrderNum;
                danjumingxitables[row].ContractNum = d.order.ContractNum;
                danjumingxitables[row].CustomName = d.order.CustomerName;
                danjumingxitables[row].bizhong = "人民币￥";
                danjumingxitables[row].Bianhao = d.orderDetail.sampleNum;
                danjumingxitables[row].guige = d.orderDetail.Specifications;
                danjumingxitables[row].chengfeng = d.orderDetail.Component;
                danjumingxitables[row].pingming = d.orderDetail.sampleName;
                danjumingxitables[row].kezhong = d.orderDetail.weight;
                danjumingxitables[row].menfu = d.orderDetail.width;
                danjumingxitables[row].danwei = "米";
                danjumingxitables[row].OrderNum = d.orderDetail.OrderNum;
                danjumingxitables[row].kuanhao = d.orderDetail.Kuanhao;
                danjumingxitables[row].yanse = d.orderDetail.color;
                danjumingxitables[row].chengpingmishu = d.orderDetail.Num - d.orderDetail.consignmentNum;
                danjumingxitables[row].Huahao = d.orderDetail.Huahao;
                danjumingxitables[row].ColorNum = d.orderDetail.ColorNum;
                danjumingxitables[row].CustomerColorNum = d.orderDetail.CustomerColorNum;
                danjumingxitables[row].CustomerPingMing = d.orderDetail.CustomerPingMing;              
                row++;
                if (row == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                    }
            }
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex  =gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle);
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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (string.IsNullOrWhiteSpace ( txtckmc.Text.TrimEnd ()) ||string.IsNullOrWhiteSpace ( txtkehu.Text.TrimEnd ()))
            {
                MessageBox.Show("请选择收货地址或者供货商！保存失败",this.Text ,MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            if(danjumingxitables.Where (x=>!string.IsNullOrWhiteSpace(x.Bianhao) ).ToList ().Count ==0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text ;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = txtckmc.Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.ksmc = txtkehu.Text;
            danju.djlx = DanjuLeiXing.采购入库单 ;
            danju.rq = dateEdit1.DateTime.Date ;
            danju.shouhuodizhi = txtckmc.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji) + danjumingxitables.Sum(x => x.weishuiheji);
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = (decimal )txtyunfei.Value;
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.jiagongleixing = cmbcaigouleixing.Text;
            danju.own = User.user.YHBH;
            danju.zhuangtai = "未审核";
            if (useful == FormUseful.新增)
            {
                采购入库单BLL.保存单据(danju, danjumingxitables);
            }
            else
            {
                采购入库单BLL.修改单据(SQLHelper.SQLHelper.CreatNewInstance ( danju),SQLHelper.SQLHelper .CreatNewInstanceList ( danjumingxitables));
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) ==6)
                    {
                        采购入库单BLL.单据审核(danju.dh);
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
                if(c is DevComponents.DotNetBar.Controls.TextBoxX||c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            } 
            dateEdit1.DateTime  = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购入库单 ,dateEdit1.DateTime, DanjuLeiXing.采购入库单);        
            danjumingxitables.Clear();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            } 
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            useful = FormUseful.新增;
        }

        private void 采购入库单_Load(object sender, EventArgs e)
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
            txtckmc.Text = danju.shouhuodizhi;
            txtckmc.Text = danju.ckmc;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString ();
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
            dateEdit1.Text = danju.rq.ToShortDateString();
            cmbcaigouleixing.Text = danju.jiagongleixing;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 供货商选择 () { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }

        private void cmbcunfang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (useful != FormUseful.新增)
            {
                txtckmc.Text = txtckmc.Text;
            }
            else
            {
                txtckmc.Text = "";
            }
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].ColorNum  = fm.colorInfo.ColorNum;
            danjumingxitables[gridView1.FocusedRowHandle].yanse  = fm.colorInfo.ColorName  ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 采购入库单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        } 

        private void dateEdit1_SelectionChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购入库单 , dateEdit1.DateTime, DanjuLeiXing.采购入库单);
            }
        }

        private void 导入通知单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 采购通知单选择();
            fm.ShowDialog(this);
            int rowindex = gridView1.FocusedRowHandle;
            if(fm.pingzhong.Count >0)
            {
                var tongzhidan = DanjuTableService.GetOneDanjuTable(x => x.dh == fm.pingzhong[0].danhao);              
                cmbcunfang.Text = tongzhidan.ckmc ;
                txtckmc.Text = tongzhidan.shouhuodizhi ;
                txtkehu.Text = tongzhidan.ksmc;
                danju.ksbh = tongzhidan.ksbh;
                danju.ksmc = tongzhidan.ksmc;
            }
            foreach(var mingxi in fm.pingzhong )
            {
                danjumingxitables[rowindex] = mingxi;
                rowindex++;
            }
            gridControl1.RefreshDataSource();
        }
    }
}
