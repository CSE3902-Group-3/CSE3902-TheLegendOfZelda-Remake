using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemMenuState : IGameState
    {
        InventoryHUD inventoryHUD;
        MapHUD mapHUD;
        public ItemMenuState()
        {
            inventoryHUD = InventoryHUD.GetInstance();
            
            mapHUD = MapHUD.GetInstance();
        }
        public void Update(GameTime gameTime)
        {
            inventoryHUD.Update(gameTime);
            mapHUD.Update(gameTime);
            GameState.ItemMenuController.Update();
            CameraController.GetInstance().itemMenuCamera.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            inventoryHUD.Show();
            mapHUD.Show();
        }
    }
}
