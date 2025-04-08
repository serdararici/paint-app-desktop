using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.Json;
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
            //çizim iþlemi için
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;

            //þekil çizimleri için
            int maxWidth = bm.Width - 1;
            int maxHeight = bm.Height - 1;

            // Sýnýrlarý aþmamak için kontrol yapýyorum.
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
                // Sýnýrlarý aþmamak için kontrol yapýyorum.
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
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }

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
            currentShapeType = ShapeType.None;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
            HighlightButton(sender as Button, ref selectedShapeButton);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Shape Data (*.shapes)|*.shapes|All Files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Dictionary<string, object>> shapesData = new List<Dictionary<string, object>>();

                    foreach (var shape in shapes)
                    {
                        Dictionary<string, object> shapeData = new Dictionary<string, object>();
                        shapeData["Type"] = shape.GetType().Name;
                        shapeData["X1"] = shape.X1;
                        shapeData["Y1"] = shape.Y1;
                        shapeData["X2"] = shape.X2;
                        shapeData["Y2"] = shape.Y2;
                        shapeData["R"] = shape.ShapeColor.R;
                        shapeData["G"] = shape.ShapeColor.G;
                        shapeData["B"] = shape.ShapeColor.B;

                        shapesData.Add(shapeData);
                    }

                    string json = System.Text.Json.JsonSerializer.Serialize(shapesData);

                    System.IO.File.WriteAllText(sfd.FileName, json);

                    MessageBox.Show("Shapes saved successfully");
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
            ofd.Filter = "Shape Data (*.shapes)|*.shapes|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = System.IO.File.ReadAllText(ofd.FileName);

                    List<Dictionary<string, JsonElement>> shapesData =
                        System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(json);

                    shapes.Clear();

                    foreach (var shapeData in shapesData)
                    {
                        Shape shape = null;

                        string typeName = shapeData["Type"].GetString();
                        switch (typeName)
                        {
                            case "RectangleShape":
                                shape = new RectangleShape();
                                break;
                            case "EllipseShape":
                                shape = new EllipseShape();
                                break;
                            case "TriangleShape":
                                shape = new TriangleShape();
                                break;
                            case "HexagonShape":
                                shape = new HexagonShape();
                                break;
                            default:
                                continue;
                        }

                        shape.X1 = shapeData["X1"].GetInt32();
                        shape.Y1 = shapeData["Y1"].GetInt32();
                        shape.X2 = shapeData["X2"].GetInt32();
                        shape.Y2 = shapeData["Y2"].GetInt32();
                        shape.ShapeColor = Color.FromArgb(
                            shapeData["R"].GetInt32(),
                            shapeData["G"].GetInt32(),
                            shapeData["B"].GetInt32()
                        );

                        shapes.Add(shape);
                    }

                    pic.Refresh();
                    MessageBox.Show("Shapes loaded successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}");
                }
            }
        }


        private void HighlightButton(Button newSelectedButton, ref Button currentSelectedButton)
        {
            // Önceki seçili butonu normal hale getirmek için kontrol yaptým
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = SystemColors.Control;
                currentSelectedButton.FlatAppearance.BorderSize = 1;
            }

            // Yeni seçilen buton için renklendirme iþlemi yaptým
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