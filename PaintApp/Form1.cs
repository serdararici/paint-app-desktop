using System.Drawing.Imaging;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 1200;
            this.Height = 700;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }
            }
            pic.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }

            if (index == 4)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }



        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (paint)
            {
                if (index == 3)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }

                if (index == 4)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
            }

        }

        private void btn_newPage_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Red;
            p.Color = Color.Red;
        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Blue;
            p.Color = Color.Blue;
        }

        private void btn_green_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Green;
            p.Color = Color.Green;
        }

        private void btn_orange_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Orange;
            p.Color = Color.Orange;
        }

        private void btn_black_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Black;
            p.Color = Color.Black;
        }

        private void btn_yellow_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Yellow;
            p.Color = Color.Yellow;
        }

        private void btn_purple_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Purple;
            p.Color = Color.Purple;
        }

        private void btn_brown_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.Brown;
            p.Color = Color.Brown;
        }

        private void btn_white_Click(object sender, EventArgs e)
        {
            pic.BackColor = Color.White;
            p.Color = Color.White;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bm.Clone(new Rectangle(0,0,pic.Width, pic.Height), bm.PixelFormat);
                bm.Save(sfd.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Image saved successfully");
            }
        }
    }
}
