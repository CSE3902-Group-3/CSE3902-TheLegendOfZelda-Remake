using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        private readonly AnimatedSprite AquamentusSprite;
        private int Health { get; set; } = 1;
        private Vector2 Position;

        private int CycleCount = 0;
        private readonly int MaxCycles = 50;
        private int PosIncrement = 2;

        public Aquamentus(Vector2 pos)
        {
            Position = pos;
            AquamentusSprite = SpriteFactory.getInstance().CreateAquamentusSprite();
        }
        public void Spawn ()
        {
            LevelMaster.RegisterUpdateable(this);
            AquamentusSprite.RegisterSprite();
            AquamentusSprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }
            Position.X += PosIncrement;
            CycleCount++;

            AquamentusSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            new AquamentusBall(Position, new Vector2(-10, 0));
            new AquamentusBall(Position, new Vector2(-10, 10));
            new AquamentusBall(Position, new Vector2(-10, -10));
        }
        public void UpdateHealth(int damagePoints)
        {
            // Not needed
        }

        public void ChangeDirection()
        {
            // Aquamentus cycles left and right movement,
            // but it does not change the direction it is
            // facing
        }

        public void Update(GameTime gameTime)
        {
            ChangePosition();
            if (CycleCount == MaxCycles)
            {
                Attack();
            }
        }
        public void Die()
        {
            AquamentusSprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
        }
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall)
                {
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                }
            }
        }
    }
}
