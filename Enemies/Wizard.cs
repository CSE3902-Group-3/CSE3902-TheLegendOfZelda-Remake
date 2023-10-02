﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private readonly Game1 Game;
        private readonly AnimatedSprite Sprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;

        public Wizard(Vector2 pos)
        {
            Game = Game1.getInstance();
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateOldManSprite();

        }
        public void Spawn()
        {
            Game.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void ChangePosition() {}
        public void Attack()
        {

        }
        public void UpdateHealth(int damagePoints)
        {

        }

        public void ChangeDirection() {}
        public void Die()
        {
            Sprite.UnregisterSprite();
            Game.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime) {}
    }
}
