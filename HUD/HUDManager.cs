using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZeld
{
    public class HUDManager
    {
        Game1 game;

        private LowerHUD lowerHUD;
        private InventoryHUD inventoryHUD;
        private MapHUD mapHUD;

        public HUDManager(Game1 game)
        {
            this.game = game;

            lowerHUD = new LowerHUD(game);
            inventoryHUD = new InventoryHUD(game);
            mapHUD = new MapHUD(game);
        }

        public void LoadContent()
        {
            lowerHUD.LoadContent();
            inventoryHUD.LoadContent();
            mapHUD.LoadContent();
        }

        public void Show()
        {

        }  
    }
}
