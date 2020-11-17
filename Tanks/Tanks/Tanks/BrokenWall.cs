using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class BrokenWall : IWall
    {
        public List<Brick> Points { get; private set; }
        private ImageList imageList1;
        Graphics g;


        public BrokenWall(ImageList imageList1, Graphics g)
        {
            Points = new List<Brick>();
            this.imageList1 = imageList1;
            this.g = g;
        }

        public void AddBiglWall(int startX, int endX, int startY, int endY)
        {
            for (int i = startX; i < endX; i += 20)
            {
                for (int j = startY; j < endY; j += 20)
                {
                    Position p = new Position(i, j);
                    Brick brick = new Brick(imageList1, i, j);
                    imageList1.Draw(g, new Point(i, j), 18);
                    Points.Add(brick);
                }
            }
        }

        public void AnimationOfBrokenWall(Position position)
        {
            foreach (var point in Points.ToList())
            {
                if (point.CurrentPosition.X == position.X && point.CurrentPosition.Y == position.Y)
                    point.AnimationOfBrokenWall(position);
            }
        }

        public void AnimationOfExploration(Position position)
        {
            if (position != null)
            {
                foreach (var point in Points.ToList())
                {
                    point.AnimationOfExploration(position);
                    if (point.IsDeleteWall(position))
                    {
                        Points.Remove(point);
                        SolidBrush bf = new SolidBrush(Color.Black);
                        g.FillRectangle(bf, point.CurrentPosition.X, point.CurrentPosition.Y,
                            20, 20);
                    }
                }
            }
        }

        public void ChangeImageWall(PaintEventArgs e, Position position)
        {
            foreach (var point in Points)
            {
                point.ChangeImageWall(e);
            }
        }
    }
}
