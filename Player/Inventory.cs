using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
	public class Inventory
	{
        private Dictionary<IItem, int> inventory;
        private Arrow arrow;
        private Bomb bomb;
        private Boomerang boomerang;
        private Bow bow;
        private Candle candle;
        private Clock clock;
        private Compass compass;
        private Fairy fairy;
        private OneRupee rupee;
        private HeartContainer heartContainer;
        private Key key;
        private Map map;
        private Potion potion;
        private Triforce triforce;

        // HUD should use this
        private IItem _secondaryItem;

        public IItem SecondaryItem
        {
            get { return _secondaryItem; }
            set
            {
                if (GetQuantity(value) > 0)
                {
                    _secondaryItem = value;
                }
            }
        }


        private static Inventory instance;

        public static Inventory getInstance()
        {
            if (instance == null)
                instance = new Inventory();

            return instance;
        }

        private Inventory()
        {
            /* All items in inventory will have a position of (0, 0),
             * their position can be changed when being used.
             */
            arrow = new Arrow(Vector2.Zero);
            bomb = new Bomb(Vector2.Zero);
            boomerang = new Boomerang(Vector2.Zero);
            bow = new Bow(Vector2.Zero);
            candle = new Candle(Vector2.Zero);
            clock = new Clock(Vector2.Zero);
            compass = new Compass(Vector2.Zero);
            fairy = new Fairy(Vector2.Zero);
            rupee = new OneRupee(Vector2.Zero);
            heartContainer = new HeartContainer(Vector2.Zero);
            key = new Key(Vector2.Zero);
            map = new Map(Vector2.Zero);
            potion = new Potion(Vector2.Zero);
            triforce = new Triforce(Vector2.Zero);

            inventory = new Dictionary<IItem, int>
            {
                { arrow, 0 },
                { bomb, 0 },
                { boomerang, 0 },
                { bow, 0 },
                { candle, 0 },
                { clock, 0 },
                { compass, 0 },
                { fairy, 0 },
                { rupee, 0 },
                { heartContainer, 0 },
                { key, 0 },
                { map, 0 },
                { potion, 0 },
                { triforce, 0 }
            };
        }

        public void AddItem(IItem item)
        {
            if (item is Arrow)
            {
                inventory[arrow]++;
            }
            if (item is Bomb)
            {
                inventory[bomb]++;
            }
            if (item is Boomerang)
            {
                inventory[boomerang]++;
            }
            if (item is Bow)
            {
                inventory[bow]++;
            }
            if (item is Candle)
            {
                inventory[candle]++;
            }
            if (item is Clock)
            {
                inventory[clock]++;
            }
            if (item is Compass)
            {
                inventory[compass]++;
            }
            if (item is Fairy)
            {
                inventory[fairy]++;
            }
            if (item is OneRupee)
            {
                AddRupee(item);
            }
            if (item is FiveRupee)
            {
                AddRupee(item);
            }
            if (item is HeartContainer)
            {
                inventory[heartContainer]++;
            }
            if (item is Key)
            {
                inventory[key]++;
            }
            if (item is Map)
            {
                inventory[map]++;
            }
            if (item is Potion)
            {
                inventory[potion]++;
            }
            if (item is Triforce)
            {
                inventory[triforce]++;
            }
        }

        /* Return a boolean letting player know if item exists in inventory,
         * DO NOT use this for spending rupee!! Use SpendRupee() down below */
        public bool RemoveItem(IItem item)
        {
            bool contain = false;

            if (item is Arrow)
            {
                if (inventory[arrow] != 0)
                {
                    inventory[arrow]--;
                    contain = true;
                }
            }
            if (item is Bomb)
            {
                if (inventory[bomb] != 0)
                {
                    inventory[bomb]--;
                    contain = true;
                }
            }
            if (item is Boomerang)
            {
                if (inventory[boomerang] != 0)
                {
                    inventory[boomerang]--;
                    contain = true;
                }
            }
            if (item is Bow)
            {
                if (inventory[bow] != 0)
                {
                    inventory[bow]--;
                    contain = true;
                }
            }
            if (item is Candle)
            {
                if (inventory[candle] != 0)
                {
                    inventory[candle]--;
                    contain = true;
                }
            }
            if (item is Clock)
            {
                if(inventory[clock] != 0)
                {
                    inventory[clock]--;
                    contain = true;
                }
            }
            if (item is Compass)
            {
                if (inventory[compass] != 0)
                {
                    inventory[compass]--;
                    contain = true;
                }
            }
            if (item is Fairy)
            {
                if (inventory[fairy] != 0)
                {
                    inventory[fairy]--;
                    contain = true;
                }
            }
            if (item is HeartContainer)
            {
                if (inventory[heartContainer] != 0)
                {
                    inventory[heartContainer]--;
                    contain = true;
                }
            }
            if (item is Key)
            {
                if (inventory[key] != 0)
                {
                    inventory[key]--;
                    contain = true;
                }
            }
            if (item is Map)
            {
                if (inventory[map] != 0)
                {
                    inventory[map]--;
                    contain = true;
                }
            }
            if (item is Potion)
            {
                if (inventory[potion] != 0)
                {
                    inventory[potion]--;
                    contain = true;
                }
            }
            if (item is Triforce)
            {
                if (inventory[triforce] != 0)
                {
                    inventory[triforce]--;
                    contain = true;
                }
            }

            return contain;
        }

        public void AddRupee(IItem incomingRupee)
        {
            if (incomingRupee is FiveRupee)
            {
                inventory[rupee] += 5;
            }
            if (incomingRupee is OneRupee)
            {
                inventory[rupee]++;
            }
        }

        /* USE THIS METHOD when spending rupee */
        public bool SpendRupee(int price)
        {
            bool afford = true;
            int inPocket = inventory[rupee];
            if (inPocket < price)
            {
                afford = false;
            }
            if (afford)
            {
                inventory[rupee] -= price;
            }

            return afford;
        }

        public int GetQuantity(IItem item)
        {
            int itemAmount = 0;

            if (item is Arrow)
            {
                itemAmount = inventory[arrow];
            }
            if (item is Bomb)
            {
                itemAmount = inventory[bomb];
            }
            if (item is Boomerang)
            {
                itemAmount = inventory[boomerang];
            }
            if (item is Bow)
            {
                itemAmount = inventory[bow];
            }
            if (item is Candle)
            {
                itemAmount = inventory[candle];
            }
            if (item is Clock)
            {
                itemAmount = inventory[clock];
            }
            if (item is Compass)
            {
                itemAmount = inventory[compass];
            }
            if (item is Fairy)
            {
                itemAmount = inventory[fairy];
            }
            if (item is OneRupee)
            {
                itemAmount = inventory[rupee];
            }
            if (item is FiveRupee)
            {
                itemAmount = inventory[rupee];
            }
            if (item is HeartContainer)
            {
                itemAmount = inventory[heartContainer];
            }
            if (item is Key)
            {
                itemAmount = inventory[key];
            }
            if (item is Map)
            {
                itemAmount = inventory[map];
            }
            if (item is Potion)
            {
                itemAmount = inventory[potion];
            }
            if (item is Triforce)
            {
                itemAmount = inventory[triforce];
            }

            return itemAmount;
        }
    }
}

