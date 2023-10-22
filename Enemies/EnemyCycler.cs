using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{

    public class EnemyCycler
    {
        private readonly List<IEnemy> Enemies;
        private Vector2 Position;
        private int index = 0;

        public EnemyCycler(Vector2 pos)
        {
            Position = pos;
            Enemies = new List<IEnemy>()
            {
                new Bat(Position),
                new Skeleton(Position),
                new Goriya(Position),
                new GelSmall(Position),
                new ZolBig(Position),
                new Wizard(Position),
                new Aquamentus(Position),
                new Rope(Position),
                new NewDodongo(Position),
                new WallMaster(Position),
                new BladeTrap(Position),
            };

            foreach (IEnemy entity in Enemies)
            {
                entity.Die();
            }

            // Draw the first enemy to the screen
            Enemies[0].Spawn();
        }

        public void CycleForward()
        {
            // TODO: Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index++;
            if (index >= Enemies.Count)
            {
                index = 0;
            }

            // TODO: Draw enemy cloud appearance when an enemy is cycled in
            Enemies[index].Spawn();
        }

        public void CycleBackward()
        {
            // This method will be more useful when the button commands are available

            // TODO: Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index--;
            if (index < 0)
            {
                index = Enemies.Count - 1;
            }

            // TODO: Draw enemy cloud appearance when an enemy is cycled in
            Enemies[index].Spawn();
        }

        public void Reset()
        {
            foreach (IEnemy entity in Enemies)
            {
                entity.Die();
            }

            index = 0;
            // Draw the first enemy to the screen
            Enemies[index].Spawn();
        }
    }
}
