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
    public partial class Tanks : Form
    {
        Graphics g;
        Bitmap buf;

        int width = 700;
        int height = 400;
        Border border;
        int countOfTanks = 5;
        int countOfApple = 5;
        Wall wall;
        BrokenWall brokenWall;
        Kolobok kolobok;
        Apple[] apple;
        Tank[] tank;
        Position positionOfHit;
        BindingList<IObjects> listOfObjects;
        int speed = 1;

        public Tanks()
        {
            InitializeComponent();
            timer1.Interval = 200;
            listOfObjects = new BindingList<IObjects>();
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
            brokenWall = new BrokenWall(imageList1, g);
            wall.AddBiglWall(80, 120, 60, 160);
            brokenWall.AddBiglWall(160, 200, 60, 160);
            wall.AddBiglWall(300, 340, 60, 140);
            wall.AddBiglWall(380, 420, 60, 140);
            brokenWall.AddBiglWall(500, 540, 60, 160);
            wall.AddBiglWall(580, 620, 60, 160);


            brokenWall.AddBiglWall(20, 80, 200, 240);
            brokenWall.AddBiglWall(120, 200, 200, 240);
            wall.AddBiglWall(240, 340, 180, 220);
            wall.AddBiglWall(380, 460, 180, 220);
            wall.AddBiglWall(500, 580, 200, 240);
            brokenWall.AddBiglWall(620, 680, 200, 240);


            wall.AddBiglWall(80, 120, 280, 340);
            wall.AddBiglWall(160, 200, 280, 340);
            wall.AddBiglWall(300, 340, 260, 340);
            wall.AddBiglWall(380, 420, 260, 340);
            wall.AddBiglWall(340, 380, 280, 300);
            brokenWall.AddBiglWall(460, 500, 300, 380);
            brokenWall.AddBiglWall(580, 620, 300, 380);
            brokenWall.AddBiglWall(500, 580, 300, 320);
            pictureBox1.Image = buf;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCountOfTanks.Text) && !int.TryParse(tbCountOfTanks.Text, out countOfTanks))
            {
                label2.Text = "Введите корректное значение";
                return;
            }

            if (!String.IsNullOrEmpty(tbCountOfApple.Text) && !int.TryParse(tbCountOfApple.Text, out countOfApple))
            {
                lblError.Text = "Введите корректное значение";
                return;
            }

            if (!String.IsNullOrEmpty(tbSpeed.Text) && !int.TryParse(tbSpeed.Text, out speed))
            {
                label6.Text = "Введите корректное значение";
                return;
            }

            tank = new Tank[countOfTanks];
            kolobok = new Kolobok(imageList1, border, wall, brokenWall, speed);
            listOfObjects.Add(kolobok);
            for (int i = 0; i < countOfTanks; i++)
            {
                tank[i] = new Tank(imageList1, border, wall, kolobok, brokenWall,speed);
                listOfObjects.Add(tank[i]);
                Thread.Sleep(50);
            }

            kolobok.InitEvent(tank);

            apple = new Apple[countOfApple];
            for (int i = 0; i < countOfApple; i++)
            {
                apple[i] = new Apple(imageList1, border, wall, brokenWall);
                listOfObjects.Add(apple[i]);
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
                    if ( kolobok.positionsOfShot[i].IsHitBorder(brokenWall.Points, 
                        kolobok.positionsOfShot[i].Directions))
                    {
                        if (kolobok.positionsOfShot[i].HitBorderPosition(brokenWall.Points,
                        kolobok.positionsOfShot[i].Directions) != null)
                        {
                             positionOfHit = kolobok.positionsOfShot[i].HitBorderPosition(
                                brokenWall.Points, kolobok.positionsOfShot[i].Directions);
                            brokenWall.AnimationOfBrokenWall(positionOfHit);
                            kolobok.positionsOfShot[i].Dispose();
                            kolobok.positionsOfShot.Remove(kolobok.positionsOfShot[i]);
                        }
                    }
                    else if (!kolobok.positionsOfShot[i].IsHitBorder(border.borderList,
                        kolobok.positionsOfShot[i].Directions) &&
                        !kolobok.positionsOfShot[i].IsHitBorder(wall.Points, kolobok.positionsOfShot[i].Directions)
                        && !kolobok.positionsOfShot[i].IsHitBorder(brokenWall.Points, kolobok.positionsOfShot[i].Directions))
                    {
                        kolobok.positionsOfShot[i].Move(kolobok.positionsOfShot[i].Directions);
                    }
                    else 
                    {
                        kolobok.positionsOfShot[i].Dispose();
                        kolobok.positionsOfShot.Remove(kolobok.positionsOfShot[i]);
                    }
                }
            }
            
            brokenWall.AnimationOfExploration(positionOfHit);

            for (int i = 0; i < countOfTanks; i++)
            {
                tank[i].Move();
                if (kolobok.IsGameOver == true)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        kolobok.AnimationOfExplotion();
                        pictureBox1.Image = buf;
                        pictureBox1.Refresh();
                        Thread.Sleep(200);
                    }
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
                            !tank[i].positionsOfShot[j].IsHitBorder(wall.Points, tank[i].positionsOfShot[j].Directions)
                            && !tank[i].positionsOfShot[j].IsHitBorder(brokenWall.Points, tank[i].positionsOfShot[j].Directions))
                        {
                            tank[i].positionsOfShot[j].Move(tank[i].positionsOfShot[j].Directions);
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

                if (tank != null && tank[i].positionOfKill != null && tank[i].countOfShot < 3)
                {
                    tank[i].AddExplorationOfTanks(e);
                }
            }
            if (kolobok != null && kolobok.positionsOfShot != null)
            {
                foreach (var shot in kolobok.positionsOfShot.ToList())
                {
                    shot.AddShot(e);
                }
            }
            if (positionOfHit != null)
            brokenWall.ChangeImageWall(e, positionOfHit);

            if (kolobok != null)
                kolobok.AddTanks(e);
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
                kolobok.Move(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void btnStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm statisticForm = new StatisticForm(kolobok, tank, apple);
            await Task.Run(new Action(() =>
            {
                statisticForm.ShowDialog();
            }));
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteStateOfGame writeStateOfGame = new WriteStateOfGame();
            writeStateOfGame.WriteState(listOfObjects);
        }
    }
}
