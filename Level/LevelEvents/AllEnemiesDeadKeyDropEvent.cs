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
            LevelManager.AddUpdateable(this);
        }
        private void ConditionSuccess()
        {
            IItem key = new Key(Position);
            key.Show();
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
