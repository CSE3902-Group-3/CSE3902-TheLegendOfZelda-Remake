using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class GameOverState : IGameState
    {
        private GameOverScreen gameOver;

        public GameOverState()
        {
            gameOver = new GameOverScreen();
        }
        public void Update(GameTime gameTime)
        {
            gameOver.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
