namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增疵点
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增疵点.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增疵点.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增疵点));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtpingming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtkoufeng = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKoumi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbWenti = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(194, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(73, 36);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "名称";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(11, 144);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 37;
            this.label29.Text = "扣分";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(11, 109);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 36;
            this.label30.Text = "扣米";
            // 
            // txtpingming
            // 
            // 
            // 
            // 
            this.txtpingming.Border.Class = "TextBoxBorder";
            this.txtpingming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingming.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpingming.Location = new System.Drawing.Point(71, 70);
            this.txtpingming.Margin = new System.Windows.Forms.Padding(2);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.PreventEnterBeep = true;
            this.txtpingming.Size = new System.Drawing.Size(101, 21);
            this.txtpingming.TabIndex = 1;
            this.txtpingming.WatermarkText = "疵点名称";
            // 
            // txtkoufeng
            // 
            // 
            // 
            // 
            this.txtkoufeng.Border.Class = "TextBoxBorder";
            this.txtkoufeng.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkoufeng.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkoufeng.Location = new System.Drawing.Point(71, 142);
            this.txtkoufeng.Margin = new System.Windows.Forms.Padding(2);
            this.txtkoufeng.Name = "txtkoufeng";
            this.txtkoufeng.PreventEnterBeep = true;
            this.txtkoufeng.Size = new System.Drawing.Size(101, 21);
            this.txtkoufeng.TabIndex = 64;
            // 
            // txtKoumi
            // 
            // 
            // 
            // 
            this.txtKoumi.Border.Class = "TextBoxBorder";
            this.txtKoumi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKoumi.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKoumi.Location = new System.Drawing.Point(71, 105);
            this.txtKoumi.Margin = new System.Windows.Forms.Padding(2);
            this.txtKoumi.Name = "txtKoumi";
            this.txtKoumi.PreventEnterBeep = true;
            this.txtKoumi.Size = new System.Drawing.Size(101, 21);
            this.txtKoumi.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(11, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 87;
            this.label10.Text = "问题归属";
            // 
            // cmbWenti
            // 
            this.cmbWenti.DisplayMember = "Text";
            this.cmbWenti.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWenti.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWenti.FormattingEnabled = true;
            this.cmbWenti.ItemHeight = 16;
            this.cmbWenti.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbWenti.Location = new System.Drawing.Point(71, 181);
            this.cmbWenti.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWenti.Name = "cmbWenti";
            this.cmbWenti.Size = new System.Drawing.Size(103, 22);
            this.cmbWenti.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbWenti.TabIndex = 88;
            this.cmbWenti.Text = "坯布厂";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "坯布厂";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "染厂";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "后整理厂";
            // 
            // 新增疵点
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 223);
            this.Controls.Add(this.cmbWenti);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtkoufeng);
            this.Controls.Add(this.txtKoumi);
            this.Controls.Add(this.txtpingming);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增疵点";
            this.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.Text = "新增疵点";
            this.Load += new System.EventHandler(this.新增品种_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingming;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkoufeng;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKoumi;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbWenti;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
    }
}