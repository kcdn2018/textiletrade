using BLL;
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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 付款单 : Sunny.UI.UIForm 
    {
        public int Useful { get; set; } = 1;
        private LXR LinkMan = new LXR ();
        public DanjuTable danju { get; set; } = new DanjuTable() { djlx=DanjuLeiXing.付款单 };
        public 付款单()
        {
            InitializeComponent();
        }

        private void 收款单_Load(object sender, EventArgs e)
        {
            if (Useful==FormUseful.新增 )
            {
                InitDanju ();
            }
            else
            {
                Edit();
            }
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtjine.Text  = danju.je.ToString ();
            txtkehu.Text = danju.ksmc;
            txtyuanying.Text = danju.yaoqiu;
            LinkMan.BH = danju.ksbh;
            txtzhanghu.Text = danju.ShoukuanFangshi;
            dateEdit1.DateTime = danju.rq.Date;
            txtyouhui.Text = danju.totalmoney.ToString ();
        }
        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 供货商选择() { linkman=new LXR() { ZJC="",MC="" } };
            fm.ShowDialog();
            LinkMan = fm.linkman;
            txtkehu.Text = LinkMan.MC;
        }

        private void txtzhanghu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 收款方式();
            fm.ShowDialog();
            txtzhanghu.Text = fm.skfs.Skfs ;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danju.dh = txtdanhao.Text;
            danju.rq = dateEdit1.DateTime ;
            danju.ksbh = LinkMan.BH;
            danju.ksmc = LinkMan.MC;
            danju.remarker = txtbeizhu.Text;
            danju.totalmoney = txtyouhui .Text.TryToDecmial(0);
            danju.je = txtjine.Text.TryToDecmial(0);
            danju.yaoqiu = txtyuanying.Text;
            danju.ShoukuanFangshi = txtzhanghu.Text;
            danju.djlx = DanjuLeiXing.付款单;
            danju.Qiankuan = "欠款";
            danju.own = User.user.YHBH;
            if (Useful==FormUseful.新增 )
            {
                付款单BLL.保存(danju);
            }
            else
            {
                付款单BLL.修改 (danju);
            }
            Useful = FormUseful.新增;
            InitDanju ();
            AlterDlg.Show("保存成功！");
         
        }
        private void InitDanju()
        { 
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.付款单 ,dateEdit1.DateTime,DanjuLeiXing.付款单  );
            txtjine.Text = "0.00";
            txtyuanying.Text = "";
            txtkehu.Text = "";
            txtbeizhu.Text = "";           
            txtzhanghu.Text = "";
            txtyouhui.Text = "0.00";
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.付款单 , dateEdit1.DateTime, DanjuLeiXing.付款单);
            }
        }
    }
}
