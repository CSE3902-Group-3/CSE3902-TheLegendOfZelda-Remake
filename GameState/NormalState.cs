using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        LowerHUD lowerHUD;
        public NormalState()
        {
            lowerHUD = LowerHUD.GetInstance();
        }
        public void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            lowerHUD.Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
            GameState.cheatCodeController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            lowerHUD.Show();
        }
    }
}
