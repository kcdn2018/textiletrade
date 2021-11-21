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

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 产量统计报表 : Form
    {
        public 产量统计报表()
        {
            InitializeComponent();
            uiDatePicker2.Value = DateTime.Now;
            uiDatePicker1.Value = uiDatePicker2.Value.AddDays(-uiDatePicker2.Value.Date.Day);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
            var logs = liuzhuanlogService .Getliuzhuanloglst(x => x._date >= uiDatePicker1.Value.Date && x._date <= uiDatePicker2.Value.Date).ToList();
            if (comboBox1.Text == "技工")
            {
                Cjigong.HeaderText = "技工";
                var employes = logs.Select(x => x.Employee).ToList().Distinct().ToList();
                txthejimishu.Text = "0.00";
                uiDataGridView1.Rows.Clear();
                foreach (var em in employes)
                {
                    var index = uiDataGridView1.Rows.Add();
                    uiDataGridView1.Rows[index].Cells[Cjigong.Name].Value = em;
                    uiDataGridView1.Rows[index].Cells[Ccanliang.Name].Value = logs.Where(x => x.Employee == em).Sum(x => x.Num);
                    txthejimishu.Text = (txthejimishu.Text.TryToDecmial() + uiDataGridView1.Rows[index].Cells[Ccanliang.Name].Value.TryToDecmial()).ToString();
                }
            }
            else
            {
                Cjigong.HeaderText = "机台";
                var employes = logs.Select(x => x.MachineID ).ToList().Distinct().ToList();
                txthejimishu.Text = "0.00";
                uiDataGridView1.Rows.Clear();
                foreach (var em in employes)
                {
                    var index = uiDataGridView1.Rows.Add();
                    uiDataGridView1.Rows[index].Cells[Cjigong.Name].Value = em;
                    uiDataGridView1.Rows[index].Cells[Ccanliang.Name].Value = logs.Where(x => x.MachineID  == em).Sum(x => x.Num);
                    txthejimishu.Text = (txthejimishu.Text.TryToDecmial() + uiDataGridView1.Rows[index].Cells[Ccanliang.Name].Value.TryToDecmial()).ToString();
                }
            }
        }

        private void 产量统计报表_Load(object sender, EventArgs e)
        {
            query();
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportExcels(this.Text, uiDataGridView1);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            query();
        }

        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.Text == "技工")
            {
                var logs = liuzhuanlogService.Getliuzhuanloglst(x => x.Employee==uiDataGridView1.CurrentRow.Cells [Cjigong.Name ].Value.ToString ()  && x._date >= uiDatePicker1.Value.Date && x._date <= uiDatePicker2.Value.Date);
                uiDataGridView2.DataSource = logs;
                uiDataGridView2.Refresh();
            }
            else
            {
                var logs = liuzhuanlogService.Getliuzhuanloglst(x => x.MachineID  == uiDataGridView1.CurrentRow.Cells[Cjigong.Name].Value.ToString() && x._date >= uiDatePicker1.Value.Date && x._date <= uiDatePicker2.Value.Date);
                uiDataGridView2.DataSource = logs;
                uiDataGridView2.Refresh();              
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ExcelService.ExportExcels(this.Text, uiDataGridView2);
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action (()=> { ExcelService.PrintExcels(this.Text, uiDataGridView2); }));
            
        }

        private void 打印预览ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => { ExcelService.PrintExcels(this.Text, uiDataGridView1); }));
           
        }
    }
}
