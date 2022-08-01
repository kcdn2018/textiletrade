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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 盘盈入库单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public int rowindex;
        public DanjuTable danju = new DanjuTable();
        public 盘盈入库单()
        {
            InitializeComponent();          
            CreateGrid.Create(this.Name , gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.Columns["Rangchang"].ColumnEdit = btnRangchang;
                gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
                gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
                gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null ,null );
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 供货商选择() { linkman=new LXR() { ZJC=txtckmc.Text } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;           
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cmbcunfang.Text == "仓库")
            {
                var fm = new 仓库选择() { stock = new StockInfoTable() { mingcheng = cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
                CreateGrid.CreateKuweiCmb(gridView1, txtckmc.Text);
            }
            else
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC = "",ZJC="" } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                CreateGrid.ClearKuwei(gridView1);
            }
        }
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectProductHelper.Select(gridView1, danjumingxitables);
            gridControl1.RefreshDataSource();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OrderDetailSelect.SelectDetail(gridView1, danjumingxitables);
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;           
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle,this);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                gridControl1.RefreshDataSource();
            }
            catch 
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxitables.Sum(x => x.chengpingmishu) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtckmc.Text.TrimEnd()))
            {
                MessageBox.Show("请选择收货地址或者供货商！保存失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息，请选择相应的布料后再保存！");
                return;
            } 
            UIWaitFormService.ShowWaitForm("正在保存！。。。。");
            danju.bz = txtbeizhu.Text;
            danju.ckmc = txtckmc .Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.盘盈入库单  ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;
            danju.own = User.user.YHBH;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );         
            if (useful == FormUseful.新增)
            {
                盘盈入库单BLL .保存单据(danju, danjumingxitables);
            }
            else
            {
                盘盈入库单BLL.修改单据(danju, danjumingxitables);
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        盘盈入库单BLL .单据审核(danju.dh);
                    }
                }
            }
            else
            {
                盘盈入库单BLL .单据审核(danju.dh);
            }
            UIWaitFormService.HideWaitForm();
            AlterDlg.Show("保存成功！");
            //清空所有控件
            Init();
        }
        private void Init()
        { 
            foreach (Control  c in this.groupControl1.Controls  )
            {
                if(c is DevComponents.DotNetBar.Controls.TextBoxX||c is DevExpress.XtraEditors.ButtonEdit  )
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.盘盈入库单, dateEdit1.DateTime,DanjuLeiXing.盘盈入库单);
            danjumingxitables.Clear();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl1.DataSource=danjumingxitables;
            useful = FormUseful.新增;
        }

        private void 盘盈入库单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit(); 
            }
            gridControl1.DataSource = danjumingxitables;
        }
        private void Edit()
        {
            txtbeizhu.Text = danju.bz;
            txtckmc.Text = danju.ckmc  ;
            cmbcunfang.Text = danju.StockName; 
            txtdanhao.Text = danju.dh;
           dateEdit1.DateTime=danju.rq;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
        }

        private void cmbcunfang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtckmc.Text = "";
            }
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].yanse  = fm.colorInfo.ColorName ;
            danjumingxitables[gridView1.FocusedRowHandle].ColorNum  = fm.colorInfo.ColorNum ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.盘盈入库单 , dateEdit1.DateTime, DanjuLeiXing.盘盈入库单);
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void btnRangchang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].Rangchang = fm.linkman.MC;
            gridView1.CloseEditor();
            gridControl1.RefreshDataSource();
        }

        private void colorbtn_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode==Keys.Enter )
            {
                gridView1.CloseEditor();
                var colorlist = ColorTableService.GetColorTablelst (x => x.ColorNum.Contains(danjumingxitables[gridView1.FocusedRowHandle].yanse));
                ColorTable color  = new ColorTable();
                if (colorlist.Count > 1)
                {
                    var fm = new 色号选择() { colorInfo = new ColorTable() { ColorNum = danjumingxitables[gridView1.FocusedRowHandle].yanse } };
                    fm.ShowDialog();
                    color = fm.colorInfo;
                }
                else
                {
                    if (colorlist.Count == 1)
                    {
                        color = colorlist[0];
                    }
                }
                if (!string.IsNullOrEmpty(color.ColorNum))
                {
                    danjumingxitables[gridView1.FocusedRowHandle].ColorNum = color.ColorNum;
                    danjumingxitables[gridView1.FocusedRowHandle].yanse = color.ColorName;
                }
                gridControl1.RefreshDataSource();
            }
        }
    }
}
