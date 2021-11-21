
namespace 纺织贸易管理系统.报表窗体
{
    partial class 来货退卷单
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
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印单据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直接打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtShouhuodizhi = new Sunny.UI.UITextBox();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.cmbcunfang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.txtckmc = new DevExpress.XtraEditors.ButtonEdit();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtdanhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtkehu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtbeizhu = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
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
            this.danjumingxiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtWuliuInfo = new Sunny.UI.UITextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.menuStrip1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danjumingxiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.打印单据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.新增ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.新增ToolStripMenuItem.Text = "保存单据";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 打印单据ToolStripMenuItem
            // 
            this.打印单据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印预览ToolStripMenuItem,
            this.打印编辑ToolStripMenuItem,
            this.直接打印ToolStripMenuItem});
            this.打印单据ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x321;
            this.打印单据ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.打印单据ToolStripMenuItem.Name = "打印单据ToolStripMenuItem";
            this.打印单据ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.打印单据ToolStripMenuItem.Text = "打印单据";
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.PrintPreview_32x32;
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打印预览ToolStripMenuItem.Text = "打印预览";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.打印预览ToolStripMenuItem_Click);
            // 
            // 打印编辑ToolStripMenuItem
            // 
            this.打印编辑ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x32;
            this.打印编辑ToolStripMenuItem.Name = "打印编辑ToolStripMenuItem";
            this.打印编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打印编辑ToolStripMenuItem.Text = "打印编辑";
            this.打印编辑ToolStripMenuItem.Click += new System.EventHandler(this.打印编辑ToolStripMenuItem_Click);
            // 
            // 直接打印ToolStripMenuItem
            // 
            this.直接打印ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x321;
            this.直接打印ToolStripMenuItem.Name = "直接打印ToolStripMenuItem";
            this.直接打印ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.直接打印ToolStripMenuItem.Text = "直接打印";
            this.直接打印ToolStripMenuItem.Click += new System.EventHandler(this.直接打印ToolStripMenuItem_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtWuliuInfo);
            this.uiGroupBox1.Controls.Add(this.labelX1);
            this.uiGroupBox1.Controls.Add(this.txtShouhuodizhi);
            this.uiGroupBox1.Controls.Add(this.labelX15);
            this.uiGroupBox1.Controls.Add(this.cmbcunfang);
            this.uiGroupBox1.Controls.Add(this.txtckmc);
            this.uiGroupBox1.Controls.Add(this.labelX8);
            this.uiGroupBox1.Controls.Add(this.labelX7);
            this.uiGroupBox1.Controls.Add(this.txtdanhao);
            this.uiGroupBox1.Controls.Add(this.txtkehu);
            this.uiGroupBox1.Controls.Add(this.txtbeizhu);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.uiDatePicker1);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 40);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(800, 225);
            this.uiGroupBox1.TabIndex = 2;
            this.uiGroupBox1.Text = "单据信息";
            // 
            // txtShouhuodizhi
            // 
            this.txtShouhuodizhi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShouhuodizhi.FillColor = System.Drawing.Color.White;
            this.txtShouhuodizhi.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtShouhuodizhi.Location = new System.Drawing.Point(69, 133);
            this.txtShouhuodizhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShouhuodizhi.Maximum = 2147483647D;
            this.txtShouhuodizhi.Minimum = -2147483648D;
            this.txtShouhuodizhi.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtShouhuodizhi.Name = "txtShouhuodizhi";
            this.txtShouhuodizhi.Padding = new System.Windows.Forms.Padding(5);
            this.txtShouhuodizhi.Size = new System.Drawing.Size(682, 23);
            this.txtShouhuodizhi.TabIndex = 58;
            this.txtShouhuodizhi.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(3, 133);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(60, 23);
            this.labelX15.TabIndex = 57;
            this.labelX15.Text = "收货地址";
            // 
            // cmbcunfang
            // 
            this.cmbcunfang.DisplayMember = "Text";
            this.cmbcunfang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbcunfang.Enabled = false;
            this.cmbcunfang.ForeColor = System.Drawing.Color.Black;
            this.cmbcunfang.FormattingEnabled = true;
            this.cmbcunfang.ItemHeight = 18;
            this.cmbcunfang.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbcunfang.Location = new System.Drawing.Point(69, 81);
            this.cmbcunfang.Name = "cmbcunfang";
            this.cmbcunfang.Size = new System.Drawing.Size(156, 24);
            this.cmbcunfang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbcunfang.TabIndex = 42;
            this.cmbcunfang.Text = "仓库";
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
            this.txtckmc.Location = new System.Drawing.Point(288, 81);
            this.txtckmc.Name = "txtckmc";
            this.txtckmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtckmc.Size = new System.Drawing.Size(150, 20);
            this.txtckmc.TabIndex = 40;
            this.txtckmc.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtckmc_ButtonClick);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(231, 80);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 23);
            this.labelX8.TabIndex = 41;
            this.labelX8.Text = "发货地址";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(5, 81);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(72, 23);
            this.labelX7.TabIndex = 39;
            this.labelX7.Text = "发货位置";
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
            this.txtdanhao.Location = new System.Drawing.Point(69, 33);
            this.txtdanhao.Name = "txtdanhao";
            this.txtdanhao.PreventEnterBeep = true;
            this.txtdanhao.Size = new System.Drawing.Size(153, 23);
            this.txtdanhao.TabIndex = 11;
            // 
            // txtkehu
            // 
            this.txtkehu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtkehu.Border.Class = "TextBoxBorder";
            this.txtkehu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkehu.ButtonCustom.Text = "选择";
            this.txtkehu.ButtonCustom.Visible = true;
            this.txtkehu.DisabledBackColor = System.Drawing.Color.White;
            this.txtkehu.ForeColor = System.Drawing.Color.Black;
            this.txtkehu.Location = new System.Drawing.Point(523, 32);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.PreventEnterBeep = true;
            this.txtkehu.ReadOnly = true;
            this.txtkehu.Size = new System.Drawing.Size(230, 23);
            this.txtkehu.TabIndex = 10;
            this.txtkehu.ButtonCustomClick += new System.EventHandler(this.txtkehu_ButtonCustomClick);
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbeizhu.FillColor = System.Drawing.Color.White;
            this.txtbeizhu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbeizhu.Location = new System.Drawing.Point(69, 188);
            this.txtbeizhu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbeizhu.Maximum = 2147483647D;
            this.txtbeizhu.Minimum = -2147483648D;
            this.txtbeizhu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Padding = new System.Windows.Forms.Padding(5);
            this.txtbeizhu.Size = new System.Drawing.Size(682, 23);
            this.txtbeizhu.TabIndex = 9;
            this.txtbeizhu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(19, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "单号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(449, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户名称：";
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDatePicker1.Location = new System.Drawing.Point(288, 29);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(150, 23);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 1;
            this.uiDatePicker1.Text = "2021-01-22";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2021, 1, 22, 10, 51, 29, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(228, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.gridControl1);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox3.Location = new System.Drawing.Point(0, 265);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(800, 185);
            this.uiGroupBox3.TabIndex = 4;
            this.uiGroupBox3.Text = "单据明细";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ButtonEdit1,
            this.ButtonEdit2,
            this.cmddanwei,
            this.colorbtn});
            this.gridControl1.Size = new System.Drawing.Size(800, 153);
            this.gridControl1.TabIndex = 11;
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
            // danjumingxiBindingSource
            // 
            this.danjumingxiBindingSource.DataSource = typeof(纺织贸易管理系统.danjumingxitable);
            // 
            // txtWuliuInfo
            // 
            this.txtWuliuInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWuliuInfo.FillColor = System.Drawing.Color.White;
            this.txtWuliuInfo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtWuliuInfo.Location = new System.Drawing.Point(523, 80);
            this.txtWuliuInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWuliuInfo.Maximum = 2147483647D;
            this.txtWuliuInfo.Minimum = -2147483648D;
            this.txtWuliuInfo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtWuliuInfo.Name = "txtWuliuInfo";
            this.txtWuliuInfo.Padding = new System.Windows.Forms.Padding(5);
            this.txtWuliuInfo.Size = new System.Drawing.Size(230, 23);
            this.txtWuliuInfo.TabIndex = 60;
            this.txtWuliuInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(457, 80);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 23);
            this.labelX1.TabIndex = 59;
            this.labelX1.Text = "物流信息";
            // 
            // 来货退卷单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "来货退卷单";
            this.Text = "生产退卷单";
            this.Load += new System.EventHandler(this.来货入库单_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtckmc.Properties)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmddanwei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danjumingxiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatePicker uiDatePicker1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label1;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtbeizhu;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label2;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private DevComponents.DotNetBar.Controls.TextBoxX txtdanhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkehu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource danjumingxiBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmddanwei;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit colorbtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存样式ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbcunfang;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevExpress.XtraEditors.ButtonEdit txtckmc;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.ToolStripMenuItem 打印单据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直接打印ToolStripMenuItem;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtShouhuodizhi;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private DevComponents.DotNetBar.LabelX labelX15;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtWuliuInfo;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}