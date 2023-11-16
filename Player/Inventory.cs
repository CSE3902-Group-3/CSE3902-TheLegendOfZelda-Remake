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
            switch (item)
            {
                case Arrow:
                    inventory[arrow]++;
                    break;

                case Bomb:
                    inventory[bomb]++;
                    break;

                case Boomerang:
                    inventory[boomerang]++;
                    break;

                case Bow:
                    inventory[bow]++;
                    break;

                case Candle:
                    inventory[candle]++;
                    break;

                case Clock:
                    inventory[clock]++;
                    break;

                case Compass:
                    inventory[compass]++;
                    break;

                case Fairy:
                    inventory[fairy]++;
                    break;

                case OneRupee:
                    AddRupee(item);
                    break;

                case FiveRupee:
                    AddRupee(item);
                    break;

                case HeartContainer:
                    inventory[heartContainer]++;
                    break;

                case Key:
                    inventory[key]++;
                    break;

                case Map:
                    inventory[map]++;
                    break;

                case Potion:
                    inventory[potion]++;
                    break;

                case Triforce:
                    inventory[triforce]++;
                    break;
            }
        }

        /* Return a boolean letting player know if item exists in inventory,
         * DO NOT use this for spending rupee!! Use SpendRupee() down below */
        public bool RemoveItem(IItem item)
        {
            bool contain = false;

            switch (item)
            {
                case Arrow:
                    if (inventory[arrow] != 0)
                    {
                        inventory[arrow]--;
                        contain = true;
                    }
                    break;

                case Bomb:
                    if (inventory[bomb] != 0)
                    {
                        inventory[bomb]--;
                        contain = true;
                    }
                    break;

                case Boomerang:
                    if (inventory[boomerang] != 0)
                    {
                        inventory[boomerang]--;
                        contain = true;
                    }
                    break;

                case Bow:
                    if (inventory[bow] != 0)
                    {
                        inventory[bow]--;
                        contain = true;
                    }
                    break;

                case Candle:
                    if (inventory[candle] != 0)
                    {
                        inventory[candle]--;
                        contain = true;
                    }
                    break;

                case Clock:
                    if (inventory[clock] != 0)
                    {
                        inventory[clock]--;
                        contain = true;
                    }
                    break;

                case Compass:
                    if (inventory[compass] != 0)
                    {
                        inventory[compass]--;
                        contain = true;
                    }
                    break;

                case Fairy:
                    if (inventory[fairy] != 0)
                    {
                        inventory[fairy]--;
                        contain = true;
                    }
                    break;

                case HeartContainer:
                    if (inventory[heartContainer] != 0)
                    {
                        inventory[heartContainer]--;
                        contain = true;
                    }
                    break;

                case Key:
                    if (inventory[key] != 0)
                    {
                        inventory[key]--;
                        contain = true;
                    }
                    break;

                case Map:
                    if (inventory[map] != 0)
                    {
                        inventory[map]--;
                        contain = true;
                    }
                    break;

                case Potion:
                    if (inventory[potion] != 0)
                    {
                        inventory[potion]--;
                        contain = true;
                    }
                    break;

                case Triforce:
                    if (inventory[triforce] != 0)
                    {
                        inventory[triforce]--;
                        contain = true;
                    }
                    break;
            }

            return contain;
        }

        public void AddRupee(IItem incomingRupee)
        {
            if (incomingRupee is FiveRupee)
            {
                inventory[rupee] += 5;
            }
            else if (incomingRupee is OneRupee)
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

            switch (item)
            {
                case Arrow:
                    itemAmount = inventory[arrow];
                    break;

                case Bomb:
                    itemAmount = inventory[bomb];
                    break;

                case Boomerang:
                    itemAmount = inventory[boomerang];
                    break;

                case Bow:
                    itemAmount = inventory[bow];
                    break;

                case Candle:
                    itemAmount = inventory[candle];
                    break;

                case Clock:
                    itemAmount = inventory[clock];
                    break;

                case Compass:
                    itemAmount = inventory[compass];
                    break;

                case Fairy:
                    itemAmount = inventory[fairy];
                    break;

                case OneRupee:
                    itemAmount = inventory[rupee];
                    break;

                case FiveRupee:
                    itemAmount = inventory[rupee];
                    break;

                case HeartContainer:
                    itemAmount = inventory[heartContainer];
                    break;

                case Key:
                    itemAmount = inventory[key];
                    break;

                case Map:
                    itemAmount = inventory[map];
                    break;

                case Potion:
                    itemAmount = inventory[potion];
                    break;

                case Triforce:
                    itemAmount = inventory[triforce];
                    break;
            }

            return itemAmount;
        }
    }
}

