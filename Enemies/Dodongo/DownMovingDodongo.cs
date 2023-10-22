using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class DownMovingDodongo : IEnemy
    {
        private readonly DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private readonly int MoveMagnitude = 5;
        private bool Injured = false;
        public RectCollider Collider { get; private set; }
        public DownMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Dodongo = dodongo;
            Direction = new Vector2(0, MoveMagnitude);
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateDodongoDownSprite();
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)this.Position.X, (int)+this.Position.Y, 8 * scale, 8 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void UpdateHealth(int damagePoints)
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoDownHitSprite();
            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoDownSprite();
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
                Collider.Pos = Position;
            }
        }
        public void ChangeDirection()
        {
            Sprite.UnregisterSprite();
            Dodongo.State = new RightMovingDodongo(Dodongo, Position);
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
            LevelMaster.RemoveUpdateable(Dodongo);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            Dodongo.OnCollision(collisions);
        }
    }
}
