using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class LinkUtilities
    {

        public static Vector2 originalLinkPosition = new Vector2(1448, 864);
        public static int SnapToGrid(int position)
        {
            int alignTo = 8 * SpriteFactory.getInstance().scale;
            int remainder = position % alignTo;
            int halfway = alignTo / 2;

            if (remainder > halfway)
                return alignTo - remainder;
            else
                return -remainder;
        }

        public static void UpdatePositions(Link link, Vector2 newPositon)
        {
            link.sprite.UpdatePos(newPositon);
            link.stateMachine.position = newPositon;
            link.collider.Pos = newPositon;
        }

        public static bool IsStateWithIncompleteAnimation(IState state)
        {
            if (state is AttackingUpLinkState || state is AttackingDownLinkState ||
                state is AttackingLeftLinkState || state is AttackingRightLinkState ||
                state is CollectItemLinkState)
            {
                return !((AnimatedSprite)Game1.getInstance().link.sprite).complete;
            }
            return false;
        }

        public static Vector2 CalcKnockback(Link link)
        {
            Vector2 targetPosition = link.stateMachine.position;

            // Calculate the knockback direction based on Link's current direction
            if (link.stateMachine.currentDirection == Direction.down)
            {
                targetPosition.Y -= 100;
            }
            else if (link.stateMachine.currentDirection == Direction.up)
            {
                targetPosition.Y += 100;
            }
            else if (link.stateMachine.currentDirection == Direction.left)
            {
                targetPosition.X += 100;
            }
            else
            {
                targetPosition.X -= 100;
            }
            
            // move back 2 blocks UNLESS a wall is in the way
            targetPosition.X = MathHelper.Clamp(targetPosition.X, 130, 900);
            targetPosition.Y = MathHelper.Clamp(targetPosition.Y, 450, 825);

            return targetPosition;
        }
    }
}
