namespace 纺织贸易管理系统.新增窗体
{
    partial class 盘盈入库单
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtLiuzhuanka = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbcunfang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.txtckmc = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtbeizhu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cmddanwei = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colorbtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnRangchang = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRangchang)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1115, 40);
            this.menuStrip1.TabIndex = 2;
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtLiuzhuanka);
            this.groupControl1.Controls.Add(this.labelX17);
            this.groupControl1.Controls.Add(this.labelX2);
            this.groupControl1.Controls.Add(this.cmbcunfang);
            this.groupControl1.Controls.Add(this.txtckmc);
            this.groupControl1.Controls.Add(this.labelX8);
            this.groupControl1.Controls.Add(this.labelX7);
            this.groupControl1.Controls.Add(this.txtbeizhu);
            this.groupControl1.Controls.Add(this.labelX4);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.txtdanhao);
            this.groupControl1.Controls.Add(this.labelX1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1115, 119);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "单据信息";
            // 
            // txtLiuzhuanka
            // 
            this.txtLiuzhuanka.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLiuzhuanka.Border.Class = "TextBoxBorder";
            this.txtLiuzhuanka.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLiuzhuanka.DisabledBackColor = System.Drawing.Color.White;
            this.txtLiuzhuanka.ForeColor = System.Drawing.Color.Black;
            this.txtLiuzhuanka.Location = new System.Drawing.Point(762, 81);
            this.txtLiuzhuanka.Name = "txtLiuzhuanka";
            this.txtLiuzhuanka.PreventEnterBeep = true;
            this.txtLiuzhuanka.Size = new System.Drawing.Size(147, 22);
            this.txtLiuzhuanka.TabIndex = 58;
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(702, 81);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(63, 23);
            this.labelX17.TabIndex = 57;
            this.labelX17.Text = "流转卡号";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(703, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(53, 23);
            this.labelX2.TabIndex = 39;
            this.labelX2.Text = "日期";
            // 
            // cmbcunfang
            // 
            this.cmbcunfang.DisplayMember = "Text";
            this.cmbcunfang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbcunfang.ForeColor = System.Drawing.Color.Black;
            this.cmbcunfang.FormattingEnabled = true;
            this.cmbcunfang.ItemHeight = 17;
            this.cmbcunfang.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbcunfang.Location = new System.Drawing.Point(313, 38);
            this.cmbcunfang.Name = "cmbcunfang";
            this.cmbcunfang.Size = new System.Drawing.Size(156, 23);
            this.cmbcunfang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbcunfang.TabIndex = 38;
            this.cmbcunfang.Text = "加工厂";
            this.cmbcunfang.SelectedIndexChanged += new System.EventHandler(this.cmbcunfang_SelectedIndexChanged);
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
            this.txtckmc.Location = new System.Drawing.Point(549, 39);
            this.txtckmc.Name = "txtckmc";
            this.txtckmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtckmc.Properties.ReadOnly = true;
            this.txtckmc.Size = new System.Drawing.Size(147, 20);
            this.txtckmc.TabIndex = 32;
            this.txtckmc.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtckmc_ButtonClick);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(480, 38);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 23);
            this.labelX8.TabIndex = 33;
            this.labelX8.Text = "存放地址";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(244, 38);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(72, 23);
            this.labelX7.TabIndex = 28;
            this.labelX7.Text = "存放位置";
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
            this.txtbeizhu.Location = new System.Drawing.Point(80, 81);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.PreventEnterBeep = true;
            this.txtbeizhu.Size = new System.Drawing.Size(616, 22);
            this.txtbeizhu.TabIndex = 27;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(14, 81);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 23);
            this.labelX4.TabIndex = 26;
            this.labelX4.Text = "备注";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2020, 7, 31, 16, 33, 18, 0);
            this.dateEdit1.Location = new System.Drawing.Point(762, 39);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(147, 20);
            this.dateEdit1.TabIndex = 23;
            this.dateEdit1.DateTimeChanged += new System.EventHandler(this.dateEdit1_DateTimeChanged);
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
            this.txtdanhao.Location = new System.Drawing.Point(80, 38);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.PreventEnterBeep = true;
            this.txtdanhao.ReadOnly = true;
            this.txtdanhao.Size = new System.Drawing.Size(156, 22);
            this.txtdanhao.TabIndex = 21;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 38);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "单号";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 159);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.ButtonEdit2,
            this.cmddanwei,
            this.colorbtn,
            this.btnRangchang});
            this.gridControl1.Size = new System.Drawing.Size(1115, 291);
            this.gridControl1.TabIndex = 10;
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
            this.保存样式ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 136);
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
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // ButtonEdit2
            // 
            this.ButtonEdit2.AutoHeight = false;
            this.ButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEdit2.Name = "ButtonEdit2";
            this.ButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEdit2_ButtonClick);
            // 
            // cmddanwei
            // 
            this.cmddanwei.AutoHeight = false;
            this.cmddanwei.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmddanwei.Items.AddRange(new object[] {
            "米",
            "码",
            "公斤数"});
            this.cmddanwei.Name = "cmddanwei";
            this.cmddanwei.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colorbtn
            // 
            this.colorbtn.AutoHeight = false;
            this.colorbtn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.colorbtn.Name = "colorbtn";
            this.colorbtn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.colorbtn_ButtonClick);
            this.colorbtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colorbtn_KeyDown);
            // 
            // btnRangchang
            // 
            this.btnRangchang.AutoHeight = false;
            this.btnRangchang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnRangchang.Name = "btnRangchang";
            this.btnRangchang.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRangchang_ButtonClick);
            // 
            // 盘盈入库单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "盘盈入库单";
            this.Text = "盘盈入库单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.盘盈入库单_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRangchang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbcunfang;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevExpress.XtraEditors.ButtonEdit txtckmc;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbeizhu;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdanhao;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmddanwei;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit colorbtn;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRangchang;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLiuzhuanka;
        private DevComponents.DotNetBar.LabelX labelX17;
    }
}