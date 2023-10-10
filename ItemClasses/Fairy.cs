using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Fairy : IItem, IUpdateable
    {
        protected AnimatedSprite fairy;
        private SpriteFactory spriteFactory;
        private Vector2 position;
        private Vector2 originalPosition;
        private bool moveUp;
        private bool moveRight;
        private Game1 game;
        private Vector2 Direction;
        public Vector2 ViewportSize;
        private double LastSwitch = 0;

        public Fairy(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            fairy = spriteFactory.CreateFairySprite();
            position = pos;
            originalPosition = pos;
            game = Game1.getInstance();
            ViewportSize = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);

        }

        public void Show()
        {
            game.RegisterUpdateable(this);
            fairy.RegisterSprite();
            fairy.UpdatePos(position);
        }

        /* this is added in case fairy should be displayed in inventory, where it should not move */
        public void ShowIdle()
        {
            fairy.RegisterSprite();
            fairy.UpdatePos(position);
        }

        public void Remove()
        {
            fairy.UnregisterSprite();
            game.RemoveUpdateable(this);
        }

        public IItem Collect()
        {
            fairy.UnregisterSprite();
            return this;
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

        public void ChangeDirection()
        {
            Random rand = new();
            int random = rand.Next(0, 4);

            if (random == 0)
            {
                Direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                Direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                Direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                Direction = new Vector2(0, -1);
            }
        }
        public void ChangePosition()
        {
            position += Direction * 2;
            if (position.X < 0 || position.Y < 0)
            {
                position -= Direction * 2;
            }

            if (position.X >= ViewportSize.X || position.Y >= ViewportSize.Y)
            {
                ChangeDirection();
            }
            fairy.UpdatePos(position);
        }
    }
}