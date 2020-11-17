using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Apple : ITanks, IObjects
    {
        public Position CurrentPosition { get; private set; }
        public Image ImageFile { get; private set; }
        Random random = new Random();
        Border border;
        Wall wall;
        BrokenWall brokenWall;

        private ImageList imageList;

        public Apple(ImageList imageList, Border border, Wall wall, BrokenWall brokenWall)
        {
            this.border = border;
            this.wall = wall;
            this.brokenWall = brokenWall;
            CreateRandomLocation();
            this.imageList = imageList;
            ImageFile = imageList.Images["Apple.png"];
        }

        public void CreateRandomLocation()
        {
            CurrentPosition = new Position();

            while (true)
            {
                int numberWidth = random.Next((int)border.Width / 20) * 20;
                int numberHeight = random.Next((int)border.Height / 20) * 20;
                CurrentPosition.X = numberWidth;
                CurrentPosition.Y = numberHeight;
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points) && 
                    !IsHitBorder(brokenWall.Points))
                    break;
            }
        }

        public void AddTanks(PaintEventArgs e)
        {
            e.Graphics.DrawImage(ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, ImageFile.Width, ImageFile.Height));
        }

        public bool IsHitBorder(List<Position> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y)
                    return true;
            }
            return false;
        }

        public bool IsHitBorder(List<Brick> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y)
                    return true;
            }
            return false;
        }
    }
}
