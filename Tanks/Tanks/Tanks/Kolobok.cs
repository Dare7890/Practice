using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Kolobok
    {
        public Position CurrentPosition { get; private set; }
        public Direction Directions = new Direction();
        public KolobokView KolobokView { get; set; }

        private ImageList imageList;

        public Kolobok(ImageList imageList)
        {
            CurrentPosition = new Position(0, 0);
            Directions = Direction.RIGHT;
            this.imageList = imageList;
            //KolobokView = new KolobokView(this, imageList);
        }
    }
}
