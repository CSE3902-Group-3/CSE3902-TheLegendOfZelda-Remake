using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AttackingRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        private Sword sword;
        private SwordBeam swordBeam;

        public AttackingRightLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.stateMachine.canMove = false;

            link.sprite = SpriteFactory.getInstance().CreateLinkWoodStabRightSprite();

            if (link.HP == link.maxHP)
            {
                swordBeam = new SwordBeam(link.stateMachine.position, link.stateMachine.currentDirection);
            }
            
            sword = new Sword(link.stateMachine.currentDirection, link.stateMachine.position);
        }
        public void Execute()
        {
            if (((AnimatedSprite)link.sprite).complete)
            {
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
            swordBeam?.Destroy();
            sword.Destroy();
        }

    }
}
