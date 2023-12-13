using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class LevelTransitionState : IGameState
    {
        private LevelStartScreen LevelStartScreen;
        public LevelTransitionState(int levelNumber)
        {
            GameState.CollisionManager = new CollisionManager();
            GameState.CameraController.Reset();
            GameState.CameraController.ChangeMenu(Menu.Item);
            GameState.LevelManager.StartLevel(levelNumber);
            GameState.Link = new Link();
            LevelStartScreen = new LevelStartScreen(levelNumber);
            if (ShaderHolder.ShadersOn)
            {
                switch (levelNumber)
                {
                    case 1:
                        ShaderHolder.SetPallette(PalletHolder.normalPallette);
                        break;
                    case 2:
                        ShaderHolder.SetPallette(PalletHolder.dung2Pallette);
                        break;
                }
            }
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
