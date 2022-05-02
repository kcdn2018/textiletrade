namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增供货商
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增供货商.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增供货商.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(新增供货商));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBianhao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtpingming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlianxidianhua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlianxiren = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtbeizhu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtqq = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtkaihuyinghang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtyouxiang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtyinghangzhanghao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdizhi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpingyingma = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtshuihao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtyingkaifapiao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label14 = new System.Windows.Forms.Label();
            this.txtweixing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtqichu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.cmbleixing = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbzhuangtai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtkejiagong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.SaveAll_32x32;
            this.保存ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(73, 36);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(248, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "名称";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(12, 391);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 30;
            this.label22.Text = "备注";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(12, 124);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 37;
            this.label29.Text = "联系电话";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(485, 90);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 36;
            this.label30.Text = "联系人";
            // 
            // txtBianhao
            // 
            this.txtBianhao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBianhao.Border.Class = "TextBoxBorder";
            this.txtBianhao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBianhao.DisabledBackColor = System.Drawing.Color.White;
            this.txtBianhao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBianhao.ForeColor = System.Drawing.Color.Black;
            this.txtBianhao.Location = new System.Drawing.Point(83, 84);
            this.txtBianhao.Name = "txtBianhao";
            this.txtBianhao.PreventEnterBeep = true;
            this.txtBianhao.ReadOnly = true;
            this.txtBianhao.Size = new System.Drawing.Size(145, 21);
            this.txtBianhao.TabIndex = 39;
            this.txtBianhao.WatermarkText = "编号";
            // 
            // txtpingming
            // 
            this.txtpingming.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtpingming.Border.Class = "TextBoxBorder";
            this.txtpingming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingming.DisabledBackColor = System.Drawing.Color.White;
            this.txtpingming.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpingming.ForeColor = System.Drawing.Color.Black;
            this.txtpingming.Location = new System.Drawing.Point(324, 84);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.PreventEnterBeep = true;
            this.txtpingming.Size = new System.Drawing.Size(145, 21);
            this.txtpingming.TabIndex = 1;
            this.txtpingming.WatermarkText = "公司名称";
            this.txtpingming.TextChanged += new System.EventHandler(this.txtpingming_TextChanged);
            // 
            // txtlianxidianhua
            // 
            this.txtlianxidianhua.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtlianxidianhua.Border.Class = "TextBoxBorder";
            this.txtlianxidianhua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlianxidianhua.DisabledBackColor = System.Drawing.Color.White;
            this.txtlianxidianhua.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlianxidianhua.ForeColor = System.Drawing.Color.Black;
            this.txtlianxidianhua.Location = new System.Drawing.Point(83, 120);
            this.txtlianxidianhua.Name = "txtlianxidianhua";
            this.txtlianxidianhua.PreventEnterBeep = true;
            this.txtlianxidianhua.Size = new System.Drawing.Size(145, 21);
            this.txtlianxidianhua.TabIndex = 64;
            // 
            // txtlianxiren
            // 
            this.txtlianxiren.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtlianxiren.Border.Class = "TextBoxBorder";
            this.txtlianxiren.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlianxiren.DisabledBackColor = System.Drawing.Color.White;
            this.txtlianxiren.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlianxiren.ForeColor = System.Drawing.Color.Black;
            this.txtlianxiren.Location = new System.Drawing.Point(561, 86);
            this.txtlianxiren.Name = "txtlianxiren";
            this.txtlianxiren.PreventEnterBeep = true;
            this.txtlianxiren.Size = new System.Drawing.Size(145, 21);
            this.txtlianxiren.TabIndex = 63;
            // 
            // txtbeizhu
            // 
            this.txtbeizhu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtbeizhu.Border.Class = "TextBoxBorder";
            this.txtbeizhu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbeizhu.DisabledBackColor = System.Drawing.Color.White;
            this.txtbeizhu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbeizhu.ForeColor = System.Drawing.Color.Black;
            this.txtbeizhu.Location = new System.Drawing.Point(83, 387);
            this.txtbeizhu.Name = "txtbeizhu";
            this.txtbeizhu.PreventEnterBeep = true;
            this.txtbeizhu.Size = new System.Drawing.Size(385, 21);
            this.txtbeizhu.TabIndex = 72;
            // 
            // txtqq
            // 
            this.txtqq.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtqq.Border.Class = "TextBoxBorder";
            this.txtqq.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtqq.DisabledBackColor = System.Drawing.Color.White;
            this.txtqq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtqq.ForeColor = System.Drawing.Color.Black;
            this.txtqq.Location = new System.Drawing.Point(324, 120);
            this.txtqq.Name = "txtqq";
            this.txtqq.PreventEnterBeep = true;
            this.txtqq.Size = new System.Drawing.Size(145, 21);
            this.txtqq.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(485, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "微信";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(248, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 73;
            this.label4.Text = "QQ";
            // 
            // txtkaihuyinghang
            // 
            this.txtkaihuyinghang.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtkaihuyinghang.Border.Class = "TextBoxBorder";
            this.txtkaihuyinghang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkaihuyinghang.DisabledBackColor = System.Drawing.Color.White;
            this.txtkaihuyinghang.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkaihuyinghang.ForeColor = System.Drawing.Color.Black;
            this.txtkaihuyinghang.Location = new System.Drawing.Point(561, 159);
            this.txtkaihuyinghang.Name = "txtkaihuyinghang";
            this.txtkaihuyinghang.PreventEnterBeep = true;
            this.txtkaihuyinghang.Size = new System.Drawing.Size(145, 21);
            this.txtkaihuyinghang.TabIndex = 80;
            // 
            // txtyouxiang
            // 
            this.txtyouxiang.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtyouxiang.Border.Class = "TextBoxBorder";
            this.txtyouxiang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtyouxiang.DisabledBackColor = System.Drawing.Color.White;
            this.txtyouxiang.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyouxiang.ForeColor = System.Drawing.Color.Black;
            this.txtyouxiang.Location = new System.Drawing.Point(83, 159);
            this.txtyouxiang.Name = "txtyouxiang";
            this.txtyouxiang.PreventEnterBeep = true;
            this.txtyouxiang.Size = new System.Drawing.Size(145, 21);
            this.txtyouxiang.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(485, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "开户银行";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 77;
            this.label6.Text = "邮箱";
            // 
            // txtyinghangzhanghao
            // 
            this.txtyinghangzhanghao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtyinghangzhanghao.Border.Class = "TextBoxBorder";
            this.txtyinghangzhanghao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtyinghangzhanghao.DisabledBackColor = System.Drawing.Color.White;
            this.txtyinghangzhanghao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyinghangzhanghao.ForeColor = System.Drawing.Color.Black;
            this.txtyinghangzhanghao.Location = new System.Drawing.Point(83, 201);
            this.txtyinghangzhanghao.Name = "txtyinghangzhanghao";
            this.txtyinghangzhanghao.PreventEnterBeep = true;
            this.txtyinghangzhanghao.Size = new System.Drawing.Size(145, 21);
            this.txtyinghangzhanghao.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 85;
            this.label9.Text = "银行账号";
            // 
            // txtdizhi
            // 
            this.txtdizhi.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtdizhi.Border.Class = "TextBoxBorder";
            this.txtdizhi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdizhi.DisabledBackColor = System.Drawing.Color.White;
            this.txtdizhi.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdizhi.ForeColor = System.Drawing.Color.Black;
            this.txtdizhi.Location = new System.Drawing.Point(324, 203);
            this.txtdizhi.Name = "txtdizhi";
            this.txtdizhi.PreventEnterBeep = true;
            this.txtdizhi.Size = new System.Drawing.Size(383, 21);
            this.txtdizhi.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(248, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 87;
            this.label10.Text = "公司地址";
            // 
            // txtpingyingma
            // 
            this.txtpingyingma.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtpingyingma.Border.Class = "TextBoxBorder";
            this.txtpingyingma.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpingyingma.DisabledBackColor = System.Drawing.Color.White;
            this.txtpingyingma.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpingyingma.ForeColor = System.Drawing.Color.Black;
            this.txtpingyingma.Location = new System.Drawing.Point(324, 159);
            this.txtpingyingma.Name = "txtpingyingma";
            this.txtpingyingma.PreventEnterBeep = true;
            this.txtpingyingma.Size = new System.Drawing.Size(145, 21);
            this.txtpingyingma.TabIndex = 90;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(248, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 89;
            this.label11.Text = "拼音码";
            // 
            // txtshuihao
            // 
            this.txtshuihao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtshuihao.Border.Class = "TextBoxBorder";
            this.txtshuihao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtshuihao.DisabledBackColor = System.Drawing.Color.White;
            this.txtshuihao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtshuihao.ForeColor = System.Drawing.Color.Black;
            this.txtshuihao.Location = new System.Drawing.Point(83, 243);
            this.txtshuihao.Name = "txtshuihao";
            this.txtshuihao.PreventEnterBeep = true;
            this.txtshuihao.Size = new System.Drawing.Size(145, 21);
            this.txtshuihao.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(12, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 91;
            this.label12.Text = "税号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(248, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 93;
            this.label13.Text = "期初应付款";
            // 
            // txtyingkaifapiao
            // 
            this.txtyingkaifapiao.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtyingkaifapiao.Border.Class = "TextBoxBorder";
            this.txtyingkaifapiao.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtyingkaifapiao.DisabledBackColor = System.Drawing.Color.White;
            this.txtyingkaifapiao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyingkaifapiao.ForeColor = System.Drawing.Color.Black;
            this.txtyingkaifapiao.Location = new System.Drawing.Point(561, 245);
            this.txtyingkaifapiao.Name = "txtyingkaifapiao";
            this.txtyingkaifapiao.PreventEnterBeep = true;
            this.txtyingkaifapiao.Size = new System.Drawing.Size(145, 21);
            this.txtyingkaifapiao.TabIndex = 96;
            this.txtyingkaifapiao.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(485, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 95;
            this.label14.Text = "期初应收票";
            // 
            // txtweixing
            // 
            this.txtweixing.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtweixing.Border.Class = "TextBoxBorder";
            this.txtweixing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtweixing.DisabledBackColor = System.Drawing.Color.White;
            this.txtweixing.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtweixing.ForeColor = System.Drawing.Color.Black;
            this.txtweixing.Location = new System.Drawing.Point(561, 120);
            this.txtweixing.Name = "txtweixing";
            this.txtweixing.PreventEnterBeep = true;
            this.txtweixing.Size = new System.Drawing.Size(145, 21);
            this.txtweixing.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 98;
            this.label7.Text = "供货商类型";
            // 
            // txtqichu
            // 
            this.txtqichu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtqichu.Border.Class = "TextBoxBorder";
            this.txtqichu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtqichu.DisabledBackColor = System.Drawing.Color.White;
            this.txtqichu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtqichu.ForeColor = System.Drawing.Color.Black;
            this.txtqichu.Location = new System.Drawing.Point(324, 245);
            this.txtqichu.Name = "txtqichu";
            this.txtqichu.PreventEnterBeep = true;
            this.txtqichu.Size = new System.Drawing.Size(145, 21);
            this.txtqichu.TabIndex = 94;
            this.txtqichu.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(248, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 100;
            this.label8.Text = "合作状态";
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // cmbleixing
            // 
            this.cmbleixing.DisplayMember = "Text";
            this.cmbleixing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbleixing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbleixing.FormattingEnabled = true;
            this.cmbleixing.ItemHeight = 18;
            this.cmbleixing.Location = new System.Drawing.Point(83, 287);
            this.cmbleixing.Name = "cmbleixing";
            this.cmbleixing.Size = new System.Drawing.Size(145, 24);
            this.cmbleixing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbleixing.TabIndex = 101;
            // 
            // cmbzhuangtai
            // 
            this.cmbzhuangtai.DisplayMember = "Text";
            this.cmbzhuangtai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbzhuangtai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbzhuangtai.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbzhuangtai.FormattingEnabled = true;
            this.cmbzhuangtai.ItemHeight = 18;
            this.cmbzhuangtai.Location = new System.Drawing.Point(324, 287);
            this.cmbzhuangtai.Name = "cmbzhuangtai";
            this.cmbzhuangtai.Size = new System.Drawing.Size(145, 24);
            this.cmbzhuangtai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbzhuangtai.TabIndex = 102;
            // 
            // txtkejiagong
            // 
            this.txtkejiagong.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtkejiagong.Border.Class = "TextBoxBorder";
            this.txtkejiagong.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtkejiagong.DisabledBackColor = System.Drawing.Color.White;
            this.txtkejiagong.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkejiagong.ForeColor = System.Drawing.Color.Black;
            this.txtkejiagong.Location = new System.Drawing.Point(83, 339);
            this.txtkejiagong.Name = "txtkejiagong";
            this.txtkejiagong.PreventEnterBeep = true;
            this.txtkejiagong.Size = new System.Drawing.Size(385, 21);
            this.txtkejiagong.TabIndex = 104;
            this.txtkejiagong.WatermarkText = "该加工厂能做的加工类型";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(12, 343);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 103;
            this.label15.Text = "可做加工";
            // 
            // 新增供货商
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 444);
            this.Controls.Add(this.txtkejiagong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbzhuangtai);
            this.Controls.Add(this.cmbleixing);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtweixing);
            this.Controls.Add(this.txtyingkaifapiao);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtqichu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtshuihao);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtpingyingma);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtdizhi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtyinghangzhanghao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtkaihuyinghang);
            this.Controls.Add(this.txtyouxiang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtqq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbeizhu);
            this.Controls.Add(this.txtlianxidianhua);
            this.Controls.Add(this.txtlianxiren);
            this.Controls.Add(this.txtpingming);
            this.Controls.Add(this.txtBianhao);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增供货商";
            this.Text = "新增供货商";
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
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBianhao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingming;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlianxidianhua;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlianxiren;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbeizhu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtyingkaifapiao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtqq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkaihuyinghang;
        private DevComponents.DotNetBar.Controls.TextBoxX txtyouxiang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtyinghangzhanghao;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdizhi;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpingyingma;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtshuihao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtweixing;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtqichu;
        private System.Windows.Forms.Label label8;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbleixing;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbzhuangtai;
        private DevComponents.DotNetBar.Controls.TextBoxX txtkejiagong;
        private System.Windows.Forms.Label label15;
    }
}