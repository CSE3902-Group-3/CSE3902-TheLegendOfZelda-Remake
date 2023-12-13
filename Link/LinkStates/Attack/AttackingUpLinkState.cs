using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AttackingUpLinkState : IState
    {
        private Link Link;

        private Sword Sword;

        public AttackingUpLinkState()
        {
            Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;

            Link.Sprite = SpriteFactory.getInstance().CreateLinkWoodStabUpSprite();

            if (Link.HP == Link.MaxHP && Link.spawnProjectileCooldown <= 0)
            {
                new SwordBeam(Link.StateMachine.position + LinkUtilities.upSwordBeamOffset, Link.StateMachine.currentDirection);
                Link.spawnProjectileCooldown = Link.spawnProjectileCooldownDuration;  // Reset the cooldown timer
            }

            Sword = new Sword(Link.StateMachine.currentDirection, Link.StateMachine.position);
        }

        public void Execute()
        {
            if (((AnimatedSprite)Link.Sprite).complete)
            {
                Link.StateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            Link.StateMachine.canMove = true;
            Sword.Destroy();
        }

    }
}
