using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZelda.Interfaces;

namespace LegendOfZelda.Enemies
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
            };

            foreach (IEnemy enemy in Enemies)
            {
                enemy.Die();
            }
        }

        public void CycleForward()
        {
            // Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index++;
            if (index >= Enemies.Count)
            {
                index = 0;
            }
            // Draw enemy cloud appearance when an enemy is cycled in
        }

        public void CycleBackward()
        {
            // Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index--;
            if (index < 0)
            {
                index = Enemies.Count - 1;
            }
            // Draw enemy cloud appearance when an enemy is cycled in
        }
    }
}
