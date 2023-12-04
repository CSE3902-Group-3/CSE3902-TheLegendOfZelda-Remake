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
            GameState.lowerHUD.Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
            GameState.cheatCodeController.Update();
            GameState.mapHUD.Update(gameTime);
            //GameState.inventoryHUD.Update(gameTime);    
        }
        public void Draw(SpriteBatch _spriteBatch) 
        {
            GameState.CameraController.Draw(_spriteBatch);
            GameState.lowerHUD.Show();
            GameState.mapHUD.Show();
        }
    }
}
