using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class WinningState : IGameState
    {
        private WinningScreenManager ScreenManager;
        public WinningState()
        {
            // There should be a controller for the winning state
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
