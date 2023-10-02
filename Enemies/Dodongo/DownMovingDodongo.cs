using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class DownMovingDodongo : IEnemy
    {
        private readonly Game1 Game;
        private readonly DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private readonly int MoveMagnitude = 5;
        private bool Injured = false;
        public DownMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Game = Game1.instance;
            Dodongo = dodongo;
            Direction = new Vector2(0, MoveMagnitude);
            Position = pos;
        }
        public void Spawn()
        {
            Sprite = Game1.getInstance().spriteFactory.CreateDodongoDownSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth(int damagePoints)
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = Game1.getInstance().spriteFactory.CreateDodongoDownHitSprite();
            }
            else
            {
                Sprite = Game1.getInstance().spriteFactory.CreateDodongoDownSprite();
            }
            Sprite.UpdatePos(Position);
            Injured = !Injured;
        }
        public void ChangePosition()
        {
            if (!Injured)
            {
                Position += Direction;
                Sprite.UpdatePos(Position);
            }
        }
        public void ChangeDirection()
        {
            Sprite.UnregisterSprite();
            Dodongo.State = new RightMovingDodongo(Dodongo, Position);
            Dodongo.State.Spawn();
        }
        public void Attack()
        {
            // not needed
        }
        public void Update(GameTime gameTime)
        {
            //handled by Dodongo
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Game1.getInstance().RemoveUpdateable(Dodongo);
        }
    }
}
