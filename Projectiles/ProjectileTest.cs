using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

//This test relies on there already being colliders for walls created somewhere else (such as CollisionDemo)

namespace LegendOfZelda
{
    public class ProjectileTest
    {
        int i = 0;
        double wait = 2;
        Vector2 pos = new Vector2(800, 600);

        public ProjectileTest() {
            Timer timer = new Timer(wait, spawn);
        }

        public void spawn()
        {
            switch (i)
            {
                case 0:
                    new ArrowProjectile(pos, Direction.up);
                    break;
                case 1:
                    new ArrowProjectile(pos, Direction.right);
                    break;
                case 2:
                    new ArrowProjectile(pos, Direction.down);
                    break;
                case 3:
                    new ArrowProjectile(pos, Direction.left);
                    break;
                case 4:
                    new BombProjectile(pos);
                    break;
                case 5:
                    new BoomerangProjectile(pos, new Vector2(1, 1), Game1.getInstance().link);
                    break;
                case 6:
                    new FireProjectile(pos, Direction.up);
                    break;
                case 7:
                    new FireProjectile(pos, Direction.right);
                    break;
                case 8:
                    new FireProjectile(pos, Direction.down);
                    break;
                case 9:
                    new FireProjectile(pos, Direction.left);
                    break;
            }

            i++;
            if (i > 9) i = 0;
            Timer timer = new Timer(wait, spawn);
        }
    }
}
