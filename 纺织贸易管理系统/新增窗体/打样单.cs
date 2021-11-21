using BLL;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 打样单 : Form
    {
        private LXR jiagongchang = new LXR();
        private LXR Kehu = new LXR();
        private BindingList<danjumingxitable> danjumingxitables = new BindingList<danjumingxitable>();
        public DanjuTable danju { get; set; }
        public int Useful { get; set; }
        public 打样单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.Columns["ColorNum"].ColumnEdit = colorbtn;
                gridView1.Columns["rq"].ColumnEdit = dtEndDate;
                gridView1.Columns["PingzhiYang"].ColumnEdit = cmbPingzhiyang;
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
                var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
                fm.ShowDialog();
            }
        }
        private void 打样工艺单_Load(object sender, EventArgs e)
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
                        txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样单, dateEdit1.DateTime, DanjuLeiXing.打样单);
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
            foreach (Control c in this.groupControl1.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit || c is Sunny.UI.UIRichTextBox)
                {
                    c.Text = "";
                }
            }

            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样单, dateEdit1.DateTime, DanjuLeiXing.打样单);
            checkBoxX1.Checked = true;
            checkBoxX2.Checked = true;
            checkBoxX3.Checked = true;
            checkBoxX4.Checked = true;
            danjumingxitables.Clear();
            for (int i = 0; i < 20; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime.AddDays(10) });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            Useful = FormUseful.新增;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            dateEdit1.DateTime = danju.rq;
            jiagongchang.BH = danju.ksbh;
            jiagongchang.MC = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            //客户名称
            Kehu.MC = danju.ksmc;
            txtkehu.Text = Kehu.MC;
            //客户编号
            Kehu.BH = danju.wuliuBianhao;
            //备注
            txtbeizhu.Text = danju.bz;
            txtheji.Value = danju.je;
            comhanshui.Text = danju.Hanshui;
            cmbqiankuan.Text = danju.Qiankuan;
            comleixing.Text = danju.jiagongleixing;
            danjumingxitables = new BindingList<danjumingxitable>(danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh));
            for (int i = danjumingxitables.Count; i < 20; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = danju.dh });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            var listhouzhengli = ShengchandanHouzhengliService.GetShengchandanHouzhenglilst(x => x.shengchandanhao == danju.dh);
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "A").ToList()[0].Value == true)
            {
                checkBoxX1.Checked = true;
            }
            else
            {
                checkBoxX1.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "B").ToList()[0].Value == true)
            {
                checkBoxX2.Checked = true;
            }
            else
            {
                checkBoxX2.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "C").ToList()[0].Value == true)
            {
                checkBoxX3.Checked = true;
            }
            else
            {
                checkBoxX3.Checked = false;
            }
            if (listhouzhengli.Where(x => x.HouzhengliGongyi == "D").ToList()[0].Value == true)
            {
                checkBoxX4.Checked = true;
            }
            else
            {
                checkBoxX4.Checked = false;
            }
            var yaoqius = ShengChanDanHouZhengLiYaoQiuService.GetShengChanDanHouZhengLiYaoQiulst(x => x.ShengChanDanHao == danju.dh);

        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linkman = new LXR() { ZJC = "", MC = "" };
            var fm = new 客户选择() { linkman = linkman };
            fm.ShowDialog();
            Kehu = fm.linkman;
            txtkehu.Text = Kehu.MC;
            txtlianxidianhua.Text = Kehu.DH;
            txtlianxiren.Text = Kehu.Lxr;
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var linkman = new LXR() { ZJC = txtkehu.Text, MC = "" };
                var fm = new 客户选择() { linkman = linkman };
                fm.ShowDialog();
                Kehu = fm.linkman;
                txtkehu.Text = Kehu.MC;
                txtlianxidianhua.Text = Kehu.DH;
                txtlianxiren.Text = Kehu.Lxr;
            }
        }



        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new ShengchandanSeLaodu() };
            fm.ShowDialog();
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CopyRow.Copy<danjumingxitable>(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            var lianxiren = LXRService.GetOneLXR(x => x.MC == txtkehu.Text);
            if (string.IsNullOrWhiteSpace(lianxiren.MC))
            {
                Sunny.UI.UIMessageBox.Show($"该客户{txtkehu.Text}名称在客户资料中没有匹配到！\r\n请检查输入的客户名是否正确");
                return;
            }
            else
            {
                Kehu.BH = lianxiren.BH;
            }
            if (comleixing.Text == "")
            {
                MessageBox.Show("请填写工艺类型！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtkehu.Text == "")
            {
                MessageBox.Show("请选择或填写客户！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var danju = new DanjuTable()
            {
                dh = txtdanhao.Text,
                rq = dateEdit1.DateTime,
                ksbh = Kehu.BH,
                ksmc = txtkehu.Text,
                lianxidianhua = txtlianxidianhua.Text,
                lianxiren = txtlianxiren.Text,
                djlx = DanjuLeiXing.打样单,
                own = User.user.YHBH,
                //客户名称
                SaleMan = txtdayangyuan.Text,
                //类型
                jiagongleixing = comleixing.Text,
                //合计费用
                je = txtheji.Value,
                Hanshui = comhanshui.Text,
                Qiankuan = cmbqiankuan.Text,
                zhuangtai = "已审核",
                bz = txtbeizhu.Text,
                yaoqiu = txtbeizhu.Text
            };
            var listhouzhenli = new List<ShengchandanHouzhengli>();
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "A", Value = checkBoxX1.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "B", Value = checkBoxX2.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "C", Value = checkBoxX3.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "D", Value = checkBoxX4.Checked });
            var yaoqius = new List<ShengChanDanHouZhengLiYaoQiu>();

            danju.TotalMishu = danjumingxitables.Where(x => x.pingming != null).ToList().Count();
            if (Useful == FormUseful.新增)
            {
                打样单BLL.保存(danjumingxitables.Where(x => x.pingming != null).ToList(), danju, listhouzhenli);
            }
            else
            {
                打样单BLL.修改(danjumingxitables.Where(x => x.pingming != null).ToList(), danju, listhouzhenli);
            }
            AlterDlg.Show("保存成功！");
            Thread.Sleep(1000);
            Init();
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Design);
        }
        private void Print(int c)
        {
            gridView1.CloseEditor();
            var lianxiren = LXRService.GetOneLXR(x => x.MC == txtkehu.Text);
            if (string.IsNullOrWhiteSpace(lianxiren.MC))
            {
                Sunny.UI.UIMessageBox.Show($"该客户{txtkehu.Text}名称在客户资料中没有匹配到！\r\n请检查输入的客户名是否正确");
                return;
            }
            var danju = new DanjuTable()
            {
                dh = txtdanhao.Text,
                rq = dateEdit1.DateTime,
                ksbh = Kehu.BH,
                ksmc = Kehu.MC,
                lianxidianhua = txtlianxidianhua.Text,
                lianxiren = txtlianxiren.Text,
                djlx = DanjuLeiXing.打样单,
                own = User.user.YHBH,
                SaleMan = txtdayangyuan.Text,
                yaoqiu = txtbeizhu.Text,
                bz = txtbeizhu.Text,
                zhuangtai = "未审核"
            };
            var listhouzhenli = new List<ShengchandanHouzhengli>();
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "A", Value = checkBoxX1.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "B", Value = checkBoxX2.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "C", Value = checkBoxX3.Checked });
            listhouzhenli.Add(new ShengchandanHouzhengli() { shengchandanhao = txtdanhao.Text, HouzhengliGongyi = "D", Value = checkBoxX4.Checked });
            var yaoqius = new List<ShengChanDanHouZhengLiYaoQiu>();
            danju.TotalMishu = danjumingxitables.Where(x => x.pingming != null).ToList().Count();
            var result = new Tools.打印打样单后整理() { colorTables = danjumingxitables.Where(x => x.pingming != null).ToList(), formInfo = new FormInfo() { FormName = "打样管理", GridviewName = "gridView1" }, DanjuTable = danju, houzhenglis = listhouzhenli, yaoqius = yaoqius };
            result.打印(PrintPath.报表模板 + "打样单.frx", c);
            if (Useful != FormUseful.查看)
            {
                if (Sunny.UI.UIMessageBox.ShowAsk("是否保存该单据？\r\n保存按确定。不保存按取消") == true)
                {
                    保存ToolStripMenuItem_Click(保存ToolStripMenuItem, null);
                }
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Privew);
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Print);
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            //ColorTables [gridView1.FocusedRowHandle].Yaoqiu  = fm.colorInfo.ColorName ;
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (Useful != FormUseful.修改 && Useful != FormUseful.查看)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.打样单, dateEdit1.DateTime, DanjuLeiXing.打样单);
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var linkman = new YuanGongTable() { Xingming = "" };
            var fm = new 员工选择() { linkman = linkman };
            fm.ShowDialog();
            txtdayangyuan.Text = fm.linkman.Xingming;
        }

        private void uiTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var linkman = new YuanGongTable() { Xingming = "" };
                var fm = new 员工选择() { linkman = linkman };
                fm.ShowDialog();
                txtdayangyuan.Text = fm.linkman.Xingming;
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
                danjumingxitables[i].Bianhao = pingzhong.bh;
                danjumingxitables[i].guige = pingzhong.gg;
                danjumingxitables[i].chengfeng = pingzhong.cf;
                danjumingxitables[i].pingming = pingzhong.pm;
                danjumingxitables[i].kezhong = pingzhong.kz;
                danjumingxitables[i].menfu = pingzhong.mf;
                danjumingxitables[i].danwei = "米";
                danjumingxitables[i].PingzhiYang = "无品质样";
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                    }
            }
            gridView1.CloseEditor();
            gridControl1.RefreshDataSource();
        }

        private void ButtonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fm = new 品种选择() { Bianhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Bianhao").ToString() };
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.bh;
                    danjumingxitables[i].guige = pingzhong.gg;
                    danjumingxitables[i].chengfeng = pingzhong.cf;
                    danjumingxitables[i].pingming = pingzhong.pm;
                    danjumingxitables[i].kezhong = pingzhong.kz;
                    danjumingxitables[i].menfu = pingzhong.mf;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].PingzhiYang = "无品质样";
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(dateEdit1.Text) });
                        }
                }
                gridView1.CloseEditor();
                gridControl1.RefreshDataSource();
            }
        }

        private void 复制单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1 .Focus(); 
            SendKeys.Send("^c");
        }

        private void 粘贴单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1 .Focus();
            SendKeys.Send("^v");
        }
    }
}
