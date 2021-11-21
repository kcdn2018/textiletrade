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
using 纺织贸易管理系统.其他窗体;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 新增色号 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public int useFul { get; set; }
        public string ColorNum { get; set; }
        public 新增色号()
        {
            InitializeComponent();
        }

       

        private void 新增色号_Load(object sender, EventArgs e)
        {
            if (useFul == FormUseful.新增)
            {
                txtColorNum.Text = BianhaoBLL.CreatSeHao();
            }
            else
            {
                var color = ColorTableService.GetOneColorTable(x => x.ColorNum == ColorNum);
                txtColorName.Text = color.ColorName;
                txtColorNum.Text = color.ColorNum;
                txtColorNum.ReadOnly = true;
                labelX1.BackColor  = System.Drawing.ColorTranslator.FromHtml(color.Color);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColorName .Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入颜色名称！颜色名称不能为空");
                return;
            }
            if (useFul == FormUseful.新增)
            {
                if (Check())
                {
                    MessageBox.Show("该编号已经存在！请重新输入编号", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ColorTableService.InsertColorTable(new ColorTable() { Color = labelX1.BackColor.ToArgb().ToString(), ColorName = txtColorName.Text, ColorNum = txtColorNum.Text });
                    AlterDlg.Show("新增色号成功！");
                }
            }
            else
            {
                ColorTableService.UpdateColorTable(new ColorTable() { Color = labelX1.BackColor.ToArgb().ToString(), ColorName = txtColorName.Text, ColorNum = txtColorNum.Text }, x => x.ColorNum == txtColorNum.Text);
            }
        }
        private Boolean  Check()
        {
            var color = ColorTableService.GetOneColorTable(x => x.ColorNum == txtColorNum.Text);
            return color.ColorNum == string.Empty ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Dlg = new ColorDialog();
            Dlg.ShowDialog();
            labelX1.BackColor = Dlg.Color;
        }
    }
}
