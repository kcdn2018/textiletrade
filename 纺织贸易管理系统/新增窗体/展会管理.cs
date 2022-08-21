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
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 展会管理 : Form
    {
        private List<ZhanhuiDetail> zhanhuiDetails = new List<ZhanhuiDetail>();
        /// <summary>
        /// 单据状态  修改还是新增
        /// </summary>
        public int Userful { get; set; }
        public string Danhao { get; set; }
        public 展会管理()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            try
            {
                gridView1.Columns["YangbuBianhao"].ColumnEdit = ButtonEdit1;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new ZhanhuiDetail () };
            fm.ShowDialog();
        }
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var i = gridView1.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
               
                    if (zhanhuiDetails.Where(x =>x!=null && x.YangbuBianhao == pingzhong.bh).ToList().Count > 0)
                    {
                        Sunny.UI.UIMessageBox.ShowWarning($"该编号{pingzhong.bh }已经存在!\r\n系统将默认不再添加");
                    }
                    else
                    {
                        zhanhuiDetails[i] = new ZhanhuiDetail()
                        {
                            YangbuBianhao = pingzhong.bh,
                            GG = pingzhong.gg,
                            CF = pingzhong.cf,
                            PM = pingzhong.pm,
                            KZ = pingzhong.kz,
                            Beizhu = string.Empty,
                            EnglishName = pingzhong.EnglishName,
                            Leixing = "挂卡",
                            MF = pingzhong.mf,
                            ShuLiang = 1,
                            Yanse = string.Empty,
                            Danhao = txtdanhao.Text,
                            bz = string.Empty
                        };
                    Mapper.MapperTo(pingzhong, zhanhuiDetails[i]);
                        i++;
                        if (i == zhanhuiDetails.Count - 1)
                            for (int j = 0; j < 30; j++)
                            {
                                zhanhuiDetails.Add(new ZhanhuiDetail() { Danhao = txtdanhao.Text });
                            }
                    }
                }
            fm.Dispose();
            gridControl1.RefreshDataSource();
            gridView1.CloseEditor();
        }

        private void 展会管理_Load(object sender, EventArgs e)
        {
            var conMenu = new ContexMenuEX() { formName = this.Name, gridControl = gridControl1, gridView = gridView1, menuStrip = contextMenuStrip1, obj = new ZhanhuiDetail() };
            conMenu.Init();
            if (Userful ==FormUseful.新增 )
            {
                新增();
            }
            else
            {
                修改();
            }
        }
        private void 新增()
        {
            txtdanhao.Text = BLL.BianhaoBLL.CreatDanhao( FirstLetter.展会, uiDatePicker1.Value,DanjuLeiXing.展会);
            zhanhuiDetails.AddRange(new ZhanhuiDetail[100]);
            gridControl1.DataSource = zhanhuiDetails;
        }
        private void 修改()
        {
            if(!string.IsNullOrWhiteSpace (Danhao ))
            {
                zhanhuiDetails = ZhanhuiDetailService.GetZhanhuiDetaillst(x => x.Danhao == Danhao).GroupBy(x => x.YangbuBianhao).Select(y => y.First()).ToList ();
            }
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == Danhao);
            txtdanhao.Text = danju.dh;
            txtAddress.Text = danju.ckmc;
            txtweizhi.Text = danju.StockName;
            uiDatePicker1.Value = danju.rq;
            txtName.Text = danju.ksmc;
            if (zhanhuiDetails.Count < 100)
            { zhanhuiDetails.AddRange(new ZhanhuiDetail[100 - zhanhuiDetails.Count]); }
            
            gridControl1.DataSource  =zhanhuiDetails;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Userful ==FormUseful.新增 )
            {
                DanjuTableService.InsertDanjuTable(new DanjuTable()
                {
                    dh = txtdanhao.Text,
                    ckmc = txtAddress.Text,
                    StockName = txtweizhi.Text,
                    rq = uiDatePicker1.Value.Date,
                    ksmc = txtName.Text,
                    djlx=DanjuLeiXing.展会 
                });
                UIWaitFormService.ShowWaitForm("正在保存。。。。。。。请等待");
                ZhanhuiDetailService.InsertZhanhuiDetaillst(zhanhuiDetails.Where(x =>x!=null && x.YangbuBianhao!=null&&x.YangbuBianhao!=string.Empty ).ToList());
                UIWaitFormService.HideWaitForm();
            }
            else
            {
                DanjuTableService.UpdateDanjuTable(x => x.ksmc == txtName.Text && x.ckmc == txtAddress.Text && x.StockName == txtweizhi.Text && x.rq == uiDatePicker1.Value.Date, y => y.dh == txtdanhao.Text);
                ZhanhuiDetailService.DeleteZhanhuiDetail(x => x.Danhao == txtdanhao.Text);
                UIWaitFormService.ShowWaitForm("正在保存。。。。。。。请等待");
                var res = zhanhuiDetails.Where(x =>x!=null&& !string.IsNullOrEmpty(x.YangbuBianhao)).Distinct().ToList();
                ZhanhuiDetailService.InsertZhanhuiDetaillst(res);
                UIWaitFormService.HideWaitForm();
            }
        }

        private void 导出列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "参展明细");
        }
    }
}
