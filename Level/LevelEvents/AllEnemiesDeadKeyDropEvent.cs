using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AllEnemiesDeadKeyDropEvent : ILevelEvent
    {
        private Vector2 Position;
        public AllEnemiesDeadKeyDropEvent(Vector2 position)
        {
            Position = position;
            LevelManager.AddUpdateable(this);
        }
        private void ConditionSuccess()
        {
            IItem key = new Key(Position);
            key.Show();
            LevelManager.RemoveUpdateable(this);
        }
        public void CheckCondition()
        {
            if (!LevelManager.CurrentLevelRoom.EnemiesInRoom()) 
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
