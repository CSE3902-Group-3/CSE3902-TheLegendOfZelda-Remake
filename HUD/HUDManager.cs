using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class HUDManager
    {
        private static HUDManager instance;

        public LowerHUD lowerHUD;
        public InventoryHUD inventoryHUD;
        public MapHUD mapHUD;
        
        public HUDManager()
        {

            lowerHUD = new LowerHUD();
            inventoryHUD = new InventoryHUD();
            mapHUD = new MapHUD();

        }

        public static HUDManager GetInstance()
        {
            if (instance == null)
                instance = new HUDManager();

            return instance;
        }   

        public void LoadContent()
        {
            lowerHUD.LoadContent();
            inventoryHUD.LoadContent();
            mapHUD.LoadContent();
        }

        public void Show()
        {

            // Uncomment one for test
            lowerHUD.Show();
            //inventoryHUD.Show();
            //mapHUD.Show();
        }  
    }
}
