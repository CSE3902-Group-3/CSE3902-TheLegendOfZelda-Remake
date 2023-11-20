using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class FireballStatue : IUpdateable, ICollidable
    {
        private AnimatedSprite Sprite;
        private double LastAttackTime = 0;
        private float FireballSpeed = 2;
        private Vector2 Position;
        public FireballStatue(AnimatedSprite animatedSprite, Vector2 position)
        {
            Sprite = animatedSprite;
            Position = position;
            Sprite.UpdatePos(Position);
            LevelManager.AddUpdateable(this);
        }
        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > 3000 + LastAttackTime)
            {
                LastAttackTime = gameTime.TotalGameTime.TotalMilliseconds;
                LaunchFireball();
            }
        }
        public void LaunchFireball()
        {
            Vector2 direction = GameState.Link.Pos - Position;
            direction /= direction.Length();
            direction.X *= FireballSpeed;
            direction.Y *= FireballSpeed;
            new AquamentusBall(Position, direction);
        }
        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}
