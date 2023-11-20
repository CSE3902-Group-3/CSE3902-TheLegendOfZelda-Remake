using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AttackingDownLinkState : IState
    {
        private Game1 game;
        private Link link;

        private Sword sword;

        public AttackingDownLinkState()
        {
            this.game = Game1.getInstance();
            link = GameState.Link;
        }

        public void Enter()
        {
            if (link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.Sprite).UnregisterSprite();
            }
            link.StateMachine.canMove = false;

            link.Sprite = SpriteFactory.getInstance().CreateLinkWoodStabDownSprite();
            
            if (link.HP == link.MaxHP)
            {
                new SwordBeam(link.StateMachine.position + LinkUtilities.downSwordBeamOffset, link.StateMachine.currentDirection);
            }
            
            sword = new Sword(link.StateMachine.currentDirection, link.StateMachine.position);
        }
        public void Execute()
        {
            if (((AnimatedSprite)link.Sprite).complete)
            {
                link.StateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.StateMachine.canMove = true;

            sword.Destroy();
        }

    }
}
