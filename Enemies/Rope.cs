using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Rope : IEnemy
    {
        private readonly Game1 Game;
        private AnimatedSprite RopeSprite;
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private readonly int PosIncrement = 5;
        private bool FacingLeft = false;
        private double LastSwitch = 0;

        public Rope(Vector2 pos)
        {
            Game = Game1.instance;
            Position = pos;
            RopeSprite = Game.spriteFactory.CreateRopeRightSprite();
            StateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = RopeSprite,
                Health = Health
            };
        }
        public void Spawn()
        {
           StateMachine.Spawn();
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
            StateMachine.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            StateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            Game.RemoveDrawable(RopeSprite);
            if (FacingLeft)
            {
                RopeSprite = Game.spriteFactory.CreateRopeRightSprite();
            }
            else
            {
                RopeSprite = Game.spriteFactory.CreateRopeLeftSprite();
            }
            FacingLeft = !FacingLeft;
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }
        public void Die()
        {
            StateMachine.Die();
        }
    }
}
