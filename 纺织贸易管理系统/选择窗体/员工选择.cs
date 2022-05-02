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

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 员工选择 : Sunny.UI.UIForm
    {
        public YuanGongTable  linkman { get; set; }
        public 员工选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Query<YuanGongTable>(gridControl1, YuanGongTableService.GetYuanGongTablelst (x => x.Xingming .Contains(txtzhujici.Text)));
        }
       
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<YuanGongTable>(gridControl1, YuanGongTableService.GetYuanGongTablelst(x => x.Xingming.Contains(txtzhujici.Text)));
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode ==Keys.Enter )
            {
                CreateGrid.Query<YuanGongTable>(gridControl1, YuanGongTableService.GetYuanGongTablelst(x => x.Xingming.Contains(txtzhujici.Text)));
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        private void 客户选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            string bianhao = string.Empty;
        
            if (gridView1.FocusedRowHandle >= 0)
            {
                bianhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bianhao").ToString();
            }
            linkman = YuanGongTableService .GetOneYuanGongTable    (x => x.Bianhao ==bianhao  .ToString());
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 客户选择_Load(object sender, EventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
