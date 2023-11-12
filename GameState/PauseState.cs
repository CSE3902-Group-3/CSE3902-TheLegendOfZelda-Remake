using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class PauseState : IGameState
    {
        private IController Controller;
        public PauseState()
        {
            Controller = new PauseController(GameState.PauseManager);
        }
        public void Update(GameTime gameTime)
        {
            Controller.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
