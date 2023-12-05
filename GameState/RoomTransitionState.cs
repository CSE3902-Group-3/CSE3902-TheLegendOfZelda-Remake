using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class RoomTransitionState : IGameState
    {
        public RoomTransitionState(){}
        public void Update(GameTime gameTime)
        {
            CameraController.GetInstance().mainCamera.Update(gameTime);
            GameState.Link.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
