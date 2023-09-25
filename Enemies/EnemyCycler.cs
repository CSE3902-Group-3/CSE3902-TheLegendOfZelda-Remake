using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZelda.Interfaces;
using System;

namespace LegendOfZelda.Enemies
{
    public class EnemyCycler
    {
        public Game1 game;
        private readonly List<IEnemy> Enemies;
        private Vector2 Position;
        private int index = 0;

        public EnemyCycler(Vector2 pos)
        {
            game = Game1.instance;
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

        public void CycleForward(GameTime gameTime)
        {
            // TODO: Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index++;
            if (index >= Enemies.Count)
            {
                index = 0;
            }

            // TODO: Draw enemy cloud appearance when an enemy is cycled in
            Enemies[index].Draw();
            Enemies[index].Update(gameTime);
        }

        public void CycleBackward(GameTime gameTime)
        {
            // TODO: Draw enemy death explosion when an enemy is cycled out
            Enemies[index].Die();
            index--;
            if (index < 0)
            {
                index = Enemies.Count - 1;
            }

            // TODO: Draw enemy cloud appearance when an enemy is cycled in
            Enemies[index].Draw();
            Enemies[index].Update(gameTime);
        }
    }
}
