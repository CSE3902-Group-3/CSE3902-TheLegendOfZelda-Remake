using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    // This class will soon be expanded to encapsulate commonly used code / constants for enemies
    // It is a primitive start for now, but I thought I'd establish it now. - MDC 10/25/23
    public class EnemyUtilities
    {
       public static readonly float DAMAGE_COOLDOWN = 1.0f; // Adjust the delay duration as needed
        public static Vector2 GetCenter(Vector2 pos, int width, int height)
        {
            return new Vector2(pos.X + (width)/2, pos.Y + (height/2));
        }
    }
}
