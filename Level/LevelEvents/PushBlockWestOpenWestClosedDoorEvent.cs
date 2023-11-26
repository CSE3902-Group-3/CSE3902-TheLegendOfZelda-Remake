using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Level
{
    internal class PushBlockWestOpenWestClosedDoorEvent : ILevelEvent
    {
        private IDoor Door;
        private MoveWestPushablBlock Block;
        public PushBlockWestOpenWestClosedDoorEvent(Vector2 blockPos, Room room)
        {
            LevelManager.AddUpdateable(this);
            Door = new CloseableDoor(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
            Block = new MoveWestPushablBlock(blockPos);
        }
        private void ConditionSuccess()
        {
            Door.Open();
        }
        private void ConditionFailure()
        {
            Door.Close();
        }
        public void CheckCondition()
        {
            if (Block.Moved)
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
