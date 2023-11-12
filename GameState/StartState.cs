using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZelda.Graphics;

namespace LegendOfZelda
{
    public class StartState : IGameState
    {
        private IController StartStateController;
        public StartState() 
        {
            BackgroundGenerator.GenerateMenuBackgrounds();
            new MainMenu();
            CameraController.GetInstance().ChangeMenu(Menu.Start);
            StartStateController = new MainMenuController();
        }
        public void Update(GameTime gameTime)
        {
            StartStateController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
        }
    }
}
