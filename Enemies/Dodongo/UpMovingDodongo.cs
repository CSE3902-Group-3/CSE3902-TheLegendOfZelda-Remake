using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.Dodongo
{
    internal class UpMovingDodongo : IEnemy
    {
        private DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private Boolean Injured = false;
        public UpMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Dodongo = dodongo;
            Direction = new Vector2(0, -MoveMagnitude);
            Position = pos;
        }
        public void Spawn()
        {
            Sprite = Game1.instance.spriteFactory.CreateDodongoUpSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth()
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoUpHitSprite();
            }
            else
            {
                Sprite = Game1.instance.spriteFactory.CreateDodongoUpSprite();
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
            Sprite.UnregisterSprite();
            Dodongo.State = new LeftMovingDodongo(Dodongo, Position);
            Dodongo.State.Spawn();
        }
        public void Attack()
        {
            // not needed
        }
        public void Update(GameTime gameTime)
        {
            //handled by Dodongo
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Game1.instance.RemoveUpdateable(Dodongo);
        }
    }
}
