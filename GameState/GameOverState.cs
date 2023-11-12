using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class GameOverState : IGameState
    {
        private GameOverScreen gameOver;
        private GameOverMenu menu;

        public GameOverState()
        {
            gameOver = new GameOverScreen();
            menu = new GameOverMenu();
        }
        public void Update(GameTime gameTime)
        {
            GameOver.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            menu.Draw();
        }
    }
}
