using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_puzzle
{
    public partial class Remote : Form
    {
        private String imageName;
        private int column;
        private int row;

        private bool isImageMove;
        private int imageX;
        private int imageY;

        private Random random;
        private int rotate;
        private int itemSelected = 0;

        private const int R = 15;
        private const int WIDTH = 425;
        private const int HEIGHT = 425;

        private PictureBox[] pictureBoxes;

        public Remote(String imageName, int column, int row)
        {
            InitializeComponent();
            this.imageName = imageName;
            this.row = row;
            this.column = column;

            random = new Random();
            isImageMove = false;
            initImage();

            // Mặc định cái đầu tiên được chọn
            showPictureBox(itemSelected);

            this.LeftButton.Click +=  new System.EventHandler(this.Left_Click);
            this.RightButton.Click +=  new System.EventHandler(this.Right_Click);
            this.UpButton.Click +=  new System.EventHandler(this.Top_Click);
            this.DownButton.Click +=  new System.EventHandler(this.Bottom_Click);
        }

        private void initImage()
        {
            Bitmap bitmap = new Bitmap(imageName);
            Bitmap resize = new Bitmap(bitmap, new Size(425, 425));

            int width = WIDTH / this.column;
            int height = HEIGHT / this.row;

            pictureBoxes = new PictureBox[column * row];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int locationX = Pieces.Location.X + random.Next(0, WIDTH - width);
                    int locationY = Pieces.Location.Y + random.Next(0, HEIGHT - height);

                    Bitmap image = cropImage(resize, i, j);

                    int index = i * row + j;
                    pictureBoxes[index] = new PictureBox();
                    pictureBoxes[index].Size = new Size(width + R, height + R);
                    pictureBoxes[index].Location = new Point(locationX, locationY);
                    pictureBoxes[index].Image = image;
                    pictureBoxes[index].Tag = Color.Black;

                    pictureBoxes[index].Paint += new PaintEventHandler(this.imagePaint);
                    pictureBoxes[index].MouseDown += new MouseEventHandler(this.imageMouseDown);
                    pictureBoxes[index].MouseUp += new MouseEventHandler(this.imageMouseUp);
                    pictureBoxes[index].MouseMove += new MouseEventHandler(this.imageMouseMove);

                    int rotateRan = random.Next(3);
                    for(int k=0; k<rotateRan; k++)
                    {
                        turnRightPictureBox(pictureBoxes[index]);
                    }
                    

                    Pieces.Controls.Add(pictureBoxes[index]);
                    Pieces.Refresh();
                }
            }
        }

        private Bitmap cropImage(Bitmap source, int i, int j)
        {
            int width = WIDTH / this.column;
            int height = HEIGHT / this.row;

            int x = i * width;
            int y = j * height;


            Rectangle rectangle = new Rectangle(x, y, width, height);
            Bitmap bitmap = new Bitmap(rectangle.Width + R, rectangle.Height + R);
            bitmap.MakeTransparent();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                
                // Chốt bên phải nếu không phải hàng phải cùng
                if(i != this.column - 1){
                    Bitmap right = new Bitmap(2*R, 2*R);
                    
                    Graphics graphics = Graphics.FromImage(right);
                    graphics.DrawImage(
                        source,
                        0, 0, 
                        new Rectangle(x + width - R,y + height/2 - R, 2*R, 2*R),                        
                        GraphicsUnit.Pixel);

                    TextureBrush textureBrush = new TextureBrush(right);
                    g.FillEllipse(textureBrush, new Rectangle(width - R,height/2 - R, 2*R, 2*R));
                }

                // Chốt bên dưới nếu không phải hàng dưới cùng
                if(j != this.row - 1){
                    Bitmap bottom = new Bitmap(2*R, 2*R);
                    
                    Graphics graphics = Graphics.FromImage(bottom);
                    graphics.DrawImage(
                        source,
                        0, 0, 
                        new Rectangle(x + width/2 - R,y + height - R, 2*R, 2*R),                        
                        GraphicsUnit.Pixel);

                    TextureBrush textureBrush = new TextureBrush(bottom);
                    g.FillEllipse(textureBrush, new Rectangle(width/2 - R,height - R, 2*R, 2*R));
                }

                // Vẽ ảnh lên bitmap
                g.DrawImage(
                    source, 
                    0, 0,
                    rectangle,
                    GraphicsUnit.Pixel);
                
                // Khoét bên trên nếu không phải hàng trên cùng
                if(j != 0){
                    Rectangle ellip = new Rectangle(width/2 - R,- R, 2*R, 2*R);
                    g.FillEllipse(Brushes.White, ellip);
                }

                // Khoét bên trái nếu không phải hàng trái cùng
                if( i != 0){
                    Rectangle ellip = new Rectangle(-R,height/2 - R, 2*R, 2*R);
                    g.FillEllipse(Brushes.White, ellip);
                }

                return bitmap;
            }
        }

        private void imageMouseDown(object sender, MouseEventArgs e)
        {
            isImageMove = true;
            imageX = e.X;
            imageY = e.Y;

            PictureBox pictureBox = (PictureBox) sender;
            pictureBox.Tag = Color.Red;
            pictureBox.BringToFront();
            pictureBox.Refresh();
        }

        private void imageMouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if(pictureBoxes[itemSelected] == pictureBox){
                pictureBox.Tag = Color.Blue;
            }
            else{
                pictureBox.Tag = Color.Black;
            }

            pictureBox.Refresh();

            isImageMove = false;
        }

        private void imageMouseMove(object sender, MouseEventArgs e)
        {
            if (!isImageMove)
            {
                return;
            }

            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Top += (e.Y - imageY);
            pictureBox.Left += (e.X - imageX);
        }

        private void imagePaint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox) sender;
            ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, (Color) pictureBox.Tag, ButtonBorderStyle.Solid);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(itemSelected < 0 || itemSelected >= this.column * this.row){
                return;
            }

            turnRightPictureBox(pictureBoxes[itemSelected]);
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            int last = Int32.Parse(currentNumber.Text);
            int current = (last + (row * column) - 1) % (row * column);

            currentNumber.Text = current.ToString();
            // Đánh dấu vị trí chọn
            itemSelected = current;
            showPictureBox(current);
            hidePictureBox(last);
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            int last = Int32.Parse(currentNumber.Text);
            int current = (last + 1) % (row * column);
            
            currentNumber.Text = current.ToString();
            // Đánh dấu vị trí chọn
            itemSelected = current;
            showPictureBox(current);
            hidePictureBox(last);
        }

        private void hidePictureBox(int index){
            // Đổi màu cái cũ thành màu đen
            pictureBoxes[index].Tag = Color.Black;
            pictureBoxes[index].Refresh();
        }

        private void showPictureBox(int index){
            // Đổi màu cái được chọn thành màu xanh
            pictureBoxes[index].Tag = Color.Blue;
            pictureBoxes[index].Refresh();
            pictureBoxes[index].BringToFront();
        }

        private void turnRightPictureBox(PictureBox pictureBox)
        {
            int width = pictureBox.Height;
            int height = pictureBox.Width;

            pictureBox.Width = width;
            pictureBox.Height = height;

            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox.Refresh();
        }
        
        private void Left_Click(object sender, EventArgs e)
        {
            PictureBox p = pictureBoxes[itemSelected];
            p.Left -= 5;
        }

        private void Right_Click(object sender, EventArgs e)
        {
            PictureBox p = pictureBoxes[itemSelected];
            p.Left += 5;
        }

        private void Top_Click(object sender, EventArgs e)
        {
            PictureBox p = pictureBoxes[itemSelected];
            p.Top -= 5;
        }

        private void Bottom_Click(object sender, EventArgs e)
        {
            PictureBox p = pictureBoxes[itemSelected];
            p.Top += 5;
        }
        
    }
}

