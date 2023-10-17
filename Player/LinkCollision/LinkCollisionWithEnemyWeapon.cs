using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Player.LinkCollision
{
    public class LinkCollisionWithEnemyWeapon
    {
        public static void HandleCollisionWithEnemy()
        {
            ((Link)Game1.getInstance().link).TakeDamage();
        }
    }
}
