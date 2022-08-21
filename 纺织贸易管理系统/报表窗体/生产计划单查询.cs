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
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 生产计划单查询 : Form
    {
        public 生产计划单查询()
        {
            InitializeComponent();
            gridView1.OptionsView.AllowCellMerge = true;
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView4);
            CreateGrid.Create(this.Name, gridView2);
            CreateGrid.Create(this.Name, gridView3);
            CreateGrid.Create(this.Name, gridView5);
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
           foreach (var yuangong in YuanGongTableService .GetYuanGongTablelst ())
            {
                cmbzhidanren.Items.Add(yuangong.Xingming );
            }
            cmbzhidanren.Text = string.Empty;
        }

        private void 生产计划单查询_Load(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            string querystring = $"select *  from ShengchanBuliaoInfo,ShengChanDanTable  where  shengchandantable.shengchandanhao=ShengchanBuliaoInfo.shengchandanhao " +
                   $"and ShengChanDanTable.Jiagongchang like '%{txtjiagongchang.Text }%' " +
                   $"and ShengChanDanTable.riqi between '{ dateEdit1.DateTime}' and '{dateEdit2.DateTime.Date.AddDays(1)}' and ShengchanBuliaoInfo.SampleNum like '%{txtbianhao.Text }%' " +
                   $"and ShengchanBuliaoInfo.BuliaoPingming like '%{txtpingming.Text }%' " +
                   $"and ShengchanBuliaoInfo.ColorNum like '%{txtyanse.Text }%' " +
                   $"and ShengChanDanTable.Hetonghao like '%{txthetonghao.Text }%' " +
                   $"and ShengChanDanTable.OrderNum like '%{txtordernum.Text }%'  and ShengChanDanTable.SampleFrom like '%{txtksmc.Text}%' and ShengChanDanTable.Xiadanyuan like '%{cmbzhidanren.Text }%' ";
            //$" order by  desc"
            if (User.user.access == "自己")
            {
                querystring += $" and ShengChanDanTable.own='{User.user.YHBH }'";
            }  
            querystring += " order by ShengChanDanTable.riqi desc";
            //CreateGrid.Query<ShengChanDanTable>(gridControl1, ShengChanDanTableService.GetShengChanDanTablelst(x => x.riqi >= dateEdit1.DateTime && x.riqi <= dateEdit2.DateTime && x.OrderNum.Contains(txtordernum.Text) && x.SampleFrom.Contains(txtksmc.Text)));
            CreateGrid.Query(gridControl1,querystring );
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname=this.Name, dt=gridControl1.DataSource as DataTable  };
            fm.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new ShengchanBuliaoInfo () };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CreateGrid.Query<ShengchanBuliaoInfo>(gridControl2, ShengchanBuliaoInfoService.GetShengchanBuliaoInfolst(x => x.ShengChanDanhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()));
            CreateGrid.Query<ShengchanHouzhengli>(gridControl5,ShengchanHouzhengliService.GetShengchanHouzhenglilst  (x => x.shengchandanhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()));
            CreateGrid.Query<ShengchanChanshangTable>(gridControl4, ShengchanChanshangTableService.GetShengchanChanshangTablelst(x => x.ShengChandanhao  == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()));
            CreateGrid.Query<ShengChanFuHeMingxi >(gridControl3, ShengChanFuHeMingxiService .GetShengChanFuHeMingxilst (x => x.ShengChanDanHao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView3) { formname = this.Name, Obj = new ShengChanFuHeMingxi  () };
            fm.ShowDialog();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 生成指示单() {useful=FormUseful.新增});
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("修改生产计划单"))
            {
                MainForm.mainform.AddMidForm(new 生成指示单() { useful = FormUseful.修改, shengchandan = ShengChanDanTableService.GetOneShengChanDanTable(x => x.shengchandanhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()) });
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除生产计划单"))
            {
                if ((int)(MessageBox.Show("您确定要删除生产计划单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    生产计划单BLL.Delete(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShengChanDanhao").ToString());
                    Query();
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限删除该单据！请让管理员为你开通");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void 保存样式ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView3);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView4) { formname = this.Name, Obj = new ShengchanChanshangTable() };
            fm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView4);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView5) { formname = this.Name, Obj = new ShengchanHouzhengli () };
            fm.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView5);
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 生成指示单() { useful = FormUseful.复制 , shengchandan = ShengChanDanTableService.GetOneShengChanDanTable(x => x.shengchandanhao == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString()) });
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                Query();
            }
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            txtksmc.Text = fm.linkman.MC;
            Query();
        }

        private void txtordernum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择();
            fm.ShowDialog();
            txtordernum.Text = fm.Order.OrderNum;
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "生产计划单列表");
        }

        private void 结束生产单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            生产计划单BLL.结束生产单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString());
            Query();
        }

        private void 重启生产单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            生产计划单BLL.重启生产单(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "shengchandanhao1").ToString());
            Query();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txtjiagongchang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = txtksmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtjiagongchang.Text = fm.linkman.MC;
            Query();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn.FieldName == "ShippingDate" || gridView1.FocusedColumn.FieldName == "SellDate" || gridView1.FocusedColumn.FieldName == "OrderState" || gridView1.FocusedColumn.FieldName == "ProduceSate")
                {
                    Connect.CreatConnect().Update<ShengchanBuliaoInfo>(gridView1.FocusedColumn.FieldName +"='"+ gridView1.GetFocusedValue()+"'", x => x.ID == (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("同步到数据库的时候发送了错误!" + ex.Message);
            }
        }
    }
}
