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
using Tools;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 岗位信息 : Form
    {
        public 岗位信息()
        {
            InitializeComponent();
         
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 新增窗体.新增岗位() { Useful=FormUseful.新增 };
            fm.ShowDialog();
            query();
        }

        private void 员工信息_Load(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
            gridControl1 .DataSource = MachineTableService.GetMachineTablelst();
            //uiDataGridView1.DataSource = DBHelper.dbHelper.Ado.GetDataTable ("select * from employee");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 新增窗体.新增岗位()
            {
                Useful = FormUseful.修改,
                station = MachineTableService.GetOneMachineTable(x => x.ID == (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colID.FieldName))
            };
            fm.ShowDialog();
            query();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Sunny.UI .UIMessageDialog.ShowAskDialog (this,"您确定要删除该岗位信息吗？")==true )
            {
                MachineTableService .DeleteMachineTable(x=>x. ID == (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colID.FieldName));
                query();
            }
        }
    }
}
