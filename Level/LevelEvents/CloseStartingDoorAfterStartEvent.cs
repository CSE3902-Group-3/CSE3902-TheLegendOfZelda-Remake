using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class CloseStartingDoorAfterStartEvent : ILevelEvent
    {
        private IDoor Door;
        public CloseStartingDoorAfterStartEvent(Room room)
        {
            LevelManager.AddUpdateable(this);
            Door = new CloseableDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
            Door.Open();
        }
        private void ConditionSuccess()
        {
            Door.Close();
            LevelManager.RemoveUpdateable(this);
        }
        public void CheckCondition()
        {
            ConditionSuccess();
        }
        public void Update(GameTime gameTime)
        {
            CheckCondition();
        }
    }
}
