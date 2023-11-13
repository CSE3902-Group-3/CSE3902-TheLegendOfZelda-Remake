using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AllEnemiesDeadKeyDropEvent : ILevelEvent
    {
        private int RoomNumber;
        private Vector2 Position;
        public AllEnemiesDeadKeyDropEvent(int roomNumber, Vector2 position)
        {
            RoomNumber = roomNumber;
            Position = position;
            LevelMaster.RegisterUpdateable(this);
        }
        private void ConditionSuccess()
        {
            IItem Key = new Key(Position);
            Key.Show();
            LevelMaster.RemoveUpdateable(this);
        }
        public void CheckCondition()
        {
            if (LevelMaster.EnemiesList[RoomNumber].Count == 0) 
            {
                ConditionSuccess();
            }
        }
        public void Update(GameTime gameTime)
        {
            CheckCondition();
        }
    }
}
