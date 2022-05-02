
namespace 纺织贸易管理系统.其他窗体
{
    partial class 库位登记
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
            this.cmb_kuwei = new Sunny.UI.UIComboBox();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label1.Location = new System.Drawing.Point(36, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "库位";
            // 
            // cmb_kuwei
            // 
            this.cmb_kuwei.DataSource = null;
            this.cmb_kuwei.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_kuwei.FillColor = System.Drawing.Color.White;
            this.cmb_kuwei.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cmb_kuwei.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cmb_kuwei.Location = new System.Drawing.Point(97, 68);
            this.cmb_kuwei.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_kuwei.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_kuwei.Name = "cmb_kuwei";
            this.cmb_kuwei.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_kuwei.Size = new System.Drawing.Size(150, 29);
            this.cmb_kuwei.TabIndex = 1;
            this.cmb_kuwei.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(110, 134);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.TabIndex = 2;
            this.uiSymbolButton1.Text = "确定";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // 库位登记
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 197);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.cmb_kuwei);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "库位登记";
            this.Text = "库位登记";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
            this.Load += new System.EventHandler(this.库位登记_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIComboBox cmb_kuwei;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
    }
}