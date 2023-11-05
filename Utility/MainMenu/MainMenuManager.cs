using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MainMenuManager : IUpdateable
    {

        private Game1 game;
        private AnimatedSprite mainMenu;
        private GraphicsDevice graphicsDevice;

        private bool atMainMenu = true;
        
        public MainMenuManager()
        {
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            mainMenu = SpriteFactory.getInstance().CreateMainMenuSprite();
        }

        private void DrawMainMenu()
        {
            mainMenu.RegisterSprite();
        }

        private void ExitMainMenu()
        {
            mainMenu.UnregisterSprite();
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
