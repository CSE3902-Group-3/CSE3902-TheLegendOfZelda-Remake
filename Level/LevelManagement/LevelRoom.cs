using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LevelRoom
    {
        private List<IUpdateable> RoomUpdateables;
        private List<IDrawable> RoomDrawables;
        private List<IRectCollider> RoomColliders;
        private List<IEnemy> RoomEnemies;
        private List<IPlayerProjectile> RoomPlayerProjectiles;
        private List<IEnemyProjectile> RoomEnemyProjectiles;
        private Dictionary<Direction, IDoor> RoomDoors;
        private List<IDrawable> DoorFrameSprites;
        public Vector2 RoomPosition { get { return roomPosition; } }
        private Vector2 roomPosition;

        private static BlockLamda BlockLamda = BlockLamda.GetInstance();
        private static ItemLamda ItemLamda = ItemLamda.GetInstance();
        private static EnemyLamda EnemyLamda = EnemyLamda.GetInstance();
        private static EventLamda EventLamda = EventLamda.GetInstance();

        public LevelRoom()
        {
            RoomUpdateables = new List<IUpdateable>();
            RoomDrawables = new List<IDrawable>();
            RoomColliders = new List<IRectCollider>();
            RoomEnemies = new List<IEnemy>();
            RoomPlayerProjectiles = new List<IPlayerProjectile>();
            RoomEnemyProjectiles = new List<IEnemyProjectile>();
            RoomDoors = new Dictionary<Direction, IDoor>();
            DoorFrameSprites = new List<IDrawable>();
        }
        public void LoadRoom (Room room)
        {
            roomPosition = new Vector2(LevelUtilities.RoomWidth * room.RoomXLocation, LevelUtilities.RoomHeight * room.RoomYLocation * -1);
            ProcessMapElements(room);
            ProcessEvents(room);
        }
        private void ProcessMapElements(Room room)
        {
            foreach (MapElement mapElement in room.MapElements)
            {
                switch (mapElement.ElementType)
                {
                    case "Block":
                        BlockLamda.BlockFunctionArray[mapElement.ElementValue](room, mapElement);
                        break;
                    case "Item":
                        ItemLamda.ItemFunctionArray[mapElement.ElementValue](room, mapElement);
                        break;
                    case "Enemy":
                        EnemyLamda.EnemyFunctionArray[mapElement.ElementValue](room, mapElement);
                        break;
                    default:
                        Console.WriteLine("INVALID MAP ELEMENT TYPE: " + mapElement.ElementType);
                        break;
                }
            }
        }
        private void ProcessEvents(Room room)
        {
            foreach (LevelEvent levelEvent in room.Events)
            {
                EventLamda.EventFunctionArray[levelEvent.EventNumber](room, levelEvent);
            }
        }
        public void Update(GameTime gameTime)
        {
            for (int i = RoomUpdateables.Count - 1; i >= 0; i--)
            {
                RoomUpdateables[i].Update(gameTime);
            }
        }
        public bool AddUpdateable(IUpdateable updateable)
        {
            if (RoomUpdateables.Contains(updateable))
            {
                return false;
            }
            RoomUpdateables.Add(updateable);
            return true;
        }
        public bool RemoveUpdateable(IUpdateable updateable)
        {
            return RoomUpdateables.Remove(updateable);
        }
        public bool AddDrawable(IDrawable drawable)
        {
            if (RoomDrawables.Contains(drawable))
            {
                return false;
            }
            RoomDrawables.Add(drawable);
            return true;
        }
        public bool RemoveDrawable(IDrawable drawable)
        {
            return RoomDrawables.Remove(drawable);
        }
        public bool AddCollider(IRectCollider collider)
        {
            if (RoomColliders.Contains(collider))
            {
                return false;
            }
            RoomColliders.Add(collider);
            return true;
        }
        public bool RemoveCollider(IRectCollider collider)
        {
            return RoomColliders.Remove(collider);
        }
        public void AddEnemy(IEnemy enemy)
        {
            RoomEnemies.Add(enemy);
        }
        public void RemoveEnemy(IEnemy enemy)
        {
            RoomEnemies.Remove(enemy);
        }
        public bool EnemiesInRoom()
        {
            if (RoomEnemies.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void SpawnEnemies()
        {
            foreach (IEnemy enemy in RoomEnemies)
            {
                enemy.Spawn();
            }
        }
        public void DespawnEnemies()
        {
            foreach (IEnemy enemy in RoomEnemies)
            {
                enemy.Despawn();
            }
        }
        public void KillAllEnemies()
        {
            for (int i = RoomEnemies.Count - 1; i >= 0; i--)
            {
                RoomEnemies[i].Die();
            }
        }
        public void AddDoor(Direction direction, IDoor door, IAnimatedSprite doorFrameSprite)
        {
            RoomDoors.Add(direction, door);
            DoorFrameSprites.Add(doorFrameSprite);
        }
        public void OpenDoor(Direction direction)
        {
            RoomDoors.TryGetValue(direction, out IDoor door);
            door.Open();
        }
        public void SwitchIn()
        {
            foreach (IRectCollider collider in RoomColliders)
            {
                GameState.CollisionManager.AddRectCollider(collider);
            }
            CameraController.GetInstance().AddDrawablesToBackgroundOfMainCamera(RoomDrawables);
            CameraController.GetInstance().AddDrawablesToForegroundOfMainCamera(DoorFrameSprites);
        }
        public void SwitchOut()
        {
            foreach (IRectCollider collider in RoomColliders)
            {
                GameState.CollisionManager.RemoveRectCollider(collider);
            }
            DestroyAllProjectiles();
            CameraController.GetInstance().RemoveDrawablesFromMainCamera(RoomDrawables);
            CameraController.GetInstance().RemoveDrawablesFromMainCamera(DoorFrameSprites);
        }
        public void AddProjectile(IEnemyProjectile projectile)
        {
            RoomEnemyProjectiles.Add(projectile);
        }
        public void RemoveProjectile(IEnemyProjectile projectile)
        {
            RoomEnemyProjectiles.Remove(projectile);
        }
        public void AddProjectile(IPlayerProjectile projectile)
        {
            RoomPlayerProjectiles.Add(projectile);
        }
        public void RemoveProjectile(IPlayerProjectile projectile)
        {
            RoomPlayerProjectiles.Remove(projectile);
        }
        private void DestroyAllProjectiles()
        {
            for (int i = RoomEnemyProjectiles.Count - 1; i >= 0; i--)
            {
                RoomEnemyProjectiles[i].Destroy();
            }
            for (int i = RoomPlayerProjectiles.Count - 1; i >= 0; i--)
            {
                RoomPlayerProjectiles[i].Destroy();
            }
        }
    }
}