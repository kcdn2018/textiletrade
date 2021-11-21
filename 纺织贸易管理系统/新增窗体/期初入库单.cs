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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 期初出库单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private int rowindex;

        public 期初出库单()
        {
            InitializeComponent();           
            CreateGrid.Create(this.Name, gridView1);
            gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
            gridView1.Columns["danwei"].ColumnEdit = cmddanwei ;
            gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
            gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
            gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
            gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.IndicatorWidth = 30;           
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
            if(cmbcunfang.Text=="仓库")
            {
                var fm = new 仓库选择();
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
            }
            else
            {
               var fm = new 供货商选择() { linkman=new LXR() { ZJC="",MC="" } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao  = pingzhong.bh;
                danjumingxitables[i].guige = pingzhong.gg;
                danjumingxitables[i].chengfeng = pingzhong.cf;
                danjumingxitables[i].pingming  = pingzhong.pm;
                danjumingxitables[i].kezhong  = pingzhong.kz;          
                danjumingxitables[i].menfu  = pingzhong.mf;
                danjumingxitables[i].danwei  = "米";
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable () { danhao  = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text)});
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择 ();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].OrderNum = fm.Order.OrderNum;
            danjumingxitables[gridView1.FocusedRowHandle].CustomName  = fm.Order.CustomerName ;
            danjumingxitables[gridView1.FocusedRowHandle].ContractNum  = fm.Order.ContractNum ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle);
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
            danju.bz = txtbeizhu.Text;          
            danju.ckmc = cmbcunfang .Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.期初入库单 ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;           
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.own = User.user.YHBH;
            if (useful == FormUseful.新增)
            {
                采购入库单BLL.保存单据(danju, danjumingxitables);
            }
            else
            {

            }
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
            dateEdit1.DateTime = DateTime.Now.Date;
            txtdanhao.Text = BianhaoBLL.CreatDanhao("QCRK", dateEdit1.DateTime,"期初入库");
            danjumingxitables.Clear();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl1.RefreshDataSource();
            useful = FormUseful.新增;
        }

        private void 期初出库单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtdanhao.Text = BianhaoBLL.CreatDanhao("QCRK", dateEdit1.DateTime,DanjuLeiXing.期初入库单);
                dateEdit1.Text = DateTime.Now.ToShortDateString();
                Init();
            }
            else
            {
                Edit();
                if (useful == FormUseful.查看)
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void Edit()
        {
            txtbeizhu.Text = danju.bz;
            txtckmc.Text = danju.StockName;
            cmbcunfang.Text = danju.ckmc;
            txtdanhao.Text = danju.dh;
            dateEdit1.Text = danju.rq.ToShortDateString();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.RefreshDataSource();
        }

        private void cmbcunfang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtckmc.Text = "";
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 期初出库单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao("QCRK", dateEdit1.DateTime,"期初入库");
            }
        }
    }
}
