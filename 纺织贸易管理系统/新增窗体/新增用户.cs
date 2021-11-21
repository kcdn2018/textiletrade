using BLL;
using Microsoft.VisualBasic.ApplicationServices;
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
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 新增用户 : Form
    {
        public int useful { get; set; }
        public Yhb Yonghu { get; set; } = new Yhb();
        private List<FatherMenuTable> fatherMenuTables = new List<FatherMenuTable>();
        private List<MenuTable> menuTables = new List<MenuTable>();
        private List<AccessTable> accessTables = new List<AccessTable>();
        private string status = string.Empty;
        private bool isdone = false;
        public 新增用户()
        {
            InitializeComponent();
            CreateGrid.Create("菜单管理", gridView1);
            CreateGrid.Create("菜单管理", gridView2);
            CreateGrid.Create(this.Name, gridView3);
            cmbUser.DataSource = YhbService.GetYhblst().Select(x => x.YHBH + "/" + x.YHMC).ToList();
            cmbUser.SelectedIndex = 0;
            uiLabel1.Text = string.Empty;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView3) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 新增用户_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtBianhao.Text = BianhaoBLL.CreatYonghuBianhao();
                initMenu();
            }
            else
            {
                txtBianhao.Text = Yonghu.YHBH;
                txtbz.Text = Yonghu.备注;
                txtmm.Text = Yonghu.MM;
                txtyhmc.Text = Yonghu.YHMC;
                comboBoxEx1.Text = Yonghu.access;
                fatherMenuTables = FatherMenuTableService.GetFatherMenuTablelst(x => x.UserID == txtBianhao.Text);
                menuTables = MenuTableService.GetMenuTablelst(x => x.UserID == txtBianhao.Text);
                accessTables = AccessTableService.GetAccessTablelst(x => x.UserID == txtBianhao.Text);
                gridControl1.DataSource = fatherMenuTables;
                gridControl2.DataSource = menuTables;
                gridControl3.DataSource = accessTables;
            }
        }
        private void initMenu()
        {
            var userid = cmbUser.Text.Split('/')[0];
            fatherMenuTables = FatherMenuTableService.GetFatherMenuTablelst(x => x.UserID == userid);
            menuTables = MenuTableService.GetMenuTablelst(x => x.UserID == userid);
            accessTables = AccessTableService.GetAccessTablelst(x => x.UserID == userid);
            foreach (var f in fatherMenuTables)
            {
                f.UserID = txtBianhao.Text;
            }
            foreach (var f in menuTables)
            {
                f.UserID = txtBianhao.Text;
            }
            foreach (var f in accessTables)
            {
                f.UserID = txtBianhao.Text;
            }
            gridControl1.DataSource = fatherMenuTables;
            gridControl2.DataSource = menuTables;
            gridControl3.DataSource = accessTables;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBianhao.Text == "10001")
            {
                MessageBox.Show("10001账号是管理员账号不能添加", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var yh = YhbService.GetOneYhb(x => x.YHBH == txtBianhao.Text);
            if (useful == FormUseful.新增)
            {
                if (!string.IsNullOrWhiteSpace(yh.YHBH))
                {
                    MessageBox.Show("该用户编号已经存在！系统将自动加1", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBianhao.Text = BianhaoBLL.CreatYonghuBianhao();
                }
            }
            if (comboBoxEx1.Text == "")
            {
                yh.access = "所有";
            }
            else
            {
                yh.access = comboBoxEx1.Text;
            }
            yh.hs = "含税";
            yh.MM = txtmm.Text;
            yh.YHBH = txtBianhao.Text;
            yh.YHMC = txtyhmc.Text;
            yh.备注 = txtbz.Text;
            yh.own = User.user.YHBH;
            if (useful == FormUseful.新增)
            {
                YhbService.InsertYhb(yh);
                Sunny.UI.UIMessageDialog.ShowInfoDialog(this, "系统将要创建一个新的账户！期间会需要一点时间，为了不妨碍您的其他操作，创建新账户的过程会在后台运行。创建好后会有提示。在没提示创建成功之前请不要关闭程序。否则有可能会出现字段混乱的问题。请耐心等待");
                if (txtBianhao.Text != "10001")
                {
                    isdone = false;
                    status = "正在创建菜单";
                    SaveMenu();
                    status = "正在创建权限";
                    SaveAccess();
                    if (useful == FormUseful.新增)
                    {
                        SaveColumn();
                    }
                }
                Sunny.UI.UIMessageDialog.ShowSuccessDialog(this, "创建成功！");
            }
            else
            {
                YhbService.UpdateYhb(yh, x => x.YHBH == yh.YHBH);
            }
        }
        private void SaveMenu()
        {
            FatherMenuTableService.DeleteFatherMenuTable(x => x.UserID == txtBianhao.Text);
            MenuTableService.DeleteMenuTable(x => x.UserID == txtBianhao.Text);
            FatherMenuTableService.InsertFatherMenuTablelst(fatherMenuTables);
            MenuTableService.InsertMenuTablelst(menuTables);
        }
        private void SaveAccess()
        {
            AccessTableService.DeleteAccessTable(x => x.UserID == txtBianhao.Text);
            AccessTableService.InsertAccessTablelst(accessTables);
        }
        private void SaveColumn()
        {
            var userid = cmbUser.Text.Split('/')[0];
            var columns = Connect.CreatConnect().Query<ColumnTable>(x => x.UserID == userid);
            foreach (var c in columns)
            {
                c.UserID = txtBianhao.Text;
            }
            Connect.CreatConnect().Insert<ColumnTable>(columns);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtmm.PasswordChar = default(char);
            }
            else
            {
                txtmm.PasswordChar = '*';
            }
        }
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            initMenu();
        }
    }
}
