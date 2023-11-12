using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class WinningState : IGameState
    {
        private WinningScreenManager ScreenManager;
        public WinningState()
        {
            ScreenManager = new WinningScreenManager();
        }
        public void Update(GameTime gameTime)
        {
            ScreenManager.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
