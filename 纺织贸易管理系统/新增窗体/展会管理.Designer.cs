namespace 纺织贸易管理系统.新增窗体
{
    partial class 展会管理
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
            this.导出列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtweizhi = new Sunny.UI.UITextBox();
            this.txtName = new Sunny.UI.UITextBox();
            this.txtAddress = new Sunny.UI.UITextBox();
            this.txtdanhao = new Sunny.UI.UITextBox();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cmddanwei = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colorbtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnRangchang = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
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
            this.保存ToolStripMenuItem,
            this.导出列表ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1207, 40);
            this.menuStrip1.TabIndex = 3;
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
            // 导出列表ToolStripMenuItem
            // 
            this.导出列表ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出列表ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.导出列表ToolStripMenuItem.Name = "导出列表ToolStripMenuItem";
            this.导出列表ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.导出列表ToolStripMenuItem.Text = "导出列表";
            this.导出列表ToolStripMenuItem.Click += new System.EventHandler(this.导出列表ToolStripMenuItem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtweizhi);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.txtAddress);
            this.groupControl1.Controls.Add(this.txtdanhao);
            this.groupControl1.Controls.Add(this.uiDatePicker1);
            this.groupControl1.Controls.Add(this.labelX6);
            this.groupControl1.Controls.Add(this.labelX5);
            this.groupControl1.Controls.Add(this.labelX4);
            this.groupControl1.Controls.Add(this.labelX3);
            this.groupControl1.Controls.Add(this.labelX2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1207, 125);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "展会信息";
            // 
            // txtweizhi
            // 
            this.txtweizhi.ButtonSymbol = 61761;
            this.txtweizhi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtweizhi.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtweizhi.Location = new System.Drawing.Point(618, 77);
            this.txtweizhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtweizhi.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtweizhi.Name = "txtweizhi";
            this.txtweizhi.Padding = new System.Windows.Forms.Padding(5);
            this.txtweizhi.ShowText = false;
            this.txtweizhi.Size = new System.Drawing.Size(138, 23);
            this.txtweizhi.TabIndex = 17;
            this.txtweizhi.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtweizhi.Watermark = "";
            this.txtweizhi.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtName
            // 
            this.txtName.ButtonSymbol = 61761;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtName.Location = new System.Drawing.Point(269, 77);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(261, 23);
            this.txtName.TabIndex = 16;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "";
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAddress
            // 
            this.txtAddress.ButtonSymbol = 61761;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtAddress.Location = new System.Drawing.Point(269, 38);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(5);
            this.txtAddress.ShowText = false;
            this.txtAddress.Size = new System.Drawing.Size(261, 23);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAddress.Watermark = "";
            this.txtAddress.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtdanhao
            // 
            this.txtdanhao.ButtonSymbol = 61761;
            this.txtdanhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdanhao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtdanhao.Location = new System.Drawing.Point(55, 38);
            this.txtdanhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdanhao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.Padding = new System.Windows.Forms.Padding(5);
            this.txtdanhao.ReadOnly = true;
            this.txtdanhao.ShowText = false;
            this.txtdanhao.Size = new System.Drawing.Size(125, 23);
            this.txtdanhao.TabIndex = 14;
            this.txtdanhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdanhao.Watermark = "";
            this.txtdanhao.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiDatePicker1.Location = new System.Drawing.Point(618, 38);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(138, 23);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 13;
            this.uiDatePicker1.Text = "2021-06-29";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2021, 6, 29, 19, 55, 7, 0);
            this.uiDatePicker1.Watermark = "";
            this.uiDatePicker1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(537, 77);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "展位：";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(187, 77);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "展会名称：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(537, 38);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "展会日期：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(187, 38);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "展会地点：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(10, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "单号：";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 165);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1207, 285);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "出展品种";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.ButtonEdit2,
            this.cmddanwei,
            this.colorbtn,
            this.btnRangchang});
            this.gridControl1.Size = new System.Drawing.Size(1203, 260);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
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
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // 
            // btnRangchang
            // 
            this.btnRangchang.AutoHeight = false;
            this.btnRangchang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnRangchang.Name = "btnRangchang";
            // 
            // 展会管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 450);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "展会管理";
            this.Text = "展会管理";
            this.Load += new System.EventHandler(this.展会管理_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatePicker uiDatePicker1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmddanwei;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit colorbtn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRangchang;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtweizhi;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtName;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtAddress;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtdanhao;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.ToolStripMenuItem 导出列表ToolStripMenuItem;
    }
}