
namespace 纺织贸易管理系统.报表窗体
{
    partial class 进出记录
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cmbcunfang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.txtckmc = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出到EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtganghao = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.录入明细ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Refresh_32x32;
            this.刷新ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 录入明细ToolStripMenuItem
            // 
            this.录入明细ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.录入明细ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.录入明细ToolStripMenuItem.Name = "录入明细ToolStripMenuItem";
            this.录入明细ToolStripMenuItem.Size = new System.Drawing.Size(124, 36);
            this.录入明细ToolStripMenuItem.Text = "导出到EXCEL";
            this.录入明细ToolStripMenuItem.Click += new System.EventHandler(this.导出到EXCELToolStripMenuItem_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtganghao);
            this.uiGroupBox1.Controls.Add(this.labelX3);
            this.uiGroupBox1.Controls.Add(this.cmbcunfang);
            this.uiGroupBox1.Controls.Add(this.txtckmc);
            this.uiGroupBox1.Controls.Add(this.labelX8);
            this.uiGroupBox1.Controls.Add(this.labelX7);
            this.uiGroupBox1.Controls.Add(this.dateEdit2);
            this.uiGroupBox1.Controls.Add(this.labelX2);
            this.uiGroupBox1.Controls.Add(this.dateEdit1);
            this.uiGroupBox1.Controls.Add(this.labelX1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 40);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1110, 74);
            this.uiGroupBox1.TabIndex = 3;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmbcunfang
            // 
            this.cmbcunfang.DisplayMember = "Text";
            this.cmbcunfang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbcunfang.ForeColor = System.Drawing.Color.Black;
            this.cmbcunfang.FormattingEnabled = true;
            this.cmbcunfang.ItemHeight = 18;
            this.cmbcunfang.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbcunfang.Location = new System.Drawing.Point(463, 33);
            this.cmbcunfang.Name = "cmbcunfang";
            this.cmbcunfang.Size = new System.Drawing.Size(156, 24);
            this.cmbcunfang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbcunfang.TabIndex = 42;
            this.cmbcunfang.Text = "加工厂";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "仓库";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "加工厂";
            // 
            // txtckmc
            // 
            this.txtckmc.Location = new System.Drawing.Point(699, 34);
            this.txtckmc.Name = "txtckmc";
            this.txtckmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtckmc.Size = new System.Drawing.Size(147, 20);
            this.txtckmc.TabIndex = 40;
            this.txtckmc.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtckmc_ButtonClick);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(630, 33);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 23);
            this.labelX8.TabIndex = 41;
            this.labelX8.Text = "存放地址";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(394, 33);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(72, 23);
            this.labelX7.TabIndex = 39;
            this.labelX7.Text = "存放位置";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(265, 35);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(121, 20);
            this.dateEdit2.TabIndex = 22;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(204, 34);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(55, 23);
            this.labelX2.TabIndex = 21;
            this.labelX2.Text = "日期到：";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(76, 35);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 20;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(55, 23);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "日期从：";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1110, 471);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出到EXCELToolStripMenuItem,
            this.配置列ToolStripMenuItem,
            this.刷新ToolStripMenuItem1,
            this.保存样式ToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            // 
            // 导出到EXCELToolStripMenuItem
            // 
            this.导出到EXCELToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出到EXCELToolStripMenuItem.Name = "导出到EXCELToolStripMenuItem";
            this.导出到EXCELToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出到EXCELToolStripMenuItem.Text = "导出到EXCEL";
            this.导出到EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出到EXCELToolStripMenuItem_Click);
            // 
            // 配置列ToolStripMenuItem
            // 
            this.配置列ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.reading_32x32;
            this.配置列ToolStripMenuItem.Name = "配置列ToolStripMenuItem";
            this.配置列ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.配置列ToolStripMenuItem.Text = "配置列";
            this.配置列ToolStripMenuItem.Click += new System.EventHandler(this.配置列ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Image = global::纺织贸易管理系统.Properties.Resources.Refresh_32x32;
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
            // 
            // 保存样式ToolStripMenuItem
            // 
            this.保存样式ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存样式ToolStripMenuItem.Name = "保存样式ToolStripMenuItem";
            this.保存样式ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存样式ToolStripMenuItem.Text = "保存样式";
            this.保存样式ToolStripMenuItem.Click += new System.EventHandler(this.保存样式ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Copy_32x32;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(852, 34);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(55, 23);
            this.labelX3.TabIndex = 43;
            this.labelX3.Text = "缸号：";
            // 
            // txtganghao
            // 
            this.txtganghao.Location = new System.Drawing.Point(913, 34);
            this.txtganghao.Name = "txtganghao";
            this.txtganghao.Size = new System.Drawing.Size(100, 23);
            this.txtganghao.TabIndex = 44;
            this.txtganghao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtganghao_KeyDown);
            // 
            // 进出记录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 585);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "进出记录";
            this.Text = "进出记录";
            this.Load += new System.EventHandler(this.进出记录_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入明细ToolStripMenuItem;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbcunfang;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevExpress.XtraEditors.ButtonEdit txtckmc;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出到EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtganghao;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}