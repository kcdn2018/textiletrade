using DevComponents.AdvTree;
using DevExpress.XtraEditors;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.报表窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 应付款查询 : Form
    {
        private List<LXR > dblist = new List<LXR>();
        public 应付款查询()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name   ,gridView1 );
            dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text)&&x.JE !=0);
            CreateGrid.Query<LXR>(gridControl1,dblist );
        }
        private void Query()
        {
            if (checkBoxX1.Checked == true)
            {
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text));
            }
            else
            {
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text)&&x.JE!=0);
            }
            gridControl1.DataSource =dblist;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new LXR () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("删除疵点信息"))
            {
                var fm = new 付款单() { Useful = FormUseful.新增 };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >=0)
            {
                var fm = new 供货商对账单() { Useful = FormUseful.供货商, LinkMan = dblist[gridView1.FocusedRowHandle] };
                MainForm.mainform.AddMidForm(fm);
                Query();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
                Query();
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"应付款查询");
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void 收款记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 付款记录() );
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var fm = new 供货商对账单() { Useful = FormUseful.供货商, LinkMan = dblist[gridView1.FocusedRowHandle] };
                MainForm.mainform.AddMidForm(fm);
                Query();
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 销售分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 应付款汇总());
        }

        private void 调整金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 调整金额() { linkman = LXRService.GetOneLXR (x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString()) };
            fm.ShowDialog();
            Query();
        }
    }
}
