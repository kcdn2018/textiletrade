
namespace 纺织贸易管理系统.新增窗体
{
    partial class 流转登记
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “流转登记.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “流转登记.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.cmbjitaihao = new Sunny.UI.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbeizhu = new Sunny.UI.UITextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtliuzhuankaNum = new Sunny.UI.UITextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdanjunum = new Sunny.UI.UITextBox();
            this.txtNum = new Sunny.UI.UITextBox();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.cmbcishu = new Sunny.UI.UIComboBox();
            this.cmbgongxv = new Sunny.UI.UIComboBox();
            this.cmbjigong = new Sunny.UI.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // cmbjitaihao
            // 
            this.cmbjitaihao.FillColor = System.Drawing.Color.White;
            this.cmbjitaihao.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbjitaihao.Location = new System.Drawing.Point(363, 243);
            this.cmbjitaihao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbjitaihao.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbjitaihao.Name = "cmbjitaihao";
            this.cmbjitaihao.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbjitaihao.Size = new System.Drawing.Size(150, 29);
            this.cmbjitaihao.TabIndex = 37;
            this.cmbjitaihao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 36;
            this.label9.Text = "机台号：";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbeizhu.FillColor = System.Drawing.Color.White;
            this.txtbeizhu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtbeizhu.Location = new System.Drawing.Point(109, 308);
            this.txtbeizhu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbeizhu.Maximum = 2147483647D;
            this.txtbeizhu.Minimum = -2147483648D;
            this.txtbeizhu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Padding = new System.Windows.Forms.Padding(5);
            this.txtbeizhu.ReadOnly = true;
            this.txtbeizhu.Size = new System.Drawing.Size(404, 29);
            this.txtbeizhu.TabIndex = 35;
            this.txtbeizhu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 21);
            this.label8.TabIndex = 34;
            this.label8.Text = "备注：";
            // 
            // txtliuzhuankaNum
            // 
            this.txtliuzhuankaNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtliuzhuankaNum.FillColor = System.Drawing.Color.White;
            this.txtliuzhuankaNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtliuzhuankaNum.Location = new System.Drawing.Point(363, 51);
            this.txtliuzhuankaNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtliuzhuankaNum.Maximum = 2147483647D;
            this.txtliuzhuankaNum.Minimum = -2147483648D;
            this.txtliuzhuankaNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtliuzhuankaNum.Name = "txtliuzhuankaNum";
            this.txtliuzhuankaNum.Padding = new System.Windows.Forms.Padding(5);
            this.txtliuzhuankaNum.Size = new System.Drawing.Size(150, 29);
            this.txtliuzhuankaNum.TabIndex = 32;
            this.txtliuzhuankaNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtliuzhuankaNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtliuzhuankaNum_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "流转卡号：";
            // 
            // txtdanjunum
            // 
            this.txtdanjunum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdanjunum.FillColor = System.Drawing.Color.White;
            this.txtdanjunum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtdanjunum.Location = new System.Drawing.Point(363, 177);
            this.txtdanjunum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdanjunum.Maximum = 2147483647D;
            this.txtdanjunum.Minimum = -2147483648D;
            this.txtdanjunum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtdanjunum.Name = "txtdanjunum";
            this.txtdanjunum.Padding = new System.Windows.Forms.Padding(5);
            this.txtdanjunum.ReadOnly = true;
            this.txtdanjunum.Size = new System.Drawing.Size(150, 29);
            this.txtdanjunum.TabIndex = 31;
            this.txtdanjunum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNum
            // 
            this.txtNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNum.FillColor = System.Drawing.Color.White;
            this.txtNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtNum.Location = new System.Drawing.Point(109, 177);
            this.txtNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNum.Maximum = 2147483647D;
            this.txtNum.Minimum = -2147483648D;
            this.txtNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtNum.Name = "txtNum";
            this.txtNum.Padding = new System.Windows.Forms.Padding(5);
            this.txtNum.Size = new System.Drawing.Size(150, 29);
            this.txtNum.TabIndex = 30;
            this.txtNum.Text = "0.00";
            this.txtNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNum.Type = Sunny.UI.UITextBox.UIEditType.Double;
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDatePicker1.Location = new System.Drawing.Point(363, 114);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(150, 29);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 29;
            this.uiDatePicker1.Text = "2021-05-28";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2021, 5, 28, 0, 0, 0, 0);
            // 
            // cmbcishu
            // 
            this.cmbcishu.FillColor = System.Drawing.Color.White;
            this.cmbcishu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbcishu.Location = new System.Drawing.Point(109, 243);
            this.cmbcishu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbcishu.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbcishu.Name = "cmbcishu";
            this.cmbcishu.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbcishu.Size = new System.Drawing.Size(150, 29);
            this.cmbcishu.TabIndex = 28;
            this.cmbcishu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbgongxv
            // 
            this.cmbgongxv.FillColor = System.Drawing.Color.White;
            this.cmbgongxv.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbgongxv.Location = new System.Drawing.Point(109, 51);
            this.cmbgongxv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbgongxv.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbgongxv.Name = "cmbgongxv";
            this.cmbgongxv.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbgongxv.Size = new System.Drawing.Size(150, 29);
            this.cmbgongxv.TabIndex = 27;
            this.cmbgongxv.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbgongxv.TextChanged += new System.EventHandler(this.cmbgongxv_TextChanged);
            // 
            // cmbjigong
            // 
            this.cmbjigong.FillColor = System.Drawing.Color.White;
            this.cmbjigong.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbjigong.Location = new System.Drawing.Point(109, 114);
            this.cmbjigong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbjigong.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbjigong.Name = "cmbjigong";
            this.cmbjigong.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbjigong.Size = new System.Drawing.Size(150, 29);
            this.cmbjigong.TabIndex = 26;
            this.cmbjigong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbjigong.TextChanged += new System.EventHandler(this.cmbjigong_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "单据数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "操作日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "工序次数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "工序名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "操作员：";
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolButton1.Location = new System.Drawing.Point(177, 357);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.TabIndex = 38;
            this.uiSymbolButton1.Text = "确定";
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolButton2.Location = new System.Drawing.Point(315, 357);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.uiSymbolButton2.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Red;
            this.uiSymbolButton2.StyleCustomMode = true;
            this.uiSymbolButton2.Symbol = 61453;
            this.uiSymbolButton2.TabIndex = 39;
            this.uiSymbolButton2.Text = "退出";
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // 流转登记
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 406);
            this.Controls.Add(this.uiSymbolButton2);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.cmbjitaihao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtbeizhu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtliuzhuankaNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtdanjunum);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.uiDatePicker1);
            this.Controls.Add(this.cmbcishu);
            this.Controls.Add(this.cmbgongxv);
            this.Controls.Add(this.cmbjigong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "流转登记";
            this.Text = "流转登记";
            this.Load += new System.EventHandler(this.流转登记_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbjitaihao;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label9;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtbeizhu;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label8;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtliuzhuankaNum;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label7;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtdanjunum;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtNum;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatePicker uiDatePicker1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbcishu;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbgongxv;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cmbjigong;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton uiSymbolButton1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton uiSymbolButton2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
    }
}