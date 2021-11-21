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
    public partial class 打样工艺单查询 : Form
    {
        private List<DanjuTable> danjulist = new List<DanjuTable>();
        public 打样工艺单查询()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name , gridView1);
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
            gridView2.IndicatorWidth = 30;
            EndDateEdit.NullDate = DateTime.Now;
            gridView1.Columns["remarker"].ColumnEdit = EndDateEdit;
            gridView1.Columns["yaoqiu"].ColumnEdit = cmbgongyi;
            foreach(var g in DanjuTableService.GetGongYiList ())
            {
                cmbgongyi.Items.Add(g);
            }           
            if (SysInfo.GetInfo.own != "审核制")
            {
                单据审核ToolStripMenuItem.Enabled = false;
            }
        }
        private void 打样工艺单查询_Load(object sender, EventArgs e)
        {
            reflash();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess(this.Name) == true)
            {
                MainForm.mainform.AddMidForm(new 打样工艺单() { Useful = FormUseful.新增 });
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (AccessBLL.CheckAccess("修改打样工艺单") == true)
                {
                    if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                    {
                        MainForm.mainform.AddMidForm(new 打样工艺单() { Useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                    }
                    else
                    {
                        if (SysInfo.GetInfo.own != "审核制")
                        {
                            MainForm.mainform.AddMidForm(new 打样工艺单() { Useful = FormUseful.修改, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
                        }
                        else
                        {
                            MessageBox.Show("对不起!改单据已经审核，如需修改请先取消审核状态！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("您没有权限修改此单据", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("删除打样工艺单"))
            {
                if ((int)(MessageBox.Show("您确定要删除改打样工艺单吗？确定按YES.取消按NO", "提示", MessageBoxButtons.YesNo)) == 6)
                {
                    if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                    {
                        打样单BLL.删除(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                        reflash();
                    }
                    else
                    {
                        MessageBox.Show("该单据已经审核过，不能删除！要删除需先取消审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ExportFile.导出到文件(gridControl1, "打样工艺单");
        }

        private void 单据反审ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL.未审核 (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 审核单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            单据BLL.审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("审核打样工艺单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) == false)
                {
                    单据BLL.审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());

                    MessageBox.Show("审核完成成功！该打样工艺单的结束日期就是审核日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reflash();
                }
                else
                {
                    MessageBox.Show("该单据已经审核过了！无需再次审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("您没有权限审核改单据！请让管理员为你开通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 反审核单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessBLL.CheckAccess("反审核打样工艺单"))
            {
                if (单据BLL.检查是否已经审核(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()))
                {
                    单据BLL.未审核 (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
                    MessageBox.Show("反审核成功！完成日期清空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reflash();
                }
                else
                {
                    MessageBox.Show("该单据还未审核通过！不能反审核", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new DanjuTable() };
            fm.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString();
            var colortables = ShengchandanSeLaoduService.GetShengchandanSeLaodulst(x=>x.shengchandanhao==danhao );
            gridControl2.DataSource = colortables;
            var abcd = ShengchandanHouzhengliService.GetShengchandanHouzhenglilst(x => x.shengchandanhao == danhao);
            if(abcd[0].Value==true )
            {
                checkBoxX1.Checked = abcd[0].Value;
            }
            if (abcd[1].Value == true)
            {
                checkBoxX2.Checked = abcd[1].Value;
            }
            if (abcd[2].Value == true)
            {
                checkBoxX3.Checked = abcd[2].Value;
            }
            if (abcd[3].Value == true)
            {
                checkBoxX4.Checked = abcd[3].Value;
            }
            var yaoqiu = ShengChanDanHouZhengLiYaoQiuService.GetShengChanDanHouZhengLiYaoQiulst(x => x.ShengChanDanHao == danhao);
            txtcicun.Text = yaoqiu[1].YaoQiu;
            txtguangyue.Text = yaoqiu[0].YaoQiu;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reflash();
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void reflash()
        {
           Sunny.UI. UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            if (checkBox1.Checked == true)
            {
                danjulist = DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtghsmc.Text) && x.SaleMan.Contains(txtkehu.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.打样工艺单
                &&x.ordernum.Contains (txtOrdernum.Text) &&x.fromDanhao.Contains (txthetonghao .Text) &&x.StockName.Contains (txtbuliaobianhao.Text) &&x.CarLeixing.Contains (txtpingming.Text )&&x.yaoqiu .Contains (txtgongyimingcheng.Text) );
            }
            else
            {
                danjulist = DanjuTableService.GetDanjuTablelst(x => x.rq >= Convert.ToDateTime(dateEdit1.Text) && x.rq <= Convert.ToDateTime(dateEdit2.Text) && x.ksmc.Contains(txtghsmc.Text) && x.SaleMan.Contains(txtkehu.Text) && x.zhuangtai != "已删除" && x.djlx == DanjuLeiXing.打样工艺单&&x.remarker ==string.Empty
                && x.ordernum.Contains(txtOrdernum.Text) && x.fromDanhao.Contains(txthetonghao.Text) && x.StockName.Contains(txtbuliaobianhao.Text) && x.CarLeixing.Contains(txtpingming.Text) && x.yaoqiu .Contains(txtgongyimingcheng.Text));
            }
                gridControl1.DataSource = danjulist;
            Sunny.UI.UIWaitFormService.HideWaitForm ();
        }

      

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 打样工艺单() { Useful = FormUseful.复制, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 打样工艺单() { Useful = FormUseful.查看, danju = DanjuTableService.GetOneDanjuTable(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString()) });
        }

        private void txtghsmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = txtghsmc.Text, ZJC = "" } };
            fm.ShowDialog();
            txtghsmc.Text = fm.linkman.MC;
            reflash();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { MC = txtkehu.Text, ZJC = "" } };
            fm.ShowDialog();
            txtkehu.Text = fm.linkman.MC;
            reflash();
        }

        private void txtghsmc_KeyDown(object sender, KeyEventArgs e)
        {
            reflash();
        }

        private void EndDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var danju = danjulist.First(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
            danju .remarker = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "remarker").ToString();
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            //gridControl1.RefreshDataSource();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appNotPass1 = new DevExpress.Utils.AppearanceDefault(Color.Black, Color.Salmon, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                DevExpress.Utils.AppearanceDefault appNotPass2 = new DevExpress.Utils.AppearanceDefault(Color.Black, Color.Red, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                if (e.RowHandle > 0)
                {
                    var dr = danjulist[e.RowHandle];
                    if (dr != null)
                    {
                        if (string.IsNullOrWhiteSpace(dr.remarker))
                        {
                            var endate = DateTime.Now;
                            TimeSpan sp = endate.Subtract(dr.rq);
                            if (sp.Days > 7)
                            {
                                e.Appearance.ForeColor  = Color.Red;// 改变行背景颜色
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("显示特定行颜色是发生了错误"+ex.Message );
            }
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            reflash();
        }

        private void txtgongyimingcheng_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            { reflash(); }
        }

        private void 清楚结束日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue (gridView1.FocusedRowHandle, "remarker","");
            var danju = danjulist.First(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
            danju.remarker ="";
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
        }

        private void EndDateEdit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            gridView1.CloseEditor();
            var danju = danjulist.First(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
            danju.remarker = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "remarker").ToString();
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
        }

        private void cmbgongyi_SelectedValueChanged(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var danju = danjulist.First(x => x.dh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString());
            danju.yaoqiu  = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "yaoqiu").ToString();
            DanjuTableService.UpdateDanjuTable(x=>x.yaoqiu ==danju.yaoqiu , x => x.dh == danju.dh);
        }
    }
}
