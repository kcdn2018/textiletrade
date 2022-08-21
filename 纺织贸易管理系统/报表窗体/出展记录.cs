using BLL;
using Model;
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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 出展记录 : Form
    {
        public 出展记录()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now.AddDays(-QueryTime.间隔);
            dateEdit2.DateTime = DateTime.Now;
            CreateGrid.Create(this.Name, gridView1);
            Query();          
            gridView1.OptionsCustomization.AllowSort = true;
        }
        public virtual void Query()
        {
            try
            {
                UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
                var querystring = $"select distinct  danjutable.* from danjutable join zhanhuidetail on danjutable.dh=ZhanhuiDetail.danhao where danjutable.rq between '{ dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays(1)}'" +
                        $"and ZhanhuiDetail.YangbuBianhao like '%{txtbianhao.Text }%' " +
                        $"and ZhanhuiDetail.PM like '%{txtpingming.Text }%' " +
                        $"and ZhanhuiDetail.GG like '%{txtGuige.Text }%' " +
                        $"and danjutable.djlx='{DanjuLeiXing.展会  }' ";
                querystring += " order by danjutable.id desc";
                CreateGrid.Query(gridControl1, querystring);
                UIWaitFormService.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 展会管理() { Userful = FormUseful.新增 });
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改展会") == true)
            {
                MainForm.mainform.AddMidForm(new 展会管理() { Userful = FormUseful.修改,Danhao =gridView1.GetFocusedRowCellValue ("dh").ToString () });
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除展会"))
            {
                if (Sunny.UI.UIMessageBox.ShowAsk($"您确定要删除单号为{gridView1.GetFocusedRowCellValue ("dh").ToString()}该展会信息吗？"))
                {
                    DanjuTableService.DeleteDanjuTable(x => x.dh == gridView1.GetFocusedRowCellValue("dh").ToString());
                    ZhanhuiDetailService.DeleteZhanhuiDetail(x => x.Danhao == gridView1.GetFocusedRowCellValue("dh").ToString());
                }
                Query();
            }
         }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 出展记录_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "展会记录");
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

    }
}
