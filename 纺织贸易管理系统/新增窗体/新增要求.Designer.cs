﻿
namespace 纺织贸易管理系统.新增窗体
{
    partial class 新增要求
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
#pragma warning disable CS0115 // “新增要求.Dispose(bool)”: 没有找到适合的方法来重写
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “新增要求.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.txtnum = new Sunny.UI.UITextBox();
            this.pnlBtm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 129);
            this.pnlBtm.Size = new System.Drawing.Size(309, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(181, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(66, 12);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(42, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "要求名称";
            // 
            // txtnum
            // 
            this.txtnum.ButtonSymbol = 61761;
            this.txtnum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnum.FillColor = System.Drawing.Color.White;
            this.txtnum.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtnum.Location = new System.Drawing.Point(123, 70);
            this.txtnum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtnum.Maximum = 2147483647D;
            this.txtnum.Minimum = -2147483648D;
            this.txtnum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtnum.Name = "txtnum";
            this.txtnum.Padding = new System.Windows.Forms.Padding(5);
            this.txtnum.Size = new System.Drawing.Size(150, 23);
            this.txtnum.TabIndex = 3;
            this.txtnum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 新增要求
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 187);
            this.Controls.Add(this.txtnum);
            this.Controls.Add(this.label1);
            this.Name = "新增要求";
            this.Text = "新增要求";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ButtonOkClick += new System.EventHandler(this.新增员工_ButtonOkClick);
            this.ButtonCancelClick += new System.EventHandler(this.新增工艺_ButtonCancelClick);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtnum, 0);
            this.pnlBtm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtnum;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
    }
}