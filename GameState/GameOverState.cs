using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class GameOverState : IGameState
    {
        private GameOverScreen gameOver;
        private GameOverMenu menu;
        private GameOverMenuSelector selector;
        private GameOverMenuController controller;

        public GameOverState()
        {
            gameOver = new GameOverScreen();
            menu = new GameOverMenu();
            selector = new GameOverMenuSelector();
            controller = new GameOverMenuController();
        }
        public void Update(GameTime gameTime)
        {
            gameOver.Update(gameTime);
            controller.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            menu.Draw();
        }
    }
}
