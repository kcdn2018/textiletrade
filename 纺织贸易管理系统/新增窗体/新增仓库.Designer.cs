namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增仓库
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增仓库.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增仓库.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增仓库));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbleixing = new System.Windows.Forms.ToolStripComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtpingming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlianxidianhua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlianxiren = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtdizhi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.仓库类型ToolStripMenuItem,
            this.cmbleixing});
            this.menuStrip1.Location = new System.Drawing.Point(0, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 40);
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
            // 仓库类型ToolStripMenuItem
            // 
            this.仓库类型ToolStripMenuItem.Name = "仓库类型ToolStripMenuItem";
            this.仓库类型ToolStripMenuItem.Size = new System.Drawing.Size(65, 36);
            this.仓库类型ToolStripMenuItem.Text = "仓库类型";
            // 
            // cmbleixing
            // 
            this.cmbleixing.Items.AddRange(new object[] {
            "成品仓库",
            "次品仓库",
            "半成品仓库",
            "原料仓库",
            "五金仓库",
            "样布库"});
            this.cmbleixing.Name = "cmbleixing";
            this.cmbleixing.Size = new System.Drawing.Size(121, 36);
            this.cmbleixing.Text = "成品仓库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(250, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "名称";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(250, 136);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 37;
            this.label29.Text = "联系电话";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(15, 136);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 36;
            this.label30.Text = "联系人";
            // 
            // txtBianhao
            // 
            // 
            // 
            // 
            this.txtBianhao.Border.Class = "TextBoxBorder";
            this.txtBianhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBianhao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBianhao.Location = new System.Drawing.Point(88, 89);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.ReadOnly = true;
            this.txtBianhao.Size = new System.Drawing.Size(145, 21);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "编号";
            // 
            // txtpingming
            // 
            // 
            // 
            // 
            this.txtpingming.Border.Class = "TextBoxBorder";
            this.txtpingming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingming.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpingming.Location = new System.Drawing.Point(326, 89);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.PreventEnterBeep = true;
            this.txtpingming.Size = new System.Drawing.Size(145, 21);
            this.txtpingming.TabIndex = 1;
            this.txtpingming.WatermarkText = "仓库名称";
            // 
            // txtlianxidianhua
            // 
            // 
            // 
            // 
            this.txtlianxidianhua.Border.Class = "TextBoxBorder";
            this.txtlianxidianhua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlianxidianhua.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlianxidianhua.Location = new System.Drawing.Point(326, 132);
            this.txtlianxidianhua.Name = "txtlianxidianhua";
            this.txtlianxidianhua.PreventEnterBeep = true;
            this.txtlianxidianhua.Size = new System.Drawing.Size(145, 21);
            this.txtlianxidianhua.TabIndex = 64;
            // 
            // txtlianxiren
            // 
            // 
            // 
            // 
            this.txtlianxiren.Border.Class = "TextBoxBorder";
            this.txtlianxiren.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlianxiren.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlianxiren.Location = new System.Drawing.Point(86, 132);
            this.txtlianxiren.Name = "txtlianxiren";
            this.txtlianxiren.PreventEnterBeep = true;
            this.txtlianxiren.Size = new System.Drawing.Size(145, 21);
            this.txtlianxiren.TabIndex = 63;
            // 
            // txtdizhi
            // 
            // 
            // 
            // 
            this.txtdizhi.Border.Class = "TextBoxBorder";
            this.txtdizhi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdizhi.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdizhi.Location = new System.Drawing.Point(88, 178);
            this.txtdizhi.Name = "txtdizhi";
            this.txtdizhi.PreventEnterBeep = true;
            this.txtdizhi.Size = new System.Drawing.Size(383, 21);
            this.txtdizhi.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(15, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 87;
            this.label10.Text = "公司地址";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "样布库";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "五金仓库";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "原料仓库";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "半成品仓库";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "次品仓库";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "成品仓库";
            // 
            // 新增仓库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 214);
            this.Controls.Add(this.txtdizhi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtlianxidianhua);
            this.Controls.Add(this.txtlianxiren);
            this.Controls.Add(this.txtpingming);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增仓库";
            this.Text = "新增仓库";
            this.Load += new System.EventHandler(this.新增品种_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingming;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlianxidianhua;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlianxiren;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdizhi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem 仓库类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbleixing;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
    }
}