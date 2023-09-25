using LegendOfZelda.Player;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interfaces
{
    public interface IPlayer : IUpdateable
    {
        ISprite sprite { get; }
        LinkStateMachine stateMachine { get; }

        Vector2 pos { get; }

        public void UseItem();

        public void ChangeItem(int index);
        public void ChangeWeapon(int index);

        public void Reset();
    }
}
