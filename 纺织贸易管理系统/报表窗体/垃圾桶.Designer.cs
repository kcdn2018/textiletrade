
namespace 纺织贸易管理系统.报表窗体
{
    partial class 垃圾桶
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.清空垃圾桶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除垃圾ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.配置列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtpingming = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtCustomer = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtganghao = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.还原库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CXuanzhe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空垃圾桶ToolStripMenuItem,
            this.删除垃圾ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.还原库存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 清空垃圾桶ToolStripMenuItem
            // 
            this.清空垃圾桶ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Clear_32x32;
            this.清空垃圾桶ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.清空垃圾桶ToolStripMenuItem.Name = "清空垃圾桶ToolStripMenuItem";
            this.清空垃圾桶ToolStripMenuItem.Size = new System.Drawing.Size(112, 36);
            this.清空垃圾桶ToolStripMenuItem.Text = "清空垃圾桶";
            this.清空垃圾桶ToolStripMenuItem.Click += new System.EventHandler(this.清空垃圾桶ToolStripMenuItem_Click);
            // 
            // 删除垃圾ToolStripMenuItem
            // 
            this.删除垃圾ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.DeleteList_32x32;
            this.删除垃圾ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.删除垃圾ToolStripMenuItem.Name = "删除垃圾ToolStripMenuItem";
            this.删除垃圾ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.删除垃圾ToolStripMenuItem.Text = "删除垃圾";
            this.删除垃圾ToolStripMenuItem.Click += new System.EventHandler(this.删除垃圾ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.Find_32x32;
            this.查询ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // uiDataGridViewFooter1
            // 
            this.uiDataGridViewFooter1.DataGridView = this.uiDataGridView1;
            this.uiDataGridViewFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiDataGridViewFooter1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiDataGridViewFooter1.Location = new System.Drawing.Point(0, 427);
            this.uiDataGridViewFooter1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            this.uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiDataGridViewFooter1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiDataGridViewFooter1.Size = new System.Drawing.Size(800, 23);
            this.uiDataGridViewFooter1.TabIndex = 1;
            this.uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            this.uiDataGridViewFooter1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CXuanzhe});
            this.uiDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 113);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowTemplate.Height = 23;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView1.Size = new System.Drawing.Size(800, 314);
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.TabIndex = 2;
            this.uiDataGridView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置列ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // 配置列ToolStripMenuItem
            // 
            this.配置列ToolStripMenuItem.Name = "配置列ToolStripMenuItem";
            this.配置列ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.配置列ToolStripMenuItem.Text = "配置列";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtpingming);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.txtCustomer);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.txtganghao);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 40);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(800, 73);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtpingming
            // 
            this.txtpingming.ButtonSymbol = 61761;
            this.txtpingming.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpingming.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtpingming.Location = new System.Drawing.Point(545, 30);
            this.txtpingming.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpingming.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtpingming.Name = "txtpingming";
            this.txtpingming.ShowText = false;
            this.txtpingming.Size = new System.Drawing.Size(150, 25);
            this.txtpingming.TabIndex = 5;
            this.txtpingming.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtpingming.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtpingming.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtganghao_KeyDown);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(472, 30);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(66, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "品名";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCustomer
            // 
            this.txtCustomer.ButtonSymbol = 61761;
            this.txtCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomer.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtCustomer.Location = new System.Drawing.Point(311, 32);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomer.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ShowText = false;
            this.txtCustomer.Size = new System.Drawing.Size(150, 25);
            this.txtCustomer.TabIndex = 3;
            this.txtCustomer.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCustomer.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtganghao_KeyDown);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(238, 32);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(66, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "编号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtganghao
            // 
            this.txtganghao.ButtonSymbol = 61761;
            this.txtganghao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtganghao.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtganghao.Location = new System.Drawing.Point(79, 32);
            this.txtganghao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtganghao.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtganghao.Name = "txtganghao";
            this.txtganghao.ShowText = false;
            this.txtganghao.Size = new System.Drawing.Size(150, 25);
            this.txtganghao.TabIndex = 1;
            this.txtganghao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtganghao.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtganghao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtganghao_KeyDown);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.Location = new System.Drawing.Point(31, 32);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "缸号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 还原库存ToolStripMenuItem
            // 
            this.还原库存ToolStripMenuItem.Image = global::纺织贸易管理系统.Properties.Resources.LoadFrom_32x32;
            this.还原库存ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.还原库存ToolStripMenuItem.Name = "还原库存ToolStripMenuItem";
            this.还原库存ToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.还原库存ToolStripMenuItem.Text = "还原库存";
            this.还原库存ToolStripMenuItem.Click += new System.EventHandler(this.还原库存ToolStripMenuItem_Click);
            // 
            // CXuanzhe
            // 
            this.CXuanzhe.HeaderText = "选择";
            this.CXuanzhe.Name = "CXuanzhe";
            this.CXuanzhe.Width = 50;
            // 
            // 垃圾桶
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiDataGridViewFooter1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "垃圾桶";
            this.Text = "垃圾桶";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空垃圾桶ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除垃圾ToolStripMenuItem;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridViewFooter”(是否缺少程序集引用?)
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridViewFooter”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private Sunny.UI.UIDataGridView uiDataGridView1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置列ToolStripMenuItem;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txtCustomer;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtganghao;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private Sunny.UI.UITextBox txtpingming;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.ToolStripMenuItem 还原库存ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CXuanzhe;
    }
}