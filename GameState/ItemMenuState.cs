using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemMenuState : IGameState
    {
        public ItemMenuState()
        {
        }
        public void Update(GameTime gameTime)
        {
            GameState.InventoryHUD.Update(gameTime);
            GameState.MapHUD.Update(gameTime);
            GameState.ItemMenuController.Update();
            GameState.LowerHUD.Update(gameTime);
            CameraController.GetInstance().itemMenuCamera.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            GameState.InventoryHUD.Show();
            GameState.MapHUD.Show();
        }
    }
}
