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
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 委外通知单选择 : Sunny.UI.UIForm 
    {
        public string zjc { get; set; }
        public string Bianhao { get; set; }
        public List <danjumingxitable > pingzhong { get; set; }
        public 委外通知单选择()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
        }

        private void 品种选择_Load(object sender, EventArgs e)
        {
            txtpingming.Text = zjc;
            txtbianhao.Text = Bianhao;
            gridControl1.DataSource=danjumingxitableService .Getdanjumingxitablelst (x => x.danhao.Contains(FirstLetter.采购通知单 ) && x.pingming .Contains(txtpingming.Text) && x.guige .Contains(txtguige.Text) &&x.rq >=dateEdit1.DateTime.Date&&x.rq <=dateEdit2.DateTime.Date.AddDays(1)).OrderByDescending  (x=>x.rq );
        }
        private void Query()
        {
            gridControl1.DataSource = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao.Contains(FirstLetter.采购通知单) && x.pingming.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text));
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new db () };
            fm.ShowDialog();
        }

        private void 品种选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.CloseEditor();
            pingzhong = new List<danjumingxitable>();
            foreach (int i in gridView1.GetSelectedRows())
            {
                pingzhong.Add(danjumingxitableService .GetOnedanjumingxitable (x=>x.ID==(int)gridView1.GetRowCellValue(i,"ID")));
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
