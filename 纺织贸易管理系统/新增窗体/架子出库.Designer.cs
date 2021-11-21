
namespace 纺织贸易管理系统.新增窗体
{
    partial class 架子出库
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “架子出库.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “架子出库.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.uiTransfer1 = new Sunny.UI.UITransfer();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.确认出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkehu = new DevExpress.XtraEditors.ButtonEdit();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbeizhu = new Sunny.UI.UITextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTransfer1
            // 
            this.uiTransfer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiTransfer1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.uiTransfer1.Location = new System.Drawing.Point(0, 30);
            this.uiTransfer1.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.uiTransfer1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTransfer1.Name = "uiTransfer1";
            this.uiTransfer1.Padding = new System.Windows.Forms.Padding(1);
            this.uiTransfer1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiTransfer1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiTransfer1.Size = new System.Drawing.Size(517, 454);
            this.uiTransfer1.TabIndex = 0;
            this.uiTransfer1.Text = "uiTransfer1";
            this.uiTransfer1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(11, 5);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "在库架子";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(298, 5);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "要出库架子";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确认出库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 40);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 确认出库ToolStripMenuItem
            // 
            this.确认出库ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.确认出库ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.确认出库ToolStripMenuItem.Name = "确认出库ToolStripMenuItem";
            this.确认出库ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.确认出库ToolStripMenuItem.Text = "确认出库";
            this.确认出库ToolStripMenuItem.Click += new System.EventHandler(this.确认出库ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(239, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "客户名称";
            // 
            // txtkehu
            // 
            this.txtkehu.Location = new System.Drawing.Point(301, 6);
            this.txtkehu.Name = "txtkehu";
            this.txtkehu.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkehu.Properties.Appearance.Options.UseFont = true;
            this.txtkehu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtkehu.Size = new System.Drawing.Size(138, 18);
            this.txtkehu.TabIndex = 8;
            this.txtkehu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtkehu_ButtonClick);
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDatePicker1.Location = new System.Drawing.Point(69, 5);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(150, 21);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 10;
            this.uiDatePicker1.Text = "2021-06-02";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2021, 6, 2, 17, 4, 4, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "日期";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.txtbeizhu);
            this.uiPanel2.Controls.Add(this.label1);
            this.uiPanel2.Controls.Add(this.uiDatePicker1);
            this.uiPanel2.Controls.Add(this.txtkehu);
            this.uiPanel2.Controls.Add(this.label3);
            this.uiPanel2.Controls.Add(this.label2);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 68);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(517, 91);
            this.uiPanel2.TabIndex = 14;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiTransfer1);
            this.uiPanel3.Controls.Add(this.uiLabel1);
            this.uiPanel3.Controls.Add(this.uiLabel2);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel3.Location = new System.Drawing.Point(0, 159);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(517, 484);
            this.uiPanel3.TabIndex = 15;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "备注";
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbeizhu.FillColor = System.Drawing.Color.White;
            this.txtbeizhu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtbeizhu.Location = new System.Drawing.Point(69, 43);
            this.txtbeizhu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbeizhu.Maximum = 2147483647D;
            this.txtbeizhu.Minimum = -2147483648D;
            this.txtbeizhu.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtbeizhu.Multiline = true;
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.Padding = new System.Windows.Forms.Padding(5);
            this.txtbeizhu.Size = new System.Drawing.Size(370, 39);
            this.txtbeizhu.TabIndex = 13;
            this.txtbeizhu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 架子出库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 643);
            this.Controls.Add(this.uiPanel3);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1344, 842);
            this.MinimizeBox = false;
            this.Name = "架子出库";
            this.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "架子出库";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtkehu.Properties)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.uiPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITransfer”(是否缺少程序集引用?)
        private Sunny.UI.UITransfer uiTransfer1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITransfer”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 确认出库ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ButtonEdit txtkehu;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatePicker uiDatePicker1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatePicker”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label3;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPanel”(是否缺少程序集引用?)
        private Sunny.UI.UIPanel uiPanel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPanel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPanel”(是否缺少程序集引用?)
        private Sunny.UI.UIPanel uiPanel3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPanel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtbeizhu;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Label label1;
    }
}