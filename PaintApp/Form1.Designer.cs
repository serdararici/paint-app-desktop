namespace PaintApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pic = new PictureBox();
            btn_circle = new Button();
            btn_triangle = new Button();
            btn_rectangle = new Button();
            btn_haxagon = new Button();
            label_drawing_style = new Label();
            label_color_selection = new Label();
            label_shape_operations = new Label();
            label_file_operations = new Label();
            btn_red = new Button();
            btn_blue = new Button();
            btn_green = new Button();
            btn_orange = new Button();
            btn_black = new Button();
            btn_yellow = new Button();
            panel1 = new Panel();
            btn_eraser = new Button();
            btn_pencil = new Button();
            btn_save = new Button();
            btn_folder = new Button();
            btn_newPage = new Button();
            btn_delete = new Button();
            btn_select = new Button();
            btn_white = new Button();
            btn_brown = new Button();
            btn_purple = new Button();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pic
            // 
            pic.BackColor = Color.WhiteSmoke;
            pic.Dock = DockStyle.Fill;
            pic.Location = new Point(0, 0);
            pic.Name = "pic";
            pic.Size = new Size(1184, 661);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.Paint += pic_Paint;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            // 
            // btn_circle
            // 
            btn_circle.BackColor = Color.White;
            btn_circle.BackgroundImageLayout = ImageLayout.None;
            btn_circle.Cursor = Cursors.Hand;
            btn_circle.FlatAppearance.MouseDownBackColor = Color.White;
            btn_circle.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_circle.FlatStyle = FlatStyle.Flat;
            btn_circle.ForeColor = Color.White;
            btn_circle.Image = Properties.Resources.circle_purple;
            btn_circle.Location = new Point(63, 11);
            btn_circle.Name = "btn_circle";
            btn_circle.Size = new Size(50, 50);
            btn_circle.TabIndex = 1;
            btn_circle.UseVisualStyleBackColor = false;
            btn_circle.Click += btn_circle_Click;
            // 
            // btn_triangle
            // 
            btn_triangle.BackColor = Color.White;
            btn_triangle.Cursor = Cursors.Hand;
            btn_triangle.FlatAppearance.MouseDownBackColor = Color.White;
            btn_triangle.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_triangle.FlatStyle = FlatStyle.Flat;
            btn_triangle.ForeColor = Color.White;
            btn_triangle.Image = Properties.Resources.triangle_blue;
            btn_triangle.Location = new Point(7, 67);
            btn_triangle.Name = "btn_triangle";
            btn_triangle.Size = new Size(50, 50);
            btn_triangle.TabIndex = 2;
            btn_triangle.UseVisualStyleBackColor = false;
            btn_triangle.Click += btn_triangle_Click;
            // 
            // btn_rectangle
            // 
            btn_rectangle.BackColor = Color.White;
            btn_rectangle.Cursor = Cursors.Hand;
            btn_rectangle.FlatAppearance.MouseDownBackColor = Color.White;
            btn_rectangle.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_rectangle.FlatStyle = FlatStyle.Flat;
            btn_rectangle.ForeColor = SystemColors.ControlLight;
            btn_rectangle.Image = Properties.Resources.square_yellow;
            btn_rectangle.Location = new Point(7, 11);
            btn_rectangle.Name = "btn_rectangle";
            btn_rectangle.Size = new Size(50, 50);
            btn_rectangle.TabIndex = 3;
            btn_rectangle.UseVisualStyleBackColor = false;
            btn_rectangle.Click += btn_rectangle_Click;
            // 
            // btn_haxagon
            // 
            btn_haxagon.BackColor = Color.White;
            btn_haxagon.Cursor = Cursors.Hand;
            btn_haxagon.FlatAppearance.MouseDownBackColor = Color.White;
            btn_haxagon.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_haxagon.FlatStyle = FlatStyle.Flat;
            btn_haxagon.ForeColor = Color.White;
            btn_haxagon.Image = Properties.Resources.hexagon_green;
            btn_haxagon.Location = new Point(63, 67);
            btn_haxagon.Name = "btn_haxagon";
            btn_haxagon.Size = new Size(50, 50);
            btn_haxagon.TabIndex = 4;
            btn_haxagon.UseVisualStyleBackColor = false;
            btn_haxagon.Click += btn_hexagon_Click;
            // 
            // label_drawing_style
            // 
            label_drawing_style.AutoSize = true;
            label_drawing_style.Font = new Font("Segoe UI", 7F, FontStyle.Bold | FontStyle.Underline);
            label_drawing_style.Location = new Point(7, 0);
            label_drawing_style.Name = "label_drawing_style";
            label_drawing_style.Size = new Size(61, 12);
            label_drawing_style.TabIndex = 5;
            label_drawing_style.Text = "ÇİZİM ŞEKLİ";
            // 
            // label_color_selection
            // 
            label_color_selection.AutoSize = true;
            label_color_selection.Font = new Font("Segoe UI", 7F, FontStyle.Bold | FontStyle.Underline);
            label_color_selection.Location = new Point(7, 130);
            label_color_selection.Name = "label_color_selection";
            label_color_selection.Size = new Size(67, 12);
            label_color_selection.TabIndex = 6;
            label_color_selection.Text = "RENK SEÇİMİ";
            // 
            // label_shape_operations
            // 
            label_shape_operations.AutoSize = true;
            label_shape_operations.Font = new Font("Segoe UI", 7F, FontStyle.Bold | FontStyle.Underline);
            label_shape_operations.Location = new Point(7, 259);
            label_shape_operations.Name = "label_shape_operations";
            label_shape_operations.Size = new Size(82, 12);
            label_shape_operations.TabIndex = 7;
            label_shape_operations.Text = "ŞEKİL İŞLEMLERİ";
            // 
            // label_file_operations
            // 
            label_file_operations.AutoSize = true;
            label_file_operations.Font = new Font("Segoe UI", 7F, FontStyle.Bold | FontStyle.Underline);
            label_file_operations.Location = new Point(7, 318);
            label_file_operations.Name = "label_file_operations";
            label_file_operations.Size = new Size(90, 12);
            label_file_operations.TabIndex = 8;
            label_file_operations.Text = "DOSYA İŞLEMLERİ";
            // 
            // btn_red
            // 
            btn_red.BackColor = Color.White;
            btn_red.Cursor = Cursors.Hand;
            btn_red.FlatAppearance.MouseDownBackColor = Color.White;
            btn_red.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_red.FlatStyle = FlatStyle.Flat;
            btn_red.ForeColor = Color.White;
            btn_red.Image = Properties.Resources.red;
            btn_red.Location = new Point(7, 145);
            btn_red.Name = "btn_red";
            btn_red.Size = new Size(30, 30);
            btn_red.TabIndex = 9;
            btn_red.UseVisualStyleBackColor = false;
            btn_red.Click += btn_red_Click;
            // 
            // btn_blue
            // 
            btn_blue.BackColor = Color.White;
            btn_blue.Cursor = Cursors.Hand;
            btn_blue.FlatAppearance.MouseDownBackColor = Color.White;
            btn_blue.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_blue.FlatStyle = FlatStyle.Flat;
            btn_blue.ForeColor = Color.White;
            btn_blue.Image = Properties.Resources.blue;
            btn_blue.Location = new Point(44, 145);
            btn_blue.Name = "btn_blue";
            btn_blue.Size = new Size(30, 30);
            btn_blue.TabIndex = 10;
            btn_blue.UseVisualStyleBackColor = false;
            btn_blue.Click += btn_blue_Click;
            // 
            // btn_green
            // 
            btn_green.BackColor = Color.White;
            btn_green.Cursor = Cursors.Hand;
            btn_green.FlatAppearance.MouseDownBackColor = Color.White;
            btn_green.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_green.FlatStyle = FlatStyle.Flat;
            btn_green.ForeColor = Color.White;
            btn_green.Image = Properties.Resources.green;
            btn_green.Location = new Point(80, 145);
            btn_green.Name = "btn_green";
            btn_green.Size = new Size(30, 30);
            btn_green.TabIndex = 11;
            btn_green.UseVisualStyleBackColor = false;
            btn_green.Click += btn_green_Click;
            // 
            // btn_orange
            // 
            btn_orange.BackColor = Color.White;
            btn_orange.Cursor = Cursors.Hand;
            btn_orange.FlatAppearance.MouseDownBackColor = Color.White;
            btn_orange.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_orange.FlatStyle = FlatStyle.Flat;
            btn_orange.ForeColor = Color.White;
            btn_orange.Image = Properties.Resources.orange;
            btn_orange.Location = new Point(7, 181);
            btn_orange.Name = "btn_orange";
            btn_orange.Size = new Size(30, 30);
            btn_orange.TabIndex = 12;
            btn_orange.UseVisualStyleBackColor = false;
            btn_orange.Click += btn_orange_Click;
            // 
            // btn_black
            // 
            btn_black.BackColor = Color.White;
            btn_black.Cursor = Cursors.Hand;
            btn_black.FlatAppearance.MouseDownBackColor = Color.White;
            btn_black.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_black.FlatStyle = FlatStyle.Flat;
            btn_black.ForeColor = Color.White;
            btn_black.Image = Properties.Resources.black;
            btn_black.Location = new Point(44, 181);
            btn_black.Name = "btn_black";
            btn_black.Size = new Size(30, 30);
            btn_black.TabIndex = 13;
            btn_black.UseVisualStyleBackColor = false;
            btn_black.Click += btn_black_Click;
            // 
            // btn_yellow
            // 
            btn_yellow.BackColor = Color.White;
            btn_yellow.Cursor = Cursors.Hand;
            btn_yellow.FlatAppearance.MouseDownBackColor = Color.White;
            btn_yellow.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_yellow.FlatStyle = FlatStyle.Flat;
            btn_yellow.ForeColor = Color.White;
            btn_yellow.Image = Properties.Resources.yellow;
            btn_yellow.Location = new Point(80, 181);
            btn_yellow.Name = "btn_yellow";
            btn_yellow.Size = new Size(30, 30);
            btn_yellow.TabIndex = 14;
            btn_yellow.UseVisualStyleBackColor = false;
            btn_yellow.Click += btn_yellow_Click;
            // 
            // btn_white
            // 
            btn_white.BackColor = Color.White;
            btn_white.Cursor = Cursors.Hand;
            btn_white.FlatAppearance.MouseDownBackColor = Color.White;
            btn_white.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_white.FlatStyle = FlatStyle.Flat;
            btn_white.ForeColor = Color.White;
            btn_white.Image = Properties.Resources.white;
            btn_white.Location = new Point(80, 217);
            btn_white.Name = "btn_white";
            btn_white.Size = new Size(30, 30);
            btn_white.TabIndex = 17;
            btn_white.UseVisualStyleBackColor = false;
            btn_white.Click += btn_white_Click;
            // 
            // btn_brown
            // 
            btn_brown.BackColor = Color.White;
            btn_brown.Cursor = Cursors.Hand;
            btn_brown.FlatAppearance.MouseDownBackColor = Color.White;
            btn_brown.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_brown.FlatStyle = FlatStyle.Flat;
            btn_brown.ForeColor = Color.White;
            btn_brown.Image = Properties.Resources.brown;
            btn_brown.Location = new Point(44, 217);
            btn_brown.Name = "btn_brown";
            btn_brown.Size = new Size(30, 30);
            btn_brown.TabIndex = 16;
            btn_brown.UseVisualStyleBackColor = false;
            btn_brown.Click += btn_brown_Click;
            // 
            // btn_purple
            // 
            btn_purple.BackColor = Color.White;
            btn_purple.Cursor = Cursors.Hand;
            btn_purple.FlatAppearance.MouseDownBackColor = Color.White;
            btn_purple.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_purple.FlatStyle = FlatStyle.Flat;
            btn_purple.ForeColor = Color.White;
            btn_purple.Image = Properties.Resources.purple;
            btn_purple.Location = new Point(7, 217);
            btn_purple.Name = "btn_purple";
            btn_purple.Size = new Size(30, 30);
            btn_purple.TabIndex = 15;
            btn_purple.UseVisualStyleBackColor = false;
            btn_purple.Click += btn_purple_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btn_eraser);
            panel1.Controls.Add(btn_pencil);
            panel1.Controls.Add(btn_save);
            panel1.Controls.Add(btn_folder);
            panel1.Controls.Add(btn_newPage);
            panel1.Controls.Add(btn_delete);
            panel1.Controls.Add(btn_select);
            panel1.Controls.Add(btn_white);
            panel1.Controls.Add(btn_brown);
            panel1.Controls.Add(btn_purple);
            panel1.Controls.Add(btn_yellow);
            panel1.Controls.Add(btn_black);
            panel1.Controls.Add(btn_orange);
            panel1.Controls.Add(btn_green);
            panel1.Controls.Add(btn_blue);
            panel1.Controls.Add(btn_red);
            panel1.Controls.Add(label_file_operations);
            panel1.Controls.Add(label_shape_operations);
            panel1.Controls.Add(label_color_selection);
            panel1.Controls.Add(label_drawing_style);
            panel1.Controls.Add(btn_haxagon);
            panel1.Controls.Add(btn_rectangle);
            panel1.Controls.Add(btn_triangle);
            panel1.Controls.Add(btn_circle);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1066, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(118, 661);
            panel1.TabIndex = 0;
            // 
            // btn_eraser
            // 
            btn_eraser.BackColor = Color.Gray;
            btn_eraser.Cursor = Cursors.Hand;
            btn_eraser.FlatAppearance.MouseDownBackColor = Color.White;
            btn_eraser.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_eraser.FlatStyle = FlatStyle.Flat;
            btn_eraser.ForeColor = Color.White;
            btn_eraser.Image = Properties.Resources.eraser;
            btn_eraser.Location = new Point(59, 395);
            btn_eraser.Name = "btn_eraser";
            btn_eraser.Size = new Size(30, 30);
            btn_eraser.TabIndex = 24;
            btn_eraser.UseVisualStyleBackColor = false;
            // 
            // btn_pencil
            // 
            btn_pencil.BackColor = Color.Gray;
            btn_pencil.Cursor = Cursors.Hand;
            btn_pencil.FlatAppearance.MouseDownBackColor = Color.White;
            btn_pencil.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_pencil.FlatStyle = FlatStyle.Flat;
            btn_pencil.ForeColor = Color.White;
            btn_pencil.Image = Properties.Resources.pencil;
            btn_pencil.ImageAlign = ContentAlignment.TopRight;
            btn_pencil.Location = new Point(7, 395);
            btn_pencil.Name = "btn_pencil";
            btn_pencil.Size = new Size(30, 30);
            btn_pencil.TabIndex = 23;
            btn_pencil.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.White;
            btn_save.Cursor = Cursors.Hand;
            btn_save.FlatAppearance.MouseDownBackColor = Color.White;
            btn_save.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.ForeColor = Color.White;
            btn_save.Image = Properties.Resources.file_save;
            btn_save.Location = new Point(44, 333);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(30, 30);
            btn_save.TabIndex = 22;
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_folder
            // 
            btn_folder.BackColor = Color.White;
            btn_folder.Cursor = Cursors.Hand;
            btn_folder.FlatAppearance.MouseDownBackColor = Color.White;
            btn_folder.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_folder.FlatStyle = FlatStyle.Flat;
            btn_folder.ForeColor = Color.White;
            btn_folder.Image = Properties.Resources.folder;
            btn_folder.Location = new Point(7, 333);
            btn_folder.Name = "btn_folder";
            btn_folder.Size = new Size(30, 30);
            btn_folder.TabIndex = 21;
            btn_folder.UseVisualStyleBackColor = false;
            // 
            // btn_newPage
            // 
            btn_newPage.BackColor = Color.Black;
            btn_newPage.Cursor = Cursors.Hand;
            btn_newPage.FlatAppearance.MouseDownBackColor = Color.White;
            btn_newPage.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_newPage.FlatStyle = FlatStyle.Flat;
            btn_newPage.ForeColor = Color.White;
            btn_newPage.Image = Properties.Resources.edit_square;
            btn_newPage.Location = new Point(80, 274);
            btn_newPage.Name = "btn_newPage";
            btn_newPage.Size = new Size(30, 30);
            btn_newPage.TabIndex = 20;
            btn_newPage.UseVisualStyleBackColor = false;
            btn_newPage.Click += btn_newPage_Click;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.Black;
            btn_delete.Cursor = Cursors.Hand;
            btn_delete.FlatAppearance.MouseDownBackColor = Color.White;
            btn_delete.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.ForeColor = SystemColors.ControlLight;
            btn_delete.Image = Properties.Resources.delete;
            btn_delete.Location = new Point(44, 274);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(30, 30);
            btn_delete.TabIndex = 19;
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_select
            // 
            btn_select.BackColor = SystemColors.ControlLight;
            btn_select.Cursor = Cursors.Hand;
            btn_select.FlatAppearance.MouseDownBackColor = Color.White;
            btn_select.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_select.FlatStyle = FlatStyle.Flat;
            btn_select.ForeColor = Color.White;
            btn_select.Image = Properties.Resources.pointer;
            btn_select.Location = new Point(7, 274);
            btn_select.Name = "btn_select";
            btn_select.Size = new Size(30, 30);
            btn_select.TabIndex = 18;
            btn_select.UseVisualStyleBackColor = false;
            btn_select.Click += btn_select_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(panel1);
            Controls.Add(pic);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paint App";
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pic;
        private Button btn_circle;
        private Button btn_triangle;
        private Button btn_rectangle;
        private Button btn_haxagon;
        private Label label_drawing_style;
        private Label label_color_selection;
        private Label label_shape_operations;
        private Label label_file_operations;
        private Button btn_red;
        private Button btn_blue;
        private Button btn_green;
        private Button btn_orange;
        private Button btn_black;
        private Button btn_yellow;
        private Panel panel1;
        private Button btn_white;
        private Button btn_brown;
        private Button btn_newPage;
        private Button btn_delete;
        private Button btn_select;
        private Button btn_purple;
        private Button btn_save;
        private Button btn_pencil;
        private Button btn_folder;
        private Button btn_eraser;
    }
}
