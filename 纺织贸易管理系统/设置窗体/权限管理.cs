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

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 权限管理 : Form
    {
        private List<AccessTable> AccessList = new List<AccessTable>();
        public 权限管理()
        {          
            InitializeComponent();
            comboBoxEx1.Items.AddRange (YhbService.GetYhblst().Select(x=>x.YHBH ).ToArray ());
            CreateGrid.Create(this.Name, gridView1);           
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void comboBoxEx1_SelectedValueChanged(object sender, EventArgs e)
        {
            CreateGrid.Query<AccessTable>(gridControl1, AccessList = AccessTableService.GetAccessTablelst(x=>x.UserID==comboBoxEx1.Text ).OrderBy (x=>x.AccessName ).ToList ());
            textBoxX1.Text = YhbService.GetOneYhb(x => x.YHBH == comboBoxEx1.Text).YHMC;
            textBoxX1.ReadOnly = false;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AccessTableService.DeleteAccessTable(x => x.UserID == comboBoxEx1.Text);          
            //AccessTableService.InsertAccessTablelst(AccessList);
            gridView1.CloseEditor();
            //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AlterDlg.Show("保存成功");
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (comboBoxEx1.Text != "10001")
            {
                AccessTableService.UpdateAccessTable(AccessList[gridView1.FocusedRowHandle], x => x.AccessName == AccessList[gridView1.FocusedRowHandle].AccessName && x.UserID == comboBoxEx1.Text);
            }
            else
            {
                var acc = AccessList[gridView1.FocusedRowHandle];
                acc.Access = true;
                AccessTableService.UpdateAccessTable(acc, x => x.AccessName == AccessList[gridView1.FocusedRowHandle].AccessName && x.UserID == comboBoxEx1.Text);
            }
        }

        private void 权限管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
        }
    }
}
