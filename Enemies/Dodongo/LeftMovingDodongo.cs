﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LeftMovingDodongo : IEnemy
    {
        private readonly Game1 Game;
        private readonly DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private bool Injured = false;
        public LeftMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Game = Game1.getInstance();
            Dodongo = dodongo;
            Direction = new Vector2(-MoveMagnitude, 0);
            Position = pos;
        }
        public void Spawn()
        {
            Sprite = SpriteFactory.getInstance().CreateDodongoLeftSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth(int damagePoints)
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoLeftHitSprite();

            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoLeftSprite();
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
            Dodongo.State = new DownMovingDodongo(Dodongo, Position);
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
            Game1.getInstance().RemoveDrawable(Sprite);
            Game1.getInstance().RemoveUpdateable(Dodongo);
        }
    }
}
