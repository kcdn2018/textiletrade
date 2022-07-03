
namespace 纺织贸易管理系统.报表窗体
{
    partial class 细码库存
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
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除卷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除开剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印检验报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预览报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印唛头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唛头模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbmaitou = new System.Windows.Forms.ToolStripComboBox();
            this.groupPanel1 = new System.Windows.Forms.GroupBox();
            this.txtkehu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtsehao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtOrderNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txthuohao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtganghao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtguige = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtpingming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.uiPagination1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.删除卷ToolStripMenuItem,
            this.删除开剪ToolStripMenuItem,
            this.打印检验报告ToolStripMenuItem,
            this.打印唛头ToolStripMenuItem,
            this.唛头模板ToolStripMenuItem,
            this.cmbmaitou});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 40);
            this.menuStrip1.TabIndex = 3;
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
            this.刷新ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Find_32x32;
            this.刷新ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.刷新ToolStripMenuItem.Text = "查询";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 删除卷ToolStripMenuItem
            // 
            this.删除卷ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.DeleteList_32x32;
            this.删除卷ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.删除卷ToolStripMenuItem.Name = "删除卷ToolStripMenuItem";
            this.删除卷ToolStripMenuItem.Size = new System.Drawing.Size(88, 36);
            this.删除卷ToolStripMenuItem.Text = "删除卷";
            this.删除卷ToolStripMenuItem.Click += new System.EventHandler(this.删除卷ToolStripMenuItem_Click);
            // 
            // 删除开剪ToolStripMenuItem
            // 
            this.删除开剪ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.DeleteList_32x32;
            this.删除开剪ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.删除开剪ToolStripMenuItem.Name = "删除开剪ToolStripMenuItem";
            this.删除开剪ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.删除开剪ToolStripMenuItem.Text = "删除开剪";
            // 
            // 打印检验报告ToolStripMenuItem
            // 
            this.打印检验报告ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑报告ToolStripMenuItem,
            this.预览报告ToolStripMenuItem,
            this.打印报告ToolStripMenuItem});
            this.打印检验报告ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x32;
            this.打印检验报告ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.打印检验报告ToolStripMenuItem.Name = "打印检验报告ToolStripMenuItem";
            this.打印检验报告ToolStripMenuItem.Size = new System.Drawing.Size(124, 36);
            this.打印检验报告ToolStripMenuItem.Text = "打印检验报告";
            // 
            // 编辑报告ToolStripMenuItem
            // 
            this.编辑报告ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x32;
            this.编辑报告ToolStripMenuItem.Name = "编辑报告ToolStripMenuItem";
            this.编辑报告ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑报告ToolStripMenuItem.Text = "编辑报告";
            this.编辑报告ToolStripMenuItem.Click += new System.EventHandler(this.编辑报告ToolStripMenuItem_Click);
            // 
            // 预览报告ToolStripMenuItem
            // 
            this.预览报告ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.PrintPreview_32x32;
            this.预览报告ToolStripMenuItem.Name = "预览报告ToolStripMenuItem";
            this.预览报告ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.预览报告ToolStripMenuItem.Text = "预览报告";
            this.预览报告ToolStripMenuItem.Click += new System.EventHandler(this.预览报告ToolStripMenuItem_Click);
            // 
            // 打印报告ToolStripMenuItem
            // 
            this.打印报告ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x321;
            this.打印报告ToolStripMenuItem.Name = "打印报告ToolStripMenuItem";
            this.打印报告ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打印报告ToolStripMenuItem.Text = "打印报告";
            this.打印报告ToolStripMenuItem.Click += new System.EventHandler(this.打印报告ToolStripMenuItem_Click);
            // 
            // 打印唛头ToolStripMenuItem
            // 
            this.打印唛头ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Print_32x32;
            this.打印唛头ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.打印唛头ToolStripMenuItem.Name = "打印唛头ToolStripMenuItem";
            this.打印唛头ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.打印唛头ToolStripMenuItem.Text = "打印唛头";
            this.打印唛头ToolStripMenuItem.Click += new System.EventHandler(this.打印唛头ToolStripMenuItem_Click);
            // 
            // 唛头模板ToolStripMenuItem
            // 
            this.唛头模板ToolStripMenuItem.Enabled = false;
            this.唛头模板ToolStripMenuItem.Name = "唛头模板ToolStripMenuItem";
            this.唛头模板ToolStripMenuItem.Size = new System.Drawing.Size(68, 36);
            this.唛头模板ToolStripMenuItem.Text = "唛头模板";
            // 
            // cmbmaitou
            // 
            this.cmbmaitou.Name = "cmbmaitou";
            this.cmbmaitou.Size = new System.Drawing.Size(121, 36);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.txtkehu);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.txtsehao);
            this.groupPanel1.Controls.Add(this.txtBianhao);
            this.groupPanel1.Controls.Add(this.txtOrderNum);
            this.groupPanel1.Controls.Add(this.labelX10);
            this.groupPanel1.Controls.Add(this.txthuohao);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txtganghao);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX11);
            this.groupPanel1.Controls.Add(this.txtguige);
            this.groupPanel1.Controls.Add(this.txtpingming);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 40);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(800, 102);
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.TabStop = false;
            this.groupPanel1.Text = "查询条件";
            // 
            // txtkehu
            // 
            this.txtkehu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtkehu.Border.Class = "TextBoxBorder";
            this.txtkehu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkehu.DisabledBackColor = System.Drawing.Color.White;
            this.txtkehu.ForeColor = System.Drawing.Color.Black;
            this.txtkehu.Location = new System.Drawing.Point(580, 61);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.PreventEnterBeep = true;
            this.txtkehu.Size = new System.Drawing.Size(100, 21);
            this.txtkehu.TabIndex = 36;
            this.txtkehu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(515, 60);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(59, 23);
            this.labelX7.TabIndex = 35;
            this.labelX7.Text = "客户：";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(344, 60);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(59, 23);
            this.labelX8.TabIndex = 34;
            this.labelX8.Text = "颜色：";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(173, 60);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(59, 23);
            this.labelX9.TabIndex = 33;
            this.labelX9.Text = "编号：";
            // 
            // txtsehao
            // 
            this.txtsehao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtsehao.Border.Class = "TextBoxBorder";
            this.txtsehao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsehao.DisabledBackColor = System.Drawing.Color.White;
            this.txtsehao.ForeColor = System.Drawing.Color.Black;
            this.txtsehao.Location = new System.Drawing.Point(409, 61);
            this.txtsehao.Name = "txtsehao";
            this.txtsehao.PreventEnterBeep = true;
            this.txtsehao.Size = new System.Drawing.Size(100, 21);
            this.txtsehao.TabIndex = 32;
            this.txtsehao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // txtBianhao
            // 
            this.txtBianhao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBianhao.Border.Class = "TextBoxBorder";
            this.txtBianhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBianhao.DisabledBackColor = System.Drawing.Color.White;
            this.txtBianhao.ForeColor = System.Drawing.Color.Black;
            this.txtBianhao.Location = new System.Drawing.Point(238, 61);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.Size = new System.Drawing.Size(100, 21);
            this.txtBianhao.TabIndex = 31;
            this.txtBianhao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOrderNum.Border.Class = "TextBoxBorder";
            this.txtOrderNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNum.DisabledBackColor = System.Drawing.Color.White;
            this.txtOrderNum.ForeColor = System.Drawing.Color.Black;
            this.txtOrderNum.Location = new System.Drawing.Point(72, 61);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.PreventEnterBeep = true;
            this.txtOrderNum.Size = new System.Drawing.Size(95, 21);
            this.txtOrderNum.TabIndex = 30;
            this.txtOrderNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(7, 60);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(59, 23);
            this.labelX10.TabIndex = 29;
            this.labelX10.Text = "订单号：";
            // 
            // txthuohao
            // 
            this.txthuohao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txthuohao.Border.Class = "TextBoxBorder";
            this.txthuohao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txthuohao.DisabledBackColor = System.Drawing.Color.White;
            this.txthuohao.ForeColor = System.Drawing.Color.Black;
            this.txthuohao.Location = new System.Drawing.Point(580, 34);
            this.txthuohao.Name = "txthuohao";
            this.txthuohao.PreventEnterBeep = true;
            this.txthuohao.Size = new System.Drawing.Size(100, 21);
            this.txthuohao.TabIndex = 28;
            this.txthuohao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(515, 33);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(59, 23);
            this.labelX5.TabIndex = 27;
            this.labelX5.Text = "款号：";
            // 
            // txtganghao
            // 
            this.txtganghao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtganghao.Border.Class = "TextBoxBorder";
            this.txtganghao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtganghao.DisabledBackColor = System.Drawing.Color.White;
            this.txtganghao.ForeColor = System.Drawing.Color.Black;
            this.txtganghao.Location = new System.Drawing.Point(409, 34);
            this.txtganghao.Name = "txtganghao";
            this.txtganghao.PreventEnterBeep = true;
            this.txtganghao.Size = new System.Drawing.Size(100, 21);
            this.txtganghao.TabIndex = 26;
            this.txtganghao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(344, 33);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(59, 23);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "缸号：";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(173, 33);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(59, 23);
            this.labelX6.TabIndex = 24;
            this.labelX6.Text = "规格：";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(6, 33);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(59, 23);
            this.labelX11.TabIndex = 23;
            this.labelX11.Text = "品名：";
            // 
            // txtguige
            // 
            this.txtguige.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtguige.Border.Class = "TextBoxBorder";
            this.txtguige.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtguige.DisabledBackColor = System.Drawing.Color.White;
            this.txtguige.ForeColor = System.Drawing.Color.Black;
            this.txtguige.Location = new System.Drawing.Point(238, 34);
            this.txtguige.Name = "txtguige";
            this.txtguige.PreventEnterBeep = true;
            this.txtguige.Size = new System.Drawing.Size(100, 21);
            this.txtguige.TabIndex = 22;
            this.txtguige.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // txtpingming
            // 
            this.txtpingming.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtpingming.Border.Class = "TextBoxBorder";
            this.txtpingming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingming.DisabledBackColor = System.Drawing.Color.White;
            this.txtpingming.ForeColor = System.Drawing.Color.Black;
            this.txtpingming.Location = new System.Drawing.Point(71, 34);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.PreventEnterBeep = true;
            this.txtpingming.Size = new System.Drawing.Size(96, 21);
            this.txtpingming.TabIndex = 21;
            this.txtpingming.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpingming_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::纺织贸易管理系统.Properties.Resources.reading_32x32;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "配置列";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "保存样式";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 142);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(800, 273);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "米",
            "码",
            "公斤数"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // uiPagination1
            // 
            this.uiPagination1.Controls.Add(this.panel1);
            this.uiPagination1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPagination1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPagination1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPagination1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiPagination1.Location = new System.Drawing.Point(0, 415);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.PageSize = 30;
            this.uiPagination1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.ShowText = false;
            this.uiPagination1.Size = new System.Drawing.Size(800, 35);
            this.uiPagination1.Style = Sunny.UI.UIStyle.Gray;
            this.uiPagination1.StyleCustomMode = true;
            this.uiPagination1.TabIndex = 14;
            this.uiPagination1.Text = "uiPagination1";
            this.uiPagination1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_PageChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 35);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "合计：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "0卷";
            // 
            // 细码库存
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.uiPagination1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "细码库存";
            this.Text = "细码库存";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.uiPagination1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除卷ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除开剪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印唛头ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 唛头模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbmaitou;
        private System.Windows.Forms.GroupBox groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkehu;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsehao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNum;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txthuohao;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtganghao;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtguige;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingming;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 打印检验报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预览报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印报告ToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private Sunny.UI.UIPagination uiPagination1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}