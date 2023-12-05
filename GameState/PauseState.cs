using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class PauseState : IGameState
    {
        private IController Controller;
        public PauseState()
        {
            LevelManager.RemoveDrawable(GameState.Link.Sprite, true);
            LevelManager.AddDrawable(GameState.Link.Sprite);
            LevelManager.CurrentLevelRoom.RemoveDoorFrames();
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
