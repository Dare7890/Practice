using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Wall
    {
        public List<Position> Points { get; private set; }

        private ImageList imageList1;
        Graphics g;


        public Wall(ImageList imageList1, Graphics g)
        {
            Points = new List<Position>();
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
                    imageList1.Draw(g, new Point(i, j), 3);
                    Points.Add(p);
                }
            }
        }

    }
}
