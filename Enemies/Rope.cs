using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Rope : IEnemy
    {
        private AnimatedSprite Sprite;
        private int Width = 16;
        private int Height = 16;
        private float Health { get; set; } = 0.5f;
        public Vector2 Position { get; set; }
        private Vector2 Center;
        private readonly int PosIncrement = 5;
        private bool FacingLeft = false;
        private double LastSwitch = 0;
        private float currentCooldown = 0.0f;
        private bool allowedToMove = true;
        public bool isColliding = false;
        public RectCollider Collider { get; private set; }
        public Rope(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();
            Sprite.UnregisterSprite();
            LevelMaster.RegisterUpdateable(this);
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, Width * scale, Height * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            Sprite.RegisterSprite();
        }
        public void Despawn()
        {
            Sprite.UnregisterSprite();
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Remove(this);
        }
        public void ChangePosition()
        {
            Vector2 newPosition = new(Position.X, Position.Y);

            if (allowedToMove)
            {
                // Cycle left and right movement
                if (FacingLeft)
                {
                    newPosition.X -= PosIncrement;
                }
                else
                {
                    newPosition.X += PosIncrement;
                }

                Position = newPosition;
                Sprite.UpdatePos(Position);
                Collider.Pos = Position;
            }
        }
        public void Attack() { }
        public void UpdateHealth(float damagePoints)
        {
            Health -= damagePoints;

            // Indicate damage, or if health has reached 0, die
            if (Health < 0)
            {
                Die();
            }
            else
            {
                SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit, 1.0f, 0.0f, 0.0f);
            }
        }

        public void ChangeDirection()
        {
            Sprite.UnregisterSprite();
            if (FacingLeft)
            {
                Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();
            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateRopeLeftSprite();
            }
            FacingLeft = !FacingLeft;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }

        public void Update(GameTime gameTime)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000 && isColliding == false)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    isColliding = true;
                    ChangeDirection();
                    Sprite.UpdatePos(Position);
                    Collider.Pos = Position;
                    ChangePosition();
                    isColliding = false;
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (currentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        Sprite.flashing = true;
                        new Timer(1.0f, StopFlashing);
                    }
                }
            }
        }
        public void Stun()
        {
            allowedToMove = false;
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit, 1.0f, 0.0f, 0.0f);
            new Timer(2.0f, CompleteStun);
        }
        public void CompleteStun()
        {
            allowedToMove = true;
        }
        public void StopFlashing()
        {
            Sprite.flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, 16, 16);
            EnemyItemDrop.DropClassBItem(Center);
        }
    }
}
