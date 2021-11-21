using BLL;
using Microsoft.VisualBasic;
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
using 纺织贸易管理系统.新增窗体;

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 用户管理 : Form
    {
       
        public 用户管理()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["MM"].ColumnEdit = TextEdit1;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            gridControl1.DataSource = YhbService.GetYhblst();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 新增用户() { useful=FormUseful.新增 });
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 新增用户() { useful = FormUseful.修改,Yonghu=YhbService.GetOneYhb (x=>x.YHBH==gridView1.GetRowCellValue (gridView1.FocusedRowHandle ,"YHBH").ToString ()) });
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString()=="管理员")
            {
                MessageBox.Show("管理员不能删除!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (AccessBLL.CheckAccess("删除用户") == true)
            {
                if (MessageBox.Show("您确定要删除该用户吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)== DialogResult.Yes)
                 {
                    Sunny.UI.UIMessageBox.ShowAsk ("请选择一个账号！帮该账号的所有资料转到新账号上");
                    var fm = new 用户选择();
                    fm.ShowDialog();
                    var yonghu = fm.yonghu;
                    //把联系人信息转到新的账号上去
                    LXRService.UpdateLXR($"own='{yonghu.YHBH }'", x => x.own == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    //把单据转到新的账号上去
                    DanjuTableService.UpdateDanjuTable($"own='{yonghu.YHBH }'", x => x.own == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    //把生产单转到新的账号上去
                    ShengChanDanTableService.UpdateShengChanDanTable($"own='{yonghu.YHBH }'", x => x.own == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    ///把订单信息转到新装好上去
                    OrderTableService.UpdateOrderTable($"own='{yonghu.YHBH }'", x => x.own == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    ///删除菜单信息及界面
                    FatherMenuTableService.DeleteFatherMenuTable(x => x.UserID == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    MenuTableService.DeleteMenuTable(x => x.UserID == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    AccessTableService.DeleteAccessTable(x => x.UserID == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    Connect.CreatConnect().Delete<ColumnTable >(x=>x.UserID == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    YhbService.DeleteYhb(x => x.YHBH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YHBH").ToString());
                    gridControl1.DataSource = YhbService.GetYhblst();
                }
            }
            else
            {
                MessageBox.Show("您没有权限删除用户!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = YhbService.GetYhblst();
        }
    }
}
