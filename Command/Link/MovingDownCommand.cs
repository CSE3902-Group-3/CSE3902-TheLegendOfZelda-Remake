using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    internal class MovingDownCommand : ICommands
    {
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        //Prepare for later use
        private IState linkState;

        public void Execute()
        {
            spriteFactory = Game1.instance.spriteFactory;
            link = spriteFactory.CreateLinkWalkDownSprite();

            link.UpdatePos(new Microsoft.Xna.Framework.Vector2(160, 0));
        }
    }
}
