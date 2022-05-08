using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.设置窗体
{
   public static  class CreateGrid
    {
        /// <summary>
        /// 创建Sunny.UI.Datagridview
        /// </summary>
        /// <param name="formname"></param>
        /// <param name="gridview"></param>
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        public static void CreateDatagridview(string formname,Sunny.UI.UIDataGridView gridview)
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        {
            gridview.AutoGenerateColumns = false;
            gridview.Columns.Clear();
            var cols = Connect.GetColumntable(formname, gridview.Name, User.user.YHBH).OrderBy (x=>x.VisibleID ).ToList ();
            foreach (var col in cols.Where (x=>x.Visible ==true ).OrderBy (x=>x.VisibleID ).ToList () )
            {
                gridview.Columns.Add(new DataGridViewTextBoxColumn() { Name =col.ColumnName,Width =col.Width,Visible=col.Visible ,ReadOnly=col.Edit ,HeaderText =col.ColumnText ,DataPropertyName =string.IsNullOrWhiteSpace (col.DataProperty)?"":col.DataProperty});
            }
        }
        public static void Create(string formname,GridView  gridView  )
        { 
            gridView.OptionsView.AllowCellMerge = false ;
            gridView.Columns.Clear();
            gridView.OptionsClipboard.CopyColumnHeaders =DevExpress.Utils.DefaultBoolean.False ;
            gridView.OptionsClipboard.PasteMode  = DevExpress.Export.PasteMode.Update ;
            //var c = Connect.GetColumntable(formname, gridView.Name, User.user.YHBH);
            var t = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ();
            t.PasswordChar = '*';            
            foreach (ColumnTable columnTable in Connect.GetColumntable(formname , gridView.Name,User.user.YHBH ))
            {
                var col = new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Name = columnTable.ColumnName,
                    Caption = columnTable.ColumnText,
                    FieldName = columnTable.DataProperty,
                    Width = columnTable.Width,
                    VisibleIndex = columnTable.VisibleID,
                };
                col.OptionsColumn.AllowMerge =(DevExpress.Utils.DefaultBoolean)columnTable.AllowMerge  ;
                gridView.Columns.Add(col) ;
                gridView.Columns[columnTable.DataProperty ].Visible = columnTable.Visible;        
                gridView.Columns[columnTable.DataProperty].OptionsColumn.AllowEdit  = columnTable.Edit;
                if (columnTable.Summary)
                {
                    if (columnTable.ColumnText.Contains("价") || columnTable.ColumnText.Contains("含税") || columnTable.ColumnText.Contains("金额"))
                    {
                        gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatString = "C2";                     
                    }
                    else
                    {
                        gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatString = $"F{QueryTime.Digit}";
                        gridView.Columns[columnTable.DataProperty].SummaryItem.DisplayFormat = "{0:0.##}";
                    }
                    gridView.Columns[columnTable.DataProperty].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView.Columns[columnTable.DataProperty].SummaryItem.FieldName = columnTable.DataProperty;
                   gridView.Columns[columnTable.DataProperty].SummaryItem.DisplayFormat   = "{0:0.##}";
                    gridView.OptionsView.ShowFooter = true;
                }
                var a = GetAccess.AccessList.Where(x => x.AccessName == (formname + "价格可见")).ToList();
                if (a.Count > 0)
                {
                    if (a[0].Access == false) 
                    {
                        if (columnTable.DataProperty .Contains("danjia") || columnTable.DataProperty.Contains("heji") || columnTable.DataProperty.Contains("money")|| columnTable.DataProperty.Contains("Heji")
                            || columnTable.DataProperty.Contains("JG")||columnTable.DataProperty.Contains ("Price") )
                        {
                            gridView.Columns[columnTable.DataProperty].ColumnEdit = t;
                            gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom ;
                            gridView.Columns[columnTable.DataProperty].DisplayFormat.FormatString = "*";
                            if (columnTable.Summary)
                            {
                                gridView.Columns[columnTable.DataProperty].SummaryItem.DisplayFormat = "******";
                            }
                        }
                    }
                }
                else
                {
                    BLL.AccessBLL.CheckAccess(formname + "价格可见");
                }
            }
            gridView.IndicatorWidth = 45;
            gridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            gridView.CustomColumnDisplayText += CustomColumnDisplayText;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.Appearance.EvenRow.BackColor = System.Drawing.ColorTranslator.FromHtml( Connect.GetColumnSetting().EvenColor);
            gridView.Appearance.OddRow .BackColor = System.Drawing.ColorTranslator.FromHtml(Connect.GetColumnSetting().OddColor );
            gridView.OptionsCustomization.AllowSort  = false;
        }
        public  static void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        public static void Query(GridControl gridControl,string sql)
        {
            gridControl.DataSource = SQLHelper.SQLHelper.Chaxun(sql);
            gridControl.RefreshDataSource();
        }
        public static void Query<T>(GridControl gridControl ,List<T> list)
        {
            if (list != null)
            {
                gridControl.DataSource = new BindingList<T>(list);
            }
        }
        /// <summary>
        /// 重载Sunny.Uidatagridview
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridControl"></param>
        /// <param name="list"></param>
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        public static void Query<T>(Sunny.UI.UIDataGridView  gridControl, List<T> list)
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        {
            if (list != null)
            {
                gridControl.DataSource = new BindingList<T>(list);
            }
        }
        public static void Query<T>(GridControl gridControl, BindingList<T> list)
        {
            gridControl.DataSource = list;
        }
        public static void  CreateKuweiCmb(GridView gridView,string stockname )
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox Kuweicmb = new RepositoryItemComboBox();
           var dblist = ZhijiaTableService.GetZhijiaTablelst(x => x.StockName == stockname );
            foreach(var zhijia in dblist )
            {
                Kuweicmb.Items.Add(zhijia.Zhijiahao);
            }
            gridView.Columns["Kuwei"].ColumnEdit = Kuweicmb;
        }
        public static void ClearKuwei(GridView gridView )
        {
            gridView.Columns["Kuwei"].ColumnEdit = null;
        }
        /// <summary>
        /// 保存当前的表格样式
        /// </summary>
        /// <param name="formname">窗体名称</param>
        /// <param name="grid">gridview</param>
        public static void SaveGridview(string formname, GridView grid)
        {
            if (grid != null)
            {
                List<ColumnTable> collist = new List<ColumnTable>();
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
                        UserID = User.user.YHBH,
                        Summary = grid.Columns[i].SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum ? true : false
                    });
                }
                Connect.DeleteColumnTable(formname, grid.Name, User.user.YHBH);
                Connect.SaveColumnTable(collist);
            }
         }
        public static void SaveGridview(string formname, Sunny.UI.UIDataGridView  grid)
        {
            List<ColumnTable> collist = new List<ColumnTable>();
            collist.Clear();
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                collist.Add(new ColumnTable()
                {
                    ColumnText = grid.Columns[i].HeaderText ,
                    DataProperty = grid.Columns[i].DataPropertyName ,
                    ColumnName = grid.Columns[i].Name,
                    FormName = formname,
                    GridName = grid.Name,
                    Visible = grid.Columns[i].Visible,
                    VisibleID = grid.Columns[i].Index ,
                    Width = grid.Columns[i].Width,
                    Edit = grid.Columns[i].ReadOnly ,
                    UserID = User.user.YHBH,
                    //Summary = grid.Columns[i].SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum ? true : false
                });
            }
            Connect.DeleteColumnTable(formname, grid.Name, User.user.YHBH); 
            Connect.SaveColumnTable(collist);
        }
        public  static  void CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (Convert.ToString(e.Value) == "0")
                e.DisplayText = string.Empty;
        }
    }
}
