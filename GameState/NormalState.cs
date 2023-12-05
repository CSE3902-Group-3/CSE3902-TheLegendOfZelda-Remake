using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class NormalState: IGameState
    {
        public NormalState()
        {
            LevelManager.RemoveDrawable(GameState.Link.Sprite);
            LevelManager.AddDrawable(GameState.Link.Sprite, true);
            LevelManager.CurrentLevelRoom.AddDoorFrames();
            lowerHUD = LowerHUD.GetInstance();
            GameState.CheatCodeController = new CheatCodeController();
        }
        public void Update(GameTime gameTime)
        {
            LevelManager.Update(gameTime);
            GameState.LowerHUD.Update(gameTime);
            GameState.PlayerController.Update();
            GameState.CollisionManager.Update(gameTime);
            GameState.CheatCodeController.Update();
            GameState.MapHUD.Update(gameTime);  
        }
        public void Draw(SpriteBatch _spriteBatch) 
        {
            GameState.CameraController.Draw(_spriteBatch);
            GameState.LowerHUD.Show();
            GameState.MapHUD.Show();
        }
    }
}
