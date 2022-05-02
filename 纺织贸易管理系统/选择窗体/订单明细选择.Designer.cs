namespace 纺织贸易管理系统.选择窗体
{
    partial class 订单明细选择
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(订单明细选择));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.txtBianhao = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtyanse = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtpingming = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtOrderNum = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 95);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(915, 364);
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiSymbolButton2);
            this.uiGroupBox1.Controls.Add(this.txtBianhao);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.uiSymbolButton1);
            this.uiGroupBox1.Controls.Add(this.checkBox1);
            this.uiGroupBox1.Controls.Add(this.txtyanse);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.txtpingming);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.txtOrderNum);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 31);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(915, 64);
            this.uiGroupBox1.TabIndex = 9;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiSymbolButton2.Location = new System.Drawing.Point(754, 29);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Size = new System.Drawing.Size(76, 28);
            this.uiSymbolButton2.Symbol = 61442;
            this.uiSymbolButton2.TabIndex = 11;
            this.uiSymbolButton2.Text = "查询";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // txtBianhao
            // 
            this.txtBianhao.ButtonSymbol = 61761;
            this.txtBianhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBianhao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtBianhao.Location = new System.Drawing.Point(545, 29);
            this.txtBianhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBianhao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.ShowText = false;
            this.txtBianhao.Size = new System.Drawing.Size(114, 28);
            this.txtBianhao.Symbol = 61442;
            this.txtBianhao.TabIndex = 9;
            this.txtBianhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBianhao.Watermark = "";
            this.txtBianhao.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtBianhao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNum_KeyDown);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.Location = new System.Drawing.Point(510, 31);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(56, 23);
            this.uiLabel4.TabIndex = 10;
            this.uiLabel4.Text = "编号";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiSymbolButton1.Location = new System.Drawing.Point(836, 29);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(76, 28);
            this.uiSymbolButton1.TabIndex = 8;
            this.uiSymbolButton1.Text = "确定";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(666, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "显示已结束";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtyanse
            // 
            this.txtyanse.ButtonSymbol = 61761;
            this.txtyanse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtyanse.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtyanse.Location = new System.Drawing.Point(389, 29);
            this.txtyanse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtyanse.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtyanse.Name = "txtyanse";
            this.txtyanse.ShowText = false;
            this.txtyanse.Size = new System.Drawing.Size(114, 28);
            this.txtyanse.Symbol = 61442;
            this.txtyanse.TabIndex = 5;
            this.txtyanse.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtyanse.Watermark = "";
            this.txtyanse.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtyanse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNum_KeyDown);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(352, 31);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(56, 23);
            this.uiLabel3.TabIndex = 6;
            this.uiLabel3.Text = "颜色";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtpingming
            // 
            this.txtpingming.ButtonSymbol = 61761;
            this.txtpingming.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpingming.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtpingming.Location = new System.Drawing.Point(231, 29);
            this.txtpingming.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpingming.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.ShowText = false;
            this.txtpingming.Size = new System.Drawing.Size(114, 28);
            this.txtpingming.Symbol = 61442;
            this.txtpingming.TabIndex = 3;
            this.txtpingming.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtpingming.Watermark = "";
            this.txtpingming.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtpingming.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNum_KeyDown);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(199, 31);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(56, 23);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "品名";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(11, 29);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(56, 23);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "订单号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.ButtonSymbol = 61761;
            this.txtOrderNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOrderNum.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtOrderNum.Location = new System.Drawing.Point(74, 29);
            this.txtOrderNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOrderNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.ShowText = false;
            this.txtOrderNum.Size = new System.Drawing.Size(114, 28);
            this.txtOrderNum.Symbol = 61442;
            this.txtOrderNum.TabIndex = 1;
            this.txtOrderNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOrderNum.Watermark = "";
            this.txtOrderNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtOrderNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNum_KeyDown);
            // 
            // 订单明细选择
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(915, 459);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1344, 842);
            this.MinimizeBox = false;
            this.Name = "订单明细选择";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.Text = "品种选择";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleHeight = 31;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 915, 459);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.品种选择_FormClosed);
            this.Load += new System.EventHandler(this.品种选择_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtOrderNum;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Sunny.UI.UITextBox txtyanse;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtpingming;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UITextBox txtBianhao;
        private Sunny.UI.UILabel uiLabel4;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
    }
}