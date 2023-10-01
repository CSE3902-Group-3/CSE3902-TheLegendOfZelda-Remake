using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class DamageCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.

        private IPlayer player;

        private bool active;

        public DamageCommand(IPlayer link)
        {
            player = link;

        }

        public void Execute()
        {
            if (active)
            {
                active = false;
                ((Link)player).TakeDamage();
            } else
            {
                active = true;
                ((Link)player).Heal();
            }
        }
    }
}
