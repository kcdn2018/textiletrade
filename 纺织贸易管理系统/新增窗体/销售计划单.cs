using BLL;
using Microsoft.VisualBasic.ApplicationServices;
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
using 纺织贸易管理系统.报表窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 销售计划单 : Form
    {
        public int useful = FormUseful.新增;
        public OrderTable order = new OrderTable();
        public List<OrderDetailTable> orderDetailTables = new List<OrderDetailTable>();
        private int rowindex;
        public 销售计划单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["sampleNum"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["color"].ColumnEdit = colorbtn;
                gridView1.Columns["ColorNum"].ColumnEdit = colorbtn;
                gridView1.Columns["Unit"].ColumnEdit = cmbdanwei;
                gridView1.Columns["OtherCostStyle"].ColumnEdit = cmbleixing;
                gridView1.Columns["Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Total"].SummaryItem.FieldName = "Total";
                gridView1.Columns["Total"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["Num"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Num"].SummaryItem.FieldName = "Num";
                gridView1.Columns["Num"].SummaryItem.DisplayFormat = "{null}";
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
                var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderDetailTable() };
                fm.ShowDialog();
            }
          
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { ZJC="",MC=""  } };
            fm.ShowDialog();
            order.CustomerNum  = fm.linkman.BH;
            order.CustomerName = fm.linkman.MC;
            txtkehu.Text = fm.linkman.MC;
            txtkehu.Text = fm.linkman.MC;
            txtaddEamil.Text = fm.linkman.YX;
            txtaddress.Text = fm.linkman.dz;
            txtCustomerAddress.Text = fm.linkman.dz;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new OrderDetailTable () };
            fm.ShowDialog();
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                orderDetailTables[i].OrderNum = txtdanhao.Text;
                orderDetailTables[i].sampleName  = pingzhong.pm;
                orderDetailTables[i].sampleNum  = pingzhong .bh;
                orderDetailTables[i].Component = pingzhong.cf;
                orderDetailTables[i].Specifications = pingzhong.gg;
                orderDetailTables[i].weight  = pingzhong.kz;
                orderDetailTables[i].width  = pingzhong.mf;
                orderDetailTables[i].EnglishName = pingzhong.EnglishName;
                orderDetailTables[i].Num = 0;
                orderDetailTables[i].color  = pingzhong.ys ;
                orderDetailTables[i].Total  = 0;
                orderDetailTables[i].Unit  = "米";
                orderDetailTables[i].price  = pingzhong.jg .TryToDecmial(0);
                i++;
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.FocusedRowHandle;
            if (row >= 0)
                if (orderDetailTables[row].Num != 0)
                {
                    try
                    {
                        string suolv = dbService.GetOnedb(x => x.bh == orderDetailTables[row].sampleNum).sl;
                        if (gridView1.FocusedColumn.FieldName == "Num")
                        {
                            orderDetailTables[row].YutouMishu = orderDetailTables[row].Num * (1 + Convert.ToDecimal(suolv) / 100);
                        }
                    }
                    catch
                    {
                        orderDetailTables[row].YutouMishu = orderDetailTables[row].Num;
                    }
                }
            orderDetailTables [gridView1.FocusedRowHandle].Total  = orderDetailTables [gridView1.FocusedRowHandle].price  * orderDetailTables [gridView1.FocusedRowHandle].Num ;
            gridControl1.RefreshDataSource();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void Init()
        {
            dateEdit1.DateTime = DateTime.Now.Date;
            txtbeizhu.Text = order.Remakers;
            txtdanhao.Text = BianhaoBLL.CreatOrderNum(FirstLetter.销售计划单, dateEdit1.DateTime.Date );
            txtdingjing.Value = 0;
            txthetonghao.Text = "";
            txtkehu.Text = "";
            txtyaoqiu.Text = "";
            txtsupemail.Text = infoService.Getinfolst()[0].Email;
            txtNopingse.Text = "此订单为非拼色订单，面料、里料、辅料（拉链、纽扣、水洗唛、LOGO、印花、绣花、缝纫线、松紧带、魔术贴、包边等）均无鲜明对比度颜色拼色。";
            txtHavePingse.Text = "";
            txtCustomerAddress.Text = "";
            txtaddress.Text = "";
            txtjiesuanfangshi.Text = "";
            var yuangonglist = YuanGongTableService.GetYuanGongTablelst(x => x.Xingming.Contains(""));
            txtyewuyuan.Text = yuangonglist.Count > 0 ? yuangonglist[0].Xingming : "";
            orderDetailTables.Clear();
            var length = orderDetailTables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                orderDetailTables.Add(new OrderDetailTable() { OrderNum = txtdanhao.Text });
            }
            gridControl1.RefreshDataSource () ;
        }
        private void 赋值Order()
        {
            order.ContractNum = txthetonghao.Text;
            order.CustomerName = txtkehu.Text;
            order.Orderdate = Convert.ToDateTime(dateEdit1.Text);
            order.TotalNum = orderDetailTables.Sum(x => x.Num);
            order.SumMoney = orderDetailTables.Sum(x => x.Total);
            order.ShengHe = "已审核";
            order.SaleMan = txtyewuyuan.Text;
            order.Rax = comhanshui.Text == "含税";
            order.Remakers = txtbeizhu.Text;
            order.state = "未审核";
            order.Yaoqiu = txtyaoqiu.Text;
            order.Deposit = (decimal)txtdingjing.Value;
            order.OrderNum = txtdanhao.Text;
            order.MoneyType = combizhong.Text;
            order.own = User.user.YHBH ;
            order.JiesuanStyle = txtjiesuanfangshi.Text;
            order.JiaohuoAddress = txtaddress.Text;
            order.NeedEmail = txtaddEamil.Text;
            order.NoPingColor = txtNopingse.Text;
            order.CustomerAddress = txtCustomerAddress.Text;
            order.HavePingColor = txtHavePingse.Text;
            order.SuppertEmail = txtsupemail.Text;
        }

     
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增 || useful ==FormUseful .复制 )
            {
              
                if (!string.IsNullOrWhiteSpace(txthetonghao.Text))
                {
                    if (订单BLL.检查合同号(txthetonghao.Text))
                    {
                        if (!Sunny.UI.UIMessageBox.ShowAsk("该合同号已经存在是否继续保持\r\n继续保持按确定，否则按取消"))
                        {
                            return;
                        }
                    }
                }
            }
            gridView1.CloseEditor();
            赋值Order();
            if (orderDetailTables .Where(x => !string.IsNullOrWhiteSpace(x.sampleNum) ).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            if (useful == FormUseful.新增 || useful == FormUseful.复制)
            {
                订单BLL.新增(order, orderDetailTables.Where(x=>!string.IsNullOrWhiteSpace(x.sampleNum)).ToList ());
            }
            else
            {
                订单BLL.修改(order, orderDetailTables.Where(x => !string.IsNullOrWhiteSpace(x.sampleNum) ).ToList());
            }
           if( Sunny.UI.UIMessageBox.ShowAsk("保存成功！\r\n是否直接开具生产指示单?\r\n直接开具按确定，否则按取消"))
            {
                List<ShengchanBuliaoInfo> buliaoInfos = new List<ShengchanBuliaoInfo>();
                foreach (var o in orderDetailTables.Where(x => !string.IsNullOrWhiteSpace(x.sampleNum) ).ToList())
                {
                    buliaoInfos.Add(new ShengchanBuliaoInfo()
                    {
                        BuliaoPingming = o.sampleName,
                        ChengpingMishu = o.Num,
                        ColorNum = o.ColorNum,
                        Danwei = o.danwei,
                        Jiaoqi = o.Jiaohuoriqi,
                        Kezhong = o.weight,
                        Menfu = o.width,
                        Kuanhao = o.Kuanhao,
                        SampleNum = o.sampleNum,
                        PibuPlaneNum = o.Num,
                        YutouMishu = o.YutouMishu,
                        Yanse = o.color,
                        Remarker = o.Remarkers
                    });
                }
                MainForm.mainform.AddMidForm(new 生成指示单()
                {
                    useful = FormUseful.跳转,
                    shengchandan = new ShengChanDanTable()
                    {
                        Hejimishu = orderDetailTables.Sum(x => x.Num),
                        Hetonghao = txthetonghao.Text,
                        hejiyutoumishu = orderDetailTables.Sum(x => x.YutouMishu),
                        OrderNum = txtdanhao.Text,
                        riqi = DateTime.Now.Date,
                        own = User.user.YHBH,
                        Xiadanyuan = txtyewuyuan.Text
                    },
                    shengchanBuliaoInfos = buliaoInfos
                }) ;
            }
            Init();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<OrderDetailTable >(orderDetailTables , rowindex, gridView1, gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderDetailTables.Add(new OrderDetailTable() { OrderNum = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
           
        }

        private void 销售计划单_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = orderDetailTables;
            if (useful == FormUseful.新增)
            {
                //if (useful == FormUseful.新增)
                //{
                //    txtdanhao.Text = BianhaoBLL.CreatOrderNum("S", User.user.YHBH);
                //    dateEdit1.Text = DateTime.Now.ToShortDateString();
                //    dateEdit2.Text = DateTime.Now.AddDays(30).ToShortDateString();
                //}
                Init();
            }
            else
            {
                if (useful == FormUseful.复制)
                {
                    Edit();
                    //txtdanhao.Text = BianhaoBLL.CreatOrderNum("S", User.user.YHBH);
                    txtdanhao.Text = BianhaoBLL.CreatOrderNum("S", dateEdit1.DateTime);
                    dateEdit1.DateTime = DateTime.Now;
                    foreach (var detail in orderDetailTables)
                    {
                        detail.OrderNum = txtdanhao.Text;
                        detail.Jiaohuoriqi = dateEdit1.DateTime.AddDays(30);
                    }
                }
                else
                {
                    Edit();
                    if (useful == FormUseful.查看)
                    {
                        保存ToolStripMenuItem.Enabled = false;
                    }
                }
            }
           
        }
        private void Edit()
        {
            txtbeizhu.Text = order .Remakers ;
            txtdanhao.Text = order.OrderNum;
            dateEdit1.Text = order.Orderdate.ToShortDateString();
            txtdingjing.Text = order.Deposit.ToString ();
            txthetonghao.Text = order.ContractNum;
            txtkehu.Text = order.CustomerName;
            txtyaoqiu.Text = order.Yaoqiu;
            txtyewuyuan.Text = order.SaleMan;
            txtaddEamil.Text = order.NeedEmail;
            txtsupemail.Text = order.SuppertEmail;
            txtNopingse.Text = order.NoPingColor;
            txtHavePingse.Text = order.HavePingColor;
            txtCustomerAddress.Text = order.CustomerAddress;
            txtaddress.Text = order.JiaohuoAddress;
            txtjiesuanfangshi.Text = order.JiesuanStyle;
            combizhong .Text = order.MoneyType;
            if (order.Rax == true)
            {
                comhanshui.Text = "含税";
            }
            else
            {
                comhanshui.Text = "不含税";
            }
            orderDetailTables  =OrderDetailTableService.GetOrderDetailTablelst (x => x.OrderNum  == txtdanhao.Text);
            var length = orderDetailTables .Count;
            for (int i = 0; i < 30 - length; i++)
            {
                orderDetailTables .Add(new OrderDetailTable () { OrderNum = txtdanhao.Text});
            }
            gridControl1.DataSource=orderDetailTables  ;
        }

        private void txtyewuyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择();
            fm.ShowDialog();
            txtyewuyuan.Text = fm.linkman.Xingming;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            赋值Order();
            new Tools.打印合同() { orderTable = order, orderDetailTables = orderDetailTables.Where(x => x.sampleNum != null).ToList(),  }.Print(PrintPath.报表模板 + "销售合同.frx", PrintModel.Privew);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            赋值Order();
            new Tools.打印合同() { orderTable = order, orderDetailTables = orderDetailTables.Where(x => x.sampleNum != null).ToList() }.Print(PrintPath.报表模板 + "销售合同.frx", PrintModel.Design);
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text ,MC=""} };
                fm.ShowDialog();
                order.CustomerNum = fm.linkman.BH;
                order.CustomerName = fm.linkman.MC;
                txtkehu.Text = fm.linkman.MC;
                txtaddEamil.Text = fm.linkman.YX;
                txtaddress.Text = fm.linkman.dz;
                txtCustomerAddress.Text = fm.linkman.dz;
               
            }
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            orderDetailTables[gridView1.FocusedRowHandle].color = fm.colorInfo.ColorName ;
            orderDetailTables[gridView1.FocusedRowHandle].ColorNum  = fm.colorInfo.ColorNum;
            gridView1.CloseEditor();
            gridControl1.RefreshDataSource();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            txtdanhao.ReadOnly = checkBoxX1.Checked;
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 销售计划单_FormClosing(object sender, FormClosingEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatOrderNum ("S", dateEdit1.DateTime);
            }
        }
    }
}
