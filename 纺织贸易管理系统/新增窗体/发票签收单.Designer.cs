namespace 纺织贸易管理系统.新增窗体
{
    partial class 发票签收单
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(发票签收单));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtbeizhu = new Sunny.UI.UITextBox();
            this.txtdanhao = new Sunny.UI.UITextBox();
            this.txtyouhuipiaoe = new Sunny.UI.UITextBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmbleixing = new Sunny.UI.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtkehu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
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
            this.cmbsuilv = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbsuilv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 40);
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
            this.groupControl1.Controls.Add(this.txtbeizhu);
            this.groupControl1.Controls.Add(this.txtdanhao);
            this.groupControl1.Controls.Add(this.txtyouhuipiaoe);
            this.groupControl1.Controls.Add(this.labelX5);
            this.groupControl1.Controls.Add(this.cmbleixing);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.labelX4);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.labelX3);
            this.groupControl1.Controls.Add(this.txtkehu);
            this.groupControl1.Controls.Add(this.labelX2);
            this.groupControl1.Controls.Add(this.labelX1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(803, 152);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "单据信息";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.ButtonSymbol = 61761;
            this.txtbeizhu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbeizhu.FillColor = System.Drawing.Color.White;
            this.txtbeizhu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtbeizhu.Location = new System.Drawing.Point(80, 121);
            this.txtbeizhu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbeizhu.Maximum = 2147483647D;
            this.txtbeizhu.Minimum = -2147483648D;
            this.txtbeizhu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.RectColor = System.Drawing.Color.Silver;
            this.txtbeizhu.Size = new System.Drawing.Size(602, 23);
            this.txtbeizhu.Style = Sunny.UI.UIStyle.Custom;
            this.txtbeizhu.TabIndex = 34;
            this.txtbeizhu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdanhao
            // 
            this.txtdanhao.ButtonSymbol = 61761;
            this.txtdanhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdanhao.FillColor = System.Drawing.Color.White;
            this.txtdanhao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtdanhao.Location = new System.Drawing.Point(80, 37);
            this.txtdanhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdanhao.Maximum = 2147483647D;
            this.txtdanhao.Minimum = -2147483648D;
            this.txtdanhao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.RectColor = System.Drawing.Color.Silver;
            this.txtdanhao.Size = new System.Drawing.Size(156, 23);
            this.txtdanhao.Style = Sunny.UI.UIStyle.Custom;
            this.txtdanhao.TabIndex = 33;
            this.txtdanhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtyouhuipiaoe
            // 
            this.txtyouhuipiaoe.ButtonSymbol = 61761;
            this.txtyouhuipiaoe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtyouhuipiaoe.FillColor = System.Drawing.Color.White;
            this.txtyouhuipiaoe.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtyouhuipiaoe.Location = new System.Drawing.Point(80, 79);
            this.txtyouhuipiaoe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtyouhuipiaoe.Maximum = 2147483647D;
            this.txtyouhuipiaoe.Minimum = -2147483648D;
            this.txtyouhuipiaoe.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtyouhuipiaoe.Name = "txtyouhuipiaoe";
            this.txtyouhuipiaoe.RectColor = System.Drawing.Color.Silver;
            this.txtyouhuipiaoe.Size = new System.Drawing.Size(156, 23);
            this.txtyouhuipiaoe.Style = Sunny.UI.UIStyle.Custom;
            this.txtyouhuipiaoe.TabIndex = 32;
            this.txtyouhuipiaoe.Text = "0.00";
            this.txtyouhuipiaoe.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtyouhuipiaoe.Type = Sunny.UI.UITextBox.UIEditType.Double;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 79);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(62, 23);
            this.labelX5.TabIndex = 31;
            this.labelX5.Text = "优惠票额";
            // 
            // cmbleixing
            // 
            this.cmbleixing.DataSource = null;
            this.cmbleixing.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbleixing.FillColor = System.Drawing.Color.White;
            this.cmbleixing.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmbleixing.Items.AddRange(new object[] {
            "增值税发票",
            "增值税普票"});
            this.cmbleixing.Location = new System.Drawing.Point(317, 79);
            this.cmbleixing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbleixing.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbleixing.Name = "cmbleixing";
            this.cmbleixing.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbleixing.RectColor = System.Drawing.Color.Silver;
            this.cmbleixing.Size = new System.Drawing.Size(146, 23);
            this.cmbleixing.Style = Sunny.UI.UIStyle.Custom;
            this.cmbleixing.TabIndex = 30;
            this.cmbleixing.Text = "增值税发票";
            this.cmbleixing.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "发票类型：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(14, 121);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 23);
            this.labelX4.TabIndex = 26;
            this.labelX4.Text = "备注";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2020, 10, 15, 0, 0, 0, 0);
            this.dateEdit1.Location = new System.Drawing.Point(546, 38);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(136, 20);
            this.dateEdit1.TabIndex = 23;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(477, 37);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 23);
            this.labelX3.TabIndex = 22;
            this.labelX3.Text = "日期";
            // 
            // txtkehu
            // 
            this.txtkehu.Location = new System.Drawing.Point(316, 38);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtkehu.Size = new System.Drawing.Size(147, 20);
            this.txtkehu.TabIndex = 19;
            this.txtkehu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtkehu_ButtonClick);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(247, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 23);
            this.labelX2.TabIndex = 20;
            this.labelX2.Text = "供货商";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 37);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "发票号";
            // 
            // gridControl2
            // 
            this.gridControl2.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 192);
            this.gridControl2.MainView = this.gridView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.ButtonEdit2,
            this.cmddanwei,
            this.cmbsuilv});
            this.gridControl2.Size = new System.Drawing.Size(803, 383);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridView1.GridControl = this.gridControl2;
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
            // 
            // ButtonEdit2
            // 
            this.ButtonEdit2.AutoHeight = false;
            this.ButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEdit2.Name = "ButtonEdit2";
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
            // cmbsuilv
            // 
            this.cmbsuilv.AutoHeight = false;
            this.cmbsuilv.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbsuilv.Items.AddRange(new object[] {
            "13%",
            "12%",
            "11%",
            "10%",
            "9%",
            "8%",
            "7%",
            "6%",
            "5%",
            "4%",
            "3%",
            "2%",
            "1%"});
            this.cmbsuilv.Name = "cmbsuilv";
            // 
            // 发票签收单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 575);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "发票签收单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票签收单";
            this.Load += new System.EventHandler(this.采购入库单_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbsuilv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevExpress.XtraEditors.ButtonEdit txtkehu;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmddanwei;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbsuilv;
        private Sunny.UI.UITextBox txtyouhuipiaoe;
        private DevComponents.DotNetBar.LabelX labelX5;
        private Sunny.UI.UIComboBox cmbleixing;
        private Sunny.UI.UITextBox txtbeizhu;
        private Sunny.UI.UITextBox txtdanhao;
    }
}