namespace 纺织贸易管理系统.设置窗体
{
    partial class 打印设置窗体
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(打印设置窗体));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbprinters = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtNum = new System.Windows.Forms.NumericUpDown();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(46, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "打印机选择";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(46, 91);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "打印份数";
            // 
            // cmbprinters
            // 
            this.cmbprinters.DisplayMember = "Text";
            this.cmbprinters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbprinters.FormattingEnabled = true;
            this.cmbprinters.ItemHeight = 15;
            this.cmbprinters.Location = new System.Drawing.Point(127, 40);
            this.cmbprinters.Name = "cmbprinters";
            this.cmbprinters.Size = new System.Drawing.Size(164, 21);
            this.cmbprinters.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbprinters.TabIndex = 2;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(127, 95);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(87, 21);
            this.txtNum.TabIndex = 3;
            this.txtNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(139, 159);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(220, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "单份连续";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // 打印设置窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 204);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.cmbprinters);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "打印设置窗体";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印设置";
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbprinters;
        private System.Windows.Forms.NumericUpDown txtNum;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}