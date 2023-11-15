using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        public NormalState(){}
        public void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            LowerHUD.GetInstance().Show();
            LowerHUD.GetInstance().Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
