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
    public partial class 发货通知单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public int rowindex;
        public DanjuTable danju = new DanjuTable();
        public 发货通知单()
        {
            InitializeComponent();          
            CreateGrid.Create(this.Name, gridView1);
            gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
            gridView1.Columns["danwei"].ColumnEdit = cmddanwei ;
            commaitou.Items.AddRange(Tools.获取模板.获取所有模板(PrintPath.唛头模板).ToArray ());
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择 () { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
            txtshouhuo.Text = fm.linkman.bz;
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
                danjumingxitables[i].FrabicWidth = pingzhong.FrabicWidth;
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
                danjumingxitables[i].toupimishu = pingzhong.MS;
                danjumingxitables[i].chengpingmishu = pingzhong.MS;
                danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                danjumingxitables[i].rq = danju.rq;
                danjumingxitables[i].PiBuChang = pingzhong.PibuChang;
                danjumingxitables[i].Pihao = pingzhong.Pihao;
                danjumingxitables[i].IsHanshui = QueryTime.IsTax;
                danjumingxitables[i].AveragePrice = pingzhong.AvgPrice;
                danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
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
                danjumingxitables[i].FrabicWidth = pingzhong.FrabicWidth;
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
                danjumingxitables[i].toupimishu = pingzhong.MS;
                danjumingxitables[i].chengpingmishu = pingzhong.MS;
                danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                danjumingxitables[i].rq = danju.rq;
                danjumingxitables[i].PiBuChang = pingzhong.PibuChang;
                danjumingxitables[i].Pihao = pingzhong.Pihao;
                danjumingxitables[i].IsHanshui = QueryTime.IsTax;
                danjumingxitables[i].AveragePrice = pingzhong.AvgPrice;
                danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
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
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex  =gridView1.FocusedRowHandle;
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
            赋值单据();
            if (useful == FormUseful.新增)
            {
                单据BLL.单据保存(danju, danjumingxitables.Where (x=>!string.IsNullOrEmpty (x.Bianhao )).ToList ());
            }
            else
            {
                单据BLL.修改单据(danju, danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            }
            //清空所有控件
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        单据BLL .审核 (danju.dh);
                    }
                }
            }
            else
            {
                单据BLL .审核(danju.dh);
            }
            AlterDlg.Show("保存成功！");
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
            dateEdit1.DateTime = DateTime.Now ;
            dt_lasttime.DateTime = DateTime.Now;
            dt_loadingtime.DateTime = DateTime.Now;
            dt_fahuo.DateTime = DateTime.Now;
            cmb_fahuofangshi.Text =string.Empty;
            cmb_fukuanfangshi.Text = string.Empty;
            txtshouhuo.Text = string.Empty;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.发货通知单 , dateEdit1.DateTime, DanjuLeiXing.发货通知单);
            danjumingxitables.Clear();
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            danju.own = User.user.YHBH;
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
            dt_fahuo.DateTime = danju.Deliverytime;
            dt_lasttime.DateTime = danju.LastTime;
            dt_loadingtime.DateTime = danju.LastHoldingtime;
            cmb_fahuofangshi.Text = danju.CarLeixing ;
            cmb_fukuanfangshi.Text = danju.Qiankuan;
            txtshouhuo.Text = danju.shouhuodizhi;
            txtckmc.Text = danju.ckmc ;           
            cmbcunfang.Text = danju.StockName ;
            txtkehu.Text = danju.ksmc;
            commaitou.Text = danju.jiagongleixing ;
            txtyundanhao.Text = danju.wuliuBianhao;
           dateEdit1.DateTime=danju.rq;
            txtyewuyuan.Text = danju.SaleMan;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
        }
        private void 赋值单据()
        {
            danju.bz = txtbeizhu.Text;
            danju.ckmc = txtckmc .Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.发货通知单;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtshouhuo.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.Deliverytime = dt_fahuo .DateTime;
            danju.LastHoldingtime = dt_loadingtime.DateTime;
            danju.LastTime = dt_lasttime.DateTime ;
            danju.CarLeixing = cmb_fahuofangshi.Text;
            danju.Qiankuan = cmb_fukuanfangshi.Text;
            danju.StockName = cmbcunfang.Text;
            danju.SaleMan = txtyewuyuan.Text;
            ///物流编号对应运单号
            danju.wuliuBianhao = txtyundanhao.Text;
            ///外唛模板
            danju.jiagongleixing = commaitou.Text;
            danju.own = User.user.YHBH;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            赋值单据();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货通知单.frx", PrintModel.Design);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            赋值单据();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货通知单.frx", PrintModel.Privew);
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            赋值单据();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货通知单.frx", PrintModel.Print);
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 发货通知单_FormClosed(object sender, FormClosedEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.发货通知单 , dateEdit1.DateTime, DanjuLeiXing.发货通知单);
            }
        }

        private void txtyewuyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择();
            fm.ShowDialog();
            txtyewuyuan.Text = fm.linkman.Xingming;
        }
    }
}
