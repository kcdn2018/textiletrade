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
using Tools;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 供货商对账单 : Form
    {
        public LXR LinkMan { get; set; }
        public int Useful { get; set; }
        public 供货商对账单()
        {
            InitializeComponent();
            dateEdit1.DateTime =DateTime.Now.AddDays(0-DateTime.Now.Day );
            dateEdit2.DateTime = DateTime.Now;

            try
            {
                CreateGrid.Create(this.Name, gridView1);
                gridView1.Columns["IsCheck"].ColumnEdit = CheckEdit1;
            }
            catch
            {
                配置列ToolStripMenuItem_Click(null,null );
            }
        }
        private void Query()
        {
            Sunny.UI.UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            var dt = SQLHelper.SQLHelper.Chaxun($"select LwDetail.*,danjumingxitable.* from lwDetail left join danjumingxitable on lwdetail.dh=danjumingxitable.danhao where lwDetail.rq between '{ dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date }' and lwdetail.KHBH = '{LinkMan.BH }' order by lwdetail.rq asc");
            DataRow dataRow = dt.NewRow();
            int index = 0;
            if (dt.Rows.Count > 0)
            {
                while (dt.Rows[index]["LX"].ToString() == DanjuLeiXing.发票签收 )
                {
                    index++;
                    if(index==dt.Rows.Count )
                    {
                        break;
                    }
                }
                if (index < 0)
                {
                    index = 0;
                }
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[index]["qichujine"] != DBNull.Value)
                    {
                        dataRow["Qimojine"] = dt.Rows[index]["Qichujine"];
                        dataRow["LX"] = "期初金额";
                        dt.Rows.InsertAt(dataRow, 0);

                    }
                }
                for (int row = 1; row < dt.Rows.Count; row++)
                {
                    if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.发票签收 )
                    {
                        dt.Rows[row]["hanshuiheji"] = 0;
                        dt.Rows[row]["hanshuidanjia"] = 0;
                        dt.Rows[row]["chengpingmishu"] = 0;
                    }
                    if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.打样工艺单 )
                    {
                        dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["je"];
                        dt.Rows[row]["LX"] = DanjuTableService.GetOneDanjuTable(x => x.dh == dt.Rows[row]["DH"].ToString()).jiagongleixing ;
                    }
                    if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.采购退货单)
                    {
                        dt.Rows[row]["ReduceYingShouFapiao"]=0;
                    }
                    decimal qichu, qimo, hanshui, yingfukuan;
                    qichu = dt.Rows[row - 1]["Qimojine"].TryToDecmial(0);
                    dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["hanshuiheji"].TryToDecmial(0)+ dt.Rows[row]["weishuiheji"].TryToDecmial(0);
                    hanshui = dt.Rows[row]["hanshuiheji"].TryToDecmial(0);
                    yingfukuan = dt.Rows[row]["ReduceYingFuKuan"].TryToDecmial(0);
                    if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.付款单)
                    {
                        dt.Rows[row]["hanshuiheji"] = 0;
                        qimo = qichu - yingfukuan; }
                    else
                    {
                        qimo = qichu + hanshui;
                    }
                    dt.Rows[row]["Qimojine"] = qimo;
                    //dt.Rows[row]["Qimojine"] = dt.Rows[row - 1]["Qimojine"].ToDecimal(0) + dt.Rows[row]["hanshuiheji"].ToDecimal(0)-dt.Rows [row]["ReduceYingFuKuan"].ToDecimal (2);
                }
            }
            gridControl1.DataSource = dt;
            Sunny.UI.UIWaitFormService.HideWaitForm ();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, LinkMan.MC+ "对账单");
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, LinkMan.MC + "对账单");
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, dt=gridControl1 .DataSource as DataTable  };
            fm.ShowDialog();
        }

        private void 对账单_Load(object sender, EventArgs e)
        {
            txtksmc.Text = LinkMan.MC;
            Query();
        }

        private void txtksmc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Useful==FormUseful.客户 )
            {
                var fm = new 客户选择() { linkman=new LXR() { ZJC=txtksmc.Text,MC="" } };
                fm.ShowDialog();
                LinkMan = fm.linkman;
            }
            else
            {
                var fm = new 供货商选择 () { linkman = new LXR() { ZJC = txtksmc.Text, MC = "" } };
                fm.ShowDialog();
                LinkMan = fm.linkman;
            }
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle > 0)
                {
                    var dt = gridControl1 .DataSource as DataTable;
                    for (var row = 1; row < dt.Rows.Count; row++)
                    {
                        dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["chengpingmishu"].TryToDecmial(0) * dt.Rows[row]["hanshuidanjia"].TryToDecmial(0) + dt.Rows[row]["weishuiheji"].TryToDecmial(0);
                        dt.Rows[row]["qimojine"] = dt.Rows[row - 1]["qimojine"].TryToDecmial(0) + dt.Rows[row]["weishuiheji"].TryToDecmial(0) + dt.Rows[row]["hanshuiheji"].TryToDecmial(0)-dt.Rows[row]["ReduceYingfukuan"].TryToDecmial(0);
                    }
                    gridControl1.DataSource = dt;
                }               
            }
            catch
            { }
        }

        private void CheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var dh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString();
                var lw = LwDetailService.GetOneLwDetail(x => x.DH == dh);
                if (Convert.ToBoolean (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IsCheck")) == true)
                {
                    lw.IsCheck = true;
                }
                else
                {
                    lw.IsCheck = false;
                }
                LwDetailService.UpdateLwDetail(lw, x => x.DH == dh);
            }
        }

        private void 保存对账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = gridControl1.DataSource as DataTable;
            for (int row = 1; row < dt.Rows.Count; row++)
            {
                dt.Rows[row]["IsCheck"] = true;
                var dh = gridView1.GetRowCellValue(row, "DH").ToString();
                Task.Run(() => {
                    var lw = LwDetailService.GetOneLwDetail(x => x.DH == dh);
                    lw.IsCheck = true;
                    LwDetailService.UpdateLwDetail(lw, x => x.DH == dh);
                });
            }
            gridControl1.RefreshDataSource();
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = gridControl1.DataSource as DataTable;
            for (int row = 1; row < dt.Rows.Count; row++)
            {
                dt.Rows[row]["IsCheck"] = true;
                var dh = gridView1.GetRowCellValue(row, "DH").ToString();
                Task.Run(() => {
                    var lw = LwDetailService.GetOneLwDetail(x => x.DH == dh);
                    lw.IsCheck = false;
                    LwDetailService.UpdateLwDetail(lw, x => x.DH == dh);
                });
            }
            gridControl1.RefreshDataSource();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appNotPass1 = new DevExpress.Utils.AppearanceDefault(Color.Black, Color.Salmon, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                DevExpress.Utils.AppearanceDefault appNotPass2 = new DevExpress.Utils.AppearanceDefault(Color.Black, Color.Red, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                if (e.RowHandle > 0)
                {
                    if (!string.IsNullOrWhiteSpace(gridView1.GetRowCellValue(e.RowHandle, "LX").ToString()))
                    {
                        switch (gridView1.GetRowCellValue(e.RowHandle, "LX").ToString())
                        {
                            case DanjuLeiXing.付款单:
                                e.Appearance.ForeColor = Color.Red;
                                break;
                            case DanjuLeiXing.发票签收:
                                e.Appearance.ForeColor = Color.Blue;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("显示特定行颜色是发生了错误" + ex.Message);
            }
        }
    }
}
