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
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 发票开具单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public int rowindex;
        public DanjuTable danju = new DanjuTable();
        public 发票开具单()
        {
            InitializeComponent();
           
            CreateGrid.Create(this.Name , gridView1);
            //gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
            //gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
            gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
            gridView1.Columns["suilv"].ColumnEdit = cmbsuilv;
            //gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
            //gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
            //gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
            //gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
            //gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
            //gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.IndicatorWidth = 30;
           
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var fm = new 客户选择() { linkman=new LXR() { MC="",ZJC =""  } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
        }
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            gridControl2.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex  =gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle,this );
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                switch (gridView1.FocusedColumn.FieldName)
                {
                    case "hanshuiheji":
                        danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia = Math.Round(danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji / danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu, 2);
                        计算未税单价();
                        break;
                    case "hanshuidanjia":
                        danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                        计算未税单价();
                        break;
                    case "weishuidanjia":
                        计算含税单价();
                        danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;                      
                        break;
                    case "chengpingmishu":
                        danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                        break;
                }
                gridControl2.RefreshDataSource();
            }
            catch
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }
        private void 计算含税单价()
        {
            decimal suilv = 13;
            try
            {
                suilv = danjumingxitables[gridView1.FocusedRowHandle].suilv.Split('%')[0].TryToDecmial(0);
            }
            catch
            {
                danjumingxitables[gridView1.FocusedRowHandle].suilv = "13%";
                suilv = 13;
            }
            danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia  = Math.Round(danjumingxitables[gridView1.FocusedRowHandle].weishuidanjia * (1 + suilv / 100), 2);
        }
        private void 计算未税单价()
        {         
            decimal suilv = 13;
            try
            {
                suilv = danjumingxitables[gridView1.FocusedRowHandle].suilv.Split('%')[0].TryToDecmial(0);
            }
            catch
            {
                danjumingxitables[gridView1.FocusedRowHandle].suilv = "13%";
                suilv = 13;
            } 
            danjumingxitables[gridView1.FocusedRowHandle].weishuidanjia = Math.Round(danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia / (1 + suilv / 100), 2);
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.pingming) ).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            danju.bz = txtbeizhu.Text;        
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.发票开具 ;
            danju.rq = dateEdit1.DateTime ;
            danju.Hanshui = "含税";
            danju.own = User.user.YHBH;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji) + txtyouhuipiaoe.Text.ToDecimal();
            danju.totalmoney = txtyouhuipiaoe.Text.ToDecimal();
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.jiagongleixing = cmbleixing.Text;
            if (useful == FormUseful.新增)
            {
                if (DanjuTableService.GetDanjuTablelst(x => x.dh == txtdanhao.Text).Count == 0)
                {
                    财务BLL.减少应开发票(danju);
                    来往明细BLL.增加来往记录(danju);
                    单据BLL.单据保存(danju, danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.pingming)).ToList());
                }
                else
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该发票号码已经存在!保存失败");
                    return;
                }
            }
            else
            {
                var olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == txtdanhao.Text);
                财务BLL.增加应开发票(olddanju );
                来往明细BLL.删除来往记录(olddanju );
                财务BLL.减少应开发票(danju);
                来往明细BLL.增加来往记录(danju);
                单据BLL.修改单据(danju, danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.pingming) ).ToList());
            }
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
            txtyouhuipiaoe.Text = "0.00";
            //txtdanhao.Text = BianhaoBLL.CreatDanhao("CGD",dateEdit1.DateTime );
            dateEdit1.DateTime = DateTime.Now;
            danjumingxitables.Clear();
            //danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 ; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl2.DataSource = danjumingxitables;
            gridControl2.RefreshDataSource ();
            useful = FormUseful.新增;
        }

        private void 采购入库单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                //txtdanhao.Text = BianhaoBLL.CreatDanhao("KFP", dateEdit1.DateTime);
                dateEdit1.DateTime = DateTime.Now;
                Init();
            }
            else
            {
                Edit();
            }
         
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;       
            txtkehu.Text = danju.ksmc;
            dateEdit1.DateTime = danju.rq.Date;
            txtyouhuipiaoe.Text = danju.totalmoney.ToString();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl2.DataSource = danjumingxitables;
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }    
    }
}
