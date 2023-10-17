namespace LegendOfZelda
{
    public class LinkCollisionWithEntity
    {
        public static void HandleCollisionWithEnemy()
        {
            ((Link)Game1.getInstance().link).TakeDamage();
        }
    }
}
