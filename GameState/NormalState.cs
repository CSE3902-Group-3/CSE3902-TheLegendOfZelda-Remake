using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        private IController Controller;
        public NormalState()
        {
            Controller = new PlayerController(GameState.Link);
        }
        public void Update(GameTime gameTime)
        {
            LevelMaster.Update(gameTime);
            Controller.Update();
            GameState.CollisionManager.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
