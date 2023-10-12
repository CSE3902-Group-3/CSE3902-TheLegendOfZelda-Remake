using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class BladeTrap:IEnemy
    {
        private AnimatedSprite Sprite;
        public Vector2 Position;

        public BladeTrap(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateBladeTrapSprite();
        }
        public void Spawn() {
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
        }
        public void UpdateHealth(int damagePoints) {}

        public void Attack() {}

        public void ChangePosition() {}

        public void ChangeDirection() {}
        public void Update(GameTime gameTime) {}
    }
}
