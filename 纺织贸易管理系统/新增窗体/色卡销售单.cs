using BLL;
using DAL;
using DevComponents.DotNetBar.Controls;
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
    public partial class 色卡销售单 : Form
    {
        public int useful = FormUseful.新增;
        public List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        public DanjuTable danju = new DanjuTable();
        private int rowindex;

        public 色卡销售单()
        {
            InitializeComponent();          
            CreateGrid.Create(this.Name  ,gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["OrderNum"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView1.Columns["hanshuiheji"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["hanshuiheji"].SummaryItem.FieldName = "hanshuiheji";
                gridView1.Columns["hanshuiheji"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingmishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingmishu"].SummaryItem.FieldName = "chengpingmishu";
                gridView1.Columns["chengpingmishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["chengpingjuanshu"].SummaryItem.FieldName = "chengpingjuanshu";
                gridView1.Columns["chengpingjuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
            }
            catch
            {
                var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
                fm.ShowDialog();
            }
           
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { MC="",ZJC="" } };
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
            var wuliu = fm.linkman;
            txtchepai.Text = wuliu.CarNum;
            txtlianxiren.Text = wuliu.name;
            txtQicheleixing.Text = wuliu.CarLeixing;            
        }
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(txtckmc.Text =="")
            {
                MessageBox.Show("请先选择仓库名称","错误",MessageBoxButtons.OK );
                return;
            }
            var fm = new 库存选择() { StockName=txtckmc.Text };
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao  = pingzhong.BH ;
                danjumingxitables[i].guige = pingzhong.GG;
                danjumingxitables[i].chengfeng = pingzhong.CF;
                danjumingxitables[i].pingming  = pingzhong.PM;
                danjumingxitables[i].kezhong  = pingzhong.KZ;          
                danjumingxitables[i].menfu  = pingzhong.MF;
                danjumingxitables[i].danwei  = "米";
                danjumingxitables[i].ContractNum  = pingzhong.ContractNum ;
                danjumingxitables[i].CustomName = pingzhong.CustomName ;
                danjumingxitables[i].OrderNum  = pingzhong.orderNum ;
                danjumingxitables[i].kuanhao  = pingzhong.kuanhao ;
                danjumingxitables[i].houzhengli  = pingzhong.houzhengli ;
                danjumingxitables[i].yanse  = pingzhong.YS ;
                danjumingxitables[i].Chengpingyanse = pingzhong.YS;
                danjumingxitables[i].ganghao  = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS ;
                danjumingxitables[i].chengpingmishu  = pingzhong.MS ;
                danjumingxitables[i].Kuwei  = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum  = pingzhong.CustomerColorNum ;
                danjumingxitables[i].CustomerPingMing  = pingzhong.CustomerPingMing;
                danjumingxitables[i].rq = danju.rq;
                danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS&&x.Huahao==pingzhong.Huahao ).price;
                danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable () { danhao  = txtdanhao.Text, rq = dateEdit1.DateTime});
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }
   
        private void ButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择 ();
            fm.ShowDialog();
            danjumingxitables[gridView1.FocusedRowHandle].OrderNum = fm.Order.OrderNum;
            danjumingxitables[gridView1.FocusedRowHandle].CustomName  = fm.Order.CustomerName ;
            danjumingxitables[gridView1.FocusedRowHandle].ContractNum  = fm.Order.ContractNum ;
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
        //给单据信息赋值
        private void InitDanju()
        {
            danju.bz = txtbeizhu.Text;
            danju.CarLeixing = txtQicheleixing.Text;
            danju.CarNum = txtchepai.Text;
            danju.ckmc = txtckmc.Text;
            danju.StockName = cmbcunfang.Text;
            danju.dh = txtdanhao.Text;
            danju.djlx = DanjuLeiXing.色卡销售单;
            danju.rq = dateEdit1.DateTime;
            danju.shouhuodizhi = txtShouhuodizhi.Text;
            danju.lianxiren = txtlianxiren.Text;
            danju.Qiankuan = cmbqiankuan.Text;
            danju.Hanshui = comhanshui.Text;
            danju.je = danjumingxitables.Sum(x => x.hanshuiheji);
            danju.totaljuanshu = danjumingxitables.Sum(x => x.chengpingjuanshu);
            danju.TotalMishu = danjumingxitables.Sum(x => x.chengpingmishu );
            danju.wuliugongsi = txtwuliu.Text;
            danju.yunfei = (decimal)txtyunfei.Value;
            danju.lianxidianhua = txtlianxidianhua.Text;
            danju.own = User.user.YHBH;
        }
     
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
       
            InitDanju();
            if (useful == FormUseful.新增)
            {
                if (财务BLL.查询额度(danju.ksbh, danjumingxitables.Sum(x => x.hanshuiheji)) == false)
                {
                    MessageBox.Show("该客户欠款额度已经不够了！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (财务BLL.检查是否有超期(danju.ksbh) )
                {
                    MessageBox.Show("该客户存在超期单据！保存失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var d = 库存BLL.检查库存(danjumingxitables, danju);
                if (d.Bianhao != null)
                {
                    var mes = $"该发货单中\n 布料编号:{d.Bianhao }\n 订单号:{d.OrderNum } \n 色号:{d.ColorNum } \n 缸号:{d.ganghao } \n 颜色:{d.yanse }在该仓库中没有！保存失败";
                    MessageBox.Show(mes, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                色卡销售单BLL .保存单据(danju, danjumingxitables);
            }
            else
            {
                色卡销售单BLL .修改单据(danju,danjumingxitables);
            }
            if (SysInfo.GetInfo.own != string.Empty )
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    if ((int)(MessageBox.Show("是否直接审核过账？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == 6)
                    {
                        销售发货单BLL .单据审核(danju.dh);
                        检测状态.检测(danjumingxitables);
                    }
                }
                else
                {
                    检测状态.检测(danjumingxitables);
                }
            }
            AlterDlg.Show("保存成功");
            //清空所有控件
            Init();
        }
        private void Init()
        { 
            foreach (Control  c in this.groupControl1.Controls  )
            {
                if(c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    c.Text = "";
                }
                if(c is DevExpress.XtraEditors.ButtonEdit)
                {
                    c.Text = "";
                }
            }
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.色卡销售单, dateEdit1.DateTime, DanjuLeiXing.色卡销售单);
            danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
            var length = danjumingxitables.Count;
            for (int i = 0; i < 30 - length; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { danhao = txtdanhao.Text,rq=dateEdit1.DateTime  });
            }
            gridControl1.DataSource = danjumingxitables;
            gridControl1.RefreshDataSource();
            txtckmc.Text = "色卡仓库";
            useful = FormUseful.新增;
        }

  

     
        private void 销售发货单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else
            {
                Edit();
                if (useful == FormUseful.查看)
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
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.ckmc ;
            cmbcunfang.Text = danju.StockName;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
           dateEdit1.DateTime=danju.rq;
            
        }  
    
        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitDanju();
            var madan = new Tools.打印成品码单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },

                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            };
            madan.Print(PrintPath.报表模板 + "\\madan.frx", PrintModel.Print );
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Privew);
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                InitDanju();
                new Tools.打印发货单()
                {
                    danjuTable = danju,
                    danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                    danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                    mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
                }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDanju();
            new Tools.打印发货单()
            {
                danjuTable = danju,
                danjumingxitables = danjumingxitables.Where(x => x.Bianhao != null).ToList(),
                danjuinfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = gridView1.Name },
                mingxiinfo = new Tools.FormInfo() { FormName = this.Name, GridviewName = gridView1.Name }
            }.Print(PrintPath.报表模板 + "发货单.frx", PrintModel.Print );
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
                fm.ShowDialog();
                danju.ksbh = fm.linkman.BH;
                danju.ksmc = fm.linkman.MC;
                txtkehu.Text = danju.ksmc;
            }
        }    
        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
        private void 销售发货单_FormClosing(object sender, FormClosingEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.色卡销售单  , dateEdit1.DateTime, DanjuLeiXing.色卡销售单);
            }
        }
    }
}
