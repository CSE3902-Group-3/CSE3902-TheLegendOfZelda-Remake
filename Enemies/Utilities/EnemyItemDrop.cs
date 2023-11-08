using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyItemDrop
    {
        public enum EnemyClass { A, B, C, D, X };
        public static int DropCounter { get; set; } = 0;
        public static void DropClassAItem(Vector2 pos)
        {
            IItem item;
            DropCounter++;
            switch(DropCounter)
            {
                case 2: case 4: case 7: case 8:
                    item = new OneRupee(new Vector2(pos.X + 6, pos.Y));
                    break;
                case 3:
                    item = new Fairy(new Vector2(pos.X + 4, pos.Y + 4));
                    break;
                case 1: case 5: case 6:
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    break;
                default: // case where drop counter is 9
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        public static void DropClassBItem(Vector2 pos)
        {
            IItem item;
            DropCounter++;
            switch (DropCounter)
            {
                case 5: case 7:
                    item = new Bomb(new Vector2(pos.X + 4, pos.Y + 4));
                    break;
                case 1: case 3: case 6:
                    item = new OneRupee(new Vector2(pos.X + 6, pos.Y));
                    break;
                case 4: case 8:
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    break;
                case 2:
                    item = new Clock(new Vector2(pos.X + 3, pos.Y + 3));
                    break;
                default: // case where drop counter is 9
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        public static void DropClassCItem(Vector2 pos)
        {
            IItem item;
            DropCounter++;
            switch (DropCounter)
            {
                case 2: case 6: case 7: case 8:
                    item = new OneRupee(new Vector2(pos.X + 6, pos.Y));
                    break;
                case 1: case 4:
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    break;
                case 3:
                    item = new FiveRupee(new Vector2(pos.X + 6, pos.Y));
                    break;
                case 5:
                    item = new Clock(new Vector2(pos.X + 3, pos.Y + 3));
                    break;
                default: // case where drop counter is 9
                    item = new FiveRupee(new Vector2(pos.X + 6, pos.Y));
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        public static void DropClassDItem(Vector2 pos)
        {
            IItem item;
            DropCounter++;
            switch (DropCounter)
            {
                case 3: case 5: case 6: case 7:
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    break;
                case 1: case 4:
                    item = new Fairy(new Vector2(pos.X + 4, pos.Y + 4));
                    break;
                case 2: case 8:
                    item = new OneRupee(new Vector2(pos.X + 6, pos.Y));
                    break;
                default: // case where drop counter is 9
                    item = new Heart(new Vector2(pos.X + 5, pos.Y + 5));
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
    }
}
