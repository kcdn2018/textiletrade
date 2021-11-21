namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增物流
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增物流.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增物流.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增物流));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtcheliangleixing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtchepai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
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
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(245, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "名称";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(245, 145);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 17);
            this.label29.TabIndex = 37;
            this.label29.Text = "车辆类型";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(10, 148);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 17);
            this.label30.TabIndex = 36;
            this.label30.Text = "车牌号：";
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
            this.txtBianhao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBianhao.ForeColor = System.Drawing.Color.Black;
            this.txtBianhao.Location = new System.Drawing.Point(83, 89);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.ReadOnly = true;
            this.txtBianhao.Size = new System.Drawing.Size(145, 23);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "编号";
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtname.Border.Class = "TextBoxBorder";
            this.txtname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtname.DisabledBackColor = System.Drawing.Color.White;
            this.txtname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.Location = new System.Drawing.Point(321, 89);
            this.txtname.Name = "txtname";
            this.txtname.PreventEnterBeep = true;
            this.txtname.Size = new System.Drawing.Size(145, 23);
            this.txtname.TabIndex = 1;
            this.txtname.WatermarkText = "物流公司名称";
            // 
            // txtcheliangleixing
            // 
            this.txtcheliangleixing.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtcheliangleixing.Border.Class = "TextBoxBorder";
            this.txtcheliangleixing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtcheliangleixing.DisabledBackColor = System.Drawing.Color.White;
            this.txtcheliangleixing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcheliangleixing.ForeColor = System.Drawing.Color.Black;
            this.txtcheliangleixing.Location = new System.Drawing.Point(321, 143);
            this.txtcheliangleixing.Name = "txtcheliangleixing";
            this.txtcheliangleixing.PreventEnterBeep = true;
            this.txtcheliangleixing.Size = new System.Drawing.Size(145, 23);
            this.txtcheliangleixing.TabIndex = 64;
            // 
            // txtchepai
            // 
            this.txtchepai.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtchepai.Border.Class = "TextBoxBorder";
            this.txtchepai.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtchepai.DisabledBackColor = System.Drawing.Color.White;
            this.txtchepai.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtchepai.ForeColor = System.Drawing.Color.Black;
            this.txtchepai.Location = new System.Drawing.Point(81, 143);
            this.txtchepai.Name = "txtchepai";
            this.txtchepai.PreventEnterBeep = true;
            this.txtchepai.Size = new System.Drawing.Size(145, 23);
            this.txtchepai.TabIndex = 63;
            // 
            // 新增物流
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 179);
            this.Controls.Add(this.txtcheliangleixing);
            this.Controls.Add(this.txtchepai);
            this.Controls.Add(this.txtname);
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
            this.Name = "新增物流";
            this.Text = "新增物流";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtname;
        private DevComponents.DotNetBar.Controls.TextBoxX txtcheliangleixing;
        private DevComponents.DotNetBar.Controls.TextBoxX txtchepai;
    }
}