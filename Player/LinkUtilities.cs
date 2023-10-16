using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LinkUtilities
    {
        // I can't just multiply by SpriteFactory.getInstance().scale because it must be a compile time constant
        public static int SnapToGrid(int position, int alignTo = 64) // original 8 * scale 8
        {
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
    }
}
