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
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 费用申请单 : Sunny.UI.UIForm 
    {
        public int useful { get; set; }
        public DanjuTable danju { get; set; } = new DanjuTable();
        private List<danjumingxitable> danjumingxis = new List<danjumingxitable>();
        private ContexMenuEX menuEX = new ContexMenuEX();
        public 费用申请单()
        {
            InitializeComponent();
            JiazaiBumen();
            jiazaifukuanfangshi();
            jiazaijingshouren();
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["CustomName"].ColumnEdit = ButtonEdit2;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
                gridView1.Columns["hanshuidanjia"].ColumnEdit = TextEdit1;
                gridView1.Columns["chengpingmishu"].ColumnEdit = TextEdit1;
                gridView1.IndicatorWidth = 30;
            }
            catch
            {
               menuEX. 配置列ToolStripMenuItem_Click(null, null);
            }
        }
        /// <summary>
        /// 加载部门
        /// </summary>
        private void JiazaiBumen()
        {
            cmbbumen.DataSource = YuanGongTableService.加载部门(); 
        }
        /// <summary>
        /// 加载收款方式
        /// </summary>
        private void jiazaifukuanfangshi()
        {
            cmbfukuanfangshi.DataSource = SKFSService.GetSKFSlst (x => x.Skfs .Contains("")).Select(x => x.Skfs).ToList();
        }
        /// <summary>
        /// 加载经手人
        /// </summary>
      private void jiazaijingshouren()
        {
            cmbjinshouren.DataSource = YuanGongTableService.GetYuanGongTablelst(x => x.Xingming.Contains("")).Select(x => x.Xingming).ToList(); ;
        }
            
        private void 费用申请单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void InitDanju()
        {
            foreach (Control c in this.groupControl1.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX || c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.费用单, dateEdit1.DateTime, DanjuLeiXing.费用单);
            txtjine.Text = "0.00";
            useful = FormUseful.新增;
            danjumingxis.Clear();
            for (int i = 0; i < 30; i++)
            {
                danjumingxis.Add(new danjumingxitable() { danwei = "米" });
            }
            gridControl1.DataSource = danjumingxis;
            gridControl1.RefreshDataSource();
        }

   
        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.费用单 , dateEdit1.DateTime, DanjuLeiXing.费用单);
            }
        }

        private void 费用申请单_Load(object sender, EventArgs e)
        {
            menuEX.formName = this.Name;
            menuEX.gridControl = this.gridControl1;
            menuEX.gridView = this.gridView1;
            menuEX.menuStrip = this.contextMenuStrip1;
            menuEX.Init();
            if (useful == FormUseful.新增)
            {
                InitDanju ();
            }
            else
            {
                Edit();
                if (useful == FormUseful.查看)
                {
                    保存ToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void Edit()
        {
            txtdanhao.Text = danju.dh;
            txtjine.Text = danju.je.ToString ();
            txtordernum.Text = danju.ordernum;
            txtzaiyao.Text = danju.bz;
            txtfahuodanhao.Text = danju.fromDanhao;
            cmbfeiyongleixing.Text = danju.jiagongleixing;
            cmbfukuanfangshi.Text = danju.ShoukuanFangshi;
            cmbqiankuan.Text = danju.Qiankuan;
            cmbjinshouren.Text = danju.own;
            cmbbumen.Text = danju.SaleMan;
            cmbshouzhi.Text = danju.yaoqiu;
           dateEdit1.DateTime=danju.rq;
            txthetonghao.Text = danju.HetongHao;
            if(danju.yaoqiu =="收入")
            {
                txtjine.Text = danju.totalmoney.ToString ();
            }
            danjumingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh);
            for (int i = danjumingxis.Count; i < 30; i++)
            {
                danjumingxis.Add(new danjumingxitable() { danwei = "米" });
            }
            gridControl1.DataSource = danjumingxis;
            gridControl1.RefreshDataSource();
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择();
            fm.ShowDialog();
            txtordernum.Text = fm.Order.OrderNum;
            
        }
        //给单据信息赋值
        private void assignment()
        {         
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.费用单;
            danju.rq = dateEdit1.DateTime;      
            danju.Qiankuan = cmbqiankuan.Text;
            danju.je = txtjine.Text.ToDecimal(0);
            danju.bz = txtzaiyao.Text;
            danju.fromDanhao = txtfahuodanhao.Text;
            danju.lianxiren  = cmbjinshouren.Text;
            danju.jiagongleixing = cmbfeiyongleixing.Text;
            danju.ShoukuanFangshi = cmbfukuanfangshi.Text;
            danju.SaleMan = cmbbumen.Text;
            danju.ordernum = txtordernum.Text;
            danju.yaoqiu = cmbshouzhi.Text;
            danju.HetongHao = txthetonghao.Text;
            danju.own = User.user.YHBH;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtjine.Text =="0.00")
            {                
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请填写金额,保存失败！");
                    return;
            }
            assignment();
            if (useful == FormUseful.新增)
            {
                费用BLL.保存单据(danju,danjumingxis.Where (x=>!string.IsNullOrWhiteSpace ( x.pingming)).ToList ());
            }
            else
            {
                费用BLL.修改单据(danju, danjumingxis.Where(x =>!string.IsNullOrWhiteSpace ( x.pingming)).ToList());
            }
            InitDanju ();
        }

        private void txtordernum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择();
            fm.ShowDialog();
            txtordernum.Text = fm.Order.OrderNum;
            txthetonghao.Text = fm.Order.ContractNum;
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int rowindex = gridView1.FocusedRowHandle;
                if (gridView1.FocusedColumn.FieldName == "hanshuidanjia" || gridView1.FocusedColumn.FieldName == "chengpingmishu")
                {
                    //decimal hanshuidanjia = gridView1.GetRowCellValue(rowindex, "hanshuidanjia").TryToDecmial(0);
                    //decimal shuliang = gridView1.GetRowCellValue(rowindex, "chengpingmishu").TryToDecmial(0);
                    //decimal xiaoji = hanshuidanjia * shuliang;
                    //gridView1.SetRowCellValue(rowindex, "hanshuiheji", xiaoji);
                    danjumingxis[rowindex].hanshuiheji = danjumingxis[rowindex].hanshuidanjia * danjumingxis[rowindex].chengpingmishu;
                    gridControl1.RefreshDataSource();
                    txtjine.Text = danjumingxis.Sum(x => x.hanshuiheji).ToString ();
                }
               
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "计算合计的时候发送了错误" + ex.Message);
            }
        }

        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            danjumingxis[gridView1.FocusedRowHandle ].CustomName = fm.linkman.MC;
        }
    }
}
