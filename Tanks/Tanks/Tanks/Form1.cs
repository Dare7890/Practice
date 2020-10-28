using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap buf;

        int width = 700;
        int height = 400;
        Border border;
        Wall wall;
        Kolobok kolobok;
        AllTanks allTanks;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 200;
            buf = new Bitmap(Width, Height);
            g = Graphics.FromImage(buf);
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            border = new Border(width, height, imageList1, g);
            border.HorizontalLineOfBorder(0);
            border.HorizontalLineOfBorder(height - 20);
            border.VerticalLineOfBorder(0);
            border.VerticalLineOfBorder(width - 20);
            wall = new Wall(imageList1, g);
            wall.AddBiglWall(80, 120, 60, 160);
            wall.AddBiglWall(160, 200, 60, 160);
            wall.AddBiglWall(300, 340, 60, 140);
            wall.AddBiglWall(380, 420, 60, 140);
            wall.AddBiglWall(500, 540, 60, 160);
            wall.AddBiglWall(580, 620, 60, 160);


            wall.AddBiglWall(20, 80, 200, 240);
            wall.AddBiglWall(120, 200, 200, 240);
            wall.AddBiglWall(240, 340, 180, 220);
            wall.AddBiglWall(380, 460, 180, 220);
            wall.AddBiglWall(500, 580, 200, 240);
            wall.AddBiglWall(620, 680, 200, 240);


            wall.AddBiglWall(80, 120, 280, 340);
            wall.AddBiglWall(160, 200, 280, 340);
            wall.AddBiglWall(300, 340, 260, 340);
            wall.AddBiglWall(380, 420, 260, 340);
            wall.AddBiglWall(340, 380, 280, 300);
            wall.AddBiglWall(460, 500, 300, 380);
            wall.AddBiglWall(580, 620, 300, 380);
            wall.AddBiglWall(500, 580, 300, 320);

            kolobok = new Kolobok(imageList1, g, border, wall);

            pictureBox1.Image = buf;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = buf;
            this.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            kolobok.AddKolobok(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            kolobok.Move(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
