namespace LegendOfZelda
{
    public interface IEnemy: IUpdateable, ICollidable
    {
        void Spawn();
        void UpdateHealth(int damagePoints);
        void Attack();
        void ChangePosition();
        void ChangeDirection();
        void Die();
        void DropItem();
    }
}
