using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 后整理管理系统.BLL;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.自定义类;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
    public partial class 流转卡 : Form
    {
        public int Useful { get; set; }
        public Liuzhuancard liuzhuancard { get; set; }
        private List<StockTable> stocks = new List<StockTable>();
        List<liuzhuanmingxi> liuzhuangkamingxi = new List<liuzhuanmingxi>();
        public List<danjumingxitable> danjumingxis { get; set; } = new List<danjumingxitable>();
        private int rowindex;
        public DanjuTable danju { get; set; } = new DanjuTable();

        public 流转卡()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            cmbjitai.Items.AddRange(MachineTableService.GetMachineTablelst("select * from machinetable").Select(x => x.MachineID).ToArray());
            cmblianxiren.Items.AddRange(YuanGongTableService.GetYuanGongTablelst().Select(x => x.Xingming).ToArray());
            CreateGrid.Create(this.Name, gridView2);
            try
            {
                gridView2.Columns["Bianhao"].ColumnEdit = ButtonEdit1;
                gridView2.Columns["pingming"].ColumnEdit = ButtonEdit1;
                gridView2.Columns["danwei"].ColumnEdit = cmddanwei;
                gridView2.Columns["yanse"].ColumnEdit = colorbtn;
                gridView2.Columns["ColorNum"].ColumnEdit = colorbtn;
                gridView2.IndicatorWidth = 30;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null, null);
            }
            gridControl2.DataSource = danjumingxis;
            gridControl1.DataSource = liuzhuangkamingxi;
            var conMenu = new ContexMenuEX() { formName=this.Name , gridControl =gridControl2 , gridView =gridView2 , menuStrip =contextMenuStrip2  };
            conMenu.Init();
        }
        private void 流转卡_Load(object sender, EventArgs e)
        {
            InitForm();
        }
        private void InitForm()
        {
            if (Useful == FormUseful.复制)
            {
                txtdanhao.Text = BianhaoBLL.CreateLiuzhuanKahao(FirstLetter.流转卡, uiDatePicker1.Value);
                txtbeizhu.Text = "";
                txtkehu.Text = danju.ksmc;
                txtkezhong.Text = danjumingxis.Count > 0 ? danjumingxis[0].kezhong : string.Empty;
                txtmenfu.Text = danjumingxis.Count > 0 ? danjumingxis[0].menfu : string.Empty;
                txtpingming.Text = danjumingxis.Count > 0 ? danjumingxis[0].pingming : string.Empty;
                txtckmc.Text = danju.ckmc;
                txtbeizhu.Text = danju.bz;
                txtshuliang.Text = danjumingxis.Sum(x => x.chengpingmishu).ToString();
                txtyanse.Text = danjumingxis.Count > 0 ? danjumingxis[0].yanse : string.Empty; ;
                var gongyis = TechnologyTableService.GetTechnologyTablelst("select * from Technologytable");
                foreach (var g in gongyis)
                {
                    liuzhuangkamingxi.Add(new liuzhuanmingxi() { CardNum = txtdanhao.Text, GongyiYaoqiu = g.Technology, Cishu = 1 });
                }
                //danjumingxis.AddRange(new danjumingxitable[30] );            
                var count = danjumingxis.Count;
                foreach (var d in danjumingxis )
                {
                    d.danhao = txtdanhao.Text;
                }
                for (int i = 0; i < 30 - count; i++)
                {
                    danjumingxis.Add(new danjumingxitable { danhao = txtdanhao.Text });
                }
                gridControl1.RefreshDataSource();
                gridControl2.DataSource = danjumingxis;
            }
            else
            {
                if (Useful == FormUseful.修改)
                {
                    txtdanhao.Text = liuzhuancard.CardNum;
                    txtbeizhu.Text = liuzhuancard.Beizhu;
                    txtkehu.Text = liuzhuancard.Customer;
                    txtkezhong.Text = liuzhuancard.Kezhong;
                    txtmenfu.Text = liuzhuancard.Menfu;
                    txtpingming.Text = liuzhuancard.Pingming;
                    txtshuliang.Text = liuzhuancard.Shuliang.ToString();
                    txtyanse.Text = liuzhuancard.Color;
                    txtckmc.Text = liuzhuancard.StockName;
                    
                    var gongyis = TechnologyTableService.GetTechnologyTablelst("select * from Technologytable");
                    foreach (var g in gongyis)
                    {
                        liuzhuangkamingxi.Add(new liuzhuanmingxi() { CardNum = txtdanhao.Text, GongyiYaoqiu = g.Technology, Cishu = 1, Beizhu = "" });
                    }
                    var mingxis = liuzhuanmingxiService.Getliuzhuanmingxilst(x => x.CardNum == txtdanhao.Text);
                    foreach (var m in mingxis)
                    {
                        var z = liuzhuangkamingxi.Where(x => x.GongyiYaoqiu == m.GongyiYaoqiu).ToList()[0];
                        z.Employee = m.Employee;
                        z.Cishu = m.Cishu;
                        z.Beizhu = m.Beizhu;
                        z.MachineID = m.MachineID;
                    }
                    gridControl1.DataSource = liuzhuangkamingxi;
                    gridControl1.RefreshDataSource();
                    danjumingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == txtdanhao.Text);
                    var count = danjumingxis.Count;
                    for (int i = 0; i < 30 - count; i++)
                    {
                        danjumingxis.Add(new danjumingxitable { danhao = txtdanhao.Text });
                    }
                    gridControl2.DataSource = danjumingxis;
                    gridControl2.RefreshDataSource();
                }
                else
                {
                    if (Useful == FormUseful.新增)
                    {
                        txtdanhao.Text = BianhaoBLL.CreateLiuzhuanKahao(FirstLetter.流转卡, uiDatePicker1.Value);
                        txtbeizhu.Text = "";
                        txtkehu.Text = "";
                        txtkezhong.Text = string.Empty;
                        txtmenfu.Text = string.Empty;
                        txtpingming.Text = string.Empty;
                        txtckmc.Text = string.Empty;
                        txtshuliang.Text = danjumingxis.Sum(x => x.chengpingmishu).ToString();
                        txtyanse.Text = danjumingxis.Count > 0 ? danjumingxis[0].yanse : string.Empty; ;
                        var gongyis = TechnologyTableService.GetTechnologyTablelst("select * from Technologytable");

                        foreach (var g in gongyis)
                        {
                            liuzhuangkamingxi.Add(new liuzhuanmingxi() { CardNum = txtdanhao.Text, GongyiYaoqiu = g.Technology, Cishu = 1 });
                        }
                        //danjumingxis.AddRange(new danjumingxitable[30] );            
                        danjumingxis.Clear();
                        var count = danjumingxis.Count;
                        for (int i = 0; i < 30 - count; i++)
                        {
                            danjumingxis.Add(new danjumingxitable { danhao = txtdanhao.Text });
                        }
                        gridControl1.RefreshDataSource();
                        gridControl2.DataSource = danjumingxis;
                        gridControl2.RefreshDataSource();
                    }
                    else
                    {
                        if(Useful==FormUseful.查看 )
                        {
                            txtdanhao.Text = BianhaoBLL.CreateLiuzhuanKahao(FirstLetter.流转卡, uiDatePicker1.Value);
                            //danjumingxis.AddRange(new danjumingxitable[30] );            
                            var count = danjumingxis.Count;
                            foreach (var d in danjumingxis)
                            {
                                d.danhao = txtdanhao.Text;
                            }
                            for (int i = 0; i < 30 - count; i++)
                            {
                                danjumingxis.Add(new danjumingxitable { danhao = txtdanhao.Text });
                            }
                            gridControl1.RefreshDataSource();
                            gridControl2.DataSource = danjumingxis;
                        }
                    }
                }
            }

        }

        private void 选择布料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 工艺选择();
            fm.ShowDialog();
            foreach (var t in fm.technologyTables)
            {
                txtbeizhu.Text += t.Technology + "+";
            }
            txtbeizhu.Text = txtbeizhu.Text.Substring(0, txtbeizhu.Text.Length - 1);
        }

        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer(PrintModel.Design);
        }
        private void Printer(int printModel)
        {
            gridView1.CloseEditor();
            gridView2.CloseEditor();
            if(gridView2.GetSelectedRows ().Length  ==0)
            {
                Sunny.UI.UIMessageBox.ShowError("没有任何布料别选中！\r\n请把要开流转卡的布料选中,布料前面打勾");
                return;
            }
            var fs = new FastReport.Report();
            DataTable liuzhuandan = new DataTable("流转单信息");
            liuzhuandan.Columns.Add("流转卡号");
            liuzhuandan.Columns.Add("客户名称");
            liuzhuandan.Columns.Add("日期", typeof(DateTime));
            liuzhuandan.Columns.Add("品名");
            liuzhuandan.Columns.Add("克重");
            liuzhuandan.Columns.Add("门幅");
            liuzhuandan.Columns.Add("颜色");
            liuzhuandan.Columns.Add("数量", typeof(decimal));
            liuzhuandan.Columns.Add("备注");
            liuzhuandan.Rows.Add();
            //赋值
            liuzhuandan.Rows[0]["流转卡号"] = txtdanhao.Text;
            liuzhuandan.Rows[0]["客户名称"] = txtkehu.Text;
            liuzhuandan.Rows[0]["日期"] = uiDatePicker1.Value;
            liuzhuandan.Rows[0]["品名"] = txtpingming.Text;
            liuzhuandan.Rows[0]["克重"] = txtkezhong.Text;
            liuzhuandan.Rows[0]["门幅"] = txtmenfu.Text;
            liuzhuandan.Rows[0]["颜色"] = txtyanse.Text;
            liuzhuandan.Rows[0]["数量"] = Convert.ToDecimal(txtshuliang.Text);
            liuzhuandan.Rows[0]["备注"] = txtbeizhu.Text;
            //
            DataSet ds = new DataSet();
            ds.Tables.Add(liuzhuandan);
            ///明细
            DataTable mingxi = new DataTable("流转卡明细");
            try
            {
                for (var col = 0; col < gridView1.Columns.Count; col++)
                {
                    mingxi.Columns.Add(gridView1.Columns[col].Caption);
                }
                //明细赋值
                for (var row = 0; row < gridView1.RowCount; row++)
                {
                    var index = mingxi.Rows.Add();
                    for (var col = 0; col < gridView1.Columns.Count; col++)
                    {
                        index[col] = gridView1.GetRowCellValue(row, gridView1.Columns[col].FieldName);
                    }
                }

                ds.Tables.Add(mingxi);
                ////布料信息
                ///明细
                DataTable bulioaos = new DataTable("布料明细");
                for (var col = 0; col < gridView2.Columns.Count; col++)
                {
                    bulioaos .Columns.Add(gridView2.Columns[col].Caption);
                }
                //布料明细赋值
              foreach (var row in gridView2.GetSelectedRows ())
                {
                    if (!string.IsNullOrWhiteSpace(gridView2.GetRowCellValue(row, "pingming").ToString()))
                    {
                        var index = bulioaos.Rows.Add();
                        for (var col = 0; col < gridView2.Columns.Count; col++)
                        {
                            index[col] = gridView2.GetRowCellValue(row, gridView2.Columns[col].FieldName);
                        }
                    }
                }
                ds.Tables.Add(bulioaos);
            }
            catch (Exception ex)
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, ex.Message);
            }
            fs.RegisterData(ds);
            if (File.Exists(Application.StartupPath + "\\Report\\流转单.frx"))
            {
                fs.Load(Application.StartupPath + "\\Report\\流转单.frx");
            }
            else
            {
                fs.Design();
                return;
            }
            try
            {
                switch (printModel)
                {
                    case PrintModel.Design:
                        fs.Design();
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                    case PrintModel.Print:
                        fs.Print();
                        break;
                }
            }
            catch 
            {
                fs.Design();
            }
            if (Sunny.UI.UIMessageBox.ShowAsk("是否直接保存该单据？\r\n保存按确定，否则按取消"))
            {
                新增ToolStripMenuItem_Click(null, null);
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer(PrintModel.Privew );
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer(PrintModel.Print );
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            gridView2.CloseEditor();
            if (gridView2.GetSelectedRows().Length == 0)
            {
                Sunny.UI.UIMessageBox.ShowError("没有任何布料别选中！\r\n请把要开流转卡的布料选中,布料前面打勾");
                return;
            }
            var liuzhuandan = new Liuzhuancard()
            {
                Beizhu = txtbeizhu.Text,
                CardNum = txtdanhao.Text,
                Card_Date = uiDatePicker1.Value.Date,
                Color = txtyanse.Text,
                Customer = txtkehu.Text,
                Ganghao = string.Empty,
                Kezhong = txtkezhong.Text,
                Menfu = txtmenfu.Text,
                Pingming = txtpingming.Text,
                StockName = txtckmc.Text,
                Shuliang = Convert.ToDecimal(txtshuliang.Text),
                ID=liuzhuancard !=null? liuzhuancard.ID :0,
                own = User.user.YHBH
        };
            var mingxi = new List<liuzhuanmingxi>();
            //MessageBox.Show(gridView1.GetRowCellValue(0, colGongyiYaoqiu.FieldName).ToString());
            for (int row = 0; row < gridView1.RowCount; row++)
            {
                mingxi.Add(new liuzhuanmingxi()
                {
                    Beizhu = gridView1.GetRowCellValue(row, colBeizhu.FieldName) == null ? string.Empty : gridView1.GetRowCellValue(row, colBeizhu.FieldName).ToString(),
                    CardNum = txtdanhao.Text,
                    Employee = gridView1.GetRowCellValue(row, colEmployee.FieldName) == null ? string.Empty : gridView1.GetRowCellValue(row, colEmployee.FieldName).ToString(),
                    GongyiYaoqiu = gridView1.GetRowCellValue(row, colGongyiYaoqiu.FieldName) == null ? string.Empty : gridView1.GetRowCellValue(row, colGongyiYaoqiu.FieldName).ToString(),
                    MachineID = gridView1.GetRowCellValue(row, colMachineID.FieldName) == null ? string.Empty : gridView1.GetRowCellValue(row, colMachineID.FieldName).ToString(),
                    Cishu = Convert.ToInt32(gridView1.GetRowCellValue(row, colCishu.FieldName)),
                });
            }
            List<danjumingxitable> resmingxis = new List<danjumingxitable>();          
            foreach (var row in gridView2.GetSelectedRows ())
            {
                if (!string.IsNullOrWhiteSpace(gridView2.GetRowCellValue(row, "pingming").ToString()))
                {
                    resmingxis.Add(danjumingxis[row]);
                }
            }
            if (Useful == FormUseful.修改 )
            {
                流转单BLL.修改(liuzhuandan, mingxi , stocks,  resmingxis.Where(x => x.pingming != null).ToList());
            }
            else
            {
                流转单BLL.保存(liuzhuandan, mingxi , stocks,resmingxis .Where (x=>x.pingming!=null ).ToList ());
            }        
            gridView2.DeleteSelectedRows();
            if(danjumingxis.Sum(x=>x.chengpingmishu )>0)
            {
                if(Sunny.UI.UIMessageBox.ShowAsk ("还有剩余布料没有开具流转卡!是否继续开具流转卡\r\n继续请按确定,重新开具请按取消?"))
                {
                    txtshuliang.Text = danjumingxis.Sum(x => x.chengpingmishu).ToString();
                    Useful = FormUseful.查看;
                }
                else
                {
                    Useful = FormUseful.新增;
                    danjumingxis.Clear();
                }
            }
            else
            {
                Useful = FormUseful.新增;
            }
            Thread.Sleep(1000);
            InitForm();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView2.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = uiDatePicker1.Value });
            gridControl2.RefreshDataSource();
        }

        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowindex = gridView2.FocusedRowHandle;
        }

        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRow.Copy<danjumingxitable>(danjumingxis, rowindex, gridView2, gridView2.FocusedRowHandle,this);
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView2) { formname = this.Name, Obj = new danjumingxitable() };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView2);
        }

        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                if (txtckmc.Text == "")
                {
                    MessageBox.Show("请先选择仓库名称", "错误", MessageBoxButtons.OK);
                    return;
                }
                var fm = new 库存选择() { StockName = txtckmc.Text };
                fm.ShowDialog();
                var i = gridView2.FocusedRowHandle;
                
                foreach (var pingzhong in fm.pingzhong)
                {
                   
                    danjumingxis[i].bizhong = "人民币￥";
                    danjumingxis[i].Bianhao = pingzhong.BH;
                    danjumingxis[i].guige = pingzhong.GG;
                    danjumingxis[i].chengfeng = pingzhong.CF;
                    danjumingxis[i].pingming = pingzhong.PM;
                    danjumingxis[i].kezhong = pingzhong.KZ;
                    danjumingxis[i].menfu = pingzhong.MF;
                    danjumingxis[i].danwei = "米";
                    danjumingxis[i].ContractNum = pingzhong.ContractNum;
                    danjumingxis[i].CustomName = pingzhong.CustomName;
                    danjumingxis[i].OrderNum = pingzhong.orderNum;
                    danjumingxis[i].kuanhao = pingzhong.kuanhao;
                    danjumingxis[i].houzhengli = pingzhong.houzhengli;
                    danjumingxis[i].yanse = pingzhong.YS;
                    danjumingxis[i].Chengpingyanse = pingzhong.YS;
                    danjumingxis[i].ganghao = pingzhong.GH;
                    danjumingxis[i].chengpingjuanshu = pingzhong.JS;
                    danjumingxis[i].chengpingmishu = pingzhong.MS;
                    danjumingxis[i].Kuwei = pingzhong.Kuwei;
                    danjumingxis[i].Huahao = pingzhong.Huahao;
                    danjumingxis[i].ColorNum = pingzhong.ColorNum;
                    danjumingxis[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxis[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    danjumingxis[i].rq = uiDatePicker1.Value;
                    danjumingxis[i].IsHanshui = IsHanshuiModel.含税;
                    danjumingxis[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                    && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                    danjumingxis[i].hanshuiheji = danjumingxis[i].hanshuidanjia * pingzhong.MS;
                    i++;
                    if (i == danjumingxis.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = Convert.ToDateTime(uiDatePicker1.Text) });
                        }
                }
                var mingxi = danjumingxis[0];
                txtkezhong.Text = mingxi.kezhong ;
                txtpingming.Text = mingxi.pingming  ;
                txtyanse.Text = mingxi.yanse ;
                txtmenfu.Text = mingxi.menfu ;
                txtguige.Text = mingxi .guige ;
                txtshuliang.Text = danjumingxis.Sum(x => x.chengpingmishu).ToString();
                gridControl2.RefreshDataSource();
                gridView2.CloseEditor();
            }
        }

        private void txtckmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 仓库选择();
            fm.ShowDialog();
            txtckmc.Text = fm.stock.mingcheng;
        }

        private void 选择布料ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ButtonEdit1_ButtonClick(null, null);
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择() { linkman = new LXR() { ZJC = "", MC = "" } };
            fm.ShowDialog();
            txtkehu.Text = fm.linkman.MC;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            txtshuliang.Text = danjumingxis.Sum(x => x.chengpingmishu).ToString();
        }

        private void 复制单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.Focus();
            SendKeys.Send("^c");
        }

        private void 粘贴单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.Focus();
            SendKeys.Send("^v");
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            decimal total = 0;
            foreach (var row in gridView2.GetSelectedRows())
            {
                total += gridView2.GetRowCellValue(row, "chengpingmishu").TryToDecmial();
            }
            txtshuliang.Text = total.ToString ();
            if (gridView2.GetSelectedRows().Length > 0)
            {
                txtpingming.Text = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "pingming").ToString();
                txtguige.Text = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "guige").ToString();
                txtmenfu.Text = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "menfu").ToString();
                txtkezhong.Text = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "kezhong").ToString();
                txtyanse.Text = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "yanse").ToString();
            }
        }
    }
}
