using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class MovingLeftCommand : ICommands
    {
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        //Prepare for later use
        private IState linkState;

        public void Execute()
        {
            spriteFactory = Game1.instance.spriteFactory;
            link = spriteFactory.CreateLinkWalkLeftSprite();

            link.UpdatePos(new Microsoft.Xna.Framework.Vector2(80, 0));
        }
    }
}
