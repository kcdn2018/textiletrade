using Sunny.UI;
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
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class 工艺选择 : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public List<TechnologyTable> technologyTables { get; set; } = new List<TechnologyTable> ();
        private List<TechnologyTable> querys = new List<TechnologyTable>();
        public 工艺选择()
        {
            InitializeComponent();
            CreateGrid.Create (this.Name, gridView1);
        }
       
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1 ) { formname = this. Name };
            fm.ShowDialog();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            querys = TechnologyTableService.GetTechnologyTablelst();
            CreateGrid.Query<TechnologyTable >(gridControl1 ,  querys );
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
            gridView1.CloseEditor();
            try
            {
                foreach (int i in gridView1.GetSelectedRows())
                {
                        technologyTables.Add(querys[i]);
                }
            }
            catch
            {
               technologyTables.Add ( new TechnologyTable() {  Technology  = "", ID = 0 });
            }
        }
        private void 客户选择_Load(object sender, EventArgs e)
        {
            querys = TechnologyTableService.GetTechnologyTablelst();
            CreateGrid.Query<TechnologyTable>(gridControl1 , querys);
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1 );
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            this.Close();
        }
    }
}
