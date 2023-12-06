using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Invincible : ICheatCode
    {
        private Link link;
        private bool invincible;
        public Invincible()
        {
            link = GameState.Link;
            invincible = false;
        }

        public void Execute()
        {
            if (invincible)
            {
                invincible = false;
                link.SetInvincible(false);
            }
            else
            {
                invincible = true;
                link.SetInvincible(true);
            }
        }
    }
}
