namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增支架
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增支架.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增支架.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增支架));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtckbh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtweizhi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbleixing = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
            // 
            // txtBianhao
            // 
            // 
            // 
            // 
            this.txtBianhao.Border.Class = "TextBoxBorder";
            this.txtBianhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBianhao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBianhao.Location = new System.Drawing.Point(91, 62);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.Size = new System.Drawing.Size(145, 23);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "支架号";
            // 
            // txtckbh
            // 
            // 
            // 
            // 
            this.txtckbh.Border.Class = "TextBoxBorder";
            this.txtckbh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtckbh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtckbh.Location = new System.Drawing.Point(91, 168);
            this.txtckbh.Name = "txtckbh";
            this.txtckbh.PreventEnterBeep = true;
            this.txtckbh.Size = new System.Drawing.Size(145, 23);
            this.txtckbh.TabIndex = 1;
            this.txtckbh.WatermarkText = "仓库编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 89;
            this.label3.Text = "仓库编号";
            // 
            // txtweizhi
            // 
            // 
            // 
            // 
            this.txtweizhi.Border.Class = "TextBoxBorder";
            this.txtweizhi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtweizhi.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtweizhi.Location = new System.Drawing.Point(91, 115);
            this.txtweizhi.Name = "txtweizhi";
            this.txtweizhi.PreventEnterBeep = true;
            this.txtweizhi.Size = new System.Drawing.Size(145, 23);
            this.txtweizhi.TabIndex = 92;
            this.txtweizhi.WatermarkText = "位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 91;
            this.label4.Text = "位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "仓库名称";
            // 
            // cmbleixing
            // 
            this.cmbleixing.DisplayMember = "Text";
            this.cmbleixing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbleixing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbleixing.FormattingEnabled = true;
            this.cmbleixing.ItemHeight = 18;
            this.cmbleixing.Location = new System.Drawing.Point(91, 221);
            this.cmbleixing.Name = "cmbleixing";
            this.cmbleixing.Size = new System.Drawing.Size(145, 24);
            this.cmbleixing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbleixing.TabIndex = 90;
            this.cmbleixing.Text = "成品仓库";
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
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiSymbolButton1.Location = new System.Drawing.Point(80, 281);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.Symbol = 61639;
            this.uiSymbolButton1.TabIndex = 93;
            this.uiSymbolButton1.Text = "保存";
            this.uiSymbolButton1.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 新增支架
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 334);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.txtweizhi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbleixing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtckbh);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增支架";
            this.Text = "新增支架";
            this.Load += new System.EventHandler(this.新增品种_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtckbh;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtweizhi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbleixing;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
    }
}