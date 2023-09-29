using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        private readonly Game1 game;
        private readonly AnimatedSprite aquamentusSprite;
        private int Health { get; set; } = 1;
        private Vector2 position;

        private int CycleCount = 0;
        private int MaxCycles = 50;
        private int PosIncrement = 2;

        public Aquamentus(Vector2 pos)
        {
            game = Game1.instance;
            position = pos;
            aquamentusSprite = game.spriteFactory.CreateAquamentusSprite();
        }
        public void Spawn ()
        {
            game.RegisterUpdateable(this);
            aquamentusSprite.RegisterSprite();
            aquamentusSprite.UpdatePos(position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }
            position.X += PosIncrement;
            CycleCount++;

            aquamentusSprite.UpdatePos(position);
        }
        public void Attack()
        {
            new AquamentusBall(position, new Vector2(-10, 0));
            new AquamentusBall(position, new Vector2(-10, 10));
            new AquamentusBall(position, new Vector2(-10, -10));
        }
        public void UpdateHealth(int damagePoints)
        {
            // Not needed
        }

        public void ChangeDirection()
        {
            // Aquamentus cycles left and right movement,
            // but it does not change the direction it is
            // facing
        }

        public void Update(GameTime gameTime)
        {
            ChangePosition();
            if (CycleCount == MaxCycles)
            {
                Attack();
            }
        }
        public void Die()
        {
            aquamentusSprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }
    }
}
