using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class TankView
    {
        public Image ImageFile { get; private set; }

        public TankView(ImageList imageList)
        {
            ImageFile = imageList.Images["Enemy_Right.png"];
        }

        public void ChangeImage(ImageList imageList, Direction directions)
        {
            if (directions == Direction.RIGHT)
            {
                ImageFile = imageList.Images["Enemy_Right.png"];
            }
            else if (directions == Direction.LEFT)
            {
                ImageFile = imageList.Images["Enemy.png"];
            }
            else if (directions == Direction.UP)
            {
                ImageFile = imageList.Images["Enemy_Up.png"];
            }
            else if (directions == Direction.DOWN)
            {
                ImageFile = imageList.Images["Enemy_Down.png"];
            }
        }
    }
}
