using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemMenuState : IGameState
    {
        public ItemMenuState(){}
        public void Update(GameTime gameTime)
        {
            InventoryHUD.GetInstance().Show();
            InventoryHUD.GetInstance().Update(gameTime);
            MapHUD.GetInstance().Show();
            MapHUD.GetInstance().Update(gameTime);
            GameState.ItemMenuController.Update();
            CameraController.GetInstance().itemMenuCamera.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
