using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LinkUtilities
    {
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

        public static bool IsAttackingStateWithIncompleteAnimation(IState state)
        {
            if (state is AttackingUpLinkState || state is AttackingDownLinkState ||
                state is AttackingLeftLinkState || state is AttackingRightLinkState)
            {
                return !((AnimatedSprite)Game1.getInstance().link.sprite).complete;
            }
            return false;
        }
    }
}
