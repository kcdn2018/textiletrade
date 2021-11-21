using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 寄件登记 : Form
    {
        /// <summary>
        /// 单据用途
        /// </summary>
        public int useful { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string danhao { get; set; }
        public 寄件登记()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            cmbwuliugongshi.DataSource = WuliuTableService.GetWuliuTablelst(x => x.Bianhao.Contains(""));
            cmbwuliugongshi.DisplayMember = "name";
            cmbjsr.DataSource = YuanGongTableService.GetYuanGongTablelst(x => x.Bianhao.Contains(""));
            cmbjsr.DisplayMember = "Xingming";
            cmbywy.DataSource = YuanGongTableService.GetYuanGongTablelst(x => x.Bianhao.Contains(""));
            cmbywy.DisplayMember = "Xingming";
            cmbquyu.DataSource = DanjuTableService.GetDanjuTablelst(x => x.djlx == DanjuLeiXing.物流登记).Select (x=>x.StockName ).Distinct ().ToList ();
            cmbquyu.DisplayMember = "StockName";
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = "", MC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            txtshdz.Text = fm.linkman.dz;
        }

        private void 寄件登记_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit  ();
            }
        }
        private void Init()
        {
            txtdanhao.Text = "";         
            txtksmc.Text ="";
            txtshdz.Text = "";
            dateEdit2.DateTime = DateTime.Now ;
            txtheji.Text = "0.00";
            txtgjs.Text = "0.0";
            txtjianshu.Text ="0.0";
            txtmishu.Text ="0.0";
            txtwuliudanjia.Text ="0.00";
            txtpingjun.Text = "0.00";
            cmbquyu.Text = "";
            useful = FormUseful.新增;
        }
        private void Edit()
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            txtdanhao.Text = danju.dh;
            cmbjsr.Text = danju.own;
            cmbwuliugongshi.Text = danju.wuliugongsi;
            txtksmc.Text = danju.ksmc;
            txtshdz.Text = danju.shouhuodizhi;
            dateEdit2.DateTime = danju.rq;
            txtheji.Text = danju.je.ToString ();
            cmbfangshi.Text = danju.ShoukuanFangshi;
            txtgjs.Text = danju.totaljuanshu.ToString();
            txtjianshu.Text = danju.totalweishuimoney.ToString();
            txtmishu.Text = danju.TotalMishu.ToString();
            txtwuliudanjia.Text = danju.toupijuanshu.ToString ();
            txtpingjun.Text = danju.toupimishu.ToString();
            cmbquyu.Text = danju.StockName;
            cmbywy.Text = danju.SaleMan;
        }
        private DanjuTable Initdanju()
        {
            DanjuTable danju = new DanjuTable
            {
                dh = txtdanhao.Text,
                own = cmbjsr.Text,
                wuliugongsi = cmbwuliugongshi.Text,
                ksmc = txtksmc.Text,
                shouhuodizhi = txtshdz.Text,
                rq = dateEdit2.DateTime.Date,
                je = txtheji.Text.ToDecimal(0),
                ShoukuanFangshi=cmbfangshi.Text,
                totaljuanshu=txtgjs.Text.ToDecimal(0),
                totalweishuimoney=txtjianshu.Text.ToDecimal (0),
                TotalMishu=txtmishu.Text .ToDecimal (0),
                toupijuanshu=txtwuliudanjia.Text .ToDecimal (0),
                toupimishu=txtpingjun.Text .ToDecimal(0),
                StockName=cmbquyu .Text ,
                SaleMan=cmbywy.Text ,
                djlx=DanjuLeiXing.物流登记 
            };
            return danju;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(useful==FormUseful.新增 )
            {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == txtdanhao.Text);
                danju.own = User.user.YHBH;
                if (danju.dh == string.Empty)
                {
                    DanjuTableService.InsertDanjuTable(Initdanju());
                    Init();
                }
                else
                {
                    AlterDlg.Show("该单号已经存在！请检查单号输入是否正确");
                }
            }
            else
            {
                DanjuTableService.UpdateDanjuTable(Initdanju(), x => x.dh == danhao);
                Init();
            }
        }

        private void txtheji_EditValueChanged(object sender, EventArgs e)
        {
            if (txtgjs.EditValue.TryToDecmial(0) != 0)
            {
                txtwuliudanjia.Text = Math.Round (txtheji.EditValue.TryToDecmial(0) / txtgjs.EditValue.TryToDecmial(0),2).ToString();
            }
            if (txtmishu.EditValue.TryToDecmial(0) != 0)
            {
                txtpingjun.Text =Math.Round  (txtheji.EditValue.TryToDecmial(0) / txtmishu.EditValue.TryToDecmial(0),2).ToString();
            }
        }
    }
}
