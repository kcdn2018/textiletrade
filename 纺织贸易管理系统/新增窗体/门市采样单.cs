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
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 门市采样单 : Form
    {
        public int useful= FormUseful.新增;
        public DanjuTable danju = new DanjuTable();
        public  JiYangBaoJia jiYangBaoJia = new JiYangBaoJia();
        public List<JiYangBaoJia> listjiyang = new List<JiYangBaoJia>();
        private int rowindex;

        public 门市采样单()
        {
            InitializeComponent();          
            CreateGrid.Create(this.Name  , gridView1);
            cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
            cmbMoban.Text = Connect.GetDefault()[0].LabelName;
            gridView1.Columns["SPBH"].ColumnEdit = ButtonEdit1;
            gridView1.Columns["bizhong"].ColumnEdit = cmbbizhong;
            gridView1.Columns["Leixing"].ColumnEdit = cmbleixing;
            gridView1.Columns["hs"].ColumnEdit = cmbhanshui ;        
            gridView1.Columns["HejiJinE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum ;
            gridView1.Columns["HejiJinE"].SummaryItem.FieldName = "HejiJinE";
            gridView1.Columns["HejiJinE"].SummaryItem.DisplayFormat  = "{0:0.##}";
            gridView1.Columns["sl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["sl"].SummaryItem.FieldName = "sl";
            gridView1.Columns["sl"].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.IndicatorWidth = 30;         
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }
        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman=new LXR() { MC="",ZJC=""} };
            fm.ShowDialog();
            jiYangBaoJia.KHBH = fm.linkman.BH;
            jiYangBaoJia.KHMC = fm.linkman.MC;
            txtkehu.Text = fm.linkman.MC;
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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            listjiyang[0].bz  = txtbeizhu.Text;
            listjiyang[0].RQ =Convert.ToDateTime ( dateEdit1 .Text);
            if (useful==FormUseful.新增 )
            {
                报价单BLL.保存报价单 (listjiyang.Where(x =>!string.IsNullOrWhiteSpace ( x.SPMC)).ToList());
            }
            else
            {
                报价单BLL.修改单据(listjiyang.Where(x =>!string.IsNullOrWhiteSpace ( x.SPMC)).ToList());
            }
            AlterDlg.Show("保存成功！");
            Init();
            useful = FormUseful.新增;
        }
        private void Init()
        {
            dateEdit1.DateTime = DateTime.Now;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.门市采样单, dateEdit1.DateTime, DanjuLeiXing.门市采样单);
            txtkehu.Text = "";       
            txtbeizhu.Text = "";
            listjiyang.Clear();
            for (int i = 0; i < 30 ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = dateEdit1.DateTime, DH = txtdanhao.Text,own = User.user.YHBH
            });
            }
            gridControl1.DataSource=listjiyang ;
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

        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listjiyang.Add(new JiYangBaoJia() { RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<JiYangBaoJia >(listjiyang, rowindex, gridView1, gridView1.FocusedRowHandle,this );
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
                    dateEdit1.DateTime = DateTime.Now;
                    txtdanhao.Text =  BianhaoBLL.CreatDanhao(FirstLetter.门市采样单 , dateEdit1.DateTime, DanjuLeiXing.门市采样单);                 
                    foreach (var j in listjiyang )
                    {
                        j.DH = txtdanhao.Text;
                        j.RQ = danju.rq;
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
           dateEdit1.DateTime=danju.rq;
            //txtyundanhao.Text = danju.wuliuBianhao ;
            //txtyunfei.Value =(double) danju.yunfei ;
            txtbeizhu.Text = danju.bz ;
            listjiyang=JiYangBaoJiaService.GetJiYangBaoJialst (x=>x.DH ==danju.dh );
            var len = listjiyang.Count;
            for (int i = 0; i <30-len ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
            }
            gridControl1.DataSource = listjiyang;
            
        }

        private void 门市采样单_FormClosing(object sender, FormClosingEventArgs e)
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
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.门市采样单, dateEdit1.DateTime, DanjuLeiXing.门市采样单 );
            }
        }

        private void 打印编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Design);
        }
        private void PrintBiaoqian(int userfule)
        {
            gridView1.CloseEditor();
            try
            {
                string printer = string.Empty;
                decimal num = 1;
                if (userfule == PrintModel.Print)
                {
                    var fm = new 打印设置窗体();
                    fm.ShowDialog();
                    printer = fm.printer;
                    num = fm.copyies;
                }
                foreach (var i in gridView1.GetSelectedRows())
                {
                    jiYangBaoJia = listjiyang[i];
                    if (jiYangBaoJia.SPMC == null && jiYangBaoJia.EnglishName == null && jiYangBaoJia.cf == null && jiYangBaoJia.gg == null)
                    {
                        break;
                    }
                    db pingzhong = new db();
                    if (jiYangBaoJia.SPBH != null)
                    {
                        pingzhong = dbService.GetOnedb(x => x.bh == jiYangBaoJia.SPBH);
                    }
                    pingzhong.bh = jiYangBaoJia.SPBH;
                    pingzhong.pm = jiYangBaoJia.SPMC;
                    pingzhong.gg = jiYangBaoJia.gg;
                    pingzhong.cf = jiYangBaoJia.cf;
                    pingzhong.kz = jiYangBaoJia.kz;
                    pingzhong.mf = jiYangBaoJia.mf;
                    pingzhong.md = jiYangBaoJia.md;
                    pingzhong.zb = jiYangBaoJia.zb;
                    pingzhong.jg = jiYangBaoJia.JG.ToString();
                    pingzhong.ys = jiYangBaoJia.ys;
                    pingzhong.lxr = jiYangBaoJia.Lianxiren;
                    pingzhong.EnglishName = jiYangBaoJia.EnglishName;
                    pingzhong.HH = jiYangBaoJia.Kuanhao;
                    pingzhong.rq = jiYangBaoJia.RQ.Date;
                    AlterDlg.Show($"正在打印第{i + 1}行信息的标签");
                    Tools.打印标签.打印(jiYangBaoJia.sl, pingzhong, new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, Printmodel = userfule, PrintName = printer, PrintNum = (int)num }, ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SPBH").ToString()), jiYangBaoJia);
                    if (userfule != PrintModel.Print)
                    { return; }
                }
                AlterDlg.Show("所有标签打印完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name);
            }

        }

        private void 打印预览ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Privew);
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Print);
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
        private void Print(int printmodel)
        {
            var danju = new DanjuTable()
            {
                dh = txtdanhao.Text,
                bz = txtbeizhu.Text,
                je = listjiyang.Sum(x => x.HejiJinE),
                rq = dateEdit1.DateTime,
                ksmc = txtkehu.Text,
            };
            var dt = new DataTable("单据明细");
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                dt.Columns.Add(gridView1.Columns[i].Caption);
            }
            int j = 0;
            foreach (var jiyang in listjiyang.Where(x => x.SPMC != null || x.EnglishName != null).ToList())
            {
                dt.Rows.Add();
                var pro = jiyang.GetType().GetProperties();
                foreach (var p in pro.ToList())
                {
                    if (p.GetValue(jiyang, null) != null)
                    {
                        if (gridView1.Columns[p.Name] != null)
                        {
                            dt.Rows[j][gridView1.Columns[p.Name].Caption] = p.GetValue(jiyang, null);
                        }
                    }
                }
                j++;
            }

            var fs = new FastReport.Report();
            var ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(CreateDanjuDatatable.DanjuConvertToDatatable(danju));
            fs.RegisterData(ds);
            try
            {
                fs.Load(PrintPath.报表模板 + "采样单.frx");
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到寄样单模板！" + ex.Message);
                fs.Design();
                return;
            }
            try
            {
                switch (printmodel)
                {
                    case PrintModel.Design:
                        fs.Design();
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                    case PrintModel.Print:
                        var fm = new 打印设置窗体();
                        fs.PrintSettings.ShowDialog = false;
                        fs.PrintSettings.Printer = fm.printer;
                        fs.PrintSettings.Copies = (int)fm.copyies;
                        fs.Print();
                        break;
                }
            }
            catch
            {
                fs.Design();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connect.SetDefault(cmbMoban.Text);
                MessageBox.Show("设置默认标签成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置默认标签失败！原因是" + ex.Message);
            }
        }

        private void 票签模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new 票签模式();
            form.ShowDialog();
            int index=0;
            for(int i=index;i<listjiyang .Count;i++)
            {
                if (string.IsNullOrWhiteSpace(listjiyang[i].SPMC))
                {
                    index = i;
                    break;
                }
                else
                {
                    index = i;
                }
            }
           foreach(JiYangBaoJia jiYangBaoJia in form.JiYangBaoJiaList )
            {                  
                    jiYangBaoJia.Danhao = txtdanhao.Text;
                    jiYangBaoJia.RQ = danju.rq;
                    jiYangBaoJia.own = User.user.YHBH;
                    listjiyang[index ] = jiYangBaoJia;
                    if (index  + 1 == listjiyang.Count)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                            listjiyang.Add(new JiYangBaoJia()
                            {
                                RQ = dateEdit1.DateTime,
                                DH = txtdanhao.Text,
                                own = User.user.YHBH
                            });
                        }
                    }
                index++;
            }
            gridControl1.RefreshDataSource ();
        }
    }
}
