using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    /*
     *  The explosion in the original game creates a cluster of seven explosions. Half of them appear on even frames and half appear on
     *  odd frames, making a strobe effect. This is not slowed down like all other animations in the game. The purpose of this class is to
     *  create sprites with the correct timing such that they are offset like this, hence references to "halfA" and "halfB".
     */
    public class Explosion : IPlayerProjectile
    {
        private SpriteFactory spriteFactory;
        private List<IAnimatedSprite> sprites;
        private Vector2 pos;
        private enum InitState { HalfA, HalfB, Complete }
        private InitState initState = InitState.HalfA;

        private List<Vector2> halfAPositions;
        private List<Vector2> halfBPositions;

        private List<IRectCollider> colliders;

        private int colliderWidth = 16;
        private int colliderHeight = 16;

        public Explosion(Vector2 position)
        {
            spriteFactory = SpriteFactory.getInstance();
            LevelMaster.RegisterUpdateable(this);

            pos = position;

            int scale = spriteFactory.scale;
            halfAPositions = new List<Vector2>
            {
                Vector2.Zero,
                new Vector2 (-8 * scale, 16 * scale),
                new Vector2 (8 * scale, -16 * scale),
                new Vector2 (16 * scale, 0)
            };
            halfBPositions = new List<Vector2>
            {
                Vector2.Zero,
                new Vector2 (8 * scale, 16 * scale),
                new Vector2 (-8 * scale, -16 * scale),
                new Vector2 (-16 * scale, 0)
            };

            sprites = new List<IAnimatedSprite>();
            colliders = new List<IRectCollider>();

            colliderWidth *= scale;
            colliderHeight *= scale;
        }

        public void Update(GameTime gameTime)
        {
            if(initState == InitState.HalfA)
            {
                SpawnListOfExplosions(halfAPositions);
                initState = InitState.HalfB;
            } else if(initState == InitState.HalfB && sprites[0].frame == 1)
            {
                SpawnListOfExplosions(halfBPositions);
                initState = InitState.Complete;
            } else if (sprites[0].complete)
            {
                Destroy();
            }
        }

        private void SpawnListOfExplosions(List<Vector2> offsets)
        {
            foreach(Vector2 offset in  offsets)
            {
                IAnimatedSprite newSprite = spriteFactory.CreateBombLongExplosionSprite();
                newSprite.UpdatePos(pos + offset);
                sprites.Add(newSprite);

                IRectCollider newRectCollider = new RectCollider(
                    new Rectangle((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), colliderWidth, colliderHeight),
                    CollisionLayer.PlayerWeapon,
                    this
                );
                colliders.Add(newRectCollider);
            }
        }

        public void Destroy()
        {
            foreach(IAnimatedSprite sprite in sprites)
            {
                sprite.UnregisterSprite();
            }
            foreach(IRectCollider rectCollider in colliders)
            {
                rectCollider.Active = false;
            }
            LevelMaster.RemoveUpdateable(this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            //No response
        }
    }
}

