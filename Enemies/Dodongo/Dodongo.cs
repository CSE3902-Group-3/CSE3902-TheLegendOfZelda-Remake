using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Dodongo
{
    public class Dodongo : IEnemy
    {
        private Game1 Game { get; set; }
        private ISprite DodongoSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private int PosIncrement = 5;

        private double LastDirSwitch = 0;
        private enum FacingDirection { facingDown, facingUp, facingRight, facingLeft };
        private FacingDirection Direction = FacingDirection.facingRight;
        private Boolean Injured = false;
        private double LastHealthSwitch = 0;

        public Dodongo(Vector2 pos)
        {
            Game1.instance.RegisterUpdateable(this);
            DodongoSprite = Game1.instance.spriteFactory.CreateDodongoRightSprite();
            Position = pos;
        }
        public void ChangePosition()
        {
            switch(Direction)
            {
                case (FacingDirection.facingDown):
                    Position.Y += PosIncrement;
                    break;
                case(FacingDirection.facingUp):
                    Position.Y -= PosIncrement;
                    break;
                case (FacingDirection.facingRight):
                    Position.X += PosIncrement;
                    break;
                case (FacingDirection.facingLeft):
                    Position.X -= PosIncrement;
                    break;
            }
            DodongoSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            /* 
             * This isn't needed for Sprint 2,
             * however it will be needed later.
             */
        }
        public void UpdateHealth()
        {
            if (Injured)
            {
                Game1.instance.RemoveDrawable(DodongoSprite);
                switch (Direction)
                {
                    case (FacingDirection.facingDown):
                        DodongoSprite = Game1.instance.spriteFactory.CreateDodongoDownHitSprite();
                        break;
                    case (FacingDirection.facingUp):
                        DodongoSprite = Game1.instance.spriteFactory.CreateDodongoUpHitSprite();
                        break;
                    case (FacingDirection.facingRight):
                        DodongoSprite = Game1.instance.spriteFactory.CreateDodongoRightHitSprite();
                        break;
                    case (FacingDirection.facingLeft):
                        DodongoSprite = Game1.instance.spriteFactory.CreateDodongoLeftHitSprite();
                        break;
                }
            }
            Injured = !Injured;
        }

        public void ChangeDirection()
        {
            Game1.instance.RemoveDrawable(DodongoSprite);
            switch (Direction)
            {
                case (FacingDirection.facingDown):
                    Direction = FacingDirection.facingRight;
                    DodongoSprite = Game1.instance.spriteFactory.CreateDodongoRightSprite();
                    break;
                case (FacingDirection.facingUp):
                    Direction = FacingDirection.facingLeft;
                    DodongoSprite = Game1.instance.spriteFactory.CreateDodongoLeftSprite();
                    break;
                case (FacingDirection.facingRight):
                    Direction = FacingDirection.facingUp;
                    DodongoSprite = Game1.instance.spriteFactory.CreateDodongoUpSprite();
                    break;
                case (FacingDirection.facingLeft):
                    Direction = FacingDirection.facingDown;
                    DodongoSprite = Game1.instance.spriteFactory.CreateDodongoDownSprite();
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastDirSwitch + 1000)
            {
                LastDirSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > LastHealthSwitch + 550)
            {
                LastHealthSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                UpdateHealth();
            }
            ChangePosition();
        }

        public void Draw()
        {
            DodongoSprite.Draw();
        }
        public void Destroy()
        {
            Game1.instance.RemoveUpdateable(this);
            Game1.instance.RemoveDrawable(DodongoSprite);
        }
    }
}