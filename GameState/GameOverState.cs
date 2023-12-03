﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameOverState : IGameState
    {
        private GameOverScreen gameOver;
        private GameOverMenuController controller;

        public GameOverState()
        {
            gameOver = new GameOverScreen();
            controller = new GameOverMenuController();
        }
        public void Update(GameTime gameTime)
        {
            gameOver.Update(gameTime);
            GameState.Link.Update(gameTime);
            if (gameOver.done == true)
            {
                controller.Update();
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
