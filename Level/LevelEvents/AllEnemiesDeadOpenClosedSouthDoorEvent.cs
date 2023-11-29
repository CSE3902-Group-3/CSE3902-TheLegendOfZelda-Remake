using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AllEnemiesDeadOpenClosedSouthDoorEvent : ILevelEvent
    {
        private IDoor Door;
        public AllEnemiesDeadOpenClosedSouthDoorEvent(Room room)
        {
            LevelManager.AddUpdateable(this);
            Door = new CloseableDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        private void ConditionSuccess()
        {
            Door.Open();
            LevelManager.RemoveUpdateable(this);
        }
        private void ConditionFailure()
        {
            Door.Close();
        }
        public void CheckCondition()
        {
            if (!LevelManager.CurrentLevelRoom.EnemiesInRoom())
            {
                ConditionSuccess();
            }
            else
            {
                ConditionFailure();
            }
        }
        public void Update(GameTime gameTime)
        {
            CheckCondition();
        }
    }
}
