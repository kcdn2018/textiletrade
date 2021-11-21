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
    public partial class 盘亏出库单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private int rowindex;

        public 盘亏出库单()
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
            if (cmbcunfang.Text == "仓库")
            {
                var fm = new 仓库选择() { stock = new StockInfoTable() { mingcheng = cmbcunfang.Text } };
                fm.ShowDialog();
                txtckmc.Text = fm.stock.mingcheng;
                CreateGrid.CreateKuweiCmb(gridView1, txtckmc.Text);
            }
            else
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC ="",ZJC=""} };
                fm.ShowDialog();
                txtckmc.Text = fm.linkman.MC;
                CreateGrid.ClearKuwei(gridView1);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtckmc.Text == "")
            {
                MessageBox.Show("请先选择仓库名称", "错误", MessageBoxButtons.OK);
                return;
            }
            var fm = new 库存选择() { StockName = txtckmc.Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao = pingzhong.BH;
                danjumingxitables[i].guige = pingzhong.GG;
                danjumingxitables[i].chengfeng = pingzhong.CF;
                danjumingxitables[i].pingming = pingzhong.PM;
                danjumingxitables[i].kezhong = pingzhong.KZ;
                danjumingxitables[i].menfu = pingzhong.MF;
                danjumingxitables[i].danwei = "米";
                danjumingxitables[i].ContractNum = pingzhong.ContractNum;
                danjumingxitables[i].CustomName = pingzhong.CustomName;
                danjumingxitables[i].OrderNum = pingzhong.orderNum;
                danjumingxitables[i].kuanhao = pingzhong.kuanhao;
                danjumingxitables[i].houzhengli = pingzhong.houzhengli;
                danjumingxitables[i].yanse = pingzhong.YS;
                danjumingxitables[i].ganghao = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS;
                danjumingxitables[i].chengpingmishu = pingzhong.MS;
                danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtckmc.Text == "")
            {
                MessageBox.Show("请先选择仓库名称", "错误", MessageBoxButtons.OK);
                return;
            }
            var fm = new 库存选择() { StockName = txtckmc.Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao = pingzhong.BH;
                danjumingxitables[i].guige = pingzhong.GG;
                danjumingxitables[i].chengfeng = pingzhong.CF;
                danjumingxitables[i].pingming = pingzhong.PM;
                danjumingxitables[i].kezhong = pingzhong.KZ;
                danjumingxitables[i].menfu = pingzhong.MF;
                danjumingxitables[i].danwei = "米";
                danjumingxitables[i].ContractNum = pingzhong.ContractNum;
                danjumingxitables[i].CustomName = pingzhong.CustomName;
                danjumingxitables[i].OrderNum = pingzhong.orderNum;
                danjumingxitables[i].kuanhao = pingzhong.kuanhao;
                danjumingxitables[i].houzhengli = pingzhong.houzhengli;
                danjumingxitables[i].yanse = pingzhong.YS;
                danjumingxitables[i].ganghao = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS;
                danjumingxitables[i].chengpingmishu = pingzhong.MS;
                danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                    }
            }
            fm.Dispose();
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
            danju.ckmc = txtckmc .Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.盘亏出库单  ;
            danju.rq = dateEdit1.DateTime;
            danju.StockName  = cmbcunfang.Text ;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu= danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );
            danju.own = User.user.YHBH;
            if (useful == FormUseful.新增)
            {
                ////检查库存。没有不能发货
            var d = 库存BLL.检查库存(danjumingxitables, danju);
            if (d.Bianhao != null)
            {
                var mes = $"该发货单中\n 布料编号:{d.Bianhao }\n 订单号:{d.OrderNum } \n 色号:{d.ColorNum } \n 缸号:{d.ganghao } \n 颜色:{d.yanse }在该仓库中没有！保存失败";
                MessageBox.Show(mes, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ///////
                盘亏出库单BLL .保存单据(danju, danjumingxitables);
            }
            else
            {
                盘亏出库单BLL.修改单据(danju, danjumingxitables);
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        盘亏出库单BLL.单据审核(danju.dh);
                    }
                }
            }
            else
            {
                盘亏出库单BLL.单据审核(danju.dh);
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
            dateEdit1.DateTime = DateTime.Now.Date;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.盘亏出库单, dateEdit1.DateTime,DanjuLeiXing.盘亏出库单);
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

        private void 盘亏出库单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.盘亏出库单 , dateEdit1.DateTime,DanjuLeiXing.盘亏出库单);
                dateEdit1.Text = DateTime.Now.ToShortDateString();
                danju.dh = txtdanhao.Text;
            }
            else
            {
              
                Edit();  
                if(useful==FormUseful.查看 )
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;           
            txtckmc.Text = danju.ckmc;
            cmbcunfang.Text = danju.StockName;
            dateEdit1.Text = danju.rq.ToShortDateString();
        }

        private void cmbcunfang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                txtckmc.Text = "";
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 盘亏出库单_FormClosing(object sender, FormClosingEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.盘亏出库单 , dateEdit1.DateTime, DanjuLeiXing.盘亏出库单);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
