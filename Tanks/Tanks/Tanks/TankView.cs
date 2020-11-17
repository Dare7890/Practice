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
    class TankView : ITanksView
    {
        public Image ImageFile { get; private set; }
        private int stage = 0;

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

        public void AnimationOfExploration(ImageList imageList)
        {
            switch (stage)
            {
                case 0:
                    {
                        ImageFile = imageList.Images["Explosion1.png"];
                        stage++;
                        break;
                    }
                case 1:
                    {
                        ImageFile = imageList.Images["Explosion2.png"];
                        stage++;
                        break;
                    }
                case 2:
                    {
                        ImageFile = imageList.Images["Explosion3.png"];
                        break;
                    }
            }
        }

        public Image AnimationOfExplorations(ImageList imageList)
        {
            switch (stage)
            {
                case 0:
                    {
                        stage++;
                        return imageList.Images["Explosion1.png"];
                    }
                case 1:
                    {
                        stage++;
                        return imageList.Images["Explosion2.png"];
                    }
                case 2:
                    {
                        return imageList.Images["Explosion3.png"];
                    }
            }
            return imageList.Images["Explosion3.png"];
        }
    }
}
