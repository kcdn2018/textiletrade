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
    public partial class 品种选择 : Form
    {
        public string zjc { get; set; }
        public string Bianhao { get; set; }
        public List <db> pingzhong { get; set; }
        private List<db> dblist = new List<db>();
        public 品种选择()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
        }

        private void 品种选择_Load(object sender, EventArgs e)
        {
            txtpingming.Text = zjc;
            txtbianhao.Text = Bianhao;
            dblist =dbService.Getdblst(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text),10,100,1,0);
            gridControl1.DataSource = dblist;
        }
        private void Query()
        {
            dblist = dbService.Getdblst(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text)).OrderByDescending (x=>x.rq ).ToList ();
            gridControl1.DataSource = dblist;
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new db () };
            fm.ShowDialog();
        }

        private void 品种选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            pingzhong = new List<db>();
            foreach (int i in gridView1.GetSelectedRows())
            {
                pingzhong.Add(dblist.Where (x=>x.bh==gridView1.GetRowCellValue(i,"bh").ToString ()).ToList ()[0]);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            this.Close();
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                gridView1.SelectRow(gridView1.FocusedRowHandle);
                this.Close();
            }
        }
    }
}
