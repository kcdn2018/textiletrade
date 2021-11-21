using BLL;
using Model;
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
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 产量登记 : Form
    {
        public List<danjumingxitable> danjumingxis { get; set; } = new List<danjumingxitable>();
        public int Useful { get;  set; }
        public DanjuTable danju { get; set; }

        public 产量登记()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            var conMenu = new ContexMenuEX() { formName = this.Name, gridControl = gridControl1, gridView = gridView1, menuStrip = contextMenuStrip1 };
            conMenu.Init();
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (txtckmc.Text == "")
                {
                    Sunny.UI.UIMessageBox.Show ("请先选择仓库名称", "错误");
                    return;
                }
                var fm = new 库存选择() { StockName = txtckmc.Text };
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;

                foreach (var pingzhong in fm.pingzhong)
                {

                    danjumingxis[i].bizhong = "人民币￥";
                    danjumingxis[i].Bianhao = pingzhong.BH;
                    danjumingxis[i].guige = pingzhong.GG;
                    danjumingxis[i].chengfeng = pingzhong.CF;
                    danjumingxis[i].pingming = pingzhong.PM;
                    danjumingxis[i].kezhong = pingzhong.KZ;
                    danjumingxis[i].menfu = pingzhong.MF;
                    danjumingxis[i].danwei = "米";
                    danjumingxis[i].ContractNum = pingzhong.ContractNum;
                    danjumingxis[i].CustomName = pingzhong.CustomName;
                    danjumingxis[i].OrderNum = pingzhong.orderNum;
                    danjumingxis[i].kuanhao = pingzhong.kuanhao;
                    danjumingxis[i].houzhengli = pingzhong.houzhengli;
                    danjumingxis[i].yanse = pingzhong.YS;
                    danjumingxis[i].Chengpingyanse = pingzhong.YS;
                    danjumingxis[i].ganghao = pingzhong.GH;
                    danjumingxis[i].chengpingjuanshu = 0;
                    danjumingxis[i].chengpingmishu = 0;
                    danjumingxis[i].Kuwei = pingzhong.Kuwei;
                    danjumingxis[i].Huahao = pingzhong.Huahao;
                    danjumingxis[i].ColorNum = pingzhong.ColorNum;
                    danjumingxis[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxis[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    danjumingxis[i].rq = dateEdit1 .DateTime;
                    danjumingxis[i].IsHanshui = IsHanshuiModel.含税;
                    danjumingxis[i].suolv  =pingzhong.ID ;
                    danjumingxis[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                    && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                    danjumingxis[i].hanshuiheji = danjumingxis[i].hanshuidanjia * pingzhong.MS;
                    i++;
                    if (i == danjumingxis.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                        }
                }
                var mingxi = danjumingxis[0];             
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }

        private void 产量登记_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                if (Useful == FormUseful.修改)
                {
                    Edit();
                }
                else
                {
                    if (Useful == FormUseful.复制)
                    {
                        Edit();
                        dateEdit1.DateTime = DateTime.Now.Date;
                        txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.成品登记, dateEdit1.DateTime, DanjuLeiXing.成品登记单);
                        Useful = FormUseful.新增;
                    }
                    else
                    {
                        Edit();
                        保存ToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        private void Init()
        {
            danju = new DanjuTable();
            txtbeizhu.Text = "";
            txtckmc.Text = "";
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.成品登记 , dateEdit1.DateTime,DanjuLeiXing.成品登记单 );
            danjumingxis.Clear();
            for (int i = 0; i < 30; i++)
            {
                danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text });
            }
            gridControl1.DataSource = danjumingxis;
            gridControl1.RefreshDataSource();
            Useful = FormUseful.新增;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            dateEdit1.DateTime = danju.rq;
            txtckmc.Text = danju.ckmc;
            //备注
            txtbeizhu.Text = danju.bz;
            danjumingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            for (int i = danjumingxis.Count; i <30; i++)
            {
                danjumingxis.Add(new danjumingxitable() { danhao = danju.dh });
            }
            gridControl1.DataSource = danjumingxis;
            gridControl1.RefreshDataSource();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxis .Where(x => x.Bianhao != null).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            danju.bz = txtbeizhu.Text;       
            danju.ckmc = txtckmc.Text;
            danju.StockName = "仓库";
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.成品登记单 ;
            danju.rq = dateEdit1.DateTime.Date ;
            danju.shouhuodizhi = txtckmc.Text;
            danju.own = User.user.YHBH;
            danju.zhuangtai = "未审核";
            if (Useful == FormUseful.新增)
            {
                产量登记单BLL .保存单据(danju, danjumingxis);
            }
            else
            {
                产量登记单BLL .修改单据(SQLHelper.SQLHelper.CreatNewInstance(danju), SQLHelper.SQLHelper.CreatNewInstanceList(danjumingxis));
            }
            if (SysInfo.GetInfo.own != null)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        产量登记单BLL .单据审核(danju.dh);
                    }
                }
            }
            AlterDlg.Show("保存成功！");
            Thread.Sleep(1000);
            //清空所有控件
            Init();
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 仓库选择();
            fm.ShowDialog();
            txtckmc.Text = fm.stock.mingcheng;
        }
    }
}
