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
    class Tank : AllTanks, ITanks
    {
        public static BindingList<Tank> positionsOfTanks = new BindingList<Tank>();
        Random random = new Random();
        
        public event EventHandler HitKolobokEvent;

        public Tank(ImageList imageList, Border border, Wall wall, Kolobok kolobok, int speed) : 
            base(imageList, border, wall, speed)
        {
            CreateRandomLocation();
            LastPosition = new Position(CurrentPosition);
            Directions = Direction.RIGHT;
            TanksView = new TankView(imageList);
            kolobok.HitTankEvent += Shot_HitTankEvent; 
            positionsOfTanks.Add(this);
        }

        private void HitKolobok()
        {
            HitTankEventArgs hitTankEventArgs = new HitTankEventArgs(positionsOfShot);
            OnHitKolobok(hitTankEventArgs);
        }

        private void OnHitKolobok(HitTankEventArgs e)
        {
            EventHandler hitKolobokEvent = HitKolobokEvent;
            hitKolobokEvent?.Invoke(this, e);
        }

        private void Shot_HitTankEvent(object sender, EventArgs e)
        {
            if (e is HitTankEventArgs)
            {
                HitTankEventArgs hitTankEventArgs = e as HitTankEventArgs;
                for (int i = 0; i < hitTankEventArgs.positionsOfShot.Count; i++)
                {
                    if (IsHitBorder(hitTankEventArgs.positionsOfShot[i].CurrentPosition))
                    {
                        CreateRandomLocation();
                        hitTankEventArgs.positionsOfShot[i] = null;
                        hitTankEventArgs.positionsOfShot.Remove(hitTankEventArgs.positionsOfShot[i]);
                    }
                }
            }
        }

        public void CreateRandomLocation()
        {
            CurrentPosition = new Position();

            while (true)
            {
                int numberWidth = random.Next((int)border.Width / 20) * 20;
                int numberHeight = random.Next((int)border.Height / 20) * 20;
                CurrentPosition.X = numberWidth;
                CurrentPosition.Y = numberHeight;
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points))
                    break;
            }
        }

        private bool RandomHit()
        {
            int value = random.Next(800);
            if (value < 50)
                return true;
            else
                return false;
        }

        private Direction RandomDirection()
        {
            int value = random.Next(600);
            if (value > 300 && value < 400)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            if (value > 400 && value < 500)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            if (value > 500 && value < 600)
            {
                Directions++;
                if ((int)Directions == 4)
                    Directions = 0;
            }
            return Directions;
        }

        public bool IsHitTanks()
        {
            if (positionsOfTanks.Where(tank => tank.CurrentPosition.X == CurrentPosition.X &&
            tank.CurrentPosition.Y == CurrentPosition.Y).Count() > 1)
                return true;
            else
            return false;
        }

        private void TurnTanks()
        {
            if (IsHitTanks())
            {
                var tanks = positionsOfTanks.Where(tank => tank.CurrentPosition.X == CurrentPosition.X &&
            tank.CurrentPosition.Y == CurrentPosition.Y).ToList();
                foreach (var tank in tanks)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        tank.Directions++;
                        if ((int)tank.Directions == 4)
                            tank.Directions = 0;
                    }
                    tank.TanksView.ChangeImage(imageList, tank.Directions);
                    tank.CurrentPosition.X = tank.LastPosition.X;
                    tank.CurrentPosition.Y = tank.LastPosition.Y;
                }
            }
        }

        public void Move()
        {
            if (Directions == Direction.RIGHT)
            {
                CurrentPosition.X += (20 * Speed);
                if (RandomHit())
                    Shot();
                if (IsHitTanks())
                {
                    TurnTanks();
                    return;
                }
                if (IsHitBorder(border.borderList) || IsHitBorder(wall.Points)) { }
                LastPosition.X = CurrentPosition.X;
            }
            else if (Directions == Direction.LEFT)
            {
                CurrentPosition.X -= (20 * Speed);
                if (RandomHit())
                    Shot();
                if (IsHitTanks())
                {
                    TurnTanks();
                    return;
                }
                if (IsHitBorder(border.borderList) || IsHitBorder(wall.Points)) { }
                LastPosition.X = CurrentPosition.X;
            }
            else if (Directions == Direction.UP)
            {
                CurrentPosition.Y -= (20 * Speed);
                if (RandomHit())
                    Shot();
                if (IsHitTanks())
                {
                    TurnTanks();
                    return;
                }
                if (IsHitBorder(border.borderList) || IsHitBorder(wall.Points)) { }
                LastPosition.Y = CurrentPosition.Y;
            }
            else if (Directions == Direction.DOWN)
            {
                CurrentPosition.Y += (20 * Speed);
                if (RandomHit())
                    Shot();
                if (IsHitTanks())
                {
                    TurnTanks();
                    return;
                }
                if (IsHitBorder(border.borderList) || IsHitBorder(wall.Points)) { }
                LastPosition.Y = CurrentPosition.Y;
            }
            HitKolobok();
            Directions = RandomDirection();
            TanksView.ChangeImage(imageList, Directions);
        }

        public override void AddTanks(PaintEventArgs e)
        {
            e.Graphics.DrawImage(TanksView.ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, TanksView.ImageFile.Width, TanksView.ImageFile.Height));
        }
    }
}
