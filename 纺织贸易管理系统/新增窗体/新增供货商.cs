using BLL;
using Model;
using Sunny.UI;
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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 新增供货商 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public LXR LinkMan = new LXR();
        public int Useful=FormUseful.新增 ;
        
        public 新增供货商()
        {
            InitializeComponent();
            cmbleixing.DataSource = Gonhuoshang.类型;
            cmbzhuangtai.DataSource = Gonhuoshang.合作;
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
            LinkMan.BH = BianhaoBLL.CreatBianhao("GHS");
            LinkMan.LX = "供货商";
            LinkMan.sxed = 0;
            LinkMan.fp = 0;
            LinkMan.JE = 0;
            txtBianhao.Text = LinkMan.BH;
            txtqichu.Text = "0";
            txtyingkaifapiao.Text = "0";
            txtFullName.Text = string.Empty;
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
            txtBianhao.Text = LinkMan.BH;
            txtbeizhu.Text = LinkMan.bz;
            txtdizhi.Text = LinkMan.dz;
            txtlianxidianhua.Text = LinkMan.DH;
            txtlianxiren.Text = LinkMan.Lxr;
            txtyingkaifapiao.Text = LinkMan.fp.ToString();
            txtyingkaifapiao.Text = LinkMan.YingKaifapiao.ToString();
            txtyouxiang.Text = LinkMan.YX;
            txtqq.Text = LinkMan.QQ;           
            txtweixing.Text = LinkMan.WX;
            txtpingyingma.Text = LinkMan.ZJC;
            txtqichu.Text =(LinkMan.JE).ToString();
            txtshuihao.Text = LinkMan.Shuihao;
            txtyinghangzhanghao.Text = LinkMan.Yinghangzhanghao;
            txtkaihuyinghang.Text = LinkMan.Kaihuyinghang;
            txtpingming.Text = LinkMan.MC;
            cmbleixing.Text = LinkMan.Leixing;
            cmbzhuangtai.Text = LinkMan.Zhuangtai;
            txtkejiagong.Text = LinkMan.Kezuojiagong;
            txtFullName.Text = LinkMan.FullName;
        }
        private void InitPingzhong()
        {
            LinkMan.BH = txtBianhao.Text;
            LinkMan.bz = txtbeizhu.Text;
            LinkMan.dz = txtdizhi.Text;
            LinkMan.DH = txtlianxidianhua.Text;
            LinkMan.Lxr  = txtlianxiren.Text;
            LinkMan.fp = txtyingkaifapiao.Text.ToDecimal(0);
            LinkMan.YingKaifapiao = txtyingkaifapiao.Text.ToDecimal(0);
            LinkMan.own = User.user.YHBH;
            LinkMan.YX = txtyouxiang.Text;
            LinkMan.QQ = txtqq.Text;          
            LinkMan.WX = txtweixing.Text;
            LinkMan.ZJC = txtpingyingma.Text;
            LinkMan.JE =0- txtqichu.Text.ToDecimal (2);
            LinkMan.Shuihao = txtshuihao.Text;
            LinkMan.Yinghangzhanghao = txtyinghangzhanghao.Text;
            LinkMan.Kaihuyinghang = txtkaihuyinghang.Text;
            LinkMan.MC  = txtpingming.Text;
            LinkMan.Zhuangtai = cmbzhuangtai.Text;
            LinkMan.Leixing = cmbleixing.Text;
            LinkMan.Kezuojiagong = txtkejiagong.Text;
            LinkMan.FullName = txtFullName.Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpingming.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入供货商名称！供货商名称不能为空");
                return;
            }
         
            InitPingzhong();
            if (Useful == FormUseful.新增)
            { 
                if (!string.IsNullOrWhiteSpace(LXRService.GetOneLXR(x => x.MC == txtpingming.Text&&x.LX=="供货商").MC))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该供货商名称已经存在！保存失败");
                return;
            }
                LXRService .InsertLXR (LinkMan);
            }
            else
            {
                LXRService .UpdateLXR (LinkMan, x=>x.BH ==LinkMan.BH );
            }
            LinkMan = new LXR() { LX="供货商"};
            Useful = FormUseful.新增;
            InitText();
        }

        private void txtpingming_TextChanged(object sender, EventArgs e)
        {
            txtpingyingma.Text = Tools.GetPy.GetPingYingFirstLetter(txtpingming.Text);
        }
    }
}
