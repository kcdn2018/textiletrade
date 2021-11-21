using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.自定义类
{
      public  class ContexMenuEX
    {
        public ToolStripMenuItem 删除行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public ToolStripMenuItem 添加行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public ToolStripMenuItem 复制行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public ToolStripMenuItem 粘贴行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public ToolStripMenuItem 配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public ToolStripMenuItem 保存样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public DevExpress .XtraGrid.GridControl gridControl { get; set; }
        public DevExpress.XtraGrid.Views.Grid.GridView gridView { get; set; }
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        public Sunny.UI.UIDataGridView dataGridView { get; set; }
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        public string formName { get; set; }
        public int  rowindex { get; set; }
        public object obj { get; set; }
        public ContextMenuStrip menuStrip { get; set; } = new ContextMenuStrip();
        public ContexMenuEX()
        {
           
        }
        public void Init()
        {
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除行ToolStripMenuItem,
            this.添加行ToolStripMenuItem,
            this.复制行ToolStripMenuItem,
            this.粘贴行ToolStripMenuItem,
            this.配置列ToolStripMenuItem,
            this.保存样式ToolStripMenuItem});
            menuStrip.Size = new System.Drawing.Size(125, 136);
            // 
            // 删除行ToolStripMenuItem
            // 
            this.删除行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.DeleteList_32x32;
            this.删除行ToolStripMenuItem.Name = "删除行ToolStripMenuItem";
            this.删除行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除行ToolStripMenuItem.Text = "删除行";
            this.删除行ToolStripMenuItem.Click += new System.EventHandler(this.删除行ToolStripMenuItem_Click);
            // 
            // 添加行ToolStripMenuItem
            // 
            this.添加行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Add_32x32;
            this.添加行ToolStripMenuItem.Name = "添加行ToolStripMenuItem";
            this.添加行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加行ToolStripMenuItem.Text = "添加行";
            this.添加行ToolStripMenuItem.Click += new System.EventHandler(this.添加行ToolStripMenuItem_Click);
            // 
            // 复制行ToolStripMenuItem
            // 
            this.复制行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Copy_32x32;
            this.复制行ToolStripMenuItem.Name = "复制行ToolStripMenuItem";
            this.复制行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制行ToolStripMenuItem.Text = "复制行";
            this.复制行ToolStripMenuItem.Click += new System.EventHandler(this.复制行ToolStripMenuItem_Click);
            // 
            // 粘贴行ToolStripMenuItem
            // 
            this.粘贴行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Paste_32x32;
            this.粘贴行ToolStripMenuItem.Name = "粘贴行ToolStripMenuItem";
            this.粘贴行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.粘贴行ToolStripMenuItem.Text = "粘贴行";
            this.粘贴行ToolStripMenuItem.Click += new System.EventHandler(this.粘贴行ToolStripMenuItem_Click);
            // 
            // 配置列ToolStripMenuItem
            // 
            this.配置列ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.reading_32x32;
            this.配置列ToolStripMenuItem.Name = "配置列ToolStripMenuItem";
            this.配置列ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.配置列ToolStripMenuItem.Text = "配置列";
            this.配置列ToolStripMenuItem.Click += new System.EventHandler(this.配置列ToolStripMenuItem_Click);
            // 
            // 保存样式ToolStripMenuItem
            // 
            this.保存样式ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存样式ToolStripMenuItem.Name = "保存样式ToolStripMenuItem";
            this.保存样式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存样式ToolStripMenuItem.Text = "保存样式";
            this.保存样式ToolStripMenuItem.Click += new System.EventHandler(this.保存样式ToolStripMenuItem_Click);
        }
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView.DeleteRow(gridView.FocusedRowHandle);
        }
        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //danjumingxis.Add(new danjumingxitable() { danhao = txtdanhao.Text, rq = uiDatePicker1.Value });
            gridView.AddNewRow();
            gridControl.RefreshDataSource();
        }
        private void 粘贴行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView.Focus();
            gridView.SelectRow(gridView.FocusedRowHandle);
            SendKeys.Send("^v");
        }
        private void 复制行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView.Focus();
            gridView.SelectRow( gridView.FocusedRowHandle);
            SendKeys.Send("^c");
        }
        public  void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl == null)
                {
                    if(obj !=null )
                    {
                        var fm = new 配置列(dataGridView) { formname = formName, Obj  = obj};
                        fm.ShowDialog();
                    }
                    else
                    {
                        var fm = new 配置列(dataGridView) { formname = formName, dt = dataGridView.DataSource as DataTable };
                        fm.ShowDialog();
                    }

                }
                else
                {
                    var fm = new 配置列(gridView) { formname = formName, dt = gridControl.DataSource as DataTable };
                    fm.ShowDialog();
                }
            }
            catch
            {

            }
        }
        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView != null)
            {
                CreateGrid.SaveGridview(formName, this.gridView);
            }
            else
            {
                CreateGrid.SaveGridview(formName , dataGridView);
            }
        }
    }
}
