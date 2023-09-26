using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using LegendOfZelda.StateMachine.LinkStates.Attack;
using LegendOfZelda.StateMachine.LinkStates.Walk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    public class PrimaryAttackCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
        /*
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        private IState linkState;
        */
        private Player.Link player;


        public PrimaryAttackCommand(Player.Link link)
        {
            player = link;

        }

        public void Execute()
        {
            switch (player.currentDirection)
            {
                case Player.Link.Direction.Left:
                    player.stateMachine.ChangeState(new AttackingLeftLinkState(Game1.instance));
                    break;
                case Player.Link.Direction.Up:
                    player.stateMachine.ChangeState(new AttackingUpLinkState(Game1.instance));
                    break;
                case Player.Link.Direction.Right:
                    player.stateMachine.ChangeState(new AttackingRightLinkState(Game1.instance));
                    break;
                case Player.Link.Direction.Down:
                    player.stateMachine.ChangeState(new AttackingDownLinkState(Game1.instance));
                    break;
            }
        }
    }
}
