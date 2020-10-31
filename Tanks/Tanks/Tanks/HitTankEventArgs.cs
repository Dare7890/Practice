using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class HitTankEventArgs : EventArgs
    {
        public BindingList<Shot> positionsOfShot = new BindingList<Shot>();

        public HitTankEventArgs(BindingList<Shot> positionsOfShot)
        {
            foreach (var item in positionsOfShot)
            {
                this.positionsOfShot.Add(item);
            }
        }
    }
}
