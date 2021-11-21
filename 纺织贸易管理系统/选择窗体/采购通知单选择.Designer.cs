namespace 纺织贸易管理系统.选择窗体
{
    partial class 采购通知单选择
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(采购通知单选择));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1 = new Sunny.UI.UIGroupBox();
            this.labelX3 = new Sunny.UI.UILabel();
            this.labelX2 = new Sunny.UI.UILabel();
            this.txtguige = new Sunny.UI.UITextBox();
            this.txtpingming = new Sunny.UI.UITextBox();
            this.txtbianhao = new Sunny.UI.UITextBox();
            this.labelX1 = new Sunny.UI.UILabel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.menuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(871, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Apply_32x32;
            this.新增ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.新增ToolStripMenuItem.Text = "确定";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txtguige);
            this.groupPanel1.Controls.Add(this.txtpingming);
            this.groupPanel1.Controls.Add(this.txtbianhao);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupPanel1.Location = new System.Drawing.Point(0, 40);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.groupPanel1.Size = new System.Drawing.Size(871, 66);
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "查询条件";
            this.groupPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelX3.Location = new System.Drawing.Point(324, 26);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "规格：";
            this.labelX3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelX2.Location = new System.Drawing.Point(165, 26);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "品名：";
            this.labelX2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtguige
            // 
            this.txtguige.BackColor = System.Drawing.Color.White;
            this.txtguige.ButtonSymbol = 61761;
            this.txtguige.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtguige.FillColor = System.Drawing.Color.White;
            this.txtguige.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtguige.Location = new System.Drawing.Point(377, 26);
            this.txtguige.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtguige.Maximum = 2147483647D;
            this.txtguige.Minimum = -2147483648D;
            this.txtguige.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtguige.Name = "txtguige";
            this.txtguige.Size = new System.Drawing.Size(100, 23);
            this.txtguige.TabIndex = 3;
            this.txtguige.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtguige.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbianhao_KeyDown);
            // 
            // txtpingming
            // 
            this.txtpingming.BackColor = System.Drawing.Color.White;
            this.txtpingming.ButtonSymbol = 61761;
            this.txtpingming.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpingming.FillColor = System.Drawing.Color.White;
            this.txtpingming.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtpingming.Location = new System.Drawing.Point(218, 26);
            this.txtpingming.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpingming.Maximum = 2147483647D;
            this.txtpingming.Minimum = -2147483648D;
            this.txtpingming.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.Size = new System.Drawing.Size(100, 23);
            this.txtpingming.TabIndex = 2;
            this.txtpingming.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtpingming.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbianhao_KeyDown);
            // 
            // txtbianhao
            // 
            this.txtbianhao.BackColor = System.Drawing.Color.White;
            this.txtbianhao.ButtonSymbol = 61761;
            this.txtbianhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbianhao.FillColor = System.Drawing.Color.White;
            this.txtbianhao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtbianhao.Location = new System.Drawing.Point(59, 26);
            this.txtbianhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbianhao.Maximum = 2147483647D;
            this.txtbianhao.Minimum = -2147483648D;
            this.txtbianhao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtbianhao.Name = "txtbianhao";
            this.txtbianhao.Size = new System.Drawing.Size(100, 23);
            this.txtbianhao.TabIndex = 1;
            this.txtbianhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbianhao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbianhao_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelX1.Location = new System.Drawing.Point(6, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "编号：";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(871, 422);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置列ToolStripMenuItem,
            this.保存样式ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
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
            this.gridView1.DetailHeight = 283;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 采购通知单选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 528);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1344, 842);
            this.MinimizeBox = false;
            this.Name = "采购通知单选择";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采购通知单选择";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.品种选择_FormClosed);
            this.Load += new System.EventHandler(this.品种选择_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private Sunny.UI.UIGroupBox  groupPanel1;
        private Sunny.UI.UILabel labelX3;
        private Sunny.UI.UILabel labelX2;
        private Sunny.UI.UITextBox txtguige;
        private Sunny.UI.UITextBox txtpingming;
        private Sunny.UI.UITextBox txtbianhao;
        private Sunny.UI.UILabel labelX1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
    }
}