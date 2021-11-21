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
    public partial class 客户选择 : Form
    {
        public LXR linkman { get; set; } = new LXR();
        public 客户选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);           
        }
       
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (User.user.access == "自己")
            {
                CreateGrid.Query<LXR>(gridControl1, LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "客户" && x.MC.Contains(txtMingcheng.Text)&&x.own==User.user.YHBH ));
            }
            else
            {
                CreateGrid.Query<LXR>(gridControl1, LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "客户" && x.MC.Contains(txtMingcheng.Text)));
            }
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode ==Keys.Enter )
            {
                查询ToolStripMenuItem_Click(null, null);
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        private void 客户选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string bianhao = string.Empty;
                if (gridView1.FocusedRowHandle >= 0)
                {
                     bianhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString();
                }
                else
                { 
                    bianhao =string.Empty ;
                }              
                if (!string.IsNullOrWhiteSpace (bianhao ))
                {
                    linkman = LXRService.GetOneLXR (x=>x.BH ==bianhao );
                }
                else
                {
                    linkman = new LXR() { MC = "", BH = "" };
                }
            }
            catch
            {
                linkman = new LXR() { MC = "", BH = "" };
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 客户选择_Load(object sender, EventArgs e)
        {
            txtMingcheng.Text = linkman.MC;
            txtzhujici.Text = linkman.ZJC;
            查询ToolStripMenuItem_Click(null, null);
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
