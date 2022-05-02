using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.其他窗体;

namespace 纺织贸易管理系统.选择窗体
{
    public partial class 色号选择 : Form
    {
        private List<ColorTable> dblist = null;
        public ColorTable colorInfo { get; set; } = new ColorTable() { ColorNum = string.Empty, ColorName = string.Empty };
        public 色号选择()
        {
            InitializeComponent();

        }
        private void Query()
        {
            dblist = ColorTableService.GetColorTablelst(x => x.ColorNum.Contains(txtzhujici.Text )&&x.ColorName .Contains (txtmingcheng.Text ));
            gridControl1.DataSource = dblist;
        }

        private void txtzhujici_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void 色号选择_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(gridView1.FocusedRowHandle>=0)
            {
                colorInfo = dblist.Where(x => x.ColorNum == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ColorNum").ToString()).ToList ()[0] ;
            }
            else
            {
                AlterDlg.Show("没有色号被选中");
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 色号选择_Load(object sender, EventArgs e)
        {
            txtzhujici.Text = colorInfo.ColorNum;
            txtmingcheng.Text = colorInfo.ColorName;
            Query();
        }
    }
}
