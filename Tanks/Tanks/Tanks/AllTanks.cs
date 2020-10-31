using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    abstract class AllTanks : ITanks
    {
        public Position CurrentPosition { get; internal set; }
        public Position LastPosition { get; internal set; }
        public Direction Directions = new Direction();
        public ITanksView TanksView { get; set; }
        public int Speed { get; set; }
        internal Border border;
        internal Wall wall;
        public BindingList<Shot> positionsOfShot = new BindingList<Shot>();

        internal ImageList imageList;
        public event EventHandler ShotEvent;

        public AllTanks(ImageList imageList, Border border, Wall wall, int speed)
        {
            this.border = border;
            this.wall = wall;
            this.Speed = speed;
            this.imageList = imageList;
        }

        public abstract void AddTanks(PaintEventArgs e);

        public bool IsHitBorder(List<Position> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y)
                {
                    try
                    {
                        CurrentPosition.Y = LastPosition.Y;
                        CurrentPosition.X = LastPosition.X;
                    }
                    catch (NullReferenceException)
                    {

                    }
                    return true;
                }
            }
            return false;
        }

        public bool IsHitBorder(Position position)
        {
            if (CurrentPosition.X == position.X && CurrentPosition.Y == position.Y)
                return true;
            return false;
        }
        
        public void OnShot(KolobokEventArgs e)
        {
            EventHandler shotEvent = ShotEvent;
            shotEvent?.Invoke(this, e);
        }

        internal void Shot()
        {
            KolobokEventArgs kolobokEventArgs = new KolobokEventArgs(CurrentPosition, Directions);

            Shot shot = new Shot(imageList, this);
            positionsOfShot.Add(shot);
            OnShot(kolobokEventArgs);
        }
    }
}
