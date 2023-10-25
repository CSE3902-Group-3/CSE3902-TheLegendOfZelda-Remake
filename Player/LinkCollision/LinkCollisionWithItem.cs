namespace LegendOfZelda
{
    public class LinkCollisionWithItem
    {
        public static void HandleCollisionWithItem(CollisionInfo collision)
        {
            IItem itemCollidedWith = collision.CollidedWith.Collidable as IItem;

            Link.getInstance().stateMachine.ChangeState(new CollectItemLinkState(itemCollidedWith));
        }

    }
}
