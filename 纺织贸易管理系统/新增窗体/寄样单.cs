using BLL;
using DAL;
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
using System.Linq.Expressions;
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
    public partial class 寄样单 : Form
    {
        public int useful { get; set; } = FormUseful.新增;
        public DanjuTable danju { get; set; }
        public  JiYangBaoJia jiYangBaoJia = new JiYangBaoJia();
        public List<JiYangBaoJia> listjiyang = new List<JiYangBaoJia>();
        private int rowindex;
        public 寄样单()
        {
            InitializeComponent();
            cmbMoban.Items.AddRange ( Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray ());
            cmbMoban.Text = Connect.GetDefault()[0].LabelName ;          
            CreateGrid.Create(this.Name, gridView1);
            try
            {
                gridView1.Columns["SPBH"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["ys"].ColumnEdit = colorbtn;
                gridView1.Columns["bizhong"].ColumnEdit = cmbbizhong;
                gridView1.Columns["Danwei"].ColumnEdit = cmbdanwei;
                gridView1.Columns["Leixing"].ColumnEdit = cmbleixing;
                gridView1.Columns["Lianxiren"].ColumnEdit = cmblianxiren;
                gridView1.Columns["hs"].ColumnEdit = cmbhanshui;
                gridView1.Columns["HejiJinE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["HejiJinE"].SummaryItem.FieldName = "HejiJinE";
                gridView1.Columns["HejiJinE"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns["sl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["sl"].SummaryItem.FieldName = "sl";
                gridView1.Columns["sl"].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.IndicatorWidth = 30;
                cmbCangkumingcheng.DataSource = StockInfoTableService.GetStockInfoTablelst(x => x.Leixing.Contains("")).Select(x => x.mingcheng).ToList();
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new JiYangBaoJia () };
            fm.ShowDialog();
        }
        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = txtkehu.Text, MC = "" } };
            fm.ShowDialog();
            jiYangBaoJia.KHBH = fm.linkman.BH;
            jiYangBaoJia.KHMC = fm.linkman.MC;
            txtkehu.Text = fm.linkman.MC;
            加载联系人();
        }
        private void 加载联系人()
        {
            cmblianxiren.Items.Clear();
            foreach (var lxr in JiYangBaoJiaService.GetJiYangBaoJialst(x=>x.KHMC==txtkehu.Text ).Select (x=>x.Lianxiren ).Distinct ().ToList ())
            {
                cmblianxiren.Items.Add(lxr);
            }
        }
        private void buttonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 物流选择 ();
            fm.ShowDialog();
            jiYangBaoJia.kdgs = fm.linkman.Bianhao ;
            txtwuliu.Text = fm.linkman.name ;
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
                Connect.SetDefault(cmbMoban.Text);
                MessageBox.Show("设置默认标签成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置默认标签失败！原因是" + ex.Message);
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (chkCangku.Checked == true)
            {
                var fm = new 库存选择() { StockName = cmbCangkumingcheng.Text };
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    listjiyang[i].bizhong = "人民币￥";
                    listjiyang[i].SPBH = pingzhong.BH;
                    listjiyang[i].gg = pingzhong.GG;
                    listjiyang[i].cf = pingzhong.CF;
                    listjiyang[i].SPMC = pingzhong.PM;
                    listjiyang[i].kz = pingzhong.KZ;
                    listjiyang[i].md = "";
                    listjiyang[i].mf = pingzhong.MF;
                    listjiyang[i].zb = "";
                    listjiyang[i].EnglishName = dbService.GetOnedb(x => x.bh == pingzhong.BH).EnglishName;
                    listjiyang[i].ys = pingzhong.YS;
                    listjiyang[i].Ganghao = pingzhong.GH;
                    listjiyang[i].Hetonghao = pingzhong.ContractNum;
                    listjiyang[i].OrderNum = pingzhong.orderNum;
                    listjiyang[i].GHSMC = pingzhong.houzhengli;
                    listjiyang[i].Kuanhao = pingzhong.kuanhao;
                    listjiyang[i].Kuwei = pingzhong.Kuwei;
                    i++;
                    if (i == listjiyang.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            listjiyang.Add(new JiYangBaoJia() { Danhao = txtdanhao.Text, RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
                        }
                }
                fm.Dispose();
            }
            else
            {
                SelectPingzhong();
            }
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }
        private void SelectPingzhong()
        {         
            var fm = new 品种选择();      
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                listjiyang[i].bizhong = "人民币￥";
                listjiyang[i].SPBH = pingzhong.bh ;
                listjiyang[i].gg = pingzhong.gg;
                listjiyang[i].cf = pingzhong.cf;
                listjiyang[i].SPMC = pingzhong.pm;
                listjiyang[i].kz = pingzhong.kz;
                listjiyang[i].md = "";
                listjiyang[i].mf = pingzhong.mf;
                listjiyang[i].zb = "";
                listjiyang[i].EnglishName = dbService.GetOnedb(x => x.bh == pingzhong.bh).EnglishName;
                listjiyang[i].ys = pingzhong.ys;
                listjiyang[i].Ganghao = "";
                listjiyang[i].Hetonghao = "";
                listjiyang[i].OrderNum ="";
                listjiyang[i].GHSMC ="";
                listjiyang[i].Kuanhao = "";
                listjiyang[i].Kuwei ="";
                listjiyang[i].PibuPrice = Regex.IsMatch(pingzhong.PBPrice, @"^[+-]?\d*[.]?\d*$") ? pingzhong.PBPrice.ToDecimal(0) : 0;
                listjiyang[i].Houzhengli = pingzhong.hzl;
                listjiyang[i].HouzhengliPrice = Regex.IsMatch(pingzhong.hzljg, @"^[+-]?\d*[.]?\d*$") ? pingzhong.hzljg.ToDecimal(0) : 0;
                listjiyang[i].RQ = dateEdit1.DateTime.Date;
                var auto = SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "寄样自动价格", settingValue ="" }).settingValue;
                if(auto!=string.Empty )
                {
                    if (auto == "自动")
                    {
                        listjiyang[i].JG = pingzhong.jg.ToDecimal(0);
                    }
                    else
                    {
                        listjiyang[i].JG = 0;
                    }
                }              
                i++;
                if (i == listjiyang.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        listjiyang.Add(new JiYangBaoJia() { Danhao = txtdanhao.Text, RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
                    }
            }
            fm.Dispose();
            gridControl1.RefreshDataSource();
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
                j.Danhao = txtyundanhao.Text;
                j.kdgs = txtwuliu.Text;
                j.ydh = txtyundanhao.Text;
                j.yf = (decimal)txtyunfei.Value;
                j.RQ = Convert.ToDateTime(dateEdit1.DateTime.Date.ToString ());
                j.DH = txtdanhao.Text;
                j.KHMC = txtkehu.Text;
                j.KHBH = jiYangBaoJia.KHBH;
                j.own = User.user.YHBH;
                j.zt =(chkCangku.Checked?1:0);
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();

            try
            {
                //txtdanhao.Text = 单据BLL.检查单号(txtdanhao.Text);
                var danju = new DanjuTable()
                {
                    dh =txtdanhao.Text ,
                    ksbh = jiYangBaoJia.KHBH,
                    ksmc = jiYangBaoJia .KHMC,
                    rq = dateEdit1.DateTime ,
                    je = listjiyang.Sum(x => x.HejiJinE),
                    TotalMishu = listjiyang.Sum(x => x.sl),
                    wuliuBianhao = txtyundanhao.Text,
                    wuliugongsi = txtwuliu.Text,
                    djlx = "寄样单",
                    yunfei = txtyunfei.Text.ToDecimal(0),
                    bz = txtbeizhu.Text,
                    ckmc = cmbCangkumingcheng.Text,
                    Qiankuan=cmbqiankuan.Text,
                    Hanshui=comhanshui.Text ,
                    own = User.user.YHBH
            };
                列表赋值 ();
                if (useful == FormUseful.新增)
                {
                    寄样单BLL.保存寄样单(listjiyang.Where (x=>!string.IsNullOrWhiteSpace (x.SPMC)||!string.IsNullOrWhiteSpace(x.EnglishName ) || !string.IsNullOrWhiteSpace(x.SPBH)).ToList (), danju,chkCangku .Checked );
                }
                else
                {
                    if (useful == FormUseful.复制)
                    {
                        寄样单BLL.保存寄样单(listjiyang.Where(x => !string.IsNullOrWhiteSpace(x.SPMC) || !string.IsNullOrWhiteSpace(x.EnglishName) || !string.IsNullOrWhiteSpace(x.SPBH)).ToList(), danju, chkCangku.Checked);
                    }
                    else
                    {
                     寄样单BLL.修改单据(listjiyang.Where(x => !string.IsNullOrWhiteSpace(x.SPMC) || !string.IsNullOrWhiteSpace(x.EnglishName) || !string.IsNullOrWhiteSpace(x.SPBH)).ToList(), danju, chkCangku.Checked);
                    }
                }
                AlterDlg.Show("保存成功！");
                Init();
                useful = FormUseful.新增;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存单据时发送了错误"+ex.Message , this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Init()
        { 
            dateEdit1.DateTime  = DateTime.Now ;
            txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.寄样单 , dateEdit1.DateTime, DanjuLeiXing.寄样单 );
            txtkehu.Text = "";
            txtwuliu.Text = "";          
            txtyundanhao.Text = "";
            txtyunfei.Value=0;
            txtbeizhu.Text = "";
            listjiyang.Clear();
            for (int i = 0; i < 30 ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
            }
            gridControl1.DataSource=listjiyang ;
            gridControl1.RefreshDataSource();
        }
        private void Print(int printmodel)
        {
            var danju = new DanjuTable() {dh=txtdanhao.Text ,wuliugongsi=txtwuliu .Text , bz =txtbeizhu.Text, yunfei =Convert.ToDecimal ( txtyunfei .Text) ,
             je=listjiyang.Sum (x=>x.HejiJinE ),
            wuliuBianhao =txtyundanhao.Text ,
            rq=Convert.ToDateTime(dateEdit1.Text ),
            ksmc=txtkehu.Text ,
            CarNum=txtyundanhao.Text 
            };
            var dt = new DataTable("单据明细");
            for (int i = 0; i < gridView1 .Columns.Count; i++)
            {
                dt.Columns.Add(gridView1.Columns[i].Caption);
            }
            int j = 0;
            foreach (var jiyang in listjiyang.Where (x=>x.SPMC!=null||x.EnglishName!=null ).ToList ())
            {
                dt.Rows.Add();   
                    var pro = jiyang.GetType().GetProperties();
                    foreach (var p in pro.ToList())
                    {                 
                        if (p.GetValue(jiyang ,null)!= null)
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
              fs.Load(PrintPath.报表模板 + "jiyangdan.frx");
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
        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetAccess.IsCanPrintDesign)
            {
                Print(PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }
        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Privew);
        }
        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Print );
        }
        private void 打印寄样标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Print);
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
                    if (string.IsNullOrWhiteSpace ( jiYangBaoJia.SPMC ) &&string.IsNullOrWhiteSpace ( jiYangBaoJia.EnglishName)  &&string.IsNullOrWhiteSpace ( jiYangBaoJia.cf ) &&string.IsNullOrWhiteSpace ( jiYangBaoJia.gg ))
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
                    pingzhong.rq = dateEdit1.DateTime ;
                    pingzhong.hzl = jiYangBaoJia.Houzhengli;
                    pingzhong.hzljg = jiYangBaoJia.HouzhengliPrice.ToString ();
                    AlterDlg.Show($"正在打印第{i+1}行信息的标签");
                    Tools.打印标签.打印(jiYangBaoJia.sl, pingzhong, new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, Printmodel = userfule, PrintName = printer, PrintNum = (int)num }, ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SPBH").ToString()),jiYangBaoJia );
                    if (userfule != PrintModel.Print)
                    { return; }
                }
                AlterDlg.Show("所有标签打印完毕！");
            }
               catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name);
            }

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
            CopyRow.Copy<JiYangBaoJia >(listjiyang, rowindex, gridView1, gridView1.FocusedRowHandle,this);
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
                    txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.寄样单, dateEdit1.DateTime, DanjuLeiXing.寄样单);
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
            txtdanhao.Text = jiYangBaoJia.DH  ;     
            txtkehu.Text = jiYangBaoJia .KHMC  ;
            txtwuliu.Text = jiYangBaoJia.kdgs ;
            dateEdit1.DateTime= jiYangBaoJia .RQ;
            txtyundanhao.Text = jiYangBaoJia .ydh  ;
            txtyunfei.Value =(double) jiYangBaoJia.yf  ;        
            danju = DanjuTableService.GetOneDanjuTable(x => x.dh == jiYangBaoJia.DH);
            cmbCangkumingcheng.Text = danju.ckmc;
            txtbeizhu.Text = danju.bz ;
            listjiyang=JiYangBaoJiaService.GetJiYangBaoJialst (x=>x.DH ==jiYangBaoJia .DH  );
            var len = listjiyang.Count;
            for (int i = 0; i <30-len ; i++)
            {
                listjiyang.Add(new JiYangBaoJia() { RQ = dateEdit1.DateTime, DH = txtdanhao.Text });
            }
            gridControl1.DataSource = listjiyang;
            加载联系人();
        }

        private void 打印预览ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Privew);
        }

        private void 打印编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintBiaoqian(PrintModel.Design);
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                var fm = new 客户选择() { linkman=new LXR() { ZJC=txtkehu.Text ,MC=""} };
                fm.ShowDialog();
                jiYangBaoJia.KHBH = fm.linkman.BH;
                jiYangBaoJia.KHMC = fm.linkman.MC;
                txtkehu.Text = fm.linkman.MC;
                加载联系人();
            }
        }

        private void colorbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 色号选择();
            fm.ShowDialog();
            listjiyang [gridView1.FocusedRowHandle].ys = fm.colorInfo.ColorNum;
            gridView1.CloseEditor();
            gridControl1.RefreshDataSource();
        }

        private void 寄样单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful != FormUseful.修改 )
            {
                if (dateEdit1.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BianhaoBLL.CreatDanhao(FirstLetter.寄样单 , dateEdit1.DateTime, DanjuLeiXing.寄样单 );
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void ButtonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                SelectPingzhong();
            }
        }

        private void 打印寄样单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.CloseEditor();
                var colorlist = ColorTableService.GetColorTablelst(x => x.ColorNum.Contains(listjiyang [gridView1.FocusedRowHandle].ys ));
                ColorTable color = new ColorTable();
                if (colorlist.Count > 1)
                {
                    var fm = new 色号选择() { colorInfo = new ColorTable() { ColorNum = listjiyang [gridView1.FocusedRowHandle].ys } };
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
                    //listjiyang [gridView1.FocusedRowHandle]. = color.ColorNum;
                    listjiyang [gridView1.FocusedRowHandle].ys  = color.ColorName;
                }
                gridControl1.RefreshDataSource();
            }
        }
    }
}
