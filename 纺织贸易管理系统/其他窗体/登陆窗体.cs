using BLL;
using DAL;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using Microsoft.VisualBasic;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.其他窗体
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class 登陆窗体 : UIForm 
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public 登陆窗体()
        {
            StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(DevComponents.DotNetBar.ColorScheme.GetColor("0E6D38"), DevComponents.DotNetBar.ColorScheme.GetColor("0E6D38"));
            InitializeComponent();
            ComboBoxX1.SelectedIndex = 0;
            var set = SettingService.GetSetting(new Model.Setting() { formname = this.Name, settingname = "记住用户名和密码", settingValue = checkBoxX1.Checked.ToString() });
            if(set.settingValue =="True")
            {
                checkBoxX1.Checked = true;
                txtUser.Text = SettingService.GetSetting(new Model.Setting() { formname = this.Name, settingname = "用户名", settingValue = checkBoxX1.Checked.ToString() }).settingValue  ;
                txtpwd.Text = SettingService.GetSetting(new Model.Setting() { formname = this.Name, settingname = "密码", settingValue = checkBoxX1.Checked.ToString() }).settingValue;
            }
            else
            {
                checkBoxX1.Checked = false;
            }
            Connect.Environmen = ComboBoxX1.Text == "公司局域网" ? "公司" : "云端";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text=="")
            {
                MessageBox.Show("请填写用户名！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtpwd.Text=="")
                {
                    MessageBox.Show("请填写密码！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            ///开始登录
            try
            {
                var yonghu = YhbService.GetOneYhb(x => x.YHBH == txtUser.Text && x.MM == txtpwd.Text);
                if (yonghu.YHMC != string.Empty)
                {
                    User.user = yonghu;
                    AccessBLL.userid = yonghu.YHBH;
                    MainForm.mainform = new Main();
                    MainForm.mainform.Show();
                    Save();                  
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误！请填写正确", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
            if(MessageBox.Show("连接到数据库发生错误！请检查网络连接，数据库名称，IP地址，用户名，密码，网络环境，重新选择环境请按确定。重新设置请安取消", "错误"+ex.Message , MessageBoxButtons.OKCancel , MessageBoxIcon.Error)==DialogResult.OK )
                {
                    return;
                }
                Process.Start(Application.StartupPath + "\\Config.exe");
                Process.GetCurrentProcess().Kill();
                Application.ExitThread();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fabricsa.com");
        }

        private void 登陆窗体_Load(object sender, EventArgs e)
        {
            Thread td = new Thread(CheckUpdate);
            td.Start();
        }
        private void CheckUpdate()
        {
            var check = new Update().CheckUpdate();
            if (check == true)
            {              
                if (MessageBox.Show("有新的更新！启用更新将会关闭程序。请做好保存", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + "\\Updater.exe");
                    Process cur = Process.GetCurrentProcess();
                    KillProcess(cur.ProcessName);
                    Process.GetCurrentProcess().Kill();
                    Application.ExitThread();
                }
            }
        }
        public static void KillProcess(string strProcessesByName)//关闭线程
        {
            foreach (Process p in Process.GetProcesses())//GetProcessesByName(strProcessesByName))
            {
                if (p.ProcessName.ToUpper().Contains(strProcessesByName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Win32Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());   // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.Message.ToString()); // process has already exited - might be able to let this one go
                    }
                }
            }
        }
            private void 登陆窗体_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            Process.GetCurrentProcess().Kill();
            Application.ExitThread();
        }
        private void Save()
        {
            SettingService.Update(new Model.Setting() { formname = this.Name, settingname = "记住用户名和密码", settingValue = checkBoxX1.Checked.ToString() });
            if (checkBoxX1.Checked)
            {
                SettingService.Update(new Model.Setting() { formname = this.Name, settingname = "用户名", settingValue = txtUser.Text });
                SettingService.Update(new Model.Setting() { formname = this.Name, settingname = "密码", settingValue = txtpwd.Text });
            }
        }

     

        private void uiCheckBox1_ValueChanged(object sender, bool value)
        {
            Connect.Environmen = ComboBoxX1.Text == "公司局域网" ? "公司" : "云端";
        }

        private void ComboBoxX1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connect.Environmen = ComboBoxX1.Text == "公司局域网" ? "公司" : "云端";
        }
    }
}
