namespace 纺织贸易管理系统.设置窗体
{
    partial class 输入密码
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(输入密码));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtfirst = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtsecond = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(28, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "第一个密码";
            // 
            // txtfirst
            // 
            // 
            // 
            // 
            this.txtfirst.Border.Class = "TextBoxBorder";
            this.txtfirst.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtfirst.Location = new System.Drawing.Point(97, 34);
            this.txtfirst.Name = "txtfirst";
            this.txtfirst.PasswordChar = '*';
            this.txtfirst.PreventEnterBeep = true;
            this.txtfirst.Size = new System.Drawing.Size(126, 21);
            this.txtfirst.TabIndex = 1;
            // 
            // txtsecond
            // 
            // 
            // 
            // 
            this.txtsecond.Border.Class = "TextBoxBorder";
            this.txtsecond.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsecond.Location = new System.Drawing.Point(97, 81);
            this.txtsecond.Name = "txtsecond";
            this.txtsecond.PasswordChar = '*';
            this.txtsecond.PreventEnterBeep = true;
            this.txtsecond.Size = new System.Drawing.Size(126, 21);
            this.txtsecond.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(28, 81);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "第二个密码";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX1.Location = new System.Drawing.Point(103, 128);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // 输入密码
            // 
            this.AcceptButton = this.buttonX1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 165);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtsecond);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtfirst);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "输入密码";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入密码";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtfirst;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsecond;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}