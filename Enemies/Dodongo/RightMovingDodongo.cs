using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.Dodongo
{
    internal class RightMovingDodongo : IEnemy
    {
        private Dodongo Dodongo;
        private Vector2 Position;
        private ISprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private Boolean Injured = false;
        public RightMovingDodongo(Dodongo dodongo, Vector2 pos)
        {
            Dodongo = dodongo;
            Direction = new Vector2(MoveMagnitude, 0);
            Position = pos;
            Sprite = Game1.instance.spriteFactory.CreateDodongoRightSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth()
        {
            Game1.instance.RemoveDrawable(Sprite);
            if (!Injured)
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoRightHitSprite();
            }
            else
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoRightSprite();
            }
            Sprite.UpdatePos(Position);
            Injured = !Injured;
        }
        public void ChangePosition()
        {
            if (!Injured)
            {
                Position += Direction;
                Sprite.UpdatePos(Position);
            }
        }
        public void ChangeDirection()
        {
            Game1.instance.RemoveDrawable(Sprite);
            Dodongo.State = new UpMovingDodongo(Dodongo, Position);
        }
        public void Attack()
        {
            // not needed
        }
        public void Update(GameTime gameTime)
        {
            //handled by Dodongo
        }
        public void Destroy()
        {
            Game1.instance.RemoveDrawable(Sprite);
            Game1.instance.RemoveUpdateable(Dodongo);
        }
    }
}
