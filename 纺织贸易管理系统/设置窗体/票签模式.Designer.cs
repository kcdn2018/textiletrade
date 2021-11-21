
namespace 纺织贸易管理系统.设置窗体
{
    partial class 票签模式
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “票签模式.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “票签模式.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.txtBianhao = new Sunny.UI.UITextBox();
            this.cmbMoban = new Sunny.UI.UIComboBox();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.cmbprinters = new Sunny.UI.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "布料编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "标签模板";
            // 
            // txtBianhao
            // 
            this.txtBianhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBianhao.FillColor = System.Drawing.Color.White;
            this.txtBianhao.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtBianhao.Location = new System.Drawing.Point(148, 79);
            this.txtBianhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBianhao.Maximum = 2147483647D;
            this.txtBianhao.Minimum = -2147483648D;
            this.txtBianhao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.Padding = new System.Windows.Forms.Padding(5);
            this.txtBianhao.Size = new System.Drawing.Size(150, 29);
            this.txtBianhao.TabIndex = 2;
            this.txtBianhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBianhao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBianhao_KeyDown);
            // 
            // cmbMoban
            // 
            this.cmbMoban.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbMoban.FillColor = System.Drawing.Color.White;
            this.cmbMoban.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbMoban.Location = new System.Drawing.Point(148, 155);
            this.cmbMoban.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMoban.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbMoban.Name = "cmbMoban";
            this.cmbMoban.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbMoban.Size = new System.Drawing.Size(150, 29);
            this.cmbMoban.TabIndex = 3;
            this.cmbMoban.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbMoban.SelectedIndexChanged += new System.EventHandler(this.cmbMoban_SelectedIndexChanged);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolButton1.Location = new System.Drawing.Point(148, 292);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.TabIndex = 4;
            this.uiSymbolButton1.Text = "打印票签";
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // cmbprinters
            // 
            this.cmbprinters.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbprinters.FillColor = System.Drawing.Color.White;
            this.cmbprinters.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbprinters.Location = new System.Drawing.Point(148, 225);
            this.cmbprinters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbprinters.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbprinters.Name = "cmbprinters";
            this.cmbprinters.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbprinters.Size = new System.Drawing.Size(150, 29);
            this.cmbprinters.TabIndex = 6;
            this.cmbprinters.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbprinters.SelectedIndexChanged += new System.EventHandler(this.cmbprinters_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "标签打印机";
            // 
            // 票签模式
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 364);
            this.Controls.Add(this.cmbprinters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.cmbMoban);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "票签模式";
            this.Text = "票签模式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtBianhao;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbMoban;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton uiSymbolButton1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbprinters;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label3;
    }
}