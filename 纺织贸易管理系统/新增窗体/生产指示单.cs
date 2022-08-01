using BLL;
using DAL;
using FastReport;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.基本资料;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;
using PictureBoxEx = 纺织贸易管理系统.设置窗体.PictureBoxEx;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 生成指示单 : Form
    {
        public  List<ShengchanBuliaoInfo> shengchanBuliaoInfos = new List<ShengchanBuliaoInfo>();
        private List<ShengchanHouzhengli> gongyis = new List<ShengchanHouzhengli>();
        private List<ShengchanChanshangTable > changjialist = new List<ShengchanChanshangTable >();
        private List<ShengChanFuHeMingxi > fuHeMingxis  = new List<ShengChanFuHeMingxi>();
        private int rowindex;
        public ShengChanDanTable shengchandan = new ShengChanDanTable();
        public int useful=FormUseful.新增 ;
        private int imageindex = 0;
       private List<Bitmap> imgs = new List<Bitmap>();
        public 生成指示单()
        {
            InitializeComponent();
            cmbMoban.SelectedIndex = 0;
            CreateGrid.Create(this.Name, gridView1);
            CreateGrid.Create(this.Name, gridView4);
            CreateGrid.Create(this.Name, gridView3);
            CreateGrid.Create(this.Name, gridView2);
            try
            {
                gridView1.Columns["BuliaoPingming"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["SampleNum"].ColumnEdit = ButtonEdit1;
                gridView1.Columns["Danwei"].ColumnEdit = cmbdanwei ;
                gridView1.Columns["FriceUnit"].ColumnEdit = cmbdanwei;
                //////
                ///
                gridView1.Columns["ChengpingMishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["ChengpingMishu"].SummaryItem.FieldName = "ChengpingMishu";
                gridView1.Columns["ChengpingMishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                //
                gridView1.Columns["YutouMishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["YutouMishu"].SummaryItem.FieldName = "YutouMishu";
                gridView1.Columns["YutouMishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                //
                gridView1.Columns["PibuPlaneNum"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["PibuPlaneNum"].SummaryItem.FieldName = "PibuPlaneNum";
                gridView1.Columns["PibuPlaneNum"].SummaryItem.DisplayFormat = "{0:0.##}";
                //
                gridView1.Columns["PeitongPishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["PeitongPishu"].SummaryItem.FieldName = "PeitongPishu";
                gridView1.Columns["PeitongPishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                //
                gridView1.Columns["PeitongMishu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["PeitongMishu"].SummaryItem.FieldName = "PeitongMishu";
                gridView1.Columns["PeitongMishu"].SummaryItem.DisplayFormat = "{0:0.##}";
                //
                gridView1.Columns["ChengpingJuanshu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["ChengpingJuanshu"].SummaryItem.FieldName = "ChengpingJuanshu";
                gridView1.Columns["ChengpingJuanshu"].SummaryItem.DisplayFormat = "{0:0.##}";
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            } 
            try
            {
                gridView4.Columns["chanjiamingcheng"].ColumnEdit = btnChangjia;
                gridView4.Columns["leixing"].ColumnEdit = ComboBox1;
                gridView4.Columns["Jiaoqi"].ColumnEdit = rDateEdit1;
                gridView2.Columns["yaoqiumingcheng"].ColumnEdit = ComboBox3;
            }
            catch
            {
                toolStripMenuItem9_Click(null, null);
            }
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj=new ShengchanBuliaoInfo() };
            fm.ShowDialog();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
           
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo() { ShengChanDanhao = txtdanhao.Text });
            //gridView1.AddNewRow();
            gridControl1.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView1.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            CopyRow.Copy<ShengchanBuliaoInfo >(shengchanBuliaoInfos , rowindex, gridView1, gridView1.FocusedRowHandle,this);            
        }

        private void TxtOrder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 订单号选择();
            fm.ShowDialog();
            if (fm.Order != null)
            {
                txtorder.Text = fm.Order.OrderNum;
                dateEdit1.DateTime = fm.Order.Orderdate;
                txthetonghao.Text = fm.Order.ContractNum;
                txtkehu.Text = fm.Order.CustomerName;
                var res = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == txtorder.Text);
                shengchanBuliaoInfos.Clear();
                foreach (var d in res)
                {
                    shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo()
                    {
                        BuliaoPingming = d.sampleName,
                        PibuPlaneNum = d.YutouMishu - d.Yitoumishu,
                        Yanse = d.color,
                        Kuanhao = d.Kuanhao,
                        SampleNum = d.sampleNum,
                        ColorNum = d.ColorNum,
                        ChengpingMishu = d.Num,
                        Kezhong = d.weight,
                        Menfu = d.width,
                        Suolv = "0",
                        PeiTongDate = DateTime.Now,
                        Jiaoqi = DateTime.Now.AddDays(30),
                        ShengChanDanhao = txtdanhao.Text,
                        Danwei = "米"
                    });
                }
                for (int i = res.Count; i < 30; i++)
                {
                    shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo() { ShengChanDanhao  = txtdanhao.Text });
                }
                gridControl1.RefreshDataSource();
                gridView1.CloseEditor();
                foreach (var s in shengchanBuliaoInfos.Select(x => x.Yanse).Distinct().ToList())
                {
                    if (s != null)
                    {
                        ComboBox2.Items.Add(s);
                    }
                }
                gridView3.Columns["MianBuColor"].ColumnEdit = ComboBox2;
                gridView3.Columns["DiBuColor"].ColumnEdit = ComboBox2;
            }
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtorder.Text))
            {
                var fm = new 品种选择();
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong)
                {
                    shengchanBuliaoInfos[i].BuliaoPingming = pingzhong.pm;
                    shengchanBuliaoInfos[i].SampleNum = pingzhong.bh;
                    shengchanBuliaoInfos[i].Menfu  = pingzhong.mf;
                    shengchanBuliaoInfos[i].Kezhong  = pingzhong.kz ;
                    shengchanBuliaoInfos[i].Danwei  ="米";
                    i++;
                    if (i >= shengchanBuliaoInfos.Count + 1)
                    {
                        shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo());
                    }
                }
            }
            else
            {
                var fm = new 订单明细选择() { OrderNum =txtorder.Text };
                fm.ShowDialog();
                var i = gridView1.FocusedRowHandle;
                foreach (var pingzhong in fm.pingzhong )
                {
                    shengchanBuliaoInfos[i].BuliaoPingming = pingzhong.sampleName ;
                    shengchanBuliaoInfos[i].SampleNum = pingzhong.sampleNum;
                    shengchanBuliaoInfos[i].Menfu = pingzhong.width;
                    shengchanBuliaoInfos[i].Kezhong = pingzhong.weight;
                    shengchanBuliaoInfos[i].PibuPlaneNum = pingzhong.YutouMishu - pingzhong.Yitoumishu;
                    shengchanBuliaoInfos[i].ChengpingMishu = pingzhong.Num;
                    shengchanBuliaoInfos[i].Danwei  = "米";
                    i++;
                    if (i >= shengchanBuliaoInfos.Count + 1)
                    {
                        shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo());
                    }
                }
            }
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var s = shengchanBuliaoInfos[gridView1.FocusedRowHandle];
           s.Suolv = ((s.PeitongMishu - s.ChengpingMishu) / 100).ToString();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name,Obj =new ShengchanHouzhengli  ()  };
            fm.ShowDialog();
        }

        private void 生成指示单_Load(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                //
                foreach (DataRow g in Connect.CreatConnect ().Query ("select distinct leixing from ShengchanChanshangTable").Rows )
                {
                    ComboBox1.Items.Add(g["leixing"].ToString ());
                }
                foreach (var g in GongYiYaoqiuService.GetGongYiYaoqiulst())
                {
                    ComboBox3.Items.Add(g.name);
                }
            });
            if (useful==FormUseful.新增 )
            {
                Init();
            }
            else
            {
                if (useful == FormUseful.跳转)
                {
                    跳转();
                }
                else
                {
                    Edit();
                    if (useful == FormUseful.查看)
                    {
                        保存ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        if (useful == FormUseful.复制)
                        {
                            dateEdit2.DateTime = DateTime.Now;
                            cmbZhuangtai.Text = "未完成";
                        }
                    }
                }
            }
            gridControl4.RefreshDataSource();
        }
        private void Edit()
        {
            txtdanhao.Text = shengchandan.shengchandanhao ;
            txtorder.Text = shengchandan.OrderNum ;
            txthetonghao.Text = shengchandan.Hetonghao ;
            dateEdit1.DateTime =shengchandan.jiaohuoriqi  ;
            dateEdit2.DateTime = shengchandan.riqi ;
            TxtPibulaiyuan.Text = shengchandan.SampleFrom;
            txtgendanyuan.Text = shengchandan.Genduanyuan;
            txtJiagongdanwei.Text = shengchandan.Jiagongchang;
            txtxiadanyuan.Text = shengchandan.Xiadanyuan;
            cmbZhuangtai.Text = shengchandan.State;
            txtkehu.Text = shengchandan.CustomerName;
            txtbeizhu.Text = "";
            shengchanBuliaoInfos = ShengchanBuliaoInfoService.GetShengchanBuliaoInfolst(x => x.ShengChanDanhao == shengchandan.shengchandanhao);
            gongyis = ShengchanHouzhengliService.GetShengchanHouzhenglilst(x => x.shengchandanhao == shengchandan.shengchandanhao);
            changjialist = ShengchanChanshangTableService.GetShengchanChanshangTablelst(x => x.ShengChandanhao == shengchandan.shengchandanhao);
            fuHeMingxis = ShengChanFuHeMingxiService.GetShengChanFuHeMingxilst(x => x.ShengChanDanHao == shengchandan.shengchandanhao);
            CreateGrid.Query<ShengchanBuliaoInfo>(gridControl1, shengchanBuliaoInfos);
            CreateGrid.Query<ShengchanHouzhengli>(gridControl2, gongyis);
            CreateGrid.Query<ShengChanFuHeMingxi >(gridControl3, fuHeMingxis );
            CreateGrid.Query<ShengchanChanshangTable >(gridControl4, changjialist );
            for (int i = 0; i < 30-gongyis.Count ; i++)
            {
                gongyis.Add(new ShengchanHouzhengli() { shengchandanhao = txtdanhao.Text });
            }
            for (int i = 0; i < 30 - shengchanBuliaoInfos .Count; i++)
            {
                shengchanBuliaoInfos .Add(new ShengchanBuliaoInfo () { ShengChanDanhao  = txtdanhao.Text, Jiaoqi = dateEdit1.DateTime, PeiTongDate = dateEdit2.DateTime });
            }
            gridControl1.RefreshDataSource();
            gridControl4.RefreshDataSource();
           foreach (var pic in MadanPictureService.GetMadanPicturelst(x => x.ckdh == txtdanhao.Text).Select(x => x.picture).ToList()){
                imgs.Add(Tools.ImgHelp.BytesToBitmap (pic));
            }
           if(imgs.Count >0)
            {
                pictureBox1.Image = imgs[0];
            }
        }
        private void 生产单赋值()
        {
            shengchandan.OrderNum = txtorder.Text;
            shengchandan.shengchandanhao = txtdanhao.Text;
            shengchandan.Hetonghao = txthetonghao.Text;
            shengchandan.jiaohuoriqi = dateEdit1.DateTime.Date ;
            shengchandan.riqi = dateEdit2.DateTime.Date ;
            shengchandan.SampleFrom = TxtPibulaiyuan.Text;
            shengchandan.hejiyutoumishu = shengchanBuliaoInfos.Sum(x => x.PibuPlaneNum );
            shengchandan.Hejimishu = shengchanBuliaoInfos.Sum(x => x.ChengpingMishu);
            shengchandan.Jiagongchang = txtJiagongdanwei.Text;
            shengchandan.Xiadanyuan = txtxiadanyuan.Text;
            shengchandan.Genduanyuan = txtgendanyuan.Text;
            shengchandan.own = User.user.YHBH;
            shengchandan.CustomerName = txtkehu.Text;
            shengchandan.State =cmbZhuangtai.Text ;
            shengchandan.Remark = txtbeizhu.Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            gridView4.CloseEditor();
            if (shengchanBuliaoInfos .Where(x => !string.IsNullOrWhiteSpace(x.SampleNum )).ToList().Count == 0)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "没有检测到任何布料信息.请选择相应的布料后再保存！");
                return;
            }
            生产单赋值();
            if (useful == FormUseful.新增)
            {
                生产计划单BLL.Save(shengchandan, shengchanBuliaoInfos.Where(x => !string.IsNullOrWhiteSpace ( x.BuliaoPingming) ).ToList(), gongyis.Where(x => !string.IsNullOrWhiteSpace(x.yaoqiumingcheng )).ToList(), changjialist.Where (x=> !string.IsNullOrWhiteSpace(x.chanjiamingcheng )).ToList ());
                fuHeMingxis.ForEach(x => x.ShengChanDanHao = shengchandan.shengchandanhao);
                ShengChanFuHeMingxiService.InsertShengChanFuHeMingxilst(fuHeMingxis .Where (x=> !string.IsNullOrWhiteSpace(x.MianBuColor)).ToList ());
                foreach(var img in imgs )
                {
                    MadanPictureService.InsertMadanPicture(new MadanPicture() { ckdh=txtdanhao.Text ,rq=dateEdit1.DateTime ,picture =BitmapByte (img),khbh=txtkehu.Text});
                }
            }
            else
            {
                ShengChanFuHeMingxiService.DeleteShengChanFuHeMingxi(x => x.ShengChanDanHao == txtdanhao.Text);
                ShengChanFuHeMingxiService.InsertShengChanFuHeMingxilst(fuHeMingxis.Where(x => !string.IsNullOrWhiteSpace(x.MianBuColor)).ToList());
                生产计划单BLL.Edit (shengchandan, shengchanBuliaoInfos.Where(x => !string.IsNullOrWhiteSpace(x.BuliaoPingming)).ToList(), gongyis.Where(x => !string.IsNullOrWhiteSpace(x.yaoqiumingcheng )).ToList(), changjialist.Where(x => !string.IsNullOrWhiteSpace(x.chanjiamingcheng )).ToList());
                MadanPictureService.DeleteMadanPicture(x => x.ckdh == txtdanhao.Text);
                foreach (var img in imgs)
                {
                    MadanPictureService.InsertMadanPicture(new MadanPicture() { ckdh = txtdanhao.Text, rq = dateEdit1.DateTime, picture = BitmapByte(img), khbh = txtkehu.Text });
                }
            }
            AlterDlg.Show("保存成功！");
            Init();
        }
        private void Init()
        {          
            txtorder.Text = "";
            txthetonghao.Text = "";
            dateEdit1.DateTime = DateTime.Now.AddDays (30);
            dateEdit2.DateTime = DateTime.Now; 
            txtdanhao.Text = BLL.BianhaoBLL.CreatShengchangDanhao (FirstLetter.生产指示单, dateEdit2.DateTime, DanjuLeiXing.生产指示单);
            txtbeizhu.Text = "";
            shengchanBuliaoInfos.Clear();
            gongyis.Clear(); 
            CreateGrid.Query<ShengchanBuliaoInfo>(gridControl1, shengchanBuliaoInfos);
            CreateGrid.Query<ShengchanChanshangTable >(gridControl4, changjialist );
            CreateGrid.Query<ShengChanFuHeMingxi>(gridControl3, fuHeMingxis);
            CreateGrid.Query<ShengchanHouzhengli >(gridControl2, gongyis );
            for (int i = 0; i < 30; i++)
            {
                gongyis.Add(new ShengchanHouzhengli() { shengchandanhao=txtdanhao.Text });  
                shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo() { ShengChanDanhao = txtdanhao.Text ,Jiaoqi =dateEdit1.DateTime , PeiTongDate=dateEdit2.DateTime }); 
                changjialist .Add(new ShengchanChanshangTable () { ShengChandanhao = txtdanhao.Text ,Jiaoqi=dateEdit1.DateTime });
                fuHeMingxis.Add(new ShengChanFuHeMingxi() { ShengChanDanHao = txtdanhao.Text });
            }
            var glist = GongYiYaoqiuService.GetGongYiYaoqiulst();
          for(var i=0;i<glist.Count;i++)
            {
                gongyis[i].yaoqiumingcheng = glist[i].name;
            }
            gridControl1.RefreshDataSource();
            gridControl4.RefreshDataSource();
            gridControl3.RefreshDataSource();
            gridControl2.RefreshDataSource();
        }
        private void 跳转()
        {
            txtorder.Text = shengchandan.OrderNum ;
            txthetonghao.Text = shengchandan.Hetonghao ;
            dateEdit1.DateTime = DateTime.Now.AddDays(30);
            dateEdit2.DateTime = DateTime.Now;
            txtdanhao.Text = BLL.BianhaoBLL.CreatShengchangDanhao(FirstLetter.生产指示单, dateEdit2.DateTime, DanjuLeiXing.生产指示单);
            txtbeizhu.Text = "";
            gongyis.Clear();
            CreateGrid.Query<ShengchanBuliaoInfo >(gridControl1,shengchanBuliaoInfos );
            CreateGrid.Query<ShengchanChanshangTable>(gridControl4, changjialist);
            CreateGrid.Query<ShengChanFuHeMingxi>(gridControl3, fuHeMingxis);
            CreateGrid.Query<ShengchanHouzhengli>(gridControl2, gongyis);
            for(int i=0;i<30-shengchanBuliaoInfos .Count ;i++)
            {
                shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo() { ShengChanDanhao = txtdanhao.Text, Jiaoqi = dateEdit1.DateTime, PeiTongDate = dateEdit2.DateTime });
            }
            for (int i = 0; i < 30; i++)
            {
                gongyis.Add(new ShengchanHouzhengli() { shengchandanhao = txtdanhao.Text });               
                changjialist.Add(new ShengchanChanshangTable() { ShengChandanhao = txtdanhao.Text, Jiaoqi = dateEdit1.DateTime });
                fuHeMingxis.Add(new ShengChanFuHeMingxi() { ShengChanDanHao = txtdanhao.Text });
            }
            var glist = GongYiYaoqiuService.GetGongYiYaoqiulst();
            for (var i = 0; i < glist.Count; i++)
            {
                gongyis[i].yaoqiumingcheng = glist[i].name;
            }
            gridControl1.RefreshDataSource();
            gridControl4.RefreshDataSource();
            gridControl3.RefreshDataSource();
            gridControl2.RefreshDataSource();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Design);
        }
        private void Print(int useful)
        {
            gridView1.CloseEditor();
            gridView2.CloseEditor();
            gridView3.CloseEditor();
            gridView4.CloseEditor();
            var gongyilist = GongYiYaoqiuService.GetGongYiYaoqiulst();
            var gongyitable = new DataTable("工艺要求");
            foreach (var g in gongyilist )
            {
                gongyitable.Columns.Add(g.name);
            }
            gongyitable.Rows.Add();
            foreach (var g in gongyis.Where (x=>x.yaoqiumingcheng !=null).ToList ())
            {
                if (!string.IsNullOrWhiteSpace(g.yaoqiumingcheng))
                {
                    try
                    {
                        gongyitable.Rows[0][g.yaoqiumingcheng] = string.IsNullOrWhiteSpace(g.yaoqiu) ?  string.Empty:g.yaoqiu;
                    }
                    catch
                    { }
                }
            }
            生产单赋值();
                DataSet ds = new DataSet();
            try
            {
                var shengchandandt = Tools.CreateDanjuDatatable.CreateTable<ShengChanDanTable>(shengchandan, new FormInfo() { FormName = "生产计划单查询", GridviewName = "gridView1" }, "生产单信息","");
                shengchandandt.Columns.Add("客户名称",typeof(string));
                shengchandandt.Rows[0]["客户名称"] = txtkehu.Text;
                var buliaodt = Tools.CreateDanjuDatatable.CreateTable<ShengchanBuliaoInfo>(shengchanBuliaoInfos.Where(x => x.BuliaoPingming != null).ToList(), new FormInfo() { FormName = "生成指示单", GridviewName = "gridView1" }, "生产单布料信息");
                var gongyidt = Tools.CreateDanjuDatatable.CreateTable<ShengchanHouzhengli>(gongyis.Where(x => x.yaoqiumingcheng != null).ToList(), new FormInfo() { FormName = "生成指示单", GridviewName = "gridView2" }, "生产单要求信息");
                var fuhedt = Tools.CreateDanjuDatatable.CreateTable<ShengChanFuHeMingxi>(fuHeMingxis.Where(x => x.MianBuColor != null).ToList(), new FormInfo() { FormName = "生成指示单", GridviewName = "gridView3" }, "复合信息");
                var changliangdt = Tools.CreateDanjuDatatable.CreateTable<ShengchanChanshangTable>(changjialist.Where(x => x.chanjiamingcheng != null).ToList(), new FormInfo() { FormName = "生成指示单", GridviewName = "gridView4" }, "生产单工艺信息");
                ds.Tables.Add(shengchandandt);
                ds.Tables.Add(buliaodt);
                ds.Tables.Add(gongyidt);
                ds.Tables.Add(gongyitable);
                ds.Tables.Add(fuhedt);
                ds.Tables.Add(changliangdt);
                DataTable imgDatatable = new DataTable("图片");
                for (int i = 0; i < 3; i++)
                {
                    imgDatatable.Columns.Add("图片"+i.ToString (), typeof(Byte[]));
                }
                int row = 0;
                if(imgs.Count >0)
                {
                    for (int i = 0; i < imgs.Count; i++)
                    {
                        imgDatatable.Rows.Add();
                        for (int r = 0; r < 3; r++)
                        {
                            imgDatatable.Rows[row][r] = BitmapByte(imgs[i]);
                            i++;
                            if (i == imgs.Count)
                            {
                                break;
                            }
                        }
                    }                   
                    row++;
                }
                else
                {
                    imgDatatable.Rows.Add();
                    imgDatatable.Rows[row][0] = pictureBox1.Image ;
                }
                ds.Tables.Add(imgDatatable);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Report fs = new FastReport.Report();
            try
            {
                fs.RegisterData(ds);
                fs.Load(PrintPath.报表模板 +(cmbMoban.SelectedIndex ==0? "shengchandan.frx":"生产流程表.frx"));
                switch (useful )
                {
                    case PrintModel.Design :
                        fs.Design();
                        var path = PrintPath.报表模板 + (cmbMoban.SelectedIndex == 0 ? "shengchandan.frx" : "生产流程表.frx");
                        var arr = path.Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.报表);
                        ReportService.LoadReport(path, new ReportTable { reportStyle = ReportService.报表, reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Print:
                        fs.Print();
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                }
            }
            catch
            {
                fs.Design();
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void 生成指示单_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TxtPibulaiyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();          
            TxtPibulaiyuan .Text = fm.linkman.MC;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Print(PrintModel.Privew );
        }

        private void 工艺名称维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 要求名称();
            MainForm.mainform.AddMidForm(fm);
        }

        private void 添加行ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridView2.AddNewRow();
        }

        private void 删除行ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }

        private void 重新加载要求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox3.Items.Clear();
            foreach (var g in GongYiYaoqiuService.GetGongYiYaoqiulst())
            {
                ComboBox3.Items.Add(g.name);
            }
        }

        private void txtJiagongdanwei_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            txtJiagongdanwei.Text = fm.linkman.MC;
        }

        private void txtgendanyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择 () { linkman = new YuanGongTable() { Xingming  = ""} };
            fm.ShowDialog();
            txtgendanyuan .Text = fm.linkman.Xingming ;
        }

        private void txtxiadanyuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择() { linkman = new YuanGongTable() { Xingming = "" } };
            fm.ShowDialog();
            txtxiadanyuan.Text = fm.linkman.Xingming;
        }

        private void btnChangjia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 供货商选择() { linkman = new LXR() { MC = "", ZJC = "" } };
            fm.ShowDialog();
            gridView4.SetRowCellValue (gridView4.FocusedRowHandle, "chanjiamingcheng" , fm.linkman.MC);
            gridControl4.RefreshDataSource();
        }

        private void 选择所有品种ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                shengchanBuliaoInfos[i].BuliaoPingming = pingzhong.pm;
                shengchanBuliaoInfos[i].SampleNum = pingzhong.bh;
                i++;
                if (i >= shengchanBuliaoInfos.Count + 1)
                {
                    shengchanBuliaoInfos.Add(new ShengchanBuliaoInfo());
                }
            }
            gridControl1.RefreshDataSource();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView3) { formname = this.Name, Obj = new ShengChanFuHeMingxi () };
            fm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView3);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            gridView3.AddNewRow();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            gridView3.DeleteRow(gridView3.FocusedRowHandle);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView4) { formname = this.Name, Obj = new ShengchanChanshangTable() };
            fm.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView4);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            gridView4.AddNewRow();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            gridView4.DeleteRow(gridView4.FocusedRowHandle);
        }

        private void dateEdit2_DateTimeChanged(object sender, EventArgs e)
        {
            if (useful  != FormUseful.修改 && useful  != FormUseful.查看)
            {
                if (dateEdit2.DateTime == DateTime.Parse("0001-01-01 0:00:00"))
                {
                    dateEdit2.DateTime = DateTime.Now;
                }
                txtdanhao.Text = BLL.BianhaoBLL.CreatShengchangDanhao(FirstLetter.生产指示单, dateEdit2.DateTime, DanjuLeiXing.生产指示单);
            }
        }
        
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片|*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Image fromImage = Image.FromFile(openFileDialog1.FileName);
                ////fromImage = fromImage.AdjImageToFitSize(pictureBox1.Width, pictureBox1.Height); //350
                //this.pictureBox1.Image = fromImage;
                //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                imgs.Add((Bitmap)Image.FromFile(openFileDialog1.FileName));
                imageindex = imgs.Count - 1;
                PictureBoxEx.loadImg(pictureBox1, openFileDialog1.FileName);
            }
            
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            PictureBox pbox = pictureBox1;
            int x = pbox.Location.X;
            int y = pbox.Location.Y;
            int ow = pbox.Width;
            int oh = pbox.Height;
            int VX, VY;  //因缩放产生的位移矢量

            //第①步
            pbox.Width += 30;
                pbox.Height += 30;
                //第②步
                PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                 BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
                //第③步
                pbox.Width = rect.Width;
                pbox.Height = rect.Height;

            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            VX = (int)((double)x * (ow - pbox.Width) / ow);
            VY = (int)((double)y * (oh - pbox.Height) / oh);
            pbox.Location = new Point(pbox.Location.X + VX, pbox.Location.Y + VY);
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            PictureBox pbox = pictureBox1;
            int x = pbox.Location.X;
            int y = pbox.Location.Y;
            int ow = pbox.Width;
            int oh = pbox.Height;
            int VX, VY;  //因缩放产生的位移矢量

            //第①步
            pbox.Width -=20;
            pbox.Height -= 20;
            ////第②步
            PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
             BindingFlags.NonPublic);
            Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
            //第③步
            pbox.Width = rect.Width;
            pbox.Height = rect.Height;

            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            VX = (int)((double)x * (ow - pbox.Width) / ow);
            VY = (int)((double)y * (oh - pbox.Height) / oh);
            pbox.Location = new Point(pbox.Location.X + VX, pbox.Location.Y + VY);
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            b.RotateFlip(RotateFlipType.Rotate90FlipXY);//旋转90度
            //b.RotateFlip(RotateFlipType.Rotate90FlipNone);//不进行翻转的旋转
            pictureBox1.Image = b;
        }

        private void uiSymbolButton6_Click(object sender, EventArgs e)
        {
            if(imageindex >0 )
            {
                imageindex--;
                pictureBox1.Image = imgs[imageindex];
            }
        }

        private void uiSymbolButton7_Click(object sender, EventArgs e)
        {
            if (imageindex < imgs.Count -1)
            {
                imageindex++;
                pictureBox1.Image = imgs[imageindex];
            }
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            if (imgs.Count > 0)
            {
                imgs.RemoveAt(imageindex);
                imageindex--;
                if (imageindex < 0)
                {
                    imageindex = 0;
                }
                if(imgs.Count >0)
                {
                    pictureBox1.Image = imgs[imageindex];
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }
        public static byte[] BitmapByte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }
    }
}
