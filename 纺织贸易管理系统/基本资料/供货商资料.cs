using DevComponents.AdvTree;
using DevExpress.Utils.DirectXPaint;
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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 供货商资料 : Form
    {
        private List<LXR > dblist = new List<LXR>();
        public 供货商资料()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name ,gridView1 );
            Query();
            CreateTree();
        }
        private void CreateTree()
        {
            var node = new TreeNode("所有类型");
            var lxr = LXRService.GetLXRlst(x => x.LX == "供货商").Select(x => x.Leixing).Distinct().ToList().Where (x=>!string.IsNullOrWhiteSpace (x)).ToList ();
            foreach (var l in lxr )
            {
                node.Nodes.Add(l);
            }
            uiTreeView1.Nodes.Add(node);
            uiTreeView1.ExpandAll();
        }
        private void Query()
        {
            if (uiTreeView1.SelectedNode != null)
            {
                if (uiTreeView1.SelectedNode.Text == "所有类型")
                {
                    dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text));
                }
                else
                {
                    dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text) && x.Leixing == uiTreeView1.SelectedNode.Text);
                }
            }
            else
            {
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtmingcheng.Text));
            }
            foreach (var d in dblist)
            {
                d.JE = 0 - d.JE;
            }
            gridControl1.DataSource = dblist;
        }

    private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name ,Obj  =new LXR () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增供货商"))
            {
                var fm = new 新增供货商() { Useful = FormUseful.新增 };
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
            if (BLL.AccessBLL.CheckAccess("修改供货商"))
            {
                var fm = new 新增供货商() { Useful = FormUseful.修改, LinkMan = dblist[gridView1.FocusedRowHandle] };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("删除供货商信息"))
            {
                try
            {
                var res = MessageBox.Show($"您确定要删除该编号{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH")}的供货商信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    LXRService.DeleteLXR(x => x.BH == $"{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BH")}");
                    AlterDlg.Show("删除成功！");
                    Query();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除时发生错误！" + ex.Message);
            }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }

        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"供货商资料");
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void uiTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Query();
        }
    }
}
