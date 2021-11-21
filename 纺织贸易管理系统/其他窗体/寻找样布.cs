using BLL;
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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 寻找样布 : Form
    {
        private List<db> dblist = new List<db>();
        private string lb;
        public 寻找样布()
        {
            InitializeComponent();
           
            CreatGrid();
            CreatLeibie();
        }
        private void CreatLeibie()
        {
            //var lblist = (from lb in 样布BLL.GetRemortDB () select lb.lb).ToList().Distinct<string>();
            //var node = new TreeNode() { Text = "所有类别", Name = "所有类别" };
            //foreach (string lb in lblist)
            //{
            //    node.Nodes.Add(new TreeNode() { Text = lb, Name = lb });
            //}
            //treeView1.Nodes.Add(node);
            //treeView1.ExpandAll();
        }
        private void 品种资料_Load(object sender, EventArgs e)
        {

        }
        private void Query()
        {
            //if (lb == "")
            //{
            //    dblist = 样布BLL.GetRemortDB(x =>  x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text)  );
            //}
            //else
            //{
            //    dblist = 样布BLL.GetRemortDB(x => x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text)  && x.lb == lb);
            //}
            //gridControl1.DataSource = dblist;
        }
        private void CreatGrid()
        {
            CreateGrid.Create(this.Name , gridView1);

            if (treeView1.SelectedNode != null)
            {
                lb = treeView1.SelectedNode.Text;
            }
            else
            {
                lb = "";
            }
            if (lb == "所有类别")
            {
                lb = "";
            }
            Query();
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lb = treeView1.SelectedNode.Text;
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1,"样布清单");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var fm = new InpuBox() { Label = "请输入你要新建的模板名称",内容="" };
            fm.ShowDialog();
            if (fm.内容 != "")
            {
                Tools.获取模板.新增模板(PrintPath.标签模板, fm.内容 , fm.参考模板);
            }
        }

        private void txtguige_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query ();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
