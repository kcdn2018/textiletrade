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
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 点色通知单 : Form
    {
        public int UseFul { get; set; }
        public DanjuTable danju { get; set; } = new DanjuTable();
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        private int rowindex;
        public 点色通知单()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit2;
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

        private void 点色通知单_Load(object sender, EventArgs e)
        {
            if (UseFul  == FormUseful.新增)
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

            foreach (Control c in this.groupPanel2 .Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.点色通知单 , dateEdit1.DateTime, DanjuLeiXing.点色通知单 );          
            danjumingxitables.Clear();
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            UseFul  = FormUseful.新增;
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            dateEdit1.DateTime = danju.rq;
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            //danjumingxitables.ForEach(x => { x.houzhengli = x.houzhengli.Substring(0, x.houzhengli.Length - 4); });
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = dateEdit1.DateTime });
            }
            gridControl1.DataSource = danjumingxitables;
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
            if(e.KeyCode==Keys.Enter )
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
            if (string.IsNullOrEmpty ( txtkehu.Text ))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择染厂");
                return;
            }
            if(UseFul ==FormUseful.新增 )
            {
                Save();
            }
            else
            {
                EditSave();
            }
            Init ();
        }
        private void Save()
        {
            danju.dh = 单据BLL.检查单号(txtdanhao.Text);
            InitDanju();
            DanjuTableService.InsertDanjuTable(danju);
            var mingxis = danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList();
            库存BLL.减少库存(mingxis, danju);
            mingxis.ForEach(x => { x.danhao = danju.dh; x.houzhengli += "+已点色"; });
            库存BLL.增加库存(mingxis, danju);
            danjumingxitableService.Insertdanjumingxitablelst(mingxis );
        }
        private void EditSave()
        {
            InitDanju();
            Connect.DbHelper().Updateable<DanjuTable>(danju).ExecuteCommandHasChange();
            var mingxis = danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList();
            var oldmingxi = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            库存BLL.减少库存(oldmingxi, danju);
            oldmingxi.ForEach(m => m.houzhengli = m.houzhengli.Substring(0, m.houzhengli.Length - 4));
            库存BLL.增加库存(oldmingxi, danju);
            foreach (var m in mingxis)
            {
                m.danhao = danju.dh;
            }
            库存BLL.减少库存(mingxis, danju);
            foreach (var m in mingxis)
            {
                m.danhao = danju.dh;
                m.houzhengli += "+已点色";
            }
            库存BLL.增加库存(mingxis, danju);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst(mingxis );
        }
        private void InitDanju()
        {
            danju.dh = txtdanhao.Text;
            danju.SaleMan = txtgengdanyuan.Text;
            danju.rq = dateEdit1.DateTime;
            danju.bz = txtbeizhu.Text;
            //danju.remarker = txtbeizhu.Text;
            danju.own = User.user.YHMC;
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu);
            danju.toupimishu = danjumingxitables.Sum(x => x.toupimishu);
            danju.toupijuanshu = danjumingxitables.Sum(x => x.toupijuanshu);
            danju.ckmc = danju.ksmc;
            danju.djlx = DanjuLeiXing.点色通知单;
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectStock();
        }
        private void SelectStock()
        {
            if (txtkehu.Text == "")
            {
                MessageBox.Show("请先选择染厂", "错误", MessageBoxButtons.OK);
                return;
            }
            SelectStockHelper.Select(txtkehu, gridView1, danjumingxitables);
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                Print(PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }
        private void Print(int printModel)
        {
            InitDanju ();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.pingming)).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "点色通知单.frx", printModel);
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Privew );
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
    }
}
