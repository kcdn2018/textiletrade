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

namespace 纺织贸易管理系统.其他窗体
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class 调整金额 : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public LXR linkman { get; set; } = new LXR();
        public 调整金额()
        {
            InitializeComponent();
        }

        private void 调整金额_Load(object sender, EventArgs e)
        {
            if(linkman.LX =="供货商")
            {
                label3.Text = "应付款";
                label4.Text = "应收票";
                txtfapiao.Text = linkman.YingShouFapiao.ToString ();
                txtbianhao.Text = linkman.BH;
                txtmingcheng.Text = linkman.MC;
                txtjine.Text = linkman.JE.ToString ();
            }
            else
            {
                txtbianhao.Text = linkman.BH;
                txtmingcheng.Text = linkman.MC;
                txtjine.Text = linkman.JE.ToString();
                txtfapiao.Text = linkman.YingKaifapiao.ToString();
            }
        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            
            if (linkman.LX == "供货商")
            {
                LXRService.UpdateLXR(x =>x.YingShouFapiao ==txtfapiao.Text .TryToDecmial (0),y=>y.BH ==linkman.BH );
            }
            else
            {
                LXRService.UpdateLXR(x =>  x.YingKaifapiao  == txtfapiao.Text.TryToDecmial(0), y => y.BH == linkman.BH);
            }
            this.Close();
        }
    }
}
