using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class LinkUtilities
    {

        public static Vector2 originalLinkPosition = new Vector2(1504, 832);
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

            return targetPosition;
        }

        public static bool LinkChangedDirection()
        {
            return Link.getInstance().stateMachine.prevDirection != Link.getInstance().stateMachine.currentDirection;
        }

        public static void LinkChangePosToRoom(Vector2 fromRoom, Vector2 toRoom)
        {
            Vector2 linkRoomPos = toRoom + GameState.Link.pos - fromRoom;
            UpdatePositions(GameState.Link, linkRoomPos);
        }
    }
}
