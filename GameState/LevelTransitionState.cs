using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class LevelTransitionState : IGameState
    {
        private LevelStartScreen LevelStartScreen;
        public LevelTransitionState(int levelNumber)
        {
            GameState.LevelManager.StartLevel(levelNumber);
            GameState.Link = new Link();
            LevelStartScreen = new LevelStartScreen(levelNumber);
        }
        public void Update(GameTime gameTime)
        {
            CameraController.GetInstance().mainCamera.Update(gameTime);
            GameState.Link.Update(gameTime);
            LevelStartScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CameraController.GetInstance().Draw(spriteBatch);
        }
    }
}
