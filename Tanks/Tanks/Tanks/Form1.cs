using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        int countOfTanks = 5;
        int countOfApple = 5;
        Wall wall;
        Kolobok kolobok;
        Apple[] apple;
        Tank[] tank;
        int speed = 0;

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
            pictureBox1.Image = buf;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbCountOfTanks.Text, out countOfTanks))
            {
                label2.Text = "Введите корректное значение";
                return;
            }
            
            if (!int.TryParse(tbCountOfApple.Text, out countOfApple))
            {
                lblError.Text = "Введите корректное значение";
                return;
            }

            if (!int.TryParse(tbSpeed.Text, out speed))
            {
                label6.Text = "Введите корректное значение";
                return;
            }

            tank = new Tank[countOfTanks];
            kolobok = new Kolobok(imageList1, border, wall, speed);
            for (int i = 0; i < countOfTanks; i++)
            {
                tank[i] = new Tank(imageList1, border, wall, kolobok, speed);
                Thread.Sleep(50);
            }

            kolobok.InitEvent(tank);

            apple = new Apple[countOfApple];
            for (int i = 0; i < countOfApple; i++)
            {
                apple[i] = new Apple(imageList1, border, wall);
                Thread.Sleep(50);
            }

            pictureBox1.Image = buf;
            timer1.Start();
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kolobok.positionsOfShot != null)
            {
                for (int i = 0; i < kolobok.positionsOfShot.Count; i++)
                {
                    if (!kolobok.positionsOfShot[i].IsHitBorder(border.borderList,
                        kolobok.positionsOfShot[i].Directions) &&
                        !kolobok.positionsOfShot[i].IsHitBorder(wall.Points, kolobok.positionsOfShot[i].Directions))
                    {
                        kolobok.positionsOfShot[i].MoveAsync(kolobok.positionsOfShot[i].Directions);
                    }
                    else
                    {
                        kolobok.positionsOfShot[i].Dispose();
                        kolobok.positionsOfShot.Remove(kolobok.positionsOfShot[i]);
                    }
                }
            }

            for (int i = 0; i < countOfTanks; i++)
            {
                tank[i].Move();
                if (kolobok.IsGameOver == true)
                {
                    timer1.Stop();
                    lblTheEnd.Text = "Game Over!";
                    btnStart.Enabled = true;
                    return;
                }

                if (tank != null && tank[i].positionsOfShot != null)
                {
                    for (int j = 0; j < tank[i].positionsOfShot.Count; j++)
                    {
                        if (!tank[i].positionsOfShot[j].IsHitBorder(border.borderList,
                            tank[i].positionsOfShot[j].Directions) &&
                            !tank[i].positionsOfShot[j].IsHitBorder(wall.Points, tank[i].positionsOfShot[j].Directions))
                        {
                            tank[i].positionsOfShot[j].MoveAsync(tank[i].positionsOfShot[j].Directions);
                        }
                        else
                        {
                            tank[i].positionsOfShot[j].Dispose();
                            tank[i].positionsOfShot.Remove(tank[i].positionsOfShot[j]);
                        }
                    }
                }

                if (kolobok.IsHitBorder(tank[i].CurrentPosition))
                {
                    timer1.Stop();
                    lblTheEnd.Text = "Game Over!";
                    btnStart.Enabled = true;
                }
            }

            for (int i = 0; i < countOfApple; i++)
            {
                if (kolobok.IsHitBorder(apple[i].CurrentPosition))
                {
                    kolobok.EatingApple();
                    apple[i].CreateRandomLocation();
                    lblAmountApple.Text = "Количество съеденных яблок: " + kolobok.Score;
                }
            }
            pictureBox1.Image = buf;
            this.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < countOfApple; i++)
            {
                if (apple != null)
                    apple[i].AddTanks(e);
            }
            if (kolobok != null)
                kolobok.AddTanks(e);
            for (int i = 0; i < countOfTanks; i++)
            {
                if (tank != null)
                    tank[i].AddTanks(e);

                if (tank != null && tank[i].positionsOfShot != null)
                {
                    foreach (var shot in tank[i].positionsOfShot)
                    {
                        shot.AddShot(e);
                    }
                }
            }
            if (kolobok != null && kolobok.positionsOfShot != null)
            {
                foreach (var shot in kolobok.positionsOfShot)
                {
                    shot.AddShot(e);
                }
            }
        }

        public void Reset()
        {
            lblTheEnd.Text = "";
            btnStart.Enabled = false;
            label2.Text = "";
            lblError.Text = "";
            lblAmountApple.Text = "";
            btnStatistic.Enabled = true;
            label2.Visible = false;
            label1.Visible = false;
            tbSpeed.Visible = false;
            label5.Visible = false;
            tbCountOfTanks.Visible = false;
            lblError.Visible = false;
            label4.Visible = false;
            tbCountOfApple.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (kolobok != null)
                kolobok.MoveAsync(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void btnStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm statisticForm = new StatisticForm(kolobok, tank, apple);
            btnStatistic.Enabled = false;
            await Task.Factory.StartNew<DialogResult>(
                                             () => statisticForm.ShowDialog(),
                                             TaskCreationOptions.LongRunning);
        }
    }
}
