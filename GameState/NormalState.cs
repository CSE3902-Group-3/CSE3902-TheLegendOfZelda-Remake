using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class NormalState: IGameState
    {
        private IController Controller;
        public NormalState()
        {
            Controller = new PlayerController(GameState.Link);
        }
        public void Update(GameTime gameTime)
        {
            LevelMaster.Update(gameTime);
            GameState.Link.Update(gameTime);
            Controller.Update();
            GameState.CollisionManager.Update(gameTime);
        }
        public void Draw()
        {
            LevelMaster.Draw();
            GameState.Link.sprite.Draw();
        }
    }
}
