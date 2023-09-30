using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class RightMovingDodongo : IEnemy
    {
        private readonly Game1 Game;
        private readonly DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private bool Injured = false;
        public RightMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Game = Game1.instance;
            Dodongo = dodongo;
            Direction = new Vector2(MoveMagnitude, 0);
            Position = pos;
        }
        public void Spawn()
        {
            Sprite = Game.spriteFactory.CreateDodongoRightSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth(int damagePoints)
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = Game.spriteFactory.CreateDodongoRightHitSprite();
            }
            else
            {
                Sprite = Game.spriteFactory.CreateDodongoRightSprite();
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
            Dodongo.State = new UpMovingDodongo(Dodongo, Position);
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
            Game.RemoveUpdateable(Dodongo);
        }
    }
}
