//This class is for testing the collision system, see CollisionDemoObject.cs for details

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class CollisionDemo : ICollidable
    {
        public CollisionDemo()
        {
            Vector2 viewportSize = new Vector2(Game1.getInstance().GraphicsDevice.Viewport.Width, Game1.getInstance().GraphicsDevice.Viewport.Height);

            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            new CollisionDemoObject(spriteFactory.CreateLinkWalkDownSprite(), CollisionLayer.Player, 16, 16);
            new CollisionDemoObject(spriteFactory.CreateAquamentusSprite(), CollisionLayer.Enemy, 24, 32);
            new CollisionDemoObject(spriteFactory.CreateArrowRightSprite(), CollisionLayer.PlayerWeapon, 16, 5);
            new CollisionDemoObject(spriteFactory.CreateBoomerangSprite(), CollisionLayer.EnemyWeapon, 8, 8);
            new CollisionDemoObject(spriteFactory.CreateLinkWalkLeftSprite(), CollisionLayer.Player, 16, 16);

            new RectCollider(new Rectangle(0, -50, (int)viewportSize.X, 50), CollisionLayer.OuterWall, this);
            new RectCollider(new Rectangle(-50, 0, 50, (int)viewportSize.Y), CollisionLayer.OuterWall, this);
            new RectCollider(new Rectangle((int)viewportSize.X, 0, 50, (int)viewportSize.Y), CollisionLayer.OuterWall, this);
            new RectCollider(new Rectangle(0, (int)viewportSize.Y, (int)viewportSize.X, 50), CollisionLayer.OuterWall, this);

            IAnimatedSprite wall = spriteFactory.CreateWallSprite();
            wall.UpdatePos(new Vector2(1500, 600));
            new RectCollider(new Rectangle(1500, 600, 16 * spriteFactory.scale, 16 * spriteFactory.scale), CollisionLayer.Wall, this);
        }

        public void OnCollision(List<CollisionInfo> collisions) { }
    }
}
