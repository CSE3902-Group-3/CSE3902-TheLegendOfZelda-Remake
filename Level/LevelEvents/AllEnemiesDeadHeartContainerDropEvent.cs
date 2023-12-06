using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AllEnemiesDeadHeartContainerDropEvent : ILevelEvent
    {
        private Vector2 Position;
        public AllEnemiesDeadHeartContainerDropEvent(Vector2 position)
        {
            Position = position;
            LevelManager.AddUpdateable(this);
        }
        private void ConditionSuccess()
        {
            IItem heartContainer = new HeartContainer(Position);
            heartContainer.Show();
            SoundFactory.PlaySound(SoundFactory.getInstance().KeyAppear);
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
