using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    internal class MovingUpCommand : ICommands
    {
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        //Prepare for later use
        private IState linkState;

        public void Execute()
        {
            spriteFactory = Game1.instance.spriteFactory;
            link = spriteFactory.CreateLinkWalkUpSprite();

            link.UpdatePos(new Microsoft.Xna.Framework.Vector2(0, 0));
        }
    }
}
