using BLL;
using DevComponents.DotNetBar.Controls;
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

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 新增收款方式 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public SKFS  shoukuanfangshi { get; set; }
        public int useful { get; set; }
        public 新增收款方式()
        {
            InitializeComponent();
        }

        private void 新增收款方式_Load(object sender, EventArgs e)
        {
            if(useful==FormUseful.新增 )
            {
                Init();
            }
            else
            {
                txtBianhao.Text = shoukuanfangshi.BH;
                txtBianhao.ReadOnly = true;
                txtkaihuren.Text = shoukuanfangshi.Kaihuren;
                txtkaihuyinghang.Text = shoukuanfangshi.Kaihuyinghang;
                txtpingming.Text = shoukuanfangshi.Skfs;
                txtzhanghao.Text = shoukuanfangshi.Yinghangzhanghao;
                txtzhanghuyue.Text = shoukuanfangshi.Zhanghuyue.ToString ();
                txtzjc.Text = shoukuanfangshi.ZJC;
            }
        }
        private void CreatNew()
        {
            txtBianhao.Text = BianhaoBLL.CreatShouKuangFangshiBianhao();
            txtkaihuren.Text = "";
            txtkaihuyinghang.Text = "";
            txtpingming.Text = "";
            txtzhanghao.Text = "";
            txtzhanghuyue.Text = "0.00";
            txtzjc.Text = "";
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpingming.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入收款方式名称！收款方式名称不能为空");
                return;
            }
            if (useful==FormUseful.新增 )
            {
                if (!string.IsNullOrWhiteSpace(SKFSService.GetOneSKFS(x => x.Skfs  == txtpingming.Text).Skfs))
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该收款方式名称已经存在！保存失败");
                    return;
                }
                SKFSService.InsertSKFS(new SKFS()
                {
                    BH = txtBianhao.Text,
                    Kaihuren = txtkaihuren.Text,
                    Kaihuyinghang = txtkaihuyinghang.Text,
                    Skfs = txtpingming.Text,
                    Yinghangzhanghao = txtzhanghao.Text,
                    Zhanghuyue = txtzhanghuyue.Text.ToDecimal(0),
                    ZJC = txtzjc.Text,
                    own =User.user.YHBH 
                }) ;
            }
            else
            {
                SKFSService.UpdateSKFS (new SKFS()
                {
                    BH = txtBianhao.Text,
                    Kaihuren = txtkaihuren.Text,
                    Kaihuyinghang = txtkaihuyinghang.Text,
                    Skfs = txtpingming.Text,
                    Yinghangzhanghao = txtzhanghao.Text,
                    Zhanghuyue = txtzhanghuyue.Text.ToDecimal(0),
                    ZJC = txtzjc.Text,
                    own = User.user.YHBH
                },x=>x.BH==txtBianhao.Text );
            }
            Init();
        }

        private void txtpingming_TextChanged(object sender, EventArgs e)
        {
            txtzjc.Text = Tools.GetPy.GetPingYingFirstLetter(txtpingming.Text);
        }
    }
}
