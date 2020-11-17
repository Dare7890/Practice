using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    interface ITanksView
    {
        Image ImageFile { get; }

        void AnimationOfExploration(ImageList imageList);
        void ChangeImage(ImageList imageList, Direction directions);
    }
}
