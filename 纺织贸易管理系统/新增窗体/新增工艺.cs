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
    public partial class 新增工艺 : Sunny.UI.UIEditForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIEditForm”(是否缺少程序集引用?)
    {
        public int Useful { get; set; }
        public TechnologyTable technology { get; set; }
        public 新增工艺()
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
            txtnum.Text = technology.Technology ;
        }
        private void 新增员工_ButtonOkClick(object sender, EventArgs e)
        {
            var stat = new TechnologyTable();
            stat.Technology = txtnum.Text;
            if (Useful == FormUseful.新增)
            {
                TechnologyTableService.InsertTechnologyTable(stat);
            }
            else
            {
                stat.ID = technology.ID;
                TechnologyTableService.UpdateTechnologyTable(stat  , x => x.ID == stat.ID);
            }
            Useful = FormUseful.新增;
            technology = new TechnologyTable();
            edit();
        }

        private void 新增工艺_ButtonCancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
