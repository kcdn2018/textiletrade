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
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 来货退卷单 : Form
    {
        public DanjuTable  danju { get; set; }
        private List<danjumingxitable > danjumingxitables = new List<danjumingxitable >();
        public int Useful { get; set; }
        private int rowindex = 0;
        public 来货退卷单()
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
                    txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.生产退卷单  , uiDatePicker1.Value ,DanjuLeiXing.退卷单 );
                    txtkehu.Text = "";
                danjumingxitables.Clear();
                    for (int i = 0; i < 30; i++)
                    {
                    danjumingxitables.Add(new danjumingxitable() { danwei ="米"});
                    }
                gridControl1.DataSource = danjumingxitables;
                gridControl1.RefreshDataSource();
            }
            else
            {
                txtdanhao.Text = danju.dh;
                txtkehu.Text = danju.ksmc  ;
                uiDatePicker1.Value =danju.rq ;
                txtckmc.Text = danju.ckmc;
                txtbeizhu.Text = danju.bz;
                danjumingxitables = danjumingxitableService.Getdanjumingxitablelst (x => x.danhao == danju.dh);
                for(int i= danjumingxitables.Count;i<30;i++)
                {
                    danjumingxitables.Add(new danjumingxitable() { danwei = "米" });
                }
                gridControl1.DataSource = danjumingxitables;
                gridControl1.RefreshDataSource();
            }
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1 .CloseEditForm ();
                if (danjumingxitables.Where(x => x.pingming  != null).ToList().Count == 0)
                {
                    Sunny.UI.UIMessageBox.ShowError("保存失败！没有任何布料！如果有布料品名必须要填写!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtkehu.Text))
                {
                    Sunny.UI.UIMessageBox.ShowError("保存失败！请选择客户");
                    return;
                }
                danju.bz = txtbeizhu.Text;
                danju.ksmc  = txtkehu.Text;
                danju.dh = txtdanhao.Text;
                danju.djlx = DanjuLeiXing.退卷单 ;
                danju.rq = uiDatePicker1.Value.Date ;
                danju.ckmc = txtckmc.Text;
                danju.StockName = cmbcunfang.Text;
                danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
                danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
                danju.zhuangtai = "未审核";
                danju.wuliugongsi = txtWuliuInfo.Text;
                danju.shouhuodizhi = txtShouhuodizhi.Text;
                danju.own = User.user.YHBH;
                if (Useful == FormUseful.新增)
                {
                    来货退卷单BLL .保存(danju, danjumingxitables);
                }
                else
                {
                    来货退卷单BLL.修改单据 (danju, danjumingxitables);
                }
                Sunny.UI.UIMessageDialog.ShowSuccessDialog (this, "保存单据成功");
            }
            catch(Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "保存单据的时候发生了错误" + ex.Message);
                
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
            CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle,this );
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = uiDatePicker1.Value  });
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
                    danjumingxitables[i].Chengpingyanse = pingzhong.YS;
                    danjumingxitables[i].ganghao = pingzhong.GH;
                    danjumingxitables[i].chengpingjuanshu = pingzhong.JS;
                    danjumingxitables[i].chengpingmishu = pingzhong.MS;
                    danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                    danjumingxitables[i].Huahao = pingzhong.Huahao;
                    danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                    danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    danjumingxitables[i].rq = uiDatePicker1 .Value ;
                    danjumingxitables[i].IsHanshui = IsHanshuiModel.含税;
                    danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                    && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                    danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(uiDatePicker1 .Text) });
                        }
                }
                fm.Dispose();
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印退卷单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "退卷单.frx", PrintModel.Privew);
        }
        private void InitDanju()
        {
            danju.bz = txtbeizhu.Text;        
            danju.ckmc = txtckmc.Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.退卷单; 
            danju.Hanshui = IsHanshuiModel.含税;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji) + danjumingxitables.Sum(x => x.weishuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);       
            danju.own = User.user.YHBH;
            danju.ksmc = txtkehu.Text;
            danju.shouhuodizhi = txtShouhuodizhi.Text;
            danju.rq = uiDatePicker1.Value.Date;
            danju.wuliugongsi = txtWuliuInfo.Text;
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印退卷单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "退卷单.frx", PrintModel.Design);
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印退卷单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "退卷单.frx", PrintModel.Print );
        }
    }
}
