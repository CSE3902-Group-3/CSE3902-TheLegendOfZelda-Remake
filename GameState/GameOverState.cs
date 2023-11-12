using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameOverState : IGameState
    {
        private GameOverScreen GameOver;

        public GameOverState()
        {
            GameOver = new GameOverScreen();
        }
        public void Update(GameTime gameTime)
        {
            GameOver.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
