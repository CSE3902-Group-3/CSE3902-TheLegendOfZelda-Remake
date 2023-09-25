using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.Dodongo
{
    internal class DownMovingDodongo : IEnemy
    {
        private Dodongo Dodongo;
        private Vector2 Position;
        private ISprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private Boolean Injured = false;
        public DownMovingDodongo(Dodongo dodongo, Vector2 pos)
        {
            Dodongo = dodongo;
            Direction = new Vector2(0, MoveMagnitude);
            Position = pos;
            Sprite = Game1.instance.spriteFactory.CreateDodongoDownSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth()
        {
            Game1.instance.RemoveDrawable(Sprite);
            if (!Injured)
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoDownHitSprite();
            } 
            else
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoDownSprite();
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
            Dodongo.State = new RightMovingDodongo(Dodongo, Position);
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
