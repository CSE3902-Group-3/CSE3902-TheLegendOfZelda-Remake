using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class WinningState : IGameState
    {
        private WinningScreenManager ScreenManager;
        private WinningMenu menu;
        public static WinningSelector selector;
        private WinningSelectorController controller;

        public WinningState()
        {
            LevelManager.CurrentLevelRoom.RemoveDoorFrames();
            ScreenManager = new WinningScreenManager();
            menu = new WinningMenu();
            selector = new WinningSelector();
            controller = new WinningSelectorController();
            SoundFactory.PlaySound(SoundFactory.getInstance().Fanfare);
        }
        public void Update(GameTime gameTime)
        {
            ScreenManager.Update(gameTime);
            controller.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            menu.Draw();
        }
    }
}
