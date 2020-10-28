using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Border
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public PictureBox PictureBox { get; private set; }
        public List<Position> borderList { get; private set; }

        private ImageList imageList1;
        private Graphics g;

        public Border(int width, int height, ImageList imageList1, Graphics g)
        {
            borderList = new List<Position>();
            this.Width = width;
            this.Height = height;
            this.imageList1 = imageList1;
            this.g = g;

            BrushBackground();
        }

        public void HorizontalLineOfBorder(int y)
        {
            for (int i = 0; i < Width; i = i + 20)
            {
                Position position = new Position(i, y);
                imageList1.Draw(g, new Point(i, y), 5);
                borderList.Add(position);
            }
        }

        public void VerticalLineOfBorder(int x)
        {
            for (int i = 0; i < Height; i = i + 20)
            {
                Position position = new Position(x, i);
                imageList1.Draw(g, new Point(x, i), 5);
                borderList.Add(position);
            }
        }

        private void BrushBackground()
        {
            SolidBrush bf = new SolidBrush(Color.Black);
            g.FillRectangle(bf, 0, 0, Width, Height);
        }
    }
}
