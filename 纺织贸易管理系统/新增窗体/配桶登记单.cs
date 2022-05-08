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
    public partial class 配桶登记单 : Form
    {
        public int UseFul { get; set; }
        public DanjuTable danju { get; set; } = new DanjuTable();
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        private List<RangShequpiTable> ToupiList = new List<RangShequpiTable>();
        private int rowindex;
        public 配桶登记单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView2);
            try
            {
                gridView2.Columns["SampleNum"].ColumnEdit = BuliaoBTN ;
                gridView2.Columns["OrderNum"].ColumnEdit = BuliaoBTN;
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
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

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 配桶登记单_Load(object sender, EventArgs e)
        {
            if (UseFul == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit();
                if (UseFul == FormUseful.查看)
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 新增一个单据
        /// </summary>
        private void Init()
        {

            foreach (Control c in this.groupPanel2.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.配桶登记单, dateEdit1.DateTime, DanjuLeiXing.配桶登记单);
            danjumingxitables.Clear();
            ToupiList.Clear();
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                ToupiList.Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
            }
            gridControl2.DataSource = ToupiList;
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
            UseFul = FormUseful.新增;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            dateEdit1.DateTime = danju.rq;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            ToupiList = RangShequpiTableService.GetRangShequpiTablelst(x => x.DocumentNum == txtdanhao.Text);
            for (int i = 0; i < 30 - ToupiList.Count ; i++)
            {
                ToupiList .Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
            }
            //danjumingxitables.ForEach(x => { x.houzhengli = x.houzhengli.Substring(0, x.houzhengli.Length - 4); });
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl2.DataSource = ToupiList;
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danju.ksbh = fm.linkman.BH;
            danju.ksmc = fm.linkman.MC;
            txtkehu.Text = danju.ksmc;
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }

        private void txtgengdanyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择();
            fm.ShowDialog();
            txtgengdanyuan.Text = fm.linkman.Xingming;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (danjumingxitables.Sum(x => x.chengpingmishu  ) == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "布料数量不能为0，请填写数量！");
                return;
            }
            if (string.IsNullOrEmpty(txtkehu.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择染厂");
                return;
            }
            if (UseFul == FormUseful.新增)
            {
                Save();
            }
            else
            {
                EditSave();
            }
            Init();
        }
        private void Save()
        {
            danju.dh = 单据BLL.检查单号(txtdanhao.Text);
            InitDanju();
            ToupiList.ForEach(x => x.DocumentNum = danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            var mingxis = danjumingxitables.Where(x => !string.IsNullOrEmpty(x.yanse )).ToList();
            库存BLL.减少库存(ToupiList.Where (x=>!string.IsNullOrEmpty (x.SampleNum )).ToList () , danju);
            mingxis.ForEach(x => { x.danhao = danju.dh; x.houzhengli += "+已配桶"; });
            foreach (var m in mingxis)
            {
                m.danhao = danju.dh;
                m.Bianhao = ToupiList[0].SampleNum;
                m.pingming  = ToupiList[0].sampleName;
                m.OrderNum = ToupiList[0].OrderNum;
                m.PiBuChang  = ToupiList[0].PibuChang ;
                m.Pihao  = ToupiList[0].Pihao ;
                m.menfu  = ToupiList[0].menfu ;
                m.FrabicWidth = ToupiList[0].FrabicWidth;
                m.Rangchang  =txtkehu.Text ;
                m.AveragePrice = ToupiList[0].AveragePrice;
                m.chengfeng = ToupiList[0].chengfeng;
                m.ContractNum = ToupiList[0].ContractNum;
                m.CustomerColorNum = ToupiList[0].CustomerColorNum;
                m.CustomerPingMing = ToupiList[0].CustomerPingMing;
                m.CustomName = ToupiList[0].CustomName;
                m.danwei = "米";
                m.guige = ToupiList[0].Specifications;
                m.Huahao = ToupiList[0].Huahao ;
                m.kezhong = ToupiList[0].kezhong ;
                m.kuanhao  = ToupiList[0].kuanhao ;
            }
            库存BLL.增加库存(mingxis, danju);
            danjumingxitableService.Insertdanjumingxitablelst(mingxis);
            RangShequpiTableService.InsertRangShequpiTablelst(ToupiList.Where(x => !string.IsNullOrEmpty(x.SampleNum)).ToList());
        }
        private void EditSave()
        {
            InitDanju();
            Connect.DbHelper().Updateable<DanjuTable>(danju).ExecuteCommandHasChange();
            var mingxis = danjumingxitables.Where(x => !string.IsNullOrEmpty(x.yanse )).ToList();
            var oldtoupi = RangShequpiTableService.GetRangShequpiTablelst(x => x.DocumentNum == txtdanhao.Text);
            库存BLL.增加库存(oldtoupi, danju);
            库存BLL.减少库存 (ToupiList , danju);
            var oldmingxi = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            库存BLL.减少库存(oldmingxi, danju);
            oldmingxi.ForEach(m => m.houzhengli = m.houzhengli.Substring(0, m.houzhengli.Length - 4));
            库存BLL.增加库存(oldmingxi, danju);
            foreach (var m in mingxis)
            {
                m.danhao = danju.dh;
            }
            ToupiList.ForEach(x => x.DocumentNum = txtdanhao.Text );
            ToupiList.ForEach(x=>x.riqi = dateEdit1.DateTime);
            //库存BLL.减少库存(mingxis, danju);
            //foreach (var m in mingxis)
            //{
            //    m.danhao = danju.dh;            
            //    m.houzhengli += "+已配桶";
            //}
            //库存BLL.增加库存(mingxis, danju);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst(mingxis);
            RangShequpiTableService.DeleteRangShequpiTable(x => x.DocumentNum == txtdanhao.Text);
            RangShequpiTableService.InsertRangShequpiTablelst(ToupiList);
            if(UseFul ==FormUseful.查看  )
            {
                保存ToolStripMenuItem.Enabled = false;
            }
        }
        private void InitDanju()
        {
            danju.dh = txtdanhao.Text;
            danju.SaleMan = txtgengdanyuan.Text;
            danju.rq = dateEdit1.DateTime;
            danju.bz = txtbeizhu.Text;
            danju.own = User.user.YHMC;
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu );
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
            danju.toupimishu =danjumingxitables.Sum(x => x.toupimishu );
            danju.toupijuanshu  = danjumingxitables.Sum(x => x.toupijuanshu );
            danju.ckmc = danju.ksmc;
            danju.djlx = DanjuLeiXing.配桶登记单 ;
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectStock();
        }
        private void SelectStock()
        {
            if (txtkehu.Text == "")
            {
                MessageBox.Show("请先选择加工厂", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var fm = new 库存选择() { StockName = txtkehu.Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                ToupiList[i].OrderNum = pingzhong.orderNum;
                ToupiList[i].CustomName = pingzhong.CustomName;
                ToupiList[i].ContractNum = pingzhong.ContractNum;
                ToupiList[i].SampleNum = pingzhong.BH;
                ToupiList[i].sampleName = pingzhong.PM;
                ToupiList[i].Specifications = pingzhong.GG;
                ToupiList[i].chengfeng = pingzhong.CF;
                ToupiList[i].kezhong = pingzhong.KZ;
                ToupiList[i].menfu = pingzhong.MF;
                ToupiList[i].color = pingzhong.YS;
                ToupiList[i].kuanhao = pingzhong.kuanhao;
                ToupiList[i].ganghao = pingzhong.GH;
                ToupiList[i].ToupiMishu = pingzhong.MS;
                ToupiList[i].ToupiJuanshu = pingzhong.JS;
                ToupiList[i].houzhengli = pingzhong.houzhengli;
                ToupiList[i].Remarkers = pingzhong.Kuwei;
                ToupiList[i].SampleRemarks = "";
                ToupiList[i].Danjia = pingzhong.AvgPrice;
                ToupiList[i].Heji = pingzhong.AvgPrice * pingzhong.MS;
                ToupiList[i].ColorNum = pingzhong.ColorNum;
                ToupiList[i].CustomerColorNum = pingzhong.CustomerColorNum;
                ToupiList[i].CustomerPingMing = pingzhong.CustomerPingMing;
                ToupiList[i].Huahao = pingzhong.Huahao;
                ToupiList[i].AveragePrice = pingzhong.AvgPrice;
                ToupiList[i].FactoryName = pingzhong.Rangchang;
                ToupiList[i].Pihao = pingzhong.Pihao;
                ToupiList[i].PibuChang = pingzhong.PibuChang;
                ToupiList[i].FrabicWidth = pingzhong.FrabicWidth;
                i++;
            }
            gridControl2.RefreshDataSource();
            gridView2.CloseEditor();
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Design);
        }
        private void Print(int printModel)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.pingming)).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "配桶登记单.frx", printModel);
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Privew);
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Print );
        }

        private void colorbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.CloseEditor();
                var colorlist = ColorTableService.GetColorTablelst(x => x.ColorNum.Contains(danjumingxitables[gridView1.FocusedRowHandle].yanse));
                ColorTable color = new ColorTable();
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new RangShequpiTable() };
            fm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToupiList.Add(new RangShequpiTable() { DocumentNum = txtdanhao.Text, riqi = dateEdit1.DateTime });
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择() { colorInfo = new ColorTable() { ColorNum = danjumingxitables[gridView1.FocusedRowHandle].yanse } };
            fm.ShowDialog();
            ColorTable color = new ColorTable();
            color = fm.colorInfo;
            if (!string.IsNullOrEmpty(color.ColorNum))
            {
                danjumingxitables[gridView1.FocusedRowHandle].ColorNum = color.ColorNum;
                danjumingxitables[gridView1.FocusedRowHandle].yanse = color.ColorName;
            }
            gridControl1.RefreshDataSource();
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择() { UseFul = 1 };
            fm.ShowDialog();
            var row = gridView2.FocusedRowHandle;
            foreach (var d in fm.returnDatas)
            {
                danjumingxitables[row].OrderNum = d.order.OrderNum;
                danjumingxitables[row].ContractNum = d.order.ContractNum;
                danjumingxitables[row].CustomName = d.order.CustomerName;
                danjumingxitables[row].bizhong = "人民币￥";
                danjumingxitables[row].Bianhao = d.orderDetail.sampleNum;
                danjumingxitables[row].guige = d.orderDetail.Specifications;
                danjumingxitables[row].chengfeng = d.orderDetail.Component;
                danjumingxitables[row].pingming = d.orderDetail.sampleName;
                danjumingxitables[row].kezhong = d.orderDetail.weight;
                danjumingxitables[row].menfu = d.orderDetail.width;
                danjumingxitables[row].FrabicWidth = d.orderDetail.width;
                danjumingxitables[row].danwei = "米";
                danjumingxitables[row].OrderNum = d.orderDetail.OrderNum;
                danjumingxitables[row].kuanhao = d.orderDetail.Kuanhao;
                danjumingxitables[row].yanse = d.orderDetail.color;
                danjumingxitables[row].chengpingmishu = d.orderDetail.Num - d.orderDetail.consignmentNum;
                danjumingxitables[row].Huahao = d.orderDetail.Huahao;
                danjumingxitables[row].ColorNum = d.orderDetail.ColorNum;
                danjumingxitables[row].CustomerColorNum = d.orderDetail.CustomerColorNum;
                danjumingxitables[row].CustomerPingMing = d.orderDetail.CustomerPingMing;
                var mx = ToupiList.Where(x => x.SampleNum == d.orderDetail.sampleNum && x.OrderNum == d.orderDetail.OrderNum && x.color == d.orderDetail.color).ToList();
                if (mx.Count > 0)
                {
                    danjumingxitables[row].ganghao = mx[0].ganghao;
                }
                row++;
                if (row == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                    }
            }
            gridControl2.RefreshDataSource();
            gridView2.CloseEditor();
        }

        private void ButtonEdit1_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridView2.FocusedRowHandle;
            if (danjumingxitables[row].OrderNum == null)
            {
                var fm = new 品种选择();
                fm.ShowDialog();
                var i = gridView2.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.bh;
                    danjumingxitables[i].guige = pingzhong.gg;
                    danjumingxitables[i].chengfeng = pingzhong.cf;
                    danjumingxitables[i].pingming = pingzhong.pm;
                    danjumingxitables[i].kezhong = pingzhong.kz;
                    danjumingxitables[i].menfu = pingzhong.mf;
                    danjumingxitables[i].FrabicWidth = pingzhong.mf;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].Kuwei  = string.Empty;
                    danjumingxitables[i].ColorNum  = string.Empty;
                    var mx = ToupiList.Where(x => x.SampleNum == pingzhong.bh && x.OrderNum == x.OrderNum && x.color == x.color).ToList();
                    if (mx.Count > 0)
                    {
                        danjumingxitables[i].FrabicWidth = mx[0].FrabicWidth;
                        danjumingxitables[i].houzhengli = mx[0].houzhengli;
                    }    
                    else
                    {
                        danjumingxitables[i].houzhengli = mx[0].houzhengli;
                    }
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
            else
            {
                var fm = new 订单明细选择() { OrderNum = danjumingxitables[row].OrderNum };
                fm.ShowDialog();
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == danjumingxitables[row].OrderNum);
                var i = gridView2.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.sampleNum;
                    danjumingxitables[i].guige = pingzhong.Specifications;
                    danjumingxitables[i].chengfeng = pingzhong.Component;
                    danjumingxitables[i].pingming = pingzhong.sampleName;
                    danjumingxitables[i].kezhong = pingzhong.weight;
                    danjumingxitables[i].menfu = pingzhong.width;
                    danjumingxitables[i].FrabicWidth = pingzhong.width;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].OrderNum = pingzhong.OrderNum;
                    danjumingxitables[i].kuanhao = pingzhong.Kuanhao;
                    danjumingxitables[i].yanse = pingzhong.color;
                    danjumingxitables[i].chengpingmishu = pingzhong.Num - pingzhong.consignmentNum;
                    danjumingxitables[i].ContractNum = order.ContractNum;
                    danjumingxitables[i].CustomName = order.CustomerName;
                    danjumingxitables[i].Huahao = pingzhong.Huahao;
                    danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                    danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    var mx = ToupiList.Where(x => x.SampleNum == pingzhong.sampleNum && x.OrderNum == pingzhong.OrderNum && x.color == pingzhong.color).ToList();
                    if (mx.Count > 0)
                    {
                        danjumingxitables[i].FrabicWidth = mx[0].FrabicWidth;
                        danjumingxitables[i].houzhengli = mx[0].houzhengli ;
                    }
                    else
                    {
                        danjumingxitables[i].houzhengli = string.Empty ;
                    }
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
                        }
                }
                foreach (var d in danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)))
                {
                    var t = ToupiList.Where(x => x.ganghao == d.ganghao).ToList();
                    if (t.Count > 0)
                    {
                        d.Rangchang = t[0].FactoryName;
                        d.houzhengli = t[0].houzhengli;
                    }
                }
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName == "chengpingmishu")
            {
                ToupiList[0].ToupiMishu = danjumingxitables.Sum(x => x.chengpingmishu );
                ToupiList[0].ToupiJuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
                gridControl2.RefreshDataSource();
            }
            else
            {
                if (gridView1.FocusedColumn.FieldName == "chengpingjuanshu")
                {
                    ToupiList[0].ToupiMishu = danjumingxitables.Sum(x => x.chengpingmishu);
                    ToupiList[0].ToupiJuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void 相同信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var pingzhong in ToupiList.Where(x => x.SampleNum != null).ToList())
            {
                var mingxi = (new danjumingxitable()
                {
                    CustomName = pingzhong.CustomName,
                    chengfeng = pingzhong.chengfeng,
                    ganghao = pingzhong.ganghao,
                    Bianhao = pingzhong.SampleNum,
                    pingming = pingzhong.sampleName,
                    guige = pingzhong.Specifications,
                    ContractNum = pingzhong.ContractNum,
                    chengpingmishu = pingzhong.ToupiMishu,
                    chengpingjuanshu = pingzhong.ToupiJuanshu,
                    bizhong = "人民币￥",
                    beizhu = pingzhong.SampleRemarks,
                    Chengpingyanse = pingzhong.color,
                    yanse = pingzhong.color,
                    danhao = txtdanhao.Text,
                    menfu = pingzhong.menfu,
                    Kuwei = pingzhong.Remarkers,
                    kezhong = pingzhong.kezhong,
                    kuanhao = pingzhong.kuanhao,
                    OrderNum = pingzhong.OrderNum,
                    Huahao = pingzhong.Huahao,
                    rq = dateEdit1.DateTime,
                    danwei = "米",
                    rkdh = pingzhong.rkdh,
                    CustomerColorNum = pingzhong.CustomerColorNum,
                    CustomerPingMing = pingzhong.CustomerPingMing,
                    ColorNum = pingzhong.ColorNum,
                    Rangchang = pingzhong.FactoryName,
                    Pihao = pingzhong.Pihao,
                    PiBuChang = pingzhong.PibuChang,
                    FrabicWidth = pingzhong.FrabicWidth,
                });
                if (pingzhong.houzhengli != "")
                {
                    mingxi.houzhengli = pingzhong.houzhengli ;
                }
                else
                {
                    mingxi.houzhengli = string.Empty ;
                }
                danjumingxitables[i] = (mingxi);
                i++;
            }
            gridControl1.RefreshDataSource();
        }
    }
}
