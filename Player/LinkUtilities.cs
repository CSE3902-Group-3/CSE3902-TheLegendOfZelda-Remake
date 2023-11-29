using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class LinkUtilities
    {

        public static Vector2 originalLinkPosition = new Vector2(LevelManager.CurrentRoomPosition.X + (LevelUtilities.RoomWidth - LevelUtilities.GridUnitSize) / 2, LevelManager.CurrentRoomPosition.Y + LevelUtilities.RoomHeight);

        public static Vector2 upBombOffset = new Vector2(15, -90);
        public static Vector2 rightBombOffset = new Vector2(90, 0);
        public static Vector2 leftBombOffset = new Vector2(-90, 0);
        public static Vector2 downBombOffset = new Vector2(15, 90);

        public static Vector2 upFireOffet = new Vector2(0, -90);
        public static Vector2 rightFireOffset = new Vector2(90, 0);
        public static Vector2 leftFireOffset = new Vector2(-90, 0);
        public static Vector2 downFireOffset = new Vector2(0, 90);

        public static Vector2 upSwordBeamOffset = new Vector2(13, 0);
        public static Vector2 downSwordBeamOffset = new Vector2(20, 0);
        public static Vector2 leftRightSwordBeamOffset = new Vector2(0, 25);

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
                state is CollectItemLinkState )
            {
                return !((AnimatedSprite)GameState.Link.Sprite).complete;
            }
            if (state is DeathLinkState)
            {
                return true;
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

        public static void LinkChangePosToRoom(Vector2 fromRoom, Vector2 toRoom)
        {
            Vector2 linkRoomPos = toRoom + GameState.Link.Pos - fromRoom;
            UpdatePositions(GameState.Link, linkRoomPos);
        }
    }
}
