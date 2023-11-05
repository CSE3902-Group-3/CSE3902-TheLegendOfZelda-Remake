using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MainMenuState
    {
        private IController Controller;
        public MainMenuState()
        {
            Controller = new MainMenuController(GameState.MainMenuState);
        }
        public void Update(GameTime gameTime)
        {
            Controller.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            GameState.CameraController.Draw(_spriteBatch);
            GameState.PauseManager.Draw();
        }
    }
}
