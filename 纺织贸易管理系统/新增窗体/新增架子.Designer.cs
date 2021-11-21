namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增架子
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增架子.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增架子.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增架子));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtguishuo = new Sunny.UI.UITextBox();
            this.txtcunfang = new Sunny.UI.UITextBox();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(376, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
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
            this.txtBianhao.Location = new System.Drawing.Point(80, 86);
            this.txtBianhao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.Size = new System.Drawing.Size(260, 23);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "支架号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 89;
            this.label3.Text = "归属";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 94;
            this.label2.Text = "存放状态";
            // 
            // txtguishuo
            // 
            this.txtguishuo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtguishuo.FillColor = System.Drawing.Color.White;
            this.txtguishuo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtguishuo.Location = new System.Drawing.Point(80, 139);
            this.txtguishuo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtguishuo.Maximum = 2147483647D;
            this.txtguishuo.Minimum = -2147483648D;
            this.txtguishuo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtguishuo.Name = "txtguishuo";
            this.txtguishuo.Padding = new System.Windows.Forms.Padding(5);
            this.txtguishuo.Size = new System.Drawing.Size(260, 23);
            this.txtguishuo.TabIndex = 95;
            this.txtguishuo.Text = "自己公司";
            this.txtguishuo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcunfang
            // 
            this.txtcunfang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcunfang.FillColor = System.Drawing.Color.White;
            this.txtcunfang.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtcunfang.Location = new System.Drawing.Point(81, 191);
            this.txtcunfang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtcunfang.Maximum = 2147483647D;
            this.txtcunfang.Minimum = -2147483648D;
            this.txtcunfang.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtcunfang.Name = "txtcunfang";
            this.txtcunfang.Padding = new System.Windows.Forms.Padding(5);
            this.txtcunfang.Size = new System.Drawing.Size(188, 23);
            this.txtcunfang.TabIndex = 96;
            this.txtcunfang.Text = "自己公司";
            this.txtcunfang.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
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
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton1.Location = new System.Drawing.Point(266, 191);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(64, 23);
            this.uiButton1.TabIndex = 97;
            this.uiButton1.Text = "选择客户";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // 新增架子
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 239);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.txtcunfang);
            this.Controls.Add(this.txtguishuo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1344, 842);
            this.MinimizeBox = false;
            this.Name = "新增架子";
            this.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.Text = "新增支架";
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private System.Windows.Forms.Label label2;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtguishuo;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtcunfang;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton uiButton1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
    }
}