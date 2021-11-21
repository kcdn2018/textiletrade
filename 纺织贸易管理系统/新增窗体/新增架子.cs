using BLL;
using DAL;
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
    public partial class 新增架子 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public JiaziTable  zhijiaTable  { get; set; } = new JiaziTable  ();
        public int Useful=FormUseful.新增 ;
        private string zhijiahao ="";
        public 新增架子()
        {
            InitializeComponent();
           
        }
        private void InitText()
        {
            txtBianhao.Text = BianhaoBLL.CreatJiaziBianhao  ();
            txtcunfang.Text = "自己公司";
            txtguishuo.Text = "自己公司";
        }

        private void 新增品种_Load(object sender, EventArgs e)
        {
             zhijiahao = zhijiaTable.JiaziID ;
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
            txtBianhao.Text = zhijiaTable.JiaziID   ;                     
            txtcunfang .Text  = zhijiaTable.State   ;
            txtguishuo.Text = zhijiaTable.Guisuo ;
           
        }
        private void InitPingzhong()
        {
            zhijiaTable.JiaziID    = txtBianhao.Text;
            zhijiaTable.State = txtcunfang.Text;
            zhijiaTable.Guisuo  = txtguishuo.Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtguishuo .Text =="")
            {
                MessageBox.Show("请填写该支架的归属", "提醒",MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrWhiteSpace ( JiaziTableService.GetOneJiaziTable (x=>x.JiaziID ==txtBianhao.Text &&x.Guisuo ==txtguishuo.Text ).JiaziID ))
            {
                MessageBox.Show("该归属公司的子架号已经存在！请勿重复添加", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
                while (JiaziTableService.GetJiaziTablelst (x=>x.JiaziID ==txtBianhao.Text ).Count >0)
                {
                    txtBianhao.Text = BianhaoBLL.CreatJiaziBianhao();
                }
                JiaziTableService.InsertJiaziTable   (zhijiaTable);             
            }
            else
            {
                JiaziTableService .UpdateJiaziTable    (zhijiaTable, x=>x.JiaziID   == txtBianhao .Text   );             
            }
            zhijiaTable = new JiaziTable  ();
            Useful = FormUseful.新增;
            InitText();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var fm = new 客户选择();
            fm.ShowDialog();
            txtcunfang .Text = fm.linkman.MC;
        }
    }
}
