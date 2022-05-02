using BLL;
using Model;
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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 账户转账 : Sunny.UI.UIForm 
    {
        public 账户转账()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            var skfs = Connect.DbHelper().Queryable<SKFS>().ToList ();
            foreach (var s in skfs)
            {
                cmb_zhuanchu.Items.Add(s.BH + "/" + s.Skfs);
            }
            cmb_zhuanru.Items.AddRange ( cmb_zhuanchu.Items);
            txt_Danhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.账户转账单, uiDatePicker1.Value, DanjuLeiXing.账户转账单);
            cmb_style.SelectedIndex = 0;
           if( RateModel.CurrentRate != 0)
            {
                txtRax.Text = RateModel.CurrentRate.ToString ("N2");
            }
        }
        private void txt_zhuanchu_TextChanged(object sender, EventArgs e)
        {
            转换();
        }
        private void 转换()
        {
            if (cmb_style.SelectedIndex ==1)
            {
                txt_zhuanru.Text = (txt_zhuanchu.Text.TryToDecmial() * txtRax.Text.TryToDecmial()).ToString();
            }
            else
            {
                if (cmb_style.SelectedIndex == 2)
                {
                    if (txtRax.Text.TryToDecmial() != 0)
                    { txt_zhuanru.Text = (txt_zhuanchu.Text.TryToDecmial() / txtRax.Text.TryToDecmial()).ToString(); }
                }
                else
                {
                    txt_zhuanru.Text = txt_zhuanchu.Text;
                }
            }
        }

        private void txtRax_TextChanged(object sender, EventArgs e)
        {
            转换();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmb_zhuanchu.Text) && !string.IsNullOrEmpty(cmb_zhuanru.Text))
            {
                var zc = cmb_zhuanchu.Text.Split('/')[0];
                var zr = cmb_zhuanru .Text.Split('/')[0];
                var zhuanchu = Connect.DbHelper().Queryable<SKFS>().First(x => x.BH == zc);
                var zhuanru = Connect.DbHelper().Queryable<SKFS>().First(x => x.BH == zr);
                zhuanchu.Zhanghuyue -= txt_zhuanchu.Text.TryToDecmial();
                zhuanru.Zhanghuyue += txt_zhuanru.Text.TryToDecmial();
                Connect.DbHelper().Updateable<SKFS>(new SKFS[] { zhuanchu,zhuanru }).ExecuteCommand ();
                SaveDanju();
                this.Close();
                this.Dispose();
            }
            else
            {
                Sunny.UI.UIMessageBox.ShowError("转入转出账户不能为空\r\n必须选择一个");
            }
        }
        private void SaveDanju()
        {
            var danju=new DanjuTable()
            {
                dh =txt_Danhao.Text ,
                rq = uiDatePicker1.Value,
                djlx = DanjuLeiXing.账户转账单,
                ksbh = cmb_zhuanchu.Text.Split('/')[0],
                ksmc = cmb_zhuanchu.Text.Split('/')[1],
                je = txt_zhuanchu.Text.TryToDecmial(),
                ShoukuanFangshi = cmb_zhuanchu.Text.Split('/')[1],
                Qiankuan = "现金",
                yaoqiu = ShouzhiStyle.支出,
                bz = "账户转账转出",
                jiagongleixing = "账户转账转出到账户"+ cmb_zhuanru.Text.Split('/')[1],
                own = User.user.YHMC
            } ;
            DanjuTableService.InsertDanjuTable(danju);
            账户BLL.刷新剩余金额(DanjuTableService.GetOneDanjuTable (x=>x.dh ==txt_Danhao.Text ));
            txt_Danhao.Text= BianhaoBLL.CreatDanhao(FirstLetter.账户转账单, uiDatePicker1.Value, DanjuLeiXing.账户转账单);
            DanjuTableService.InsertDanjuTable(new DanjuTable()
            {
                dh = txt_Danhao.Text ,
                rq = uiDatePicker1.Value,
                djlx = DanjuLeiXing.账户转账单,
                ksbh = cmb_zhuanru .Text.Split('/')[0],
                ksmc = cmb_zhuanru.Text.Split('/')[1],
                je = txt_zhuanru.Text.TryToDecmial(),
                ShoukuanFangshi = cmb_zhuanru.Text.Split('/')[1],
                Qiankuan = "现金",
                yaoqiu = ShouzhiStyle.收入 ,
                bz = "账户转账转入",
                jiagongleixing = cmb_zhuanchu.Text.Split('/')[1]+"账户转账转入",
                own = User.user.YHMC
            });
            账户BLL.刷新剩余金额(DanjuTableService.GetOneDanjuTable (x=>x.dh ==txt_Danhao.Text ));
            if(cmb_style.SelectedIndex==1)
            {
                var fm = new 销售单明细选择() { Rate =txtRax.Text .TryToDecmial ()};
                fm.ShowDialog ();
            }
        }

        private void cmb_style_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRax.Enabled = cmb_style.SelectedIndex != 0 ? true : false;
            转换();
        }
    }
}
