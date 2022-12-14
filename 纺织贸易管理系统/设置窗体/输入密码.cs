using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 输入密码 : Form
    {
        public 输入密码()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
            var pswlist = versionService.Getversionlst().OrderBy (x=>x.ID ).ToList ();
            if(txtfirst.Text ==pswlist[0].Version && txtsecond.Text==pswlist[1].Version )
            {
                if (Sunny.UI.UIMessageDialog.ShowAskDialog(this, "重新建账将会清空所有的信息!\r\n应收和应付信息\r\n所有的库存信息\r\n所有订单的订单信息\r\n所有的单据信息\r\n请再次确认"))
                {
                    重新建账.Clear();
                    MessageBox.Show("重新建账成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("两个密码其中一个或者两个都不对！请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
