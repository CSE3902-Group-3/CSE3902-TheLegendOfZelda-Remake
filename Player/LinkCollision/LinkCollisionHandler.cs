using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionHandler
    {
        public static void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                /*
                 * You will likely need to sort out the collisions by the Layer of the collidable you collided with
                 */
                if (collision.CollidedWith.Layer == CollisionLayer.OuterWall || collision.CollidedWith.Layer == CollisionLayer.Wall)
                {
                    LinkCollisionWithBlock.HandleCollisionWithWall(collision.EstimatedDirection, collision.OverlapRectangle);
                }
                else if (collision.CollidedWith.Layer == CollisionLayer.Enemy)
                {
                    LinkCollisionWithEnemy.HandleCollisionWithEnemy(collision);
                }
                else if (collision.CollidedWith.Layer == CollisionLayer.EnemyWeapon)
                {
                    LinkCollisionWithEnemyWeapon.HandleCollisionWithEnemyWeapon(collision);
                }
                else if (collision.CollidedWith.Layer == CollisionLayer.Item)
                {
                    LinkCollisionWithItem.HandleCollisionWithItem(collision);
                }
                // there's also a PlayerWeapon layer, but i don't think we need it unless we add a second player? correct me if i'm wrong
            }
        }
    }
}
