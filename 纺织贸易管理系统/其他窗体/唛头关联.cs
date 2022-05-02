using BLL;
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
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 唛头关联 : Form
    {
        private List<string> Maitoulist = null;
        public 唛头关联()
        {
            InitializeComponent();
        }
        private void 加载唛头()
        {
            Maitoulist = Tools.获取模板.获取所有模板(PrintPath.唛头模板);
            commaitou.Items.Clear();
            commaitou .Items.AddRange(Maitoulist.ToArray());
            commaitou .SelectedIndex = 0;
            cmbmaitou.Items.Clear();
            cmbmaitou.Items.AddRange(Maitoulist);
            gridControl2.DataSource = MaitouService.GetMaitoulst();
        }
        private void 唛头关联_Load(object sender, EventArgs e)
        {
            加载唛头();
        }

        private void 设计唛头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改唛头"))
            {
                var fm = new 打印设置窗体();
                //fm.ShowDialog();
                new Tools.打印唛头() { copyies = fm.copyies, PrinterName = fm.printer, userful = PrintModel.Design, moban = PrintPath.唛头模板 + commaitou .Text, juan = new JuanHaoTable() }.打印();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有修改唛头的权限！请让管理员给你开通");
            }
           
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("新增唛头"))
            {
                var fm = new InpuBox() { Label = "请输入你要新建的模板名称", 内容 = "", filePath = PrintPath.唛头模板 };
                fm.ShowDialog();
                if (fm.内容 != "")
                {
                    Tools.获取模板.新增模板(PrintPath.唛头模板, fm.内容,fm.参考模板 );
                    加载唛头();
                    commaitou.Text = fm.内容 + ".frx";
                    var f = new 打印设置窗体();
                    //fm.ShowDialog();
                    new Tools.打印唛头() { copyies = f.copyies, PrinterName = f.printer, userful = PrintModel.Design, moban = PrintPath.唛头模板 + commaitou.Text, juan = new JuanHaoTable() }.打印();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有新增唛头的权限！请让管理员给你开通");
            }
        }

        private void linkSave_Click(object sender, EventArgs e)
        {
            var maitou = (gridControl2.DataSource as List<Maitou>)[gridView2.FocusedRowHandle];
            MaitouService.UpdateMaitou(maitou, x => x.khbh == maitou.khbh);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除唛头"))
            {
                Tools.ReportService.Delete(new ReportTable { reportName = commaitou .Text, reportStyle = Tools.ReportService.唛头 }, Application.StartupPath);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有删除唛头的权限！请让管理员给你开通");
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string newname = string.Empty;
                Sunny.UI.UIInputDialog.InputStringDialog(ref newname, true, "请输入新的模板名称");
                string oldname = commaitou .Text;
                ReportService.ReName(new ReportTable()
                {
                    ReportFile = ReportTableService.GetOneReportTable(x => x.reportName == oldname && x.reportStyle == Tools.ReportService.唛头 ).ReportFile
                    ,
                    reportName = newname + ".frx",
                    reportStyle = Tools.ReportService.唛头
                }, Application.StartupPath, oldname);
                加载唛头();
                MaitouService.UpdateMaitou(x=>x.path ==newname,x=>x.path==oldname );
                gridControl2.DataSource = MaitouService.GetMaitoulst();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
