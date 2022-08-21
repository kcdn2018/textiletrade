using BLL;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 来样登记单 : Form
    {
        public int useful= FormUseful.新增;
        public DanjuTable danju = new DanjuTable();
        private  List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
        private int rowindex;

        public 来样登记单()
        {
            InitializeComponent();
           
            CreateGrid.Create(this.Name  , gridView1);
            try
            {
                gridView1.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["yanse"].ColumnEdit = colorbtn;
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
                配置列ToolStripMenuItem_Click(null, null);
            }
            gridView1.IndicatorWidth = 30;         
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }
        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman =new LXR() { MC="" ,ZJC=""} };
            fm.ShowDialog();
            txtkehu.Text = fm.linkman.MC;
            加载联系人();
        }

        private void buttonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择 ();
            fm.ShowDialog();
            //txtwuliu.Text = fm.linkman.name ;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {            
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                MessageBox.Show("设置默认标签成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置默认标签失败！原因是" + ex.Message);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectProductHelper.Select(gridView1, danjumingxitables);
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (useful != FormUseful.修改)
            {
                txtdanhao.Text = 单据BLL.检查单号(txtdanhao.Text);
            }
                if (useful==FormUseful.修改 )
            {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == txtdanhao.Text);
                danju.rq = dateEdit1.DateTime;
                danju.ksmc = txtkehu.Text;
                danju.bz = txtbeizhu.Text;
                Connect.DbHelper().Updateable<DanjuTable>(danju).ExecuteCommand ();
                danjumingxitableService.Deletedanjumingxitable(x => x.danhao == txtdanhao.Text);
                danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.CustomerFrabicNo)).ToList());
            }
            else
            {
                DanjuTableService.InsertDanjuTable(new DanjuTable() { dh = txtdanhao.Text, bz = txtbeizhu.Text, ksmc = txtkehu.Text, rq = dateEdit1.DateTime,djlx =DanjuLeiXing.来样登记单  });
                danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.CustomerFrabicNo)).ToList());
            }
            Init();
            useful = FormUseful.新增;
        }
        private void Init()
        {
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.来样登记单 , dateEdit1.DateTime, DanjuLeiXing.来样登记单 );
            txtkehu.Text = "";       
            txtbeizhu.Text = "";
            danjumingxitables .Clear();
            for (int i = 0; i < 30 ; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { rq = dateEdit1.DateTime, danhao = txtdanhao.Text
            });
            }
            gridControl1.DataSource=danjumingxitables ;
            gridControl1.RefreshDataSource();
        }

      
        private void 打印寄样标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var fm = new 打印设置窗体 ();
            //fm.Show();
            //if (!fm.printerSettings.IsCancelPrint)
            //{
            //    var printer = fm.printerSettings.PrintName;
            //    var num = fm.printerSettings.PrintNum;
            //    foreach (var i in gridView1.GetSelectedRows())
            //    {
            //        jiYangBaoJia = listjiyang[i];
            //        var pingzhong = dbService.GetOnedb(x => x.bh == jiYangBaoJia.SPBH);
            //        if (pingzhong.bh == "")
            //        {
            //            pingzhong.bh = jiYangBaoJia.SPBH;
            //            pingzhong.pm = jiYangBaoJia.SPMC;
            //            pingzhong.gg = jiYangBaoJia.gg;
            //            pingzhong.cf = jiYangBaoJia.cf;
            //            pingzhong.kz = jiYangBaoJia.kz;
            //            pingzhong.mf = jiYangBaoJia.mf;
            //            pingzhong.md = jiYangBaoJia.md;
            //            pingzhong.zb = jiYangBaoJia.zb;
            //            pingzhong.jg = jiYangBaoJia.JG.ToString();
            //            pingzhong.ys = jiYangBaoJia.ys;
            //            pingzhong.HH = jiYangBaoJia.Hetonghao;
            //        }
            //        else
            //        {
            //            pingzhong.jg = jiYangBaoJia.JG.ToString();
            //            pingzhong.ys = jiYangBaoJia.ys;
            //            pingzhong.HH = jiYangBaoJia.Hetonghao;
            //        }
            //        //Tools.打印标签.打印(jiYangBaoJia.JG ,pingzhong ,new PrintSetting() {  Path =PrintPath.标签模板 +cmbMoban.Text ,Printmodel =PrintModel.Print , PrintName=printer ,PrintNum =num});
            //    }
            //}
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxitables .Add(new danjumingxitable() { rq = dateEdit1.DateTime, danhao = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable  >(danjumingxitables, rowindex, gridView1, gridView1.FocusedRowHandle,this );
        }

        private void 寄样单_Load(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                Init();
            }
            else 
            {
                if(useful==FormUseful.复制 )
                {
                    Edit();                  
                   dateEdit1.DateTime= DateTime.Now; 
                    txtdanhao.Text =  BianhaoBLL.CreatDanhao(FirstLetter.来样登记单  , dateEdit1.DateTime, DanjuLeiXing.来样登记单 );
                    foreach (var j in danjumingxitables )
                    {
                        j.danhao = txtdanhao.Text;
                        j.rq = danju.rq;
                    }
                }
                else
                {
                    Edit();
                }

            }
        }
       private void Edit()
        {
            txtdanhao.Text = danju.dh ;
            txtkehu.Text = danju.ksmc ;
            //txtwuliu.Text = danju.wuliugongsi;
            dateEdit1.DateTime =danju.rq;
            //txtyundanhao.Text = danju.wuliuBianhao ;
            //txtyunfei.Value =(double) danju.yunfei ;
            txtbeizhu.Text = danju.bz ;
            danjumingxitables=danjumingxitableService.Getdanjumingxitablelst (x=>x.danhao ==danju.dh );
            var len = danjumingxitables.Count;
            for (int i = 0; i <30-len ; i++)
            {
                danjumingxitables.Add(new danjumingxitable() { rq = dateEdit1.DateTime, danhao = txtdanhao.Text });
            }
            gridControl1.DataSource = danjumingxitables;
            
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            danjumingxitables [gridView1.FocusedRowHandle].yanse  = fm.colorInfo.ColorNum;
            gridView1.CloseEditor();
            gridControl1.RefreshDataSource();
        }
        private void 加载联系人()
        {
            cmblianxiren.Items.Clear();
            foreach (var lxr in JiYangBaoJiaService.GetJiYangBaoJialst(x => x.KHMC == txtkehu.Text).Select(x => x.Lianxiren).Distinct ().ToList())
            {
                cmblianxiren.Items.Add(lxr);
            }
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful == FormUseful.新增)
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.来样登记单  , dateEdit1.DateTime,DanjuLeiXing.来样登记单 );
            }
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, txtkehu.Text +"来样登记单");
        }
    }
}
