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
    public partial class 应收款查询 : Form
    {
        private List<LXR > dblist = new List<LXR>();
        public 应收款查询()
        {
            InitializeComponent();
            //dateEdit2.DateTime = DateTime.Now;
            //dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name  ,gridView1 );
         
        }
        private void Query()
        {
            //string sql = string.Empty;
            if (checkBoxX1.Checked == true)
            {
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "客户" && x.MC.Contains(txtmingcheng.Text));
                //sql = $"select * from lxr,lwdetail where lwdetail.rq between {dateEdit1.DateTime.Date } and {dateEdit2.DateTime.Date } and lwdetail.khmc=lxr.mc " +
                //    $" and lxr.mc like '%{txtzhujici.Text }%' and lxr.mc='客户'";
            }
            else
            {
                //sql = $"select * from lxr,lwdetail where lwdetail.rq between {dateEdit1.DateTime.Date } and {dateEdit2.DateTime.Date } and lwdetail.khmc=lxr.mc " +
                //   $" and lxr.mc like '%{txtzhujici.Text }%' and lxr.mc='客户' and lxr.je<>'0'";
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "客户" && x.MC.Contains(txtmingcheng.Text)&&x.JE!=0);
            }
            if (User.user.access == "所有")
            {
                gridControl1.DataSource = dblist;
            }
            else
            {
                gridControl1.DataSource = dblist.Where(x => x.own == User.user.YHBH).ToList();
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new LXR () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 收款单 () { Useful = FormUseful.新增 };
            MainForm.mainform.AddMidForm(fm);
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var fm = new 对账单() { Useful = FormUseful.客户, LinkMan = dblist[gridView1.FocusedRowHandle] };
                MainForm.mainform.AddMidForm(fm);
                Query();
            }
            else
            {
                AlterDlg.Show("没有任何记录被选中!");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
                Query();
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"应收款查询");
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
            MainForm.mainform.AddMidForm(new 收款记录());
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 应收款查询_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void 销售分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 应收款汇总 ());
        }

        private void 调整金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 调整金额() { linkman = LXRService.GetOneLXR(x => x.BH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH").ToString() )};
            fm.ShowDialog();
            Query();
        }
    }
}
