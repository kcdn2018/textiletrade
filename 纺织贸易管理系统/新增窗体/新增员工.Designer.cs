﻿namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增员工
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增员工.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增员工.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增员工));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtpingming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlianxidianhua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtbumeng = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtkaihuyinghang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtyinghangzhanghao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtshenfengzheng = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbXingbie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(248, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "姓名";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(248, 145);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 17);
            this.label29.TabIndex = 37;
            this.label29.Text = "联系电话";
            // 
            // txtBianhao
            // 
            // 
            // 
            // 
            this.txtBianhao.Border.Class = "TextBoxBorder";
            this.txtBianhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBianhao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBianhao.Location = new System.Drawing.Point(86, 87);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.ReadOnly = true;
            this.txtBianhao.Size = new System.Drawing.Size(145, 23);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "编号";
            // 
            // txtpingming
            // 
            // 
            // 
            // 
            this.txtpingming.Border.Class = "TextBoxBorder";
            this.txtpingming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingming.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpingming.Location = new System.Drawing.Point(324, 87);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.PreventEnterBeep = true;
            this.txtpingming.Size = new System.Drawing.Size(145, 23);
            this.txtpingming.TabIndex = 1;
            this.txtpingming.WatermarkText = "公司名称";
            // 
            // txtlianxidianhua
            // 
            // 
            // 
            // 
            this.txtlianxidianhua.Border.Class = "TextBoxBorder";
            this.txtlianxidianhua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlianxidianhua.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlianxidianhua.Location = new System.Drawing.Point(324, 142);
            this.txtlianxidianhua.Name = "txtlianxidianhua";
            this.txtlianxidianhua.PreventEnterBeep = true;
            this.txtlianxidianhua.Size = new System.Drawing.Size(145, 23);
            this.txtlianxidianhua.TabIndex = 64;
            // 
            // txtbumeng
            // 
            // 
            // 
            // 
            this.txtbumeng.Border.Class = "TextBoxBorder";
            this.txtbumeng.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbumeng.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbumeng.Location = new System.Drawing.Point(84, 200);
            this.txtbumeng.Name = "txtbumeng";
            this.txtbumeng.PreventEnterBeep = true;
            this.txtbumeng.Size = new System.Drawing.Size(145, 23);
            this.txtbumeng.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(248, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "身份证";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "部门";
            // 
            // txtkaihuyinghang
            // 
            // 
            // 
            // 
            this.txtkaihuyinghang.Border.Class = "TextBoxBorder";
            this.txtkaihuyinghang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkaihuyinghang.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkaihuyinghang.Location = new System.Drawing.Point(84, 254);
            this.txtkaihuyinghang.Name = "txtkaihuyinghang";
            this.txtkaihuyinghang.PreventEnterBeep = true;
            this.txtkaihuyinghang.Size = new System.Drawing.Size(145, 23);
            this.txtkaihuyinghang.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "开户银行";
            // 
            // txtyinghangzhanghao
            // 
            // 
            // 
            // 
            this.txtyinghangzhanghao.Border.Class = "TextBoxBorder";
            this.txtyinghangzhanghao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtyinghangzhanghao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyinghangzhanghao.Location = new System.Drawing.Point(324, 254);
            this.txtyinghangzhanghao.Name = "txtyinghangzhanghao";
            this.txtyinghangzhanghao.PreventEnterBeep = true;
            this.txtyinghangzhanghao.Size = new System.Drawing.Size(145, 23);
            this.txtyinghangzhanghao.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(248, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 85;
            this.label9.Text = "银行账号";
            // 
            // txtshenfengzheng
            // 
            // 
            // 
            // 
            this.txtshenfengzheng.Border.Class = "TextBoxBorder";
            this.txtshenfengzheng.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtshenfengzheng.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtshenfengzheng.Location = new System.Drawing.Point(324, 200);
            this.txtshenfengzheng.Name = "txtshenfengzheng";
            this.txtshenfengzheng.PreventEnterBeep = true;
            this.txtshenfengzheng.Size = new System.Drawing.Size(145, 23);
            this.txtshenfengzheng.TabIndex = 97;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(10, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 98;
            this.label15.Text = "性别";
            // 
            // cmbXingbie
            // 
            this.cmbXingbie.DisplayMember = "Text";
            this.cmbXingbie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbXingbie.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbXingbie.FormattingEnabled = true;
            this.cmbXingbie.ItemHeight = 18;
            this.cmbXingbie.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbXingbie.Location = new System.Drawing.Point(86, 141);
            this.cmbXingbie.Name = "cmbXingbie";
            this.cmbXingbie.Size = new System.Drawing.Size(145, 24);
            this.cmbXingbie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbXingbie.TabIndex = 99;
            this.cmbXingbie.Text = "男";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "男";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "女";
            // 
            // 新增员工
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 286);
            this.Controls.Add(this.cmbXingbie);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtshenfengzheng);
            this.Controls.Add(this.txtyinghangzhanghao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtkaihuyinghang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbumeng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtlianxidianhua);
            this.Controls.Add(this.txtpingming);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增员工";
            this.Text = "新增员工";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingming;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlianxidianhua;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbumeng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkaihuyinghang;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtyinghangzhanghao;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtshenfengzheng;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbXingbie;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}