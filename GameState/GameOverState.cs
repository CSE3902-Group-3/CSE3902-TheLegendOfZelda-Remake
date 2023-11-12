using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameOverState : IGameState
    {
        private GameOverScreen GameOver;
        private GameOverMenu Menu;

        public GameOverState()
        {
            GameOver = new GameOverScreen();
            Menu = new GameOverMenu();
        }
        public void Update(GameTime gameTime)
        {
            GameOver.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            Menu.Draw();
        }
    }
}
