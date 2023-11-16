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
                GameState.Link.StateMachine.ChangeState(new CollectItemLinkState(itemCollidedWith));
            }
            else if (itemCollidedWith is Heart)
                GameState.Link.Heal(1.0f);
            else if (itemCollidedWith is Fairy)
                GameState.Link.Heal(GameState.Link.MaxHP);
            else if (itemCollidedWith is FiveRupee || itemCollidedWith is OneRupee)
                Inventory.getInstance().AddRupee(itemCollidedWith);
            else
                Inventory.getInstance().AddItem(itemCollidedWith);


            SoundFactory.PlaySound(SoundFactory.getInstance().GetItem, 1.0f, 0.0f, 0.0f);
        }

    }
}
