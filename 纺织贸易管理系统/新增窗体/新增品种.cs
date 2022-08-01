using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 新增品种 :Sunny.UI.UIForm
    {
        public db Pingzhong = new db();
        public int Useful { get; set; }
        public int oldbianhao;

        public 新增品种()
        {
            InitializeComponent();
            cmbzhidongbianhao.Text = SettingService.GetSetting (new Setting() { formname = this.Name, settingname = "自动编号", settingValue = "是" }).settingValue ;
            var l = LetterTableService.GetOneLetterTable(x => x.own == User.user.YHBH ).FirstLetter;
            txtFirsetLetter.Text = l == string.Empty ? "YB" : l;
            cmbMoban.Items.AddRange (Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray ());
            if (cmbMoban.Items.Count > 0)
            {
                cmbMoban.Text = QueryTime.DefaultLabel;
            }
            dateEdit1.EditValue = DateTime.Now.ToShortDateString ();
            cmbLeibie.DataSource = (from lb in dbService.Getdblst() select lb.lb).ToList().Distinct<string>().ToList ();
            Useful = 1;
            pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            if (!AccessBLL.CheckAccess("坯布信息可见",false ))
            { tabPage4.Parent =null ; }
            if (!AccessBLL.CheckAccess("工艺信息可见",false ))
            { tabPage2.Parent =null; }
        }
        int zoomStep = 50;
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            PictureBox pbox = sender as PictureBox;
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pbox.Width;
            int oh = pbox.Height;
            int VX, VY;  //因缩放产生的位移矢量
            if (e.Delta > 0) //放大
            {
                //第①步
                pbox.Width += zoomStep;
                pbox.Height += zoomStep;
                //第②步
                PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                 BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
                //第③步
                pbox.Width = rect.Width;
                pbox.Height = rect.Height;
            }
            if (e.Delta < 0) //缩小
            {
                //防止一直缩成负值
                if (pbox.Width < 300)
                    return;

                pbox.Width -= zoomStep;
                pbox.Height -= zoomStep;
                PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                 BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
                pbox.Width = rect.Width;
                pbox.Height = rect.Height;
            }
            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            VX = (int)((double)x * (ow - pbox.Width) / ow);
            VY = (int)((double)y * (oh - pbox.Height) / oh);
            pbox.Location = new Point(pbox.Location.X + VX, pbox.Location.Y + VY);
        }

        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            if(cmbzhidongbianhao.Text =="是")
            {
                txtBianhao.ReadOnly = true;
            }
            else
            {           
                txtBianhao.ReadOnly = false;
            }
        }
        private void InitText()
        {
            if (Useful == FormUseful.新增)
            {
                if (cmbzhidongbianhao.Text == "是")
                {
                    Pingzhong.bh = BianhaoBLL.CreatPingZhongBianhao(txtFirsetLetter.Text, txtpingming.Text, txthouzhengli.Text);
                }
                else
                {
                    Pingzhong.bh = "";
                }
                Pingzhong.lx = QueryTime.IsFabricStyle ;
                Pingzhong.lb = "无";
                Pingzhong.caiyang = false;
            }
            if(Useful==FormUseful.复制 )
            {
                if (cmbzhidongbianhao.Text == "是")
                {
                    Pingzhong.bh = BianhaoBLL.CreatPingZhongBianhao(txtFirsetLetter.Text, txtpingming.Text, txthouzhengli.Text);             
                }
                else
                {
                    Pingzhong.bh = "";
                }
                Pingzhong.rq = DateTime.Now;
            }
            oldbianhao = Pingzhong.ID;
            txtBianhao.Text = Pingzhong.bh;
            txtbeizhu.Text = Pingzhong.bz;
            txtchengbenjia.Text = Pingzhong.cbj;
            txtchengfeng.Text = Pingzhong.cf;
            txtchengpingjiage.Text = Pingzhong.jg;
            txtcunyangbianhao.Text = Pingzhong.GonghuoShangBianHao;
            txtgonghuoshang.Text = Pingzhong.GHSMC;
            txtgonghuoshangbianhao.Text = Pingzhong.GHSBH;
            txtguangzhe.Text = Pingzhong.gz;
            txtguige.Text = Pingzhong.gg;
            txthouzhengli.Text = Pingzhong.hzl;
            txthouzhenglijiage.Text = Pingzhong.hzljg;
            txthuohao.Text = Pingzhong.HH;
            txtkezhong.Text = Pingzhong.kz;
            txtlianxidianhua.Text = Pingzhong.lxdh;
            txtlianxiren.Text = Pingzhong.lxr;
            txtmenfu.Text = Pingzhong.mf;
            txtmidu.Text = Pingzhong.md;
            txtpibujiage.Text = Pingzhong.PBPrice;
            txtpingming.Text = Pingzhong.pm;
            txtsuolv.Text = Pingzhong.sl;
            txtweizhi.Text = Pingzhong.wz;
            txtyanse.Text = Pingzhong.ys;
            txtyingwenming.Text = Pingzhong.EnglishName;
            txtzhibiao.Text = Pingzhong.zb;
            txtzhuzijiegou.Text = Pingzhong.zzjg;
            txtfengge.Text = Pingzhong.Fengge;
            txtyongtu.Text = Pingzhong.YongTu;
            txtbeizhu.Text = Pingzhong.bz;
            txtTeDian.Text = Pingzhong.Characteristic;
            txtDescript.Text = Pingzhong.Descript;
            txtpibuname.Text = Pingzhong.PibuName;
            txtshangjimenfu.Text = Pingzhong.ShangjiWidth;
            txtxiajimenfu.Text = Pingzhong.XiajiWidth;
            txtjinsha .Text = Pingzhong.Jinsha ;
            txtjinshschangjia.Text = Pingzhong.JinshaSupplier ;
            txtjinshapihao.Text = Pingzhong.JinshaPihao ;
            txtweisha.Text = Pingzhong.Weisha ;
            txtweishachangjia.Text = Pingzhong.WeishaSupplier;
            txtweishapihao.Text = Pingzhong.WeishaPihao;
            try
            {
                if (Pingzhong.rq != null)
                {
                    dateEdit1.DateTime = Convert.ToDateTime(Pingzhong.rq);
                }else
                {
                    dateEdit1.DateTime = DateTime.Now;
                }    
            }
            catch
            {
                dateEdit1.DateTime = DateTime.Now;
            }
            txtzhuyishixiang.Text = Pingzhong.Zhuyishixiang;
            if (Pingzhong.caiyang != true)
            {
                cmbcaiyang.SelectedIndex = 0;
            }
            else
            {
                cmbcaiyang.SelectedIndex = 1;
            }
            cmbLeibie.Text = Pingzhong.lb;
            cmbleixing.Text = Pingzhong.lx;
            try
            {
                pictureBox1.Image = Tools.ImgHelp.BytesToImage(MadanPictureService.GetOneMadanPicture(x => x.ckdh == Pingzhong.bh).picture);
                pictureBox2.Image = pictureBox1.Image;
            }
            catch
            {
                pictureBox1.Image = null;
            }
            if (!string.IsNullOrWhiteSpace(Pingzhong.bh))
            {
                var gongyilist = ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == Pingzhong.bh);
                for (int i = gongyilist.Count; i < 30; i++)
                {
                    gongyilist.Add(new ShengChengGongYi() { SPBH = txtBianhao.Text });
                }
                gridControl1.DataSource = gongyilist;
            }
            else
            {
                var gongyilist = new List<ShengChengGongYi>();
                for (int i = gongyilist.Count; i < 30; i++)
                {
                    gongyilist.Add(new ShengChengGongYi() { SPBH = txtBianhao.Text });
                }
                gridControl1.DataSource = gongyilist;
            }
            txtBianhao.ReadOnly = false;
            uiDataGridView1.DataSource = PriceTableService.GetPriceTablelst(x => x.bianhao == Pingzhong.bh);
        }

        private void 新增品种_Load(object sender, EventArgs e)
        {
            InitText();
        }
        private Boolean  InitPingzhong()
        {
            if(Useful==FormUseful.新增||Useful==FormUseful.复制)
            {
                if (!dbService.CheckBianhao(txtBianhao.Text.Trim()))
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "改编号已经存在！请重新输入编号");
                    return false ;
                }
            }
            else
            {
                if (dbService.GetOnedb(x => x.bh == txtBianhao.Text.Trim(' ')).ID != 0)
                {
                    if (dbService.GetOnedb(x => x.bh == txtBianhao.Text.Trim(' ')).ID != Pingzhong.ID)
                    {
                        Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "改编号已经存在！请重新输入编号");
                        return false;
                    }
                }
            }
            Pingzhong.bh = txtBianhao.Text.Trim ();
            Pingzhong.bz = txtbeizhu.Text;
            if(cmbcaiyang.Text =="不能采样")
            {
                Pingzhong.caiyang = false;
            }
            else
            {
                Pingzhong.caiyang = true;
            }
            Pingzhong.cbj = txtchengbenjia.Text;
            Pingzhong.cf = txtchengfeng.Text;
            Pingzhong.EnglishName = txtyingwenming.Text;
            Pingzhong.gg = txtguige.Text;
            Pingzhong.GHSBH = txtgonghuoshangbianhao.Text;
            Pingzhong.GHSMC = txtgonghuoshang.Text;
            Pingzhong.GonghuoShangBianHao = txtcunyangbianhao.Text;
            Pingzhong.gz = txtguangzhe.Text;
            Pingzhong.HH = txthuohao.Text;
            Pingzhong.hzl = txthouzhengli.Text;
            Pingzhong.hzljg = txthouzhenglijiage.Text;
            Pingzhong.jg = txtchengpingjiage.Text;
            Pingzhong.kz = txtkezhong.Text;
            Pingzhong.lb = cmbLeibie.Text;
            Pingzhong.lx = cmbleixing.Text;
            Pingzhong.lxdh = txtlianxidianhua.Text;
            Pingzhong.lxr = txtlianxiren.Text;
            Pingzhong.md = txtmidu.Text;
            Pingzhong.mf = txtmenfu.Text;
            Pingzhong.own = User.user.YHBH;
            Pingzhong.PBPrice = txtpibujiage .Text;
            Pingzhong.pm = txtpingming.Text;
            Pingzhong.rq = dateEdit1.DateTime  ;
            Pingzhong.sl = txtsuolv.Text;
            Pingzhong.wz = txtweizhi.Text;
            Pingzhong.ys = txtyanse.Text;
            Pingzhong.zb = txtzhibiao.Text;
            Pingzhong.zzjg = txtzhuzijiegou.Text;
            Pingzhong.Fengge = txtfengge.Text;
            Pingzhong.YongTu = txtyongtu.Text;
            Pingzhong.Zhuyishixiang = txtzhuyishixiang.Text;
            Pingzhong.bz = txtbeizhu.Text;
            Pingzhong.Characteristic = txtTeDian.Text;
            Pingzhong.Descript = txtDescript.Text;
            Pingzhong.PibuName = txtpibuname.Text;
            Pingzhong.ShangjiWidth = txtshangjimenfu.Text;
            Pingzhong.XiajiWidth = txtxiajimenfu.Text;
            Pingzhong.Jinsha = txtjinsha.Text;
            Pingzhong.JinshaSupplier = txtjinshschangjia.Text ;
            Pingzhong.JinshaPihao = txtjinshapihao.Text;
            Pingzhong.Weisha = txtweisha.Text;
            Pingzhong.WeishaPihao = txtweishapihao.Text;
            Pingzhong.WeishaSupplier = txtweishachangjia.Text;
            uiDataGridView1.DataSource = PriceTableService.GetPriceTablelst(x => x.bianhao == txtBianhao.Text);
            return true;
        }
        private List<ShengChengGongYi > CreateGongyi()
        {
            var gongyilist = new List<ShengChengGongYi>();
            for (int row = 0; row < gridView1.RowCount; row++)
            {
                if ( gridView1.GetRowCellValue(row,"JGDW")!=null )
                {
                    gongyilist.Add(new ShengChengGongYi() { JG = gridView1.GetRowCellValue(row, "JG").TryToDecmial(0),  JGDW = gridView1.GetRowCellValue(row, "JGDW").ToString(),
                    JGBH = gridView1.GetRowCellValue(row, "JGBH").ToString(),
                    JGGY = gridView1.GetRowCellValue(row, "JGGY").ToString()
                    });
                }
            }
            return gongyilist;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBianhao.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "编号不能为空,请输入布料编号！n\\保存失败");
                return;
            }
         var old = Pingzhong.bh;//获取之前没修改的时候的编号
           
            if (InitPingzhong() == false)
            { return; }
            if (Useful == FormUseful.新增)
            {
                dbService.Insertdb(Pingzhong);
                var madan = new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image),rq=DateTime.Now  };
                MadanPictureService.InsertMadanPicture(madan );
                ShengChengGongYiService.DeleteShengChengGongYi(x => x.SPBH == Pingzhong.bh);
                ShengChengGongYiService.InsertShengChengGongYilst(CreateGongyi());
            }
            else
            {
                if (Useful == FormUseful.复制)
                {                   
                    dbService.Insertdb(Pingzhong);
                    MadanPictureService.InsertMadanPicture(new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image), rq = DateTime.Now });
                    ShengChengGongYiService.DeleteShengChengGongYi(x => x.SPBH == Pingzhong.bh);
                    ShengChengGongYiService.InsertShengChengGongYilst(CreateGongyi());
                }
                else
                {                   
                    dbService.Updatedb(Pingzhong, x => x.ID  ==oldbianhao);
                        Connect.CreatConnect ().DoSQL ("Update PriceTable set bianhao='" + txtBianhao.Text + "' where bianhao='" + old+"'");
                    if (MadanPictureService.GetMadanPicturelst(x => x.ckdh == Pingzhong.bh).Count > 0)
                    {
                        MadanPictureService.DeleteMadanPicture ( x => x.ckdh == Pingzhong.bh);
                        //var madan = new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image) };
                        //var fm = new 图片显示();
                        //fm.Image = Tools.ImgHelp.BytesToImage(madan.picture);
                        //fm.ShowDialog();
                        MadanPictureService.InsertMadanPicture(new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image), rq = DateTime.Now });
                    }
                    else
                    {
                        //var madan = new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image) };
                        //var fm = new 图片显示();
                        //fm.Image = Tools.ImgHelp.BytesToImage(madan.picture);
                        //fm.ShowDialog();
                        MadanPictureService.InsertMadanPicture(new MadanPicture { ckdh = Pingzhong.bh, picture = Tools.ImgHelp.ImageToBytes(pictureBox1.Image), rq = DateTime.Now });
                    }
                    ShengChengGongYiService.DeleteShengChengGongYi(x => x.SPBH == Pingzhong.bh);
                    ShengChengGongYiService.InsertShengChengGongYilst(CreateGongyi());
                }
            }
            Pingzhong = new db();
            Useful = FormUseful.新增;
            oldbianhao = 0;
            InitText();
        }
       
        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DAL.GetAccess.IsCanPrintDesign)
            {
                InitPingzhong();
                Tools.打印标签.打印(0, Pingzhong, new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, PrintNum = 1, Printmodel = PrintModel.Design }, CreateGongyi(), new JiYangBaoJia());
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitPingzhong();
            Tools.打印标签.打印(0, Pingzhong, new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, PrintNum = 1,Printmodel=PrintModel.Privew  }, CreateGongyi(), new JiYangBaoJia());
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitPingzhong();
            var fm = new 打印设置窗体 ();
            fm.ShowDialog();
            if (!fm.printerSettings.IsCancelPrint)
            {
                var printset = fm.printerSettings;
                printset.Path = PrintPath.标签模板 + cmbMoban.Text;
                Tools.打印标签.打印(0, Pingzhong, printset, CreateGongyi(), new JiYangBaoJia());
            }
        }

        private void 新增品种_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                MadanPictureService.DeleteMadanPicture(x => x.khbh == txtBianhao.Text);
            }
            SettingService.Update(new Setting() { formname = this.Name, settingname = "自动编号", settingValue = cmbzhidongbianhao.Text });
            var f = LetterTableService.GetOneLetterTable(x => x.own == User.user.YHBH);
            if (f.FirstLetter == string.Empty)
            {
                LetterTableService.InsertLetterTable(new LetterTable() { FirstLetter = txtFirsetLetter.Text, own = User.user.YHBH });
            }
            else
            {
                LetterTableService.UpdateLetterTable(new LetterTable() { FirstLetter = txtFirsetLetter.Text, own = User.user.YHBH }, x => x.own == User.user.YHBH );
            }
        }

        private void txtgonghuoshangbianhao_ButtonCustomClick(object sender, EventArgs e)
        {
            var fm = new 供货商选择() {linkman = new LXR() { ZJC ="",MC=""} };
            fm.ShowDialog();
            txtgonghuoshangbianhao.Text = fm.linkman.BH;
            txtgonghuoshang.Text = fm.linkman.MC;
        }

        private void txtFirsetLetter_TextChanged(object sender, EventArgs e)
        {
            if (Useful != FormUseful.修改 )
            {
                try
                {
                    if (cmbzhidongbianhao.Text == "是")
                    {
                        txtBianhao.Text = BianhaoBLL.CreatPingZhongBianhao(txtFirsetLetter.Text, txtpingming.Text, txthouzhengli.Text);
                    }
                }
                catch
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "自动生成编号发生错误！请重新输入信息或者手动输入");
                }
            }
          
        }

        private void txtpingming_TextChanged(object sender, EventArgs e)
        {
            if (Useful != FormUseful.修改 )
            {
                try
                {
                    if (cmbzhidongbianhao.Text == "是")
                    {
                        txtBianhao.Text = BianhaoBLL.CreatPingZhongBianhao(txtFirsetLetter.Text, txtpingming.Text, txthouzhengli.Text);
                    }
                }
                catch
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this,"自动生成编号发生错误！请重新输入信息或者手动输入");
                }
            }
        }

        private void 上传图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片|*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image  fromImage = Image.FromFile(openFileDialog1.FileName);
                //fromImage = fromImage.AdjImageToFitSize(pictureBox1.Width, pictureBox1.Height); //350
               PictureBoxEx.loadImg(pictureBox1, openFileDialog1.FileName);
            }
        }

        private void 全部显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void 图片居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage ;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom ;
        }

        private void 适应大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize ;
        }

        private void 单独窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 图片显示() { Image = pictureBox1.Image };
            fm.Show();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(pictureBox1.Image==null)
            {
                复制ToolStripMenuItem.Enabled = false;
            }
            else
            {
                复制ToolStripMenuItem.Enabled  = true;
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                pictureBox1.Image = (Bitmap)iData.GetData(DataFormats.Bitmap );
            }
        }

        private void 清空图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void 旋转图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1 .Image);
            b.RotateFlip(RotateFlipType.Rotate90FlipXY);//旋转90度
            //b.RotateFlip(RotateFlipType.Rotate90FlipNone);//不进行翻转的旋转
            pictureBox1 .Image = b;
        }

        private void 上传织造工艺单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBianhao.Text))
                {
                    MessageBox.Show("编号不能为空！请填填写编号！");
                    return;
                }
                if (Sunny.UI.UIMessageBox.ShowAsk("上传后编号将不能修改！是否确定要上传？"))
                {
                    txtBianhao.ReadOnly = true;
                    var filedlg = new OpenFileDialog();
                    filedlg.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx";
                    filedlg.ShowDialog();
                    if (!string.IsNullOrWhiteSpace(filedlg.FileName))
                    {
                        MadanPictureService.DeleteMadanPicture(x => x.khbh == txtBianhao.Text);
                        var arr = filedlg.FileName.Split('\\');
                        Connect.DbHelper().Insertable<MadanPicture>(new MadanPicture() { ckdh = arr[arr.Length - 1], khbh = txtBianhao.Text, picture = MadanPictureService.ExcelToByte(filedlg.FileName), rq = DateTime.Now }).ExecuteCommand();
                    }
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 下载织造工艺单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = MadanPictureService .GetOneMadanPicture(x => x.khbh  == txtBianhao.Text  );
            if (!string.IsNullOrEmpty(report.ckdh))
            {
                if(!System.IO.Directory.Exists(Application.StartupPath +"\\Temp"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Temp");
                }
                var filepath = Application.StartupPath + "\\Temp\\" + report.ckdh ;
                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(report.picture , 0, report.picture .Length);
                    fs.Close();
                    Process.Start(Application.StartupPath + "\\Temp\\" + report.ckdh);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiDataGridView1.CurrentRow!=null)
                {
                    if (MessageBox.Show("您确定要删除该价格信息吗？", "提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        PriceTableService.DeletePriceTable(x => x.Id == uiDataGridView1.CurrentRow.Cells[CID.Name].Value.TryToInt (0));
                        uiDataGridView1.DataSource =Useful==FormUseful.新增 ? PriceTableService.GetPriceTablelst(x => x.bianhao == txtBianhao.Text): PriceTableService.GetPriceTablelst(x => x.bianhao ==Pingzhong.bh );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除价格的时候发生错误！" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty (txtBianhao.Text ))
            {
                MessageBox.Show("请先填写编号！");
                return;
            }
            else
            {
                if (txtBianhao.ReadOnly == false)
                {
                    if (MessageBox.Show("登记价格后编号将不能修改！是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Useful == FormUseful.新增)
                        {
                            if (Connect.DbHelper().Queryable<db>().First(x => x.bh == txtBianhao.Text) != null)
                            {
                                MessageBox.Show("该编号已经存在！不能启用该编号！");
                                return;
                            }
                            else
                            {
                                txtBianhao.ReadOnly = true;
                            }
                        }
                        else
                        {
                            if (Connect.DbHelper().Queryable<db>().First(x => x.ID==Pingzhong.ID ) != null)
                            {
                                if (Connect.DbHelper().Queryable<db>().First(x => x.bh == txtBianhao.Text).ID != Pingzhong.ID)
                                {
                                    MessageBox.Show("该编号已经存在！不能启用该编号！");
                                    return;
                                }
                                else
                                {
                                    txtBianhao.ReadOnly = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("该编号的布料信息已被删除！不能新增价格信息！");
                                return;
                            }
                        }
                    }
                }
            }
            new 新增价格() { Useful=FormUseful.新增,Bianhao =Useful==FormUseful.新增 ?  txtBianhao.Text .ToString ():Pingzhong.bh  }.ShowDialog();
            uiDataGridView1.DataSource = Useful == FormUseful.新增 ?PriceTableService.GetPriceTablelst (x=>x.bianhao ==txtBianhao.Text  ): PriceTableService.GetPriceTablelst(x => x.bianhao == Pingzhong.bh);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiDataGridView1.CurrentRow != null)
                {
                    var price= PriceTableService.GetOnePriceTable (x => x.Id == uiDataGridView1.CurrentRow.Cells[CID.Name].Value.TryToInt(0));
                    new 新增价格() { Useful = FormUseful.修改, Bianhao = price.bianhao, ID = price.Id }.ShowDialog();
                    uiDataGridView1.DataSource = Useful == FormUseful.新增 ? PriceTableService.GetPriceTablelst(x => x.bianhao == txtBianhao.Text) : PriceTableService.GetPriceTablelst(x => x.bianhao == Pingzhong.bh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改价格的时候发生错误！" + ex.Message);
            }
        }
    }
    internal static class ImgHelp
    {
        /// <summary>
        /// 获取等比例缩放的图片（高宽不一致时获取最中间部分的图片）
        /// </summary>
        public static Image AdjImageToFitSize(this Image fromImage, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(bitmap);
            Point[] destPoints = new Point[] {
                new Point(0, 0),
                new Point(width, 0),
                new Point(0, height)
            };

            Rectangle rect = GetImageRectangle(fromImage.Width, fromImage.Height);
            graphics.DrawImage(fromImage, destPoints, rect, GraphicsUnit.Pixel);

            Image image = Image.FromHbitmap(bitmap.GetHbitmap());
            bitmap.Dispose();
            graphics.Dispose();
            return image;
        }
        /// <summary>
        /// 居中位置获取
        /// </summary>
        private static Rectangle GetImageRectangle(int w, int h)
        {
            int x = 0;
            int y = 0;

            if (h > w)
            {
                h = w;
                y = (h - w) / 2;
            }
            else
            {
                w = h;
                x = (w - h) / 2;
            }
            return new Rectangle(x, y, w, h);
        }
    }
}
