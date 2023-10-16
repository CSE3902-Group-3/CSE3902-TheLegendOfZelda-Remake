using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IPlayer : IUpdateable
    {
        ISprite sprite { get; }
        LinkStateMachine stateMachine { get; }

        Vector2 pos { get; }

        public void UseItem(bool primary);

        public void ChangeItem(int index);
        public void ChangeWeapon(int index);

        public void Reset();
    }
}
