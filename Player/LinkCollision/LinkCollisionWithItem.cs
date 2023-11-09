namespace LegendOfZelda
{
    public class LinkCollisionWithItem
    {
        public static void HandleCollisionWithItem(CollisionInfo collision)
        {
            IItem itemCollidedWith = collision.CollidedWith.Collidable as IItem;

            if (itemCollidedWith is Bow || itemCollidedWith is Triforce)
            {
                Inventory.getInstance().AddItem(itemCollidedWith);
                Link.getInstance().stateMachine.ChangeState(new CollectItemLinkState(itemCollidedWith));
            }
            else if (itemCollidedWith is Heart)
                Link.getInstance().Heal(1.0f);
            else
                Inventory.getInstance().AddItem(itemCollidedWith);


            SoundFactory.PlaySound(SoundFactory.getInstance().GetItem, 1.0f, 0.0f, 0.0f);
        }

    }
}
