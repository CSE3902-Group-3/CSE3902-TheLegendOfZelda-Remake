using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IPlayer : IUpdateable
    {
        ISprite Sprite { get; }
        public RectCollider Collider { get; set; }
        LinkStateMachine StateMachine { get; }

        Vector2 Pos { get; }

        public void Reset();

        public void EnterRoomTransition();
        public void ExitRoomTransition();
    }
}
