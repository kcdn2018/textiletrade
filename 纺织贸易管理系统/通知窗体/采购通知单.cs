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
    public partial class 采购通知单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public int rowindex;
        public DanjuTable danju = new DanjuTable();
        public 采购通知单()
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
           var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
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
               var fm = new 供货商选择() { linkman=new LXR() { ZJC=txtckmc.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                txtlianxidianhua.Text = fm.linkman.DH;
                txtLianxiren.Text = fm.linkman.Lxr;
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectProductHelper.Select(gridView1, danjumingxitables);
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OrderDetailSelect.SelectDetail(gridView1, danjumingxitables,false );
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
                danjumingxitables[gridView1.FocusedRowHandle].hanshuiheji = danjumingxitables[gridView1.FocusedRowHandle].hanshuidanjia * danjumingxitables[gridView1.FocusedRowHandle].chengpingmishu;
                gridControl1.RefreshDataSource();
            }
            catch 
            {
                MessageBox.Show("请输入数字。计算错误");
            }
        }
        private void 赋值单据()
        {
            danju.bz = txtbeizhu.Text;
            danju.ckmc = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.采购通知单;
            danju.rq = dateEdit1.DateTime ;
            danju.shouhuodizhi = txtckmc.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.own = User.user.YHBH;
            danju.lianxiren = txtLianxiren.Text;
            danju.totalmoney = danjumingxitables.Sum(x => x.hanshuiheji );
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxitables.Sum(x => x.chengpingmishu) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return;
            }
            if (danjumingxitables.Where(x =>!string.IsNullOrWhiteSpace(x.Bianhao )).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            赋值单据();
            if (useful == FormUseful.新增)
            {
                单据BLL.单据保存(danju, danjumingxitables.Where (x=>!string.IsNullOrWhiteSpace (x.Bianhao )).ToList ());
            }
            else
            {
                单据BLL.修改单据(danju, danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)).ToList());
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        单据BLL.审核(danju.dh);
                    }
                }
            }
            else
            {
                单据BLL.审核(danju.dh);
            }
            AlterDlg.Show("保存成功！");
            //清空所有控件
            Init();
        }
        private void Init()
        {
            foreach (Control c in this.groupControl1.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            } 
            dateEdit1.DateTime  = DateTime.Now ;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购通知单 , dateEdit1.DateTime, DanjuLeiXing.采购通知单);
            comhanshui.Text = QueryTime.IsTax;
            danjumingxitables.Clear();
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            useful = FormUseful.新增;
        }

        private void 采购入库单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
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
            txtckmc.Text = danju.shouhuodizhi;
            cmbcunfang.Text = danju.ckmc ;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;       
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
            txtLianxiren.Text = danju.lianxiren;
           dateEdit1.DateTime=danju.rq;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            if(useful==FormUseful.复制 )
            {
                useful = FormUseful.新增;
                dateEdit1.DateTime = DateTime.Now;
                danjumingxitables.ForEach(x => x.danhao = txtdanhao.Text) ;
                danjumingxitables.ForEach(x => x.rq = dateEdit1.DateTime);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDanju(PrintModel.Design);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
            PrintDanju(PrintModel.Privew);
        }

        private void PrintDanju(int printModel)
        { 
            赋值单据();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x =>!string.IsNullOrWhiteSpace(x.pingming)).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "采购通知单.frx", printModel);
        }
        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDanju(PrintModel.Print);
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购通知单 , dateEdit1.DateTime, DanjuLeiXing.采购通知单);
            }
        }
    }
}
