using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 新增员工 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public YuanGongTable  LinkMan = new YuanGongTable();
        public int Useful=FormUseful.新增 ;
        public 新增员工()
        {
            InitializeComponent();          
        }
        private void InitText()
        {

            foreach (Control c in this.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    c.Text = "";
                }
            }
            LinkMan.Bianhao = BianhaoBLL.CreatYuangongBianhao("YG");
            txtBianhao.Text = LinkMan.Bianhao;
        }

        private void 新增品种_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                InitText();
            }
            else
            {
                EditText();
            }

        }
        private void EditText()
        {
            txtBianhao.Text = LinkMan.Bianhao ;         
            txtlianxidianhua.Text = LinkMan.TelephoneNum;           
            txtbumeng.Text = LinkMan.Department ;         
            txtshenfengzheng.Text = LinkMan.identityCard ;           
            txtyinghangzhanghao.Text = LinkMan.BankCard ;
            txtkaihuyinghang.Text = LinkMan.BankName ;
            txtpingming.Text = LinkMan.Xingming ;
            cmbXingbie .Text = LinkMan.SEX .ToString();           
        }
        private void InitPingzhong()
        {
            LinkMan.Bianhao  = txtBianhao.Text;           
            LinkMan.TelephoneNum = txtlianxidianhua.Text;                   
            LinkMan.Department = txtbumeng.Text;          
            LinkMan.identityCard  = txtshenfengzheng.Text;          
            LinkMan.BankCard  = txtyinghangzhanghao.Text;
            LinkMan.BankName  = txtkaihuyinghang.Text;
            LinkMan.Xingming  = txtpingming.Text;
            LinkMan.SEX = cmbXingbie .Text ;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
                YuanGongTableService .InsertYuanGongTable (LinkMan);
               if( Sunny.UI.UIMessageBox.ShowAsk("是否同时创建一个登陆账户？"))
                {
                    MainForm.mainform.AddMidForm(new 新增用户() { useful = FormUseful.新增,Yonghu =new Yhb() { YHMC =txtpingming.Text } });
                    this.Dispose();
                }
            }
            else
            {
                YuanGongTableService .UpdateYuanGongTable (LinkMan, x=>x.Bianhao  ==LinkMan.Bianhao );               
            }
            LinkMan = new YuanGongTable ();
            Useful = FormUseful.新增;
            InitText();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Dispose ();
        }
    }
}
