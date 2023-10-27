using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyItemDrop
    {
        public enum EnemyClass { A, B, C, D, X };
        public static int DropCounter { get; set; } = 0;
        public static void Drop(EnemyClass classification, Vector2 pos)
        {
            DropCounter++;

            switch (classification)
            {
                case EnemyClass.A:
                    GetClassAItem(pos);
                    break;
                case EnemyClass.B:
                    GetClassBItem(pos);
                    break; 
                case EnemyClass.C:
                    GetClassCItem(pos);
                    break;
                case EnemyClass.D:
                    GetClassDItem(pos);
                    break;
                case EnemyClass.X:
                    break;
            }
        }
        private static void GetClassAItem(Vector2 pos)
        {
            IItem item;
            switch(DropCounter)
            {
                case 0: case 2: case 4: case 7: case 8:
                    item = new OneRupee(pos);
                    break;
                case 3:
                    item = new Fairy(pos);
                    break;
                case 1: case 5: case 6:
                    item = new Heart(pos);
                    break;
                default: // case where drop counter is 9
                    item = new Heart(pos);
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        private static void GetClassBItem(Vector2 pos)
        {
            IItem item;
            switch (DropCounter)
            {
                case 0: case 5: case 7:
                    item = new Bomb(pos);
                    break;
                case 1: case 3: case 6:
                    item = new OneRupee(pos);
                    break;
                case 4: case 8:
                    item = new Heart(pos);
                    break;
                case 2:
                    item = new Clock(pos);
                    break;
                default: // case where drop counter is 9
                    item = new Heart(pos);
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        private static void GetClassCItem(Vector2 pos)
        {
            IItem item;
            switch (DropCounter)
            {
                case 0: case 2: case 6: case 7: case 8:
                    item = new OneRupee(pos);
                    break;
                case 1: case 4:
                    item = new Heart(pos);
                    break;
                case 3:
                    item = new FiveRupee(pos);
                    break;
                case 5:
                    item = new Clock(pos);
                    break;
                default: // case where drop counter is 9
                    item = new FiveRupee(pos);
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
        private static void GetClassDItem(Vector2 pos)
        {
            IItem item;
            switch (DropCounter)
            {
                case 0: case 3: case 5: case 6: case 7:
                    item = new Heart(pos);
                    break;
                case 1: case 4:
                    item = new Fairy(pos);
                    break;
                case 2: case 8:
                    item = new OneRupee(pos);
                    break;
                default: // case where drop counter is 9
                    item = new Heart(pos);
                    DropCounter = 0;
                    break;
            }
            item.Show();
        }
    }
}
