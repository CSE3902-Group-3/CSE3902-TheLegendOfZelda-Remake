using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Sword : ICollidable, IUpdateable
    {
        public RectCollider collider;
        public Vector2 spawnPos;

        private LevelMaster level;

        public Sword(Direction linkDirection, Vector2 linkPos)
        {
            // Set the spawn position based on Link's position and direction
            spawnPos = linkPos;

            // Create the collider based on the direction
            CreateCollider(linkDirection);

            LevelMaster.RegisterUpdateable(this);
        }

        private void CreateCollider(Direction direction)
        {
            int colliderWidth = 0;
            int colliderHeight = 0;

            // Determine the collider dimensions based on the sprite frames
            switch (direction)
            {
                case Direction.up:
                    colliderWidth = 16 * SpriteFactory.getInstance().scale;
                    colliderHeight = 11 * SpriteFactory.getInstance().scale;

                    // Initialize the collider with the spawn position
                    collider = new RectCollider(new Rectangle((int)spawnPos.X, (int)spawnPos.Y-46, colliderWidth, colliderHeight), CollisionLayer.PlayerWeapon, this);
                    break;

                case Direction.down:
                    colliderWidth = 16 * SpriteFactory.getInstance().scale;
                    colliderHeight = 11 * SpriteFactory.getInstance().scale;

                    // Initialize the collider with the spawn position
                    collider = new RectCollider(new Rectangle((int)spawnPos.X, (int)spawnPos.Y+62, colliderWidth, colliderHeight), CollisionLayer.PlayerWeapon, this);
                    break;

                case Direction.right:
                    colliderWidth = 13 * SpriteFactory.getInstance().scale; // Use the widest frame's width
                    colliderHeight = 16 * SpriteFactory.getInstance().scale;

                    // Initialize the collider with the spawn position
                    collider = new RectCollider(new Rectangle((int)spawnPos.X+56, (int)spawnPos.Y, colliderWidth, colliderHeight), CollisionLayer.PlayerWeapon, this);
                    break;

                case Direction.left:
                    colliderWidth = 13 * SpriteFactory.getInstance().scale; // Use the widest frame's width
                    colliderHeight = 16 * SpriteFactory.getInstance().scale;

                    // Initialize the collider with the spawn position
                    collider = new RectCollider(new Rectangle((int)spawnPos.X-46, (int)spawnPos.Y, colliderWidth, colliderHeight), CollisionLayer.PlayerWeapon, this);
                    break;
            }
        }

        public void Destroy()
        {
            collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            // sword does nothing
        }
    }
}