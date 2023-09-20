using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Bat
{
    public class Bat : IEnemy
    {
        private Game1 game { get; set; }
        public SpriteFactory spriteFactory;
        private readonly ISprite batSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;

        public Bat(Vector2 pos, SpriteFactory SpriteFactory)
        {
            spriteFactory = SpriteFactory;
            batSprite = spriteFactory.CreateKeeseSprite();
            Position = pos;
        }
        public void ChangePosition()
        {
            Random rand = new Random();
            int random = rand.Next(0, 4);

            // Move down and right
            if (random == 0)
            {
                Position.X += 1;
                Position.Y += 1;
            // Move down and left
            } else if (random == 1)
            {
                Position.X += -1;
                Position.Y += 1;
            // Move up and left
            } else if (random == 2)
            {
                Position.X += -1;
                Position.Y += -1;
            // Move up and right
            } else if (random == 3)
            {
                Position.X += 1;
                Position.Y += -1;

            }
            batSprite.UpdatePos(Position);
        }
        public void Attack()
        {   
            /* 
             * This isn't needed for Sprint 2,
             * however it will be needed later.
             */
        }
        public void UpdateHealth() 
        { 
            /* 
             * This isn't needed for Sprint 2,
             * however it will be needed later.
             */
        }

        public void ChangeDirection() { 
            // Bat does not change direction
        }

        public void Update(GameTime gameTime)
        {
            /* 
             * I don't think there is a valid
             * implimentation for this at the moment.
             * This could be applicable when we 
             * have collision.
            */
        }

        public void Draw()
        {
            batSprite.Draw();
        }
    }
}
