namespace LegendOfZelda
{
    public class LinkCollisionWithItem
    {
        public static void HandleCollisionWithItem(CollisionInfo collision)
        {
            IItem itemCollidedWith = collision.CollidedWith.Collidable as IItem;

            Inventory.getInstance().AddItem(itemCollidedWith);

            if (itemCollidedWith is Bow || itemCollidedWith is Triforce)
                Link.getInstance().stateMachine.ChangeState(new CollectItemLinkState(itemCollidedWith));

            SoundFactory.PlaySound(SoundFactory.getInstance().GetItem, 1.0f, 0.0f, 0.0f);
        }

    }
}
