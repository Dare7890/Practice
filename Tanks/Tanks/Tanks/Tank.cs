using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Tank
    {
        public Position CurrentPosition { get; private set; }
        public Position LastPosition { get; private set; }
        public Direction Directions = new Direction();
        public TankView TankView { get; set; }
        public TankView CurrentImage { get; set; }
        public static BindingList<Tank> positionsOfTanks = new BindingList<Tank>();
        Random random = new Random();
        Border border;
        Wall wall;

        private ImageList imageList;
        private Graphics g;

        public Tank(ImageList imageList, Graphics g, Border border, Wall wall)
        {
            this.border = border;
            this.wall = wall;
            CreateRandomLocation();
            LastPosition = new Position(CurrentPosition);
            Directions = Direction.RIGHT;
            this.imageList = imageList;
            TankView = new TankView(imageList);
            this.g = g;
            positionsOfTanks.Add(this);
        }

        private void CreateRandomLocation()
        {
            CurrentPosition = new Position();

            while (true)
            {
                int numberWidth = random.Next((int)border.Width / 20) * 20;
                int numberHeight = random.Next((int)border.Height / 20) * 20;
                CurrentPosition.X = numberWidth;
                CurrentPosition.Y = numberHeight;
                if (!IsHitBorder(border.borderList) && !IsHitWall(wall.Points))
                    break;
            }
        }

        public void AddTank(PaintEventArgs e)
        {
            e.Graphics.DrawImage(TankView.ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, TankView.ImageFile.Width, TankView.ImageFile.Height));
        }

        private Direction RandomDirection()
        {
            int value = random.Next(600);
            if (value > 300 && value < 400)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            if (value > 400 && value < 500)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            if (value > 500 && value < 600)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            return Directions;
        }

        private bool IsHitTanks()
        {
            if (positionsOfTanks.Where(tank => tank.CurrentPosition.X == CurrentPosition.X &&
            tank.CurrentPosition.Y == CurrentPosition.Y).Count() > 1)
                return true;
            else
            return false;
        }

        private void TurnTanks()
        {
            if (IsHitTanks())
            {
                var tanks = positionsOfTanks.Where(tank => tank.CurrentPosition.X == CurrentPosition.X &&
            tank.CurrentPosition.Y == CurrentPosition.Y && tank == this).ToList();
                foreach (var tank in tanks)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        tank.Directions++;
                        if ((int)tank.Directions == 4)
                            tank.Directions = 0;
                    }
                    tank.CurrentPosition.X = tank.LastPosition.X;
                    tank.CurrentPosition.Y = tank.LastPosition.Y;
                }
            }
        }

        public void Move()
        {
            if (Directions == Direction.RIGHT)
            {
                CurrentPosition.X += 20;
                if (IsHitBorder(border.borderList) || IsHitWall(wall.Points)) { }
                LastPosition.X = CurrentPosition.X;
            }
            else if (Directions == Direction.LEFT)
            {
                CurrentPosition.X -= 20;
                if (IsHitBorder(border.borderList) || IsHitWall(wall.Points)) { }
                LastPosition.X = CurrentPosition.X;
            }
            else if (Directions == Direction.UP)
            {
                CurrentPosition.Y -= 20;
                if (IsHitBorder(border.borderList) || IsHitWall(wall.Points)) { }
                LastPosition.Y = CurrentPosition.Y;
            }
            else if (Directions == Direction.DOWN)
            {
                CurrentPosition.Y += 20;
                if (IsHitBorder(border.borderList) || IsHitWall(wall.Points)) { }
                LastPosition.Y = CurrentPosition.Y;
            }
            TankView.ChangeImage(imageList, Directions);
            Directions = RandomDirection();
            TurnTanks();
        }

        public bool IsHitBorder(List<Position> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y)
                {
                    try
                    {
                        CurrentPosition.Y = LastPosition.Y;
                        CurrentPosition.X = LastPosition.X;
                    }
                    catch (NullReferenceException a)
                    {

                    }
                    return true;
                }
            }
            return false;
        }

        public bool IsHitWall(List<Position> wallList)
        {
            foreach (var point in wallList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y)
                {
                    try
                    {
                        CurrentPosition.Y = LastPosition.Y;
                        CurrentPosition.X = LastPosition.X;
                    }
                    catch (NullReferenceException a)
                    {

                    }
                    return true;
                }
            }
            return false;
        }
    }
}
