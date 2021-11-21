using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.设置窗体
{
    public partial class InpuBox : Form
    {
        public string 内容 { get; set; }
        public string Label { get; set; }
        public string 参考模板 { get; set; }
        public string filePath { get; set; }
        public InpuBox()
        {
            InitializeComponent();
            
        }

        private void InpuBox_Load(object sender, EventArgs e)
        {
            labelX1.Text = Label;
            cmbMoban.DataSource = Tools.获取模板.获取所有模板(filePath );
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            内容 = textBoxX1.Text;
            参考模板 = cmbMoban.Text;
            this.Close();
            this.Dispose();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
