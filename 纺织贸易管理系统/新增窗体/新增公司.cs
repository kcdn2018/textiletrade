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

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 新增公司 : Sunny.UI.UIEditForm 
    {
        public int UseFul { get; set; }
        public info oldinfo { get; set; }
        public 新增公司()
        {
            InitializeComponent();
        }

        private void 新增公司_ButtonOkClick(object sender, EventArgs e)
        {
            var gsinfo = new info()
            {           
                GHSMC = txtlxdh.Text,
                gsmc = txtgsmc.Text,              
                Address = txtaddress.Text,
                BankName = txtbankname.Text,
                BankNum = txtBankNum.Text,
                Email = txtEmail.Text,
                TaxNum = txttaxNum.Text
            };
           if(UseFul==FormUseful.新增 )
            {
                infoService.Insertinfo(gsinfo);
            }
            else
            {
                infoService.Updateinfo(gsinfo,x=>x.ID==oldinfo.ID );
            }
            this.Close();
        }

        private void 新增公司_Load(object sender, EventArgs e)
        {
            if(UseFul==FormUseful.修改 )
            {
                if(oldinfo!=null)
                {
                    txtaddress.Text = oldinfo.Address;
                    txtbankname.Text = oldinfo.BankName;
                    txtBankNum.Text = oldinfo.BankNum;
                    txtEmail.Text = oldinfo.Email;
                    txtgsmc.Text = oldinfo.gsmc;
                    txtlxdh.Text = oldinfo.GHSMC;
                    txttaxNum.Text = oldinfo.TaxNum;
                }
            }
        }
    }
}
