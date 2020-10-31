using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class KolobokEventArgs : EventArgs
    {
        public Position CurrentPosition { get; private set; }
        public Direction Directions = new Direction();

        public KolobokEventArgs(Position currentPosition, Direction direction)
        {
            CurrentPosition = currentPosition;
            Directions = direction;
        }
    }
}
