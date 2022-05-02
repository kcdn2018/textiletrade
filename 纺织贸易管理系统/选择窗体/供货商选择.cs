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
    public partial class 供货商选择 : Sunny.UI.UIForm 
    {
        public LXR linkman { get; set; } = new LXR();
        public List<LXR> dblist { get; private set; }

        public 供货商选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateTree();
        }
        private void CreateTree()
        {
            var node = new TreeNode("所有类型");
            var lxr = LXRService.GetLXRlst(x => x.LX == "供货商").Select(x => x.Leixing).Distinct().ToList().Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            foreach (var l in lxr)
            {
                node.Nodes.Add(l);
            }
            uiTreeView1.Nodes.Add(node);
            uiTreeView1.ExpandAll();
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            if (uiTreeView1.SelectedNode != null)
            {
                if (uiTreeView1.SelectedNode.Text == "所有类型")
                {
                    dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtMingcheng.Text));
                }
                else
                {
                    dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtMingcheng.Text) && x.Leixing == uiTreeView1.SelectedNode.Text);
                }
            }
            else
            {
                dblist = LXRService.GetLXRlst(x => x.ZJC.Contains(txtzhujici.Text) && x.LX == "供货商" && x.MC.Contains(txtMingcheng.Text));
            }
            foreach (var d in dblist)
            {
                d.JE = 0 - d.JE;
            }
            gridControl1.DataSource = dblist;
        }
        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
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
                if (!string.IsNullOrWhiteSpace(bianhao))
                {
                    linkman = LXRService.GetOneLXR(x => x.BH == bianhao);
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

        private void 供货商选择_Load(object sender, EventArgs e)
        { 
            txtzhujici.Text = linkman.ZJC;
            txtMingcheng.Text = linkman.MC;
            CreateGrid.Query<LXR>(gridControl1, LXRService.GetLXRlst(x => x.ZJC.Contains(linkman.ZJC )  && x.MC.Contains(txtMingcheng.Text)).Where (x=>x.LX.Contains ("商")).ToList ());
           
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
