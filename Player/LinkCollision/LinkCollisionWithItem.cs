namespace LegendOfZelda
{
    public class LinkCollisionWithItem
    {
        public static void HandleCollisionWithItem(CollisionInfo collision)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().GetItem, 1.0f, 0.0f, 0.0f);
        }

    }
}
