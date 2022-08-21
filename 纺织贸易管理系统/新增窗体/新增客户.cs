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
using Tools;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 新增客户 : Sunny.UI.UIForm
    {
        public LXR LinkMan = new LXR();
        public int Useful=FormUseful.新增 ;
        public 新增客户()
        {
            InitializeComponent();
            cmbMaitou.DataSource = Tools.获取模板.获取所有模板 (PrintPath.唛头模板);
            var yonghulist = YuanGongTableService .GetYuanGongTablelst();
            foreach (var yonghu in yonghulist )
            {
                cmbOwn.Items.Add( yonghu.Xingming );
            }
        }


        private void InitText()
        {        
                foreach (Control  c in this.Controls )
                {
                    if(c is DevComponents.DotNetBar.Controls .TextBoxX )
                    {
                        c.Text = "";
                    }
                }    
                LinkMan.BH  = BianhaoBLL.CreatBianhao("KH");
                LinkMan.LX  = "客户";
                LinkMan.sxed  = 0;
                LinkMan.fp  = 0;
                LinkMan.JE = 0;
                txtBianhao.Text = LinkMan.BH;
                txtqichu.Text = "0";
                txtyingkaifapiao.Text = "0";
                txtzhangqi.Text = "120";
                txtedu.Text = "100000";
                txtusd.Text = "0.00";
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
            txtzhangqi.Text = LinkMan.ZhangQi.ToString();
            txtweixing.Text = LinkMan.WX;
            txtpingyingma.Text = LinkMan.ZJC;
            txtqichu.Text = LinkMan.JE.ToString();
            txtshuihao.Text = LinkMan.Shuihao;
            txtyinghangzhanghao.Text = LinkMan.Yinghangzhanghao;
            txtkaihuyinghang.Text = LinkMan.Kaihuyinghang;
            txtpingming.Text = LinkMan.MC;
            txtedu.Text = LinkMan.sxed.ToString();
            txtusd.Text = LinkMan.USD.ToString();
            cmbOwn.Text = LinkMan.own;
            cmbMaitou.Text= MaitouService.GetOneMaitou(x=>x.khbh==LinkMan.BH ).path ;
            txtusd.Text= LinkMan.USD.ToString ("F2");
            txtFAX.Text=LinkMan.FAX  ;
             txtTexCode.Text=LinkMan.TexCode ;
             txtHAIPHONGPORT.Text=LinkMan.HAIPHONGPORT ;
            txtZIPCODE.Text=LinkMan.ZIPCODE  ;
             txtFullName.Text=LinkMan.FullName ;
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
            LinkMan.own = cmbOwn.Text;
            LinkMan.YX = txtyouxiang.Text;
            LinkMan.QQ = txtqq.Text;
            LinkMan.ZhangQi = txtzhangqi.Text.ToInt ();
            LinkMan.WX = txtweixing.Text;
            LinkMan.ZJC = txtpingyingma.Text;
            LinkMan.JE = txtqichu.Text.ToDecimal (0);
            LinkMan.Shuihao = txtshuihao.Text;
            LinkMan.Yinghangzhanghao = txtyinghangzhanghao.Text;
            LinkMan.Kaihuyinghang = txtkaihuyinghang.Text;
            LinkMan.MC  = txtpingming.Text;
            LinkMan.sxed = txtedu.Text.ToDecimal(0);
            LinkMan.USD = txtusd.Text.TryToDecmial();
            LinkMan.FAX = txtFAX.Text;
            LinkMan.TexCode = txtTexCode.Text;
            LinkMan.HAIPHONGPORT = txtHAIPHONGPORT.Text;
            LinkMan.ZIPCODE = txtZIPCODE.Text;
            LinkMan.FullName = txtFullName.Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace ( txtpingming.Text ))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入客户名称！客户名称不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbOwn .Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择该客户归属的业务员！归属业务员不能为空");
                return;
            }
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
                if (!string.IsNullOrWhiteSpace(LXRService.GetOneLXR(x => x.MC == txtpingming.Text&&x.LX  =="客户").MC))
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该客户名称已经存在！保存失败");
                    return;
                }
                LXRService .InsertLXR (LinkMan);
                MaitouService.InsertMaitou(new Maitou() { khbh = LinkMan.BH, path = cmbMaitou.Text, own = User.user.YHBH });
            }
            else
            {
                LXRService.UpdateLXR(LinkMan, y => y.BH == LinkMan.BH);
                //LXRService.UpdateLXR(LinkMan, x => x.BH == LinkMan.BH);
                MaitouService.UpdateMaitou(new Maitou() { khbh = LinkMan.BH, path = cmbMaitou.Text, own = User.user.YHBH }, x => x.khbh == LinkMan.BH);
            }
            LinkMan = new LXR() { LX="客户"};
            Useful = FormUseful.新增;
            InitText();
        }

        private void txtpingming_TextChanged(object sender, EventArgs e)
        {
          txtpingyingma.Text =  Tools.GetPy.GetPingYingFirstLetter (txtpingming.Text);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new InpuBox() { Label = "请输入你要新建的模板名称", 内容 = "" ,filePath= PrintPath.唛头模板 };
            fm.ShowDialog();
            if (fm.内容 != "")
            {
                Tools.获取模板.新增模板(PrintPath.唛头模板 , fm.内容, fm.参考模板,ReportService.唛头 );
                cmbMaitou.DataSource = Tools.获取模板.获取所有模板(PrintPath.唛头模板);
            }
        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new 打印设置窗体();
            //fm.ShowDialog();
            new Tools.打印唛头() { copyies = f.copyies, PrinterName = f.printer, userful = PrintModel.Design, moban = PrintPath.唛头模板 + cmbMaitou .Text, juan = new JuanHaoTable() }.打印();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var l = MaitouService.GetMaitoulst(x => x.path == cmbMaitou.Text);
            if(l.Count>0)
            {
                MessageBox.Show("该唛头已经关联到一些客户。请先解绑！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Tools.获取模板.删除模板(PrintPath.唛头模板+cmbMaitou.Text );
            cmbMaitou.DataSource = Tools.获取模板.获取所有模板(PrintPath.唛头模板);
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string newname = string.Empty;
                Sunny.UI.UIInputDialog.InputStringDialog(ref newname, true, "请输入新的模板名称");
                string oldname = cmbMaitou.Text;
                ReportService.ReName(new ReportTable()
                {
                    ReportFile = ReportTableService.GetOneReportTable(x => x.reportName == oldname && x.reportStyle == Tools.ReportService.唛头).ReportFile
                    ,
                    reportName = newname += ".frx",
                    reportStyle = Tools.ReportService.唛头
                }, Application.StartupPath, oldname);
                cmbMaitou.DataSource = Tools.获取模板.获取所有模板(PrintPath.唛头模板);
                MaitouService.UpdateMaitou(x => x.path == newname, x => x.path == oldname);
                cmbMaitou.Text = newname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
