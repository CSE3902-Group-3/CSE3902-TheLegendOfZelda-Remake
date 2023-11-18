using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AllEnemiesDeadBoomerangDropEvent : ILevelEvent
    {
        private int RoomNumber;
        private Vector2 Position;
        public AllEnemiesDeadBoomerangDropEvent(int roomNumber, Vector2 position)
        {
            RoomNumber = roomNumber;
            Position = position;
            LevelManager.AddUpdateable(this);
        }
        private void ConditionSuccess()
        {
            IItem boomerang = new Boomerang(Position);
            boomerang.Show();
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
