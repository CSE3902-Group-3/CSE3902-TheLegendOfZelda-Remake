using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class WinningState : IGameState
    {
        private IController Controller;
        private WinningScreenManager ScreenManager;
        public WinningState()
        {
            // There should be a controller for the winning state
            Controller = new PlayerController(GameState.Link);
            ScreenManager = new WinningScreenManager();
        }
        public void Update(GameTime gameTime)
        {
            LevelMaster.Update(gameTime);
            ScreenManager.Update(gameTime);
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
