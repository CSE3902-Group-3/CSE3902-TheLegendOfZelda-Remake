using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class PauseState : IGameState
    {
        private IController Controller;
        public PauseState()
        {
            Controller = new PauseController(GameState.PauseManager);
        }
        public void Update(GameTime gameTime)
        {
            Controller.Update();
        }
        public void Draw()
        {
            LevelMaster.Draw();
            GameState.Link.sprite.Draw();
            GameState.PauseManager.Draw();
        }
    }
}
