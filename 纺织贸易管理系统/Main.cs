using BLL;
using DAL;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.基本资料;
using 纺织贸易管理系统.报表窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.汇总窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统
{
    public  partial  class Main :MetroForm 
    {
        private List<MenuTable> menuTables;
        private string res = string.Empty;
        public Main()

        {
            MainForm.mainform = this;
            //Connect.Environmen = "公司";
            //Connect.GetColumntable();
            StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(ColorScheme.GetColor("0E6D38"), ColorScheme.GetColor("0E6D38"));
            InitializeComponent();
            toolStripStatusLabel2.Text = "版本号:" + User.version.ToString();
            Task.Run(new Action(() => { Tools.ReportService.DownLoad(Application.StartupPath); }));
            //创建菜单
            CreatFatherMenu();
            Task.Run(new Action(() => { GetAccess.GetUserAccess(User.user.YHBH); }));
            uiTitlePanel1.Text = "欢迎" + User.user.YHMC;
            Task.Run(new Action(() =>
            {
                QueryTime.间隔 = Convert.ToInt32(SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "时间间隔", settingValue = "" }).settingValue);
                string settingvalue = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "数量小数位", settingValue = "" }).settingValue;
                QueryTime.DanjubianhaoRule = string.IsNullOrWhiteSpace(SettingService.GetSetting(x => x.settingname == "单据编号规则").settingValue) ? "类型+年份+月份+日+累计编号" : SettingService.GetSetting(x => x.settingname == "单据编号规则").settingValue;
                QueryTime.Digit = Convert.ToInt32(settingvalue == string.Empty ? "1" : settingvalue);
                QueryTime.IsTax = SettingService.GetSetting(x => x.settingname == "默认含税").settingValue;
                QueryTime.IsTax = string.IsNullOrWhiteSpace(QueryTime.IsTax) ? "含税" : QueryTime.IsTax;
                QueryTime.IsBuyStyle = SettingService.GetSetting(x => x.settingname == "采购类型").settingValue;
                QueryTime.IsBuyStyle = string.IsNullOrWhiteSpace(QueryTime.IsBuyStyle) ? "成品采购" : QueryTime.IsBuyStyle;
                QueryTime.IsFabricStyle = SettingService.GetSetting(x => x.settingname == "产品类型").settingValue;
                var isneedSaleman = SettingService.GetSetting(x => x.settingname == "业务员必填").settingValue;
                QueryTime.IsNeedSaleMan  =string.IsNullOrWhiteSpace (isneedSaleman ) ?"否":isneedSaleman ;
                QueryTime.Tax = (SettingService.GetSetting(x => x.settingname == "税率").settingValue ?? "6").TryToDecmial(6);
                QueryTime .DefaultLabel  = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "默认标签", settingValue = string.Empty  }).settingValue;
                if(string.IsNullOrWhiteSpace ( QueryTime .DefaultLabel) )
                {
                    QueryTime.DefaultLabel = Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels")[0];
                }

                QueryTime.Suolv = string.IsNullOrWhiteSpace(SettingService.GetSetting(x => x.settingname == "报警缩率").settingValue) ? 100 : SettingService.GetSetting(x => x.settingname == "报警缩率").settingValue.TryToInt(0);
            }));
        }
        /// <summary>
        /// 创建菜单
        /// </summary>
        public  void CreatFatherMenu()
        {
            navBarControl1.Groups.Clear();
            var fathermenu = FatherMenuTableService.GetFatherMenuTablelst(x=>x.UserID==User.user.YHBH ).Where(x=>x.Visiable==true ).ToList ();
            menuTables = MenuTableService.GetMenuTablelst();
            foreach (FatherMenuTable f in fathermenu)
            {
                DevExpress.XtraNavBar.NavBarGroup group = new DevExpress.XtraNavBar.NavBarGroup
                {
                    Name = f.FatherMenuName,
                    Caption = f.FatherMenuName,
                    //SmallImage = global::纺织贸易管理系统.Properties.Resources.BOFolder_16x16
                };
                switch (group.Name)
                {
                    case "基本资料":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.基本资料;
                        break;
                    case "样品管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.样品管理 ;
                        break;
                    case "展会管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.展会管理 ;
                        break;
                    case "销售管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.销售管理;
                        break;
                    case "采购管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.采购管理;
                        break;
                    case "生产管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.生产管理 ;
                        break;
                    case "库存管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.库存管理;
                        break;
                    case "财务管理":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.财务管理;
                        break;
                    case "系统信息":
                        group.SmallImage = global::纺织贸易管理系统.Properties.Resources.系统信息 ;
                        break;
                }
                this.navBarControl1.Groups.Add(group);
                //group.Expanded = true;
                CreatMenu(f.FatherMenuName ,group );
            }
        }
        //创建子菜单
      private void CreatMenu(string fathermenu,NavBarGroup group)
        {
            foreach (MenuTable m in menuTables.Where<MenuTable >(x=>x.FatherMenu==fathermenu&&x.Visitable==true &&x.UserID==User.user.YHBH  ) )
            {
                var item = new NavBarItem() { Caption = m.MenuName, Name = m.FormName };
                item.ImageOptions.SmallImage = global::纺织贸易管理系统.Properties.Resources.菜单;
                group.ItemLinks.Add(new NavBarItemLink(item));
            }
        }
        

        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
          var menu=  MenuTableService.GetOneMenuTable(x => x.MenuName == e.Link.Caption);
            if (menu.FormName != "")
            {
                switch (menu.FormName )
                {
                    case "费用报销单":
                     if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        {
                            CheckTab(new 费用报销列表 () { Text = menu.MenuName + "列表" });
                        }
                        else
                        {
                            CheckTab(new 采购查询());
                        }
                        break;
                    case "账户管理":
                        CheckTab(new 账户资料 ());
                        break;
                    case "细码库存":
                        CheckTab(new 细码库存());
                        break;
                    case "展会管理":
                        CheckTab(new 展会管理() { Userful=FormUseful.新增 });
                        break;
                    case "委外发货列表":
                        CheckTab(new 委外通知列表());
                        break;
                    case "检验通知列表":
                        CheckTab(new 检验通知列表());
                        break;
                    case "出展记录":
                        CheckTab(new 出展记录 ());
                        break;
                    case "色卡库存":
                        CheckTab(new 色卡库存 ());
                        break;
                    case "仓库调拨单":
                        CheckTab(new 库存调拨单查询());
                        break;
                    case "经轴信息":
                        CheckTab(new 码单());
                        break;
                    case "打样工艺单":
                        CheckTab(new 打样工艺单查询());
                        break;
                    case "重新建账":
                        new 输入密码().ShowDialog();
                        break;
                    case "用户管理":
                        CheckTab(new 用户管理());
                        break;
                    case "公司信息":
                        CheckTab(new 公司信息());
                        break;
                    case "菜单管理":
                        CheckTab(new 菜单管理());
                        break;
                    case "权限管理":
                        CheckTab(new 权限管理());
                        break;
                    case "坯布日产量":
                        CheckTab(new 坯布日产量统计());
                        break;
                    case "门市采样单":
                        CheckTab(new 门市采样统计());
                        break;
                    case "品种资料":
                        CheckTab(new 品种资料());
                        break;
                    case "寄件列表":
                        CheckTab(new 寄件列表 ());
                        break;
                    case "打样管理":
                        CheckTab(new 打样管理());
                        break;
                    case "采购入库单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        {
                            CheckTab(new 采购单列表() { Text =menu.MenuName + "列表" });
                        }
                        else
                        {
                            CheckTab(new 采购查询());
                        }
                        break;
                    case "客户资料":
                        CheckTab(new 客户资料());
                        break;
                    case "供货商资料":
                        CheckTab(new 供货商资料());
                        break;
                    case "库存查询":
                        CheckTab(new 库存报表());
                        break;
                    case "委外加工单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        {
                            CheckTab(new 委外加工单列表() { Text = menu.MenuName + "列表" });
                        }
                        else
                        {
                            CheckTab(new 委外加工查询());
                        }
                            break;
                    case "委外取货单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 委外取货列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 委外取货查询());
                        }
                        break;
                    case "销售退货单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 销售退货列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 销售退货查询());
                        }
                        break;
                    case "销售计划单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 销售订单查询() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 销售计划单查询());
                        }
                        break;
                    case "员工资料":
                        CheckTab(new 员工管理());
                        break;
                    case "物流资料":
                        CheckTab(new 物流管理());
                        break;
                    case "架子资料":
                        CheckTab(new 架子资料 ());
                        break;
                    case "仓库资料":
                        CheckTab(new 仓库信息());
                        break;
                    case "支架资料":
                        CheckTab(new 支架信息());
                        break;
                    case "色号资料":
                        CheckTab(new 色号资料());
                        break;
                    case "盘盈入库单":
                        CheckTab(new 盘盈入库查询());
                        break;
                    case "盘亏出库单":
                        CheckTab(new 盘亏出库查询());
                        break;
                    case "寄样记录分析":
                        CheckTab(new 寄样统计());
                        break;
                    case "寻找样布":
                        CheckTab(new 寻找样布());
                        break;
                    case "员工管理":
                        CheckTab(new 员工管理());
                        break;
                    case "销售发货单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 销售发货列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 销售发货单查询());
                        }
                        break;
                    case "打卷报表":
                        CheckTab(new 打卷报表());
                        break;
                    case "生产指示单":
                        CheckTab(new 生产计划单查询());
                        break;
                    case "疵点管理":
                        CheckTab(new 疵点信息());
                        break;
                    case "应收款管理":
                        CheckTab(new 应收款查询());
                        break;
                    case "应付款管理":
                        CheckTab(new 应付款查询());
                        break;
                    case "采购退货单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 采购退货列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 采购退货查询());
                        }
                        break;
                    case "开具发票":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        {
                            CheckTab(new 发票开具列表() { Text = menu.MenuName + "列表" });
                        }
                        else
                        {
                            CheckTab(new 发票开具查询());
                        }
                        break;
                    case "发票签收":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        {
                            CheckTab(new 发票签收列表() { Text = menu.MenuName + "列表" });
                        }
                        else
                        {
                            CheckTab(new 发票签收查询());
                        }
                        break;
                    case "采购通知单":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 采购通知单列表 () { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 采购通知单查询());
                        }
                        break;
                    case "流转卡管理":
                        CheckTab(new 流程卡查询());
                        break;
                    case "唛头关联":
                        CheckTab(new 唛头关联 ());
                        break;
                    case "生产入库单":
                        CheckTab(new 来货入库 () { Text = menu.MenuName + "列表" });
                        break;
                    case "工艺信息":
                        CheckTab(new 工艺信息 ());
                        break;
                    case "机台信息":
                        CheckTab(new 岗位信息 ());
                        break;
                    case "发货通知单":
                        CheckTab(new 发货通知单查询());
                        break;
                    case "退货申请单":
                        CheckTab(new 退货申请单查询());
                        break;
                    case "来样管理":
                        CheckTab(new 来样报价查询());
                        break;
                    case "色卡采购":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 色卡采购列表 () { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 色卡采购列表 ());
                        }
                        break;
                    case "色卡销售":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 色卡销售列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 色卡销售列表());
                        }
                        break;
                    case "色卡盘盈":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 色卡盘盈列表() { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 色卡盘盈列表());
                        }
                        break;
                    case "色卡盘亏":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 色卡盘亏列表 () { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 色卡盘亏列表());
                        }
                        break;
                    case "生产退卷查询":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 生产退卷查询 () { Text = menu.MenuName+"列表" }); }
                        else
                        {
                            CheckTab(new 生产退卷查询());
                        }
                        break;
                    case "成品登记":
                        if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = "列表样式" }).settingValue == "清单样式")
                        { CheckTab(new 成品登记列表  () { Text = menu.MenuName + "列表" }); }
                        else
                        {
                            CheckTab(new 成品登记列表 ());
                        }
                        break;
                    case "点色通知列表":     
                            CheckTab(new 点色通知列表 ());
                        break;
                    case "配桶登记列表":                       
                            CheckTab(new 配桶登记列表 ());               
                        break;
                    case "进出记录":
                        CheckTab(new 进出记录 ());
                        break;
                    case "白坯销售列表":
                        CheckTab(new 白坯销售列表 ());
                        break;
                    case "白坯直销单":
                        CheckTab(new 白坯直销列表());
                        break;
                 
                    case "销售统计":
                        if (AccessBLL.CheckAccess("销售统计") == true)
                        {
                            CheckTab  (new 销售统计());
                        }
                        break;
                }
            }
        }
        //检查有没有一样的窗体
        private void CheckTab(Form form)
        {
            if (BLL.AccessBLL.CheckAccess(form.Text ))
            {
                foreach (SuperTabItem page in superTabControl1.Tabs)
                {
                    if (page.Text == form.Text)
                    {
                        superTabControl1.SelectedTab = page;
                        return;
                    }

                }
                AddMidForm(form);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this,"您没有使用该功能的权限！请让管理员为你开通");
            }
        }
        /// <summary>
        /// 把窗体添加到tab里面
        /// </summary>
        /// <param name="form">窗体类</param>
        public void AddMidForm(Form form )
        {
            try
            {
                SuperTabItem page = superTabControl1.CreateTab(form.Name );
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                form.TopLevel = false;
                page.Name = form.Text;
                page.Text = form.Text ;
                page.AttachedControl.Controls.Add(form);
                superTabControl1.Tabs.Add(page);
                superTabControl1.SelectedTab = page;
                form.Visible = true;
            }
            catch (Exception ex)
            {
                AlterDlg.Show(ex.Message);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.ExitThread();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
           Task.Run (new Action(() =>
           {
               var r = new Rate.ExRate();
               try
               {
                   RateModel.CurrentRate = (decimal)r.GetUsdRate();
                   res = "    当前人民币对美元的汇率是" + String.Format("{0:N}", RateModel.CurrentRate ) + "    日期是" + DateTime.Now.ToString();
               }
               catch
               {
                   res = "获取不到汇率"; 
               }
           }));
            if (res == "获取不到汇率")
            {
                toolStripStatusLabel3.Text = res;
                timer1.Stop();
            }
            else
            {
               toolStripStatusLabel3.Text = res;
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
           CompanyLabel.Text = infoService.Getinfolst()[0].gsmc ;
            timer1.Start();
        }

        private void Main_HelpButtonClick(object sender, EventArgs e)
        {
            var fm = new 关于窗体();
            fm.ShowDialog();
        }

        private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            SuperTabItem tab = e.Tab as SuperTabItem;
            var frms = this.superTabControl1.SelectedPanel.Controls.Find(tab.Text, false);
            if (frms.Length > 0)
            {
                Form frm =frms[0] as Form;
                var menutable = MenuTableService.GetOneMenuTable(x => x.FormName == frm.Name);
                if (menutable.FormName!="")
                {
                   var res =! Sunny.UI.UIMessageDialog.ShowAskDialog(this, "您确定要关闭该页面吗？\n确定关闭按确定。否则按取消");
                    e.Cancel = res;
                }
            }
        }
    }
}
