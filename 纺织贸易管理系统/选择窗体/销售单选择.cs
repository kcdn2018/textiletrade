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
    public partial class 销售单选择 : Sunny.UI.UIForm 
    {
        public string zjc { get; set; }
        public string Bianhao { get; set; }
        public danjumingxitable  pingzhong { get; set; }
        public 销售单选择()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.CreateDatagridview(this.Name, gridView1);
        }

        private void 品种选择_Load(object sender, EventArgs e)
        {
            txtpingming.Text = zjc;
            txtbianhao.Text = Bianhao;
            gridView1.DataSource=danjumingxitableService .Getdanjumingxitablelst (x => x.danhao.Contains(FirstLetter.销售发货单  ) && x.pingming .Contains(txtpingming.Text) && x.guige .Contains(txtguige.Text) &&x.rq >=dateEdit1.DateTime.Date&&x.rq <=dateEdit2.DateTime.Date.AddDays(1)).OrderByDescending  (x=>x.rq );
        }
        private void Query()
        {
            gridView1.DataSource = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao.Contains(FirstLetter.销售发货单) && x.pingming.Contains(txtpingming.Text) && x.guige.Contains(txtguige.Text));
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name,Obj=new db () };
            fm.ShowDialog();
        }

        private void 品种选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mingxis = gridView1.DataSource as List<danjumingxitable>;
            pingzhong =mingxis ==null?new danjumingxitable (): mingxis[gridView1.CurrentRow.Index  ];
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
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void gridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }
    }
}
