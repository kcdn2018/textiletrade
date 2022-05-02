
namespace 纺织贸易管理系统.其他窗体
{
    partial class 账户转账
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtRax = new Sunny.UI.UITextBox();
            this.txt_zhuanchu = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txt_zhuanru = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.cmb_zhuanchu = new Sunny.UI.UIComboBox();
            this.cmb_zhuanru = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txt_Danhao = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.cmb_style = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(17, 108);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "转出账户";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(308, 108);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(71, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "转入账户";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(17, 160);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(71, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "结转汇率";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRax
            // 
            this.txtRax.ButtonSymbol = 61761;
            this.txtRax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRax.Enabled = false;
            this.txtRax.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRax.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtRax.Location = new System.Drawing.Point(95, 157);
            this.txtRax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRax.Maximum = 2147483647D;
            this.txtRax.Minimum = -2147483648D;
            this.txtRax.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRax.Name = "txtRax";
            this.txtRax.Size = new System.Drawing.Size(177, 29);
            this.txtRax.TabIndex = 5;
            this.txtRax.Text = "0.00";
            this.txtRax.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtRax.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRax.TextChanged += new System.EventHandler(this.txtRax_TextChanged);
            // 
            // txt_zhuanchu
            // 
            this.txt_zhuanchu.ButtonSymbol = 61761;
            this.txt_zhuanchu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_zhuanchu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txt_zhuanchu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_zhuanchu.Location = new System.Drawing.Point(95, 209);
            this.txt_zhuanchu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_zhuanchu.Maximum = 2147483647D;
            this.txt_zhuanchu.Minimum = -2147483648D;
            this.txt_zhuanchu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_zhuanchu.Name = "txt_zhuanchu";
            this.txt_zhuanchu.Size = new System.Drawing.Size(177, 29);
            this.txt_zhuanchu.TabIndex = 7;
            this.txt_zhuanchu.Text = "0.00";
            this.txt_zhuanchu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_zhuanchu.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txt_zhuanchu.TextChanged += new System.EventHandler(this.txt_zhuanchu_TextChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.Location = new System.Drawing.Point(17, 214);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(71, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "转出金额";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_zhuanru
            // 
            this.txt_zhuanru.ButtonSymbol = 61761;
            this.txt_zhuanru.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_zhuanru.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txt_zhuanru.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_zhuanru.Location = new System.Drawing.Point(372, 211);
            this.txt_zhuanru.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_zhuanru.Maximum = 2147483647D;
            this.txt_zhuanru.Minimum = -2147483648D;
            this.txt_zhuanru.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_zhuanru.Name = "txt_zhuanru";
            this.txt_zhuanru.Size = new System.Drawing.Size(177, 29);
            this.txt_zhuanru.TabIndex = 9;
            this.txt_zhuanru.Text = "0.00";
            this.txt_zhuanru.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_zhuanru.Type = Sunny.UI.UITextBox.UIEditType.Double;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel5.Location = new System.Drawing.Point(308, 214);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(71, 23);
            this.uiLabel5.TabIndex = 8;
            this.uiLabel5.Text = "转入金额";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(246, 267);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.TabIndex = 10;
            this.uiSymbolButton1.Text = "确定转账";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // cmb_zhuanchu
            // 
            this.cmb_zhuanchu.DataSource = null;
            this.cmb_zhuanchu.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_zhuanchu.FillColor = System.Drawing.Color.White;
            this.cmb_zhuanchu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmb_zhuanchu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_zhuanchu.Location = new System.Drawing.Point(95, 105);
            this.cmb_zhuanchu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_zhuanchu.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_zhuanchu.Name = "cmb_zhuanchu";
            this.cmb_zhuanchu.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_zhuanchu.Size = new System.Drawing.Size(177, 29);
            this.cmb_zhuanchu.TabIndex = 12;
            this.cmb_zhuanchu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_zhuanru
            // 
            this.cmb_zhuanru.DataSource = null;
            this.cmb_zhuanru.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_zhuanru.FillColor = System.Drawing.Color.White;
            this.cmb_zhuanru.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmb_zhuanru.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_zhuanru.Location = new System.Drawing.Point(372, 105);
            this.cmb_zhuanru.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_zhuanru.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_zhuanru.Name = "cmb_zhuanru";
            this.cmb_zhuanru.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_zhuanru.Size = new System.Drawing.Size(177, 29);
            this.cmb_zhuanru.TabIndex = 13;
            this.cmb_zhuanru.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel6.Location = new System.Drawing.Point(17, 53);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(71, 23);
            this.uiLabel6.TabIndex = 14;
            this.uiLabel6.Text = "单号";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Danhao
            // 
            this.txt_Danhao.ButtonSymbol = 61761;
            this.txt_Danhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Danhao.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txt_Danhao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txt_Danhao.Location = new System.Drawing.Point(95, 53);
            this.txt_Danhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Danhao.Maximum = 2147483647D;
            this.txt_Danhao.Minimum = -2147483648D;
            this.txt_Danhao.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Danhao.Name = "txt_Danhao";
            this.txt_Danhao.Size = new System.Drawing.Size(177, 29);
            this.txt_Danhao.TabIndex = 15;
            this.txt_Danhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel7.Location = new System.Drawing.Point(308, 53);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(71, 23);
            this.uiLabel7.TabIndex = 16;
            this.uiLabel7.Text = "日期";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDatePicker1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiDatePicker1.Location = new System.Drawing.Point(372, 53);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(177, 29);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 17;
            this.uiDatePicker1.Text = "2022-02-07";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2022, 2, 7, 16, 59, 44, 240);
            // 
            // cmb_style
            // 
            this.cmb_style.DataSource = null;
            this.cmb_style.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_style.FillColor = System.Drawing.Color.White;
            this.cmb_style.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmb_style.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_style.ItemHeight = 23;
            this.cmb_style.Items.AddRange(new object[] {
            "人民币转人民币",
            "美金转人民币",
            "人民币转美金"});
            this.cmb_style.Location = new System.Drawing.Point(372, 157);
            this.cmb_style.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_style.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_style.Name = "cmb_style";
            this.cmb_style.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_style.Size = new System.Drawing.Size(177, 29);
            this.cmb_style.TabIndex = 18;
            this.cmb_style.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_style.SelectedIndexChanged += new System.EventHandler(this.cmb_style_SelectedIndexChanged);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel8.Location = new System.Drawing.Point(308, 160);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(57, 23);
            this.uiLabel8.TabIndex = 19;
            this.uiLabel8.Text = "转换类型";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 账户转账
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 324);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.cmb_style);
            this.Controls.Add(this.uiDatePicker1);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.txt_Danhao);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.cmb_zhuanru);
            this.Controls.Add(this.cmb_zhuanchu);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.txt_zhuanru);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.txt_zhuanchu);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.txtRax);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "账户转账";
            this.Text = "账户转账";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtRax;
        private Sunny.UI.UITextBox txt_zhuanchu;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txt_zhuanru;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UIComboBox cmb_zhuanchu;
        private Sunny.UI.UIComboBox cmb_zhuanru;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txt_Danhao;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIDatePicker uiDatePicker1;
        private Sunny.UI.UIComboBox cmb_style;
        private Sunny.UI.UILabel uiLabel8;
    }
}