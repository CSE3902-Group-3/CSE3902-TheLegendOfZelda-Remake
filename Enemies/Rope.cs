using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Rope : IEnemy
    {
        private readonly Game1 Game;
        private AnimatedSprite RopeSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private readonly int PosIncrement = 5;
        private bool FacingLeft = false;
        private double LastSwitch = 0;

        public Rope(Vector2 pos)
        {
            Game = Game1.getInstance();
            Position = pos;
            RopeSprite = SpriteFactory.getInstance().CreateRopeRightSprite();
        }
        public void Spawn()
        {
            Game.RegisterUpdateable(this);
            RopeSprite.RegisterSprite();
            RopeSprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (FacingLeft)
            {
                Position.X -= PosIncrement;
            }
            else
            {
                Position.X += PosIncrement;
            }

            RopeSprite.UpdatePos(Position);
        }
        public void Attack()
        {
        }
        public void UpdateHealth(int damagePoints)
        {
        }

        public void ChangeDirection()
        {
            Game.RemoveDrawable(RopeSprite);
            if (FacingLeft)
            {
                RopeSprite = SpriteFactory.getInstance().CreateRopeRightSprite();
            }
            else
            {
                RopeSprite = SpriteFactory.getInstance().CreateRopeLeftSprite();
            }
            FacingLeft = !FacingLeft;
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
        public void Die()
        {
            RopeSprite.UnregisterSprite();
            Game.RemoveUpdateable(this);
        }
    }
}
