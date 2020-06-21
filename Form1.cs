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
    public partial class Form1 : Form
    {
        private Remote remote;
        private String imageName;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disnableHelp();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open image";
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(null != this.remote)
                {
                    this.remote.Dispose();
                }

                imageName = openFileDialog.FileName;
                initRemote();
                disnableHelp();
            }

            openFileDialog.Dispose();
        }

        private void initRemote()
        {
            int column = (int) this.columnNumber.Value;
            int row = (int) this.rowNumber.Value;

            Point point = new Point();
            point.X = this.Location.X + this.Width;
            point.Y = this.Location.Y + this.Height;

            remote = new Remote(imageName, column, row);
            remote.PointToScreen(point);
            remote.Show();
        }

        private void enableHelp()
        {
            this.checkBox1.Enabled = true;
        }

        private void disnableHelp()
        {
            this.checkBox1.Enabled = false;
        }
    }
}
