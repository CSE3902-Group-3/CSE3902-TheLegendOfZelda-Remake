using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        private LowerHUD lowerHUD;
        public NormalState()
        {
            LevelManager.CurrentLevelRoom.AddDoorFrames();
            lowerHUD = LowerHUD.GetInstance();
            GameState.CheatCodeController = new CheatCodeController();
        }
        public void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            lowerHUD.Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
            GameState.CheatCodeController.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            lowerHUD.Show();
        }
    }
}
