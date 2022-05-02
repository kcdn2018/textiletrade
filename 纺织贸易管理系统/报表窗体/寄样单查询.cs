using BLL;
using DevExpress.Xpo.DB.Helpers;
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
    public partial class 寄样单查询 : Form
    {
        public 寄样单查询()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
            CreateGrid.Create(this.Name , gridView2);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void 采购查询_Load(object sender, EventArgs e)
        {
          
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x=>x.rq >=dateEdit1.DateTime.Date&&x.rq<=dateEdit2.DateTime.Date.AddDays(1)&&x.ksmc .Contains (txtksmc.Text )&&x.zhuangtai !="已删除"&&x.djlx==DanjuLeiXing.寄样单   ));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CreateGrid.Query<JiYangBaoJia >(gridControl2, JiYangBaoJiaService  .GetJiYangBaoJialst  (x => x.Danhao  == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString ()));
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess (this.Name)==true)
            {
                MainForm.mainform.AddMidForm (new 寄样单 () { useful=FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改寄样单") == false)
            {
                MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.修改,danju =DanjuTableService.GetOneDanjuTable (x=>x.dh==gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"dh").ToString ())});
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <=dateEdit2.DateTime.Date.AddDays(1) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.采购入库单));
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除寄样单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改寄样单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    寄样单BLL.删除寄样单据(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <=dateEdit2.DateTime.Date.AddDays(1) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.采购入库单));
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "寄样单清单");
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 寄样单() { useful = FormUseful.复制,danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
            }
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { ZJC=txtksmc .Text } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman .MC ;
            CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <=dateEdit2.DateTime.Date.AddDays(1) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.寄样单));
        }

        private void txtksmc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter )
            {
                CreateGrid.Query<DanjuTable>(gridControl1, DanjuTableService.GetDanjuTablelst(x => x.rq >= dateEdit1.DateTime && x.rq <=dateEdit2.DateTime.Date.AddDays(1) && x.ksmc.Contains(txtksmc.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.寄样单));
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }
    }
}
