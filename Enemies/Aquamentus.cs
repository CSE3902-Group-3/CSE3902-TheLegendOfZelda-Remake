using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        private readonly Game1 Game;
        private readonly AnimatedSprite AquamentusSprite;
        private int Health { get; set; } = 1;
        private Vector2 Position;

        private int CycleCount = 0;
        private readonly int MaxCycles = 50;
        private int PosIncrement = 2;

        public Aquamentus(Vector2 pos)
        {
            Game = Game1.getInstance();
            Position = pos;
            AquamentusSprite = SpriteFactory.getInstance().CreateAquamentusSprite();
        }
        public void Spawn ()
        {
            Game.RegisterUpdateable(this);
            AquamentusSprite.RegisterSprite();
            AquamentusSprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }
            Position.X += PosIncrement;
            CycleCount++;

            AquamentusSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            new AquamentusBall(Position, new Vector2(-10, 0));
            new AquamentusBall(Position, new Vector2(-10, 10));
            new AquamentusBall(Position, new Vector2(-10, -10));
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
            AquamentusSprite.UnregisterSprite();
            Game1.getInstance().RemoveUpdateable(this);
        }
    }
}
