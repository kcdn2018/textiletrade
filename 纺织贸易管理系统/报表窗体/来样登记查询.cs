﻿using BLL;
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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 来样登记查询 : Form
    {
        public 来样登记查询()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name  , gridView1);
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            gridView1.IndicatorWidth = 30;
            gridView1.OptionsCustomization.AllowSort = true;
            query();
        }
        private void query()
        {
            Sunny.UI.UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            gridControl1.DataSource = Connect.CreatConnect().Query("select * from danjutable t0,danjumingxitable t1 where t0.rq between "+ dateEdit1.DateTime.ToShortDateString ()+" and "+dateEdit2.DateTime.AddDays(1).ToShortDateString() +$" and t0.ksmc like '%{txtksmc.Text }%'"+$" and " +
                $"t1.CustomerFrabicNo like '%{txtbianhao.Text }%' and t1.bianhao like '%{txtpingming.Text }%' and t1.yanse like '%{txtyanse.Text }%' and t1.huahao like '%{txthuahao.Text }%'");
            Sunny.UI.UIWaitFormService.HideWaitForm ();
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 来样登记单  () { useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改来样报价单") == true)
            {
                MainForm.mainform.AddMidForm(new 来样登记单() { useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除来样登记单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改来样登记单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    var danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString();
                    DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
                    danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
                    query();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "来样登记单清单");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            query();           
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { MC=txtksmc.Text,ZJC="" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            query();
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                query();
            }
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 来样登记单() { useful = FormUseful.复制, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString()) });
            }
        }

        private void 来样报价查询_Load(object sender, EventArgs e)
        {

        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void txtpingming_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                query();
            }
        }
    }
}
