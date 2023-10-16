using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class GoriyaBoomerang : IEnemyProjectile
    {
        private readonly Game1 game;
        private readonly ISprite GoriyaBoomerangSprite;
        private Vector2 Direction;
        private Vector2 Position;
        public GoriyaBoomerang(Vector2 pos, Vector2 dir)
        {
            Game1.getInstance().RegisterUpdateable(this);
            GoriyaBoomerangSprite = SpriteFactory.getInstance().CreateBoomerangSprite();
            Position = pos;
            Direction = dir;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            GoriyaBoomerangSprite.UpdatePos(Position);
        }
        public void Destroy()
        {
            Game1.getInstance().RemoveUpdateable(this);
            Game1.getInstance().RemoveDrawable(GoriyaBoomerangSprite);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.PlayerWeapon)
                {
                    Destroy();
                }
            }
        }
    }
}
