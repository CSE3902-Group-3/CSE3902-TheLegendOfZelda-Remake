using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LegendOfZelda
{
    internal class LinkCommand : Interfaces.ICommand
    {
        SpriteFactory spriteFactory;
        List<AnimatedSprite> sprites;

        public void excute()
        {
            // DO IT LATER
        }

        public void walkDown()
        {
            sprites.Add(spriteFactory.CreateLinkWalkDownSprite());
        }
    }
}
