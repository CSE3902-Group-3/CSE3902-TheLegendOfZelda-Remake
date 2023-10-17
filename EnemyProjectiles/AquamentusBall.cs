using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class AquamentusBall : IEnemyProjectile
    {
        private readonly ISprite AquamentusBallSprite;
        private Vector2 Position;
        private Vector2 Direction;
        public AquamentusBall(Vector2 pos, Vector2 dir)
        {
            LevelMaster.RegisterUpdateable(this);
            AquamentusBallSprite = SpriteFactory.getInstance().CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction;
            AquamentusBallSprite.UpdatePos(Position);
        }

        public void Destroy()
        {
            LevelMaster.RemoveUpdateable(this);
            LevelMaster.RemoveDrawable(AquamentusBallSprite);
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
