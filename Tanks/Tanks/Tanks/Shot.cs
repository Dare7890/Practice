using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Shot : IDisposable
    {
        public Position CurrentPosition { get; private set; }
        public Image ImageFile { get; private set; }
        public int Speed { get; set; }
        Kolobok kolobok;
        Tank tank;
        public Direction Directions { get; private set; }


        private ImageList imageList;

        public Shot(ImageList imageList, ITanks tanks)
        {
            this.imageList = imageList;
            CurrentPosition = new Position(tanks.CurrentPosition.X, tanks.CurrentPosition.Y);
            Directions = new Direction();
            if (tanks is Tank)
            {
                Tank tank = tanks as Tank;
                ImageFile = imageList.Images["Enemy_Shot.png"];
                this.tank = tank;
                tank.ShotEvent += Kolobok_ShotEvent;
                Speed = tank.Speed;

            }
            else if (tanks is Kolobok)
            {
                Kolobok kolobok = tanks as Kolobok;
                ImageFile = imageList.Images["Shot.png"];
                this.kolobok = kolobok;
                kolobok.ShotEvent += Kolobok_ShotEvent;
                Speed = kolobok.Speed;
            }
        }

        private void Kolobok_ShotEvent(object sender, EventArgs e)
        {
            if (e is KolobokEventArgs)
            {
                KolobokEventArgs kolobokEventArgs = e as KolobokEventArgs;
                Directions = kolobokEventArgs.Directions;
                Move(kolobokEventArgs);
            }
        }

        
        public void AddShot(PaintEventArgs e)
        {
            e.Graphics.DrawImage(ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, ImageFile.Width, ImageFile.Height));
        }

        public void Move(KolobokEventArgs kolobokEventArgs)
        {
            if (kolobokEventArgs.Directions == Direction.RIGHT)
            {
                CurrentPosition.X += (20 * Speed);
            }
            else if (kolobokEventArgs.Directions == Direction.LEFT)
            {
                CurrentPosition.X -= (20 * Speed);
            }
            else if (kolobokEventArgs.Directions == Direction.UP)
            {
                CurrentPosition.Y -= (20 * Speed);
            }
            else if (kolobokEventArgs.Directions == Direction.DOWN)
            {
                CurrentPosition.Y += (20 * Speed);
            }
            if (kolobok != null)
            kolobok.ShotEvent -= Kolobok_ShotEvent;
            if (tank != null)
                tank.ShotEvent -= Kolobok_ShotEvent;
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                CurrentPosition.X += (20 * Speed);
            }
            else if (direction == Direction.LEFT)
            {
                CurrentPosition.X -= (20 * Speed);
            }
            else if (direction == Direction.UP)
            {
                CurrentPosition.Y -= (20 * Speed);
            }
            else if (direction == Direction.DOWN)
            {
                CurrentPosition.Y += (20 * Speed);
            }
        }

        public bool IsHitBorder(List<Position> borderList, Direction direction)
        {
            foreach (var point in borderList)
            {
                if (direction == Direction.RIGHT)
                {
                    if ((CurrentPosition.X + (20 * Speed)) == point.X && CurrentPosition.Y == point.Y)
                        return true;
                }
                else if (direction == Direction.LEFT)
                {
                    if ((CurrentPosition.X - (20 * Speed)) == point.X && CurrentPosition.Y == point.Y)
                        return true;
                }
                else if (direction == Direction.UP)
                {
                    if (CurrentPosition.X == point.X && (CurrentPosition.Y - (20 * Speed)) == point.Y)
                        return true;
                }
                else if (direction == Direction.DOWN)
                {
                    if (CurrentPosition.X == point.X && (CurrentPosition.Y + (20 * Speed)) == point.Y)
                        return true;
                }
            }
            return false;
        }

        public bool IsHitBorder(List<Brick> borderList, Direction direction)
        {
            foreach (var point in borderList)
            {
                if (direction == Direction.RIGHT)
                {
                    if ((CurrentPosition.X) == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y)
                        return true;
                }
                else if (direction == Direction.LEFT)
                {
                    if ((CurrentPosition.X) == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y)
                        return true;
                }
                else if (direction == Direction.UP)
                {
                    if (CurrentPosition.X == point.CurrentPosition.X && (CurrentPosition.Y) == point.CurrentPosition.Y)
                        return true;
                }
                else if (direction == Direction.DOWN)
                {
                    if (CurrentPosition.X == point.CurrentPosition.X && (CurrentPosition.Y) == point.CurrentPosition.Y)
                        return true;
                }
            }
            return false;
        }

        public Position HitBorderPosition(List<Position> borderList, Direction direction)
        {
            foreach (var point in borderList)
            {
                if (direction == Direction.RIGHT)
                {
                    if ((CurrentPosition.X + (20 * Speed)) == point.X && CurrentPosition.Y == point.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.LEFT)
                {
                    if ((CurrentPosition.X - (20 * Speed)) == point.X && CurrentPosition.Y == point.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.UP)
                {
                    if (CurrentPosition.X == point.X && (CurrentPosition.Y - (20 * Speed)) == point.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.DOWN)
                {
                    if (CurrentPosition.X == point.X && (CurrentPosition.Y + (20 * Speed)) == point.Y)
                        return CurrentPosition;
                }
            }
            return null;
        }

        public Position HitBorderPosition(List<Brick> borderList, Direction direction)
        {
            foreach (var point in borderList)
            {
                if (direction == Direction.RIGHT)
                {
                    if ((CurrentPosition.X) == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.LEFT)
                {
                    if ((CurrentPosition.X) == point.CurrentPosition.X && CurrentPosition.Y == point.CurrentPosition.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.UP)
                {
                    if (CurrentPosition.X == point.CurrentPosition.X && (CurrentPosition.Y) == point.CurrentPosition.Y)
                        return CurrentPosition;
                }
                else if (direction == Direction.DOWN)
                {
                    if (CurrentPosition.X == point.CurrentPosition.X && (CurrentPosition.Y) == point.CurrentPosition.Y)
                        return CurrentPosition;
                }
            }
            return null;
        }

        public void Dispose()
        {
        }
        
        public bool IsHitBorder(Position position)
        {
            if (CurrentPosition.X == position.X && CurrentPosition.Y == position.Y )
                return true;
            return false;
        }
    }
}
