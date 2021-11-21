﻿using BLL;
using DAL;
using DevComponents.DotNetBar.Controls;
using Model;
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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 销售发货单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private List<JuanHaoTable> juanList = new List<JuanHaoTable>();
        private int rowindex;

        public 销售发货单()
        {
            InitializeComponent();          
            CreateGrid.Create(this.Name  ,gridView1);
            CreateGrid.Create(this.Name , gridView2);
            cmbFahuogongsi .DataSource = infoService.Getinfolst().Select(x => x.gsmc).ToList();
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
                gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
                gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["IsHanshui"].ColumnEdit = cmbHanshui;
                cmbMadanYangshi.Text = SettingService.GetSetting(new Setting() { formname = this.Name, settingname = "码单样式", settingValue = "" }).settingValue;
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
            var fm = new 客户选择() { linkman=new LXR() { MC="",ZJC="" } };
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
            var fm = new 仓库选择();
            fm.ShowDialog();
            txtckmc.Text = fm.stock.mingcheng;
            加载卷();
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(txtckmc.Text =="")
            {
                MessageBox.Show("请先选择仓库名称","错误",MessageBoxButtons.OK );
                return;
            }
            var fm = new 库存选择() { StockName=txtckmc.Text };
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
                danjumingxitables[i].Chengpingyanse = pingzhong.YS;
                danjumingxitables[i].ganghao  = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS ;
                danjumingxitables[i].toupimishu  = pingzhong.MS;
                danjumingxitables[i].chengpingmishu  = pingzhong.MS ;
                danjumingxitables[i].Kuwei  = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum  = pingzhong.CustomerColorNum ;
                danjumingxitables[i].CustomerPingMing  = pingzhong.CustomerPingMing;
                danjumingxitables[i].rq = dateEdit1.DateTime;
                danjumingxitables[i].PiBuChang = pingzhong.PibuChang;
                danjumingxitables[i].Pihao = pingzhong.Pihao;
                danjumingxitables[i].IsHanshui = IsHanshuiModel.含税;
                danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS&&x.Huahao==pingzhong.Huahao ).price;
                danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable () { danhao  = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text)});
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
            加载卷();
            检查其他费用();
        }
        private void  检查其他费用()
        {
            foreach(var d in danjumingxitables.Where (x=>x.OrderNum !=null ).Select (x=>x.OrderNum ).Distinct ().ToList ())
            {
                if(订单BLL.CheckOtherCost(d )==true )
                {
                  if(  销售发货单BLL .CheckDanjuMingxiContainOtherCost (d )==false )
                    {
                        Sunny.UI.UIMessageDialog.ShowAskDialog(this, $"改订单号{d }存在其他费用！而且对账单还没体现过！");
                    }
                }
            }
        }
        private void 重新加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null))
            {
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x =>x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.Huahao == d.Huahao&&x.ColorNum==d.ColorNum&&x.Ckmc ==txtckmc.Text &&x.Danhao ==txtdanhao.Text ));
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == txtckmc.Text && x.Danhao == ""));
            }
            gridControl2.DataSource =  juanList.OrderBy(x => x.yanse).ThenBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
            gridControl2.RefreshDataSource();
        }
        private void 加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null))
            {                 
                    juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.Ckmc == txtckmc.Text  &&  x.CustomerName ==d.CustomName  && x.SampleName == d.pingming && x.yanse == d.yanse && x.GangHao == d.ganghao && x.state == 0
                    &&x.kuanhao ==d.kuanhao &&x.OrderNum==d.OrderNum &&x.SampleNum ==x.SampleNum &&x.Houzhengli ==d.houzhengli &&x.Huahao==d.Huahao ));
            }
            juanList = juanList.OrderBy (x=>x.yanse ).ThenBy (x => x.GangHao).ThenBy(x => x.PiHao).ToList();
            gridControl2.DataSource = juanList;
            gridControl2.RefreshDataSource();
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
            加载卷();
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (ckshifa.Checked)
                {
                    danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].toupimishu;
                }
                else
                {
                    danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu ;
                }
                    gridControl1.RefreshDataSource();
            }
            catch 
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }
        //给单据信息赋值
        private void InitDanju()
        {
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = txtckmc.Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.销售出库单;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtShouhuodizhi.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = IsHanshuiModel.含税 ;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji)+danjumingxitables.Sum(x=>x.weishuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = (decimal)txtyunfei.Value;
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.own = User.user.YHBH;
            danju.Bizhong = cmbbizhong.Text;
            //danju.Fahuodizhi = txtjiagongchang.Text;
        }
        private List <JuanHaoTable > CreatJuanhao()
        {
            var juan = new List<JuanHaoTable>();
            foreach (var j in gridView2.GetSelectedRows())
            {
                
                juan.Add( juanList[j] );
            }
            return juan.OrderBy (x=>x.GangHao ).ThenBy (x=>x.PiHao ).ToList ();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if  (gridView2.SelectedRowsCount==0)
            {
                if (juanList.Count > 0)
                {
                    MessageBox.Show("没有任何卷被选中！保存失败", this.Name, MessageBoxButtons.OK , MessageBoxIcon.Information);
                    return;
                }
            }
            if (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            InitDanju();
            if (useful == FormUseful.新增)
            {
                if (财务BLL.查询额度(danju.ksbh, danjumingxitables.Sum(x => x.hanshuiheji)) == false)
                {
                    MessageBox.Show("该客户欠款额度已经不够了！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (SettingService.GetSetting(x => x.settingname == "检查账期").settingValue == "检查")
                {
                    if (财务BLL.检查是否有超期(danju.ksbh))
                    {
                        MessageBox.Show("该客户存在超期单据！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                var d = 库存BLL.检查库存(danjumingxitables, danju);
                if (d.Bianhao != null)
                {
                    var mes = $"该发货单中\n 布料编号:{d.Bianhao }\n 订单号:{d.OrderNum } \n 色号:{d.ColorNum } \n 缸号:{d.ganghao } \n 颜色:{d.yanse }在该仓库中没有！保存失败";
                    MessageBox.Show(mes, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                销售发货单BLL.保存单据(danju, danjumingxitables, CreatJuanhao());
            }
            else
            {
                销售发货单BLL.修改单据(danju, danjumingxitables, CreatJuanhao());
            }
            if (!string.IsNullOrWhiteSpace(SysInfo.GetInfo.own))
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        销售发货单BLL.单据审核(danju.dh);
                        检测状态.检测(danjumingxitables);
                    }
                }
                else
                {
                    检测状态.检测(danjumingxitables);
                }
            }
            AlterDlg.Show("保存成功");
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
            txtjiagongchang.Text = "";
            dateEdit1.DateTime = DateTime.Now.Date;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.销售发货单 , dateEdit1.DateTime, DanjuLeiXing.销售出库单);
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            gridControl2.DataSource=null ;
            useful = FormUseful.新增;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable () };
            fm.ShowDialog();
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            foreach (var d in danjumingxitables )
            {
                d.chengpingmishu = 0;
                d.chengpingjuanshu = 0;
            }
            foreach (var i in gridView2.GetSelectedRows())
            {
                var juan = new JuanHaoTable();
                juan = juanList.First(x => x.JuanHao == gridView2.GetRowCellValue(i, "JuanHao").ToString());
   
                var d= danjumingxitables.Where(x => x.OrderNum == juan.OrderNum   && x.Bianhao==juan .SampleNum &&x.ganghao==juan .GangHao &&x.kuanhao ==juan.kuanhao 
                &&x.houzhengli==juan.Houzhengli &&x.yanse==juan.yanse&&x.Huahao ==juan.Huahao&&x.ColorNum==juan.ColorNum ).ToList ();
                if(d.Count>0)
                {
                    if (d[0].danwei == "米" && juan.Danwei == "米")
                    {
                        d[0].chengpingmishu += juan.biaoqianmishu ;
                        d[0].toupimishu  =juan.MaShu !=0? d[0].chengpingmishu /(100+(100- juan.MaShu) /100) : d[0].chengpingmishu;
                    }
                    else
                    {
                        if (d[0].danwei == "米" && juan.Danwei == "码")
                        {
                            d[0].chengpingmishu += juan.biaoqianmishu*(decimal)0.9144;
                            d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                        }
                        else
                        {
                            if (d[0].danwei == "码" && juan.Danwei == "码")
                            {
                                d[0].chengpingmishu += juan.biaoqianmishu ;
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

        private void 销售发货单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit();
                if (useful == FormUseful.查看)
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
            juanList = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == txtdanhao.Text).OrderBy(x => x.GangHao).ThenBy (x=>x.PiHao ).ToList(); ;
            gridControl2.DataSource = juanList;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.ckmc ;
            cmbcunfang.Text = danju.StockName;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbqiankuan.Text = danju.Qiankuan;
            //danju.Fahuodizhi = txtjiagongchang.Text;
            //comhanshui.Text = danju.Hanshui;
            dateEdit1.Text = danju.rq.ToShortDateString();           
        }

        private void 码单编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Design);
        }
        private void 打印码单(int use)
        {
            InitDanju();
            if (cmbMadanYangshi.Text == "竖版样式")
            {
                var madan = new Tools.打印成品码单()
                {
                    danjuTable = danju,
                    danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                    danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                    juanHaoTables = CreatJuanhao(),
                    mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name },
                    gsmc = cmbFahuogongsi.Text
                };
                madan.Print(PrintPath.报表模板 + "\\madan.frx", use);
            }
            else
            {
                if (cmbMadanYangshi.Text == "清单码单")
                {
                    var madan = new Tools.打印清单码单()
                    {
                        gsmc =cmbFahuogongsi.Text ,
                        danjuTable = danju,
                        danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                        danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                        juanHaoTables = CreatJuanhao(),
                        mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name },
                        JuanInfo = new Tools.FormInfo { FormName = "打卷报表", GridviewName = gridView2.Name }
                    };
                    madan.Print(PrintPath.报表模板 + "\\清单码单.frx", use);
                }
                else
                {
                    if (cmbMadanYangshi.Text == "横版样式")
                    {
                        try
                        {
                            var Yidabaolist = CreatJuanhao();
                            if (Yidabaolist.Count > 0)
                            {
                                new Tools.打印横版码单() { gsmc = cmbFahuogongsi.Text, danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } }.打印(use, PrintPath.报表模板 + "\\A4纸.frx");
                            }
                            else
                            {
                                MessageBox.Show("没有任何包装信息！打印失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            var Yidabaolist = CreatJuanhao();
                            if (Yidabaolist.Count > 0)
                            {
                                new Tools.打印包装码单() { gsmc = cmbFahuogongsi.Text, danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } }.打印(use, PrintPath.报表模板 + "\\打包码单.frx");
                            }
                            else
                            {
                                MessageBox.Show("没有任何包装信息！打印失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void 码单预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Privew );
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Print );
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Privew);
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Design);
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Print );
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }

        private void 重新加载卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重新加载卷();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SettingService.Update(new Setting() { formname = this.Name, settingname = "码单样式", settingValue = cmbMadanYangshi.Text });
                MessageBox.Show("设置默认标签成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置默认标签失败！原因是" + ex.Message);
            }
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.销售发货单 , dateEdit1.DateTime, DanjuLeiXing.销售出库单 );
            }
        }

        private void txtjiagongchang_ButtonCustomClick(object sender, EventArgs e)
        {
            var fm = new 供货商选择();
            fm.ShowDialog();
            txtjiagongchang.Text = fm.linkman.MC;
        }

        private void ckshifa_ValueChanged(object sender, bool value)
        {
            if(value )
            {
                foreach(var d in danjumingxitables )
                {
                    d.hanshuiheji = d.hanshuidanjia  * d.toupimishu;
                }
            }
            else
            {
                foreach (var d in danjumingxitables)
                {
                    d.hanshuiheji = d.hanshuidanjia  * d.chengpingmishu;
                }
            }
            gridControl1.RefreshDataSource();
        }
    }
}
