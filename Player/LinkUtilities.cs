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
            link.Sprite.UpdatePos(newPositon);
            link.StateMachine.position = newPositon;
            link.Collider.Pos = newPositon;
        }

        public static bool IsStateWithIncompleteAnimation(IState state)
        {
            if (state is AttackingUpLinkState || state is AttackingDownLinkState ||
                state is AttackingLeftLinkState || state is AttackingRightLinkState ||
                state is CollectItemLinkState)
            {
                return !((AnimatedSprite)GameState.Link.Sprite).complete;
            }
            return false;
        }

        public static Vector2 CalcKnockback(Link link)
        {
            Vector2 targetPosition = link.StateMachine.position;

            // Calculate the knockback direction based on Link's current direction
            if (link.StateMachine.currentDirection == Direction.down)
            {
                targetPosition.Y -= 100;
            }
            else if (link.StateMachine.currentDirection == Direction.up)
            {
                targetPosition.Y += 100;
            }
            else if (link.StateMachine.currentDirection == Direction.left)
            {
                targetPosition.X += 100;
            }
            else
            {
                targetPosition.X -= 100;
            }

            return targetPosition;
        }

        public static bool LinkChangedDirection()
        {
            return GameState.Link.StateMachine.prevDirection != GameState.Link.StateMachine.currentDirection;
        }
    }
}
