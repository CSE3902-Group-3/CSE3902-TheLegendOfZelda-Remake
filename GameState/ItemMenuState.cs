using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemMenuState : IGameState
    {
        public ItemMenuState()
        {
            CameraController.GetInstance().ChangeMenu(Menu.Item);
        }
        public void Update(GameTime gameTime)
        {
            GameState.ItemMenuController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
