using DAL;
using DevExpress.Utils.Taskbar;
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

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 打包发货 : Form
    {
        public string Danhao { get; set; }
        private  DanjuTable  danju = new DanjuTable();
        private  List <JuanHaoTable >  juanhaolist = new List<JuanHaoTable>();
        private List<JuanHaoTable> Kefajuanlist = new List<JuanHaoTable>();
        private List<JuanHaoTable> Yidabaolist = new List<JuanHaoTable>();
        public 打包发货()
        {
            InitializeComponent();
            CreateGrid.Create(this.Name, gridView2);
            CreateGrid.Create(this.Name , gridView1);
        }
        private void 打包发货_Load(object sender, EventArgs e)
        {
            juanhaolist = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == Danhao);
            danju = DanjuTableService.GetOneDanjuTable(x => x.dh == Danhao);
            txtdanhao.Text = danju.dh;
            txtbeizhu.Text = danju.bz;
            txtchepai.Text = danju.CarNum;
            txtckmc.Text = danju.ckmc;
            cmbcunfang.Text = danju.StockName;
            txtkehu.Text = danju.ksmc;
            txtlianxidianhua.Text = danju.lianxidianhua;
            txtlianxiren.Text = danju.lianxiren;
            txtQicheleixing.Text = danju.CarLeixing;
            txtwuliu.Text = danju.wuliugongsi;
            txtyunfei.Text = danju.yunfei.ToString();
            cmbqiankuan.Text = danju.Qiankuan;
            comhanshui.Text = danju.Hanshui;
            dateEdit1.Text = danju.rq.ToShortDateString();
            Kefajuanlist = juanhaolist.Where(x => x.state == 0).ToList();
            Yidabaolist = juanhaolist.Where (x=>x.state!=0).ToList ();
            gridControl1.DataSource = Yidabaolist;
            gridControl2.DataSource = Kefajuanlist ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var j in gridView2.GetSelectedRows())
            {
                var juan = Kefajuanlist.Where(x => x.JuanHao == gridView2.GetRowCellValue(j, "JuanHao").ToString()).ToList()[0];
                juan.state = (int)txtbaohao.Value;
                Yidabaolist.Add(juan);
            }
            gridView2.DeleteSelectedRows();
            foreach (var j in gridView2.GetSelectedRows())
            {
                Kefajuanlist.RemoveAt(j);
            }
            gridControl1.DataSource = Yidabaolist;
            gridControl2.DataSource = Kefajuanlist;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var j in gridView1.GetSelectedRows())
            {
                var juan = Yidabaolist .Where(x => x.JuanHao == gridView1.GetRowCellValue(j, "JuanHao").ToString()).ToList()[0];
                juan.state = 1;
                Kefajuanlist .Add(juan);
            }
            gridView1.DeleteSelectedRows();
            gridControl1.DataSource = Yidabaolist;
            gridControl2.DataSource = Kefajuanlist;
            gridControl1.RefreshDataSource();
            gridControl2.RefreshDataSource();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new JuanHaoTable() };
            fm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = new JuanHaoTable () };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
        private void PrintMadan(int useful)
        {
            new Tools.打印包装码单() { danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } };
        }

        private void 码单编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Yidabaolist.Count > 0)
                {
                    new Tools.打印包装码单() { danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } }.打印(PrintModel.Design, PrintPath.报表模板 + "\\打包码单.frx");
                }
                else
                {
                    MessageBox.Show("没有任何包装信息！打印失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 码单预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Yidabaolist.Count > 0)
                {
                    new Tools.打印包装码单() { danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } }.打印(PrintModel.Privew, PrintPath.报表模板 + "\\打包码单.frx");
                }
                else
                {
                    MessageBox.Show("没有任何包装信息！打印失败",this.Name ,MessageBoxButtons.OK ,MessageBoxIcon.Error );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 直接打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Yidabaolist.Count > 0)
                {
                    new Tools.打印包装码单() { danju = danju, juanhaolist = Yidabaolist, formInfo = new Tools.FormInfo() { FormName = "销售发货单查询", GridviewName = "gridView1" } }.打印(PrintModel.Print, PrintPath.报表模板 + "\\打包码单.frx");
                }
                else
                {
                    MessageBox.Show("没有任何包装信息！打印失败", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 保存ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            gridView2.CloseEditor();
            //JuanHaoTableService.UpdateJuanHaoTable($"state='0'", x => x.Danhao == juanhaolist[0].Danhao);
            Connect.DbHelper().Updateable<JuanHaoTable>(Yidabaolist).ExecuteCommand();
                //JuanHaoTableService.UpdateJuanHaoTable($"state='{j.state}'", x => x.ID == j.ID);
            this.Close();
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var juan = juanhaolist.Where(x => x.JuanHao == textBoxX2.Text).ToList();
                if (juan.Count > 0)
                {
                    juan[0].state = (int)txtbaohao.Value;
                    Yidabaolist.Add(juan[0]);
                    Kefajuanlist.Remove(juan[0]);
                    gridControl1.RefreshDataSource();
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                SettingService.Update(new Setting() { formname = this.Name, settingname = "码单样式", settingValue = cmbMadanYangshi.Text });
                MessageBox.Show("设置默认标签成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置默认标签失败！原因是" + ex.Message);
            }
        }
    }
}
