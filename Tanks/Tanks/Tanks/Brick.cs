using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Brick : IObjects
    {
        public Position CurrentPosition { get; private set; }
        private int stage = 0;
        public Image WallView { get; set; }

        ImageList imageList;

        public Brick(ImageList imageList1, int x, int y)
        {
            WallView = imageList1.Images["Brick1.png"];
            CurrentPosition = new Position(x, y);
            this.imageList = imageList1;
        }

        public void AnimationOfBrokenWall(Position position)
        {
            switch (stage)
            {
                case 0:
                    {
                        stage++;
                        WallView = imageList.Images["Brick2.png"];
                        break;
                    }
                case 1:
                    {
                        stage++;
                        WallView = imageList.Images["Brick3.png"];
                        break;
                    }
                case 2:
                    {
                        stage++;
                        break;
                    }
            }
        }

        public bool IsDeleteWall(Position position)
        {
            if (position.X == CurrentPosition.X && position.Y == CurrentPosition.Y && stage == 6)
            {
                return true;
            }
            return false;
        }

        public void ChangeImageWall(PaintEventArgs e)
        {
            e.Graphics.DrawImage(WallView, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, WallView.Width, WallView.Height));
        }

        public void AnimationOfExploration(Position position)
        {
            switch (stage)
            {
                case 3:
                    {
                        WallView = imageList.Images["Explosion1.png"];
                        stage++;
                        break;
                    }
                case 4:
                    {
                        WallView = imageList.Images["Explosion2.png"];
                        stage++;
                        break;
                    }
                case 5:
                    {
                        WallView = imageList.Images["Explosion3.png"];
                        stage++;
                        break;
                    }
            }
        }
    }
}
