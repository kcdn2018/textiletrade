using BLL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.设置窗体
{
    public partial class 配置列 : Sunny.UI.UIForm 
    {
        public string formname { get; set; }
        private List<ColumnTable> collist = new List<ColumnTable>();
        private GridView grid;
        private Sunny.UI.UIDataGridView sunnyview = new Sunny.UI.UIDataGridView();
        public DataTable dt { get; set; }
        public  Object Obj { get; set; }
        public 配置列(GridView gridView)
        {
            InitializeComponent();
            label1.Text = string.Empty;
            grid = gridView;
        }

        public 配置列(Sunny.UI.UIDataGridView  gridView)
        {
            InitializeComponent();
            sunnyview  = gridView;
        }
        private void 保存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            //foreach (var c in collist )
            //{ c.UserID = User.user.YHBH; 
            //}
            collist.ForEach(x => x.UserID = User.user.YHBH);
            label1 .Text = "正在保存，请等待";
            //Thread.Sleep(500);
            if (grid != null)
            {
                collist.ForEach(x => x.GridName = grid.Name);
                    Connect.DeleteColumnTable(formname, grid.Name, User.user.YHBH);
                    Connect.SaveColumnTable(collist);  
                    CreateGrid.Create(formname , grid );
            }
            else
            {
                collist.ForEach(x => x.GridName = sunnyview.Name);
                Connect.DeleteColumnTable(formname, sunnyview.Name , User.user.YHBH);
                    Connect.SaveColumnTable(collist);
                    CreateGrid.CreateDatagridview(formname, sunnyview);
            }
            statusStrip1.Text = "";
            this.Close();
        }

        private void 配置列_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text += formname;      
            cmbUser.DataSource= YhbService.GetYhblst().Select(x => x.YHBH).ToList ();
            调用窗体ToolStripMenuItem.DataSource = Connect.GetFormName();
            调用窗体ToolStripMenuItem.Text = formname;
            if (!AccessBLL.CheckAccess("配置列"))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "您没有配置列这个权限，请让管理员给你开通！");
                this.Dispose();
            }
            else
            {
                load();
            }
           
        }
        private void load()
        {
            if (grid == null)
            {
                collist = Connect.GetColumntable(formname, sunnyview.Name, User.user.YHBH);
                cmbGridName.Text = sunnyview.Name;
            }
            else
            {
                collist = Connect.GetColumntable(formname, grid.Name, User.user.YHBH);
                cmbGridName.Text = grid.Name;
            }
            if (collist.Count == 0)
            {
                if (grid != null)
                {
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        collist.Add(new ColumnTable()
                        {
                            ColumnText = grid.Columns[i].Caption,
                            DataProperty = grid.Columns[i].FieldName,
                            ColumnName = grid.Columns[i].Name,
                            FormName = formname,
                            GridName = grid.Name,
                            Visible = grid.Columns[i].Visible,
                            VisibleID = grid.Columns[i].VisibleIndex,
                            Width = grid.Columns[i].Width,
                            Edit = grid.Columns[i].OptionsColumn.AllowEdit,
                            Summary = grid.Columns[i].SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum,
                            UserID = User.user.YHBH,
                            AllowMerge = (int)grid.Columns[i].OptionsColumn.AllowMerge,
                        });
                    }
                }
                else
                {
                    for (int i = 0; i < sunnyview .Columns.Count; i++)
                    {
                        collist.Add(new ColumnTable()
                        {
                            ColumnText = sunnyview.Columns[i].HeaderText ,
                            DataProperty = sunnyview.Columns[i].DataPropertyName ,
                            ColumnName = sunnyview.Columns[i].Name,
                            FormName = formname,
                            GridName  = sunnyview.Name,
                            Visible = sunnyview.Columns[i].Visible,
                            //VisibleID = sunnyview.Columns[i].VisibleIndex,
                            Width = sunnyview.Columns[i].Width,
                            Edit = sunnyview.Columns[i].ReadOnly ,
                            //Summary = sunnyview.Columns[i].SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum,
                            UserID = User.user.YHBH,
                            //AllowMerge = (int)sunnyview.Columns[i].OptionsColumn.AllowMerge,
                        });
                    }
                }
            }
            gridControl1.DataSource = new BindingList<ColumnTable>(collist);
        }
        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collist.Clear();
            for (int i = 0; i < grid.Columns.Count; i++)
            {            
                collist.Add(new ColumnTable()
                {
                    ColumnText = grid.Columns[i].Caption,
                    DataProperty = grid.Columns[i].FieldName,
                    ColumnName = grid.Columns[i].Name,
                    FormName = formname,
                    GridName = grid.Name,
                    Visible = grid.Columns[i].Visible,
                    VisibleID = grid.Columns[i].VisibleIndex,
                    Width = grid.Columns[i].Width,
                    Edit = grid.Columns[i].OptionsColumn.AllowEdit,
                    UserID=User.user.YHBH ,
                    Summary = grid.Columns[i].SummaryItem .SummaryType == DevExpress.Data.SummaryItemType.Sum  ? true : false
                }); 
            }
        
            gridControl1.RefreshDataSource() ;
        }

        private void 全部不能编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var c in collist )
            {
                c.Edit = false;
            }
            gridControl1.RefreshDataSource();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var c in collist)
            {
                c.Summary  = false;
            }
            gridControl1.RefreshDataSource();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void ShowColumns()
        {
           
            string gridname = string.Empty;
            if(grid==null )
            {
                gridname = sunnyview.Name;
            }
            else
            {
                gridname = grid.Name;
            }
            if (uiCheckBox1 .Checked==true  )
            {
                if (dt== null)
                {
                    if (Obj != null)
                    {
                        foreach (var p in Obj.GetType().GetProperties())
                        {
                            var h = collist.Where(x => x.DataProperty == p.Name).ToList();
                            if (h.Count == 0)
                            {
                                collist.Add(new ColumnTable()
                                {
                                    ColumnText = p.Name,
                                    DataProperty = p.Name,
                                    ColumnName = p.Name,
                                    FormName = formname,
                                    GridName = gridname ,
                                    Visible = false,
                                    VisibleID = -1,
                                    Width = 50,
                                    Edit = false,
                                    UserID = User.user.YHBH,
                                    Summary = false
                                });
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataColumn  p in dt.Columns )
                    {
                        var h = collist.Where(x => x.DataProperty == p.ColumnName).ToList();
                        if (h.Count == 0)
                        {
                            collist.Add(new ColumnTable()
                            {
                                ColumnText = p.ColumnName,
                                DataProperty = p.ColumnName,
                                ColumnName = p.ColumnName,
                                FormName = formname,
                                GridName = grid.Name,
                                Visible = false,
                                VisibleID = -1,
                                Width = 50,
                                Edit = false,
                                UserID = User.user.YHBH,
                                Summary = false
                            });
                        }
                    }
                }
                gridControl1.RefreshDataSource();
            }
        }

        private void 调用窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请选择你要调用的用户的编号");
                return;
            }
            if (grid != null)
            {
                collist = Connect.GetColumntable(调用窗体ToolStripMenuItem.Text,cmbGridName.Text , cmbUser.Text);
            }
            else
            {
                collist = Connect.GetColumntable(调用窗体ToolStripMenuItem.Text, cmbGridName.Text, cmbUser.Text);
            }
            if (collist.Count == 0)
            {
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    collist.Add(new ColumnTable()
                    {
                        ColumnText = grid.Columns[i].Caption,
                        DataProperty = grid.Columns[i].FieldName,
                        ColumnName = grid.Columns[i].Name,
                        FormName = formname,
                        GridName = grid.Name,
                        Visible = grid.Columns[i].Visible,
                        VisibleID = grid.Columns[i].VisibleIndex,
                        Width = grid.Columns[i].Width,
                        Edit = grid.Columns[i].OptionsColumn.AllowEdit,
                        Summary = grid.Columns[i].SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum,
                        UserID = User.user.YHBH
                    });
                }
            }
            else
            {
                foreach (var c in collist )
                {
                    c.FormName = formname;
                }
            }
            gridControl1.DataSource = new BindingList<ColumnTable>(collist);
        }

        private void 全部不合并ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var c in collist )
            {
                c.AllowMerge = 1;
            }
            gridControl1.RefreshDataSource();
        }

        private void 显示绑定数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColumn8.Visible = true;
        }

        private void 过滤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collist = collist.Where((x, i) => collist .FindIndex(z => z.ColumnName  == x.ColumnName ) == i).ToList ();
            gridControl1.RefreshDataSource();
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            ShowColumns();
        }

        private void 调用窗体ToolStripMenuItem_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbGridName.DataSource = Connect.GetGridName(调用窗体ToolStripMenuItem.Text);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            collist = collist.Where(x => x.Visible == true).ToList();
            gridControl1.DataSource = collist;
            gridControl1.RefreshDataSource();
        }
    }
}
