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
    public partial class 发票签收列表 : Form
    {
        private LXR linkman = new LXR();
        public 发票签收列表()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name , gridView1);
           
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable() };
            fm.ShowDialog();
        }
        private void Query()
        {
            CreateGrid.Query(gridControl1, $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ Convert.ToDateTime(dateEdit1.Text)}' and '{Convert.ToDateTime(dateEdit2.Text)}' and danjutable.ksmc like '%{txtksmc.Text}%' " +
                   //$"and danjumingxitable.bianhao like '%{txtbianhao.Text }%' " +
                   //$"and danjumingxitable.pingming like '%{txtpingming.Text }%' " +
                   //$"and danjumingxitable.guige like '%{txtGuige.Text }%' " +
                   //$"and danjumingxitable.ColorNum like '%{txtyanse.Text }%' " +
                   //$"and danjumingxitable.ContractNum like '%{txthetonghao.Text }%' " +
                   //$"and danjumingxitable.OrderNum like '%{txtordernum.Text }%' " +
                   $"and danjutable.djlx='{DanjuLeiXing.发票签收}' " +
                   $"and danjutable.dh=danjumingxitable.danhao order by danjutable.id desc");
        }
      

   

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AccessBLL.CheckAccess (this.Name)==true)
            {
               new 发票签收单 () { useful=FormUseful.新增 }.ShowDialog ();
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改发票签收") == true)
            {
                new 发票签收单() { useful = FormUseful.修改,danju =DanjuTableService.GetOneDanjuTable (x=>x.dh==gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"dh").ToString ())}.ShowDialog ();
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除发票签收单"))
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    if ((int)(MessageBox.Show("您确定要删除改发票签收吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                    {
                        var danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString();
                        var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                        财务BLL.增加应收发票(danju);
                        来往明细BLL.删除来往记录(danju);
                        单据BLL.删除单据(danhao);
                        Query();
                    }
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "发票签收清单");
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //采购入库单BLL.单据审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //采购入库单BLL.单据反审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择 ();
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            linkman = fm.linkman;
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Query();
        }

        private void 发票签收列表_Load(object sender, EventArgs e)
        {
            Query();
        }
    }
}
