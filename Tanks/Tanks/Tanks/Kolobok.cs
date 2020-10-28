using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Kolobok
    {
        public Position CurrentPosition { get; private set; }
        public Position LastPosition { get; private set; }
        public Direction Directions = new Direction();
        public KolobokView KolobokView { get; set; }
        public KolobokView CurrentImage { get; set; }
        Border border;
        Wall wall;

        private ImageList imageList;
        private Graphics g;

        public Kolobok(ImageList imageList, Graphics g, Border border, Wall wall)
        {
            CurrentPosition = new Position(20, 20);
            LastPosition = new Position(20, 20);
            Directions = Direction.RIGHT;
            this.imageList = imageList;
            KolobokView = new KolobokView(imageList);
            this.g = g;
            this.wall = wall;
            this.border = border;
        }

        public void AddKolobok(PaintEventArgs e)
        {
            //add array to ImageFile
            e.Graphics.DrawImage(KolobokView.ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, KolobokView.ImageFile.Width, KolobokView.ImageFile.Height));
        }

        public void Move(Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                CurrentPosition.X += 20;
                if (!IsHitBorder(border.borderList) && !IsHitWall(wall.Points))
                {
                    Directions = Direction.RIGHT;
                    KolobokView.ChangeImage(imageList, Directions);
                    LastPosition.X = CurrentPosition.X;
                }
            }
            else if (keyData == Keys.Left)
            {
                CurrentPosition.X -= 20;
                if (!IsHitBorder(border.borderList) && !IsHitWall(wall.Points))
                {
                    Directions = Direction.LEFT;
                    KolobokView.ChangeImage(imageList, Directions);
                    LastPosition.X = CurrentPosition.X;
                }
            }
            else if (keyData == Keys.Up)
            {
                CurrentPosition.Y -= 20;
                if (!IsHitBorder(border.borderList) && !IsHitWall(wall.Points))
                {
                    Directions = Direction.UP;
                    KolobokView.ChangeImage(imageList, Directions);
                    LastPosition.Y = CurrentPosition.Y;
                }
            }
            else if (keyData == Keys.Down)
            {
                CurrentPosition.Y += 20;
                if (!IsHitBorder(border.borderList) && !IsHitWall(wall.Points))
                {
                    Directions = Direction.DOWN;
                    KolobokView.ChangeImage(imageList, Directions);
                    LastPosition.Y = CurrentPosition.Y;
                }
            }
        }

        public bool IsHitBorder(List<Position> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y)
                {
                    CurrentPosition.Y = LastPosition.Y;
                    CurrentPosition.X = LastPosition.X;
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
                    CurrentPosition.Y = LastPosition.Y;
                    CurrentPosition.X = LastPosition.X;
                    return true;
                }
            }
            return false;
        }
    }
}
