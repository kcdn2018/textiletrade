using BLL;
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
    public partial class 白坯直销单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private List<FabricMadan> juanList = new List<FabricMadan>();
        private int rowindex;

        public 白坯直销单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            //CreateGrid.Create(this.Name , gridView2);
            cmbFahuogongsi.DataSource = infoService.Getinfolst().Select(x => x.gsmc).ToList();
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
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
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            cmbCaihouhansui.SelectedIndex = 0;
            cmbxiaoshouhanshui.SelectedIndex = 0;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
        }

        private void txtwuliu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择();
            fm.ShowDialog();
            danju.wuliuBianhao = fm.linkman.Bianhao;
            txtwuliu.Text = fm.linkman.name;
            var wuliu = fm.linkman;
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择();
            fm.ShowDialog();
            txtckmc.Text = fm.linkman.MC;
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (系统设定.GetSet(new Setting() { formname = "", settingname = "采购显示订单明细", settingValue = "不显示" }).settingValue == "不显示" || danjumingxitables[gridView1.FocusedRowHandle].OrderNum == null)
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
                        danjumingxitables[i].FrabicWidth = pingzhong.mf;
                        danjumingxitables[i].danwei = "米";
                        i++;
                        if (i == danjumingxitables.Count - 1)
                            for (int j = 0; j < 30; j++)
                            {
                                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                            }
                    }
                }
                else
                {
                    OrderDetailSelect.Select(gridView1.FocusedRowHandle, danjumingxitables, new List<RangShequpiTable>(), "", txtdanhao.Text, dateEdit1.DateTime);
                }
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }
        private void 检查其他费用()
        {
            foreach (var d in danjumingxitables.Where(x => x.OrderNum != null).Select(x => x.OrderNum).Distinct().ToList())
            {
                if (订单BLL.CheckOtherCost(d) == true)
                {
                    if (销售发货单BLL.CheckDanjuMingxiContainOtherCost(d) == false)
                    {
                        Sunny.UI.UIMessageDialog.ShowAskDialog(this, $"改订单号{d }存在其他费用！而且对账单还没体现过！");
                    }
                }
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
                danjumingxitables[row].FrabicWidth = d.orderDetail.width;
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
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
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
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle, this);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                danjumingxitables[gridView1.FocusedRowHandle].weishuiheji = danjumingxitables[gridView1.FocusedRowHandle].weishuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                if (cmbCaihouhansui.Text == "含税")
                { danjumingxitables[gridView1.FocusedRowHandle].Cost = danjumingxitables[gridView1.FocusedRowHandle].weishuiheji / (1 + QueryTime.Tax / 100); }
                else
                {
                    danjumingxitables[gridView1.FocusedRowHandle].Cost = danjumingxitables[gridView1.FocusedRowHandle].weishuiheji;
                }
                decimal xiaoshoue = 0;
                if(cmbxiaoshouhanshui.Text =="含税")
                {
                    xiaoshoue = danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji / (1 + QueryTime.Tax / 100);
                }
                else
                {
                    xiaoshoue = danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji;
                }
                danjumingxitables[gridView1.FocusedRowHandle].Profit =xiaoshoue  - danjumingxitables[gridView1.FocusedRowHandle].Cost;
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
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.白坯直销单 ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtShouhuodizhi.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Hanshui  =cmbxiaoshouhanshui.Text ;
            danju.CaiGouHanshui  = cmbCaihouhansui.Text ;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = txtyunfei.Text.TryToDecmial();
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.own = User.user.YHBH;
            danju.Bizhong ="人民币";
            danju.SaleMan = txtyewuyuan.Text;
            danju.ChaCheFei = txtChachefei.Text.TryToDecmial();
            danju.ZhuangXieFei = txtzhuangxiefei.Text.TryToDecmial();
            danju.Qiankuan = "欠款";
            //danju.Fahuodizhi = txtjiagongchang.Text;
        }
        /// <summary>
        /// 检查数据是否完整
        /// </summary>
        /// <returns></returns>
        private Boolean CheckAllField()
        {
            if (string.IsNullOrWhiteSpace(txtckmc.Text.Trim(' ')))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择供货商");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtkehu.Text.Trim(' ')))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择客户");
                return false;
            }
            if (danjumingxitables.Sum(x => x.chengpingmishu) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return false;
            }
            if (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return false;
            }
            if (QueryTime.IsNeedSaleMan == "是")
            {
                if (string.IsNullOrWhiteSpace(txtyewuyuan.Text))
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择一个业务员。业务员必须填写！");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtkehu.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择一个客户。客户必须填写！");
                return false;
            }
            if (useful == FormUseful.新增)
            {
                if (财务BLL.查询额度(danju.ksbh, danjumingxitables.Sum(x => x.hanshuiheji)) == false)
                {
                    MessageBox.Show("该客户欠款额度已经不够了！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (SettingService.GetSetting(x => x.settingname == "检查账期").settingValue == "检查")
                {
                    if (财务BLL.检查是否有超期(danju.ksbh))
                    {
                        MessageBox.Show("该客户存在超期单据！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            return true;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (CheckAllField()==false )
            {
                return;
            }
            InitDanju();
            if (useful == FormUseful.新增)
            {
                白坯直销单BLL .保存单据(danju, danjumingxitables, juanList);
            }
            else
            {
                白坯直销单BLL.修改单据(danju, danjumingxitables, juanList);
            }
            if (!string.IsNullOrWhiteSpace(SysInfo.GetInfo.own))
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        白坯直销单BLL.单据审核(danju.dh);
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
            foreach (Control c in this.groupControl1.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    c.Text = "";
                }
                if (c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            txtjiagongchang.Text = "";
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.白坯直销单 , dateEdit1.DateTime, DanjuLeiXing.白坯直销单 );
            txtChachefei.Text = "0";
            txtyunfei.Text = "0";
            txtzhuangxiefei.Text = "0";
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            juanList = Connect.DbHelper().Queryable<FabricMadan>().Where(x => x.Danhao == txtdanhao.Text).ToList();
            length = juanList.Count;
            for (int i = 0; i < 10 - length; i++)
            {
                juanList.Add(new FabricMadan() { Danhao = txtdanhao.Text });
            }
            txtyewuyuan.Text =string.Empty ;
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            gridControl2.DataSource = juanList;
            gridControl2.RefreshDataSource();
            cmbCaihouhansui.SelectedIndex = 0;
            cmbxiaoshouhanshui.SelectedIndex = 0;
            useful = FormUseful.新增;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable () };
            //fm.ShowDialog();
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
            for (int i = 0; i < 30 - danjumingxitables.Count; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            juanList = Connect.DbHelper().Queryable<FabricMadan>().Where(x => x.Danhao == danju.dh).ToList();
            var length = juanList.Count;
            for (int i = 0; i < 10 - length; i++)
            {
                juanList.Add(new FabricMadan() { Danhao = txtdanhao.Text });
            }
            gridControl2.DataSource = juanList;
            gridControl1.DataSource = danjumingxitables;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.ckmc;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbxiaoshouhanshui .Text = danju.Hanshui ;
            txtzhuangxiefei.Text = danju.ZhuangXieFei.ToString();
            txtChachefei.Text = danju.ChaCheFei.ToString();
            dateEdit1.DateTime = danju.rq;
            txtyewuyuan.Text = danju.SaleMan;
            cmbCaihouhansui.Text = danju.CaiGouHanshui;
        }

        private void 码单编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Design);
        }
        private void 打印码单(int use)
        {
            if (CheckAllField() == false)
            {
                return;
            }
            InitDanju();
            new 打印白坯码单()
            {
                Danju = danju,
                Danjumingxitables = danjumingxitables,
                juanhaolist = juanList,
                FormInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" }
            }.Print(use, PrintPath.报表模板 + "\\白坯码单.frx");

        }
        private void 码单预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Privew);
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            打印码单(PrintModel.Print);
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheckAllField()==false )
            {
                return;
            }
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
            if (CheckAllField() == false)
            {
                return;
            }
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
            if (CheckAllField() == false)
            {
                return;
            }
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Print);
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }


        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.白坯直销单, dateEdit1.DateTime, DanjuLeiXing.白坯直销单);
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
            if (value)
            {
                foreach (var d in danjumingxitables)
                {
                    d.hanshuiheji = d.hanshuidanjia * d.toupimishu;
                }
            }
            else
            {
                foreach (var d in danjumingxitables)
                {
                    d.hanshuiheji = d.hanshuidanjia * d.chengpingmishu;
                }
            }
            gridControl1.RefreshDataSource();
        }

        private void txtyewuyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择();
            fm.ShowDialog();
            txtyewuyuan.Text = fm.linkman.Xingming;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int juanshu = 0;//合计卷数
            decimal TotalMishu = 0;//合计米数
            foreach (var j in juanList)
            {
                if (j.C1 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C1;
                }
                if (j.C2 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C2;
                }
                if (j.C3 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C3;
                }
                if (j.C4 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C4;
                }
                if (j.C5 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C5;
                }
                if (j.C6 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C6;
                }
                if (j.C7 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C7;
                }
                if (j.C8 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C8;
                }
                if (j.C9 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C9;
                }
                if (j.C10 > 0)
                {
                    juanshu++;
                    TotalMishu += j.C10;
                }

            }
            danjumingxitables[0].chengpingmishu = TotalMishu;
            danjumingxitables[0].chengpingjuanshu = juanshu;
            gridControl1.RefreshDataSource();
        }

        private void cmbCaihouhansui_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var m in danjumingxitables)
                {
                    if (m.hanshuiheji != 0 && m.weishuiheji != 0)
                    {
                        m.hanshuiheji = m.hanshuidanjia * m.chengpingmishu;
                        m.weishuiheji = m.weishuidanjia * m.chengpingmishu;
                        if (cmbCaihouhansui.Text == "含税")
                        { m.Cost = m.weishuiheji / (1 + QueryTime.Tax / 100); }
                        else
                        {
                            m.Cost = m.weishuiheji;
                        }
                        decimal xiaoshoue = 0;
                        if (cmbxiaoshouhanshui.Text == "含税")
                        {
                            xiaoshoue = m.hanshuiheji / (1 + QueryTime.Tax / 100);
                        }
                        else
                        {
                            xiaoshoue = m.hanshuiheji;
                        }
                        m.Profit = xiaoshoue - m.Cost;
                    }
                    gridControl1.RefreshDataSource();
                }
            }
            catch
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }
    }
}
