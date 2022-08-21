
using DAL;
using DevComponents.AdvTree;
using DevExpress.XtraEditors;
using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.其他窗体;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.基本资料
{
    public partial class 品种资料 : Form
    {
        private List<db> dblist = new List<db>();
        private string lb;
        public 品种资料()
        {
            InitializeComponent();
            var mobans = Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels");
            cmbMoban .Items .AddRange ( mobans.ToArray () );
            if (mobans.Where (x=>x==QueryTime.DefaultLabel ).Count ()>0)
            {
                cmbMoban.Text  = QueryTime.DefaultLabel ;
            }
            else
            {
                MessageBox.Show("系统找不到默认标签模板！系统将把第一个模板设定为默认模板");
                QueryTime.DefaultLabel = cmbMoban.Text;
                SettingService.Update(new Model.Setting() { formname = "", settingname = "默认标签", settingValue = cmbMoban.Text });
            }
            CreateGrid.Create(this.Name, gridView1);
            gridView1.OptionsCustomization.AllowSort = true;
            //Query();
        }
        private void CreatLeibie()
        {
            var lblist = Connect.CreatConnect().Query("select distinct lb from db");
            var node = new TreeNode() { Text = "所有类别", Name = "所有类别" };
            for  (int i=0;i<lblist.Rows.Count;i++ )
            {
                node.Nodes.Add(new TreeNode() { Text = lblist .Rows[i]["lb"].ToString (), Name = lblist.Rows[i]["lb"].ToString() });
            }
            treeView1.Nodes.Add(node);
            treeView1.ExpandAll();
        }
        private void 品种资料_Load(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { CreatLeibie(); });
            Query();
        }
        private void Query()
        {          
                if (txtNum.Text.TryToInt() > 0 && txtCurPage.Text.TryToInt () > 0)
                {
                    int peixv;
                    if (uiRadioButton1.Checked == true)
                    {
                        peixv = 0;
                    }
                    else
                    { peixv = 1; }
                    dblist = dbService.Getdblst(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text) && x.lb.Contains(lb)
                  && x.Fengge.Contains(txtFengge.Text) && x.YongTu.Contains(txtYongtu.Text) && x.GHSMC.Contains(txtGonghuoshang.Text) && x.GonghuoShangBianHao.Contains(txtGHSBH.Text), txtCurPage.Text.ToInt(0), txtNum.Text.ToInt(0), txtCurPage.Text.ToInt(1), peixv);

                    //txtCounter.Text = dblist.Count.ToString();
                    string wherestring = SQLHelper.SqlSugor.GetWhereByLambda<db>(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text) && x.lb.Contains(lb)
                    && x.Fengge.Contains(txtFengge.Text) && x.YongTu.Contains(txtYongtu.Text) && x.GHSMC.Contains(txtGonghuoshang.Text) && x.GonghuoShangBianHao.Contains(txtGHSBH.Text), "sqlserver");
                    txtCounter.Text = Connect.CreatConnect().Query("select count(id) from db where "+ wherestring ).Rows[0][0].ToString();
                    txtPageNum.Text = Math.Ceiling(txtCounter.Text.TryToInt() / txtNum.EditValue.TryToDecmial(0)).ToString();
                    //txtCurPage.Text = "1";
                    gridControl1.DataSource = dblist;//dblist.Skip (txtCurPage.Text.ToInt32 ()-1*txtNum.Text .ToInt32 () ).Take(txtNum.Text.ToInt32 ());
                }
        }
        private void CreatGrid()
        {
            //foreach (ColumnTable columnTable in Connect.GetColumntable(this.Name, gridView1.Name, User.user.YHBH))
            //{
            //    gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            //    {
            //        Name = columnTable.ColumnName,
            //        Caption = columnTable.ColumnText,
            //        FieldName = columnTable.DataProperty,
            //        Width = columnTable.Width,
            //        Visible = columnTable.Visible,
            //        VisibleIndex = columnTable.VisibleID
            //    });
            //}

            if (treeView1.SelectedNode != null)
            {
                lb = treeView1.SelectedNode.Text;
            }
            else
            {
                lb = "";
            }
            if (lb == "所有类别")
            {
                lb = "";
            }
           // Query();
        }
        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name ,Obj =new db()};
            fm.ShowDialog();
        }
        private void 打印编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetAccess.IsCanPrintDesign)
            {
                PrintLabels(PrintModel.Design);
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowWarningDialog(this, "对不起！您没有打印编辑的权限！\r\n请联系管理员开通");
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLabels(PrintModel.Privew );
        }

        private void 直接打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLabels(PrintModel.Print);
        }
        private void PrintLabels(int Useful)
        {
            string printer = string.Empty;
            decimal num = 1;
            Boolean IsContinuation = false;
            if (Useful == PrintModel.Print)
            {
                var fm = new 打印设置窗体();
                fm.ShowDialog();
                printer = fm.printer;
                num = fm.copyies;
                IsContinuation = fm.Continuation;
            }
            if (IsContinuation == false)
            {
                List<LabelExtend> labels = new List<LabelExtend>();
                foreach (var i in gridView1.GetSelectedRows())
                {
                    labels.Add(SQLHelper.MapperHelper.Mapper<db, LabelExtend>(dblist.First(x => x.bh == gridView1.GetRowCellValue(i, "bh").ToString()), new LabelExtend()));
                }
                Tools.打印标签.打印寄样票签(labels, new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, Printmodel = Useful, PrintName = printer, PrintNum = (int)num });
            }
            else
            {
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        Tools.打印标签.打印(0, dblist.First(x => x.bh == gridView1.GetRowCellValue(i, "bh").ToString()), new PrintSetting() { Path = PrintPath.标签模板 + cmbMoban.Text, Printmodel = Useful , PrintName = printer, PrintNum = (int)num }, ShengChengGongYiService.GetShengChengGongYilst(x => x.SPBH == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh").ToString()), new JiYangBaoJia());
                    }             
            }
         }


        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增品种"))
            {
                var fm = new 新增品种() { Useful = FormUseful.新增 };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("修改品种"))
            {
                var fm = new 新增品种() { Useful = FormUseful.修改, Pingzhong = dblist.First(x => x.bh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh").ToString()) };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("删除品种信息"))
            {
                if (gridView1.GetSelectedRows().Length == 0)
                { Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有选择任何需要删除的布料品种!\n删除失败"); return; }
                try
                {
                    var res = MessageBox.Show($"您确定要删除选中的这些品种信息吗？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if ((int)res == 6)
                    {
                        foreach (var i in gridView1.GetSelectedRows())
                        {
                            dbService.Deletedb(x => x.bh == $"{gridView1.GetRowCellValue(i, "bh")}");
                            MadanPictureService.DeleteMadanPicture(x => x.ckdh == $"{gridView1.GetRowCellValue(i, "bh")}");
                            PriceTableService.DeletePriceTable(x => x.bianhao == $"{gridView1.GetRowCellValue(i, "bh")}");
                        }
                        AlterDlg.Show("删除成功！");
                        Query();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除时发生错误！" + ex.Message);
                }
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           lb=(treeView1.SelectedNode.Text=="所有类别"? "": treeView1.SelectedNode.Text);
            Query();
        }

      

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var fm = new InpuBox() { Label = "请输入你要新建的模板名称",内容="", filePath = PrintPath.标签模板 };
            fm.ShowDialog();
            if (fm.内容 != "")
            {
                Tools.获取模板.新增模板(PrintPath.标签模板, fm.内容,fm.参考模板,ReportService.标签 );
            }
            cmbMoban.Items.Clear();
            cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
        }

        private void txtbianhao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                txtCurPage.Text = "1";
                Query();
            }
        }

        private void 复制添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BLL.AccessBLL.CheckAccess("新增品种"))
            {
                var fm = new 新增品种() { Useful = FormUseful.复制, Pingzhong = dbService.GetOnedb(x => x.bh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh").ToString()) };
                fm.ShowDialog();
                Query();
            }
            else
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有权限使用该功能！请让管理员给您开通");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var fm = new 新增品种() { Useful = FormUseful.修改, Pingzhong = dbService.GetOnedb(x => x.bh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh").ToString()) };
            fm.ShowDialog();
            Query();
        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtCurPage.Text = "1";
            //gridControl1.DataSource = dblist.Skip(0).Take(txtNum.EditValue.ToInt32());
            Query();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if(txtCurPage.Text.Trim ()=="1")
            { AlterDlg.Show("已经是第一页了。");return; }
            txtCurPage.Text = (txtCurPage.Text.ToInt() - 1).ToString();
            // gridControl1.DataSource = dblist.Skip((txtCurPage.Text.ToInt32() - 1) * txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());
            Query();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (txtCurPage.Text.Trim() ==txtPageNum.Text.Trim ())
            { AlterDlg.Show("已经是最后一页了。"); return; }
            txtCurPage.Text = (txtCurPage.Text.ToInt() + 1).ToString();
            Query();//dblist.Skip((txtCurPage.Text.ToInt32() - 1) * txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());            
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {         
            txtCurPage.Text = (txtPageNum.Text.ToInt()).ToString();
             Query();// dblist.Skip(txtPageNum .Text.ToInt32() * txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());         
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (txtTopage.Text.Trim().ToInt () > txtPageNum.Text.ToInt ())
            { AlterDlg.Show("超出总页数了"); return; }
            txtCurPage.Text = (txtTopage.Text.ToInt() - 1).ToString();
            //gridControl1.DataSource = dblist.Skip((txtCurPage.Text.ToInt32()  )* txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());
            //gridControl1.RefreshDataSource();
            Query();
        }

        private void 导出全部到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string wherestring = SQLHelper.SqlSugor.GetWhereByLambda<db>(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text) && x.lb.Contains(lb)
                   && x.Fengge.Contains(txtFengge.Text) && x.YongTu.Contains(txtYongtu.Text) && x.GHSMC.Contains(txtGonghuoshang.Text) && x.GonghuoShangBianHao.Contains(txtGHSBH.Text), "sqlserver");
            gridControl1.DataSource = Connect.CreatConnect().Query("select * from db where " + wherestring);
            ExportFile.导出到文件(gridControl1, "品种清单");
            //gridControl1.DataSource = dblist.Skip((txtCurPage.Text.ToInt32()) * txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());
            //gridControl1.RefreshDataSource();
        }

        private void txtNum_EditValueChanged(object sender, EventArgs e)
        {
            txtPageNum.Text = (txtCounter.EditValue.TryToInt() / txtNum.EditValue.TryToInt ()).ToString();
            if(txtCurPage.Text.ToInt () >txtPageNum.Text.ToInt ())
            {
                txtCurPage.Text = txtPageNum.Text;
            }
            //gridControl1.DataSource = dblist.Skip((txtCurPage.Text.ToInt32() - 1) * txtNum.EditValue.ToInt32()).Take(txtNum.EditValue.ToInt32());
            Query();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }

        private void 查看图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                try
                {
                    Image image = Tools.ImgHelp.BytesToImage(MadanPictureService.GetOneMadanPicture(x => x.ckdh == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "bh").ToString()).picture);
                    var fm = new 图片显示();
                    if (image != null)
                    {
                        fm.Image = image;
                        fm.ShowDialog();
                    }
                    else
                    {
                        Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "查看图片失败！有可能没有没有保存图片");
                    }
                }
                catch
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "查看图片失败！有可能没有没有保存图片");
                }
            }
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(QueryTime.DefaultLabel ==cmbMoban.Text )
                {
                    MessageBox.Show("该模板为默认标签模板！不能删除");
                    return;
                }
                if (Sunny.UI.UIMessageBox.ShowAsk("您确定要删除改模板吗？"))
                {
                    Tools.ReportService.Delete(new ReportTable { reportName = cmbMoban.Text, reportStyle = Tools.ReportService.标签 }, Application.StartupPath);
                    MessageBox.Show("删除成功！");
                    cmbMoban.Items.Clear();
                    cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
                    cmbMoban.Text = QueryTime.DefaultLabel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败"+ex.Message);
            }
        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {
            Query();
        }

        private void 导出当前页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
            ExportFile.导出到文件(gridControl1, "品种清单");
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
            ExportFile.导出到文件(gridControl1, "品种清单");
        }

        private void 导出所有记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string wherestring = SQLHelper.SqlSugor.GetWhereByLambda<db>(x => x.bh.Contains(txtbianhao.Text) && x.pm.Contains(txtpingming.Text) && x.gg.Contains(txtguige.Text) && x.EnglishName.Contains(txtyingwenming.Text) && x.HH.Contains(txthuohao.Text) && x.lb.Contains(lb)
                   && x.Fengge.Contains(txtFengge.Text) && x.YongTu.Contains(txtYongtu.Text) && x.GHSMC.Contains(txtGonghuoshang.Text) && x.GonghuoShangBianHao.Contains(txtGHSBH.Text), "sqlserver");
           gridControl1.DataSource  = Connect.CreatConnect().Query("select * from db where " + wherestring);
            ExportFile.导出到文件(gridControl1, "品种清单");
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string col = gridView1.FocusedColumn.FieldName;
            string value = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, col).ToString();
            try
            {
                int ID =(int) gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                string updatestring = $"Update db set {col}='{value }' where ID='{ID }'";
                dbService.Updatedb(updatestring);
            }
            catch
            {
                Sunny.UI.UIMessageBox.ShowError("请先配置列！增加一个ID自增列");
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {              
                string newname = string.Empty;
                Sunny.UI.UIInputDialog.InputStringDialog(ref newname, true, "请输入新的模板名称");
                string oldname = cmbMoban.Text;
                if (oldname == QueryTime.DefaultLabel)
                {
                   if( MessageBox.Show ("该模板为默认标签模板！您确定要修改该模板的名字吗？\r\n确定修改的话系统将会同步修改默认模板")==DialogResult.OK )
                    {
                        var report = ReportTableService.GetOneReportTable(x => x.reportName == oldname && x.reportStyle == Tools.ReportService.标签);
                        ReportService.ReName(new ReportTable()
                        {
                            ReportFile = report.ReportFile,
                            reportName = newname + ".frx",
                            reportStyle = Tools.ReportService.标签,
                            ID = report.ID
                        }, Application.StartupPath, oldname) ;
                        cmbMoban.Items.Clear();
                        cmbMoban.Items.AddRange(Tools.获取模板.获取所有模板(Application.StartupPath + "\\labels").ToArray());
                        cmbMoban.Text = newname;
                        if (oldname == QueryTime.DefaultLabel)
                        {
                            SettingService.Update(new Model.Setting() { formname = "", settingname = "默认标签", settingValue = newname + ".frx" });
                        }
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改模板名字发送错误："+ex.Message);
            }
        }
    }
}
