using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Sword : ICollidable, IUpdateable
    {
        public RectCollider collider;
        public Vector2 spawnPos;

        public Sword(Direction linkDirection, Vector2 linkPos)
        {
            // Set the spawn position based on Link's position and direction
            spawnPos = linkPos;

            // Create the collider based on the direction
            CreateCollider(linkDirection);

            Game1.getInstance().RegisterUpdateable(this);
        }

        private void CreateCollider(Direction direction)
        {
            int colliderWidth = 0;
            int colliderHeight = 0;

            // Determine the collider dimensions based on the sprite frames
            switch (direction)
            {
                case Direction.up:
                case Direction.down:
                    colliderWidth = 16 * SpriteFactory.getInstance().scale;
                    colliderHeight = 28 * SpriteFactory.getInstance().scale;
                    break;
                case Direction.right:
                case Direction.left:
                    colliderWidth = 23 * SpriteFactory.getInstance().scale; // Use the widest frame's width
                    colliderHeight = 16 * SpriteFactory.getInstance().scale;
                    break;
            }

            // Initialize the collider with the spawn position
            collider = new RectCollider(new Rectangle((int)spawnPos.X, (int)spawnPos.Y, colliderWidth, colliderHeight), CollisionLayer.PlayerWeapon, this);
        }

        public void Destroy()
        {
            collider = null;
            Game1.getInstance().RemoveUpdateable(this);
        }

        // Update the collider's position when the sword's position changes
        public void Update(GameTime gameTime)
        {
            if (collider != null)
            {
                collider.Pos = new Vector2((int)spawnPos.X, (int)spawnPos.Y);
            }
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            // sword does nothing
        }
    }
}