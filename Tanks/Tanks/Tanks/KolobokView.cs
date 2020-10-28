using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class KolobokView
    {
        public Image ImageFile { get; private set; }

        public KolobokView(ImageList imageList)
        {
            ImageFile = imageList.Images["Player_right.png"];
        }

        public void ChangeImage(ImageList imageList, Direction directions)
        {
            if (directions == Direction.RIGHT)
            {
                ImageFile = imageList.Images["Player_right.png"];
            }
            else if (directions == Direction.LEFT)
            {
                ImageFile = imageList.Images["Player_left.png"];
            }
            else if (directions == Direction.UP)
            {
                ImageFile = imageList.Images["Player.png"];
            }
            else if (directions == Direction.DOWN)
            {
                ImageFile = imageList.Images["Player_down.png"];
            }
        }
    }
}
