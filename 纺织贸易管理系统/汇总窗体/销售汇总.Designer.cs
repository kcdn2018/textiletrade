
namespace 纺织贸易管理系统.其他窗体
{
    partial class 销售汇总
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new Sunny.UI.UIDataGridView();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtshouru = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.txtzhichu = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.txtjiagong = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.txtyouhui = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txtcaigou = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txtstock = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtlilun = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtfeiyong = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtxiaoshoue = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.Cyewuyuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencixiaoshoushu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencixiaoshoue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencilirun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZanbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cticheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1260, 40);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.导出ToolStripMenuItem.Text = "导出";
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
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel1.Controls.Add(this.uiTextBox1);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.dateEdit2);
            this.groupPanel1.Controls.Add(this.labelX11);
            this.groupPanel1.Controls.Add(this.dateEdit1);
            this.groupPanel1.Controls.Add(this.labelX12);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 40);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1260, 83);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 27;
            this.groupPanel1.Text = "查询条件";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(259, 18);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(121, 20);
            this.dateEdit2.TabIndex = 16;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(198, 17);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(55, 23);
            this.labelX11.TabIndex = 15;
            this.labelX11.Text = "日期到：";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(70, 18);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 14;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(9, 17);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(55, 23);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = "日期从：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dataGridViewX1);
            this.groupPanel2.Controls.Add(this.uiGroupBox1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 123);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel2.Size = new System.Drawing.Size(1260, 433);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 28;
            this.groupPanel2.Text = "销售汇总";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.ColumnHeadersHeight = 32;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cyewuyuan,
            this.Cbencixiaoshoushu,
            this.Cbencixiaoshoue,
            this.Cbencilirun,
            this.CZanbi,
            this.Cticheng});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.RowHeight = 29;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewX1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewX1.RowTemplate.Height = 29;
            this.dataGridViewX1.SelectedIndex = -1;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(1254, 239);
            this.dataGridViewX1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dataGridViewX1.Style = Sunny.UI.UIStyle.Custom;
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtshouru);
            this.uiGroupBox1.Controls.Add(this.uiLabel9);
            this.uiGroupBox1.Controls.Add(this.txtzhichu);
            this.uiGroupBox1.Controls.Add(this.uiLabel8);
            this.uiGroupBox1.Controls.Add(this.txtjiagong);
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.txtyouhui);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.txtcaigou);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.txtstock);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.txtlilun);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.txtfeiyong);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.txtxiaoshoue);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 239);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1254, 170);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "合计";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtshouru
            // 
            this.txtshouru.ButtonSymbol = 61761;
            this.txtshouru.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtshouru.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtshouru.Location = new System.Drawing.Point(1038, 87);
            this.txtshouru.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtshouru.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtshouru.Name = "txtshouru";
            this.txtshouru.ShowText = false;
            this.txtshouru.Size = new System.Drawing.Size(131, 29);
            this.txtshouru.TabIndex = 17;
            this.txtshouru.Text = "0.00";
            this.txtshouru.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtshouru.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtshouru.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel9.Location = new System.Drawing.Point(958, 90);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(84, 23);
            this.uiLabel9.TabIndex = 16;
            this.uiLabel9.Text = "其他收入：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtzhichu
            // 
            this.txtzhichu.ButtonSymbol = 61761;
            this.txtzhichu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtzhichu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtzhichu.Location = new System.Drawing.Point(808, 87);
            this.txtzhichu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtzhichu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtzhichu.Name = "txtzhichu";
            this.txtzhichu.ShowText = false;
            this.txtzhichu.Size = new System.Drawing.Size(131, 29);
            this.txtzhichu.TabIndex = 15;
            this.txtzhichu.Text = "0.00";
            this.txtzhichu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtzhichu.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtzhichu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel8.Location = new System.Drawing.Point(728, 90);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(84, 23);
            this.uiLabel8.TabIndex = 14;
            this.uiLabel8.Text = "其他支出：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtjiagong
            // 
            this.txtjiagong.ButtonSymbol = 61761;
            this.txtjiagong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtjiagong.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtjiagong.Location = new System.Drawing.Point(576, 87);
            this.txtjiagong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtjiagong.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtjiagong.Name = "txtjiagong";
            this.txtjiagong.ShowText = false;
            this.txtjiagong.Size = new System.Drawing.Size(131, 29);
            this.txtjiagong.TabIndex = 13;
            this.txtjiagong.Text = "0.00";
            this.txtjiagong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtjiagong.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtjiagong.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel7.Location = new System.Drawing.Point(496, 90);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(84, 23);
            this.uiLabel7.TabIndex = 12;
            this.uiLabel7.Text = "加工费用：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtyouhui
            // 
            this.txtyouhui.ButtonSymbol = 61761;
            this.txtyouhui.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtyouhui.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtyouhui.Location = new System.Drawing.Point(808, 29);
            this.txtyouhui.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtyouhui.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtyouhui.Name = "txtyouhui";
            this.txtyouhui.ShowText = false;
            this.txtyouhui.Size = new System.Drawing.Size(131, 29);
            this.txtyouhui.TabIndex = 11;
            this.txtyouhui.Text = "0.00";
            this.txtyouhui.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtyouhui.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtyouhui.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel6.Location = new System.Drawing.Point(728, 32);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(84, 23);
            this.uiLabel6.TabIndex = 10;
            this.uiLabel6.Text = "优惠金额：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtcaigou
            // 
            this.txtcaigou.ButtonSymbol = 61761;
            this.txtcaigou.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcaigou.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtcaigou.Location = new System.Drawing.Point(335, 87);
            this.txtcaigou.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtcaigou.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtcaigou.Name = "txtcaigou";
            this.txtcaigou.ShowText = false;
            this.txtcaigou.Size = new System.Drawing.Size(131, 29);
            this.txtcaigou.TabIndex = 9;
            this.txtcaigou.Text = "0.00";
            this.txtcaigou.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtcaigou.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtcaigou.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel5.Location = new System.Drawing.Point(255, 90);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(84, 23);
            this.uiLabel5.TabIndex = 8;
            this.uiLabel5.Text = "采购金额：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtstock
            // 
            this.txtstock.ButtonSymbol = 61761;
            this.txtstock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstock.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtstock.Location = new System.Drawing.Point(89, 87);
            this.txtstock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtstock.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtstock.Name = "txtstock";
            this.txtstock.ShowText = false;
            this.txtstock.Size = new System.Drawing.Size(131, 29);
            this.txtstock.TabIndex = 7;
            this.txtstock.Text = "0.00";
            this.txtstock.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtstock.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtstock.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.Location = new System.Drawing.Point(9, 90);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(84, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "库存金额：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtlilun
            // 
            this.txtlilun.ButtonSymbol = 61761;
            this.txtlilun.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtlilun.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtlilun.Location = new System.Drawing.Point(576, 32);
            this.txtlilun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtlilun.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtlilun.Name = "txtlilun";
            this.txtlilun.ShowText = false;
            this.txtlilun.Size = new System.Drawing.Size(131, 29);
            this.txtlilun.TabIndex = 5;
            this.txtlilun.Text = "0.00";
            this.txtlilun.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtlilun.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtlilun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(496, 35);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(84, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "合计利润：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtfeiyong
            // 
            this.txtfeiyong.ButtonSymbol = 61761;
            this.txtfeiyong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfeiyong.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtfeiyong.Location = new System.Drawing.Point(335, 32);
            this.txtfeiyong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfeiyong.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtfeiyong.Name = "txtfeiyong";
            this.txtfeiyong.ShowText = false;
            this.txtfeiyong.Size = new System.Drawing.Size(131, 29);
            this.txtfeiyong.TabIndex = 3;
            this.txtfeiyong.Text = "0.00";
            this.txtfeiyong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtfeiyong.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtfeiyong.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(255, 35);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(84, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "合计费用：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtxiaoshoue
            // 
            this.txtxiaoshoue.ButtonSymbol = 61761;
            this.txtxiaoshoue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtxiaoshoue.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtxiaoshoue.Location = new System.Drawing.Point(89, 32);
            this.txtxiaoshoue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtxiaoshoue.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtxiaoshoue.Name = "txtxiaoshoue";
            this.txtxiaoshoue.ShowText = false;
            this.txtxiaoshoue.Size = new System.Drawing.Size(131, 29);
            this.txtxiaoshoue.TabIndex = 1;
            this.txtxiaoshoue.Text = "0.00";
            this.txtxiaoshoue.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtxiaoshoue.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtxiaoshoue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(9, 35);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(84, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "合计销售额：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "提成比例";
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiTextBox1.Location = new System.Drawing.Point(446, 17);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(81, 29);
            this.uiTextBox1.TabIndex = 18;
            this.uiTextBox1.Text = "0.00";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Cyewuyuan
            // 
            this.Cyewuyuan.DataPropertyName = "业务员";
            this.Cyewuyuan.HeaderText = "业务员";
            this.Cyewuyuan.Name = "Cyewuyuan";
            this.Cyewuyuan.ReadOnly = true;
            // 
            // Cbencixiaoshoushu
            // 
            this.Cbencixiaoshoushu.DataPropertyName = "合计销售数量";
            this.Cbencixiaoshoushu.HeaderText = "本次销售数";
            this.Cbencixiaoshoushu.Name = "Cbencixiaoshoushu";
            this.Cbencixiaoshoushu.ReadOnly = true;
            // 
            // Cbencixiaoshoue
            // 
            this.Cbencixiaoshoue.DataPropertyName = "合计销售额";
            this.Cbencixiaoshoue.HeaderText = "本期销售额";
            this.Cbencixiaoshoue.Name = "Cbencixiaoshoue";
            this.Cbencixiaoshoue.ReadOnly = true;
            // 
            // Cbencilirun
            // 
            this.Cbencilirun.DataPropertyName = "合计利润";
            this.Cbencilirun.HeaderText = "本期利润";
            this.Cbencilirun.Name = "Cbencilirun";
            this.Cbencilirun.ReadOnly = true;
            // 
            // CZanbi
            // 
            this.CZanbi.HeaderText = "销售占比";
            this.CZanbi.Name = "CZanbi";
            this.CZanbi.ReadOnly = true;
            // 
            // Cticheng
            // 
            this.Cticheng.HeaderText = "提成金额";
            this.Cticheng.Name = "Cticheng";
            this.Cticheng.ReadOnly = true;
            // 
            // 销售汇总
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 556);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "销售汇总";
            this.Text = "销售汇总";
            this.Load += new System.EventHandler(this.销售汇总_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private Sunny.UI.UIDataGridView dataGridViewX1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txtlilun;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtfeiyong;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtxiaoshoue;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtstock;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtcaigou;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtyouhui;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtjiagong;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtshouru;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox txtzhichu;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox uiTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cyewuyuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencixiaoshoushu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencixiaoshoue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencilirun;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZanbi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cticheng;
    }
}