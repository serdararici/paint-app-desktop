using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using PaintApp.Shapes;

namespace PaintApp
{
    /*
    // Abstract base class for shapes
    public abstract class Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Color ShapeColor { get; set; }
        public bool IsSelected { get; set; }

        public abstract void Draw(Graphics g);
        public abstract bool Contains(int x, int y);
    }
    
    
    
    // Concrete shape implementations
    public class RectangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                int x = Math.Min(X1, X2);
                int y = Math.Min(Y1, Y2);
                int width = Math.Abs(X2 - X1);
                int height = Math.Abs(Y2 - Y1);
                g.DrawRectangle(pen, x, y, width, height);

                if (IsSelected)
                {
                    // Draw selection highlight
                    using (Pen highlightPen = new Pen(Color.Blue, 2))
                    {
                        g.DrawRectangle(highlightPen, x - 2, y - 2, width + 4, height + 4);
                    }
                }
            }
        }

        public override bool Contains(int x, int y)
        {
            int left = Math.Min(X1, X2);
            int top = Math.Min(Y1, Y2);
            int right = Math.Max(X1, X2);
            int bottom = Math.Max(Y1, Y2);

            return x >= left && x <= right && y >= top && y <= bottom;
        }
    }

    public class EllipseShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                int x = Math.Min(X1, X2);
                int y = Math.Min(Y1, Y2);
                int width = Math.Abs(X2 - X1);
                int height = Math.Abs(Y2 - Y1);
                g.DrawEllipse(pen, x, y, width, height);

                if (IsSelected)
                {
                    // Draw selection highlight
                    using (Pen highlightPen = new Pen(Color.Blue, 2))
                    {
                        g.DrawRectangle(highlightPen, x - 2, y - 2, width + 4, height + 4);
                    }
                }
            }
        }

        public override bool Contains(int x, int y)
        {
            // Simple bounding box check - could be improved for more precise ellipse detection
            int left = Math.Min(X1, X2);
            int top = Math.Min(Y1, Y2);
            int right = Math.Max(X1, X2);
            int bottom = Math.Max(Y1, Y2);

            return x >= left && x <= right && y >= top && y <= bottom;
        }
    }

    public class TriangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                // Üçgenin köþelerini hesapla
                Point[] points = new Point[]
                {
            new Point((X1 + X2) / 2, Y1), // Üst nokta (tabanýn ortasý)
            new Point(X1, Y2),             // Alt sol nokta
            new Point(X2, Y2)              // Alt sað nokta
                };

                g.DrawPolygon(pen, points);

                if (IsSelected)
                {
                    // Seçim kutusu çiz
                    using (Pen highlightPen = new Pen(Color.Blue, 2))
                    {
                        g.DrawPolygon(highlightPen, points);
                    }
                }
            }
        }


        public override bool Contains(int x, int y)
        {
            // Üçgenin köþelerini hesapla
            Point[] points = new Point[]
            {
                new Point((X1 + X2) / 2, Y1), // Üst nokta (tabanýn ortasý)
                new Point(X1, Y2),             // Alt sol nokta
                new Point(X2, Y2)              // Alt sað nokta
            };

            // Daha hassas bir noktayý içerip içermediðini kontrol etmek için daha doðru bir algoritma
            int i, j = 2;
            bool inside = false;
            for (i = 0; i < 3; j = i++)
            {
                if (((points[i].Y > y) != (points[j].Y > y)) &&
                    (x < (points[j].X - points[i].X) * (y - points[i].Y) /
                    (points[j].Y - points[i].Y) + points[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }

    public class HexagonShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                // Calculate hexagon points based on start and end coordinates
                Point[] points = CalculateHexagonPoints();

                g.DrawPolygon(pen, points);

                if (IsSelected)
                {
                    // Draw selection highlight
                    using (Pen highlightPen = new Pen(Color.Blue, 2))
                    {
                        g.DrawPolygon(highlightPen, points);
                    }
                }
            }
        }

        private Point[] CalculateHexagonPoints()
        {
            Point[] points = new Point[6];
            int centerX = (X1 + X2) / 2;
            int centerY = (Y1 + Y2) / 2;
            int width = Math.Abs(X2 - X1);
            int height = Math.Abs(Y2 - Y1);
            double radius = Math.Min(width, height) / 2;

            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                points[i] = new Point(
                    (int)(centerX + radius * Math.Cos(angle)),
                    (int)(centerY + radius * Math.Sin(angle))
                );
            }

            return points;
        }

        public override bool Contains(int x, int y)
        {
            // Similar point-in-polygon logic as triangle
            Point[] points = CalculateHexagonPoints();
            bool inside = false;
            for (int i = 0, j = points.Length - 1; i < points.Length; j = i++)
            {
                if (((points[i].Y > y) != (points[j].Y > y)) &&
                    (x < (points[j].X - points[i].X) * (y - points[i].Y) /
                    (points[j].Y - points[i].Y) + points[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }

    */

    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape;
        private bool isDrawing = false;
        private bool isSelectionMode = false;
        private int startX, startY;
        private ShapeType currentShapeType = ShapeType.None;
        private Color currentColor = Color.Black;

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

            // Ensure pic is not null before creating bitmap
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

            // Additional setup for selection and shape drawing
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            pic.Paint += pic_Paint;
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            int maxWidth = bm.Width - 1; 
            int maxHeight = bm.Height - 1;

            // Sýnýrlarý aþmamak için kontrol yapýyorum.
            startX = Math.Max(0, Math.Min(e.X, maxWidth));
            startY = Math.Max(0, Math.Min(e.Y, maxHeight));

            if (isSelectionMode)
            {
                // Deselect all shapes first
                shapes.ForEach(s => s.IsSelected = false);

                // Check if any shape is clicked
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
                // Sýnýrlarý aþmamak için kontrol yapýyorum.
                int x = Math.Max(0, Math.Min(e.X, maxWidth));
                int y = Math.Max(0, Math.Min(e.Y, maxHeight));

                currentShape.X2 = x;
                currentShape.Y2 = y;
                pic.Refresh();
            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            int maxWidth = bm.Width - 1;
            int maxHeight = bm.Height - 1;

            if (isDrawing)
            {
                // Sýnýrlarý aþmamak için kontrol yapýyorum.
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
                    // Dispose of previous bitmap if it exists
                    if (bm != null)
                        bm.Dispose();

                    bm = new Bitmap(ofd.FileName);

                    // Dispose of previous graphics if it exists
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
            // Önceki seçili butonu normal hale getir
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = SystemColors.Control;
                currentSelectedButton.FlatAppearance.BorderSize = 1;
            }

            // Yeni seçilen butonu vurgula
            if (newSelectedButton != null)
            {
                newSelectedButton.BackColor = Color.LightBlue;
                newSelectedButton.FlatAppearance.BorderSize = 3;
                newSelectedButton.FlatAppearance.BorderColor = Color.Gray;
            }

            // Referansý güncelle
            currentSelectedButton = newSelectedButton;
        }

        // Color selection methods (similar to your existing ones)
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