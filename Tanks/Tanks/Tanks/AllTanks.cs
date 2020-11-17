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
    abstract class AllTanks : ITanks, IObjects
    {
        public Position CurrentPosition { get; internal set; }
        public Position LastPosition { get; internal set; }
        public Direction Directions = new Direction();
        public ITanksView TanksView { get; set; }
        public int Speed { get; set; }
        internal Border border;
        internal Wall wall;
        internal BrokenWall brokenWall;
        public BindingList<Shot> positionsOfShot = new BindingList<Shot>();

        internal ImageList imageList;
        public event EventHandler ShotEvent;

        public AllTanks(ImageList imageList, Border border, Wall wall, BrokenWall brokenWall, int speed)
        {
            this.border = border;
            this.wall = wall;
            this.Speed = speed;
            this.imageList = imageList;
            this.brokenWall = brokenWall;
        }

        public abstract void AddTanks(PaintEventArgs e);

        public bool IsHitBorder(List<Position> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.X && CurrentPosition.Y == point.Y && LastPosition != null)
                {
                        CurrentPosition.Y = LastPosition.Y;
                        CurrentPosition.X = LastPosition.X;
                    return true;
                }
            }
            return false;
        }

        public void AnimationOfExplotion()
        {
            TanksView.AnimationOfExploration(imageList);
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

        public bool IsHitBorder(List<Brick> borderList)
        {
            foreach (var point in borderList)
            {
                if (CurrentPosition.X == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y && LastPosition != null)
                    {
                        CurrentPosition.Y = LastPosition.Y;
                        CurrentPosition.X = LastPosition.X;
                        return true;
                    }
            }
            return false;
        }
    }
}
