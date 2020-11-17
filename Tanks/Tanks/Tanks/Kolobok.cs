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
    internal class Kolobok : AllTanks, ITanks
    {
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }
        
        public event EventHandler HitTankEvent;

        public Kolobok(ImageList imageList, Border border, Wall wall, BrokenWall brokenWall, int speed) : 
            base(imageList, border, wall, brokenWall, speed)
        {
            Score = 0;
            IsGameOver = false;
            CurrentPosition = new Position(20, 20);
            LastPosition = new Position(20, 20);
            Directions = Direction.RIGHT;
            TanksView = new KolobokView(imageList);
        }

        public void InitEvent(Tank[] tanks)
        {
            foreach (var t in tanks)
            {
                t.HitKolobokEvent += Tank_HitKolobokEvent;
            }
        }

        private void Tank_HitKolobokEvent(object sender, EventArgs e)
        {
            if (e is HitTankEventArgs)
            {
                HitTankEventArgs hitTankEventArgs = e as HitTankEventArgs;
                for (int i = 0; i < hitTankEventArgs.positionsOfShot.Count; i++)
                {
                    if (IsHitBorder(hitTankEventArgs.positionsOfShot[i].CurrentPosition))
                    {
                        hitTankEventArgs.positionsOfShot[i] = null;
                        hitTankEventArgs.positionsOfShot.Remove(hitTankEventArgs.positionsOfShot[i]);
                        IsGameOver = true;
                    }
                }
            }
        }

        private void HitTank()
        {
            HitTankEventArgs hitTankEventArgs = new HitTankEventArgs(positionsOfShot);
            OnHitTank(hitTankEventArgs);
        }

        private void OnHitTank(HitTankEventArgs e)
        {
            EventHandler hitTankEvent = HitTankEvent;
            hitTankEvent?.Invoke(this, e);
        }

        public void Move(Keys keyData)
        {
            //To Do switch
            if (keyData == Keys.Right)
            {
                CurrentPosition.X += (20 * Speed);
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points) && 
                    !IsHitBorder(brokenWall.Points))
                {
                    Directions = Direction.RIGHT;
                    TanksView.ChangeImage(imageList, Directions);
                    LastPosition.X = CurrentPosition.X;
                }
            }
            else if (keyData == Keys.Left)
            {
                CurrentPosition.X -= (20 * Speed);
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points) && 
                    !IsHitBorder(brokenWall.Points))
                {
                    Directions = Direction.LEFT;
                    TanksView.ChangeImage(imageList, Directions);
                    LastPosition.X = CurrentPosition.X;
                }
            }
            else if (keyData == Keys.Up)
            {
                CurrentPosition.Y -= (20 * Speed);
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points) && 
                    !IsHitBorder(brokenWall.Points))
                {
                    Directions = Direction.UP;
                    TanksView.ChangeImage(imageList, Directions);
                    LastPosition.Y = CurrentPosition.Y;
                }
            }
            else if (keyData == Keys.Down)
            {
                CurrentPosition.Y += (20 * Speed);
                if (!IsHitBorder(border.borderList) && !IsHitBorder(wall.Points) && 
                    !IsHitBorder(brokenWall.Points))
                {
                    Directions = Direction.DOWN;
                    TanksView.ChangeImage(imageList, Directions);
                    LastPosition.Y = CurrentPosition.Y;
                }
            }
            else if (keyData == Keys.Space)
            {
                Shot();
            }
        }

        public void EatingApple()
        {
            Score++;
        }

        public override void AddTanks(PaintEventArgs e)
        {
            e.Graphics.DrawImage(TanksView.ImageFile, new Rectangle(CurrentPosition.X,
            CurrentPosition.Y, TanksView.ImageFile.Width, TanksView.ImageFile.Height));
            HitTank();
        }
    }
}
