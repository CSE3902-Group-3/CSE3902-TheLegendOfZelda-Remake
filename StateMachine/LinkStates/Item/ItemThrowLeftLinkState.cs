using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowLeftLinkState : IState
    {
        private Link Link;

        public ItemThrowLeftLinkState()
        {
            this.Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.spawnProjectileCooldown <= 0)
            {
                if (Link.Sprite != null)
                {
                    // if there was a previous sprite, cast then unregister sprite
                    ((AnimatedSprite)Link.Sprite).UnregisterSprite();
                }
                Link.StateMachine.canMove = false;
                Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowLeftSprite();

                // Throw item
                if (Inventory.getInstance().SecondaryItem is Bomb)
                {
                    if (Inventory.getInstance().GetQuantity(new Bomb(new Vector2(0, 0))) > 0)
                    {
                        new BombProjectile(Link.StateMachine.position + LinkUtilities.leftBombOffset);
                        Inventory.getInstance().RemoveItem(new Bomb(new Vector2(0, 0)));
                    }
                }
                else if (Inventory.getInstance().SecondaryItem is Boomerang)
                {
                    new BoomerangProjectile(Link.StateMachine.position + LinkUtilities.leftBoomerangOffset, Direction.left, Link);
                }
                else if (Inventory.getInstance().SecondaryItem is Candle)
                {
                    new FireProjectile(Link.StateMachine.position + LinkUtilities.leftFireOffset, Direction.left);
                }
                else if (Inventory.getInstance().SecondaryItem is Bow)
                {
                    if (Inventory.getInstance().GetQuantity(new Arrow(new Vector2(0, 0))) > 0)
                    {
                        if (Inventory.getInstance().SpendRupee(1))
                        {
                            new ArrowProjectile(GameState.Link.StateMachine.position + LinkUtilities.leftRightSwordBeamOffset, GameState.Link.StateMachine.currentDirection);
                        }

                    }
                }
                Link.spawnProjectileCooldown = Link.spawnProjectileCooldownDuration;  // Reset the cooldown timer
            }
            else
            {
                Link.StateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            Link.StateMachine.canMove = true;
            ((AnimatedSprite)Link.Sprite).UnregisterSprite();
        }

    }
}
