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
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 来样报价单 : Form
    {
        public int useful= FormUseful.新增;
        public DanjuTable danju = new DanjuTable();
        public  JiYangBaoJia jiYangBaoJia = new JiYangBaoJia();
        public List<JiYangBaoJia> listjiyang = new List<JiYangBaoJia>();
        private int rowindex;

        public 来样报价单()
        {
            InitializeComponent();
           
            CreateGrid.Create(this.Name  , gridView1);
            try
            {
                gridView1.Columns["SPBH"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["ys"].ColumnEdit = colorbtn;
                gridView1.Columns["bizhong"].ColumnEdit = cmbbizhong;
                gridView1.Columns["Leixing"].ColumnEdit = cmbleixing;
                gridView1.Columns["Lianxiren"].ColumnEdit = cmblianxiren;
                gridView1.Columns["hs"].ColumnEdit = cmbhanshui;
                gridView1.Columns["HejiJinE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["HejiJinE"].SummaryItem.FieldName = "HejiJinE";
                gridView1.Columns["HejiJinE"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["sl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["sl"].SummaryItem.FieldName = "sl";
                gridView1.Columns["sl"].SummaryItem.DisplayFormat = "{0:0.##}";
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            gridView1.IndicatorWidth = 30;         
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new JiYangBaoJia() };
            fm.ShowDialog();
        }
        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman =new LXR() { MC="" ,ZJC=""} };
            fm.ShowDialog();
            jiYangBaoJia.KHBH = fm.linkman.BH;
            jiYangBaoJia.KHMC = fm.linkman.MC;
            txtkehu.Text = fm.linkman.MC;
            加载联系人();
        }

        private void buttonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择 ();
            fm.ShowDialog();
            jiYangBaoJia.kdgs = fm.linkman.Bianhao ;
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
            var fm = new 品种选择();
            fm.ShowDialog();
            var i= gridView1.FocusedRowHandle ;
            foreach (var pingzhong in fm.pingzhong )
            {
                listjiyang[i].bizhong = "人民币￥";
                listjiyang[i].SPBH = pingzhong.bh;
                listjiyang[i].gg = pingzhong.gg;
                listjiyang[i].cf = pingzhong.cf;
                listjiyang[i].SPMC = pingzhong.pm;
                listjiyang[i].kz = pingzhong.kz;
                listjiyang[i].md = pingzhong.md;
                listjiyang[i].mf = pingzhong.mf;
                listjiyang[i].zb = pingzhong.zb;
                listjiyang[i].EnglishName = pingzhong.EnglishName;
                listjiyang[i].ys = pingzhong.ys;                
                listjiyang[i].PibuPrice =Regex.IsMatch(pingzhong.PBPrice , @"^[+-]?\d*[.]?\d*$")?pingzhong.PBPrice.ToDecimal (0):0;
                listjiyang[i].Houzhengli = pingzhong.hzl;
                listjiyang[i].HouzhengliPrice = Regex.IsMatch(pingzhong.hzljg , @"^[+-]?\d*[.]?\d*$") ? pingzhong.hzljg .ToDecimal(0) : 0; ;
                i++;
                if (i == listjiyang.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        listjiyang.Add(new JiYangBaoJia() { Danhao=txtdanhao.Text,RQ=Convert.ToDateTime (dateEdit1.Text),DH =txtdanhao.Text  });
                    }
            }
            fm.Dispose ();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            listjiyang[gridView1.FocusedRowHandle].HejiJinE  = listjiyang[gridView1.FocusedRowHandle].JG * listjiyang[gridView1.FocusedRowHandle].sl;
            gridControl1.RefreshDataSource();
        }
        private void 列表赋值()
        {
            foreach (var j in listjiyang)
            {          
                j.RQ = Convert.ToDateTime(dateEdit1.DateTime.ToShortDateString ());
                j.DH = txtdanhao.Text;
                j.KHMC = txtkehu.Text;
                j.KHBH = jiYangBaoJia.KHBH;
                j.own = User.user.YHBH;        
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            if (useful != FormUseful.修改)
            {
                txtdanhao.Text = 单据BLL.检查单号(txtdanhao.Text);
            }
            列表赋值();
                if (useful==FormUseful.修改 )
            {
                报价单BLL.修改单据  (listjiyang.Where(x =>!string.IsNullOrWhiteSpace ( x.SPMC)).ToList());
            }
            else
            {
                报价单BLL .保存报价单(listjiyang.Where(x =>!string.IsNullOrWhiteSpace ( x.SPMC)).ToList());
            }
            Init();
            useful = FormUseful.新增;
        }
        private void Init()
        {
            dateEdit1.DateTime = DateTime.Now.Date;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.报价单, dateEdit1.DateTime, DanjuLeiXing.报价单);
            txtkehu.Text = "";       
            txtbeizhu.Text = "";
            listjiyang.Clear();
            for (int i = 0; i < 30 ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = Convert.ToDateTime(dateEdit1.Text), DH = txtdanhao.Text,own  = User.user.YHBH,
            });
            }
            gridControl1.DataSource=listjiyang ;
            gridControl1.RefreshDataSource();
        }

        //private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Print(PrintModel.Design);
        //}
        //private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Print(PrintModel.Privew);
        //}
        //private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Print(PrintModel.Print );
        //}
        private void 打印寄样标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 打印设置窗体 ();
            fm.Show();
            var printer = fm.printerSettings .PrintName;
            var num = fm.printerSettings .PrintNum;
            foreach(var i in gridView1.GetSelectedRows() )
            {
                jiYangBaoJia = listjiyang[i];
                var pingzhong = dbService.GetOnedb(x => x.bh == jiYangBaoJia.SPBH);
                if(pingzhong.bh=="")
                {
                    pingzhong.bh = jiYangBaoJia.SPBH;
                    pingzhong.pm = jiYangBaoJia.SPMC;
                    pingzhong.gg = jiYangBaoJia.gg;
                    pingzhong.cf = jiYangBaoJia.cf;
                    pingzhong.kz = jiYangBaoJia.kz;
                    pingzhong.mf = jiYangBaoJia.mf;
                    pingzhong.md = jiYangBaoJia.md;
                    pingzhong.zb = jiYangBaoJia.zb;
                    pingzhong.jg = jiYangBaoJia.JG.ToString () ;
                    pingzhong.ys = jiYangBaoJia.ys;
                    pingzhong.HH = jiYangBaoJia.Hetonghao ;
                }
                else
                {
                    pingzhong.jg = jiYangBaoJia.JG.ToString();
                    pingzhong.ys = jiYangBaoJia.ys;
                    pingzhong.HH = jiYangBaoJia.Hetonghao;
                }
                //Tools.打印标签.打印(jiYangBaoJia.JG ,pingzhong ,new PrintSetting() {  Path =PrintPath.标签模板 +cmbMoban.Text ,Printmodel =PrintModel.Print , PrintName=printer ,PrintNum =num});
            }          
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listjiyang.Add(new JiYangBaoJia() { RQ = Convert.ToDateTime(dateEdit1.Text), DH = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<JiYangBaoJia >(listjiyang, rowindex, gridView1, gridView1.FocusedRowHandle);
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
                    dateEdit1.Text = DateTime.Now.ToShortDateString(); 
                    txtdanhao.Text =  BianhaoBLL.CreatDanhao(FirstLetter.报价单 , dateEdit1.DateTime, DanjuLeiXing.报价单);
                    foreach (var j in listjiyang )
                    {
                        j.DH = txtdanhao.Text;
                        j.RQ = dateEdit1.DateTime;
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
            dateEdit1.Text = danju.rq.ToShortDateString();
            //txtyundanhao.Text = danju.wuliuBianhao ;
            //txtyunfei.Value =(double) danju.yunfei ;
            txtbeizhu.Text = danju.bz ;
            listjiyang=JiYangBaoJiaService.GetJiYangBaoJialst (x=>x.DH ==danju.dh );
            var len = listjiyang.Count;
            for (int i = 0; i <30-len ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = Convert.ToDateTime(dateEdit1.Text), DH = txtdanhao.Text });
            }
            gridControl1.DataSource = listjiyang;
            
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            listjiyang[gridView1.FocusedRowHandle].ys = fm.colorInfo.ColorNum;
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

        private void 来样报价单_FormClosing(object sender, FormClosingEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.报价单 , dateEdit1.DateTime,DanjuLeiXing.报价单);
            }
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, txtkehu.Text +"报价单");
        }
    }
}
