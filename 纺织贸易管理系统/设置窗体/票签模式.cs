using DAL;
using Model;
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

namespace 纺织贸易管理系统.设置窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 票签模式 : Sunny.UI.UIForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public 票签模式()
        {
            InitializeComponent();
            cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
            cmbMoban.Text = Connect.GetDefault()[0].LabelName;
            GetAllPrinter();
            this.TopMost = true;
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
                var setprinter = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "标签默认打印机", settingValue = cmbprinters.Text }).settingValue;
                bool ishavePrinter = false;
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    string tmp = PrinterSettings.InstalledPrinters[i];
                    if (setprinter == tmp)
                    {
                        if (ishavePrinter == false)
                        { ishavePrinter = true; }
                    }
                    cmbprinters.Items.Add(tmp);
                }

                if (ishavePrinter == false)
                {
                    cmbprinters.Text = defaultPrinter;
                }
                else
                { cmbprinters.Text = setprinter; }
                #endregion
            }
            catch
            {
                MessageBox.Show("没有找到任何打印机！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbMoban_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBianhao.Focus();
        }

        private void txtBianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var printset = new PrintSetting();
                printset.Path = PrintPath.标签模板 + cmbMoban.Text;
                printset.Printmodel = PrintModel.Print;
                printset.PrintName = cmbprinters.Text;
                printset.PrintNum = 1;
                var pingzhong = dbService.GetOnedb(x => x.bh == txtBianhao.Text);
                if (!string.IsNullOrWhiteSpace(pingzhong.bh))
                {
                    PrintService print = new PrintService(Tools.打印标签.打印);
                        print (0, pingzhong, printset, ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == pingzhong.bh), new JiYangBaoJia());
                }
                txtBianhao.Text = "";
                this.Activate();
            }           
        }
        private delegate void PrintService(decimal Num, db pingzhong, PrintSetting printSetting, List<ShengChengGongYi> shengChengGongYis, JiYangBaoJia jiYangBaoJia);
        private void cmbprinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBianhao.Focus();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var printset = new PrintSetting();
            printset.Path = PrintPath.标签模板 + cmbMoban.Text;
            printset.Printmodel = PrintModel.Print;
            printset.PrintName = cmbprinters.Text;
            printset.PrintNum = 1;
            var pingzhong = dbService.GetOnedb(x => x.bh == txtBianhao.Text);
            if (!string.IsNullOrWhiteSpace(pingzhong.bh))
            {
                PrintService print = new PrintService(Tools.打印标签.打印);
                print(0, pingzhong, printset, ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == pingzhong.bh), new JiYangBaoJia());
            }
            txtBianhao.Text = "";
            this.Activate();
        }
    }
}
