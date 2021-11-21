namespace 纺织贸易管理系统.报表窗体
{
    partial class 应收款汇总
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
            this.txtkehu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new Sunny.UI.UIDataGridView();
            this.ckehu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cyewuyuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Czhangqi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cshangqiyue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencixiaoshoushu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencixiaoshoue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbenciyingshoukuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbencitiaochong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbenciyue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Czongyue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbenqixvkaipiaoe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbenqiyikaipiaoe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cbenqiqianpiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cqianpiaoe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cyikaipiaoweifukuan = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Cyuqijine = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.menuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 40);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.ExportToXLS_32x32;
            this.导出ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
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
            this.groupPanel1.Controls.Add(this.txtkehu);
            this.groupPanel1.Controls.Add(this.labelX10);
            this.groupPanel1.Controls.Add(this.dateEdit2);
            this.groupPanel1.Controls.Add(this.labelX11);
            this.groupPanel1.Controls.Add(this.dateEdit1);
            this.groupPanel1.Controls.Add(this.labelX12);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 40);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1471, 83);
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
            this.groupPanel1.TabIndex = 26;
            this.groupPanel1.Text = "查询条件";
            // 
            // txtkehu
            // 
            this.txtkehu.Location = new System.Drawing.Point(467, 18);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtkehu.Size = new System.Drawing.Size(269, 20);
            this.txtkehu.TabIndex = 18;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(386, 17);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 17;
            this.labelX10.Text = "客户名称：";
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
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 123);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel2.Size = new System.Drawing.Size(1471, 327);
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
            this.groupPanel2.TabIndex = 27;
            this.groupPanel2.Text = "应收款汇总";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.ColumnHeadersHeight = 32;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckehu,
            this.Cyewuyuan,
            this.Czhangqi,
            this.Cshangqiyue,
            this.Cbencixiaoshoushu,
            this.Cbencixiaoshoue,
            this.Cbenciyingshoukuan,
            this.Cbencitiaochong,
            this.Cbenciyue,
            this.Czongyue,
            this.Cbenqixvkaipiaoe,
            this.Cbenqiyikaipiaoe,
            this.Cbenqiqianpiao,
            this.Cqianpiaoe,
            this.Cyikaipiaoweifukuan,
            this.Cyuqijine});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.RowHeight = 29;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dataGridViewX1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.RowTemplate.Height = 29;
            this.dataGridViewX1.SelectedIndex = -1;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.ShowGridLine = true;
            this.dataGridViewX1.Size = new System.Drawing.Size(1465, 303);
            this.dataGridViewX1.Style = Sunny.UI.UIStyle.Custom;
            this.dataGridViewX1.TabIndex = 0;
            // 
            // ckehu
            // 
            this.ckehu.HeaderText = "客户名称";
            this.ckehu.Name = "ckehu";
            this.ckehu.ReadOnly = true;
            // 
            // Cyewuyuan
            // 
            this.Cyewuyuan.HeaderText = "业务员";
            this.Cyewuyuan.Name = "Cyewuyuan";
            this.Cyewuyuan.ReadOnly = true;
            // 
            // Czhangqi
            // 
            this.Czhangqi.HeaderText = "账期";
            this.Czhangqi.Name = "Czhangqi";
            this.Czhangqi.ReadOnly = true;
            // 
            // Cshangqiyue
            // 
            this.Cshangqiyue.HeaderText = "上期余额";
            this.Cshangqiyue.Name = "Cshangqiyue";
            this.Cshangqiyue.ReadOnly = true;
            // 
            // Cbencixiaoshoushu
            // 
            this.Cbencixiaoshoushu.HeaderText = "本次销售数";
            this.Cbencixiaoshoushu.Name = "Cbencixiaoshoushu";
            this.Cbencixiaoshoushu.ReadOnly = true;
            // 
            // Cbencixiaoshoue
            // 
            this.Cbencixiaoshoue.HeaderText = "本期销售额";
            this.Cbencixiaoshoue.Name = "Cbencixiaoshoue";
            this.Cbencixiaoshoue.ReadOnly = true;
            // 
            // Cbenciyingshoukuan
            // 
            this.Cbenciyingshoukuan.HeaderText = "本次应收款";
            this.Cbenciyingshoukuan.Name = "Cbenciyingshoukuan";
            this.Cbenciyingshoukuan.ReadOnly = true;
            // 
            // Cbencitiaochong
            // 
            this.Cbencitiaochong.HeaderText = "本次调充";
            this.Cbencitiaochong.Name = "Cbencitiaochong";
            this.Cbencitiaochong.ReadOnly = true;
            // 
            // Cbenciyue
            // 
            this.Cbenciyue.HeaderText = "本次余额";
            this.Cbenciyue.Name = "Cbenciyue";
            this.Cbenciyue.ReadOnly = true;
            // 
            // Czongyue
            // 
            this.Czongyue.HeaderText = "总余额";
            this.Czongyue.Name = "Czongyue";
            this.Czongyue.ReadOnly = true;
            // 
            // Cbenqixvkaipiaoe
            // 
            this.Cbenqixvkaipiaoe.HeaderText = "本次需开票额";
            this.Cbenqixvkaipiaoe.Name = "Cbenqixvkaipiaoe";
            this.Cbenqixvkaipiaoe.ReadOnly = true;
            // 
            // Cbenqiyikaipiaoe
            // 
            this.Cbenqiyikaipiaoe.HeaderText = "本期已开票额";
            this.Cbenqiyikaipiaoe.Name = "Cbenqiyikaipiaoe";
            this.Cbenqiyikaipiaoe.ReadOnly = true;
            // 
            // Cbenqiqianpiao
            // 
            this.Cbenqiqianpiao.HeaderText = "本期欠票";
            this.Cbenqiqianpiao.Name = "Cbenqiqianpiao";
            this.Cbenqiqianpiao.ReadOnly = true;
            // 
            // Cqianpiaoe
            // 
            this.Cqianpiaoe.HeaderText = "欠票额";
            this.Cqianpiaoe.Name = "Cqianpiaoe";
            this.Cqianpiaoe.ReadOnly = true;
            // 
            // Cyikaipiaoweifukuan
            // 
            // 
            // 
            // 
            this.Cyikaipiaoweifukuan.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cyikaipiaoweifukuan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cyikaipiaoweifukuan.HeaderText = "已开票未付款";
            this.Cyikaipiaoweifukuan.Increment = 1D;
            this.Cyikaipiaoweifukuan.Name = "Cyikaipiaoweifukuan";
            this.Cyikaipiaoweifukuan.ReadOnly = true;
            this.Cyikaipiaoweifukuan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Cyuqijine
            // 
            // 
            // 
            // 
            this.Cyuqijine.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cyuqijine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cyuqijine.HeaderText = "逾期金额";
            this.Cyuqijine.Increment = 1D;
            this.Cyuqijine.Name = "Cyuqijine";
            this.Cyuqijine.ReadOnly = true;
            this.Cyuqijine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 应收款汇总
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 450);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "应收款汇总";
            this.Text = "应收款汇总";
            this.Load += new System.EventHandler(this.应收款汇总_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevExpress.XtraEditors.ButtonEdit txtkehu;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private Sunny.UI.UIDataGridView  dataGridViewX1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private System.Windows.Forms.DataGridViewTextBoxColumn ckehu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cyewuyuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czhangqi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cshangqiyue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencixiaoshoushu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencixiaoshoue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbenciyingshoukuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbencitiaochong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbenciyue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czongyue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbenqixvkaipiaoe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbenqiyikaipiaoe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cbenqiqianpiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cqianpiaoe;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Cyikaipiaoweifukuan;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Cyuqijine;
    }
}