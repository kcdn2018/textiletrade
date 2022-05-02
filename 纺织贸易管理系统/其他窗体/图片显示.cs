using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 图片显示 : Form
    {
        public Image Image { get; set; }
        public 图片显示()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
        }

  
            int zoomStep = 50;
            private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
            {
                PictureBox pbox = sender as PictureBox;
                int x = e.Location.X;
                int y = e.Location.Y;
                int ow = pbox.Width;
                int oh = pbox.Height;
                int VX, VY;  //因缩放产生的位移矢量
                if (e.Delta > 0) //放大
                {
                    //第①步
                    pbox.Width += zoomStep;
                    pbox.Height += zoomStep;
                    //第②步
                    PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                     BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
                    //第③步
                    pbox.Width = rect.Width;
                    pbox.Height = rect.Height;
                }
                if (e.Delta < 0) //缩小
                {
                    //防止一直缩成负值
                    if (pbox.Width < 300)
                        return;

                    pbox.Width -= zoomStep;
                    pbox.Height -= zoomStep;
                    PropertyInfo pInfo = pbox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                     BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(pbox, null);
                    pbox.Width = rect.Width;
                    pbox.Height = rect.Height;
                }
                //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
                VX = (int)((double)x * (ow - pbox.Width) / ow);
                VY = (int)((double)y * (oh - pbox.Height) / oh);
                pbox.Location = new Point(pbox.Location.X + VX, pbox.Location.Y + VY);
            }


        private void 图片显示_Load(object sender, EventArgs e)
        {
            pictureBox1.Image  = Image;
        }

        private void 适应大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void 全部显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void 图片居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void 旋转图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            b.RotateFlip(RotateFlipType.Rotate90FlipXY);//旋转90度
            //b.RotateFlip(RotateFlipType.Rotate90FlipNone);//不进行翻转的旋转
            pictureBox1.Image = b;
        }
    }
}
