using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IPlayer : IUpdateable
    {
        ISprite sprite { get; }
        public RectCollider collider { get; set; }
        LinkStateMachine stateMachine { get; }

        Vector2 pos { get; }

        public void Reset();

        public void EnterRoomTransition(Direction direction);
        public void ExitRoomTransition();
    }
}
