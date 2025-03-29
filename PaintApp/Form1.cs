using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using PaintApp.Shapes;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape;
        private bool isDrawing = false;
        private bool isSelectionMode = false;
        private int startX, startY;
        private ShapeType currentShapeType = ShapeType.None;
        private Color currentColor = Color.Black;

        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;


        private Button selectedShapeButton;
        private Button selectedColorButton;

        private Bitmap bm;
        private Graphics g;

        public enum ShapeType
        {
            None,
            Rectangle,
            Ellipse,
            Triangle,
            Hexagon,
            Line,
            Selection
        }

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Width = 1200;
            this.Height = 700;

            if (pic != null)
            {
                bm = new Bitmap(pic.Width, pic.Height);
                g = Graphics.FromImage(bm);
                g.Clear(Color.White);
                pic.Image = bm;
            }
            else
            {
                MessageBox.Show("PictureBox control not found!");
            }


        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            //�izim i�lemi i�in
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;

            //�ekil �izimleri i�in
            int maxWidth = bm.Width - 1;
            int maxHeight = bm.Height - 1;

            // S�n�rlar� a�mamak i�in kontrol yap�yorum.
            startX = Math.Max(0, Math.Min(e.X, maxWidth));
            startY = Math.Max(0, Math.Min(e.Y, maxHeight));

            if (isSelectionMode)
            {
                shapes.ForEach(s => s.IsSelected = false);

                foreach (var shape in shapes)
                {
                    if (shape.Contains(e.X, e.Y))
                    {
                        shape.IsSelected = true;
                        break;
                    }
                }
                pic.Refresh();
                return;
            }

            if (currentShapeType != ShapeType.None)
            {
                isDrawing = true;
                currentShape = CreateShape(currentShapeType);
                currentShape.X1 = startX;
                currentShape.Y1 = startY;
                currentShape.ShapeColor = currentColor;
            }
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            int maxWidth = bm.Width - 1;
            int maxHeight = bm.Height - 1;

            if (isDrawing)
            {
                // S�n�rlar� a�mamak i�in kontrol yap�yorum.
                int x = Math.Max(0, Math.Min(e.X, maxWidth));
                int y = Math.Max(0, Math.Min(e.Y, maxHeight));

                currentShape.X2 = x;
                currentShape.Y2 = y;
                pic.Refresh();
            }

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
                pic.Refresh();
            }
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

            int maxWidth = bm.Width - 1;
            int maxHeight = bm.Height - 1;

            if (isDrawing)
            {
                // S�n�rlar� a�mamak i�in kontrol yap�yorum.
                int x = Math.Max(0, Math.Min(e.X, maxWidth));
                int y = Math.Max(0, Math.Min(e.Y, maxHeight));

                currentShape.X2 = x;
                currentShape.Y2 = y;
                shapes.Add(currentShape);
                isDrawing = false;
                pic.Refresh();
            }
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            // Draw existing shapes
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }

            // Draw current shape while drawing
            if (isDrawing && currentShape != null)
            {
                currentShape.Draw(e.Graphics);
            }
        }

        private Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new RectangleShape();
                case ShapeType.Ellipse:
                    return new EllipseShape();
                case ShapeType.Triangle:
                    return new TriangleShape();
                case ShapeType.Hexagon:
                    return new HexagonShape();
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }

        // Button click handlers for shape selection
        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Rectangle;
            isSelectionMode = false;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Ellipse;
            isSelectionMode = false;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_triangle_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Triangle;
            isSelectionMode = false;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_hexagon_Click(object sender, EventArgs e)
        {
            currentShapeType = ShapeType.Hexagon;
            isSelectionMode = false;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            isSelectionMode = true;
            currentShapeType = ShapeType.None;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            shapes.RemoveAll(s => s.IsSelected);
            pic.Refresh();
        }

        private void btn_newPage_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                // Dispose of previous bitmap and graphics
                if (g != null)
                    g.Dispose();

                bm = new Bitmap(pic.Width, pic.Height);
                g = Graphics.FromImage(bm);
                g.Clear(Color.White);
                pic.Image = bm;
            }

            shapes.Clear();
            pic.Refresh();
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (bm == null)
            {
                MessageBox.Show("No image to save!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Use Clone to create a new bitmap before saving
                    using (Bitmap btm = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat))
                    {
                        btm.Save(sfd.FileName, ImageFormat.Jpeg);
                    }
                    MessageBox.Show("Image saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (bm != null)
                        bm.Dispose();

                    bm = new Bitmap(ofd.FileName);

                    if (g != null)
                        g.Dispose();

                    g = Graphics.FromImage(bm);
                    pic.Image = bm;
                    pic.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}");
                }
            }
        }

        private void HighlightButton(Button newSelectedButton, ref Button currentSelectedButton)
        {
            // �nceki se�ili butonu normal hale getirmek i�in kontrol yapt�m
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = SystemColors.Control;
                currentSelectedButton.FlatAppearance.BorderSize = 1;
            }

            // Yeni se�ilen buton i�in renklendirme i�lemi yapt�m
            if (newSelectedButton != null)
            {
                newSelectedButton.BackColor = Color.LightBlue;
                newSelectedButton.FlatAppearance.BorderSize = 3;
                newSelectedButton.FlatAppearance.BorderColor = Color.Gray;
            }

   
            currentSelectedButton = newSelectedButton;
        }

        private void SetColor(object sender, Color color)
        {
            currentColor = color;

            Button clickedButton = (Button)sender;
            HighlightButton(clickedButton, ref selectedColorButton);
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Red);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_blue_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Blue);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_green_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Green);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_black_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Black);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_white_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.White);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_yellow_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Yellow);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_orange_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Orange);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_purple_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Purple);
            HighlightButton(sender as Button, ref selectedColorButton);
        }
        private void btn_brown_Click(object sender, EventArgs e)
        {
            SetColor(sender, Color.Brown);
            HighlightButton(sender as Button, ref selectedColorButton);
        }

        
    }
}