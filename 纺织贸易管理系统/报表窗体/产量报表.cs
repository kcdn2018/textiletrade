using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 产量报表 : Form
    {
        public 产量报表()
        {
            InitializeComponent();
            uiDatePicker2.Value = DateTime.Now;
            uiDatePicker1.Value = uiDatePicker2.Value.AddDays(-uiDatePicker2.Value.Date.Day);
            cmbgongyi.DataSource =TechnologyTableService.GetTechnologyTablelst ().Select (x=>x.Technology ).ToList ();
            cmbjigong.DataSource = YuanGongTableService .GetYuanGongTablelst ().Select (x=>x.Xingming ).ToList();
            cmbjitai.DataSource = MachineTableService.GetMachineTablelst ().ToList().Select (x=>x.MachineID ).ToList ();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
            var logs = liuzhuanlogService .Getliuzhuanloglst (x => x.Employee.Contains(cmbjigong.Text) && x.GongyiYaoqiu.Contains(cmbgongyi.Text) && x.MachineID.Contains(cmbjitai.Text) && x._date >= uiDatePicker1.Value.Date && x._date <= uiDatePicker2.Value.Date);
            uiDataGridView1.DataSource = logs;
            uiDataGridView1.Refresh();
            txthejimishu.Text = logs.Sum(x => x.Num).ToString();
        }

        private void 产量报表_Load(object sender, EventArgs e)
        {
            query();
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportExcels(this.Text, uiDataGridView1);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                ExcelService.PrintExcels(this.Text, uiDataGridView1);
            }
            ));
        }
    }
}
