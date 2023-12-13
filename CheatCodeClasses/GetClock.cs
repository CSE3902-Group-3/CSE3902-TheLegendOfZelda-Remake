using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class GetClock : ICheatCode
    {
        Vector2 LinkPos;
        public GetClock()
        {
        }

        public void Execute()
        {
            LinkPos = GameState.Link.Pos;
            Clock item = new(new Vector2(LinkPos.X + 10, LinkPos.Y - 70));
            item.Show();
        }
    }
}