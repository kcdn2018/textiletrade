using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.其他窗体;

namespace 纺织贸易管理系统
{
    static class Program
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
       
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            FastReport.Utils.Res.LoadLocale(Application.StartupPath + "\\Chinese (Simplified).frl");
            (new FastReport.EnvironmentSettings()).ReportSettings.ShowProgress = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 登陆窗体());
            ////Application.Run(MainForm.mainform = new Main());
            //Application.Run(new 寄件登记 ());
        }
    }
}
