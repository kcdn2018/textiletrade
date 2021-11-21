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
    public partial class 菜单管理 : Form
    {
        private List<FatherMenuTable> fatherMenuTables = new List<FatherMenuTable>();
        private List<MenuTable> menuTables = new List<MenuTable>();
        public 菜单管理()
        {
            InitializeComponent();
            comboBoxEx1.DataSource = YhbService.GetYhblst().Select(x => x.YHBH).ToList();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView2);
            var c = Connect.GetColumnSetting();
            colorPickerButton1.BackColor = System.Drawing.ColorTranslator.FromHtml(c.OddColor);
            colorPickerButton2.BackColor = System.Drawing.ColorTranslator.FromHtml(c.EvenColor);
        }

        private void comboBoxEx1_SelectedValueChanged(object sender, EventArgs e)
        {
            fatherMenuTables = FatherMenuTableService.GetFatherMenuTablelst(x=>x.UserID ==comboBoxEx1.Text );
            gridControl1.DataSource = fatherMenuTables;
            txtyhmc.Text = YhbService.GetOneYhb(x => x.YHBH == comboBoxEx1.Text).YHMC;
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
          
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var f = fatherMenuTables[gridView1.FocusedRowHandle];
            FatherMenuTableService.UpdateFatherMenuTable(f, x => x.FatherMenuName == f.FatherMenuName && x.UserID == f.UserID);
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var m = menuTables[gridView2.FocusedRowHandle];
            MenuTableService.UpdateMenuTable(m, x => x.FatherMenu == m.FatherMenu && x.UserID == m.UserID&&x.FormName ==m.FormName );
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            menuTables = MenuTableService.GetMenuTablelst(x => x.FatherMenu == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FatherMenuName").ToString() && x.UserID == comboBoxEx1.Text);
            gridControl2.DataSource = menuTables;
            gridControl2.RefreshDataSource();
        }

        private void colorPickerButton1_SelectedColorChanged(object sender, EventArgs e)
        {
            Connect.SetOddColor(colorPickerButton1.SelectedColor.ToArgb().ToString());
        }

        private void colorPickerButton2_SelectedColorChanged(object sender, EventArgs e)
        {
            Connect.SetEvenColor(colorPickerButton2.SelectedColor.ToArgb().ToString());
        }

        private void 菜单管理_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainform.CreatFatherMenu();
        }
    }
}
