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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 白坯日产量单 : Form
    {
        public int useful { get; set; }
        private YuanGongTable yuangong = new YuanGongTable();
        public DanjuTable danju { get; set; } = new DanjuTable();
        public 白坯日产量单()
        {
            InitializeComponent();
            cmbCangkumingcheng.DataSource = StockInfoTableService.GetStockInfoTablelst(x => x.Leixing.Contains("")).Select(x => x.mingcheng).ToList();
        }

        private void 白坯日产量单_Load(object sender, EventArgs e)
        {
            if (useful ==FormUseful.新增 )
            { 
                dateEdit1.DateTime = DateTime.Now.AddDays(-1);
                txtdanhao.Text = BianhaoBLL.CreatDanhao("RCLD", dateEdit1.DateTime,"");                
            }
            else
            {
                Edit();
            }
        }
        private void Edit()
        {
            var changliang = ChangliangTableService.GetOneChangliangTable(x => x.Danhao == danju.dh);
            txtbuliao.Text = changliang.PingzhongBianhao;
            txtdanhao.Text = changliang.Danhao;
            txtguige.Text = changliang.GuiGe;
            txtpihao.Text = changliang.Pihao;
            txtpingming.Text = changliang.PingMing;
            txtYuangong.Text = changliang.Yuangong;
            txtZhouhao.Text = changliang.Zhouhao;
            cmbkuwei .Text = changliang.Kuwei;
            cmbBanci.Text = changliang.BanChi;
            cmbCangkumingcheng.Text = changliang.Ckmc;
            txtbeizhu.Text = "";
            dateEdit1.DateTime = changliang.Riqi.Date;
            dataGridViewX1.DataSource = ChangliangTableService.GetChangliangTablelst(x => x.Danhao == danju.dh);
        }
        private void txtYuangong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 员工选择();
            fm.ShowDialog();
             yuangong = fm.linkman;
            txtYuangong.Text = yuangong.Xingming;
        }

        private void txtbuliao_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var buliao = fm.pingzhong;
            txtbuliao.Text = buliao[0].bh;
            txtpingming.Text = buliao[0].pm;
            txtguige.Text = buliao[0].gg;
        }

        private  void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changlianglist = new List<ChangliangTable>();
           for(int row=0;row<dataGridViewX1.Rows.Count;row++)
            {
                if(Convert.ToDecimal ( dataGridViewX1.Rows[row].Cells [Cshuliang.Name ].Value )!=0)
                {
                    changlianglist.Add(new ChangliangTable()
                    {
                        Yuangong = yuangong.Xingming,
                        BanChi = cmbBanci.Text,
                        Danhao = txtdanhao.Text,
                        GuiGe = txtguige.Text,
                        Pihao = txtpihao.Text,
                        PingMing = txtpingming.Text,
                        PingzhongBianhao = txtbuliao.Text,
                        Zhouhao = txtZhouhao.Text,
                        GuiSuo = "",
                        Riqi = dateEdit1.DateTime,
                        Shuliang = Convert.ToDecimal(dataGridViewX1.Rows[row].Cells[Cshuliang.Name].Value),
                        Ckmc = cmbCangkumingcheng.Text,
                        Kuwei=cmbkuwei.Text 
                    }) ;
                }

            }
            if (useful == FormUseful.新增)
            {
                白坯日产量BLL.保存(changlianglist);
            }
            else
            {
                白坯日产量BLL.修改(changlianglist);
            }
            useful = FormUseful.新增;
            txtdanhao.Text = BianhaoBLL.CreatDanhao("RCLD", dateEdit1.DateTime,"");
            dataGridViewX1.Rows.Clear();
        }
    }
}
