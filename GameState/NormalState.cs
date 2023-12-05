using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        public NormalState()
        {
        }
        public void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            GameState.LowerHUD.Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
            GameState.CheatCodeController.Update();
            GameState.MapHUD.Update(gameTime);  
        }
        public void Draw(SpriteBatch _spriteBatch) 
        {
            GameState.CameraController.Draw(_spriteBatch);
            GameState.LowerHUD.Show();
            GameState.MapHUD.Show();
        }
    }
}
