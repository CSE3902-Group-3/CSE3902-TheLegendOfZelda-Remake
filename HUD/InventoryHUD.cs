using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class InventoryHUD : IHUD
    {
        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;
        private AnimatedSprite InventoryHUDBase;

        public InventoryHUD(Game1 game)
        {
            this.game = game;

            spriteFactory = SpriteFactory.getInstance();
            letterFactory = LetterFactory.GetInstance();
        }

        public void LoadContent()
        {
            InventoryHUDBase = spriteFactory.CreateInventoryHUDSprite();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Show()
        {

        }
    }
}
