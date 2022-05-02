using 纺织贸易管理系统.自定义类;

namespace 纺织贸易管理系统.新增窗体
{
    partial class 费用申请单
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(费用申请单));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印寄样标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txthetonghao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbshouzhi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtordernum = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbjinshouren = new System.Windows.Forms.ComboBox();
            this.cmbbumen = new System.Windows.Forms.ComboBox();
            this.txtjine = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtzaiyao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtfahuodanhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbfukuanfangshi = new System.Windows.Forms.ComboBox();
            this.cmbfeiyongleixing = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbqiankuan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtdanhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cmddanwei = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colorbtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.TextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtordernum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.uiTitlePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.打印寄样标签ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 40);
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
            // 打印寄样标签ToolStripMenuItem
            // 
            this.打印寄样标签ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.打印寄样标签ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x321;
            this.打印寄样标签ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.打印寄样标签ToolStripMenuItem.Name = "打印寄样标签ToolStripMenuItem";
            this.打印寄样标签ToolStripMenuItem.Size = new System.Drawing.Size(112, 36);
            this.打印寄样标签ToolStripMenuItem.Text = "打印费用单";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "打印编辑";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "打印预览";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txthetonghao);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.cmbshouzhi);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.txtordernum);
            this.groupControl1.Controls.Add(this.cmbjinshouren);
            this.groupControl1.Controls.Add(this.cmbbumen);
            this.groupControl1.Controls.Add(this.txtjine);
            this.groupControl1.Controls.Add(this.txtzaiyao);
            this.groupControl1.Controls.Add(this.txtfahuodanhao);
            this.groupControl1.Controls.Add(this.cmbfukuanfangshi);
            this.groupControl1.Controls.Add(this.cmbfeiyongleixing);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cmbqiankuan);
            this.groupControl1.Controls.Add(this.labelX12);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.labelX3);
            this.groupControl1.Controls.Add(this.txtdanhao);
            this.groupControl1.Controls.Add(this.labelX1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(820, 211);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "单据信息";
            // 
            // txthetonghao
            // 
            this.txthetonghao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txthetonghao.Border.Class = "TextBoxBorder";
            this.txthetonghao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txthetonghao.DisabledBackColor = System.Drawing.Color.White;
            this.txthetonghao.ForeColor = System.Drawing.Color.Black;
            this.txthetonghao.Location = new System.Drawing.Point(469, 33);
            this.txthetonghao.Name = "txthetonghao";
            this.txthetonghao.PreventEnterBeep = true;
            this.txthetonghao.Size = new System.Drawing.Size(123, 22);
            this.txthetonghao.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(420, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 14);
            this.label10.TabIndex = 66;
            this.label10.Text = "合同号";
            // 
            // cmbshouzhi
            // 
            this.cmbshouzhi.FormattingEnabled = true;
            this.cmbshouzhi.Items.AddRange(new object[] {
            "收入",
            "支出"});
            this.cmbshouzhi.Location = new System.Drawing.Point(469, 90);
            this.cmbshouzhi.Name = "cmbshouzhi";
            this.cmbshouzhi.Size = new System.Drawing.Size(123, 22);
            this.cmbshouzhi.TabIndex = 65;
            this.cmbshouzhi.Text = "支出";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 64;
            this.label9.Text = "收支类型";
            // 
            // txtordernum
            // 
            this.txtordernum.Location = new System.Drawing.Point(281, 34);
            this.txtordernum.Name = "txtordernum";
            this.txtordernum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtordernum.Size = new System.Drawing.Size(121, 20);
            this.txtordernum.TabIndex = 63;
            this.txtordernum.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtordernum_ButtonClick);
            // 
            // cmbjinshouren
            // 
            this.cmbjinshouren.FormattingEnabled = true;
            this.cmbjinshouren.Location = new System.Drawing.Point(659, 90);
            this.cmbjinshouren.Name = "cmbjinshouren";
            this.cmbjinshouren.Size = new System.Drawing.Size(125, 22);
            this.cmbjinshouren.TabIndex = 62;
            // 
            // cmbbumen
            // 
            this.cmbbumen.FormattingEnabled = true;
            this.cmbbumen.Location = new System.Drawing.Point(281, 61);
            this.cmbbumen.Name = "cmbbumen";
            this.cmbbumen.Size = new System.Drawing.Size(121, 22);
            this.cmbbumen.TabIndex = 61;
            // 
            // txtjine
            // 
            this.txtjine.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtjine.Border.Class = "TextBoxBorder";
            this.txtjine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtjine.DisabledBackColor = System.Drawing.Color.White;
            this.txtjine.ForeColor = System.Drawing.Color.Black;
            this.txtjine.Location = new System.Drawing.Point(82, 90);
            this.txtjine.Name = "txtjine";
            this.txtjine.PreventEnterBeep = true;
            this.txtjine.Size = new System.Drawing.Size(123, 22);
            this.txtjine.TabIndex = 60;
            // 
            // txtzaiyao
            // 
            this.txtzaiyao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtzaiyao.Border.Class = "TextBoxBorder";
            this.txtzaiyao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtzaiyao.DisabledBackColor = System.Drawing.Color.White;
            this.txtzaiyao.ForeColor = System.Drawing.Color.Black;
            this.txtzaiyao.Location = new System.Drawing.Point(80, 118);
            this.txtzaiyao.Multiline = true;
            this.txtzaiyao.Name = "txtzaiyao";
            this.txtzaiyao.PreventEnterBeep = true;
            this.txtzaiyao.Size = new System.Drawing.Size(704, 77);
            this.txtzaiyao.TabIndex = 59;
            // 
            // txtfahuodanhao
            // 
            this.txtfahuodanhao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtfahuodanhao.Border.Class = "TextBoxBorder";
            this.txtfahuodanhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtfahuodanhao.DisabledBackColor = System.Drawing.Color.White;
            this.txtfahuodanhao.ForeColor = System.Drawing.Color.Black;
            this.txtfahuodanhao.Location = new System.Drawing.Point(659, 61);
            this.txtfahuodanhao.Name = "txtfahuodanhao";
            this.txtfahuodanhao.PreventEnterBeep = true;
            this.txtfahuodanhao.Size = new System.Drawing.Size(125, 22);
            this.txtfahuodanhao.TabIndex = 58;
            // 
            // cmbfukuanfangshi
            // 
            this.cmbfukuanfangshi.FormattingEnabled = true;
            this.cmbfukuanfangshi.Location = new System.Drawing.Point(469, 61);
            this.cmbfukuanfangshi.Name = "cmbfukuanfangshi";
            this.cmbfukuanfangshi.Size = new System.Drawing.Size(123, 22);
            this.cmbfukuanfangshi.TabIndex = 57;
            // 
            // cmbfeiyongleixing
            // 
            this.cmbfeiyongleixing.FormattingEnabled = true;
            this.cmbfeiyongleixing.Items.AddRange(new object[] {
            "财务费用",
            "管理费用",
            "销售费用"});
            this.cmbfeiyongleixing.Location = new System.Drawing.Point(82, 61);
            this.cmbfeiyongleixing.Name = "cmbfeiyongleixing";
            this.cmbfeiyongleixing.Size = new System.Drawing.Size(121, 22);
            this.cmbfeiyongleixing.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 54;
            this.label8.Text = "单据摘要";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "付款方式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 52;
            this.label6.Text = "发货单号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 51;
            this.label5.Text = "金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 50;
            this.label4.Text = "经手人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 49;
            this.label3.Text = "部门";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "费用类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 47;
            this.label1.Text = "订单号";
            // 
            // cmbqiankuan
            // 
            this.cmbqiankuan.DisplayMember = "Text";
            this.cmbqiankuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbqiankuan.ForeColor = System.Drawing.Color.Black;
            this.cmbqiankuan.FormattingEnabled = true;
            this.cmbqiankuan.ItemHeight = 17;
            this.cmbqiankuan.Items.AddRange(new object[] {
            this.comboItem5,
            this.comboItem6});
            this.cmbqiankuan.Location = new System.Drawing.Point(283, 90);
            this.cmbqiankuan.Name = "cmbqiankuan";
            this.cmbqiankuan.Size = new System.Drawing.Size(123, 23);
            this.cmbqiankuan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbqiankuan.TabIndex = 42;
            this.cmbqiankuan.Text = "现金预付";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "欠款";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "现金预付";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(229, 90);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(34, 23);
            this.labelX12.TabIndex = 41;
            this.labelX12.Text = "欠款";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2020, 7, 31, 16, 33, 18, 0);
            this.dateEdit1.Location = new System.Drawing.Point(659, 34);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(125, 20);
            this.dateEdit1.TabIndex = 23;
            this.dateEdit1.DateTimeChanged += new System.EventHandler(this.dateEdit1_DateTimeChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(606, 33);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 23);
            this.labelX3.TabIndex = 22;
            this.labelX3.Text = "日期";
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
            this.txtdanhao.Location = new System.Drawing.Point(82, 33);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.PreventEnterBeep = true;
            this.txtdanhao.ReadOnly = true;
            this.txtdanhao.Size = new System.Drawing.Size(121, 22);
            this.txtdanhao.TabIndex = 21;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(27, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "单号";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.gridControl1);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 251);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.Size = new System.Drawing.Size(820, 339);
            this.uiTitlePanel1.TabIndex = 5;
            this.uiTitlePanel1.Text = "费用明细";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 35);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.ButtonEdit2,
            this.cmddanwei,
            this.colorbtn,
            this.TextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(820, 304);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            "公斤数",
            "包",
            "箱",
            "个",
            "台",
            "套",
            "盒",
            "块",
            "片",
            "本",
            "只"});
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
            // TextEdit1
            // 
            this.TextEdit1.Name = "TextEdit1";
            // 
            // 费用申请单
            // 
            this.AllowShowTitle = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.uiTitlePanel1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "费用申请单";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Text = "费用单";
            this.Load += new System.EventHandler(this.费用申请单_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtordernum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.uiTitlePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印寄样标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbqiankuan;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdanhao;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cmbjinshouren;
        private System.Windows.Forms.ComboBox cmbbumen;
        private DevComponents.DotNetBar.Controls.TextBoxX txtjine;
        private System.Windows.Forms.ComboBox cmbfukuanfangshi;
        private System.Windows.Forms.ComboBox cmbfeiyongleixing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit txtordernum;
        private DevComponents.DotNetBar.Controls.TextBoxX txtzaiyao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtfahuodanhao;
        private System.Windows.Forms.ComboBox cmbshouzhi;
        private System.Windows.Forms.Label label9;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITitlePanel”(是否缺少程序集引用?)
        private Sunny.UI.UITitlePanel uiTitlePanel1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITitlePanel”(是否缺少程序集引用?)
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmddanwei;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit colorbtn;
        private DevComponents.DotNetBar.Controls.TextBoxX txthetonghao;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEdit1;
    }
}