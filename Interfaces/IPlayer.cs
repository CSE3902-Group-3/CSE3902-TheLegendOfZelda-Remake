using LegendOfZelda.Player;

namespace LegendOfZelda.Interfaces
{
    public interface IPlayer : IUpdateable
    {
        ISprite sprite { get; }
        LinkStateMachine stateMachine { get; }

        public void UseItem();

        public void ChangeItem(int index);
        public void ChangeWeapon(int index);

        public void Reset();
    }
}
