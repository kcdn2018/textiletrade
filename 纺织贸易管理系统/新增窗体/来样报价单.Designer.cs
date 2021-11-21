namespace 纺织贸易管理系统.新增窗体
{
    partial class 来样报价单
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
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出为EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtbeizhu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtkehu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtdanhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出到EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cmbbizhong = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbleixing = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbhanshui = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colorbtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cmblianxiren = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbbizhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbleixing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbhanshui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmblianxiren)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.导出为EXCELToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 导出为EXCELToolStripMenuItem
            // 
            this.导出为EXCELToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出为EXCELToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.导出为EXCELToolStripMenuItem.Name = "导出为EXCELToolStripMenuItem";
            this.导出为EXCELToolStripMenuItem.Size = new System.Drawing.Size(124, 36);
            this.导出为EXCELToolStripMenuItem.Text = "导出为EXCEL";
            this.导出为EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出到EXCELToolStripMenuItem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtbeizhu);
            this.groupControl1.Controls.Add(this.labelX4);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.labelX3);
            this.groupControl1.Controls.Add(this.txtkehu);
            this.groupControl1.Controls.Add(this.labelX2);
            this.groupControl1.Controls.Add(this.txtdanhao);
            this.groupControl1.Controls.Add(this.labelX1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(800, 118);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "单据信息";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtbeizhu.Border.Class = "TextBoxBorder";
            this.txtbeizhu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbeizhu.DisabledBackColor = System.Drawing.Color.White;
            this.txtbeizhu.ForeColor = System.Drawing.Color.Black;
            this.txtbeizhu.Location = new System.Drawing.Point(78, 77);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.PreventEnterBeep = true;
            this.txtbeizhu.Size = new System.Drawing.Size(613, 22);
            this.txtbeizhu.TabIndex = 13;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 77);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "备注";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(544, 36);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(147, 20);
            this.dateEdit1.TabIndex = 6;
            this.dateEdit1.DateTimeChanged += new System.EventHandler(this.dateEdit1_DateTimeChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(475, 35);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "日期";
            // 
            // txtkehu
            // 
            this.txtkehu.Location = new System.Drawing.Point(314, 36);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtkehu.Size = new System.Drawing.Size(147, 20);
            this.txtkehu.TabIndex = 1;
            this.txtkehu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit2_ButtonClick);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(245, 35);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "客户名称";
            // 
            // txtdanhao
            // 
            this.txtdanhao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtdanhao.Border.Class = "TextBoxBorder";
            this.txtdanhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdanhao.DisabledBackColor = System.Drawing.Color.White;
            this.txtdanhao.ForeColor = System.Drawing.Color.Black;
            this.txtdanhao.Location = new System.Drawing.Point(78, 35);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.PreventEnterBeep = true;
            this.txtdanhao.ReadOnly = true;
            this.txtdanhao.Size = new System.Drawing.Size(156, 22);
            this.txtdanhao.TabIndex = 3;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "单号";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.cmbbizhong,
            this.cmbleixing,
            this.cmbhanshui,
            this.colorbtn,
            this.cmblianxiren});
            this.gridControl1.Size = new System.Drawing.Size(800, 292);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除行ToolStripMenuItem,
            this.添加行ToolStripMenuItem,
            this.复制行ToolStripMenuItem,
            this.粘贴行ToolStripMenuItem,
            this.配置列ToolStripMenuItem,
            this.保存样式ToolStripMenuItem,
            this.导出到EXCELToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 158);
            // 
            // 删除行ToolStripMenuItem
            // 
            this.删除行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.DeleteList_32x32;
            this.删除行ToolStripMenuItem.Name = "删除行ToolStripMenuItem";
            this.删除行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除行ToolStripMenuItem.Text = "删除行";
            this.删除行ToolStripMenuItem.Click += new System.EventHandler(this.删除行ToolStripMenuItem_Click);
            // 
            // 添加行ToolStripMenuItem
            // 
            this.添加行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Add_32x32;
            this.添加行ToolStripMenuItem.Name = "添加行ToolStripMenuItem";
            this.添加行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加行ToolStripMenuItem.Text = "添加行";
            this.添加行ToolStripMenuItem.Click += new System.EventHandler(this.添加行ToolStripMenuItem_Click);
            // 
            // 复制行ToolStripMenuItem
            // 
            this.复制行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Copy_32x32;
            this.复制行ToolStripMenuItem.Name = "复制行ToolStripMenuItem";
            this.复制行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.复制行ToolStripMenuItem.Text = "复制行";
            this.复制行ToolStripMenuItem.Click += new System.EventHandler(this.复制行ToolStripMenuItem_Click);
            // 
            // 粘贴行ToolStripMenuItem
            // 
            this.粘贴行ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Paste_32x32;
            this.粘贴行ToolStripMenuItem.Name = "粘贴行ToolStripMenuItem";
            this.粘贴行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.粘贴行ToolStripMenuItem.Text = "粘贴行";
            this.粘贴行ToolStripMenuItem.Click += new System.EventHandler(this.粘贴行ToolStripMenuItem_Click);
            // 
            // 配置列ToolStripMenuItem
            // 
            this.配置列ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.reading_32x32;
            this.配置列ToolStripMenuItem.Name = "配置列ToolStripMenuItem";
            this.配置列ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.配置列ToolStripMenuItem.Text = "配置列";
            this.配置列ToolStripMenuItem.Click += new System.EventHandler(this.配置列ToolStripMenuItem_Click);
            // 
            // 保存样式ToolStripMenuItem
            // 
            this.保存样式ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存样式ToolStripMenuItem.Name = "保存样式ToolStripMenuItem";
            this.保存样式ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存样式ToolStripMenuItem.Text = "保存样式";
            this.保存样式ToolStripMenuItem.Click += new System.EventHandler(this.保存样式ToolStripMenuItem_Click);
            // 
            // 导出到EXCELToolStripMenuItem
            // 
            this.导出到EXCELToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出到EXCELToolStripMenuItem.Name = "导出到EXCELToolStripMenuItem";
            this.导出到EXCELToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出到EXCELToolStripMenuItem.Text = "导出到EXCEL";
            this.导出到EXCELToolStripMenuItem.Click += new System.EventHandler(this.导出到EXCELToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // ButtonEdit1
            // 
            this.ButtonEdit1.AutoHeight = false;
            this.ButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEdit1.Name = "ButtonEdit1";
            this.ButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEdit1_ButtonClick);
            // 
            // cmbbizhong
            // 
            this.cmbbizhong.AutoHeight = false;
            this.cmbbizhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbbizhong.Items.AddRange(new object[] {
            "人民币￥",
            "美元$"});
            this.cmbbizhong.Name = "cmbbizhong";
            // 
            // cmbleixing
            // 
            this.cmbleixing.AutoHeight = false;
            this.cmbleixing.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbleixing.Items.AddRange(new object[] {
            "成品样",
            "色样",
            "大货样",
            "小缸样",
            "印花样"});
            this.cmbleixing.Name = "cmbleixing";
            // 
            // cmbhanshui
            // 
            this.cmbhanshui.AutoHeight = false;
            this.cmbhanshui.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbhanshui.Items.AddRange(new object[] {
            "含税",
            "不含税"});
            this.cmbhanshui.Name = "cmbhanshui";
            // 
            // colorbtn
            // 
            this.colorbtn.AutoHeight = false;
            this.colorbtn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.colorbtn.Name = "colorbtn";
            this.colorbtn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.colorbtn_ButtonClick);
            // 
            // cmblianxiren
            // 
            this.cmblianxiren.AutoHeight = false;
            this.cmblianxiren.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmblianxiren.Name = "cmblianxiren";
            // 
            // 来样报价单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "来样报价单";
            this.Text = "来样报价单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.寄样单_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbbizhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbleixing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbhanshui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmblianxiren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbeizhu;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevExpress.XtraEditors.ButtonEdit txtkehu;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdanhao;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbbizhong;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbleixing;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbhanshui;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit colorbtn;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmblianxiren;
        private System.Windows.Forms.ToolStripMenuItem 导出到EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出为EXCELToolStripMenuItem;
    }
}