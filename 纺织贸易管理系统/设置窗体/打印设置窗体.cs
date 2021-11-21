using DAL;
using FastReport;
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
    public partial class 打印设置窗体 : Form
    {
        public string printer { get; set; }
        public decimal copyies { get; set; }
        public PrintSetting  printerSettings { get; set; } = new PrintSetting ();
        public 打印设置窗体()
        {
            InitializeComponent();
            GetAllPrinter();
            printer = cmbprinters.Text;
            copyies = txtNum.Value;
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
                        if (ishavePrinter==false )
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
                MessageBox.Show("没有找到任何打印机！",this.Name ,MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            printer = cmbprinters.Text;
            copyies = txtNum.Value;
            printerSettings.PrintName  = cmbprinters.Text;
            printerSettings.PrintNum  =(short ) txtNum.Value;
            printerSettings.Printmodel = PrintModel.Print;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
