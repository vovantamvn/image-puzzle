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

        //
        private bool isImageMove;
        private int imageX;
        private int imageY;

        private Random random;
        private int rotate;
        public Remote(String imageName, int column, int row)
        {
            InitializeComponent();
            this.imageName = imageName;
            this.row = row;
            this.column = column;

            random = new Random();
            isImageMove = false;
            initImage();
        }

        private void initImage()
        {
            Bitmap bitmap = new Bitmap(imageName);
            Bitmap resize = new Bitmap(bitmap, new Size(425, 425));

            int width = 425 / this.column;
            int height = 425 / this.row;

            PictureBox[] pictureBoxes = new PictureBox[column * row];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int x = i * width;
                    int y = j * height;


                    int locationX = Pieces.Location.X + random.Next(0, 425 - width);
                    int locationY = Pieces.Location.Y + random.Next(0, 425 - height);

                    Bitmap image = cropImage(resize, x, y);

                    int index = i * row + j;
                    pictureBoxes[index] = new PictureBox();
                    pictureBoxes[index].Size = new Size(width, height);
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
                        randomTurnRight(pictureBoxes[index]);
                    }
                    

                    Pieces.Controls.Add(pictureBoxes[index]);
                    Pieces.Refresh();
                }
            }

        }

        private Bitmap cropImage(Bitmap source, int x, int y)
        {
            int width = 425 / this.column;
            int height = 425 / this.row;

            Rectangle rectangle = new Rectangle(x, y, width, height);
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(
                    source,
                    0, 0,
                    rectangle,
                    GraphicsUnit.Pixel);
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
            pictureBox.Tag = Color.Black;
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

        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            int current = Int32.Parse(currentNumber.Text);
            current += (row * column) - 1;
            current %= (row * column);
            currentNumber.Text = current.ToString();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            int current = Int32.Parse(currentNumber.Text);
            current += 1;
            current %= (row * column);
            currentNumber.Text = current.ToString();
        }

        private void randomTurnRight(PictureBox pictureBox)
        {
            int width = pictureBox.Height;
            int height = pictureBox.Width;

            pictureBox.Width = width;
            pictureBox.Height = height;

            pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox.Refresh();
        }

    }
}

