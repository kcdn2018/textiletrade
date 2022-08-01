using DAL;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 公司信息 : Form
    {
        public 公司信息()
        {
            InitializeComponent();
            cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
            var gsinfo = infoService.Getinfolst()[0];
            cmbgongshimingcheng .DataSource = infoService.Getinfolst().Select (x=>x.gsmc ).ToList ();
            txtlxdh.Text = gsinfo.GHSMC;
            txtVer.Text = gsinfo.Version;
            comboBoxEx1.Text = gsinfo.cost;
            txtaddress.Text = gsinfo.Address;
            txtbankname.Text = gsinfo.BankName;
            txtBankNum.Text = gsinfo.BankNum;
            txtEmail.Text = gsinfo.Email;
            txttaxNum.Text = gsinfo.TaxNum;
            cmbbianhao.Text = SettingService.GetSetting (new Model.Setting() { formname = "", settingname = "编号规则", settingValue = cmbcaigou.Text }).settingValue ;
            cmbcaigou.Text = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "采购显示订单明细", settingValue = cmbcaigou.Text }).settingValue ;
            cmbxianshi .Text = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = cmbcaigou.Text }).settingValue ;
            numericUpDown1.Value = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "时间间隔", settingValue =numericUpDown1.Value.ToString() }).settingValue.ToInt  (0);
            cmbAutoPrice.Text = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "寄样自动价格", settingValue = cmbAutoPrice.Text }).settingValue ;
            cmbyangbubiaohao.Text = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "样布编号", settingValue = cmbyangbubiaohao .Text }).settingValue;
          ///设定默认票签模板
            if (string.IsNullOrWhiteSpace(QueryTime.DefaultLabel))
            {
                if (cmbMoban.Items.Count > 0)
                {
                    cmbMoban.SelectedIndex = 0;
                }
            }
            else
            {
                cmbMoban.Text = QueryTime.DefaultLabel;
            }
            GetAllPrinter();
            cmbprinters.Text = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "标签默认打印机", settingValue = cmbprinters .Text }).settingValue;
            var zhangqi= SettingService.GetSetting(x => x.settingname == "检查账期").settingValue;
            cmbzhangqi.Text = string.IsNullOrWhiteSpace(zhangqi) ? "不检查账期" : zhangqi;
            numericUpDown2.Value = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "数量小数位", settingValue = numericUpDown1.Value.ToString() }).settingValue.ToDecimal(0);
            NumSuoLv.Value = QueryTime.Suolv;
            cmbBuyStyle.Text = QueryTime.IsBuyStyle;
            cmbFabricStyle.Text = QueryTime.IsFabricStyle;
            cmbIsTax.Text = QueryTime.IsTax;
            cmbdanjubianhao.Text = QueryTime.DanjubianhaoRule;
            cmbNeedSaleMan.Text = QueryTime.IsNeedSaleMan;
            taxNumInput.Value = QueryTime.Tax;
        }
        private void GetAllPrinter()
        {
            try
            {
                #region 获取默认打印机的方法
                PrintDocument fPrintDocument = new PrintDocument();
                string defaultPrinter = fPrintDocument.PrinterSettings.PrinterName;
                #endregion
                #region 获取打印机列表并添加到Listbox
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    string tmp = PrinterSettings.InstalledPrinters[i];
                    cmbprinters.Items.Add(tmp);
                }
                cmbprinters.Text = defaultPrinter;
                #endregion
            }
            catch
            {
                MessageBox.Show("没有找到任何打印机！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbcaigou.Text != string.Empty && cmbxianshi.Text != string.Empty && cmbbianhao.Text != string.Empty)
            {            
                SettingService.Update(new Model.Setting() { formname = "", settingname = "订单显示样式", settingValue = cmbxianshi.Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "采购显示订单明细", settingValue = cmbcaigou.Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "编号规则", settingValue = cmbbianhao .Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "时间间隔", settingValue = numericUpDown1 .Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "寄样自动价格", settingValue = cmbAutoPrice .Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "样布编号", settingValue = cmbyangbubiaohao.Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "标签默认打印机", settingValue = cmbprinters .Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "数量小数位", settingValue = numericUpDown2 .Text });
                SettingService.Update(new Model.Setting() { formname = "", settingname = "默认标签", settingValue = cmbMoban.Text });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "检查账期", settingValue = cmbzhangqi.Text });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "默认含税", settingValue = cmbIsTax .Text });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "采购类型", settingValue = cmbBuyStyle .Text });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "产品类型", settingValue = cmbFabricStyle .Text });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "报警缩率", settingValue = NumSuoLv.Value.ToString()  });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "税率", settingValue = taxNumInput .Value.ToString() });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "单据编号规则", settingValue =cmbdanjubianhao.Text  });
                SettingService.UpdateSQLSERVER(new Model.Setting() { formname = "", settingname = "业务员必填", settingValue = cmbNeedSaleMan .Text });
                QueryTime.间隔 =(int) numericUpDown1.Value;
                QueryTime.Digit = (int)numericUpDown2.Value;
                QueryTime.IsTax = cmbIsTax.Text;
                QueryTime.IsFabricStyle = cmbFabricStyle.Text;
                QueryTime.IsBuyStyle = cmbBuyStyle.Text;
                QueryTime.Suolv =(int) NumSuoLv.Value;
                QueryTime.DanjubianhaoRule = cmbdanjubianhao.Text;
                QueryTime.IsNeedSaleMan = cmbNeedSaleMan.Text;
                QueryTime.Tax = taxNumInput.Value;
                QueryTime.DefaultLabel = cmbMoban.Text;
                AlterDlg.Show("保存完毕");
            }
            else
            {
                MessageBox.Show("保存失败！设置信息有没选择！");
            }
        }
     
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var fm = new 新增公司() { UseFul=FormUseful.新增 };
            fm.ShowDialog();
            var gsinfo = infoService.Getinfolst()[0];
            cmbgongshimingcheng.DataSource = infoService.Getinfolst().Select(x => x.gsmc).ToList();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            var fm = new 新增公司() { UseFul=FormUseful.修改 ,oldinfo =infoService.GetOneinfo (x=>x.gsmc == cmbgongshimingcheng.Text )};        
            fm.ShowDialog();
            var gsinfo = infoService.Getinfolst()[0];
            cmbgongshimingcheng.DataSource = infoService.Getinfolst().Select(x => x.gsmc).ToList();
        }

        private void cmbgongshimingcheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gsinfo = infoService.GetOneinfo(x=>x.gsmc ==cmbgongshimingcheng.Text );
            txtlxdh.Text = gsinfo.GHSMC;
            txtVer.Text = gsinfo.Version;
            comboBoxEx1.Text = gsinfo.cost;
            txtaddress.Text = gsinfo.Address;
            txtbankname.Text = gsinfo.BankName;
            txtBankNum.Text = gsinfo.BankNum;
            txtEmail.Text = gsinfo.Email;
            txttaxNum.Text = gsinfo.TaxNum;
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            string shenhe = checkBoxX1.Checked ? "审核制" : "无需审核";
            infoService.Updateinfo($"update info set own='{shenhe}'");
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (Sunny.UI .UIMessageBox.ShowAsk ("您确定要删除"+cmbgongshimingcheng.Text+"这个公司的全部信息吗？"))
            {
                if (infoService.Getinfolst().Count > 1)
                {
                    infoService.Deleteinfo(x => x.gsmc == cmbgongshimingcheng.Text);
                    var gsinfo = infoService.Getinfolst()[0];
                    cmbgongshimingcheng.DataSource = infoService.Getinfolst().Select(x => x.gsmc).ToList();
                    txtlxdh.Text = gsinfo.GHSMC;
                    txtVer.Text = gsinfo.Version;
                    comboBoxEx1.Text = gsinfo.cost;
                    txtaddress.Text = gsinfo.Address;
                    txtbankname.Text = gsinfo.BankName;
                    txtBankNum.Text = gsinfo.BankNum;
                    txtEmail.Text = gsinfo.Email;
                    txttaxNum.Text = gsinfo.TaxNum;
                }
                else
                {
                    Sunny.UI.UIMessageBox.ShowError("删除失败！只有一个公司信息！\r\n不能删除!");
                }
            }
        }

        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => { UpdateService.IsNeedUpdate(this); }));
        }

        private void 刷新打印模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sunny.UI.UIWaitFormService.ShowWaitForm("系统正在刷新所有打印模板，请等候。。。。");
                Tools.ReportService.DownLoad(Application.StartupPath);
                Sunny.UI.UIWaitFormService.HideWaitForm();
                MessageBox.Show("刷新完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
