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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 来货入库单 : Form
    {
        public DanjuTable  danju { get; set; }
        private List<danjumingxitable > danjumingxis = new List<danjumingxitable >();
        public int Useful { get; set; }
        private int rowindex = 0;
        public 来货入库单()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["pingming"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.Columns["ColorNum"].ColumnEdit = colorbtn;
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
        }

        private void 来货入库单_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            if (Useful == FormUseful.新增)
            {
                danju = new DanjuTable();
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.生产入库单, uiDatePicker1.Value, DanjuLeiXing.入库单);
                txtkehu.Text = "";
                txtFahuodanwei.Text = string.Empty;
                txtbeizhu.Text = string.Empty;
                danjumingxis.Clear();
                for (int i = 0; i < 30; i++)
                {
                    danjumingxis.Add(new danjumingxitable() { danwei = "米" });
                }
                gridControl1.DataSource = danjumingxis;
                gridControl1.RefreshDataSource();
            }
            else
            {
                txtdanhao.Text = danju.dh;
                txtkehu.Text = danju.ksmc  ;
                uiDatePicker1.Value =danju.rq ;
                txtckmc.Text = danju.ckmc;
                txtbeizhu.Text = danju.bz;
                txtFahuodanwei.Text = danju.fromDanhao;
                danjumingxis =danjumingxitableService.Getdanjumingxitablelst (x => x.danhao == danju.dh);
                for(int i=danjumingxis.Count;i<30;i++)
                {
                    danjumingxis.Add(new danjumingxitable() { danwei = "米" });
                }
                gridControl1.DataSource = danjumingxis;
                gridControl1.RefreshDataSource();
            }
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///手动输入客户
            if (string.IsNullOrWhiteSpace(danju.ksbh))
            {
                var lianxiren = LXRService.GetOneLXR(x => x.MC == txtkehu.Text);
                if (string.IsNullOrWhiteSpace(lianxiren.MC))
                {
                    Sunny.UI.UIMessageBox.Show($"该客户{txtkehu.Text}名称在客户资料中没有匹配到！\r\n请检查输入的客户名是否正确");
                    return;
                }
                else
                {
                    danju.ksbh = lianxiren.BH;
                }
            }
            if(string.IsNullOrWhiteSpace (txtFahuodanwei .Text ))
            {
                UIMessageBox.ShowError("发货地址不能为空！\r\n请输入发货地址");
                return;
            }
            if (danjumingxis.Where (x=>!string.IsNullOrWhiteSpace ( x.pingming)&&string.IsNullOrWhiteSpace ( x.Bianhao )).ToList ().Count >0)
            {
                UIMessageBox.ShowError("有布料的品名有信息但是编号为空！\r\n请输入正确的布料编号");
                return;
            }
            //if (string.IsNullOrWhiteSpace(txtbeizhu.Text))
            //{
            //    UIMessageBox.ShowError("请输入要加工的类型及其要求和主要事项！");
            //    return;
            //}
            try
            {
                gridView1 .CloseEditForm ();
                if (danjumingxis.Where(x => x.pingming  != null).ToList().Count == 0)
                {
                    Sunny.UI.UIMessageBox.ShowError("保存失败！没有任何布料！如果有布料品名必须要填写!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtkehu.Text))
                {
                    Sunny.UI.UIMessageBox.ShowError("保存失败！请选择客户");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtckmc.Text))
                {
                    Sunny.UI.UIMessageBox.ShowError("保存失败！请选择仓库名称");
                    return;
                }
                danju.bz = txtbeizhu.Text;
                danju.ksmc  = txtkehu.Text;
                danju.dh = txtdanhao.Text;
                danju.djlx = DanjuLeiXing.入库单;
                danju.rq = uiDatePicker1.Value.Date ;
                danju.ckmc = txtckmc.Text;
                danju.StockName = cmbcunfang.Text;
                danju.totaljuanshu = danjumingxis .Sum(x => x.chengpingjuanshu);
                danju.TotalMishu = danjumingxis.Sum(x => x.chengpingmishu);
                danju.zhuangtai = "未审核";
                danju.own = User.user.YHBH;
                ///fromDanhao就是真实的发货地址
                danju.fromDanhao = txtFahuodanwei.Text;
                if (Useful == FormUseful.新增)
                {
                    生产入库单BLL.保存(danju, danjumingxis);                   
                }
                else
                {
                  生产入库单BLL.修改单据 (danju, danjumingxis);
                }
            }
            catch(Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "保存单据的时候发生了错误" + ex.Message);                
            }
            if (Sunny.UI.UIMessageDialog .ShowAskDialog (this,"单据保存成功！\r\n是否直接开生产流转卡？\r\n直接开按确定。否则按取消") == true)
            {
                MainForm.mainform.AddMidForm (new 流转卡() {danjumingxis =danjumingxitableService.Getdanjumingxitablelst (x=>x.danhao ==txtdanhao.Text ),Useful=FormUseful.复制 ,danju =new DanjuTable() { ksmc = txtkehu.Text, ksbh = danju.ksbh,ckmc =txtckmc .Text ,bz =txtbeizhu.Text } });
            }
            Useful = FormUseful.新增;
            Init();
        }
        private void txtkehu_ButtonCustomClick(object sender, EventArgs e)
        {
            var fm = new 客户选择();
            fm.ShowDialog();
            if(fm.linkman  !=null)
            {
                danju.ksbh   = fm.linkman.BH ;
                txtkehu.Text = fm.linkman.MC ;
            }
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxis , rowindex, gridView1, gridView1.FocusedRowHandle);
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxis .Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = uiDatePicker1.Value  });
            gridControl1.RefreshDataSource();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 仓库选择();
            fm.ShowDialog();
            txtckmc.Text = fm.stock.mingcheng;
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var fm = new 品种选择();
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxis[i].bizhong = "人民币￥";
                    danjumingxis[i].Bianhao = pingzhong.bh;
                    danjumingxis[i].guige = pingzhong.gg;
                    danjumingxis[i].chengfeng = pingzhong.cf;
                    danjumingxis[i].pingming = pingzhong.pm;
                    danjumingxis[i].kezhong = pingzhong.kz;
                    danjumingxis[i].menfu = pingzhong.mf;
                    danjumingxis[i].danwei = "米";
                    i++;
                    if (i == danjumingxis.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(uiDatePicker1.Text) });
                        }
                }
                fm.Dispose();
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }

        private void 选择工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 工艺选择();
            fm.ShowDialog();
            foreach (var t in fm.technologyTables )
            {
                txtbeizhu.Text += t.Technology + "+";
            }
            txtbeizhu.Text = txtbeizhu.Text.Substring(0, txtbeizhu.Text.Length - 1);
        }

        private void 复制单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.Focus();
            SendKeys.Send("^c");
        }

        private void 粘贴单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.Focus();
            SendKeys.Send("^v");
        }

        private void ButtonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (gridView1.FocusedColumn.FieldName == "pingming")
                    {
                        gridView1.CloseEditor();
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pingming") != null)
                        {
                            var pingming = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pingming").ToString();
                            if (!string.IsNullOrWhiteSpace(pingming))
                            {
                                var pingzhong = dbService.GetOnedb(x => x.pm == pingming);
                                if (string.IsNullOrWhiteSpace(pingzhong.bh))
                                {
                                    Sunny.UI.UIMessageBox.Show("该品名没有对应的编号！\r\n请检查品名输入是否正确。");
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Bianhao", pingzhong.bh);
                                    gridControl1.RefreshDataSource();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Sunny.UI.UIMessageBox.ShowError(ex.Message);
                }
            }
         }
    }
}
