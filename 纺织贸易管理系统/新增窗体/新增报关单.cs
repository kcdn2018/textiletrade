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
    public partial class 新增报关单 : Form
    {
        public int useful = FormUseful.新增;
        /// <summary>
        /// 发货单号
        /// </summary>
        public string SaleDanhao { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string InnvoiceNo { get; set; }
        public 新增报关单()
        {
            InitializeComponent();          
            CreateGrid.Create("销售发货单"  ,gridView1);
            CreateGrid.Create("销售发货单", gridView2);
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
            if (fm.linkman != null)
            {
                var customer = fm.linkman;
                txtkehu.Text = customer.FullName;
                txtFAX.Text = customer.FAX;
                txtTexCode.Text = customer.TexCode;
                txtHAIPHONGPORT.Text = customer.HAIPHONGPORT;
                txtZIPCODE.Text = customer.ZIPCODE;
                txtyouxiang.Text = customer.YX;
                txtdizhi.Text = customer.dz;
                txtlianxidianhua.Text = customer.DH;
            }
        }
        /// <summary>
        /// 初始化表数据
        /// </summary>
        /// <returns></returns>
        private BaoGuanTable CreateDanju()
        {
            var b = Connect.DbHelper().Queryable<BaoGuanTable>().First(x => x.InvoiceNo == InnvoiceNo);
            int id = 0;
            if (useful ==FormUseful.修改 )
            {
                if(b!=null)
                {
                    id = b.ID;
                }
            }
            return new BaoGuanTable()
            {
                InvoiceDate = dtinvoice.Value,
                Carrier = txtCarrier.Text,
                DesPort = txtdesport.Text,
                FromAddress = txtFrom.Text,
                FromSaleNo = txtSaleNo.Text,
                InvoiceNo = txtInvoiceNo.Text,
                LCBank = txtLCBank.Text,
                LCDate = dtLC.Value,
                LCNO = txtlc.Text,
                LoadingPort = txtloadingport.Text,
                Notify = txtnotify.Text,
                Payment = txtpayment.Text,
                Remarks = txtremarker.Text,
                Sailing = txtSaleNo.Text,
                CompanyName = cmbFahuogongsi.Text,
                Customer = txtkehu.Text,
                SalingOnDate = dtsaling.Value,
                CustomerAddress = txtdizhi.Text,
                CustomerFax = txtFAX.Text,
                CustomerHAIPHONGPORT = txtHAIPHONGPORT.Text,
                CustomerTel = txtlianxidianhua.Text,
                CustomerTexCode = txtTexCode.Text,
                CustomerZIPCODE = txtZIPCODE.Text,
                SaleAddress = txtsaleAdd.Text,
                SaleTel =txtsaletel.Text ,
                CustomerEmail =txtyouxiang.Text ,
                ID=id
            };
        }
      
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkinfo = Check();
            if (!string.IsNullOrWhiteSpace(checkinfo))
            {
                MessageBox.Show(checkinfo);
                return;
            }
            gridView1.CloseEditor();
            var baoguandan = CreateDanju();
            if (useful == FormUseful.新增)
            {
                Connect.CreatConnect().Insert<BaoGuanTable>(baoguandan);
            }
            else
            {
                Connect.DbHelper().Updateable<BaoGuanTable>(baoguandan).ExecuteCommand();
            }
        }
        /// <summary>
        /// 检查字段填写情况
        /// </summary>
        /// <returns></returns>
        private string Check()
        {
           if(string.IsNullOrWhiteSpace ( txtInvoiceNo.Text ))
            {
                return "请填写发票号";
            }else
            {
                if(string.IsNullOrWhiteSpace(txtkehu.Text ))
                {
                    return "请填写客户信息";
                }
                else
                {
                    if(string.IsNullOrWhiteSpace (txtloadingport .Text ))
                    {
                        return "请填写出口港信息";
                    }
                    else
                    {
                        if(string.IsNullOrWhiteSpace (txtdesport .Text ))
                        {
                            return "请填写目的港口信息";
                        }
                        else
                        {
                            if(string.IsNullOrWhiteSpace (txtFrom .Text ))
                            {
                                return "请填写发货地址";
                            }
                            else
                            {
                                if(string.IsNullOrWhiteSpace(cmbFahuogongsi.Text ))
                                {
                                    return "请选择发货公司";
                                }
                                else
                                {
                                    if(string.IsNullOrWhiteSpace (txtpayment.Text ))
                                    {
                                        return "请选择付款方式";
                                    }
                                    else
                                    { return string.Empty; }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Init()
        {
            try
            {
                txtSaleNo.Text = this.SaleDanhao;
                gridControl1.DataSource = Connect.DbHelper().Queryable<danjumingxitable>().Where(x => x.danhao == SaleDanhao).ToList();
                gridControl2.DataSource = Connect.DbHelper().Queryable<JuanHaoTable>().Where(x => x.Danhao == SaleDanhao).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable () };
            fm.ShowDialog();
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
          
        }
        private void Edit()
        {
            try
            {
                var baoguandan = Connect.DbHelper().Queryable<BaoGuanTable>().First(x => x.InvoiceNo == this.InnvoiceNo);
                this.SaleDanhao = baoguandan.FromSaleNo;
                if (baoguandan != null)
                {
                    txtCarrier.Text = baoguandan.Carrier;
                    txtdesport.Text = baoguandan.DesPort;
                    txtFrom.Text = baoguandan.FromAddress;
                    txtInvoiceNo.Text = baoguandan.InvoiceNo;
                    txtkehu.Text = baoguandan.Customer;
                    txtlc.Text = baoguandan.LCNO;
                    txtLCBank.Text = baoguandan.LCBank;
                    txtloadingport.Text = baoguandan.LoadingPort;
                    txtnotify.Text = baoguandan.Notify;
                    txtpayment.Text = baoguandan.Payment;
                    txtremarker.Text = baoguandan.Remarks;
                    txtSaleNo.Text = baoguandan.FromSaleNo;
                    cmbFahuogongsi.Text = baoguandan.CompanyName;
                    dtinvoice.Value = baoguandan.InvoiceDate;
                    dtLC.Value = baoguandan.LCDate;
                    dtsaling.Value = baoguandan.SalingOnDate;
                    txtsaletel.Text = baoguandan.SaleTel;
                    txtTexCode.Text = baoguandan.CustomerTexCode;
                    txtyouxiang.Text = baoguandan.CustomerEmail;
                    txtZIPCODE.Text = baoguandan.CustomerZIPCODE;
                    txtdizhi.Text = baoguandan.CustomerAddress;
                    txtlianxidianhua.Text = baoguandan.CustomerTel;
                    txtHAIPHONGPORT.Text = baoguandan.CustomerHAIPHONGPORT;
                    txtFAX.Text = baoguandan.CustomerFax;
                    txtsaleAdd.Text = baoguandan.SaleAddress;
                    gridControl1.DataSource = Connect.DbHelper().Queryable<danjumingxitable>().Where(x => x.danhao == SaleDanhao).ToList();
                    gridControl2.DataSource = Connect.DbHelper().Queryable<JuanHaoTable>().Where(x => x.Danhao == SaleDanhao).ToList();
                }
                else
                {
                    MessageBox.Show("没有找到该报关单的相关信息");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDanju(PrintModel.Privew);
        }

        private void PrintDanju(int privew)
        {
            var checkinfo = Check();
            if(!string.IsNullOrWhiteSpace ( checkinfo))
            {
                MessageBox.Show(checkinfo);
                return;
            }
            var mingxi = gridControl1.DataSource as List<danjumingxitable>;
            var juanhaos = gridControl2.DataSource as List<JuanHaoTable>;
            if (mingxi != null && juanhaos != null)
            {
                new 打印报关单() { juanHaos =juanhaos , mingxis =mingxi , baoguandan =CreateDanju ()}.Print(privew);
            }
            else
            {
                MessageBox.Show("没有可打印的内容");
            }
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                PrintDanju(PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDanju(PrintModel.Print);
        }
        /// <summary>
        /// 打印发货单
        /// </summary>
  
        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                txtkehu.Text =fm.linkman.FullName ;
            }
        }
        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void cmbFahuogongsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbFahuogongsi.Text))
            {
                var company = infoService.GetOneinfo(x => x.GHSMC == cmbFahuogongsi.Text);
                txtsaleAdd.Text = company.Address;
                txtsaletel.Text = company.GHSMC;
            }
        }

        private void 选择发货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 销售单选择();
            fm.ShowDialog();
            if (fm.pingzhong != null)
            {
                this.SaleDanhao = fm.pingzhong.danhao;
                Init();
            }
        }
    }
}
