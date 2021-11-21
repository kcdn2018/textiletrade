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
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIEditForm”(是否缺少程序集引用?)
    public partial class 新增要求 : Sunny.UI.UIEditForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIEditForm”(是否缺少程序集引用?)
    {
        public int Useful { get; set; }
        public GongYiYaoqiu  technology { get; set; }
        public 新增要求()
        {
            InitializeComponent();
        }
        private void 新增员工_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.修改)
            {
                edit();
            }
        }

        private void edit()
        {
            txtnum.Text = technology.name  ;
        }
        private void 新增员工_ButtonOkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnum.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入要求名称！要求名称不能为空");
                return;
            }
          
            var stat = new GongYiYaoqiu ();
            stat.name  = txtnum.Text;
            if (Useful == FormUseful.新增)
            { 
                if (!string.IsNullOrWhiteSpace(GongYiYaoqiuService .GetOneGongYiYaoqiu(x => x.name  == txtnum.Text).name ))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该工艺名称已经存在！保存失败");
                return;
            }
                GongYiYaoqiuService .InsertGongYiYaoqiu (stat);
            }
            else
            {
                stat.ID = technology.ID;
                GongYiYaoqiuService .UpdateGongYiYaoqiu (stat, x => x.ID == stat.ID);
            }
            Useful = FormUseful.新增;
            technology = new GongYiYaoqiu ();
            edit();
        }

        private void 新增工艺_ButtonCancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
