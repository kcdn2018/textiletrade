using BLL;
using Microsoft.VisualBasic;
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
using 纺织贸易管理系统.新增窗体;

namespace 纺织贸易管理系统.设置窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 用户选择 : Sunny.UI.UIForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public Yhb yonghu { get; set; } = new Yhb();
        public 用户选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["MM"].ColumnEdit = TextEdit1;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            gridControl1.DataSource = YhbService.GetYhblst();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = YhbService.GetYhblst();
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 用户选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            yonghu = YhbService.GetYhblst().First(x => x.YHBH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
        }
    }
}
