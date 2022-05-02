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
    public partial class 对账单 : Form
    {
        public LXR LinkMan { get; set; }
        public int Useful { get; set; }
        public 对账单()
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
               
                var fm = new 配置列(gridView1) { formname = this.Name, dt = gridControl1.DataSource as DataTable };
                fm.ShowDialog(); 
                Query();
            }
        }
  
        private void Query()
        {
            Sunny.UI.UIWaitFormService.ShowWaitForm("正在查询，请等待.............");
            DataTable dt = new DataTable();
            if (checkBox1.Checked == true)
            { dt = SQLHelper.SQLHelper.Chaxun($"select LwDetail.*,danjumingxitable.* from lwDetail left join danjumingxitable on lwdetail.dh=danjumingxitable.danhao where lwDetail.rq between '{ dateEdit1.DateTime.Date}' and '{dateEdit2.DateTime.Date.AddDays (1)}' and lwdetail.KHBH = '{LinkMan.BH }' order by lwdetail.rq asc"); }
            else
            {
                dt = SQLHelper.SQLHelper.Chaxun($"select LwDetail.*,danjumingxitable.* from lwDetail left join danjumingxitable on lwdetail.dh=danjumingxitable.danhao where lwdetail.IsCheck='false' and lwDetail.rq between '{ dateEdit1.DateTime.Date }' and '{dateEdit2.DateTime.Date.AddDays (1) }' and lwdetail.KHBH = '{LinkMan.BH }' order by lwdetail.rq asc");
            }
            //DataView dv = querydt.DefaultView;
            //DataTable dt = dv.ToTable(true, new string[] { "ID"});
            DataRow dataRow = dt.NewRow();
            int index = 0;
            decimal Initqichu = 0;
            if (dt.Rows.Count > 0)
            {
                
               while(dt.Rows[index ]["LX"].ToString ()==DanjuLeiXing.发票开具 || dt.Rows[index ]["LX"].ToString() ==DanjuLeiXing.销售订单)
                {
                    if(dt.Rows[index]["LX"].ToString() == DanjuLeiXing.销售订单)
                    {
                        Initqichu += dt.Rows[index]["je"].TryToDecmial(0);
                    }
                    index++;
                    if(index ==dt.Rows .Count )
                    {
                        break;
                    }
                }
                if(index <0)
                {
                    index = 0;
                }
                if (dt.Rows.Count > 0 && index <dt.Rows.Count )
                {
                    if (dt.Rows[index]["qichujine"] != DBNull.Value)
                    {
                        dataRow["Qimojine"] = dt.Rows[index]["Qichujine"].TryToDecmial(0) - Initqichu;
                        dataRow["LX"] = "期初金额";
                        dt.Rows.InsertAt(dataRow, 0);
                    }
                }
                else
                {
                    if(index ==dt.Rows.Count )
                    {
                        dataRow["Qimojine"] = dt.Rows[index-1]["Qichujine"].TryToDecmial(0) - Initqichu;
                        dataRow["LX"] = "期初金额";
                        dt.Rows.InsertAt(dataRow, 0);
                    }
                }
            }
          for(int row=1;row<dt.Rows.Count;row++)
            {
                if(dt.Rows[row]["LX"].ToString ()==DanjuLeiXing.发票开具 )
                {
                    dt.Rows[row]["hanshuiheji"] = 0;
                    dt.Rows[row]["hanshuidanjia"] = 0;
                    dt.Rows[row]["chengpingmishu"] = 0;
                }
                if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.销售订单 )
                {
                    dt.Rows[row]["weishuiheji"] = dt.Rows[row]["hanshuiheji"];
                    //dt.Rows[row]["hanshuiheji"] = 0;
                }
                if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.销售退货单 )
                {
                    dt.Rows[row]["ReduceYingKaiFapiao"] = 0;
                }
                if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.打样工艺单)
                {
                    dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["je"];
                    dt.Rows[row]["LX"] = DanjuTableService.GetOneDanjuTable(x => x.dh == dt.Rows[row]["DH"].ToString()).jiagongleixing;
                }
                if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.销售出库单 )
                {
                    //if (!string.IsNullOrWhiteSpace(dt.Rows[row]["weishuiheji"].ToString()) && !string.IsNullOrWhiteSpace(dt.Rows[row]["hanshuiheji"].ToString()))
                    //{
                        dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["weishuiheji"].TryToDecmial(0) +dt.Rows[row]["hanshuiheji"].TryToDecmial(0);
                    //}
                }
                decimal qichu, qimo, hanshui, yingshoukuan,otherCost;
                qichu = dt.Rows[row - 1]["Qimojine"].TryToDecmial(0);          
                yingshoukuan = dt.Rows[row]["ReduceYingShouKuan"].TryToDecmial(0);
                otherCost = dt.Rows[row]["weishuiheji"].TryToDecmial(0);
                hanshui = dt.Rows[row]["hanshuiheji"].TryToDecmial(0) ;
                if (dt.Rows[row]["LX"].ToString() == DanjuLeiXing.收款单)
                {
                    dt.Rows[row]["hanshuiheji"] = 0;
                    qimo = qichu - yingshoukuan;
                }
                else
                {
                    qimo = qichu + hanshui ;
                }
                dt.Rows[row]["Qimojine"] = qimo ;               
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
                    var dt = gridControl1.DataSource as DataTable;
                    for (var row = 1; row < dt.Rows.Count; row++)
                    {
                        dt.Rows[row]["hanshuiheji"] = dt.Rows[row]["chengpingmishu"].TryToDecmial(0) * dt.Rows[row]["hanshuidanjia"].TryToDecmial(0) + dt.Rows[row]["weishuiheji"].TryToDecmial(0);
                        dt.Rows[row]["qimojine"] = dt.Rows[row - 1]["qimojine"].TryToDecmial(0) + dt.Rows[row]["hanshuiheji"].TryToDecmial(0) - dt.Rows[row]["ReduceYingShoukuan"].TryToDecmial(0);
                    }
                    gridControl1.DataSource = dt;
                }

            }
            catch
            { }
        }

        private void 保存对账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = gridControl1 .DataSource as DataTable;
            for(int row=1;row<dt.Rows.Count;row++)
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

        private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var dh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DH").ToString();
                var lw = LwDetailService.GetOneLwDetail(x => x.DH == dh);
                if (Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IsCheck")) == true)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Query();
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
                    lw.IsCheck = false ;
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
                        if (!string.IsNullOrWhiteSpace(gridView1.GetRowCellValue (e.RowHandle , "LX").ToString ()))
                        {
                          switch (gridView1.GetRowCellValue(e.RowHandle, "LX").ToString() )
                           
                            {
                            case DanjuLeiXing.销售订单:
                                e.Appearance.ForeColor = Color.Red;// 改变行背景颜色
                                break;
                            case DanjuLeiXing.收款单:
                                e.Appearance.ForeColor = Color.Blue;
                                break;
                            case DanjuLeiXing.发票开具:
                                e.Appearance.ForeColor = Color.Salmon;
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
