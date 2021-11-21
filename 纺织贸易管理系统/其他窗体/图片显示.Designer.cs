
namespace 纺织贸易管理系统.其他窗体
{
    partial class 图片显示
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(图片显示));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.适应大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图片居中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应大小ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.全部显示ToolStripMenuItem,
            this.图片居中ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 适应大小ToolStripMenuItem
            // 
            this.适应大小ToolStripMenuItem.Name = "适应大小ToolStripMenuItem";
            this.适应大小ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.适应大小ToolStripMenuItem.Text = "适应大小";
            this.适应大小ToolStripMenuItem.Click += new System.EventHandler(this.适应大小ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 全部显示ToolStripMenuItem
            // 
            this.全部显示ToolStripMenuItem.Name = "全部显示ToolStripMenuItem";
            this.全部显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全部显示ToolStripMenuItem.Text = "全部显示";
            this.全部显示ToolStripMenuItem.Click += new System.EventHandler(this.全部显示ToolStripMenuItem_Click);
            // 
            // 图片居中ToolStripMenuItem
            // 
            this.图片居中ToolStripMenuItem.Name = "图片居中ToolStripMenuItem";
            this.图片居中ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.图片居中ToolStripMenuItem.Text = "图片居中";
            this.图片居中ToolStripMenuItem.Click += new System.EventHandler(this.图片居中ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // 图片显示
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "图片显示";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片显示";
            this.Load += new System.EventHandler(this.图片显示_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应大小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图片居中ToolStripMenuItem;
    }
}