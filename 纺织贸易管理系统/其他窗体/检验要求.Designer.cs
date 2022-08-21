
namespace 纺织贸易管理系统.其他窗体
{
    partial class 检验要求
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbmaitou = new System.Windows.Forms.ComboBox();
            this.cmbdanwei = new System.Windows.Forms.ComboBox();
            this.txtbeizhu = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "唛头模板";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "唛头单位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "其他要求";
            // 
            // cmbmaitou
            // 
            this.cmbmaitou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmaitou.FormattingEnabled = true;
            this.cmbmaitou.Location = new System.Drawing.Point(97, 56);
            this.cmbmaitou.Name = "cmbmaitou";
            this.cmbmaitou.Size = new System.Drawing.Size(223, 25);
            this.cmbmaitou.TabIndex = 3;
            // 
            // cmbdanwei
            // 
            this.cmbdanwei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdanwei.FormattingEnabled = true;
            this.cmbdanwei.Items.AddRange(new object[] {
            "米",
            "码",
            "公斤"});
            this.cmbdanwei.Location = new System.Drawing.Point(97, 105);
            this.cmbdanwei.Name = "cmbdanwei";
            this.cmbdanwei.Size = new System.Drawing.Size(121, 25);
            this.cmbdanwei.TabIndex = 4;
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Location = new System.Drawing.Point(97, 155);
            this.txtbeizhu.Multiline = true;
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Size = new System.Drawing.Size(223, 121);
            this.txtbeizhu.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "直接退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 检验要求
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(338, 355);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbeizhu);
            this.Controls.Add(this.cmbdanwei);
            this.Controls.Add(this.cmbmaitou);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "检验要求";
            this.Text = "检验要求";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.检验要求_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbmaitou;
        private System.Windows.Forms.ComboBox cmbdanwei;
        private System.Windows.Forms.TextBox txtbeizhu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}