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
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 采购退货单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private List<JuanHaoTable> juanList = new List<JuanHaoTable>();
        private int rowindex;

        public 采购退货单()
        {
            InitializeComponent();           
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create("销售发货单", gridView2);
            gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
            gridView1.Columns["danwei"].ColumnEdit = cmddanwei ;
            //gridView1.Columns["color"].ColumnEdit = colorbtn;
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

        private void txtwuliu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择();
            fm.ShowDialog();
            danju.wuliuBianhao  = fm.linkman.Bianhao  ;
            txtwuliu.Text = fm.linkman.name ;
            var wuliu= WuliuTableService.GetOneWuliuTable(x => x.Bianhao == fm.linkman.Bianhao );
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;            
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
            if (!SelectStockHelper.Select(txtckmc, gridView1, danjumingxitables))
            {
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
                加载卷();
            }
        }


        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            加载卷();
            gridView2.ClearSelection();
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
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
        private List<JuanHaoTable> CreatJuanhao()
        {
            var juan = new List<JuanHaoTable>();
            foreach (var j in gridView2.GetSelectedRows())
            {
                juan.Add(juanList[j]);
            }
            return juan;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxitables.Sum(x => x.chengpingmishu) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return;
            }
            if (gridView2.SelectedRowsCount == 0)
            {
                if (juanList.Count > 0)
                {
                    MessageBox.Show("没有任何卷被选中！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (txtckmc.Text == "" || txtkehu.Text == "")
            {
                MessageBox.Show("请选择收货地址或者供货商！保存失败", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = txtckmc.Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.采购退货单 ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei =txtyunfei.Text.TryToDecmial();
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.ChaCheFei = txtChachefei.Text.TryToDecmial();
            danju.ZhuangXieFei = txtzhuangxiefei.Text.TryToDecmial();
            danju.zhuangtai = "未审核";
            danju.own = User.user.YHBH;
            ////检查库存。没有不能发货
            if (useful == FormUseful.新增)
            {
                var d = 库存BLL.检查库存(danjumingxitables, txtckmc.Text );
                if (d.Bianhao != null)
                {
                    var mes = $"该发货单中\n 布料编号:{d.Bianhao }\n 订单号:{d.OrderNum } \n 色号:{d.ColorNum } \n 缸号:{d.ganghao } \n 颜色:{d.yanse }在该仓库中没有！保存失败";
                    MessageBox.Show(mes, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            ///////
            if (useful == FormUseful.新增)
            {
               采购退货单BLL .保存单据 (danju, danjumingxitables,CreatJuanhao());
            }
            else
            {
                采购退货单BLL.修改单据(danju, danjumingxitables,CreatJuanhao());
            }
            if (SysInfo.GetInfo.own !=string.Empty )
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        采购退货单BLL .单据审核(danju.dh);
                    }
                }
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
            dateEdit1.DateTime = DateTime.Now ;
            comhanshui.Text = QueryTime.IsTax;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购退货单 , dateEdit1.DateTime, DanjuLeiXing.采购退货单);
            txtChachefei.Text = "0";
            txtyunfei.Text = "0";
            txtzhuangxiefei.Text = "0";
            danjumingxitables.Clear();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            juanList.Clear();
            gridControl2.RefreshDataSource();
            useful = FormUseful.新增;
        }

        private void 采购退货单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit();
                if(useful==FormUseful.查看 )
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.shouhuodizhi;
            cmbcunfang.Text = danju.StockName;
            txtckmc.Text = danju.ckmc;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
           dateEdit1.DateTime=danju.rq;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            foreach (var d in danjumingxitables)
            {
                d.chengpingmishu = -d.chengpingmishu;
                d.chengpingjuanshu = -d.chengpingjuanshu;
                d.hanshuidanjia = -d.hanshuidanjia;
                d.hanshuiheji = -d.hanshuiheji;
            }
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            juanList = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == txtdanhao.Text);
            gridControl2.DataSource = juanList;
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].yanse = fm.colorInfo.ColorNum;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 采购退货单_FormClosed(object sender, FormClosedEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.采购退货单 , dateEdit1.DateTime, DanjuLeiXing.采购退货单);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            赋值单据();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "采购退货查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "采购退货单.frx", PrintModel.Design);
        }
        private void 赋值单据()
        {
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.采购退货单 ;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtckmc.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei =txtyunfei.Text.TryToDecmial();
            danju.lianxidianhua = txtlianxidianhua.Text;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }
        private void 重新加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null))
            {
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == txtckmc.Text && x.Danhao == txtdanhao.Text));
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.OrderNum == d.OrderNum && x.yanse == d.yanse && x.kuanhao == d.kuanhao && x.Houzhengli == d.houzhengli
              && x.GangHao == d.ganghao && x.SampleNum == d.Bianhao && x.Huahao == d.Huahao && x.ColorNum == d.ColorNum && x.Ckmc == txtckmc.Text && x.state == 0));
            }
            gridControl2.DataSource = juanList.OrderBy(x => x.yanse).ThenBy(x => x.GangHao).ThenBy(x => x.PiHao).ToList();
            gridControl2.RefreshDataSource();
        }
        private void 加载卷()
        {
            juanList.Clear();
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null))
            {
                juanList.AddRange(JuanHaoTableService.GetJuanHaoTablelst(x => x.Ckmc == txtckmc.Text && x.CustomerName == d.CustomName && x.SampleName == d.pingming && x.yanse == d.yanse && x.GangHao == d.ganghao && x.state == 0
                && x.kuanhao == d.kuanhao && x.OrderNum == d.OrderNum && x.SampleNum == x.SampleNum && x.Houzhengli == d.houzhengli && x.Huahao == d.Huahao).OrderBy(x => x.PiHao).ToArray());
            }
            //juanList = juanList.OrderBy (x=>x.GangHao).ThenBy (x => x.yanse ).ThenBy(x => x.PiHao).ToList();
            gridControl2.DataSource = juanList;
            gridControl2.RefreshDataSource();
        }

        private void 重新加载卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重新加载卷();
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            SelectJuanHelper.SelectJuan(gridControl1, gridView2, juanList, danjumingxitables);
        }
    }
}
